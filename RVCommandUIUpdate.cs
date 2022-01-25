using Rhino;
using Rhino.Commands;

namespace RVC
{
    public class RVCommandUIUpdate : Command
    {
        public RVCommandUIUpdate()
        {
            Instance = this;
        }

        public static RVCommandUIUpdate Instance { get; private set; }

        public override string EnglishName => "RVUIUpdate";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            RVCPlugin.Instance.MainPanel.UpdateData(doc);

            return Result.Success;
        }
    }
}