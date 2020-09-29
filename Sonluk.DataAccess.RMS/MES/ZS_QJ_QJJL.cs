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
    public class ZS_QJ_QJJL : IZS_QJ_QJJL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_ZS_QJ_QJJL_INSERT";
        const string SQL_INSERT_QJSB = "MES_ZS_QJ_QJSB_INSERT";
        const string SQL_SELECT_QJSB = "MES_ZS_QJ_QJSB_SELECT";

        const string SQL_INSERT_ERRORJL = "MES_ZS_QJ_ERRORJL_INSERT";
        const string SQL_SELECT_ERRORJL = "MES_ZS_QJ_ERRORJL_SELECT";
        public MES_RETURN INSERT(MES_ZS_QJ_QJJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@CZRGH",model.CZRGH),
                                       new SqlParameter("@CZRNAME",model.CZRNAME),
                                       new SqlParameter("@QJJSBBH",model.QJJSBBH),
                                       new SqlParameter("@QJJSBMS",model.QJJSBMS),
                                       new SqlParameter("@CJR",model.CJR)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_QJ_QJJL_INSERT", "MES_ZS");
            }
            return rst;
        }
        public MES_RETURN INSERT_QJSB(MES_ZS_QJ_QJSB model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@ISFREE",model.ISFREE),
                                       new SqlParameter("@SCSMTM",model.SCSMTM),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@CZLB",model.CZLB),
                                       new SqlParameter("@QJZT",model.QJZT)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_QJSB, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_QJ_QJSB_INSERT", "MES_ZS");
            }
            return rst;
        }

        public MES_ZS_QJ_QJSB_SELECT SELECT_QJSB(MES_ZS_QJ_QJSB model)
        {
            MES_ZS_QJ_QJSB_SELECT rst = new MES_ZS_QJ_QJSB_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_ZS_QJ_QJSB> child_MES_ZS_QJ_QJSB = new List<MES_ZS_QJ_QJSB>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_QJSB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ZS_QJ_QJSB child = new MES_ZS_QJ_QJSB();
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.ISFREE = Convert.ToInt32(sdr["ISFREE"]);
                        child.SBMS = Convert.ToString(sdr["SBMS"]);
                        child.SBFLNAME = Convert.ToString(sdr["SBFLNAME"]);
                        if (child.ISFREE == 0)
                        {
                            child.SCSMTM = Convert.ToString(sdr["SCSMTM"]);
                            child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm");
                            child.MOULD = Convert.ToString(sdr["MOULD"]);
                            child.WLH = Convert.ToString(sdr["WLH"]);
                            child.WLMS = Convert.ToString(sdr["WLMS"]);
                            child.TMKSTIME = Convert.ToDateTime(sdr["TMKSTIME"]).ToString("yyyy-MM-dd HH:mm");
                            child.TMJSTIME = Convert.ToDateTime(sdr["TMJSTIME"]).ToString("yyyy-MM-dd HH:mm");
                            child.CZRGH = Convert.ToString(sdr["CZRGH"]);
                            child.CZRNAME = Convert.ToString(sdr["CZRNAME"]);
                            child.CZLB = Convert.ToInt32(sdr["CZLB"]);
                            child.QJZT = Convert.ToInt32(sdr["QJZT"]);
                        }
                        else
                        {
                            child.SCSMTM = "";
                            child.KSTIME = "";
                            child.MOULD = "";
                            child.WLH = "";
                            child.WLMS = "";
                            child.TMKSTIME = "";
                            child.TMJSTIME = "";
                            child.CZRGH = "";
                            child.CZRNAME = "";
                            child.CZLB = 0;
                            child.QJZT = 0;
                        }

                        child_MES_ZS_QJ_QJSB.Add(child);
                    }
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_QJ_QJSB_SELECT", "MES_ZS");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_ZS_QJ_QJSB = child_MES_ZS_QJ_QJSB;
            return rst;
        }

        public MES_RETURN INSERT_ERRORJL(MES_ZS_QJ_ERRORJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ERRORTM",model.ERRORTM),
                                       new SqlParameter("@ERRORSBBH",model.ERRORSBBH),
                                       new SqlParameter("@ERRORINFO",model.ERRORINFO),
                                       new SqlParameter("@CJR",model.CJR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_ERRORJL, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_QJ_ERRORJL_INSERT", "MES_ZS");
            }
            return rst;
        }
        public MES_ZS_QJ_ERRORJL_SELECT SELECT_ERRORJL(MES_ZS_QJ_ERRORJL model)
        {
            MES_ZS_QJ_ERRORJL_SELECT rst = new MES_ZS_QJ_ERRORJL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_ZS_QJ_ERRORJL> child_MES_ZS_QJ_ERRORJL = new List<MES_ZS_QJ_ERRORJL>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@KSTIME",model.KSTIME),
                                       new SqlParameter("@JSTIME",model.JSTIME),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ERRORJL, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ZS_QJ_ERRORJL child = new MES_ZS_QJ_ERRORJL();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.SBMS = Convert.ToString(sdr["SBMS"]);
                        child.ERRORTM = Convert.ToString(sdr["ERRORTM"]);
                        child.ERRORINFO = Convert.ToString(sdr["ERRORINFO"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.CZRGH = Convert.ToString(sdr["CZRGH"]);
                        child.CZRNAME = Convert.ToString(sdr["CZRNAME"]);
                        child_MES_ZS_QJ_ERRORJL.Add(child);
                    }
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_QJ_ERRORJL_SELECT", "MES_ZS");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_ZS_QJ_ERRORJL = child_MES_ZS_QJ_ERRORJL;
            return rst;
        }
    }
}
