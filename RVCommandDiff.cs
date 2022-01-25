using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Input;
using RVC.Data;
using System;
using System.Collections;
using System.IO;

namespace RVC
{
    public class RVCommandDiff : Command
    {
        public RVCommandDiff()
        {
            Instance = this;
        }

        public static RVCommandDiff Instance { get; private set; }

        public override string EnglishName => "RVDiff";

        public DiffResults Diff(RhinoDoc docA, RhinoDoc docB)
        {
            Hashtable added = RVCUtilities.FindDifference(docA.Objects, docB.Objects);
            Hashtable removed = RVCUtilities.FindDifference(docB.Objects, docA.Objects);
            Hashtable modified = RVCUtilities.FindChanged(docA.Objects, docB.Objects);

            MeshPhantoms a = new MeshPhantoms();
            MeshPhantoms m = new MeshPhantoms();
            MeshPhantoms r = new MeshPhantoms();

            foreach (DictionaryEntry kv in added)
                a.AddMesh((RhinoObject)docA.Objects.FindId((Guid)kv.Key));

            foreach (DictionaryEntry kv in modified)
                m.AddMesh((RhinoObject)docA.Objects.FindId((Guid)kv.Key));

            foreach (DictionaryEntry kv in removed)
                r.AddMesh((RhinoObject)docB.Objects.FindId((Guid)kv.Key));

            DiffResults result = new DiffResults(added, modified, removed);

            result.meshAdded = a;
            result.meshRemoved = r;
            result.meshModified = m;

            return result;
        }

        public DiffResults Diff(RhinoDoc doc, string b)
        {
            FileRecord r = FileRecord.loadRecord(doc);

            if (r.commits.ContainsKey(b))
            {
                string docBFilename = Path.Combine(FileRecord.getRecordStoragePath(doc), b + ".3dm");
                RhinoDoc docB = RhinoDoc.OpenHeadless(docBFilename);

                return Diff(doc, docB);
            }

            return null;
        }

        public DiffResults Diff(RhinoDoc doc, string a, string b)
        {
            FileRecord r = FileRecord.loadRecord(doc);

            if (r.commits.ContainsKey(a) && r.commits.ContainsKey(b))
            {
                string docAFilename = Path.Combine(FileRecord.getRecordStoragePath(doc), a + ".3dm");
                string docBFilename = Path.Combine(FileRecord.getRecordStoragePath(doc), b + ".3dm");

                RhinoDoc docA, docB;
                docA = RhinoDoc.OpenHeadless(docAFilename);
                docB = RhinoDoc.OpenHeadless(docBFilename);

                return Diff(docA, docB);
            }

            return null;
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            if (RVCFiles.isFileMonitored(doc))
            {
                FileRecord currRecord = FileRecord.loadRecord(doc);

                RhinoDoc docA, docB;

                string currGuid = "";
                RhinoGet.GetString("Hit <Enter> to use current document state, or the ID of a previous commit to use that commit.", true, ref currGuid);

                // Check the GUID
                if (currGuid != "" && !currRecord.commits.ContainsKey(currGuid))
                {
                    RVCUtilities.writeErr("ID does not belong to any commit in history.");
                    return Result.Failure;
                }

                string tgtGuid = "";
                RhinoGet.GetString("Enter the ID of a commit to diff against.", true, ref tgtGuid);

                // Check the GUID
                if (!currRecord.commits.ContainsKey(tgtGuid))
                {
                    RVCUtilities.writeErr("ID does not belong to any commit in history.");
                    return Result.Failure;
                }

                string docBFilename = Path.Combine(FileRecord.getRecordStoragePath(doc), tgtGuid + ".3dm");

                if (currGuid == "")
                {
                    docA = doc;
                    docB = RhinoDoc.OpenHeadless(docBFilename);
                }
                else
                {
                    string docAFilename = Path.Combine(RVC.Data.FileRecord.getRecordStoragePath(doc), currGuid + ".3dm");
                    docA = RhinoDoc.OpenHeadless(docAFilename);
                    docB = RhinoDoc.OpenHeadless(docBFilename);
                }

                Hashtable added = RVCUtilities.FindDifference(docA.Objects, docB.Objects);
                Hashtable removed = RVCUtilities.FindDifference(docB.Objects, docA.Objects);
                Hashtable modified = RVCUtilities.FindChanged(docA.Objects, docB.Objects);

                RVCUtilities.writeLine("Added " + added.Count + " objects. Removed " + removed.Count + " objects. Modified " + modified.Count + " objects.");

                // TODO: DISPLAY THEM! WOW THIS WOULD BE SO COOL

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