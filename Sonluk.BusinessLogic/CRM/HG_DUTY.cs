using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_DUTY
    {
        private static readonly IHG_DUTY _DataAccess = RMSDataAccess.CreateHG_DUTY();
        public int Create(CRM_HG_DUTY model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HG_DUTY model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int DUTYID)
        {
            return _DataAccess.Delete(DUTYID);
        }
        public IList<CRM_HG_DUTY> Read()
        {
            return _DataAccess.Read();
        }
    }
}
