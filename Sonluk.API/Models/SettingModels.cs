using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.BusinessLogic.Setting;

namespace Sonluk.API.Models
{
    public class SettingModels
    {
        private Sonluk.BusinessLogic.Setting.Version _Version;

        public Sonluk.BusinessLogic.Setting.Version Version
        {
            get
            {
                if (_Version == null)
                    _Version = new Sonluk.BusinessLogic.Setting.Version();
                return _Version;
            }
            set { _Version = value; }
        }

    }
}