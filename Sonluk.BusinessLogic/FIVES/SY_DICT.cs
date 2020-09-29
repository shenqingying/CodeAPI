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
    public class SY_DICT
    {
        private static readonly ISY_DICT _DataAccess = RMSDataAccess.CreateSY_DICT();

        public MES_RETURN Create(FIVES_SY_DICT model) 
        { 
            return _DataAccess.Create(model);
        }
        public MES_RETURN Update(FIVES_SY_DICT model) 
        { 
            return _DataAccess.Update(model);
        }
        public IList<FIVES_SY_DICT> Read(FIVES_SY_DICT model) 
        { 
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(int ID) 
        { 
            return _DataAccess.Delete(ID);
        }	

    }
}
