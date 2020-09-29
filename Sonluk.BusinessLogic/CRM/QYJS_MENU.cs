using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class QYJS_MENU
    {
        private static readonly IQYJS_MENU _DataAccess = RMSDataAccess.CreateIIQYJS_MENU();


        public int Create(CRM_QYJS_MENU model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_QYJS_MENU model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int CATALOGID)
        {
            return _DataAccess.Delete(CATALOGID);
        }
        public CRM_QYJS_MENU ReadbyID(int CATALOGID)
        {
            return _DataAccess.ReadbyID(CATALOGID);
        }
        public IList<CRM_QYJS_MENU> ReadTTbyParam(CRM_QYJS_MENU model)
        {
            return _DataAccess.ReadTTbyParam(model);
        }


    }
}
