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
    public class SY_CHECKDETAILS
    {
        private static readonly ISY_CHECKDETAILS _DataAccess = RMSDataAccess.CreateSY_CHECKDETAILS();

        public MES_RETURN Create(FIVES_SY_CHECKDETAILS model) 
        { 
            return _DataAccess.Create(model); 
        } 
        public MES_RETURN Update(FIVES_SY_CHECKDETAILS model) 
        { 
            return _DataAccess.Update(model); 
        }
        public IList<FIVES_SY_CHECKDETAILSList> Read(FIVES_SY_CHECKDETAILS model) 
        { 
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(int ID) 
        { 
            return _DataAccess.Delete(ID);
        }	

    }
}
