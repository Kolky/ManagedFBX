using System.Windows;
using Microsoft.Practices.Unity;

namespace ManagedFbx.Viewer
{
    public class Bootstrapper : Prism.Unity.UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.RegisterTypeIfMissing<MainViewModel>(true);
            this.RegisterTypeIfMissing<MainWindow>(true);
            this.RegisterTypeIfMissing<FileViewModel>();
            this.RegisterTypeIfMissing<FileView>();
        }

        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<MainWindow>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current.MainWindow = (MainWindow)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected void RegisterTypeIfMissing<T>()
        {
            this.RegisterTypeIfMissing<T>(false);
        }

        protected void RegisterTypeIfMissing<T>(bool registerAsSingleton)
        {
            this.RegisterTypeIfMissing<T, T>(registerAsSingleton);
        }

        protected void RegisterTypeIfMissing<TSource, TTarget>(bool registerAsSingleton)
        {
            this.RegisterTypeIfMissing(typeof(TSource), typeof(TTarget), registerAsSingleton);
        }
    }
}
