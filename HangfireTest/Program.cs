using Hangfire;
using Hangfire.MySql;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfireTest
{
    class Program
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {

            // Configure AppDomain parameter to simplify the config – http://stackoverflow.com/a/3501950/1317575
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data"));

            //LogProvider.SetCurrentLogProvider(new ColouredConsoleLogProvider());

            const string endpoint = "http://localhost:12345";

            using (WebApp.Start<Startup>(endpoint))
            {
                Console.WriteLine();
                Console.WriteLine("{0} Hangfire Server started.", DateTime.Now);
                Console.WriteLine("{0} Dashboard is available at {1}/hangfire", DateTime.Now, endpoint);
                Console.WriteLine();
                Console.WriteLine("{0} Type JOB to add a background job.", DateTime.Now);
                Console.WriteLine("{0} Press ENTER to exit...", DateTime.Now);

                string command;
                while ((command = Console.ReadLine()) != String.Empty)
                {
                    if ("job".Equals(command, StringComparison.OrdinalIgnoreCase))
                    {
                        BackgroundJob.Enqueue(() => Console.WriteLine("{0} Background job completed successfully!", DateTime.Now.ToString()));
                    }
                }

            }
        }
        public static void Send()
        {
            Console.WriteLine("{0}===》这是队列事务", DateTime.Now.ToString("HH:mm:ss"));
        }

    }
}
