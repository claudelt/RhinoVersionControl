using Rhino;
using Rhino.DocObjects;
using Rhino.FileIO;
using Rhino.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RVC
{
    namespace Data
    {
        public abstract class Record
        {
            public Guid Id { get; set; }

            public Record()
            {
                this.Id = Guid.NewGuid();
            }
        }

        public class FileRecord : Record
        {
            public SortedList commits { get; set; }
            public string Filename { get; set; }

            public FileRecord() : base()
            {
                this.Filename = null;
                this.Id = Guid.NewGuid();

                this.commits = new SortedList();
            }

            private static string getFileRecordName(string fullName)
            {
                string[] splitedParts = Path.GetFileName(fullName).Split('.');
                return splitedParts[0] + "." + splitedParts[splitedParts.Length - 1];
            }

            public static string getRecordFilePath(RhinoDoc doc)
            {
                // The part that enables multi-file sharing the same record
                // i.e.
                // SiteModel.Final.Claude
                // SiteModel.Final.Joe
                // SiteModel.MidTermSubmission
                // etc.
                // All share the same record "SiteModel.record.rvc" and uses "SiteModel" as storage

                return Path.Combine(Path.GetDirectoryName(doc.Path), ".rvc", getFileRecordName(doc.Path) + ".record.rvc");
            }

            public static string getRecordStoragePath(RhinoDoc doc)
            {
                return Path.Combine(Path.GetDirectoryName(doc.Path), ".rvc", "store", getFileRecordName(doc.Path));
            }

            public static bool existsRecord(RhinoDoc doc)
            {
                return File.Exists(getRecordFilePath(doc)) && Directory.Exists(getRecordStoragePath(doc));
            }

            public bool initRecord(RhinoDoc doc)
            {
                if (File.Exists(getRecordFilePath(doc)))
                    return false;

                this.Filename = Path.GetFileName(doc.Path);

                FileStream newFile = File.Create(getRecordFilePath(doc));
                newFile.Close();

                Directory.CreateDirectory(getRecordStoragePath(doc));

                return true;
            }

            public static FileRecord writeRecord(RhinoDoc doc, FileRecord record)
            {
                string recordName = getRecordFilePath(doc);
                string jsonString = JsonSerializer.Serialize(record);

                File.WriteAllText(recordName, jsonString);

                return FileRecord.loadRecord(doc);
            }

            public static FileRecord loadRecord(RhinoDoc doc)
            {
                if (RVCFiles.isFileMonitored(doc))
                {
                    string recordName = getRecordFilePath(doc);
                    FileRecord currRecord = JsonSerializer.Deserialize<FileRecord>(File.ReadAllText(recordName));

                    SortedList newCommits = new SortedList();

                    foreach (DictionaryEntry kv in currRecord.commits)
                    {
                        FileCommit commit = JsonSerializer.Deserialize<FileCommit>(kv.Value.ToString());
                        newCommits[kv.Key] = commit;
                    }

                    currRecord.commits = newCommits;

                    return currRecord;
                }
                else
                {
                    RVCUtilities.writeErr(doc.Name + " is not monitored by RVC.");

                    return null;
                }
            }

            public bool validateRecord(RhinoDoc doc)
            {
                // Check to see if all commits in commit list exists as files
                return true;
            }

            public Guid addCommit(RhinoDoc doc, string author, string comment)
            {
                FileCommit commit = new FileCommit(doc, author, comment);

                // Write RhinoDoc to archive
                string archiveTarget = Path.Combine(getRecordStoragePath(doc), commit.Id.ToString() + ".3dm");

                FileWriteOptions tempOptions = new FileWriteOptions();
                tempOptions.SuppressAllInput = true;
                tempOptions.WriteUserData = true;
                tempOptions.IncludeHistory = false;
                tempOptions.UpdateDocumentPath = false;

                doc.Write3dmFile(archiveTarget, tempOptions);

                // Write commit to the record object
                this.commits.Add(commit.Id.ToString(), commit);

                return commit.Id;
            }
        }

        public class DiffResults
        {
            public Hashtable Added { get; set; }
            public Hashtable Modified { get; set; }
            public Hashtable Removed { get; set; }

            public MeshPhantoms meshAdded { get; set; }
            public MeshPhantoms meshModified { get; set; }
            public MeshPhantoms meshRemoved { get; set; }

            public DiffResults(Hashtable a, Hashtable m, Hashtable r)
            {
                this.Added = a;
                this.Modified = m;
                this.Removed = r;
            }
        }

        public class MeshPhantoms
        {
            public Hashtable Meshes { get; private set; }

            public MeshPhantoms()
            {
                this.Meshes = new Hashtable();
            }

            public Guid AddMesh(Guid id, Mesh m)
            {
                if (m != null)
                    if (m.IsValid)
                    {
                        this.Meshes.Add(id, m.DuplicateMesh());
                        return id;
                    }

                return Guid.Empty;
            }

            public Guid AddMesh(RhinoObject o)
            {
                if (o != null)
                    if (!o.Disposed)
                        if (o.Geometry.IsValid)
                        {
                            // Force new mesh generation
                            MeshingParameters mp = o.GetRenderMeshParameters();

                            Mesh m = RhinoObject.GetRenderMeshes(new List<RhinoObject> { o }, true, true)[0].Mesh();

                            if (m == null || !m.IsValid)
                                return Guid.Empty;

                            AddMesh(o.Id, m);
                            return o.Id;
                        }

                return Guid.Empty;
            }
        }

        internal class FileCommit : Record
        {
            public string Author { get; set; }
            public string Comment { get; set; }
            public DateTime Time { get; set; }

            public FileCommit()
            {

            }

            internal FileCommit(RhinoDoc doc, string author, string comment) : base()
            {
                this.Author = author;
                this.Comment = comment;
                this.Time = DateTime.UtcNow;
            }
        }
    }
}