using Rhino;
using Rhino.Commands;
using System.IO;

namespace RVC
{
    public class RVCommandInit : Command
    {
        public RVCommandInit()
        {
            Instance = this;
        }

        public static RVCommandInit Instance { get; private set; }

        public override string EnglishName => "RVInit";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            RVCUtilities.writeLine("Initializing RVC repository at current directory...");

            if (RVCUtilities.IsRVCInit(doc.Path))
            {
                RVCUtilities.writeLine("Rhino Version Control is already initialized here.");
                return Result.Nothing;
            }
            else
            {
                string currDir = Directory.GetCurrentDirectory();

                Directory.SetCurrentDirectory(Path.GetDirectoryName(doc.Path));
                Directory.CreateDirectory(".rvc");
                Directory.CreateDirectory(Path.Combine(".rvc", "temp"));
                Directory.CreateDirectory(Path.Combine(".rvc", "store"));
                RVCUtilities.writeLine("Rhino Version Control is initialized.");

                Directory.SetCurrentDirectory(currDir);
            }

            return Result.Success;
        }
    }
}