using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro;
using SuperScanning.ModuleInterface.BusinessComponent;
using SuperScanning.ModuleInterface.GlobalProtcol;
using SuperScanning.WPFClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.WPFClient.UsCrlViewModel
{
    public class SettingViewModel : ViewModelBase
    {
        private ISettingService _setting;

        private IEnumerable<string> _accentData;
        private IEnumerable<string> _thmData;
        private string _CurAccent;
        private string _CurThm;

        private bool isAuth;
        private SettingProtcol settingPtl;

        private RelayCommand refreshCmd;
        private RelayCommand resetCmd;

        public IEnumerable<string> AccentData { get => _accentData; set { _accentData = value; RaisePropertyChanged(() => AccentData); } }
        public IEnumerable<string> ThmData { get => _thmData; set { _thmData = value; RaisePropertyChanged(() => ThmData); } }
        public string CurAccent
        {
            get => _CurAccent; set
            {
                _CurAccent = value;
                RaisePropertyChanged(() => CurAccent);
                ViewModelLocator.ChangeTheme(value, _CurThm);
                _setting.CurSettingProtcol.UserSetting.UISetting.AccentName = value;
                _setting.SaveSetting();
            }
        }
        public string CurThm
        {
            get => _CurThm; set
            {
                _CurThm = value; RaisePropertyChanged(() => CurThm);
                ViewModelLocator.ChangeTheme(CurAccent, value);
                _setting.CurSettingProtcol.UserSetting.UISetting.AppTheme = value;
                _setting.SaveSetting();
            }
        }

        public SettingProtcol SettingPtl { get => settingPtl; set { settingPtl = value; RaisePropertyChanged(() => SettingPtl); } }
        public bool IsAuth { get => isAuth; set { isAuth = value; RaisePropertyChanged(() => IsAuth); } }
        public void UpdateAuth()
        {
            if (_setting.GetAuth().Equals("Auth"))
            {
                IsAuth=true;
            }
            else
            {
                IsAuth=false;
            }

        }

        public RelayCommand RefreshCmd
        {
            get
            {
                if (refreshCmd == null) refreshCmd = new RelayCommand(() => ExcuteRefreshCmd());
                return refreshCmd;
            }
            set
            {
                refreshCmd = value;
            }
        }

        public RelayCommand ResetCmd
        {
            get
            {
                if (resetCmd == null) resetCmd = new RelayCommand(() => ExcuteResetCmd());
                return resetCmd;
            }
            set
            {
                resetCmd = value;
            }
        }

        public SettingViewModel(ISettingService setting)
        {
            _setting = setting;

            settingPtl = _setting.CurSettingProtcol;

            _CurAccent = setting.CurSettingProtcol.UserSetting.UISetting.AccentName;
            _CurThm = setting.CurSettingProtcol.UserSetting.UISetting.AppTheme;
            AccentData = ThemeManager.Accents.Select(c => c.Name);
            ThmData = ThemeManager.AppThemes.Select(c => c.Name);

        }


        private void ExcuteRefreshCmd()
        {
            _setting.SaveSetting();
            //System.Windows.MessageBox.Show("Refresh");
        }
        private void ExcuteResetCmd()
        {
            _setting.LoadSettting();
            SettingPtl = _setting.CurSettingProtcol;
            //System.Windows.MessageBox.Show("Reset");
        }


    }
}
