using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_DICT
    {
        private static readonly IHG_DICT _DataAccess = RMSDataAccess.CreateHG_DICT();
        public int Create(CRM_HG_DICT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HG_DICT model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int DICID)
        {
            return _DataAccess.Delete(DICID);
        }
        public IList<CRM_HG_DICT> Read(int TYPEID, int FID)
        {
            return _DataAccess.Read(TYPEID, FID);
        }
        public IList<CRM_HG_DICT> ReadByParam(CRM_HG_DICT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int ReadByDICNAME(string DICNAME, int typeID)
        {
            return _DataAccess.ReadByDICNAME(DICNAME, typeID);
        }
        public int ReadByDICNAMEandFID(string DICNAME, int typeID, int FID)
        {
            return _DataAccess.ReadByDICNAMEandFID(DICNAME, typeID, FID);
        }
        public CRM_HG_DICT ReadByDICID(int DICID)
        {
            return _DataAccess.ReadByDICID(DICID);
        }
    }
}
