using Newtonsoft.Json;
using RestSharp;
using SuperScanning.DataModel.ZTO.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.Core.API
{
    public class RestClientCenter
    {
        JsonSerializerSettings jSettings = new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd HH:mm:ss" };
        public RestClientCenter()
        {
        }
        public async Task<BaseRes<T>> Execute<T>(string url,string jsonStr)
        {
            var res = new BaseRes<T>();
            var client = new RestClient("");
            var request = new RestRequest();
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddParameter("application/json", jsonStr, ParameterType.RequestBody);
            var result = await client.ExecutePostTaskAsync(request);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //log.ErrorFormat("get {0} response from service!", result.StatusCode);
                res.statusCode = "FAILD";
                res.status = $"{false}";
                res.message = result.ErrorMessage;
            }
            else
            {
                res.statusCode = "SUCCESS";
                res.status = $"{true}";
            }
            res.result = JsonConvert.DeserializeObject<T>(result.Content, jSettings);
            return res;
        }

    }
}
