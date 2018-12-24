using Autofac;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SuperScanning.WPFClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SuperScanning.WPFClient.Views
{
    /// <summary>
    /// SuperScanningWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SuperScanningWindow : MetroWindow
    {
        public SuperScanningWindow()
        {
            InitializeComponent();

            this.Closing += (s, e) => {
                try
                {
                    List<Process> list = new List<Process>();
                    Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                    foreach (Process process in processes)
                    {
                        if (!process.HasExited)
                        {
                            list.Add(process);
                        }
                    }
                    if (list.Count > 0)
                    {
                        foreach (Process process in list)
                        {
                            process.Kill();
                        }

                    }
                }
                catch (Exception e4)
                {
                }
            };
        }

        private async void ShowLoginDialog(object sender, RoutedEventArgs e)
        {
            LoginDialogData result = await this.ShowLoginAsync("登录", "请输入您的用户名和密码", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, InitialUsername = "admin" });
            if (result == null)
            {
                //User pressed cancel
            }
            else
            {
                bool loginRes = false;
                if (result.Username.Equals("admin") && result.Password.Equals("admin123"))
                {
                    using (var scope = ViewModelLocator.Container.BeginLifetimeScope())
                    {
                        loginRes = scope.ResolveOptional<ModuleInterface.ICache>().UpdateUser(result.Username, result.Password);
                        loginInfo.Content = result.Username;
                    }
                }
                MessageDialogResult messageResult = await this.ShowMessageAsync(loginRes?"登录成功": "登录失败", loginRes?string.Format("你好，尊敬的{0}\n欢迎使用本软件！", result.Username):"用户名或者密码错误！");
            }
        }
        private async void ShowMessageDialog(object sender, RoutedEventArgs e)
        {
            // This demo runs on .Net 4.0, but we're using the Microsoft.Bcl.Async package so we have async/await support
            // The package is only used by the demo and not a dependency of the library!
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "OK",
                //NegativeButtonText = "Go away!",
                //FirstAuxiliaryButtonText = "Cancel",
                ColorScheme = MetroDialogOptions.ColorScheme
            };
            var ruleStr = string.Empty;
            using (var scope = ViewModelLocator.Container.BeginLifetimeScope())
            {
                ruleStr = scope.ResolveOptional<ModuleInterface.BusinessComponent.ISettingService>().GetRule;
            }
                MessageDialogResult result = await this.ShowMessageAsync("单号规则", ruleStr,
                    MessageDialogStyle.Affirmative, mySettings);

            //if (result != MessageDialogResult.FirstAuxiliary)
            //    await this.ShowMessageAsync("Result", "You said: " + (result == MessageDialogResult.Affirmative ? mySettings.AffirmativeButtonText : mySettings.NegativeButtonText +
            //        Environment.NewLine + Environment.NewLine + "This dialog will follow the Use Accent setting."));
        }
    }
}
