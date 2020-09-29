using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.BusinessLogic.Setting
{
    public class Version
    {
        public string Read()
        {
            return Read("BusinessLogic");
        }

        public string Read(string assembly)
        {
            string version = "";
            if (assembly != null)
            {
                try
                {
                    Assembly asm = Assembly.Load("Sonluk." + assembly);
                    version = asm.GetName().Version.ToString();
                }
                catch (Exception e)
                {
                    Logger.Write("BusinessLogic.Setting.Version.Read", e.ToString());
                    assembly = "N/A";
                }
            }
            return version;
        }

        public IList<string> ReadAll()
        {
            IList<string> versions = new List<string>();
            string[] assemblyStrings = { "Sonluk.BusinessLogic", "Sonluk.DAFactory", "Sonluk.IDataAccess", "Sonluk.DAFactory", "Sonluk.DataAccess.SAP", "Sonluk.DataAccess.Oracle", "Sonluk.DataAccess.SQLServer", "Sonluk.Entities", "Sonluk.Utility" };

            versions.Add(AppConfig.Settings("Version") + "  " + AppConfig.Settings("Release"));
            foreach (string assemblyString in assemblyStrings)
            {

                Assembly asm = Assembly.Load(assemblyString);
                versions.Add(asm.GetName().Version.ToString());          
            }

            return versions;
        }
    }
}
