using Rhino;
using Rhino.Display;
using Rhino.DocObjects;
using Rhino.Geometry;
using System;
using System.Collections;
using System.Drawing;

namespace RVC
{
    namespace Display
    {
        public class tempDrawingHost
        {
            private Hashtable conduits;

            public tempDrawingHost(RhinoDoc d)
            {
                conduits = new Hashtable();
            }

            // Turn off all current conduits and dispose of them
            // Rhino's ULTRA opaque garbage collection is making this pretty annoying
            public void ClearConduits()
            {
                foreach (DictionaryEntry kv in conduits)
                {
                    DisplayConduit conduit = (DisplayConduit)kv.Value;
                    conduit.Enabled = false;
                    conduit = null;
                }

                // Discard old conduits
                conduits = new Hashtable();
            }

            public Guid AddConduitForMeshes(IEnumerable ms, Color c)
            {
                if (ms == null)
                    return Guid.Empty;

                tempMeshConduit conduit = new tempMeshConduit(ms, c);

                conduit.Enabled = true;
                Guid id = Guid.NewGuid();
                this.conduits.Add(id, conduit);

                return id;
            }
        }

        internal class tempMeshConduit : DisplayConduit
        {
            IEnumerable ms;
            Color c { get; }
            DisplayMaterial mat { get; }

            internal tempMeshConduit(IEnumerable ms, Color c)
            {
                this.ms = ms;

                this.c = c;
                this.mat = new DisplayMaterial();
                this.mat.Diffuse = c;
                this.mat.Transparency = 0.5;

                this.GeometryFilter = ObjectType.Mesh;
            }

            protected override void CalculateBoundingBox(CalculateBoundingBoxEventArgs e)
            {
                base.CalculateBoundingBox(e);

                if (!this.Enabled)
                    return;

                foreach (Mesh m in ms)
                    if (m != null && m.IsValid)
                        e.IncludeBoundingBox(m.GetBoundingBox(true));
            }

            protected override void PostDrawObjects(DrawEventArgs e)
            {
                base.PostDrawObjects(e);

                if (!this.Enabled)
                    return;

                foreach (Mesh m in ms)
                {
                    if (m == null)
                        continue;

                    RhinoViewport vp = e.Display.Viewport;

                    if (vp == null)
                        break;

                    if (vp.DisplayMode.EnglishName.ToLower() == "wireframe")
                        e.Display.DrawMeshWires(m, c);
                    else
                        e.Display.DrawMeshShaded(m, mat);
                }
            }
        }
    }
}