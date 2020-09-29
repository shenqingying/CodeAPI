using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_BZGZSJ
    {
        private static readonly IHG_BZGZSJ _DataAccess = RMSDataAccess.CreateHG_BZGZSJ();
        public int Create(CRM_HG_BZGZSJ model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HG_BZGZSJ model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int BZID)
        {
            return _DataAccess.Delete(BZID);
        }
        public IList<CRM_HG_BZGZSJ> Read(int STAFFID)
        {
            return _DataAccess.Read(STAFFID);
        }
        public CRM_HG_BZGZSJ ReadByBZNAME(string BZNAME)
        {
            return _DataAccess.ReadByBZNAME(BZNAME);
        }
        public CRM_HG_BZGZSJ ReadByBZID(int BZID)
        {
            return _DataAccess.ReadByBZID(BZID);
        }
    }
}
