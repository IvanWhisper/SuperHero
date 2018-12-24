using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.GlobalProtcol
{
    public class CameraSetParam
    {
        /// <summary>
        /// 相机品牌
        /// </summary>
        public  string CameraBrand { get; set; }
        /// <summary>
        /// 帧率
        /// </summary>
        public  string AcquisitionFrameRate { get; set; }
        /// <summary>
        /// 曝光时间
        /// </summary>
        public  string CameraExposureTime { get; set; } = "5000";
        /// <summary>
        /// 增益
        /// </summary>
        public  string Gain { get; set; }
        /// <summary>
        /// 窗口尺寸
        /// </summary>
        public  string CameraViewSize { get; set; } = "9";
        /// <summary>
        /// 单机最大读取码数
        /// </summary>
        public  int ScanRecordMaxAmount { get; set; } = 24;
        /// <summary>
        /// 算法最大运行时间
        /// </summary>
        public  string BcrParamWaitingTime { get; set; }
        /// <summary>
        /// 算法库模式
        /// </summary>
        public  string BcrParamAppMode { get; set; }
        /// <summary>
        /// 裁剪图行方向扩边
        /// </summary>
        public  string BoundaryRow { get; set; }
        /// <summary>
        ///  裁剪图列方向扩边
        /// </summary>
        public  string BoundaryCol { get; set; }
        /// <summary>
        /// 最大面单和条码高度比例
        /// </summary>
        public  string MaxBillBarHeigthRatio { get; set; }
        /// <summary>
        /// 最小面单和条码高度比例
        /// </summary>
        public  string MinBillBarHeigthRatio { get; set; }

        /// <summary>
        /// 裁剪帧数量
        /// </summary>
        public  int FrameMaxAmountForScreenShotAlg { get; set; } = 1;
        /// <summary>
        /// 清晰帧数量
        /// </summary>
        public  int FrameMaxAmountForSharpnessAlg { get; set; } = 5;

        /// <summary>
        /// 是否生成图片
        /// </summary>
        public  bool IsBuildImg { get; set; } = true;
        /// <summary>
        /// 图像格式
        /// </summary>
        public  string ImgFormat { get; set; } = "png";
        /// <summary>
        /// 图片存储路径
        /// </summary>
        public  string ImageStorePath { get; set; } = @".\ImgStore";
        /// <summary>
        /// 是否使用压缩算法
        /// </summary>
        public  bool IsUseCompression { get; set; } = false;
        /// <summary>
        /// 压缩比率
        /// </summary>
        public  int ImgCompressionRat { get; set; } = 100;


        /// <summary>
        /// 是否使用裁剪算法
        /// </summary>
        public  bool IsUseScreenShotAlg { get; set; } = true;
        /// <summary>
        /// 是否使用清晰度算法
        /// </summary>
        public  bool IsUseSharpnessAlg { get; set; } = true;
    }
}
