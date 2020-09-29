using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.MES;
using Sonluk.Entities.SSO;
using Sonluk.IDataAccess.SSO;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.SSO
{
    public class TOKEN_TOKENIDINFO : ITOKEN_TOKENIDINFO
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "SSO_TOKEN_TOKENIDINFO_INSERT";
        const string SQL_SELECT = "SSO_TOKEN_TOKENIDINFO_SELECT";
        const string SQL_UPDATE = "SSO_TOKEN_TOKENIDINFO_UPDATE";
        const string SQL_USERNAMEDY_INSERT = "SSO_TOKEN_USERNAMEDY_INSERT";
        const string SQL_USERNAMEDY_SELECT = "SSO_TOKEN_USERNAMEDY_SELECT";
        const string SQL_USERNAMEDY_UPDATE = "SSO_TOKEN_USERNAMEDY_UPDATE";
        private const string secretKey = "Sonluk@19542014";
        public MES_RETURN INSERT(string TOKEN)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TOKEN",TOKEN)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SSO_TOKEN_TOKENIDINFO_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(string TOKENID,int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            if (string.IsNullOrEmpty(DESE.Decrypt(TOKENID, secretKey)))
            {
                rst.TYPE = "E";
                rst.MESSAGE = "TOKENID不正确！";
                return rst;
            }
            else
            {
                TOKENID = DESE.Decrypt(TOKENID, secretKey);
            }

            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@TOKENID",Convert.ToInt32(TOKENID)),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SSO_TOKEN_TOKENIDINFO_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN SELECT(string TOKENID)
        {
            MES_RETURN rst = new MES_RETURN();
            if (string.IsNullOrEmpty(DESE.Decrypt(TOKENID, secretKey)))
            {
                rst.TYPE = "E";
                rst.MESSAGE = "TOKENID不正确！";
                return rst;
            }
            else
            {
                TOKENID = DESE.Decrypt(TOKENID, secretKey);
            }
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@TOKENID",Convert.ToInt32(TOKENID))
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SSO_TOKEN_TOKENIDINFO_SELECT", "HR");
            }
            return rst;
        }
        public MES_RETURN USERNAMEDY_INSERT(SSO_TOKEN_USERNAMEDY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@ZHLB",model.ZHLB),
                                       new SqlParameter("@ZHUSERNAME",model.ZHUSERNAME),
                                       new SqlParameter("@ZHUSERID",model.ZHUSERID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_USERNAMEDY_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SSO_TOKEN_USERNAMEDY_INSERT", "SSO");
            }
            return rst;
        }
        public SSO_TOKEN_USERNAMEDY_SELECT USERNAMEDY_SELECT(SSO_TOKEN_USERNAMEDY model)
        {
            SSO_TOKEN_USERNAMEDY_SELECT rst = new SSO_TOKEN_USERNAMEDY_SELECT();
            List<SSO_TOKEN_USERNAMEDY> child_SSO_TOKEN_USERNAMEDY_LIST = new List<SSO_TOKEN_USERNAMEDY>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@ZHLB",model.ZHLB),
                                       new SqlParameter("@ZHUSERNAME",model.ZHUSERNAME),
                                       new SqlParameter("@ZHUSERID",model.ZHUSERID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_USERNAMEDY_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        SSO_TOKEN_USERNAMEDY child = new SSO_TOKEN_USERNAMEDY();
                        child.ZHID = Convert.ToInt32(sdr["ZHID"]);
                        child.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
                        child.ZHLB = Convert.ToInt32(sdr["ZHLB"]);
                        child.ZHUSERNAME = Convert.ToString(sdr["ZHUSERNAME"]);
                        child.ZHUSERID = Convert.ToInt32(sdr["ZHUSERID"]);
                        child_SSO_TOKEN_USERNAMEDY_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SSO_TOKEN_USERNAMEDY_SELECT", "SSO");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.SSO_TOKEN_USERNAMEDY = child_SSO_TOKEN_USERNAMEDY_LIST;
            return rst;
        }
        public MES_RETURN USERNAMEDY_UPDATE(SSO_TOKEN_USERNAMEDY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@ZHID",model.ZHID),
                                           new SqlParameter("@ZHUSERNAME",model.ZHUSERNAME),
                                           new SqlParameter("@UPDATELB",model.UPDATELB),
                                           new SqlParameter("@ZHUSERID",model.ZHUSERID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_USERNAMEDY_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SSO_TOKEN_USERNAMEDY_UPDATE", "SSO");
            }
            return rst;
        }
    }
}
