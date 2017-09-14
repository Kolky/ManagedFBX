using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Regions;

namespace ManagedFbx.Viewer
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.OpenFile = new DelegateCommand(this.OpenFileExecute);
            this.CloseFile = new DelegateCommand<FileViewModel>(this.CloseFileExecute);
            this.Exit = new DelegateCommand(Application.Current.Shutdown);
        }

        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public ICommand OpenFile { get; private set; }
        public ICommand CloseFile { get; private set; }
        public ICommand Exit { get; private set; }

        public IList<FileViewModel> FilesOpened { get; } = new List<FileViewModel>();

        private void OpenFileExecute()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "FBX files (*.fbx)|*.fbx";
            var results = dialog.ShowDialog();
            if (results.HasValue && results.Value)
            {
                var vm = this.Container.Resolve<FileViewModel>(new ParameterOverride("fileName", dialog.FileName).OnType<FileViewModel>());
                this.FilesOpened.Add(vm);

                var region = this.RegionManager.Regions[RegionNames.FilesOpenedRegion];
                region.Add(vm.View);
                region.Activate(vm.View);
            }
        }

        private void CloseFileExecute(FileViewModel viewModel)
        {
            this.RegionManager.Regions[RegionNames.FilesOpenedRegion].Remove(viewModel.View);
            this.FilesOpened.Remove(viewModel);
        }
    }
}
