using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.SharpDX.Core;
using HelixToolkit.SharpDX.Core.Model;
using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;
using SharpDX;
using Camera = HelixToolkit.Wpf.SharpDX.Camera;
using Color = System.Windows.Media.Color;
using PerspectiveCamera = HelixToolkit.Wpf.SharpDX.PerspectiveCamera;
using MeshGeometry3D = HelixToolkit.SharpDX.Core.MeshGeometry3D;
using WpfApp3.Models;

namespace WpfApp3
{


    public class MainViewModel : ObservableObject
    {
        public Camera Camera { get; } = new PerspectiveCamera
        {
            Position = new Point3D(3, 3, 5),
            LookDirection = new Vector3D(-3, -3, -5),
            UpDirection = new Vector3D(0, 1, 0),
            FarPlaneDistance = 5000000
        };

        public IEffectsManager EffectsManager { get; } = new DefaultEffectsManager();

        public LineGeometry3D Grid { get; } = LineBuilder.GenerateGrid(new Vector3(0, 1, 0), -5, 5, -5, 5);
        //public Color GridColor { get; } = Colors.Black;

        public MeshGeometry3D Model { get; private set; }
        public PhongMaterial ModelMaterial { get; } = PhongMaterials.Blue;

        public LineGeometry3D Edges { get; private set; }
        public Color EdgesColor { get; private set; } = Colors.DimGray;


        public MainViewModel()
        {
            //ModelBase m = new Extruded();
            //ModelBase m = new Revolved();
            //ModelBase m = new BoxModel();
            //ModelBase m = new СylinderModel();
            ModelBase m = new SphereModel();

            m.Update();

            VisualiseModel(m);
        }


        void VisualiseModel(ModelBase model)
        {
            Model = new MeshGeometry3D()
            {
                Positions = model.Positions,
                Indices = model.Indices,
                Normals = model.Normals,
                TextureCoordinates = null,
                Tangents = null,
                BiTangents = null,
            };

            // визуализация граней
            //var inxs = new IntCollection();
            //model.Edges.ForEach(x => inxs.AddAll(x.Indices));
            //Edges = new LineGeometry3D { Positions = model.Positions, Indices = inxs };

            // визуализация граней Face
            var inxs2 = new IntCollection();
            model.Faces.ForEach(x => x.Edges.ForEach(x2 => inxs2.AddAll(x2.Indices)));
            Edges = new LineGeometry3D { Positions = model.Positions, Indices = inxs2 };
            EdgesColor = Colors.Red;
        }
    }
}
