using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_DEPT
    {
        private static readonly IHG_DEPT _DataAccess = RMSDataAccess.CreateHG_DEPT();
        public int Create(CRM_HG_DEPT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HG_DEPT model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int DEPID)
        {
            return _DataAccess.Delete(DEPID);
        }
        public IList<CRM_HG_DEPT> Read()
        {
            return _DataAccess.Read();
        }
        public CRM_HG_DEPTList ReadByDEPID(int DEPID)
        {
            return _DataAccess.ReadByDEPID(DEPID);
        }
        public CRM_HG_DEPT ReadByName(string DEPNAME)
        {
            return _DataAccess.ReadByName(DEPNAME);
        }
        public IList<CRM_HG_DEPT> ReadByStaffid(int STAFFID)
        {
            return _DataAccess.ReadByStaffid(STAFFID);
        }

    }
}
