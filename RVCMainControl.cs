using Rhino;
using Rhino.DocObjects;
using Rhino.Geometry;
using RVC.Data;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RVC
{
    namespace Forms
    {
        [System.Runtime.InteropServices.Guid("28497D98-E8DB-4886-A66F-A8BF7331C6BD")]
        public partial class RVCMainControl : UserControl
        {
            public static Guid PanelId => typeof(RVCMainControl).GUID;

            bool checkoutAvailable;

            public DiffResults lastDiffResult;

            public RVCMainControl()
            {
                InitializeComponent();

                RVCPlugin.Instance.MainPanel = this;

                VisibleChanged += OnVisibleChanged;
                Disposed += OnUserControlDisposed;

                checkoutAvailable = false;
                lastDiffResult = null;
            }

            void OnVisibleChanged(object sender, EventArgs e)
            {
                RhinoDoc currDoc = RhinoDoc.ActiveDoc;
                if (currDoc != null)
                    this.UpdateData(currDoc);

                // Really ugly hack here
            }

            void OnUserControlDisposed(object sender, EventArgs e)
            {
                RVCPlugin.Instance.MainPanel = null;
            }

            private void RVCMainControl_Load(object sender, EventArgs e)
            {
            }

            private void CommitListView_Resize(object sender, EventArgs e)
            {
                // Resize Last columns
                ListView lv = (ListView)sender;
                lv.Columns[lv.Columns.Count - 1].Width = -2;

                lv.Refresh();
            }

            private void CommitListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
            {
                ListView lv = (ListView)sender;
                lv.Columns[lv.Columns.Count - 1].Width = -2;

                lv.Refresh();
            }

            public void UpdateData()
            {
                // Do our best here and just use ActiveDoc
                this.UpdateData(RhinoDoc.ActiveDoc);
            }

            private void updateCommitData(FileRecord data)
            {
                // Clear commit view first
                CommitListView.Items.Clear();

                // Populate commit view
                // Note data needs to be completely de-serialized before being passed back
                // Refactor when we're done with this...

                // ADDITIONALLY: we will pre-sort our data here bc it's a pain to do that with the list view

                SortedList sortByTime = new SortedList();

                foreach (DictionaryEntry kv in data.commits)
                {
                    FileCommit commit = (FileCommit)kv.Value;
                    sortByTime.Add(-commit.Time.Ticks, commit);
                }

                foreach (DictionaryEntry kv in sortByTime)
                {
                    FileCommit commit = (FileCommit)kv.Value;
                    string idText = commit.Id.ToString();

                    // Use local time for display purposes
                    DateTime localTime = commit.Time.ToLocalTime();
                    string timeText = localTime.ToShortDateString() + ", " + localTime.ToShortTimeString();

                    string authorText = commit.Author.ToString();
                    string commentsText = commit.Comment.ToString();

                    ListViewItem item = new ListViewItem(new[] { idText, timeText, authorText, commentsText });

                    CommitListView.Items.Add(item);
                }
            }

            public void UpdateStagingButtons(RhinoDoc doc)
            {
                if (File.Exists(RVCFiles.rvcTempFile(doc)))
                {
                    checkoutAvailable = false;

                    RestoreButton.Enabled = true;
                    DiscardButton.Enabled = true;
                }
                else
                {
                    checkoutAvailable = true;

                    RestoreButton.Enabled = false;
                    DiscardButton.Enabled = false;
                }

                if (CommitListView.SelectedItems.Count == 1)
                    CheckoutButton.Enabled = checkoutAvailable;
                else
                    CheckoutButton.Enabled = false;

            }

            public void UpdateData(RhinoDoc doc)
            {
                FileRecord newRecord = FileRecord.loadRecord(doc);

                if (newRecord != null)
                {
                    this.updateCommitData(newRecord);

                    FilenameText.Text = doc.Name;
                    FilenameText.Enabled = true;
                    StatusText.Text = "Record loaded.";
                    StatusText.Enabled = true;

                    AddButton.Enabled = false;
                    UpdateButton.Enabled = true;
                    AuthorBox.Enabled = true;
                    CommentsBox.Enabled = true;
                    CommitButton.Enabled = true;

                    updateDiffSelectionButton.Enabled = true;
                    SelectedCommitsList.Enabled = true;
                    objList.Enabled = true;
                    diffButton.Enabled = true;
                }
                else
                {
                    FilenameText.Text = doc.Name;
                    FilenameText.Enabled = false;
                    StatusText.Text = "No record loaded";
                    StatusText.Enabled = false;

                    AddButton.Enabled = true;
                    UpdateButton.Enabled = true;
                    AuthorBox.Enabled = false;
                    CommentsBox.Enabled = false;
                    CommitButton.Enabled = false;

                    updateDiffSelectionButton.Enabled = false;
                    SelectedCommitsList.Enabled = false;
                    objList.Enabled = false;
                    diffButton.Enabled = false;
                }

                UpdateStagingButtons(doc);
            }

            private void UpdateButton_Click(object sender, EventArgs e)
            {
                UpdateData();
            }

            private void CommitButton_Click(object sender, EventArgs e)
            {
                if (CommentsBox.Text.Equals("") || AuthorBox.Text.Equals(""))
                {
                    RVCUtilities.writeErr("Author and comments cannot be empty.");
                    return;
                }

                RVCommandCommit.Instance.Commit(RhinoDoc.ActiveDoc, AuthorBox.Text, CommentsBox.Text);

                CommentsBox.Text = "";

                UpdateData();
            }

            private void AddButton_Click(object sender, EventArgs e)
            {
                RVCommandAdd.Instance.Add(RhinoDoc.ActiveDoc);

                UpdateData();
            }

            private void CommitListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
            {
                UpdateStagingButtons(RhinoDoc.ActiveDoc);
            }

            private void CheckoutButton_Click(object sender, EventArgs e)
            {
                if (CommitListView.SelectedItems.Count != 1)
                    return;

                foreach (ListViewItem item in CommitListView.SelectedItems)
                {
                    string idToBeCheckedOut = item.SubItems[0].Text;
                    RVCommandCheckout.Instance.Checkout(RhinoDoc.ActiveDoc, idToBeCheckedOut);
                }

                UpdateData();
            }

            private void RestoreButton_Click(object sender, EventArgs e)
            {
                RhinoDoc doc = RhinoDoc.ActiveDoc;
                RVCommandRestore.Instance.Restore(doc);
                RVCommandDiscard.Instance.Discard(doc);

                UpdateStagingButtons(doc);
            }

            private void DiscardButton_Click(object sender, EventArgs e)
            {
                RhinoDoc doc = RhinoDoc.ActiveDoc;
                RVCommandDiscard.Instance.Discard(doc);

                UpdateStagingButtons(doc);
            }

            private void updateDiffSelectionButton_Click(object sender, EventArgs e)
            {
                SelectedCommitsList.Items.Clear();

                if (CommitListView.SelectedItems.Count == 2 || CommitListView.SelectedItems.Count == 1)
                {
                    foreach (ListViewItem item in CommitListView.SelectedItems)
                        SelectedCommitsList.Items.Add((ListViewItem)item.Clone());
                }
                else
                {
                    // Do nothing
                }
            }

            private void diffButton_Click(object sender, EventArgs e)
            {
                RVCPlugin.Instance.DrawingHost.ClearConduits();

                objList.Items.Clear();

                DiffResults result;

                if (SelectedCommitsList.Items.Count == 2)
                {
                    string a = SelectedCommitsList.Items[0].SubItems[0].Text;
                    string b = SelectedCommitsList.Items[1].SubItems[0].Text;

                    result = RVCommandDiff.Instance.Diff(RhinoDoc.ActiveDoc, a, b);

                }
                else if (SelectedCommitsList.Items.Count == 1)
                {
                    string b = SelectedCommitsList.Items[0].SubItems[0].Text;

                    result = RVCommandDiff.Instance.Diff(RhinoDoc.ActiveDoc, b);
                }
                else
                    return;

                lastDiffResult = result;

                foreach (DictionaryEntry kv in result.Added)
                {
                    RhinoObject obj = (RhinoObject)kv.Value;
                    ListViewItem item = new ListViewItem(new[] { "+", obj.ObjectType.ToString(), obj.Id.ToString() });

                    objList.Items.Add(item);
                }

                foreach (DictionaryEntry kv in result.Modified)
                {
                    RhinoObject obj = (RhinoObject)kv.Value;
                    ListViewItem item = new ListViewItem(new[] { "~", obj.ObjectType.ToString(), obj.Id.ToString() });

                    objList.Items.Add(item);
                }

                foreach (DictionaryEntry kv in result.Removed)
                {
                    RhinoObject obj = (RhinoObject)kv.Value;
                    ListViewItem item = new ListViewItem(new[] { "-", obj.ObjectType.ToString(), obj.Id.ToString() });

                    objList.Items.Add(item);
                }

                objectCountText.Text = objList.Items.Count.ToString() + " Objects";
            }

            private void objList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
            {

            }

            private void objList_MouseClick(object sender, MouseEventArgs e)
            {
                RVCPlugin.Instance.DrawingHost.ClearConduits();

                //     if (objList.SelectedItems.Count == 0)
                //   {
                //     RhinoDoc.ActiveDoc.Views.Redraw();
                //   return;
                // }

                // Use these to store MESHES
                ArrayList a = new ArrayList();
                ArrayList m = new ArrayList();
                ArrayList r = new ArrayList();

                foreach (ListViewItem item in objList.SelectedItems)
                {
                    Guid objectId = Guid.Parse(item.SubItems[2].Text);

                    if (item.SubItems[0].Text == "+")
                        a.Add((Mesh)lastDiffResult.meshAdded.Meshes[objectId]);

                    if (item.SubItems[0].Text == "~")
                        m.Add((Mesh)lastDiffResult.meshModified.Meshes[objectId]);

                    if (item.SubItems[0].Text == "-")
                        r.Add((Mesh)lastDiffResult.meshRemoved.Meshes[objectId]);
                }

                // Git color styles

                RVCPlugin.Instance.DrawingHost.AddConduitForMeshes(a, Color.DarkGreen);
                RVCPlugin.Instance.DrawingHost.AddConduitForMeshes(m, Color.Gold);
                RVCPlugin.Instance.DrawingHost.AddConduitForMeshes(r, Color.Crimson);

                RhinoDoc.ActiveDoc.Views.Redraw();

            }
        }
    }
}
