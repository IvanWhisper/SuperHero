using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SuperScanning.DataModel;
using SuperScanning.ModuleInterface;
using SuperScanning.ModuleInterface.Db;
using SuperScanning.ModuleInterface.GlobalProtcol;

namespace SuperScanning.Cache
{
    public class CacheManageService:ICache
    {
        private ILogger _log;
        private IQuery _query;
        private List<string> ScannedCodeList=null;
        private SettingProtcol _curSettingProtcol;
        public SettingProtcol CurSettingProtcol { get => _curSettingProtcol; set => _curSettingProtcol = value; }
        public CacheManageService(ILogger log,IQuery query)
        {
            _log = log;
            _query = query;
        }
        public void RefreshScannedCodeList()
        {
            ScannedCodeList = _query.QueryList<string>(SQLFormatStr.ScannedCode(_curSettingProtcol.ScanParam.RepeatCycle), null).ToList();
        }
        public List<string> GetScannedCodeList()
        {
            return ScannedCodeList;
        }
        public bool AddScanned(string code)
        {
            bool result = false;
            try
            {
                ScannedCodeList.Add(code);
                result = true;
            }
            catch (Exception ex)
            {
                _log.Error($"{nameof(CacheManageService)}.{nameof(AddScanned)}-{ex.ToString()}");
            }
            return result;
        }
        public UserEntity User { get; set; }
        public bool UpdateUser(string userid,string pwd)
        {
            User = new UserEntity()
            {
                UserId = userid,
                Password = pwd
            };
            if (userid.Equals("admin"))
                User.Role = userid;
            return true;
        }
        public bool IsScanned(string code)
        {
            return !ScannedCodeList.Contains(code);
        }

    }
}
