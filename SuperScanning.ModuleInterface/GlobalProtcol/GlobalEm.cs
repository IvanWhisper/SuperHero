using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.GlobalProtcol
{
    public enum EnableDeviceInfo
    {
        /// <summary>
        /// 成功
        /// </summary>
        ALL_SUCCESS = 0,
        /// <summary>
        /// 相机失败
        /// </summary>
        CAMERA_FAILED = 1,
        /// <summary>
        /// 电子秤失败
        /// </summary>
        BALANCE_FAILED=2,
        /// <summary>
        /// 相机电子称失败
        /// </summary>
        CAMERA_BALANCE_FAILED=3,
    }
    public enum ScanDataExceptionType
    {
        /// <summary>
        /// 正常条码，无异常
        /// </summary>
        NoExceptionType,
        /// <summary>
        /// 空条码数据
        /// </summary>
        NULLCodeExceptionType,
        /// <summary>
        /// 一帧数据中检测到多个条码数据
        /// </summary>
        MulBarCodeExceptionType,
        /// <summary>
        /// 条码长度异常
        /// </summary>
        OutOfLengthExceptionType,
        /// <summary>
        /// 不在有效条码规则范围
        /// </summary>
        OutOfRulesExceptionType
    }
    public class EnumToMsg
    {
        public static string Convert(ScanDataExceptionType em)
        {
            switch (em)
            {
                case ScanDataExceptionType.NoExceptionType:
                    return "正常条码，无异常";
                case ScanDataExceptionType.NULLCodeExceptionType:
                    return "空条码数据";
                case ScanDataExceptionType.MulBarCodeExceptionType:
                    return "一帧数据中检测到多个条码数据";
                case ScanDataExceptionType.OutOfLengthExceptionType:
                    return " 条码长度异常";
                case ScanDataExceptionType.OutOfRulesExceptionType:
                    return " 不在有效条码规则范围";
                default:
                    return "正常条码，无异常";
            }
        }
    }
}
