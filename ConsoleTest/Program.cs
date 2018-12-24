using Newtonsoft.Json;
using SuperScanning.BusinessService;
using SuperScanning.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dictionary<string, string>();
            d.Add("zto", "123");
            d.Add("sto", "456");

            var rule = new CodeRule() { RuleMap = d };

            Console.WriteLine(JsonConvert.SerializeObject(rule));
            Console.WriteLine(new Test().doTest<string>(2));
            Console.ReadLine();
        }
    }
    public class Test
    {
        public T doTest<T>(int i)
        {
            object a = i.ToString();
            return (T)a;
        }
    }
}
