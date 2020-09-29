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
    public class SY_STAFF_DEP
    {
        private static readonly ISY_STAFF_DEP _DataAccess = RMSDataAccess.CreateSY_STAFF_DEP();
        public MES_RETURN Create(FIVES_SY_STAFF_DEP model) {
            return _DataAccess.Create(model);
        } 
        public MES_RETURN Update(FIVES_SY_STAFF_DEP model) { 
            return _DataAccess.Update(model); 
        }
        public IList<FIVES_SY_STAFF_DEPList> Read(FIVES_SY_STAFF_DEP model) { 
            return _DataAccess.Read(model);
        }
        public IList<FIVES_SY_STAFF_DEPList> ReadByDJ(FIVES_SY_STAFF_DEP model)
        {
            IList<FIVES_SY_STAFF_DEPList> DataList = _DataAccess.Read(model);
            IList<FIVES_SY_STAFF_DEPList> query = (from c in DataList where c.XFDJSTATUS != 0 || c.STDJSTATUS != 0 || c.JFDJSTATUS != 0 select c).ToList();
            return query;
        }
        public MES_RETURN Delete(FIVES_SY_STAFF_DEP model)
        {
            return _DataAccess.Delete(model); 
        }
        public MES_RETURN Update_All(List<FIVES_SY_STAFF_DEP> model, int staffid)
        {
            FIVES_SY_STAFF_DEP delmodel = new FIVES_SY_STAFF_DEP();
            delmodel.STAFFID = staffid;
            MES_RETURN delmr = _DataAccess.Delete(delmodel);
            if (!delmr.TYPE.Equals("S"))
            {
                return delmr;
            }
            for (int i = 0; i < model.Count; i++)
            {
                MES_RETURN creatmr = _DataAccess.Create(model[i]);
                if (!creatmr.TYPE.Equals("S"))
                {
                    return delmr;
                }
            }
            MES_RETURN mr = new MES_RETURN();
            mr.TYPE = "S";
            return mr;
        }

    }
}
