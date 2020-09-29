using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KAHXDJMX
    {
        private static readonly ICOST_KAHXDJMX _DataAccess = RMSDataAccess.CreateCOST_KAHXDJMX();


        public int Create(CRM_COST_KAHXDJMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KAHXDJMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_KAHXDJMX> ReadByParam(CRM_COST_KAHXDJMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_COST_KAHXDJMX> ReadForPrint(CRM_COST_KAHXDJMX model)
        {
            return _DataAccess.ReadForPrint(model);
        }
        public int Delete(int HXDJMXID)
        {
            return _DataAccess.Delete(HXDJMXID);
        }
        public int AddPrintCount(int HXDJMXID)
        {
            return _DataAccess.AddPrintCount(HXDJMXID);
        }




    }
}
