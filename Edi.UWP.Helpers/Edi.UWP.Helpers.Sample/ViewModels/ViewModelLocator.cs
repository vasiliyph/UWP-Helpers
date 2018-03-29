using CommonServiceLocator;
using Edi.UWP.Helpers.Sample.Services;
using Edi.UWP.Helpers.Sample.Views;

using GalaSoft.MvvmLight.Ioc;

namespace Edi.UWP.Helpers.Sample.ViewModels
{
    public class ViewModelLocator
    {
        NavigationServiceEx _navigationService = new NavigationServiceEx();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => _navigationService);
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<UIViewModel, UIPage>();
            Register<TasksViewModel, TasksPage>();
            Register<UtilsViewModel, UtilsPage>();
            Register<ConvertersViewModel, ConvertersPage>();
            Register<BitmapExtensionsViewModel, BitmapExtensionsPage>();
            Register<ExceptionHandlingViewModel, ExceptionHandlingPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public ExceptionHandlingViewModel ExceptionHandlingViewModel => ServiceLocator.Current.GetInstance<ExceptionHandlingViewModel>();

        public BitmapExtensionsViewModel BitmapExtensionsViewModel => ServiceLocator.Current.GetInstance<BitmapExtensionsViewModel>();

        public ConvertersViewModel ConvertersViewModel => ServiceLocator.Current.GetInstance<ConvertersViewModel>();

        public UtilsViewModel UtilsViewModel => ServiceLocator.Current.GetInstance<UtilsViewModel>();

        public TasksViewModel TasksViewModel => ServiceLocator.Current.GetInstance<TasksViewModel>();

        public UIViewModel UIViewModel => ServiceLocator.Current.GetInstance<UIViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public void Register<VM, V>() where VM : class
        {
            SimpleIoc.Default.Register<VM>();
            
            _navigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
