using Sonluk.DAFactory;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.EM
{
    public class SY_BINDINGDEVICE
    {
        private static readonly ISY_BINDINGDEVICE _DataAccess = RMSDataAccess.CreateSY_BINDINGDEVICE();
        public MES_RETURN Create(EM_SY_BINDINGDEVICE model)
        {
            return _DataAccess.Create(model);
        }

        public IList<EM_SY_BINDINGDEVICE> Read(string macadress)
        {
            return _DataAccess.Read(macadress);
        }
   
    }
}
