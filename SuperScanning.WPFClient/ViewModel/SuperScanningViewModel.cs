using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;
using SuperScanning.Model.Dto;
using SuperScanning.ModuleInterface.BusinessComponent;
using SuperScanning.ModuleInterface.GlobalProtcol;
using SuperScanning.ModuleInterface.PublishEventArgs;
using SuperScanning.WPFClient.UsCrlViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SuperScanning.WPFClient.ViewModel
{
    public class SuperScanningViewModel : ViewModelBase
    {
        #region 变量
        private IScanningService _scanningService;
        private ISettingService _setting;
        private IDialogCoordinator _dialog;

        private ILifetimeScope _root;
        private WriteableBitmap _wBitmap;
        private Int32 MaxW;
        private Int32 MaxH;

        private bool flyOutIsOpen;
        private bool isAuth;
        private string expressCompany;
        private string orderId;
        private double weight;
        private int scanStatus;

        private string _CodeMsg;

        private ObservableCollection<UIScanTotalDataModel> scanDatas=new ObservableCollection<UIScanTotalDataModel>();

        private RelayCommand testCmd;
        private RelayCommand openSettingCmd;
        private RelayCommand userManagerCmd;
        #region 常规

        #endregion
        #region 相机

        #endregion
        #region 称

        #endregion
        #region 主题

        #endregion

        #endregion
        #region 构造
        public SuperScanningViewModel(IScanningService scanningService,ISettingService setting, IDialogCoordinator dialog, ILifetimeScope root)
        {
            try
            {
                _scanningService = scanningService;
                _setting = setting;
                _dialog=dialog;
                _root = root;

                RegisterScanning();

                MaxW = _scanningService.MaxW<2049?3072: _scanningService.MaxW;
                MaxH =_scanningService.MaxH<1091?2048:_scanningService.MaxH;
                //WBitmap = new WriteableBitmap(MaxW+10, MaxH+10, 96, 96, PixelFormats.Indexed8, BitmapPalettes.Gray256);
                WBitmap = new WriteableBitmap(MaxW, MaxH,96, 96, PixelFormats.Indexed8,
                    BitmapPalettes.Gray256);
                //UpdateWritableBitmap(e.ImageData);
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion
        #region 属性
        public WriteableBitmap WBitmap
        {
            get { return _wBitmap; }

            set
            {
                _wBitmap = value;
                RaisePropertyChanged(() => WBitmap);
            }
        }
        public RelayCommand TestCmd
        {
            get
            {
                if (testCmd == null) testCmd = new RelayCommand(() => ExcuteTestCmd());
                return testCmd;
            }
            set
            {
                testCmd = value;
            }
        }
        public RelayCommand OpenSettingCmd
        {
            get
            {
                if (openSettingCmd == null) openSettingCmd = new RelayCommand(() => ExcuteOpenSettingCmd());
                return openSettingCmd;
            }
            set
            {
                openSettingCmd = value;
            }
        }
        public RelayCommand UserManagerCmd
        {
            get
            {
                if (userManagerCmd == null) userManagerCmd = new RelayCommand(() => ExcuteUserManagerCmd());
                return userManagerCmd;
            }
            set
            {
                userManagerCmd = value;
            }
        }



        public bool FlyOutIsOpen { get => flyOutIsOpen; set { flyOutIsOpen = value; RaisePropertyChanged(() => FlyOutIsOpen); } }
        public bool IsAuth { get => isAuth; set { isAuth = value; RaisePropertyChanged(() => IsAuth); } }
        public string ExpressCompany { get => expressCompany; set { expressCompany = value; RaisePropertyChanged(() => ExpressCompany); } }
        public string OrderId { get => orderId; set { orderId = value; RaisePropertyChanged("OrderId"); } }
        public double Weight { get => weight; set { weight = value; RaisePropertyChanged("Weight"); } }
        public int ScanStatus { get => scanStatus; set { scanStatus = value; RaisePropertyChanged("ScanStatus"); } }
        public ObservableCollection<UIScanTotalDataModel> ScanDatas { get => scanDatas; set { scanDatas = value; RaisePropertyChanged(() => ScanDatas); } }

        public string CodeMsg { get => _CodeMsg; set { _CodeMsg = value; RaisePropertyChanged(() => CodeMsg); } }


        #region 常规

        #endregion
        #region 相机

        #endregion
        #region 称

        #endregion
        #region 主题

        #endregion
        #endregion




        private void RegisterScanning()
        {
            _scanningService.ScanDataHandler+= ScanDataNoifyProxy;
            _scanningService.WeightHandler += BalanceDataNoifyProxy;
            _scanningService.TotalDataHandler+= TotalDataNoifyProxy;
        }

        private void UnRegisterScanning()
        {
            _scanningService.ScanDataHandler -= ScanDataNoifyProxy;
            _scanningService.WeightHandler -= BalanceDataNoifyProxy;
            _scanningService.TotalDataHandler -= TotalDataNoifyProxy;
        }

        private void ExcuteTestCmd()
        {
            _scanningService.Test();
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                System.Windows.MessageBox.Show("Test");
            });
        }
        private void ExcuteOpenSettingCmd()
        {
            using (var scope=_root.BeginLifetimeScope())
            {
                DispatcherHelper.UIDispatcher.Invoke(()=>scope.ResolveOptional<SettingViewModel>()?.UpdateAuth());
            }
                if (!FlyOutIsOpen)
                    FlyOutIsOpen = true;

        }
        private async void ExcuteUserManagerCmd()
        {
            _dialog.ShowLoginAsync(this, "Login from a VM", "This login dialog was shown from a VM, so you can be all MVVM.").ContinueWith(t => Console.WriteLine(t.Result));
        }

        private void ScanDataNoifyProxy(UIScanData e)
        {
            DispatcherHelper.UIDispatcher.Invoke(() =>
            {
                CodeMsg = "";
                OrderId = e.Code;
                CodeMsg = e.CodeMsg;
            });
            UpdateWritableBitmap(e.ImageData);

        }
        private void TotalDataNoifyProxy(UITotalData e)
        {
            DispatcherHelper.UIDispatcher.Invoke(() =>
            {
                if(e.IsSuccess)
                    ScanDatas.Add(new UIScanTotalDataModel() { Code = e.Code, Weight = e.Weight, ScanDate = e.ScanDate });
                OrderId = e.Code;
                Weight = e.Weight;
                CodeMsg = e.CodeMsg;
            });
            UpdateWritableBitmap(e.ImageData);

        }
        private void BalanceDataNoifyProxy(UIWeight e)
        {
            DispatcherHelper.UIDispatcher.Invoke(() =>
            {
                Weight = e.Weight;
            });
        }
        private void UpdateWritableBitmap(byte[] byt)
        {
            DispatcherHelper.UIDispatcher.Invoke(() =>
            {
                WBitmap.Lock();
                Marshal.Copy(byt, 0, WBitmap.BackBuffer, byt.Length);
                WBitmap.AddDirtyRect(new Int32Rect(0, 0, MaxW, MaxH));
                WBitmap.Unlock();
            }, DispatcherPriority.Background);
        }
    }
}
