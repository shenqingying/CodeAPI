using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class PRODUCT_GROUP
    {
        private static readonly IPRODUCT_GROUP _DataAccess = RMSDataAccess.CreateIPRODUCT_GROUP();

        public int Create(CRM_PRODUCT_GROUP model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_PRODUCT_GROUP model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int GROUPID)
        {
            return _DataAccess.Delete(GROUPID);
        }
        public IList<CRM_PRODUCT_GROUP> Read()
        {
            return _DataAccess.Read();
        }
        public int ReadByIDGroupName(string GROUPNAME)
        {
            return _DataAccess.ReadByIDGroupName(GROUPNAME);
        }


    }
}
