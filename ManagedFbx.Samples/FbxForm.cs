using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManagedFbx;

public partial class FbxForm : Form
{
    public FbxForm()
    {
        InitializeComponent();
        SetTitle("Untitled");
    }

    public void Add(SceneNode node, TreeNode parentNode)
    {
        var item = new TreeNode(node.Name)
        {
            Tag = node
        };

        if (parentNode == null)
        {
            uxFbxTree.Nodes.Add(item);
        }
        else
        {
            parentNode.Nodes.Add(item);
        }

        foreach (var sub in node.ChildNodes)
        {
            var subitem = new TreeNode(sub.Name)
            {
                Tag = sub
            };
            this.Add(sub, item);
        }

        if (parentNode == null)
        {
            uxFbxTree.ExpandAll();
        }
    }

    private void OnTreeSelect(object sender, TreeViewEventArgs e)
    {
        var node = e.Node.Tag as SceneNode;

        if (node == null)
        {
            return;
        }

        var builder = new StringBuilder();

        builder.AppendLine($"Position:\t{node.Position}");
        builder.AppendLine($"Rotation:\t{node.Rotation}");
        builder.AppendLine($"Scale:\t{node.Scale}");

        AppendProperties(node, x => x.IsSource, "source", builder);
        AppendProperties(node, x => x.IsDestination, "destination", builder);
        AppendProperties(node, x => !x.IsSource && !x.IsDestination, "regular", builder);

        if (node.Attributes.Any())
        {
            builder.AppendLine($"Found {node.Attributes.Count()} attribute(s)");
            foreach (var attr in node.Attributes)
            {
                switch (attr.Type)
                {
                    case NodeAttributeType.Mesh:
                        AppendMesh(node.Mesh, builder, false, false);
                        break;

                    case NodeAttributeType.Light:
                        AppendLight(node.Light, builder);
                        break;

                    default:
                        builder.AppendLine($"Attribute {attr.Type} value: {attr.Name}");
                        break;
                }
            }
        }

        uxNodeInfo.Text = builder.ToString();
    }

    private void AppendProperties(SceneNode node, Func<NodeProperty, bool> predicate, string typeOf, StringBuilder builder)
    {
        if (node.Properties.Any(predicate))
        {
            builder.AppendLine($"Found {node.Properties.Count(predicate)} {typeOf} propertie(s)");
            foreach (var prop in node.Properties.Where(predicate))
            {
                builder.AppendLine($"\tProperty name: {prop.Name}, type: {prop.DataType} (s: {prop.IsSource}, d: {prop.IsDestination}), value: {prop.Value}");
            }
        }
    }

    private void AppendMesh(Mesh mesh, StringBuilder builder, bool full, bool triangulate)
    {
        builder.AppendLine($"Mesh:");

        if (!mesh.Triangulated && triangulate)
        {
            builder.AppendLine($"\tQuads/ngons found in list of total {mesh.Polygons} polygons, triangulating");
            mesh = mesh.Triangulate();
        }

        builder.AppendLine($"\tFound {mesh.Polygons} triangles");
        if (full)
        {
            builder.AppendLine();
            for (var i = 0; i < mesh.Polygons.Length; i++)
            {
                var str = string.Empty;
                foreach (var index in mesh.Polygons[i].Indices)
                {
                    str += "\t" + index;
                }

                builder.AppendLine($"\t{i}:{str}\t(UVs: {mesh.GetUVIndex(i, 0)} ,{mesh.GetUVIndex(i, 1)}, {mesh.GetUVIndex(i, 2)}, Mat ID: {mesh.GetMaterialId(i)})");
            }
        }

        builder.AppendLine($"\tFound {mesh.Vertices} vertices");
        if (full)
        {
            builder.AppendLine();
            for (var i = 0; i < mesh.Vertices.Length; i++)
            {
                var vertex = mesh.Vertices[i];
                builder.AppendLine($"\t{i}:\t{Math.Round(vertex.X, 2)}\t{Math.Round(vertex.Y, 2)}\t{Math.Round(vertex.Z, 2)}");
            }
        }

        builder.AppendLine($"\tFound {mesh.Normals} vertex normals");
        if (full)
        {
            builder.AppendLine();
            for (var i = 0; i < mesh.Normals.Length; i++)
            {
                var normal = mesh.Normals[i];
                builder.AppendLine($"\t{i}:\t{Math.Round(normal.X, 2)}\t{Math.Round(normal.Y, 2)}\t{Math.Round(normal.Z, 2)}");
            }
        }

        builder.AppendLine($"\tFound {mesh.TextureCoords} UV coords");
        if (full)
        {
            builder.AppendLine();
            for (var i = 0; i < mesh.TextureCoords.Length; i++)
            {
                var coord = mesh.TextureCoords[i];
                builder.AppendLine($"\t{i}:\t{Math.Round(coord.X, 2)}\t{Math.Round(coord.Y, 2)}");
            }
        }

        builder.AppendLine($"\tFound {mesh.VertexColours} vertex colours");
        if (full)
        {
            builder.AppendLine();
            for (var i = 0; i < mesh.VertexColours.Length; i++)
            {
                var colour = mesh.VertexColours[i];
                builder.AppendLine($"\t{i}:\t{Math.Round(colour.R, 2)}\t{Math.Round(colour.G, 2)}\t{Math.Round(colour.B, 2)}\t{Math.Round(colour.A, 2)}");
            }
        }

        builder.AppendLine($"\tFound {mesh.MaterialIDs} material IDs");
        if (full)
        {
            builder.AppendLine();
            for (var i = 0; i < mesh.MaterialIDs.Length; i++)
            {
                var id = mesh.MaterialIDs[i];
                builder.AppendLine($"\t{i}:\t{id}");
            }
        }
    }

    private void AppendLight(Light light, StringBuilder builder)
    {
        builder.AppendLine($"Light:");
        builder.AppendLine($"\tFound light of type {light.Type}");
        builder.AppendLine($"\tColour is {light.Colour}");
    }

    private void LoadFile(object sender, EventArgs e)
    {
        var dialog = new OpenFileDialog();
        dialog.Filter = "FBX files (*.fbx)|*.fbx";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var scenePath = dialog.FileName;
            m_scene = Scene.Import(scenePath);
            uxFbxTree.Nodes.Clear();
            Add(m_scene.RootNode, null);
            SetTitle(scenePath);
        }
    }

    private void SaveFile(object sender, EventArgs e)
    {
        var dialog = new SaveFileDialog();
        dialog.Filter = "FBX file (*.fbx)|*.fbx";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var filePath = dialog.FileName;
            m_scene.Save(filePath);
        }
    }

    private void SetTitle(string filename)
    {
        Text = "FBX Viewer - " + filename;
    }

    private Scene m_scene;
}