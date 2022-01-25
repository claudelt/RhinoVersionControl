using Rhino;
using Rhino.Commands;
using Rhino.UI;
using RVC.Forms;

namespace RVC
{
    public class RVCommandUIOpen : Command
    {
        public RVCommandUIOpen()
        {
            Instance = this;
        }

        public static RVCommandUIOpen Instance { get; private set; }

        public override string EnglishName => "RVUIPanel";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            Panels.OpenPanel(typeof(RVCMainControl).GUID);

            return Result.Success;
        }
    }
}