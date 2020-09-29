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
    public class SY_RELATIONSHIPBIND
    {
        private static readonly ISY_RELATIONSHIPBIND _DataAccess = RMSDataAccess.CreateSY_RELATIONSHIPBIND();
        public MES_RETURN Create(FIVES_SY_RELATIONSHIPBIND model) 
        { 
            return _DataAccess.Create(model); 
        } 
        public MES_RETURN Update(FIVES_SY_RELATIONSHIPBIND model) 
        { 
            return _DataAccess.Update(model);
        }
        public IList<FIVES_SY_RELATIONSHIPBINDList> Read(FIVES_SY_RELATIONSHIPBIND model) 
        { 
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(FIVES_SY_RELATIONSHIPBIND model) 
        {
            return _DataAccess.Delete(model);
        }
        public MES_RETURN Delete_OJB1(FIVES_SY_RELATIONSHIPBIND model) 
        {
            return _DataAccess.Delete_OJB1(model);
        }
        public MES_RETURN Delete_OJB2(FIVES_SY_RELATIONSHIPBIND model) 
        {
            return _DataAccess.Delete_OJB2(model);
        }


    }
}
