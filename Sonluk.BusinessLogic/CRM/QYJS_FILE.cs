using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class QYJS_FILE
    {
        private static readonly IQYJS_FILE _DataAccess = RMSDataAccess.CreateQYJS_FILE();

        public int Create(CRM_QYJS_FILE model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_QYJS_FILE model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_QYJS_FILE> ReadByParam(CRM_QYJS_FILE model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int ID)
        {
            return _DataAccess.Delete(ID);
        }


    }
}
