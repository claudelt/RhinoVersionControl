using Rhino;
using System.IO;

namespace RVC
{
    internal static class RVCFiles
    {
        internal static string docDir(string doc)
        {
            return Path.GetDirectoryName(doc);
        }

        internal static string rvcDir(string doc)
        {
            if (doc == null)
                return null;

            return Path.Combine(docDir(doc), ".rvc");
        }

        internal static string rvcTempDir(string doc)
        {
            if (doc == null)
                return null;

            return Path.Combine(rvcDir(doc), "temp");
        }

        internal static string rvcTempFile(RhinoDoc doc)
        {
            if (doc.Path == null)
                return null;

            return Path.Combine(rvcTempDir(doc.Path), Path.GetFileNameWithoutExtension(doc.Path) + ".temp.3dm");
        }

        internal static bool isFileMonitored(RhinoDoc doc)
        {
            if (doc.Path == null || doc.Path.Length == 0)
                return false;

            if (!RVCUtilities.IsRVCInit(doc.Path))
                return false;

            return RVC.Data.FileRecord.existsRecord(doc);
        }
    }
}