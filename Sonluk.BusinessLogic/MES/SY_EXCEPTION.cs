using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_EXCEPTION
    {
        private static readonly ISY_EXCEPTION data_ISY_EXCEPTION = MESDataAccess.CreateISY_EXCEPTION();
        public MES_RETURN INSERT_CCGC(MES_SY_CCGCRETRUN model)
        {
            return data_ISY_EXCEPTION.INSERT_CCGC(model);
        }
    }
}
