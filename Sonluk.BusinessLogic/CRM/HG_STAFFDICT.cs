using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_STAFFDICT
    {
        private static readonly IHG_STAFFDICT _DataAccess = RMSDataAccess.CreateHG_STAFFDICT();


        public int Create(CRM_HG_STAFFDICT model)
        {
            return _DataAccess.Create(model);
        }

        public IList<CRM_HG_STAFFDICT> ReadByParam(CRM_HG_STAFFDICT model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int STAFFID, int DICID)
        {
            return _DataAccess.Delete(STAFFID, DICID);
        }





    }
}
