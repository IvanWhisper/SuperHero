using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Req
{
    public class BaseReq<T>
    {
        public T Data { get; set; }
        public string data_digest { get; set; }
        public string msg_type { get; set; }
        public string company { get; set; }
    }
}
