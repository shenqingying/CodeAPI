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
    public class SY_TPM_SYNC : ISY_TPM_SYNC
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        public const string SQL_TPM_SYNC_INSERT = "MES_SY_TPM_SYNC_INSERT";
        public const string SQL_TPM_SYNC_SELECT = "MES_SY_TPM_SYNC_SELECT";
        public const string SQL_TPM_SYNC_UPDATE = "MES_SY_TPM_SYNC_UPDATE";
        private const string SQL_SELECT_GD_SYNC = "MES_PD_GD_SYNC_SELECT";
        public MES_RETURN INSERT(MES_SY_TPM_SYNC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TPM",model.TPM),
                                       new SqlParameter("@MATNR",model.MATNR),
                                       new SqlParameter("@CHARG",model.CHARG),
                                       new SqlParameter("@WERKS",model.WERKS),
                                       new SqlParameter("@LGORT",model.LGORT),
                                       new SqlParameter("@LGPLA",model.LGPLA),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@YSSL",model.YSSL),
                                       new SqlParameter("@ZL",model.ZL),
                                       new SqlParameter("@CKDJH",model.CKDJH),
                                       new SqlParameter("@TMZT",model.TMZT),
                                       new SqlParameter("@SOBKZ",model.SOBKZ),
                                       new SqlParameter("@SONUM",model.SONUM),
                                       new SqlParameter("@CJTIME",model.CJTIME),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@XGTIME",model.XGTIME),
                                       new SqlParameter("@XGR",model.XGR)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_TPM_SYNC_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_TPM_SYNC_INSERT", "MES");
            }
            return rst;
        }
        public MES_SY_TPM_SYNC_SELECT SELECT(MES_SY_TPM_SYNC model)
        {
            MES_SY_TPM_SYNC_SELECT rst = new MES_SY_TPM_SYNC_SELECT();
            List<MES_SY_TPM_SYNC> child_MES_SY_TPM_SYNC = new List<MES_SY_TPM_SYNC>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TPM",model.TPM),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@KSTIME",model.KSTIME),
                                       new SqlParameter("@JSTIME",model.JSTIME),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@WLDL",model.WLDL),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@NOBILL",model.NOBILL),
                                       new SqlParameter("@NOBILLMX",model.NOBILLMX),
                                       new SqlParameter("@WLGROUP",model.WLGROUP)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_TPM_SYNC_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_TPM_SYNC child = new MES_SY_TPM_SYNC();
                        if (model.LB == 2)
                        {
                            child.WERKS = Convert.ToString(sdr["WERKS"]);
                            child.ARBPL = Convert.ToString(sdr["ARBPL"]);
                            child.LTXA1 = Convert.ToString(sdr["LTXA1"]);
                            child.TPM = Convert.ToString(sdr["TPM"]);
                            child.LGORT = Convert.ToString(sdr["LGORT"]);
                            child.LGPLA = Convert.ToString(sdr["LGPLA"]);
                            child.MATNR = Convert.ToString(sdr["MATNR"]);
                            child.MAKTX = Convert.ToString(sdr["MAKTX"]);
                            child.CHARG = Convert.ToString(sdr["CHARG"]);
                            child.KDAUF = Convert.ToString(sdr["KDAUF"]);
                            child.KDPOS = Convert.ToString(sdr["KDPOS"]);
                            child.AUFNR = Convert.ToString(sdr["AUFNR"]);
                            child_MES_SY_TPM_SYNC.Add(child);
                        }
                        else
                        {
                            child.TPM = Convert.ToString(sdr["TPM"]);
                            child.MATNR = Convert.ToString(sdr["MATNR"]);
                            child.CHARG = Convert.ToString(sdr["CHARG"]);
                            child.WERKS = Convert.ToString(sdr["WERKS"]);
                            child.LGORT = Convert.ToString(sdr["LGORT"]);
                            child.LGPLA = Convert.ToString(sdr["LGPLA"]);
                            child.SL = Convert.ToString(sdr["SL"]);
                            child.YSSL = Convert.ToString(sdr["YSSL"]);
                            child.ZL = Convert.ToString(sdr["ZL"]);
                            child.CKDJH = Convert.ToString(sdr["CKDJH"]);
                            child.TMZT = Convert.ToString(sdr["TMZT"]);
                            child.SOBKZ = Convert.ToString(sdr["SOBKZ"]);
                            child.SONUM = Convert.ToString(sdr["SONUM"]);
                            child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                            child.CJR = Convert.ToString(sdr["CJR"]);
                            child.XGTIME = Convert.ToString(sdr["XGTIME"]);
                            child.XGR = Convert.ToString(sdr["XGR"]);
                            child_MES_SY_TPM_SYNC.Add(child);
                        }
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_TPM_SYNC_SELECT", "MES");
            }
            rst.MES_SY_TPM_SYNC = child_MES_SY_TPM_SYNC;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE(MES_SY_TPM_SYNC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@TPM",model.TPM)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_TPM_SYNC_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_TPM_SYNC_UPDATE", "MES");
            }
            return rst;
        }
        public ZBCFUN_CPBZ_READ GET_CPBZ_READ_NEW1(string TPM)
        {
            ZBCFUN_CPBZ_READ rst = new ZBCFUN_CPBZ_READ();
            ZSL_BCS003 child_ES_HEADER = new ZSL_BCS003();
            List<ZSL_BCS302_B> child_ET_BOM = new List<ZSL_BCS302_B>();
            List<ZSL_BCST302_R> child_ET_RT = new List<ZSL_BCST302_R>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TPM",TPM),
                                       new SqlParameter("@LB",1)
                                   };

                DataTable dt1 = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_TPM_SYNC_SELECT, parms);
                if (dt1.Rows.Count == 0)
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "托盘码不存在！";
                    rst.MES_RETURN = child_MES_RETURN;
                    return rst;
                }
                SqlParameter[] parms1 = { 
                                           new SqlParameter("@LB",1),
                                           new SqlParameter("@WERKS",dt1.Rows[0]["WERKS"].ToString()),
                                           new SqlParameter("@AUFNR",dt1.Rows[0]["CKDJH"].ToString().TrimStart('0'))
                                   };
                DataTable dt2 = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_GD_SYNC, parms1);
                if (dt2.Rows.Count == 0)
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "订单不存在！";
                    rst.MES_RETURN = child_MES_RETURN;
                    return rst;
                }

                child_ES_HEADER.TPM = dt1.Rows[0]["TPM"].ToString();
                child_ES_HEADER.MATNR = dt1.Rows[0]["MATNR"].ToString().TrimStart('0');
                child_ES_HEADER.CHARG = dt1.Rows[0]["CHARG"].ToString();
                child_ES_HEADER.WERKS = dt1.Rows[0]["WERKS"].ToString();
                child_ES_HEADER.LGORT = dt1.Rows[0]["LGORT"].ToString();
                child_ES_HEADER.LGPLA = dt1.Rows[0]["LGPLA"].ToString();
                child_ES_HEADER.SL = dt1.Rows[0]["YSSL"].ToString();
                child_ES_HEADER.MEINS = "";
                child_ES_HEADER.ZL = dt1.Rows[0]["ZL"].ToString();
                child_ES_HEADER.ERFME = "";
                child_ES_HEADER.CKDJH = dt1.Rows[0]["CKDJH"].ToString().TrimStart('0');
                child_ES_HEADER.TMZT = dt1.Rows[0]["TMZT"].ToString();
                child_ES_HEADER.MVT_IND = "";
                child_ES_HEADER.MOVE_TYPE = "";
                child_ES_HEADER.FCODE = "";
                child_ES_HEADER.NLPLA = "";
                child_ES_HEADER.TANUM = "";
                child_ES_HEADER.WLM = "";
                child_ES_HEADER.SONUM = dt1.Rows[0]["SONUM"].ToString().TrimStart('0');
                child_ES_HEADER.SOBKZ = dt1.Rows[0]["SOBKZ"].ToString();
                child_ES_HEADER.BESTQ = "";
                child_ES_HEADER.USERNAME = "";
                child_ES_HEADER.LGNUM = "";
                child_ES_HEADER.JHZ = "";
                child_ES_HEADER.MAKTX = dt2.Rows[0]["MAKTX"].ToString();
                child_ES_HEADER.KDAUF = dt2.Rows[0]["KDAUF"].ToString();
                child_ES_HEADER.KDPOS = dt2.Rows[0]["KDPOS"].ToString().TrimStart('0');
                child_ES_HEADER.WLDL = dt2.Rows[0]["WLDL"].ToString();
                child_ES_HEADER.WLLB = Convert.ToInt32(dt2.Rows[0]["WLLB"].ToString());
                rst.ES_HEADER = child_ES_HEADER;

                SqlParameter[] parms2 = { 
                                           new SqlParameter("@LB",2),
                                           new SqlParameter("@WERKS",dt1.Rows[0]["WERKS"].ToString()),
                                           new SqlParameter("@AUFNR",dt1.Rows[0]["CKDJH"].ToString().TrimStart('0'))
                                   };
                DataTable dt3 = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_GD_SYNC, parms2);
                child_ET_BOM = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCS302_B>>(Newtonsoft.Json.JsonConvert.SerializeObject(dt3));
                rst.ET_BOM = child_ET_BOM;

                SqlParameter[] parms3 = { 
                                           new SqlParameter("@LB",3),
                                           new SqlParameter("@WERKS",dt1.Rows[0]["WERKS"].ToString()),
                                           new SqlParameter("@AUFNR",dt1.Rows[0]["CKDJH"].ToString().TrimStart('0'))
                                   };
                DataTable dt4 = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_GD_SYNC, parms3);
                child_ET_RT = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCST302_R>>(Newtonsoft.Json.JsonConvert.SerializeObject(dt4));
                rst.ET_RT = child_ET_RT;
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_TPM_SYNC_SELECT1", "MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;

        }
    }
}
