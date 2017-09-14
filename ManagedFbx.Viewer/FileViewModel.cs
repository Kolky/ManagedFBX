using System.Collections.Generic;
using System.IO;
using Microsoft.Practices.Unity;

namespace ManagedFbx.Viewer
{
    public class FileViewModel
    {
        private FileView view;

        public FileViewModel(string fileName)
        {
            this.FileName = fileName;
            this.Scene = Scene.Import(fileName);
        }

        public string Header
        {
            get { return !string.IsNullOrWhiteSpace(this.Scene.Name) ? this.Scene.Name : Path.GetFileNameWithoutExtension(this.FileName); }
        }

        public string FileName { get; private set; }

        public Scene Scene { get; private set; }

        public IEnumerable<SceneNode> Nodes
        {
            get { yield return this.Scene.RootNode; }
        }

        [Dependency]
        public FileView View
        {
            get { return this.view; }

            set
            {
                this.view = value;
                if (this.view != null)
                {
                    this.view.DataContext = this;
                }
            }
        }
    }
}
