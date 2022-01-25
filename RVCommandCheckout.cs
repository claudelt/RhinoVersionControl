using Rhino;
using Rhino.Commands;
using Rhino.FileIO;
using Rhino.Input;
using RVC.Data;
using System;
using System.IO;

namespace RVC
{
    public class RVCommandCheckout : Command
    {
        public RVCommandCheckout()
        {
            Instance = this;
        }

        public static RVCommandCheckout Instance { get; private set; }

        public override string EnglishName => "RVCheckout";

        public Result Checkout(RhinoDoc doc, string Id)
        {
            if (RVCFiles.isFileMonitored(doc))
            {
                FileRecord currRecord = FileRecord.loadRecord(doc);

                RhinoDoc prevDoc = doc;

                RVCUtilities.writeLine("Checkout a previous commit of " + doc.Name + " from record repository.");
                RVCUtilities.writeLine("Current changes will be temporarily held. Use RVRestore to restore them.");

                if (File.Exists(RVCFiles.rvcTempFile(doc)))
                {
                    RVCUtilities.writeErr("There is previously held changes for " + doc.Name);
                    RVCUtilities.writeErr("Use RVDiscard to discard them, or RVRestore to restore them.");

                    return Result.Failure;
                }

                if (Id == "")
                {
                    RhinoGet.GetString("Enter the ID of a commit to check out.", false, ref Id); ;
                }

                if (!currRecord.commits.ContainsKey(Id))
                {
                    RVCUtilities.writeErr("ID does not belong to any commit in history.");
                    return Result.Failure;
                }

                FileWriteOptions tempOptions = new FileWriteOptions();
                tempOptions.SuppressAllInput = true;
                tempOptions.WriteUserData = true;
                tempOptions.IncludeHistory = false;
                tempOptions.UpdateDocumentPath = false;

                // Preserve the current file first
                if (!prevDoc.Write3dmFile(RVCFiles.rvcTempFile(prevDoc), tempOptions))
                {
                    RVCUtilities.writeErr("Could not write temporary file for " + doc.Name);
                    return Result.Failure;
                }

                string newDocFileName = Path.Combine(FileRecord.getRecordStoragePath(doc), Id + ".3dm");

                // Load the correct previous commit. Note this actually saves the current file...
                // The save is necessary to provide the correct file path
                doc.Modified = false;
                string prevPath = String.Copy(doc.Path);
                bool tryOpen;

                RhinoDoc resultDoc = RhinoDoc.Open(newDocFileName, out tryOpen);

                FileWriteOptions writeOptions = new FileWriteOptions();
                writeOptions.SuppressAllInput = true;
                writeOptions.UpdateDocumentPath = true;

                resultDoc.WriteFile(prevPath, writeOptions);

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
            return this.Checkout(doc, "");
        }
    }
}