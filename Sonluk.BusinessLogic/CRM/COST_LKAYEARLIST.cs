using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAYEARLIST
    {
        private static readonly ICOST_LKAYEARLIST _DataAccess = RMSDataAccess.CreateCOST_LKAYEARLIST();
        private static readonly ICOST_LKAYEARTT _TTDataAccess = RMSDataAccess.CreateCOST_LKAYEARTT();

        public int Create(CRM_COST_LKAYEARLIST model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAYEARLIST model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAYEARLIST> ReadByParam(CRM_COST_LKAYEARLIST model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int LISTID)
        {
            return _DataAccess.Delete(LISTID);
        }
        public int UpdateByTTID(int LKAYEARTTID)
        {
            _DataAccess.DeleteByTTID(LKAYEARTTID);      //先删光该TTID对应的LKA清单，然后重新新增
            CRM_COST_LKAYEARTT cxmodel = new CRM_COST_LKAYEARTT();
            cxmodel.LKAYEARTTID = LKAYEARTTID;
            List<CRM_COST_LKAYEARTT> TTdata = _TTDataAccess.ReadByParam(cxmodel, 0).ToList();
            if (TTdata.Count != 1)
            {
                return 0;
            }

            List<CRM_COST_LKAYEARLIST> LIST = _DataAccess.ReadListByKHID(TTdata[0].LKAID, TTdata[0].HTYEAR).ToList();
            for (int i = 0; i < LIST.Count; i++)         //新增LKA清单子表
            {
                CRM_COST_LKAYEARLIST LISTmodel = new CRM_COST_LKAYEARLIST();
                LISTmodel.LKAYEARTTID = LKAYEARTTID;
                LISTmodel.KHID = LIST[i].KHID;
                LISTmodel.LAST2YEAR_HT = LIST[i].LAST2YEAR_HT;
                LISTmodel.LAST2YEAR_GS = LIST[i].LAST2YEAR_GS;
                LISTmodel.LASTYEAR_HT = LIST[i].LASTYEAR_HT;
                LISTmodel.LASTYEAR_GS = LIST[i].LASTYEAR_GS;
                LISTmodel.THISYEAR_HT = LIST[i].THISYEAR_HT;
                LISTmodel.THISYEAR_GS = LIST[i].THISYEAR_GS;
                LISTmodel.CCJ_HT = LIST[i].CCJ_HT;
                LISTmodel.CCJ_GS = LIST[i].CCJ_GS;
                int ii = _DataAccess.Create(LISTmodel);
            }
            return LKAYEARTTID;
        }
        public int DeleteByTTID(int LKAYEARTTID)
        {
            return _DataAccess.DeleteByTTID(LKAYEARTTID);
        }
        public IList<CRM_COST_LKAYEARLIST> ReadListByKHID(int KHID, string YEAR)
        {
            return _DataAccess.ReadListByKHID(KHID, YEAR);
        }
    }
}
