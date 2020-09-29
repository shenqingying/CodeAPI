using Sonluk.DAFactory;
using Sonluk.Entities.MSG;
using Sonluk.IDataAccess.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MSG
{
    public class SYS_STAFF
    {
        private static readonly ISYS_STAFF _DataAccess = RMSDataAccess.CreateSYS_STAFF();


        public int Create(MSG_SYS_STAFF model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(MSG_SYS_STAFF model)
        {
            return _DataAccess.Update(model);
        }
        public IList<MSG_SYS_STAFF> ReadByParam(MSG_SYS_STAFF model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int ID, int XGR)
        {
            return _DataAccess.Delete(ID, XGR);
        }
        public int DeleteBySYSID(int SYSID, int XGR)
        {
            return _DataAccess.DeleteBySYSID(SYSID, XGR);
        }



    }
}
