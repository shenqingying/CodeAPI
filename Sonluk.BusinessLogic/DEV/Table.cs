using Sonluk.DAFactory;
using Sonluk.IDataAccess.DEV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.BC
{
    public class Table
    {
        private static readonly ITable _DetaAccess = DEVDataAccess.CreateTable();

        public string Read(string name)
        {
            return _DetaAccess.Read(name, "1");
        }
    }
}
