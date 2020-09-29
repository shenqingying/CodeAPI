using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Sonluk.BusinessLogic.CRM
{
    public class CRM_KH
    {
        private static readonly ICRM_KH _DetaAccess = RMSDataAccess.CreateCRM_KH();
        public DataTable GetJL_MeasureTypedes() 
        {
            return _DetaAccess.GetJL_MeasureTypedes();
        }

        public IList<UserModel> GetUser()
        {
            return _DetaAccess.GetCheckUser();
        }

        public int InsertKH_KH(CRM_KH_KH KH_S)
        {
            return _DetaAccess.InsertKH_KH(KH_S);
        }


        public int InsertKH_KH()
        {
            throw new NotImplementedException();
        }

        public string SelectKH_KHForKHLXandMC(int KHLX, string mc, int MCLC)
        {
            DataTable dt = _DetaAccess.SelectKH_KHForKHLXandMC(KHLX, mc,MCLC);
            return Dtb2Json(dt);
        }

        public int ModifyKH_KH(CRM_KH_KH KH_S)
        {
            return _DetaAccess.ModifyKH_KH(KH_S);
        }

       
        public string SelectKHReportWithReportModel(CRM_Report_KHModel model)
        {
            return Dtb2Json(_DetaAccess.SelectKHReportWithReportModel(model));
        }


        public int InsertCRM_KH_GXQY(CRM_KH_GXQY model)
        {
            return _DetaAccess.InsertCRM_KH_GXQY(model);
        }

        public  int InsertCRM_KH_LXR(CRM_KH_LXR model){
            return _DetaAccess.InsertCRM_KH_LXR(model);
        }


        public int InsertKH_KHQTXX(CRM_KH_KHQTXX model)
        {
            return _DetaAccess.InsertKH_KHQTXX(model);
        }


        public DataTable SelectKH_KHForKHID(int KHID)
        {
            return _DetaAccess.SelectKH_KHForKHID(KHID);
        }

        public int InsertClXX(CRM_KH_KHQTXX model, int GSDX, string ml)
        {
            return _DetaAccess.InsertClXX(model, GSDX, ml);
        }


        public string SelectKH_KHQTXX(int KHID, int XXLB, int ISACTIVE)
        {
            return Dtb2Json(_DetaAccess.SelectKH_KHQTXX(KHID, XXLB, ISACTIVE));
        }









        /// <summary>
        /// DataTable转Js字符串
        /// </summary>
        /// <param name="dtb"></param>
        /// <returns></returns>
        public static string Dtb2Json(DataTable dtb)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            System.Collections.ArrayList dic = new System.Collections.ArrayList();
            foreach (DataRow dr in dtb.Rows)
            {
                System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn dc in dtb.Columns)
                {
                    drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                dic.Add(drow);

            }
            //序列化  
            return jss.Serialize(dic);
        }
    }
}
