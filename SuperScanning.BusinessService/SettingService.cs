using Newtonsoft.Json;
using SuperScanning.DataModel;
using SuperScanning.Model;
using SuperScanning.ModuleInterface;
using SuperScanning.ModuleInterface.BusinessComponent;
using SuperScanning.ModuleInterface.GlobalProtcol;
using SuperScanning.ModuleInterface.InterceptorCallHandlerAttributeAttribute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.BusinessService
{
    public class SettingService: ISettingService
    {
        private string settingPath;
        private string settingFileName="SettingData.json";
        private string rulesFileName = "rules.json";
        private CodeRule rule;
        private ILogger _log;
        private ICache _cache;
        public string SettingPath { get => settingPath; set {
                if (!Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }
                settingPath = value;
            } }
        public SettingProtcol CurSettingProtcol { get => _cache.CurSettingProtcol; }
        
        public string GetRule
        {
            get
            {
                return rule.RuleMap[CurSettingProtcol.ScanParam.CodeRulePolicy] ?? null;
            }
        }
        public string SettingFileName { get => settingFileName;private set => settingFileName = value; }
        public string RulesFileName { get => rulesFileName; set => rulesFileName = value; }

        public SettingService(ILogger log,ICache cache)
        {
            this._log = log;
            this._cache = cache;
            SettingPath = System.Configuration.ConfigurationManager.AppSettings["settingpath"];
            LoadSettting();
            LoadRules();
            _cache.RefreshScannedCodeList();
        }

        [AuthInterceptorCallHandlerAttribute(Role ="admin", DefaultReturnValue = "NoAuth")]
        public string GetAuth()
        {
            return "Auth";
        }

        public bool LoadRules()
        {
            rule=Load<CodeRule>(RulesFileName);
            return true;
        }
        public bool SaveRules()
        {
            return Save(RulesFileName,rule);
        }

        public bool LoadSettting()
        {
            _cache.CurSettingProtcol = Load<SettingProtcol>(SettingFileName);
            return true;
        }
        public bool SaveSetting()
        {
            return Save(SettingFileName,CurSettingProtcol);
        }

        private T Load<T>(string filename)
        {
            try
            {
                var json = GetJson(Path.Combine(SettingPath, filename));
                var res = JsonConvert.DeserializeObject<T>(json);
                return res;
            }
            catch (Exception ex)
            {
                _log.Error($"LoadSetttingFromFile()-{ex.Message}");
                return default(T);
            }
        }
        private bool Save(string filename,object obj)
        {
            bool result = false;
            try
            {
                var filepath = Path.Combine(SettingPath, filename);
                var json = JsonConvert.SerializeObject(obj);
                SaveJson(filepath, json);
                result = true;
            }
            catch (Exception ex)
            {
                _log.Error($"BuildSettingToFile()-{ex.Message}");
            }
            return result;
        }
        private static string GetJson(string path)
        {
            using (FileStream fsRead = new FileStream(path, FileMode.Open))
            {
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                return System.Text.Encoding.UTF8.GetString(heByte);
            }
        }
        private static void SaveJson(string path, string json)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(json);
                }
            }
        }
    }
}
