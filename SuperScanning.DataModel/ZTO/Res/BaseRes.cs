using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Res
{
    public class BaseRes<T>
    {
        public string statusCode { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public T result { get; set; }
    }
}
