using Rhino;
using Rhino.DocObjects;
using Rhino.DocObjects.Tables;
using Rhino.FileIO;
using Rhino.Geometry;
using System;
using System.Collections;
using System.IO;

namespace RVC
{
    internal static class RVCUtilities
    {
        internal static void writeLine(string message)
        {
            RhinoApp.WriteLine("RVC : " + message);
        }

        internal static void writeErr(string message)
        {
            RhinoApp.WriteLine("RVC : ERR! " + message);
        }

        internal static bool IsRVCInit(string curr)
        {
            if (curr == null)
                return false;

            bool result = false;

            string currDir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(Path.GetDirectoryName(curr));

            if (Directory.Exists(".rvc"))
                result = true;

            Directory.SetCurrentDirectory(currDir);
            return result;
        }

        internal static bool IsIgnored(GeometryBase g)
        {
            // TODO: Figure out specifically what should not be included!!!

            if (g is DetailView)
                return true;

            return false;
        }

        internal static RhinoDoc DeepCloneObjects(RhinoDoc doc)
        {
            RhinoDoc result;

            string tempName = Guid.NewGuid().ToString() + ".3dm";
            string tempFile = Path.Combine(RVCFiles.rvcTempDir(doc.Path), tempName);

            FileWriteOptions tempOptions = new FileWriteOptions();
            tempOptions.SuppressAllInput = true;
            tempOptions.WriteUserData = true;
            tempOptions.IncludeHistory = false;
            tempOptions.UpdateDocumentPath = false;

            if (doc.WriteFile(tempFile, tempOptions))
            {
                result = RhinoDoc.OpenHeadless(tempFile);

                File.Delete(tempFile);
            }
            else
            {
                throw new FileNotFoundException("Could not write temp file for DeepClone");
            }

            return result;
        }

        internal static Hashtable FindDifference(ObjectTable a, ObjectTable b)
        {
            Hashtable result = new Hashtable();

            foreach (RhinoObject obj in a)
                if (b.FindId(obj.Id) == null)
                    result.Add(obj.Id, obj);

            return result;
        }

        internal static bool isObjectDifferent(RhinoObject a, RhinoObject b)
        {
            // For now we're only focusing on the actual geometry
            // Not sure if ObjectAttributes are actually important for our purposes

            if (GeometryBase.GeometryReferenceEquals(a.Geometry, b.Geometry))
            {
                return false;
            }
            else if (GeometryBase.GeometryEquals(a.Geometry, b.Geometry))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static Hashtable FindChanged(ObjectTable a, ObjectTable b)
        {
            Hashtable result = new Hashtable();

            foreach (RhinoObject obj in a)
            {
                if (!(b.FindId(obj.Id) == null))
                {
                    if (isObjectDifferent(obj, b.FindId(obj.Id)))
                    {
                        result.Add(obj.Id, obj);
                    }
                }
            }
            return result;
        }
    }
}