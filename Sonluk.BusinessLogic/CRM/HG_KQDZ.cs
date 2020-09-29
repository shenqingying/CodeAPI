using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_KQDZ
    {
        private static readonly IHG_KQDZ _DataAccess = RMSDataAccess.CreateHG_KQDZ();
        public int Create(CRM_HG_KQDZ model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HG_KQDZ model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int KQDZID)
        {
            return _DataAccess.Delete(KQDZID);
        }
        public IList<CRM_HG_KQDZ> Read(int KQDZID)
        {
            return _DataAccess.Read(KQDZID);
        }
        public IList<CRM_HG_KQDZ> ReadBySTAFFID(int STAFFID)
        {
            return _DataAccess.ReadBySTAFFID(STAFFID);
        }
        public IList<CRM_HG_KQDZ> ReadBylikeKQDZ(string KQDZ)
        {
            return _DataAccess.ReadBylikeKQDZ(KQDZ);
        }
        public IList<CRM_HG_KQDZList> Report(CRM_HG_KQDZList model)
        {
            return _DataAccess.Report(model);
        }
    }
}
