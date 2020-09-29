using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KQ_GZRL
    {
        private static readonly IKQ_GZRL _DataAccess = RMSDataAccess.CreateKQ_GZRL();
        public int Create(CRM_KQ_GZRL model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KQ_GZRL model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int BBID)
        {
            return _DataAccess.Delete(BBID);
        }
        public IList<CRM_KQ_GZRL> Read(string MS, int BBID)
        {
            return _DataAccess.Read(MS,BBID);
        }
        //public CRM_KQ_GZRL ReadByMS(string MS)
        //{
        //    return _DataAccess.ReadByMS(MS);
        //}
        //public CRM_KQ_GZRL ReadByBBID(int BBID)
        //{
        //    return _DataAccess.ReadByBBID(BBID);
        //}
    }
}
