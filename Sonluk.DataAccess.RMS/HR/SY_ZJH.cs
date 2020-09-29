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
    public class SY_ZJH : ISY_ZJH
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_SY_ZJH_INSERT";
        const string SQL_SELECT = "HR_SY_ZJH_SELECT";
        const string SQL_UPDATE = "HR_SY_ZJH_UPDATE";
        const string SQL_DELETE = "HR_SY_ZJH_DELETE";
        const string SQL_SELECT_LAY = "HR_GS_ZJH_LY_SELECT";
        const string SQL_DELETE_LAY = "HR_GS_ZJH_LY_DELETE";
        const string SQL_INSERT_LAY = "HR_GS_ZJH_LY_INSERT";
        const string SQL_SELECT_ZJH_ROLE = "HR_ROLE_ZJH_SELECT";
        const string SQL_INSERT_ZJH_ROLE = "INSERT HR_ROLE_ZJH(STAFFID,ZJHID)VALUES(@STAFFID,@ZJHID)";
        const string SQL_DELETE_ZJH_ROLE = "DELETE FROM HR_ROLE_ZJH WHERE STAFFID=@STAFFID";
        const string SQL_SELECT_BY_ROLE = "HR_GS_ZJH_LY_SELECT_BY_ROLE";

        public MES_RETURN INSERT(HR_SY_ZJH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@ZNAME",model.ZNAME),
                                       new SqlParameter("@ISACTION",model.ISACTION)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["TID"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_ZJH_INSERT", "HR");
            }
            return rst;
        }
        public HR_SY_ZJH_SELECT SELECT(HR_SY_ZJH model)
        {
            HR_SY_ZJH_SELECT rst = new HR_SY_ZJH_SELECT();
            List<HR_SY_ZJH_LIST> child_HR_SY_ZJH_LIST = new List<HR_SY_ZJH_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@ZNAME",model.ZNAME),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_ZJH_LIST child = new HR_SY_ZJH_LIST();
                        child.ZJHID = Convert.ToInt32(sdr["ZJHID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.ZNAME = Convert.ToString(sdr["ZNAME"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child_HR_SY_ZJH_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_ZJH_SELECT", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_ZJH_LIST = child_HR_SY_ZJH_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE(HR_SY_ZJH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ZJHID",model.ZJHID),
                                       new SqlParameter("@ZNAME",model.ZNAME),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_ZJH_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE(int ZJHID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ZJHID",ZJHID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_ZJH_DELETE", "HR");
            }
            return rst;
        }
        public HR_SY_ZJH_LAY_SELECT SELECT_ZJH_LAY(int ZJHID, string GS)
        {
            HR_SY_ZJH_LAY_SELECT rst = new HR_SY_ZJH_LAY_SELECT();
            List<HR_SY_ZJH_LAY_LIST> child_HR_SY_ZJH_LAY_LIST = new List<HR_SY_ZJH_LAY_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {

                SqlParameter[] parms = {
                                       new SqlParameter("@ZJHID",ZJHID),
                                       new SqlParameter("@GS",GS)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LAY, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_ZJH_LAY_LIST child = new HR_SY_ZJH_LAY_LIST();
                        child.LYID = Convert.ToInt32(sdr["LYID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.LYNAME = Convert.ToString(sdr["LYNAME"]);
                        child.ISMR = Convert.ToInt32(sdr["ISMR"]);
                        if (Convert.ToInt32(sdr["ZJHID"]) > 0)
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        child_HR_SY_ZJH_LAY_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.HR_SY_ZJH_LAY_LIST = child_HR_SY_ZJH_LAY_LIST;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_ZJH_LY_SELECT", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE_ZJH_LAY(int ZJHID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ZJHID",ZJHID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE_LAY, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_ZJH_LY_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN INSERT_ZJH_LAY(HR_SY_ZJH_LAY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ZJHID",model.ZJHID),
                                       new SqlParameter("@LYID",model.LYID),
                                       new SqlParameter("@ISMR",model.ISMR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_LAY, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_ZJH_LY_INSERT", "HR");
            }
            return rst;
        }
        public HR_SY_ZJH_LAY_SELECT SELECT_ZJH_ROLE_LAY(int STAFFID)
        {
            HR_SY_ZJH_LAY_SELECT rst = new HR_SY_ZJH_LAY_SELECT();
            List<HR_SY_ZJH_LAY_LIST> child_HR_SY_ZJH_LAY_LIST = new List<HR_SY_ZJH_LAY_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {

                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ZJH_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_ZJH_LAY_LIST child = new HR_SY_ZJH_LAY_LIST();
                        child.ZJHID = Convert.ToInt32(sdr["ZJHID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.ZNAME = Convert.ToString(sdr["ZNAME"]);
                        if (Convert.ToInt32(sdr["STAFFID"]) > 0)
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        child_HR_SY_ZJH_LAY_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.HR_SY_ZJH_LAY_LIST = child_HR_SY_ZJH_LAY_LIST;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ZJH_ROLE_SELECT", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE_ZJH_ROLE_LAY(int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_ZJH_ROLE, parms))
                {
                    rst.TYPE = "S";
                    rst.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ZJH_ROLE_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN INSERT_ZJH_ROLE_LAY(HR_SY_ZJH_LAY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@ZJHID",model.ZJHID),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT_ZJH_ROLE, parms))
                {
                    rst.TYPE = "S";
                    rst.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ZJH_ROLE_INSERT", "HR");
            }
            return rst;
        }

        public HR_SY_ZJH_LAY_SELECT SELECT_BY_ROLE(int STAFFID, string GS)
        {
            HR_SY_ZJH_LAY_SELECT rst = new HR_SY_ZJH_LAY_SELECT();
            List<HR_SY_ZJH_LAY_LIST> child_HR_SY_ZJH_LAY_LIST = new List<HR_SY_ZJH_LAY_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {

                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@GS",GS)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_ZJH_LAY_LIST child = new HR_SY_ZJH_LAY_LIST();
                        child.LYID = Convert.ToInt32(sdr["LYID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.LYNAME = Convert.ToString(sdr["LYNAME"]);
                        child.ISMR = Convert.ToInt32(sdr["ISMR"]);
                        child_HR_SY_ZJH_LAY_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.HR_SY_ZJH_LAY_LIST = child_HR_SY_ZJH_LAY_LIST;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_ZJH_LY_SELECT_BY_ROLE", "HR");
            }
            return rst;
        }
    }
}
