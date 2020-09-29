using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_GROUP_KH
    {
        private static readonly IKH_GROUP_KH _DataAccess = RMSDataAccess.CreateKH_GROUP_KH();
        private static readonly IKH_KH _KHDataAccess = RMSDataAccess.CreateKH_KH();
        public IList<string[]> ReadByKHID(int KHID)
        {
            return _DataAccess.ReadByKHID(KHID);
        }
        /// <summary>
        /// 正常情况下返回1，表示返回成功，-100表示直营卖场同系统下门店编号重复
        /// </summary>
        /// <param name="KHID"></param>
        /// <param name="GID"></param>
        /// <returns></returns>
        public int Create(int KHID, int GID)
        {
            CRM_KH_KHList KH = _KHDataAccess.Read(KHID);
            if(KH.KHLX == 3 && KH.BEIZ != "")
            {
                //当客户为直营卖场时，同系统下门店编号不可重复
                CRM_Report_KHModel cxmodel = new CRM_Report_KHModel();
                cxmodel.GID = GID;
                cxmodel.BEIZ = KH.BEIZ;
                IList<CRM_KH_KHList> data = _KHDataAccess.Report(cxmodel, 0);
                if(data.Count > 0)
                {
                    return -100;
                }
            }





            return _DataAccess.Create(KHID, GID);
        }
        //public int Update(int KHID, int GID)
        //{
        //    return _DataAccess.Update(KHID, GID);
        //}
        public int Delete(int KHID, int GID)
        {
            return _DataAccess.Delete(KHID, GID);
        }
        public IList<string[]> Read()
        {
            return _DataAccess.Read();
        }
        public IList<string[]> ReadByStaffid(int STAFFID)
        {
            return _DataAccess.ReadByStaffid(STAFFID);
        }
        public int DeletebyKHID(int KHID)
        {
            return _DataAccess.DeletebyKHID(KHID);
        }
        public IList<CRM_KH_GROUP_KHList> ReadStruct(int KHID, int GID)
        {
            return _DataAccess.ReadStruct(KHID, GID);
        }
        public int Update(int KHID, int oGID, int nGid)
        {
            return _DataAccess.Update(KHID, oGID, nGid);
        }
        public IList<CRM_KH_GROUP_KHList> Report(string KHMC, int GID)
        {
            return _DataAccess.Report(KHMC, GID);
        }
        public IList<CRM_KH_GROUP_KHList> Report2(CRM_KH_GROUP_KHList model)
        {
            return _DataAccess.Report2(model);
        }
    }
}
