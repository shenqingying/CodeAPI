using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.IDataAccess.DEV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.DEV
{
    public class Table :ITable
    {
        public string Read(string name, string language)
        {
            IRfcFunction func = RFC.Function("ZDEV_TABLE_DESCRIPTION");
            func.SetValue("TABNAME", name);
            func.SetValue("DDLANGUAGE", language);
            string description = "";
            try
            {
                RFC.Invoke(func, false);
                description = func.GetString("DDTEXT");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return description; 
        }
    }
}
