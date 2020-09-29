using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_WJJL
    {
        private static readonly IHG_WJJL _DataAccess = RMSDataAccess.CreateHG_WJJL();
        public int Create(CRM_HG_WJmodel model)
        {
            return _DataAccess.Create(model);
        }
        public int Delete(int JLID)
        {
            return _DataAccess.Delete(JLID);
        }
        public IList<CRM_HG_WJJL> Read(int GSDX, int GSDXID)
        {
            return _DataAccess.Read(GSDX, GSDXID);
        }
        public IList<CRM_HG_WJJL> ReadByParam(CRM_HG_WJJL model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_HG_WJJL> ReadLocation(int GSDX, int GSDXID)
        {
            return _DataAccess.ReadLocation(GSDX, GSDXID);
        }
        public int Update_SP(CRM_HG_WJJL model)
        {
            return _DataAccess.Update_SP(model);
        }
        public IList<CRM_HG_WJJL> DisplayImgReport(CRM_HG_WJJL_KHModel model, int STAFFID)
        {
            return _DataAccess.DisplayImgReport(model, STAFFID);
        }


    }
}
