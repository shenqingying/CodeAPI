using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HD_NKAXT
    {
        private static readonly IHD_NKAXTTT _DataAccess_TT = RMSDataAccess.CreateHD_NKAXTTT();
        private static readonly IHD_NKAXTMX _DataAccess_MX = RMSDataAccess.CreateHD_NKAXTMX();
        public int Create_TT(CRM_HD_NKAXTTT model)
        {
            return _DataAccess_TT.Create(model);
        }
        public int Update_TT(CRM_HD_NKAXTTT model)
        {
            return _DataAccess_TT.Update(model);
        }
        public int Delete_TT(int NKAXTID)
        {
            return _DataAccess_TT.Delete(NKAXTID);
        }







        public int Create_MX(CRM_HD_NKAXTMX model)
        {
            return _DataAccess_MX.Create(model);
        }
        public int Update_MX(CRM_HD_NKAXTMX model)
        {
            return _DataAccess_MX.Update(model);
        }
        public int Delete_MX(int NKAXTMXID)
        {
            return _DataAccess_MX.Delete(NKAXTMXID);
        }
    }
}
