using Rhino;
using Rhino.Commands;
using Rhino.FileIO;
using System;
using System.IO;

namespace RVC
{
    public class RVCommandRestore : Command
    {
        public RVCommandRestore()
        {
            Instance = this;
        }

        public static RVCommandRestore Instance { get; private set; }

        public override string EnglishName => "RVRestore";

        public Result Restore(RhinoDoc doc)
        {
            if (RVCFiles.isFileMonitored(doc))
            {
                RVCUtilities.writeLine("Restoring previously held changes for " + doc.Name);

                if (!File.Exists(RVCFiles.rvcTempFile(doc)))
                {
                    RVCUtilities.writeErr("No changes held for " + doc.Name);
                    return Result.Failure;
                }

                doc.Modified = false;

                string prevPath = String.Copy(doc.Path);
                bool tryOpen;
                RhinoDoc currDoc = RhinoDoc.Open(RVCFiles.rvcTempFile(doc), out tryOpen);

                FileWriteOptions writeOptions = new FileWriteOptions();
                writeOptions.SuppressAllInput = true;
                writeOptions.UpdateDocumentPath = true;

                currDoc.WriteFile(prevPath, writeOptions);

                if (RVCFiles.rvcTempFile(doc) != null)
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
            return this.Restore(doc);
        }
    }
}