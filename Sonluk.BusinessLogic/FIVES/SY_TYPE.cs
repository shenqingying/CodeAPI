using Sonluk.DAFactory;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.FIVES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.FIVES
{
    public class SY_TYPE
    {
        private static readonly ISY_TYPE  _DataAccess = RMSDataAccess.CreateSY_TYPE();

        public MES_RETURN Create(FIVES_SY_TYPE model) {
            return _DataAccess.Create(model);
        } 
        public MES_RETURN Update(FIVES_SY_TYPE model) { 
            return _DataAccess.Update(model);
        }
        public IList<FIVES_SY_TYPE> Read(FIVES_SY_TYPE model) { 
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(int ID) {
            return _DataAccess.Delete(ID);
        }


    }
}
