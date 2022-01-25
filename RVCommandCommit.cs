using Rhino;
using Rhino.Commands;
using Rhino.Input;
using RVC.Data;
using System;

namespace RVC
{
    public class RVCommandCommit : Command
    {
        public RVCommandCommit()
        {
            Instance = this;
        }

        public static RVCommandCommit Instance { get; private set; }

        public override string EnglishName => "RVCommit";

        public Result Commit(RhinoDoc doc, string author, string comment)
        {
            FileRecord record = FileRecord.loadRecord(doc);
            Guid commitId = record.addCommit(doc, author, comment);

            FileRecord.writeRecord(doc, record);

            return Result.Success;
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            if (RVCFiles.isFileMonitored(doc))
            {
                RVCUtilities.writeLine("Committing " + doc.Name + " to record repository.");

                // Load appropriate record
                FileRecord record = FileRecord.loadRecord(doc);

                // Gather information
                string author = "";
                string comments = "";

                RhinoGet.GetString("Author : ", false, ref author);
                RhinoGet.GetString("Comments : ", false, ref comments);

                Guid commitId = record.addCommit(doc, author, comments);
                FileCommit commit = (FileCommit)record.commits[commitId.ToString()];

                RVCUtilities.writeLine("Commit ID : " + commit.Id.ToString());
                RVCUtilities.writeLine("Commit Author : " + commit.Author);
                RVCUtilities.writeLine("Commit Comments : " + commit.Comment);
                RVCUtilities.writeLine("Commit Time : " + commit.Time.ToShortDateString() + ", " + commit.Time.ToShortTimeString());

                RVC.Data.FileRecord.writeRecord(doc, record);

                return Result.Success;
            }
            else
            {
                RVCUtilities.writeErr(doc.Name + " is not monitored.");
                RVCUtilities.writeErr("Add this file using RVAdd first.");

                return Result.Failure;
            }
        }
    }
}