using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class SY_LANGUAGE_RETURN : ISY_LANGUAGE_RETURN
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_SY_LANGUAGE_RETURN_INSERT";
        const string SQL_SELECT = "MES_SY_LANGUAGE_RETURN_SELECT";
        const string SQL_UPDATE = "MES_SY_LANGUAGE_RETURN_UPDATE";
        const string SQL_RETURNMX_INSERT = "MES_SY_LANGUAGE_RETURNMX_INSERT";
        const string SQL_RETURNMX_SELECT = "MES_SY_LANGUAGE_RETURNMX_SELECT";
        const string SQL_RETURNMX_UPDATE = "MES_SY_LANGUAGE_RETURNMX_UPDATE";
        public MES_RETURN INSERT(MES_SY_LANGUAGE_RETURN model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MSGNO",model.MSGNO),
                                       new SqlParameter("@MSGNAME",model.MSGNAME),
                                       new SqlParameter("@MSGREMARK",model.MSGREMARK),
                                       new SqlParameter("@CJRID",model.CJRID),
                                       new SqlParameter("@MSGTYPE",model.MSGTYPE)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_LANGUAGE_RETURN_INSERT", "MES");
            }
            return rst;
        }
        public MES_RETURN UPDATE(MES_SY_LANGUAGE_RETURN model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MSGID",model.MSGID),
                                       new SqlParameter("@MSGNAME",model.MSGNAME),
                                       new SqlParameter("@MSGREMARK",model.MSGREMARK),
                                       new SqlParameter("@XGRID",model.XGRID),
                                       new SqlParameter("@MSGTYPE",model.MSGTYPE),
                                       new SqlParameter("@LB",model.LB)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_LANGUAGE_RETURN_INSERT", "MES");
            }
            return rst;
        }
        public MES_SY_LANGUAGE_RETURN_SELECT SELECT(MES_SY_LANGUAGE_RETURN model)
        {
            MES_SY_LANGUAGE_RETURN_SELECT rst = new MES_SY_LANGUAGE_RETURN_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_LANGUAGE_RETURN> child_MES_SY_LANGUAGE_RETURN = new List<MES_SY_LANGUAGE_RETURN>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@MSGNO",model.MSGNO),
                                       new SqlParameter("@MSGNAME",model.MSGNAME)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_LANGUAGE_RETURN child = new MES_SY_LANGUAGE_RETURN();
                        child.MSGID = Convert.ToInt32(sdr["MSGID"]);
                        child.MSGNO = Convert.ToString(sdr["MSGNO"]);
                        child.MSGNAME = Convert.ToString(sdr["MSGNAME"]);
                        child.MSGREMARK = Convert.ToString(sdr["MSGREMARK"]);
                        child.MSGTYPE = Convert.ToInt32(sdr["MSGTYPE"]);
                        child.MSGTYPENAME = Convert.ToString(sdr["MSGTYPENAME"]);
                        child_MES_SY_LANGUAGE_RETURN.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_LANGUAGE_RETURN_SELECT", "MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_LANGUAGE_RETURN = child_MES_SY_LANGUAGE_RETURN;
            return rst;
        }
        public MES_RETURN RETURNMX_INSERT(MES_SY_LANGUAGE_RETURNMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MSGID",model.MSGID),
                                       new SqlParameter("@SYLANGUAGEID",model.SYLANGUAGEID),
                                       new SqlParameter("@MSGMXTEXT",model.MSGMXTEXT),
                                       new SqlParameter("@CJRID",model.CJRID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_RETURNMX_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_LANGUAGE_RETURNMX_INSERT", "MES");
            }
            return rst;
        }
        public MES_SY_LANGUAGE_RETURNMX_SELECT RETURNMX_SELECT(MES_SY_LANGUAGE_RETURNMX model)
        {
            MES_SY_LANGUAGE_RETURNMX_SELECT rst = new MES_SY_LANGUAGE_RETURNMX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_LANGUAGE_RETURNMX> child_MES_SY_LANGUAGE_RETURNMX = new List<MES_SY_LANGUAGE_RETURNMX>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@MSGID",model.MSGID),
                                       new SqlParameter("@MSGNAME",model.MSGNAME),
                                       new SqlParameter("@MSGNO",model.MSGNO),
                                       new SqlParameter("@SYLANGUAGEID",model.SYLANGUAGEID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_RETURNMX_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_LANGUAGE_RETURNMX child = new MES_SY_LANGUAGE_RETURNMX();
                        child.MSGMXID = Convert.ToInt32(sdr["MSGMXID"]);
                        child.MSGMXTEXT = Convert.ToString(sdr["MSGMXTEXT"]);
                        child.SYLANGUAGEID = Convert.ToInt32(sdr["SYLANGUAGEID"]);
                        child_MES_SY_LANGUAGE_RETURNMX.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_LANGUAGE_RETURNMX_SELECT", "MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_LANGUAGE_RETURNMX = child_MES_SY_LANGUAGE_RETURNMX;
            return rst;
        }
        public MES_RETURN RETURNMX_UPDATE(MES_SY_LANGUAGE_RETURNMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@MSGMXID",model.MSGMXID),
                                       new SqlParameter("@MSGMXTEXT",model.MSGMXTEXT),
                                       new SqlParameter("@XGRID",model.XGRID),
                                       new SqlParameter("@SYLANGUAGEID",model.SYLANGUAGEID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_RETURNMX_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_LANGUAGE_RETURNMX_UPDATE", "MES");
            }
            return rst;
        }
    }
}
