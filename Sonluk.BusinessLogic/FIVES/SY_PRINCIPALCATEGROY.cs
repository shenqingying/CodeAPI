using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.DAFactory;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.FIVES;


namespace Sonluk.BusinessLogic.FIVES
{
    public class SY_PRINCIPALCATEGROY
    {
        private static readonly ISY_PRINCIPALCATEGROY _DataAccess = RMSDataAccess.CreateSY_PRINCIPALCATEGROY();

        public MES_RETURN Create(FIVES_SY_PRINCIPALCATEGROY model) 
        { 
            return _DataAccess.Create(model);
        }
        public MES_RETURN Update(FIVES_SY_PRINCIPALCATEGROY model)
        { 
            return _DataAccess.Update(model);
        }
        public IList<FIVES_SY_PRINCIPALCATEGROYList> Read(FIVES_SY_PRINCIPALCATEGROY model)
        { 
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(FIVES_SY_PRINCIPALCATEGROY model) 
        {
            return _DataAccess.Delete(model);
        }	

    }
}
