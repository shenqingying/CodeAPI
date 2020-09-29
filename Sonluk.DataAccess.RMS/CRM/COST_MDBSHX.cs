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
    public class COST_MDBSHX : ICOST_MDBSHX
    {
        private const string SQL_Create = "CRM_COST_MDBSHX_Create";
        private const string SQL_Update = "CRM_COST_MDBSHX_Update";
        private const string SQL_ReadByParam = "CRM_COST_MDBSHX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_MDBSHX_Delete";
        private const string SQL_Read_Unconnected = "CRM_COST_MDBSHX_Read_Unconnected";

        public int Create(CRM_COST_MDBSHX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MDBSID", model.MDBSID),
                                        new SqlParameter("@HXJE", model.HXJE),
                                        new SqlParameter("@FPHM", model.FPHM),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_MDBSHX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MDBSHXID", model.MDBSHXID),
                                        new SqlParameter("@HXJE", model.HXJE),
                                        new SqlParameter("@FPHM", model.FPHM),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_MDBSHX> ReadByParam(CRM_COST_MDBSHX model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MDBSHXID", model.MDBSHXID),
                                        new SqlParameter("@MDBSID", model.MDBSID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@HTMONTH", model.HTMONTH),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@FYLB", model.FYLB),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MDID", model.MDID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@MDMC", model.MDMC),
                                        new SqlParameter("@MDCRMID", model.MDCRMID),
                                        new SqlParameter("@STAFFID", STAFFID),
                                        new SqlParameter("@HXZT", model.HXZT)

                                   };
            IList<CRM_COST_MDBSHX> nodes = new List<CRM_COST_MDBSHX>();
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

        public IList<CRM_COST_MDBSHX> Read_Unconnected(CRM_COST_MDBSHX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR)

                                   };
            IList<CRM_COST_MDBSHX> nodes = new List<CRM_COST_MDBSHX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_Unconnected, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadUnconnectedDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int MDBSHXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MDBSHXID", MDBSHXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
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

        private CRM_COST_MDBSHX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_MDBSHX node = new CRM_COST_MDBSHX();
            node.MDBSHXID = Convert.ToInt32(sdr["MDBSHXID"]);
            node.MDBSID = Convert.ToInt32(sdr["MDBSID"]);
            node.HXJE = Convert.ToDecimal(sdr["HXJE"]);
            node.FPHM = Convert.ToString(sdr["FPHM"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.HTMONTH = Convert.ToString(sdr["HTMONTH"]);
            node.FYLB = Convert.ToInt32(sdr["FYLB"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.DISPLAYITEM = Convert.ToString(sdr["DISPLAYITEM"]);
            node.DISPLAYPOSITION = Convert.ToString(sdr["DISPLAYPOSITION"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.QSYJXS = Convert.ToDecimal(sdr["QSYJXS"]);
            node.HAVECXY = Convert.ToInt32(sdr["HAVECXY"]);
            node.PAYWAY = Convert.ToInt32(sdr["PAYWAY"]);
            node.HAVEDD = Convert.ToInt32(sdr["HAVEDD"]);
            node.SJXS = Convert.ToDecimal(sdr["SJXS"]);
            node.SJFY = Convert.ToDecimal(sdr["SJFY"]);
            node.SJFB = Convert.ToDecimal(sdr["SJFB"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.MDMC = Convert.ToString(sdr["MDMC"]);
            node.MDCRMID = Convert.ToString(sdr["MDCRMID"]);
            node.PAYWAYDES = Convert.ToString(sdr["PAYWAYDES"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);

            node.YHXJE = Convert.ToDecimal(sdr["YHXJE"]);
            node.HXZT = Convert.ToInt32(sdr["HXZT"]);
            return node;
        }

        private CRM_COST_MDBSHX ReadUnconnectedDataToObj(SqlDataReader sdr)
        {
            CRM_COST_MDBSHX node = new CRM_COST_MDBSHX();
            node.MDBSHXID = Convert.ToInt32(sdr["MDBSHXID"]);
            node.MDBSID = Convert.ToInt32(sdr["MDBSID"]);
            node.HXJE = Convert.ToDecimal(sdr["HXJE"]);
            node.FPHM = Convert.ToString(sdr["FPHM"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.HTMONTH = Convert.ToString(sdr["HTMONTH"]);
            node.FYLB = Convert.ToInt32(sdr["FYLB"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.DISPLAYITEM = Convert.ToString(sdr["DISPLAYITEM"]);
            node.DISPLAYPOSITION = Convert.ToString(sdr["DISPLAYPOSITION"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.QSYJXS = Convert.ToDecimal(sdr["QSYJXS"]);
            node.HAVECXY = Convert.ToInt32(sdr["HAVECXY"]);
            node.PAYWAY = Convert.ToInt32(sdr["PAYWAY"]);
            node.HAVEDD = Convert.ToInt32(sdr["HAVEDD"]);
            node.SJXS = Convert.ToDecimal(sdr["SJXS"]);
            node.SJFY = Convert.ToDecimal(sdr["SJFY"]);
            node.SJFB = Convert.ToDecimal(sdr["SJFB"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.MDMC = Convert.ToString(sdr["MDMC"]);
            node.MDCRMID = Convert.ToString(sdr["MDCRMID"]);
            node.PAYWAYDES = Convert.ToString(sdr["PAYWAYDES"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);

            node.FYCJRNAME = Convert.ToString(sdr["FYCJRNAME"]);
            node.FYXGRNAME = Convert.ToString(sdr["FYXGRNAME"]);

            return node;
        }





    }
}
