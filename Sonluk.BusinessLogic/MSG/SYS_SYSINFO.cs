using Sonluk.DAFactory;
using Sonluk.Entities.MSG;
using Sonluk.IDataAccess.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MSG
{
    public class SYS_SYSINFO
    {
        private static readonly ISYS_SYSINFO _DataAccess = RMSDataAccess.CreateSYS_SYSINFO();


        public int Create(MSG_SYS_SYSINFO model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(MSG_SYS_SYSINFO model)
        {
            return _DataAccess.Update(model);
        }
        public IList<MSG_SYS_SYSINFO> ReadByParam(MSG_SYS_SYSINFO model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int SYSID, int XGR)
        {
            return _DataAccess.Delete(SYSID, XGR);
        }




    }
}
