using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class COST_KAHXZLMX : ICOST_KAHXZLMX
    {
        private const string SQL_Create = "CRM_COST_KAHXZLMX_Create";
        private const string SQL_Update = "CRM_COST_KAHXZLMX_Update";
        private const string SQL_UpdateByKADTTTID = "CRM_COST_KAHXZLMX_UpdateByKADTTTID";
        private const string SQL_ReadByParam = "CRM_COST_KAHXZLMX_ReadByParam";
        private const string SQL_ReadByTTID = "CRM_COST_KAHXZLMX_ReadByTTID";
        private const string SQL_Delete = "CRM_COST_KAHXZLMX_Delete";
        private const string SQL_DeleteByKADTTTID = "CRM_COST_KAHXZLMX_DeleteByKADTTTID";
        private const string SQL_Read_Unconnected = "CRM_COST_KAHXZLMX_Read_Unconnected";

        public int Create(CRM_COST_KAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", model.HXZLTTID),
                                        new SqlParameter("@KADTTTID", model.KADTTTID),
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@SQJE", model.SQJE),
                                        new SqlParameter("@SQZJE", model.SQZJE),
                                        new SqlParameter("@FYHXYHCNR", model.FYHXYHCNR),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFY", model.SJFY),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@HDJSZJ", model.HDJSZJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID),
                                        new SqlParameter("@FYHXYHCNR", model.FYHXYHCNR),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFY", model.SJFY),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@HDJSZJ", model.HDJSZJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@SHR", model.SHR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int UpdateByKADTTTID(CRM_COST_KAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KADTTTID", model.KADTTTID),
                                        new SqlParameter("@FYHXYHCNR", model.FYHXYHCNR),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFY", model.SJFY),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@HDJSZJ", model.HDJSZJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@SHR", model.SHR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateByKADTTTID, parms);
        }

        public IList<CRM_COST_KAHXZLMX> ReadByParam(CRM_COST_KAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID),
                                        new SqlParameter("@HXZLTTID", model.HXZLTTID),
                                        new SqlParameter("@KADTTTID", model.KADTTTID),
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@COSTITEMIDSTR", model.COSTITEMIDSTR)

                                   };
            IList<CRM_COST_KAHXZLMX> nodes = new List<CRM_COST_KAHXZLMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_KAHXZLMX> ReadByTTID(int HXZLTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", HXZLTTID)

                                   };
            IList<CRM_COST_KAHXZLMX> nodes = new List<CRM_COST_KAHXZLMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByTTID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj2(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_KAHXZLMX> Read_Unconnected(CRM_COST_KAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@TT_KHID", model.TT_KHID),
                                        new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR)

                                   };
            IList<CRM_COST_KAHXZLMX> nodes = new List<CRM_COST_KAHXZLMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_Unconnected, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadUnConnDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int HXZLMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMXID", HXZLMXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }
        public int DeleteByKADTTTID(int KADTTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KADTTTID", KADTTTID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByKADTTTID, parms);
        }


        private int Binning(CommandType type, string sql, SqlParameter[] parms)
        {
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(type, sql, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["ID"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return ID;
        }

        private CRM_COST_KAHXZLMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAHXZLMX node = new CRM_COST_KAHXZLMX();
            node.HXZLMXID = Convert.ToInt32(sdr["HXZLMXID"]);
            node.HXZLTTID = Convert.ToInt32(sdr["HXZLTTID"]);
            node.KADTTTID = Convert.ToInt32(sdr["KADTTTID"]);
            node.COSTID = Convert.ToInt32(sdr["COSTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.SQJE = Convert.ToDecimal(sdr["SQJE"]);
            node.SQZJE = Convert.ToDecimal(sdr["SQZJE"]);
            node.FYHXYHCNR = Convert.ToString(sdr["FYHXYHCNR"]);
            node.SJXS = Convert.ToDecimal(sdr["SJXS"]);
            node.SJFY = Convert.ToDecimal(sdr["SJFY"]);
            node.SJFB = Convert.ToDecimal(sdr["SJFB"]);
            node.HDJSZJ = Convert.ToString(sdr["HDJSZJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SHR = Convert.ToInt32(sdr["SHR"]);
            node.SHSJ = Convert.ToDateTime(sdr["SHSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.SHRNAME = Convert.ToString(sdr["SHRNAME"]);

            if (node.COSTITEMID == 51 || node.COSTITEMID == 52 || node.COSTITEMID == 55 || node.COSTITEMID == 60 || node.COSTITEMID == 53)
            {
                if(node.COSTITEMID == 51 || node.COSTITEMID == 52 || node.COSTITEMID == 55)
                {
                    //海报、堆头、活动补差
                    node.CJHDMDSL = Convert.ToInt32(sdr["CJHDMDSL"]);
                    node.BEGINDATE = Convert.ToString(sdr["HDBEGINDATE"]);
                    node.ENDDATE = Convert.ToString(sdr["HDENDDATE"]);
                    node.FHDATE = Convert.ToString(sdr["FHDATE"]);
                    node.YJXS = Convert.ToDecimal(sdr["YJHDQJXS"]);
                    node.RCYJXS = Convert.ToDecimal(sdr["RCYJXS"]);
                    node.DQ = Convert.ToString(sdr["DQ"]);
                    node.CXJB = Convert.ToString(sdr["CXJB"]);
                    node.HDFASM = Convert.ToString(sdr["HDFASM"]);
                    node.YJFB = Convert.ToDecimal(sdr["YJFB"]);
                    node.CXLXDES = Convert.ToString(sdr["CXLXDES"]);

                }
                else if(node.COSTITEMID == 60)
                {
                    //特殊陈列
                    node.MDID = Convert.ToInt32(sdr["KHID"]);
                    node.MDMC = Convert.ToString(sdr["MC"]);
                    node.MDCRMID = Convert.ToString(sdr["CRMID"]);
                    node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
                    node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
                    node.CLFSDES = Convert.ToString(sdr["CLFSDES"]);
                    node.YJXS = Convert.ToDecimal(sdr["YJXS"]);
                    node.RCYJXS = Convert.ToDecimal(sdr["RCYJXS"]);
                    node.YJFB = Convert.ToDecimal(sdr["YJFB"]);

                }
                else if(node.COSTITEMID == 53)
                {
                    //制作费
                    node.ZZLXDES = Convert.ToString(sdr["ZZLXDES"]);
                    node.MDMC = Convert.ToString(sdr["MDMC"]);
                    node.MDCRMID = Convert.ToString(sdr["MDCRMID"]);

                }
            }



            return node;
        }

        private CRM_COST_KAHXZLMX ReadDataToObj2(SqlDataReader sdr)
        {
            CRM_COST_KAHXZLMX node = new CRM_COST_KAHXZLMX();
            node.HXZLMXID = Convert.ToInt32(sdr["HXZLMXID"]);
            node.HXZLTTID = Convert.ToInt32(sdr["HXZLTTID"]);
            node.KADTTTID = Convert.ToInt32(sdr["KADTTTID"]);
            node.COSTID = Convert.ToInt32(sdr["COSTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.SQJE = Convert.ToDecimal(sdr["SQJE"]);
            node.SQZJE = Convert.ToDecimal(sdr["SQZJE"]);
            node.FYHXYHCNR = Convert.ToString(sdr["FYHXYHCNR"]);
            node.SJXS = Convert.ToDecimal(sdr["SJXS"]);
            node.SJFY = Convert.ToDecimal(sdr["SJFY"]);
            node.SJFB = Convert.ToDecimal(sdr["SJFB"]);
            node.HDJSZJ = Convert.ToString(sdr["HDJSZJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SHR = Convert.ToInt32(sdr["SHR"]);
            node.SHSJ = Convert.ToDateTime(sdr["SHSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.SHRNAME = Convert.ToString(sdr["SHRNAME"]);

            



            return node;
        }

        private CRM_COST_KAHXZLMX ReadUnConnDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAHXZLMX node = new CRM_COST_KAHXZLMX();
            node.HXZLMXID = Convert.ToInt32(sdr["HXZLMXID"]);
            node.HXZLTTID = Convert.ToInt32(sdr["HXZLTTID"]);
            node.KADTTTID = Convert.ToInt32(sdr["KADTTTID"]);
            node.COSTID = Convert.ToInt32(sdr["COSTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.SQJE = Convert.ToDecimal(sdr["SQJE"]);
            node.SQZJE = Convert.ToDecimal(sdr["SQZJE"]);
            node.FYHXYHCNR = Convert.ToString(sdr["FYHXYHCNR"]);
            node.SJXS = Convert.ToDecimal(sdr["SJXS"]);
            node.SJFY = Convert.ToDecimal(sdr["SJFY"]);
            node.SJFB = Convert.ToDecimal(sdr["SJFB"]);
            node.HDJSZJ = Convert.ToString(sdr["HDJSZJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SHR = Convert.ToInt32(sdr["SHR"]);
            node.SHSJ = Convert.ToDateTime(sdr["SHSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.SHRNAME = Convert.ToString(sdr["SHRNAME"]);

            node.YHXJE = Convert.ToDecimal(sdr["YHXJE"]);




            return node;
        }





    }
}
