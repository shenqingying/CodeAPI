using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HD_ZYCXY
    {
        private static readonly IHD_ZYCXYTT _DataAccess_TT = RMSDataAccess.CreateHD_ZYCXYTT();
        private static readonly IHD_ZYCXYMX _DataAccess_MX = RMSDataAccess.CreateHD_ZYCXYMX();
        public int Create_TT(CRM_HD_ZYCXYTT model)
        {
            return _DataAccess_TT.Create(model);
        }
        public int Update_TT(CRM_HD_ZYCXYTT model)
        {
            return _DataAccess_TT.Update(model);
        }
        public int Delete_TT(int ZYCXYID)
        {
            return _DataAccess_TT.Delete(ZYCXYID);
        }


        public int Create_MX(CRM_HD_ZYCXYMX model)
        {
            return _DataAccess_MX.Create(model);
        }
        public int Update_MX(CRM_HD_ZYCXYMX model)
        {
            return _DataAccess_MX.Update(model);
        }
        public int Delete_MX(int ZYCXYMXID)
        {
            return _DataAccess_MX.Delete(ZYCXYMXID);
        }
    }
}
