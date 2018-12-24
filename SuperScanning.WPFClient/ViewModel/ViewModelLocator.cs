/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:SuperScanning.WPFClient"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Autofac;
using Autofac.Extras.CommonServiceLocator;
using GalaSoft.MvvmLight;
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;
using SuperScanning.ModuleInterface;
using SuperScanning.ModuleInterface.BusinessComponent;
using SuperScanning.WPFClient.UsCrlViewModel;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace SuperScanning.WPFClient.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// IOCContainer
        /// IOC����
        /// </summary>
        public static IContainer Container { get; set; }
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();
            //local Register һ��ע��
            //��ʽɨ��
            //Scan Register ɨ��ע�� ÿ��ģ���ڲ��ж�Ӧģ���ע�᷽��
            var files = new DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings["modulepath"]).GetFiles("*.dll");
            if (files != null && files.Length > 0)
            {
                foreach (var item in files)
                {
                    builder.RegisterAssemblyModules(Assembly.LoadFile(item.FullName));
                }
            }

            builder.RegisterInstance<IDialogCoordinator>(DialogCoordinator.Instance).SingleInstance();
            builder.RegisterType<MainViewModel>().AsSelf().SingleInstance();
            builder.RegisterType<SettingViewModel>().AsSelf().SingleInstance();
            builder.RegisterType<SuperScanningViewModel>().AsSelf().SingleInstance();
            Container = builder.Build();

            var setting = Container.ResolveOptional<ISettingService>();
            if (setting != null)
            {
                setting.LoadSettting();
                ChangeTheme(setting.CurSettingProtcol.UserSetting.UISetting.AccentName, setting.CurSettingProtcol.UserSetting.UISetting.AppTheme);
            }
        }

        /// <summary>
        /// ����App��ʽ
        /// </summary>
        /// <param name="accentName">���ڱ�������ʽ</param>
        /// <param name="themeName">������ʽ</param>
        public  static void ChangeTheme(string accentName, string themeName)
        {
            try
            {
                Accent expectedAccent = ThemeManager.Accents.First(x => x.Name == accentName); //"Blue"
                AppTheme expectedTheme = ThemeManager.GetAppTheme(themeName);  //"BaseDark"
                ThemeManager.ChangeAppStyle(Application.Current, expectedAccent, expectedTheme);
            }
            catch(Exception ex)
            {
                var _log = Container.ResolveOptional<ILogger>();
                if (_log != null)
                {
                    _log.Error($"{ex.ToString()}");
                }


            }
        }
        /// <summary>
        /// MainView��ViewModel
        /// </summary>
        public SuperScanningViewModel SuperScanning
        {
            get
            {
                var vm= Container.Resolve<SuperScanningViewModel>();
                return vm;
            }
        }
        public SettingViewModel Setting
        {
            get
            {
                var vm = Container.Resolve<SettingViewModel>();
                return vm;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
            Container.Dispose();
            Container = null;
        }
    }
}