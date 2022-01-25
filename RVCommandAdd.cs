using Rhino;
using Rhino.Commands;
using RVC.Data;

namespace RVC
{
    public class RVCommandAdd : Command
    {
        public RVCommandAdd()
        {
            Instance = this;
        }

        public static RVCommandAdd Instance { get; private set; }

        public override string EnglishName => "RVAdd";

        public Result Add(RhinoDoc doc)
        {
            if (RVCFiles.isFileMonitored(doc))
            {
                RVCUtilities.writeErr(doc.Name + " is already monitored. Nothing is done.");

                return Result.Nothing;
            }
            else
            {
                FileRecord record = new FileRecord();

                record.initRecord(doc);
                FileRecord.writeRecord(doc, record);

                RVCUtilities.writeLine(doc.Name + " is now monitored. Use RVCommit to add a new commit to the record.");
            }

            return Result.Success;
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            return this.Add(doc);
        }
    }
}