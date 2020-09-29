using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_GROUP_KH
    {
        int Create(int KHID, int GID);
        //int Update(int KHID, int GID);
        int Delete(int KHID, int GID);
        IList<string[]> ReadByKHID(int KHID);
        IList<string[]> Read();
        IList<string[]> ReadByStaffid(int STAFFID);
        int DeletebyKHID(int KHID);
        IList<CRM_KH_GROUP_KHList> ReadStruct(int KHID, int GID);

        int Update(int KHID, int oGID, int nGid);
        IList<CRM_KH_GROUP_KHList> Report(string KHMC, int GID);
        IList<CRM_KH_GROUP_KHList> Report2(CRM_KH_GROUP_KHList model);


    }
}
