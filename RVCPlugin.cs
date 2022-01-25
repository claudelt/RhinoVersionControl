using Rhino;
using Rhino.PlugIns;
using Rhino.UI;
using RVC.Display;
using RVC.Forms;
using RVC.Properties;

namespace RVC
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>
    public class RVCPlugin : Rhino.PlugIns.PlugIn
    {
        // Load at start up
        public override PlugInLoadTime LoadTime => PlugInLoadTime.AtStartup;

        public static RVCPlugin Instance { get; private set; }

        public RVCMainControl MainPanel { get; set; }
        public tempDrawingHost DrawingHost { get; set; }

        public RVCPlugin()
        {
            Instance = this;
        }

        protected override LoadReturnCode OnLoad(ref string errMsg)
        {
            var type = typeof(RVCMainControl);

            // Reigster the UI panel element
            Panels.RegisterPanel(this, type, "Rhino Version Control", Resources.RVCMainPanelIcon, PanelType.PerDoc);

            RhinoDoc.EndOpenDocumentInitialViewUpdate += RhinoDoc_EndOpenDocumentInitialViewUpdate;
            RhinoDoc.ActiveDocumentChanged += RhinoDoc_ActiveDocumentChanged;

            return LoadReturnCode.Success;
        }

        private void RhinoDoc_ActiveDocumentChanged(object sender, DocumentEventArgs e)
        {
            if (this.DrawingHost != null)
                this.DrawingHost.ClearConduits();

            this.DrawingHost = new tempDrawingHost(RhinoDoc.ActiveDoc);
        }

        private void RhinoDoc_EndOpenDocumentInitialViewUpdate(object sender, DocumentOpenEventArgs e)
        {
            RhinoDoc currDoc = RhinoDoc.ActiveDoc;

            if (this.DrawingHost != null)
                this.DrawingHost.ClearConduits();

            this.DrawingHost = new tempDrawingHost(RhinoDoc.ActiveDoc);

            if (RVCFiles.isFileMonitored(currDoc))
            {
                Instance.MainPanel.UpdateData(currDoc);
            }
        }

    }
}