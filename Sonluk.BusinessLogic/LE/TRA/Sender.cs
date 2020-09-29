using Sonluk.DAFactory;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Sender
    {
        private static readonly ISender _DetaAccess = LETRADataAccess.CreateSender();

        public IList<CompanyInfo> Read()
        {
            return _DetaAccess.Read(true);
        }

        public CompanyInfo Read(string serialNumber)
        {
            return _DetaAccess.Read(serialNumber);
        }
    }
}
