using Autofac;
using SuperScanning.DataModel;
using SuperScanning.Model.Dto;
using SuperScanning.ModuleInterface;
using SuperScanning.ModuleInterface.BusinessComponent;
using SuperScanning.ModuleInterface.Db;
using SuperScanning.ModuleInterface.GlobalProtcol;
using SuperScanning.ModuleInterface.PublishEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.BusinessService
{
    public class ScanningService : IScanningService
    {
        private ILogger _log;
        private IDeviceManagerService _deviceManagerService;
        private ILifetimeScope _root;
        private ICache _cache;
        private string _imagePath;
        public Int32 MaxW { get; private set; } = 3072;
        public Int32 MaxH { get; private set; } =2048;
        public ScanningService(ILogger log,IDeviceManagerService deviceManagerService,ILifetimeScope root,ICache cache)
        {
            _log = log;
            _deviceManagerService = deviceManagerService;
            _root = root;
            _cache = cache;

            var ls=_root.ResolveOptional<ICache>().GetScannedCodeList();

            var mh = _deviceManagerService.GetImageMaxSize();
            if (mh != null)
            {
                MaxW = mh.Item1;
                MaxH = mh.Item2;
            }
            RegisterScanning();
            _deviceManagerService.Initialization(10);
            _deviceManagerService.EnableDevice();
            _deviceManagerService.DeviceRun();
        }
        public void Test()
        {
            _deviceManagerService.TestImageOut();
        }
        public void RegisterScanning()
        {
            _deviceManagerService.ScanDataNoifyProxyHandle += _deviceManagerService_ScanDataNoifyProxyHandle;
            _deviceManagerService.BalanceDataNoifyProxyHandle += _deviceManagerService_BalanceDataNoifyProxyHandle;
            _deviceManagerService.TotalDataNoifyProxyHandle += _deviceManagerService_TotalDataNoifyProxyHandle;
        }
        private void _deviceManagerService_TotalDataNoifyProxyHandle(object sender, TotalDataPublishArgs e)
        {
            bool IsActionSuccess = false;
            if(_cache.IsScanned(e.ScanDataCode))
            {
                ScanDataEntity entity = new ScanDataEntity();
                ScanImageDataEntity imgentity = new ScanImageDataEntity();
                imgentity.OrderId = entity.OrderId = e.ScanDataCode;
                entity.Weight = e.Weight;
                entity.ScanTime = DateTime.Now;
                imgentity.PostStatus = entity.PostStatus = 0;
                imgentity.PostTime = entity.PostTime = DateTime.Now;
                imgentity.PostTimes = entity.PostTimes = 0;
                entity.Scanner = "";
                entity.ScanPlace = "";
                entity.ScanType = "0";
                imgentity.ImgStatus = 0;
                imgentity.ImgPath = _imagePath;
                using (var scope = _root.BeginLifetimeScope())
                {
                    var dataCount = scope.ResolveOptional<IRepository<ScanDataEntity>>().Add(SQLFormatStr.ScanDataAdd, entity, false);
                    _log.Info($"插入数据库 ScanData{dataCount}条");
                    var imageCount = scope.ResolveOptional<IRepository<ScanImageDataEntity>>().Add(SQLFormatStr.ImageDataAdd, imgentity, false);
                    _log.Info($"插入数据库 ImageData{imageCount}条");
                }
                _cache.AddScanned(e.ScanDataCode);
                IsActionSuccess = true;
            }
            else
            {
                e.CodeMsg = "条码已扫描";
            }
            TotalDataHandler?.Invoke(new UITotalData() { IsSuccess= IsActionSuccess, Code = e.ScanDataCode, CodeMsg = e.CodeMsg, Weight = e.Weight, ImageData = e.ImageData,ScanDate= e.ScanTime });
        }
        private void _deviceManagerService_BalanceDataNoifyProxyHandle(object sender, BalancePublishArgs e)
        {
            WeightHandler?.Invoke(new UIWeight() { Weight = e.Weight });
        }
        private void _deviceManagerService_ScanDataNoifyProxyHandle(object sender, ScanDataPublishArgs e)
        {
            ScanDataHandler?.Invoke(new UIScanData() { Code = e.ScanData.Code, CodeMsg = EnumToMsg.Convert(e.ScanData.ExpType), ImageData = e.ImageData });
        }
        public event Action<UIScanData> ScanDataHandler;
        public event Action<UITotalData> TotalDataHandler;
        public event Action<UIWeight> WeightHandler;
    }
}
