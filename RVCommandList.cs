using Rhino;
using Rhino.Commands;
using RVC.Data;
using System.Collections;
using System.Text.Json;

namespace RVC
{
    public class RVCommandList : Command
    {
        public RVCommandList()
        {
            Instance = this;
        }

        public static RVCommandList Instance { get; private set; }

        public override string EnglishName => "RVList";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            if (RVCFiles.isFileMonitored(doc))
            {
                RVCUtilities.writeLine("Listing all commits of " + doc.Name);

                FileRecord record = FileRecord.loadRecord(doc);

                SortedList sortedRecord = new SortedList();
                foreach (DictionaryEntry kv in record.commits)
                {
                    FileCommit commit = JsonSerializer.Deserialize<FileCommit>(kv.Value.ToString());
                    sortedRecord.Add(commit.Time.ToBinary(), commit);
                }

                foreach (DictionaryEntry kv in sortedRecord)
                {
                    FileCommit commit = (FileCommit)kv.Value;
                    RVCUtilities.writeLine("Commit " + commit.Id + " : " + commit.Time + ", by " + commit.Author + ". Comments: " + commit.Comment);
                }

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