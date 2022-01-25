namespace RVC
{
    namespace Forms
    {
        partial class RVCMainControl
        {
            /// <summary> 
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary> 
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Component Designer generated code

            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.ListPanel = new System.Windows.Forms.Panel();
            this.CommitListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.CheckoutGroup = new System.Windows.Forms.GroupBox();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.CheckoutButton = new System.Windows.Forms.Button();
            this.CommitGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AuthorBox = new System.Windows.Forms.TextBox();
            this.CommentsBox = new System.Windows.Forms.TextBox();
            this.CommitButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.objectCountText = new System.Windows.Forms.Label();
            this.objList = new System.Windows.Forms.ListView();
            this.objMod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.objType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.objId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedCommitsList = new System.Windows.Forms.ListView();
            this.selectedId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectedTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectedAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectedComments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.diffButton = new System.Windows.Forms.Button();
            this.updateDiffSelectionButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.StatusText = new System.Windows.Forms.Label();
            this.FilenameText = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ListPanel.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.CheckoutGroup.SuspendLayout();
            this.CommitGroup.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListPanel
            // 
            this.ListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListPanel.Controls.Add(this.CommitListView);
            this.ListPanel.Location = new System.Drawing.Point(0, 408);
            this.ListPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(352, 239);
            this.ListPanel.TabIndex = 1;
            // 
            // CommitListView
            // 
            this.CommitListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CommitListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.time,
            this.author,
            this.comments});
            this.CommitListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommitListView.FullRowSelect = true;
            this.CommitListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.CommitListView.HideSelection = false;
            this.CommitListView.Location = new System.Drawing.Point(0, 0);
            this.CommitListView.Margin = new System.Windows.Forms.Padding(0);
            this.CommitListView.MinimumSize = new System.Drawing.Size(100, 10);
            this.CommitListView.Name = "CommitListView";
            this.CommitListView.ShowGroups = false;
            this.CommitListView.Size = new System.Drawing.Size(352, 239);
            this.CommitListView.TabIndex = 7;
            this.CommitListView.UseCompatibleStateImageBehavior = false;
            this.CommitListView.View = System.Windows.Forms.View.Details;
            this.CommitListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.CommitListView_ItemSelectionChanged);
            // 
            // id
            // 
            this.id.Text = "Commit ID";
            this.id.Width = 100;
            // 
            // time
            // 
            this.time.Text = "Time Added";
            this.time.Width = 79;
            // 
            // author
            // 
            this.author.Text = "Author";
            this.author.Width = 75;
            // 
            // comments
            // 
            this.comments.Text = "Comments";
            this.comments.Width = 78;
            // 
            // mainTabs
            // 
            this.mainTabs.Controls.Add(this.tabPage1);
            this.mainTabs.Controls.Add(this.tabPage2);
            this.mainTabs.Controls.Add(this.tabPage3);
            this.mainTabs.Controls.Add(this.tabPage4);
            this.mainTabs.Location = new System.Drawing.Point(0, 62);
            this.mainTabs.Margin = new System.Windows.Forms.Padding(0);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(352, 346);
            this.mainTabs.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TopPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(344, 320);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Commit History";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.CheckoutGroup);
            this.TopPanel.Controls.Add(this.CommitGroup);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(3, 3);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(338, 305);
            this.TopPanel.TabIndex = 9;
            // 
            // CheckoutGroup
            // 
            this.CheckoutGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckoutGroup.Controls.Add(this.DiscardButton);
            this.CheckoutGroup.Controls.Add(this.RestoreButton);
            this.CheckoutGroup.Controls.Add(this.CheckoutButton);
            this.CheckoutGroup.Location = new System.Drawing.Point(5, 245);
            this.CheckoutGroup.Margin = new System.Windows.Forms.Padding(5);
            this.CheckoutGroup.Name = "CheckoutGroup";
            this.CheckoutGroup.Padding = new System.Windows.Forms.Padding(0);
            this.CheckoutGroup.Size = new System.Drawing.Size(336, 55);
            this.CheckoutGroup.TabIndex = 6;
            this.CheckoutGroup.TabStop = false;
            this.CheckoutGroup.Text = "Checkout Previous Commit";
            // 
            // DiscardButton
            // 
            this.DiscardButton.Location = new System.Drawing.Point(247, 19);
            this.DiscardButton.Name = "DiscardButton";
            this.DiscardButton.Size = new System.Drawing.Size(82, 25);
            this.DiscardButton.TabIndex = 6;
            this.DiscardButton.Text = "Discard";
            this.DiscardButton.UseVisualStyleBackColor = true;
            this.DiscardButton.Click += new System.EventHandler(this.DiscardButton_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Location = new System.Drawing.Point(156, 19);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(85, 25);
            this.RestoreButton.TabIndex = 5;
            this.RestoreButton.Text = "Restore";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // CheckoutButton
            // 
            this.CheckoutButton.Location = new System.Drawing.Point(6, 19);
            this.CheckoutButton.Name = "CheckoutButton";
            this.CheckoutButton.Size = new System.Drawing.Size(141, 25);
            this.CheckoutButton.TabIndex = 4;
            this.CheckoutButton.Text = "Checkout";
            this.CheckoutButton.UseVisualStyleBackColor = true;
            this.CheckoutButton.Click += new System.EventHandler(this.CheckoutButton_Click);
            // 
            // CommitGroup
            // 
            this.CommitGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CommitGroup.Controls.Add(this.label2);
            this.CommitGroup.Controls.Add(this.label1);
            this.CommitGroup.Controls.Add(this.AuthorBox);
            this.CommitGroup.Controls.Add(this.CommentsBox);
            this.CommitGroup.Controls.Add(this.CommitButton);
            this.CommitGroup.Location = new System.Drawing.Point(5, 5);
            this.CommitGroup.Margin = new System.Windows.Forms.Padding(5);
            this.CommitGroup.Name = "CommitGroup";
            this.CommitGroup.Padding = new System.Windows.Forms.Padding(0);
            this.CommitGroup.Size = new System.Drawing.Size(332, 235);
            this.CommitGroup.TabIndex = 7;
            this.CommitGroup.TabStop = false;
            this.CommitGroup.Text = "New Commit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Comments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Author";
            // 
            // AuthorBox
            // 
            this.AuthorBox.Location = new System.Drawing.Point(6, 36);
            this.AuthorBox.Name = "AuthorBox";
            this.AuthorBox.Size = new System.Drawing.Size(323, 20);
            this.AuthorBox.TabIndex = 3;
            // 
            // CommentsBox
            // 
            this.CommentsBox.Location = new System.Drawing.Point(6, 75);
            this.CommentsBox.Multiline = true;
            this.CommentsBox.Name = "CommentsBox";
            this.CommentsBox.Size = new System.Drawing.Size(323, 121);
            this.CommentsBox.TabIndex = 2;
            // 
            // CommitButton
            // 
            this.CommitButton.Location = new System.Drawing.Point(6, 202);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(323, 25);
            this.CommitButton.TabIndex = 1;
            this.CommitButton.Text = "Commit";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.objectCountText);
            this.tabPage2.Controls.Add(this.objList);
            this.tabPage2.Controls.Add(this.SelectedCommitsList);
            this.tabPage2.Controls.Add(this.diffButton);
            this.tabPage2.Controls.Add(this.updateDiffSelectionButton);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(344, 320);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compare Commits";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // objectCountText
            // 
            this.objectCountText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectCountText.AutoSize = true;
            this.objectCountText.Location = new System.Drawing.Point(284, 103);
            this.objectCountText.Name = "objectCountText";
            this.objectCountText.Size = new System.Drawing.Size(52, 13);
            this.objectCountText.TabIndex = 13;
            this.objectCountText.Text = "0 Objects";
            this.objectCountText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // objList
            // 
            this.objList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.objList.AutoArrange = false;
            this.objList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.objMod,
            this.objType,
            this.objId});
            this.objList.FullRowSelect = true;
            this.objList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.objList.HideSelection = false;
            this.objList.Location = new System.Drawing.Point(8, 122);
            this.objList.Margin = new System.Windows.Forms.Padding(0);
            this.objList.MinimumSize = new System.Drawing.Size(100, 10);
            this.objList.Name = "objList";
            this.objList.ShowGroups = false;
            this.objList.Size = new System.Drawing.Size(328, 159);
            this.objList.TabIndex = 12;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            this.objList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.objList_ItemSelectionChanged);
            this.objList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.objList_MouseClick);
            // 
            // objMod
            // 
            this.objMod.Text = "X";
            this.objMod.Width = 20;
            // 
            // objType
            // 
            this.objType.Text = "Object Type";
            this.objType.Width = 150;
            // 
            // objId
            // 
            this.objId.Text = "Object ID";
            this.objId.Width = 158;
            // 
            // SelectedCommitsList
            // 
            this.SelectedCommitsList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.SelectedCommitsList.AutoArrange = false;
            this.SelectedCommitsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectedCommitsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.selectedId,
            this.selectedTime,
            this.selectedAuthor,
            this.selectedComments});
            this.SelectedCommitsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SelectedCommitsList.HideSelection = false;
            this.SelectedCommitsList.Location = new System.Drawing.Point(8, 36);
            this.SelectedCommitsList.Margin = new System.Windows.Forms.Padding(0);
            this.SelectedCommitsList.MinimumSize = new System.Drawing.Size(100, 10);
            this.SelectedCommitsList.MultiSelect = false;
            this.SelectedCommitsList.Name = "SelectedCommitsList";
            this.SelectedCommitsList.ShowGroups = false;
            this.SelectedCommitsList.Size = new System.Drawing.Size(328, 61);
            this.SelectedCommitsList.TabIndex = 8;
            this.SelectedCommitsList.UseCompatibleStateImageBehavior = false;
            this.SelectedCommitsList.View = System.Windows.Forms.View.Details;
            // 
            // selectedId
            // 
            this.selectedId.Text = "Commit ID";
            this.selectedId.Width = 83;
            // 
            // selectedTime
            // 
            this.selectedTime.Text = "Time Added";
            this.selectedTime.Width = 79;
            // 
            // selectedAuthor
            // 
            this.selectedAuthor.Text = "Author";
            this.selectedAuthor.Width = 75;
            // 
            // selectedComments
            // 
            this.selectedComments.Text = "Comments";
            this.selectedComments.Width = 91;
            // 
            // diffButton
            // 
            this.diffButton.Location = new System.Drawing.Point(9, 286);
            this.diffButton.Margin = new System.Windows.Forms.Padding(5);
            this.diffButton.Name = "diffButton";
            this.diffButton.Size = new System.Drawing.Size(327, 25);
            this.diffButton.TabIndex = 11;
            this.diffButton.Text = "Compare commits";
            this.diffButton.UseVisualStyleBackColor = true;
            this.diffButton.Click += new System.EventHandler(this.diffButton_Click);
            // 
            // updateDiffSelectionButton
            // 
            this.updateDiffSelectionButton.Location = new System.Drawing.Point(230, 6);
            this.updateDiffSelectionButton.Margin = new System.Windows.Forms.Padding(5);
            this.updateDiffSelectionButton.Name = "updateDiffSelectionButton";
            this.updateDiffSelectionButton.Size = new System.Drawing.Size(106, 25);
            this.updateDiffSelectionButton.TabIndex = 10;
            this.updateDiffSelectionButton.Text = "Update Selection";
            this.updateDiffSelectionButton.UseVisualStyleBackColor = true;
            this.updateDiffSelectionButton.Click += new System.EventHandler(this.updateDiffSelectionButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Object differences found";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Selected commits (select one or two)";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(344, 320);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Merge Changes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bro chill this isn\'t implemented";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(344, 320);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Export Data";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Neither is this one...";
            // 
            // StatusText
            // 
            this.StatusText.Location = new System.Drawing.Point(194, 11);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(150, 13);
            this.StatusText.TabIndex = 9;
            this.StatusText.Text = "STATUS";
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FilenameText
            // 
            this.FilenameText.AutoSize = true;
            this.FilenameText.Location = new System.Drawing.Point(7, 11);
            this.FilenameText.Name = "FilenameText";
            this.FilenameText.Size = new System.Drawing.Size(60, 13);
            this.FilenameText.TabIndex = 8;
            this.FilenameText.Text = "FILENAME";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(3, 32);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(156, 25);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Create Record";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(165, 32);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(5);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(179, 25);
            this.UpdateButton.TabIndex = 0;
            this.UpdateButton.Text = "Read Record";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // RVCMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.FilenameText);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.mainTabs);
            this.Controls.Add(this.ListPanel);
            this.Name = "RVCMainControl";
            this.Size = new System.Drawing.Size(352, 647);
            this.Load += new System.EventHandler(this.RVCMainControl_Load);
            this.ListPanel.ResumeLayout(false);
            this.mainTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.CheckoutGroup.ResumeLayout(false);
            this.CommitGroup.ResumeLayout(false);
            this.CommitGroup.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion
            private System.Windows.Forms.Panel ListPanel;
            private System.Windows.Forms.TabControl mainTabs;
            private System.Windows.Forms.TabPage tabPage1;
            private System.Windows.Forms.TabPage tabPage2;
            private System.Windows.Forms.Panel TopPanel;
            private System.Windows.Forms.Label StatusText;
            private System.Windows.Forms.Label FilenameText;
            private System.Windows.Forms.Button AddButton;
            private System.Windows.Forms.GroupBox CheckoutGroup;
            private System.Windows.Forms.Button DiscardButton;
            private System.Windows.Forms.Button RestoreButton;
            private System.Windows.Forms.Button CheckoutButton;
            private System.Windows.Forms.Button UpdateButton;
            private System.Windows.Forms.GroupBox CommitGroup;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.TextBox AuthorBox;
            private System.Windows.Forms.TextBox CommentsBox;
            private System.Windows.Forms.Button CommitButton;
            private System.Windows.Forms.ListView CommitListView;
            private System.Windows.Forms.ColumnHeader id;
            private System.Windows.Forms.ColumnHeader time;
            private System.Windows.Forms.ColumnHeader author;
            private System.Windows.Forms.ColumnHeader comments;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.ListView SelectedCommitsList;
            private System.Windows.Forms.ColumnHeader selectedId;
            private System.Windows.Forms.ColumnHeader selectedTime;
            private System.Windows.Forms.ColumnHeader selectedAuthor;
            private System.Windows.Forms.ColumnHeader selectedComments;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.Button updateDiffSelectionButton;
            private System.Windows.Forms.Button diffButton;
            private System.Windows.Forms.ListView objList;
            private System.Windows.Forms.ColumnHeader objMod;
            private System.Windows.Forms.ColumnHeader objType;
            private System.Windows.Forms.ColumnHeader objId;
            private System.Windows.Forms.TabPage tabPage3;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.TabPage tabPage4;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.Label objectCountText;
        }
    }
}
