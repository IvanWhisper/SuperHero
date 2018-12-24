using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel
{
    public class SQLFormatStr
    {
        public static string ScanDataAdd { get; private set; } = "insert into scandata(OrderId,ScanTime,Weight,ScanType,ScanPlace,Scanner,PostStatus,PostTimes,PostTime) values(@OrderId,@ScanTime,@Weight,@ScanType,@ScanPlace,@Scanner,@PostStatus,@PostTimes,@PostTime)";
        public static string ImageDataAdd { get; private set; } = "insert into scanimage(OrderId,ImgPath,PostStatus,PostTimes,PostTime,ImgStatus) values(@OrderId,@ImgPath,@PostStatus,@PostTimes,@PostTime,@ImgStatus)";
        public static string ScannedCode(int RepeatCycle)
        {
            return $"select orderid from scandata where scantime>'{DateTime.Now.AddDays(-1*RepeatCycle).Date}'";
        }

    }
}
