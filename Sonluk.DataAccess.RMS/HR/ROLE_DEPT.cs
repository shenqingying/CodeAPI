using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.HR
{
    public class ROLE_DEPT : IROLE_DEPT
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_ROLE_DEPT_INSERT";
        const string SQL_UPDATE = "HR_ROLE_DEPT_UPDATE";
        const string SQL_SELECT = "HR_ROLE_DEPT_SELECT";
        public MES_RETURN INSERT(HR_ROLE_DEPT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DEPTID",model.DEPTID),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ROLE_DEPT_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_ROLE_DEPT model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@LB",LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ROLE_DEPT_UPDATE", "HR");
            }
            return rst;
        }
        public HR_ROLE_DEPT_SELECT SELECT(HR_ROLE_DEPT model)
        {
            HR_ROLE_DEPT_SELECT rst = new HR_ROLE_DEPT_SELECT();
            List<HR_ROLE_DEPT_LIST> child_HR_ROLE_DEPT_LIST = new List<HR_ROLE_DEPT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };

                //using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                //{
                //    while (sdr.Read())
                //    {
                //        HR_ROLE_DEPT_LIST child = new HR_ROLE_DEPT_LIST();
                //        child.DEPTID = Convert.ToInt32(sdr["DEPTID"]);
                //        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                //        int staffid = Convert.ToInt32(sdr["STAFFID"]);
                //        if (staffid == 0)
                //        {
                //            child.Lay_is_checked = false;
                //        }
                //        else
                //        {
                //            child.Lay_is_checked = true;
                //        }
                //        child_HR_ROLE_DEPT_LIST.Add(child);
                //    }
                //}
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                rst.DATALIST.Columns.Add("checked", typeof(bool));
                rst.DATALIST.Columns.Add("open", typeof(bool));
                for (int a = 0; a < rst.DATALIST.Rows.Count; a++)
                {
                    if (rst.DATALIST.Rows[a]["STAFFID"].ToString() != "0")
                    {
                        rst.DATALIST.Rows[a]["checked"] = true;
                    }
                    else
                    {
                        rst.DATALIST.Rows[a]["checked"] = false;
                    }
                    rst.DATALIST.Rows[a]["open"] = true;
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ROLE_DEPT_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_ROLE_DEPT_LIST = child_HR_ROLE_DEPT_LIST;
            return rst;
        }
    }
}
