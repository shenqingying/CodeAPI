using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HD_NKAMD
    {
        private static readonly IHD_NKAMDTT _DataAccess_TT = RMSDataAccess.CreateHD_NKAMDTT();
        private static readonly IHD_NKAMDMX _DataAccess_MX = RMSDataAccess.CreateHD_NKAMDMX();
        public int Create_TT(CRM_HD_NKAMDTT model)
        {
            return _DataAccess_TT.Create(model);
        }
        public int Update_TT(CRM_HD_NKAMDTT model)
        {
            return _DataAccess_TT.Update(model);
        }
        public int Delete_TT(int NKAMDID)
        {
            return _DataAccess_TT.Delete(NKAMDID);
        }


        public int Create_MX(CRM_HD_NKAMDMX model)
        {
            return _DataAccess_MX.Create(model);
        }
        public int Update_MX(CRM_HD_NKAMDMX model)
        {
            return _DataAccess_MX.Update(model);
        }
        public int Delete_MX(int NKAMDMXID)
        {
            return _DataAccess_MX.Delete(NKAMDMXID);
        }
    }
}
