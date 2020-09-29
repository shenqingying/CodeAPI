using Sonluk.Entities.KQ;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.KQ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.KQ
{
    public class KQinfo : IKQinfo
    {
        const string SQL_SELECT = "KQ_CHECKINFO_SELECT";
        public KQINFO getKQINFO(string date)
        {

            KQINFO kq = new KQINFO();
            //DateTime dtime = Convert.ToDateTime(date);
            //string kqtime1 = dtime.ToString("yyyy-MM-dd") + " 02:30:00";
            //string kqtime2 = dtime.ToString("yyyy-MM-dd") + " 09:00:00";
            //string kqtime3 = dtime.ToString("yyyy-MM-dd") + " 18:00:00";
            //string str = "select COUNT(distinct 人员编号) from cardrecord where 设备序列号 = '3014163000013' and 考勤时间 between @kqtime1 and @kqtime2";
            //SqlParameter[] paras = {
            //                           new SqlParameter("@kqtime1",kqtime1),
            //                           new SqlParameter("@kqtime2",kqtime2),
            //                           new SqlParameter("@kqtime3",kqtime3)
            //                       };
            //DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            //str = "select COUNT(distinct 人员编号) from cardrecord where 设备序列号 = '3014163000013' and 考勤时间 between @kqtime1 and @kqtime3";
            //DataTable dt1 = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            //kq.Count1 = dt.Rows[0][0].ToString();
            //kq.Count2 = dt1.Rows[0][0].ToString();
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, "pro", new SqlParameter("@time", date));
            DataTable dt1 = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, "pro2", new SqlParameter("@time", date));
            kq.Count1 = dt.Rows[0][0].ToString();
            kq.Count2 = dt1.Rows[0][0].ToString();
            return kq;
        }

        public string StaffCardID(string cardno)
        {
            string rst = "";
            string sql = "select userinfo.badgenumber from userinfo,personnel_issuecard where userinfo.userid = personnel_issuecard.UserID_id and personnel_issuecard.cardno = @cardno";
            SqlParameter[] paras = {
                                       new SqlParameter("@cardno",cardno.TrimStart('0'))
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, sql, paras);
            if (dt.Rows.Count > 0)
            {
                rst = dt.Rows[0]["badgenumber"].ToString();
            }
            return rst;
        }

        public string GET_STAFFNAME_BYGH(string GH)
        {
            string rst = "";
            string badgenumber = "0000" + GH;
            string sql = "select userinfo.name from userinfo where badgenumber=@badgenumber";
            SqlParameter[] paras = {
                                       new SqlParameter("@badgenumber",badgenumber)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, sql, paras);
            if (dt.Rows.Count > 0)
            {
                rst = dt.Rows[0]["name"].ToString();
            }
            return rst;
        }
        public HR_KQ_KQINFO_SELECT SELECT(HR_KQ_KQINFO model)
        {
            HR_KQ_KQINFO_SELECT rst = new HR_KQ_KQINFO_SELECT();
            List<HR_KQ_KQINFO> child_HR_KQ_KQINFO_LIST = new List<HR_KQ_KQINFO>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@Id",model.Id)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_KQ_KQINFO child = new HR_KQ_KQINFO();
                        child.Id = Convert.ToInt32(sdr["Id"]);
                        child.Badgenumber = Convert.ToString(sdr["Badgenumber"]);
                        child.Name = Convert.ToString(sdr["Name"]);
                        child.Code = Convert.ToString(sdr["Code"]);
                        child.DeptName = Convert.ToString(sdr["DeptName"]);
                        child.Checktime = Convert.ToDateTime(sdr["Checktime"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.Sn_name = Convert.ToString(sdr["Sn_name"]);
                        child_HR_KQ_KQINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_KQ_KQINFO_LIST = child_HR_KQ_KQINFO_LIST;
            return rst;
        }
    }
}
