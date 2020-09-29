using Newtonsoft.Json;
using Sonluk.DAFactory;
using Sonluk.Entities.Account;
using Sonluk.IDataAccess.SSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.SSO
{
    public class Authorization
    {
        private static readonly IAuthorization detaAccess = SSODataAccess.CreateAuthorization();
        public IList<string> Read(int UID)
        {
            return detaAccess.Read(UID);
        }

        public MenuInfo Menu(int UID)
        {
            MenuInfo menu = new MenuInfo();
            menu.Children = detaAccess.Menu(UID, 0).ToList();
            return menu;
        }

        public MenuInfo Menu(int UID,int parent)
        {
            MenuInfo menu = new MenuInfo();
            menu.Children = detaAccess.Menu(UID, parent).ToList();
            return menu;
        }

        public string Menu(int UID, bool NullValueHandlingIgnore)
        {
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            if (NullValueHandlingIgnore)
            {
                jsonSetting.NullValueHandling = NullValueHandling.Ignore;
            }
            return JsonConvert.SerializeObject(Menu(UID), jsonSetting);
        }
    }
}
