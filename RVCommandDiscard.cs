using Rhino;
using Rhino.Commands;
using System.IO;

namespace RVC
{
    public class RVCommandDiscard : Command
    {
        public RVCommandDiscard()
        {
            Instance = this;
        }

        public static RVCommandDiscard Instance { get; private set; }

        public override string EnglishName => "RVDiscard";

        public Result Discard(RhinoDoc doc)
        {
            if (RVCFiles.isFileMonitored(doc))
            {
                RVCUtilities.writeLine("Discarding previously held changes for " + doc.Name);

                if (!File.Exists(RVCFiles.rvcTempFile(doc)))
                {
                    RVCUtilities.writeErr("No changes held for " + doc.Name);
                    return Result.Failure;
                }

                File.Delete(RVCFiles.rvcTempFile(doc));
                return Result.Success;
            }
            else
            {
                RVCUtilities.writeErr(doc.Name + " is not monitored.");
                RVCUtilities.writeErr("Add this file using RVAdd first.");

                return Result.Failure;
            }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            return this.Discard(doc);
        }
    }
}