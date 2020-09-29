using Sonluk.DAFactory;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class PUBLIC_FUNC
    {
        private static readonly IPUBLIC_FUNC mesdetaAccess = MESDataAccess.CreatePUBLIC_FUNC();

        public string GET_TIME()
        {
            return mesdetaAccess.GET_TIME();
        }
    }
}
