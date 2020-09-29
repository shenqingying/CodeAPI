using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_BINDINGDEVICE
    {
        MES_RETURN Create(EM_SY_BINDINGDEVICE model);
        //MES_RETURN Update(EM_SY_BINDINGDEVICE model);
        IList<EM_SY_BINDINGDEVICE> Read(string macadress);
        //MES_RETURN Delete(string MANUALID);
    }
}
