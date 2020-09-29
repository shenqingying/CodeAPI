using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IWX_OPENID
    {
        int Create(CRM_WX_OPENID model, string USE);
        int Update(CRM_WX_OPENID model);
        int DeleteByID(int ID);
        int Delete(CRM_WX_OPENID model);
        IList<CRM_WX_OPENID> ReadByParam(CRM_WX_OPENID model);
        IList<CRM_WX_OPENIDList> ReadBySTAFFParam(CRM_WX_OPENIDList model);
        IList<CRM_WX_OPENIDList> ReadByORDERTTID(int ORDERTTID);
    }
}
