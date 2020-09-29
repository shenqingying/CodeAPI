using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_TYPE
    {
        private static readonly IHG_TYPE _DataAccess = RMSDataAccess.CreateHG_TYPE();
        public int Create(CRM_HG_TYPE model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HG_TYPE model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_HG_TYPE> Read()
        {
            return _DataAccess.Read();
        }
        public int Delete(int TYPEID)
        {
            return _DataAccess.Delete(TYPEID);
        }
    }
}
