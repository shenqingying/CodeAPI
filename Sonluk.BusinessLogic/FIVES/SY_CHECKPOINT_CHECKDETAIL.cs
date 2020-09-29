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
    public class SY_CHECKPOINT_CHECKDETAIL
    {
        private static readonly ISY_CHECKPOINT_CHECKDETAIL _DataAccess = RMSDataAccess.CreateSY_CHECKPOINT_CHECKDETAIL();
        public MES_RETURN Create(FIVES_SY_CHECKPOINT_CHECKDETAIL model) {
            return _DataAccess.Create(model);
        } 
        public MES_RETURN Update(FIVES_SY_CHECKPOINT_CHECKDETAIL model) { 
            return _DataAccess.Update(model);
        }
        public IList<FIVES_SY_CHECKPOINT_CHECKDETAILLIST> Read(FIVES_SY_CHECKPOINT_CHECKDETAIL model) { 
            return _DataAccess.Read(model); 
        }
        public MES_RETURN Delete(FIVES_SY_CHECKPOINT_CHECKDETAIL model)
        {
            return _DataAccess.Delete(model); 
        }


    }
}
