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
    public class COST_MDBS : ICOST_MDBS
    {
        private const string SQL_Create = "CRM_COST_MDBS_Create";
        private const string SQL_Update = "CRM_COST_MDBS_Update";
        private const string SQL_ReadByParam = "CRM_COST_MDBS_ReadByParam";
        private const string SQL_Delete = "CRM_COST_MDBS_Delete";
        private const string SQL_Read_Unconnected = "CRM_COST_MDBS_Read_Unconnected";

        public int Create(CRM_COST_MDBS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@HTMONTH", model.HTMONTH),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@FYLB", model.FYLB),
                                        new SqlParameter("@MDID", model.MDID),
                                        new SqlParameter("@DISPLAYITEM", model.DISPLAYITEM),
                                        new SqlParameter("@DISPLAYPOSITION", model.DISPLAYPOSITION),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@QSYJXS", model.QSYJXS),
                                        new SqlParameter("@YJFY", model.YJFY),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@YJFB", model.YJFB),
                                        new SqlParameter("@HAVECXY", model.HAVECXY),
                                        new SqlParameter("@PAYWAY", model.PAYWAY),
                                        new SqlParameter("@HAVEDD", model.HAVEDD),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFY", model.SJFY),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@BEIZ2", model.BEIZ2),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_MDBS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MDBSID", model.MDBSID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@DISPLAYITEM", model.DISPLAYITEM),
                                        new SqlParameter("@DISPLAYPOSITION", model.DISPLAYPOSITION),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@QSYJXS", model.QSYJXS),
                                        new SqlParameter("@YJFY", model.YJFY),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@YJFB", model.YJFB),
                                        new SqlParameter("@HAVECXY", model.HAVECXY),
                                        new SqlParameter("@PAYWAY", model.PAYWAY),
                                        new SqlParameter("@HAVEDD", model.HAVEDD),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFY", model.SJFY),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@BEIZ2", model.BEIZ2),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_MDBS> ReadByParam(CRM_COST_MDBS model, int STAFFID)
        {
            SqlParameter[] parms = {
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
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@CJRNAME", model.CJRNAME),
                                        new SqlParameter("@STAFFID", STAFFID),
                                        new SqlParameter("@FYHXQK", model.FYHXQK)

                                   };
            IList<CRM_COST_MDBS> nodes = new List<CRM_COST_MDBS>();
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

        public IList<CRM_COST_MDBS> Read_Unconnected(CRM_COST_MDBS model, int STAFFID)
        {
            SqlParameter[] parms = {
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
                                        new SqlParameter("@STAFFID", STAFFID)

                                   };
            IList<CRM_COST_MDBS> nodes = new List<CRM_COST_MDBS>();
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

        public int Delete(int MDBSID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MDBSID", MDBSID)
                                       

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

        private CRM_COST_MDBS ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_MDBS node = new CRM_COST_MDBS();
            node.MDBSID = Convert.ToInt32(sdr["MDBSID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.HTMONTH = Convert.ToString(sdr["HTMONTH"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.FYLB = Convert.ToInt32(sdr["FYLB"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.MDID = Convert.ToInt32(sdr["MDID"]);
            node.DISPLAYITEM = Convert.ToString(sdr["DISPLAYITEM"]);
            node.DISPLAYPOSITION = Convert.ToString(sdr["DISPLAYPOSITION"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.QSYJXS = Convert.ToDecimal(sdr["QSYJXS"]);
            node.YJFY = Convert.ToDecimal(sdr["YJFY"]);
            node.YJXS = Convert.ToDecimal(sdr["YJXS"]);
            node.YJFB = Convert.ToDecimal(sdr["YJFB"]);
            node.HAVECXY = Convert.ToInt32(sdr["HAVECXY"]);
            node.PAYWAY = Convert.ToInt32(sdr["PAYWAY"]);
            node.HAVEDD = Convert.ToInt32(sdr["HAVEDD"]);
            node.SJXS = Convert.ToDecimal(sdr["SJXS"]);
            node.SJFY = Convert.ToDecimal(sdr["SJFY"]);
            node.SJFB = Convert.ToDecimal(sdr["SJFB"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.BEIZ2 = Convert.ToString(sdr["BEIZ2"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");


            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.MDMC = Convert.ToString(sdr["MDMC"]);
            node.MDCRMID = Convert.ToString(sdr["MDCRMID"]);
            //node.DISPLAYITEMDES = Convert.ToString(sdr["DISPLAYITEMDES"]);
            //node.DISPLAYPOSITIONDES = Convert.ToString(sdr["DISPLAYPOSITIONDES"]);
            node.PAYWAYDES = Convert.ToString(sdr["PAYWAYDES"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.HAVECXYDES = Convert.ToString(sdr["HAVECXYDES"]);
            node.FYHXJE = Convert.ToDecimal(sdr["FYHXJE"]);

            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            return node;
        }


        private CRM_COST_MDBS ReadUnconnectedDataToObj(SqlDataReader sdr)
        {
            CRM_COST_MDBS node = new CRM_COST_MDBS();
            node.MDBSID = Convert.ToInt32(sdr["MDBSID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.HTMONTH = Convert.ToString(sdr["HTMONTH"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.FYLB = Convert.ToInt32(sdr["FYLB"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.MDID = Convert.ToInt32(sdr["MDID"]);
            node.DISPLAYITEM = Convert.ToString(sdr["DISPLAYITEM"]);
            node.DISPLAYPOSITION = Convert.ToString(sdr["DISPLAYPOSITION"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.QSYJXS = Convert.ToDecimal(sdr["QSYJXS"]);
            node.YJFY = Convert.ToDecimal(sdr["YJFY"]);
            node.YJXS = Convert.ToDecimal(sdr["YJXS"]);
            node.YJFB = Convert.ToDecimal(sdr["YJFB"]);
            node.HAVECXY = Convert.ToInt32(sdr["HAVECXY"]);
            node.PAYWAY = Convert.ToInt32(sdr["PAYWAY"]);
            node.HAVEDD = Convert.ToInt32(sdr["HAVEDD"]);
            node.SJXS = Convert.ToDecimal(sdr["SJXS"]);
            node.SJFY = Convert.ToDecimal(sdr["SJFY"]);
            node.SJFB = Convert.ToDecimal(sdr["SJFB"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.BEIZ2 = Convert.ToString(sdr["BEIZ2"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");


            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.MDMC = Convert.ToString(sdr["MDMC"]);
            node.MDCRMID = Convert.ToString(sdr["MDCRMID"]);
            node.PAYWAYDES = Convert.ToString(sdr["PAYWAYDES"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.HAVECXYDES = Convert.ToString(sdr["HAVECXYDES"]);

            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            node.YHXJE = Convert.ToDecimal(sdr["YHXJE"]);
            return node;
        }




    }
}
