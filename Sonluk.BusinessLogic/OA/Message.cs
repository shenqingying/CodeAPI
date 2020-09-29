using Sonluk.DAFactory;
using Sonluk.IDataAccess.OA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.OA
{
    public class Message
    {
        private static readonly IMessage _DetaAccess = OADataAccess.CreateMessage();

        public bool Send(IList<string> names, string content, IList<string> url)
        {
            bool success = false;
            try
            {
                Authority auth = new Authority();
                success = _DetaAccess.Send(auth.Authenticate().ToString(), names, content, url);
            }
            catch
            {
            }
            return success;
        }

        public bool Send(string name, string content)
        {
            IList<string> names = new List<string>();
            names.Add(name);
            IList<string> url = new List<string>();
            return Send(names, "[双鹿主机]" + content, url);
        }

        public bool Send(string content)
        {
            return Send(AppConfig.Settings("OA.Admin"), content);
        }

    }
}
