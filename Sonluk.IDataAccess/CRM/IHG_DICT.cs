using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_DICT
    {
        int Create(CRM_HG_DICT model);
        int Update(CRM_HG_DICT model);
        int Delete(int DICID);
        IList<CRM_HG_DICT> Read(int TYPEID, int FID);
        IList<CRM_HG_DICT> ReadByParam(CRM_HG_DICT model, int STAFFID);
        int ReadDICID(string DICNAME);
        int ReadByDICNAME(string DICNAME, int typeID);
        int ReadByDICNAMEandFID(string DICNAME, int typeID, int FID);
        CRM_HG_DICT ReadByDICID(int DICID);
        int ReadDICIDandType(string DICNAME, int TYPEID);
    }
}
