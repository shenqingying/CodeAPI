using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HD_ZDF
    {
        private static readonly IHD_ZDF _DataAccess = RMSDataAccess.CreateHD_ZDF();
        public int Create(CRM_HD_ZDF model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HD_ZDF model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int ZDFID)
        {
            return _DataAccess.Delete(ZDFID);
        }
        public IList<CRM_HD_ZDFList> Read(CRM_HD_ZDF_PARAMS model)
        {
            return _DataAccess.Read(model);
        }
        public CRM_HD_ZDF ReadByZDFID(int ZDFID)
        {
            return _DataAccess.ReadByZDFID(ZDFID);
        }
        public IList<CRM_HD_ZDFList> ReadBySTAFFID(CRM_HD_ZDF_PARAMS model)
        {
            return _DataAccess.ReadBySTAFFID(model);
        }
    }
}
