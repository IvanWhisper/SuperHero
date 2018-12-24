using SuperScanning.ModuleInterface.GlobalProtcol;
using SuperScanning.ModuleInterface.PublishEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.BusinessComponent
{
    public interface IDeviceManagerService:IDisposable
    {
        /// <summary>
        /// 扫描重量包装数据事件
        /// </summary>
       event EventHandler<TotalDataPublishArgs> TotalDataNoifyProxyHandle;
        /// <summary>
        /// 扫描数据通知事件
        /// </summary>
        event EventHandler<ScanDataPublishArgs> ScanDataNoifyProxyHandle;
        /// <summary>
        /// 重量数据通知事件
        /// </summary>
        event EventHandler<BalancePublishArgs> BalanceDataNoifyProxyHandle;
        void SettingGolbalParam();
        /// <summary>
        /// 初始化设备层
        /// </summary>
        /// <param name="num">初始化相机数量</param>
        /// <param name="protocol">电子秤协议</param>
        /// <returns>初始化结果</returns>
        bool Initialization(int num);
        /// <summary>
        /// 取消设备层初始化
        /// </summary>
        /// <returns>取消结果</returns>
        bool UnInitialization();
        /// <summary>
        /// 获取相机直连网卡Mac地址
        /// </summary>
        string MacAddress { get; }
        /// <summary>
        /// 设备层是否启动
        /// </summary>
       bool IsDeviceRun { get; }
        /// <summary>
        /// 设备层是否启动
        /// </summary>
        /// <returns>操作结果</returns>
        bool DeviceRun();
        /// <summary>
        /// 关闭设备层
        /// </summary>
        /// <returns></returns>
        bool StopDevice();
        /// <summary>
        /// 设备层是否打开
        /// </summary>
        bool IsEnableDevice { get; }
        /// <summary>
         /// 打开设备层
         /// </summary>
         /// <returns>操作状态</returns>
        EnableDeviceInfo EnableDevice(string endpoint = "");
        /// <summary>
        /// 关闭设备层
        /// </summary>
        /// <returns>操作状态</returns>
        bool UnableDevice();
        /// <summary>
        /// 手动称重
        /// </summary>
        void WeighedByHand();
        Tuple<int, int> GetImageMaxSize();
        /// <summary>
        /// 重置标志位
        /// </summary>
        void ResetWeightFlag();

        void TestImageOut();
   }
}
