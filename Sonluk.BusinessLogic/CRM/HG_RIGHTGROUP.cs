using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_RIGHTGROUP
    {
        private static readonly IHG_RIGHTGROUP _DataAccess = RMSDataAccess.CreateHG_RIGHTGROUP();
        public int Create(CRM_HG_RIGHTGROUP model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HG_RIGHTGROUP model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int RGROUPID)
        {
            return _DataAccess.Delete(RGROUPID);
        }
        public IList<CRM_HG_RIGHTGROUP> Read()
        {
            return _DataAccess.Read();
        }
    }
}
