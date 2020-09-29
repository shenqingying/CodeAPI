using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CBZX
    {
        private static readonly ICOST_CBZX _DataAccess = RMSDataAccess.CreateCOST_CBZX();

        public int Create(CRM_COST_CBZX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CBZX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CBZX> ReadByParam(CRM_COST_CBZX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(string CBZXBH)
        {
            return _DataAccess.Delete(CBZXBH);
        }



    }
}
