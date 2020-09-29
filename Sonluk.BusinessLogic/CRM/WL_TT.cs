using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class WL_TT
    {
        private static readonly IWL_TT _DataAccess = RMSDataAccess.CreateWL_TT();

        public int Create(CRM_WL_TT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_WL_TT model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_WL_TT> ReadByParam(CRM_WL_TT model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int TTID)
        {
            return _DataAccess.Delete(TTID);
        }
    }
}
