using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class OA_TRANSMIT
    {
        private static readonly IOA_TRANSMIT _DataAccess = RMSDataAccess.CreateOA_TRANSMIT();
        public int Create(CRM_OA_TRANSMIT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_OA_TRANSMIT model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int ID)
        {
            return _DataAccess.Delete(ID);
        }
        public IList<CRM_OA_TRANSMIT> Read(int Status)
        {
            return _DataAccess.Read(Status);
        }
        public IList<CRM_OA_TRANSMIT> ReadByParam(CRM_OA_TRANSMIT model)
        {
            return _DataAccess.ReadByParam(model);
        }
    }
}
