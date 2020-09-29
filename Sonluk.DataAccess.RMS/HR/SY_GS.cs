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
    public class SY_GS : ISY_GS
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_SY_GS_INSERT";
        const string SQL_SELECT = "HR_SY_GS_SELECT";
        const string SQL_UPDATE = "HR_SY_GS_UPDATE";
        const string SQL_DELETE = "HR_SY_GS_DELETE";
        const string SQL_UPDATE_YYZZ = "HR_SY_GS_YYZZ_UPDATE";
        const string SQL_SELECT_GS_ROLE = "HR_ROLE_GS_SELECT";
        const string SQL_INSERT_GS_ROLE = "INSERT HR_ROLE_GS(STAFFID,GS)VALUES(@STAFFID,@GS)";
        const string SQL_DELETE_GS_ROLE = "DELETE FROM HR_ROLE_GS WHERE STAFFID=@STAFFID";
        const string SQL_GS_BY_ROLE = "HR_SY_GS_SELECT_BY_ROLE";
        public MES_RETURN INSERT(HR_SY_GS model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@GSJC",model.GSJC),
                                       new SqlParameter("@GSNAME",model.GSNAME),
                                       new SqlParameter("@GSADDRESS",model.GSADDRESS),
                                       new SqlParameter("@GSSHXYDM",model.GSSHXYDM),
                                       new SqlParameter("@GSFR",model.GSFR),
                                       new SqlParameter("@GSKHYH",model.GSKHYH),
                                       new SqlParameter("@GSYHZH",model.GSYHZH),
                                       new SqlParameter("@GSTEL",model.GSTEL),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@GSPX",model.GSPX),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@ISACTION",model.ISACTION)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SY_GS_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE(HR_SY_GS model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SY_GS_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_SY_GS model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@GSJC",model.GSJC),
                                       new SqlParameter("@GSNAME",model.GSNAME),
                                       new SqlParameter("@GSADDRESS",model.GSADDRESS),
                                       new SqlParameter("@GSSHXYDM",model.GSSHXYDM),
                                       new SqlParameter("@GSFR",model.GSFR),
                                       new SqlParameter("@GSKHYH",model.GSKHYH),
                                       new SqlParameter("@GSYHZH",model.GSYHZH),
                                       new SqlParameter("@GSTEL",model.GSTEL),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@GSPX",model.GSPX),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@ISACTION",model.ISACTION)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SY_GS_UPDATE", "HR");
            }
            return rst;
        }
        public HR_SY_GS_SELECT SELECT(HR_SY_GS model)
        {
            HR_SY_GS_SELECT rst = new HR_SY_GS_SELECT();
            List<HR_SY_GS_LIST> child_HR_SY_GS_LIST = new List<HR_SY_GS_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@ISACTION",model.ISACTION)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_GS_LIST child = new HR_SY_GS_LIST();
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSJC = Convert.ToString(sdr["GSJC"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.GSADDRESS = Convert.ToString(sdr["GSADDRESS"]);
                        child.GSSHXYDM = Convert.ToString(sdr["GSSHXYDM"]);
                        child.GSFR = Convert.ToString(sdr["GSFR"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.GSKHYH = Convert.ToString(sdr["GSKHYH"]);
                        child.GSYHZH = Convert.ToString(sdr["GSYHZH"]);
                        child.GSTEL = Convert.ToString(sdr["GSTEL"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.GSYYZZ = Convert.ToString(sdr["GSYYZZ"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.GSPX = Convert.ToInt32(sdr["GSPX"]);
                        child_HR_SY_GS_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SY_GS_SELECT", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_GS_LIST = child_HR_SY_GS_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE_YYZZ(HR_SY_GS model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@GSYYZZ",model.GSYYZZ),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_YYZZ, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_GS_YYZZ_UPDATE", "HR");
            }
            return rst;
        }
        public HR_SY_GS_LAY_SELECT SELECT_GS_ROLE_LAY(int STAFFID)
        {
            HR_SY_GS_LAY_SELECT rst = new HR_SY_GS_LAY_SELECT();
            List<HR_SY_GS_LAY_LIST> child_HR_SY_GS_LAY_LIST = new List<HR_SY_GS_LAY_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {

                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_GS_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_GS_LAY_LIST child = new HR_SY_GS_LAY_LIST();
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        if (Convert.ToInt32(sdr["STAFFID"]) > 0)
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        child_HR_SY_GS_LAY_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.HR_SY_GS_LAY_LIST = child_HR_SY_GS_LAY_LIST;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_ROLE_SELECT", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE_GS_ROLE_LAY(int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_GS_ROLE, parms))
                {
                    rst.TYPE = "S";
                    rst.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_ROLE_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN INSERT_GS_ROLE_LAY(HR_SY_GS_LAY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@GS",model.GS),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT_GS_ROLE, parms))
                {
                    rst.TYPE = "S";
                    rst.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_ROLE_INSERT", "HR");
            }
            return rst;
        }
        public HR_SY_GS_SELECT SELECT_BY_ROLE(int STAFFID)
        {
            HR_SY_GS_SELECT rst = new HR_SY_GS_SELECT();
            List<HR_SY_GS_LIST> child_HR_SY_GS_LIST = new List<HR_SY_GS_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_GS_BY_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_GS_LIST child = new HR_SY_GS_LIST();
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSJC = Convert.ToString(sdr["GSJC"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.GSADDRESS = Convert.ToString(sdr["GSADDRESS"]);
                        child.GSSHXYDM = Convert.ToString(sdr["GSSHXYDM"]);
                        child.GSFR = Convert.ToString(sdr["GSFR"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.GSKHYH = Convert.ToString(sdr["GSKHYH"]);
                        child.GSYHZH = Convert.ToString(sdr["GSYHZH"]);
                        child.GSTEL = Convert.ToString(sdr["GSTEL"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.GSYYZZ = Convert.ToString(sdr["GSYYZZ"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.GSPX = Convert.ToInt32(sdr["GSPX"]);
                        child_HR_SY_GS_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SY_GS_SELECT_BY_ROLE", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_GS_LIST = child_HR_SY_GS_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}
