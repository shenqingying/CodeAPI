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
    public class COST_KATSCLTT : ICOST_KATSCLTT
    {
        private const string SQL_Create = "CRM_COST_KATSCLTT_Create";
        private const string SQL_Update = "CRM_COST_KATSCLTT_Update";
        private const string SQL_ReadByParam = "CRM_COST_KATSCLTT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_KATSCLTT_Delete";
        private const string SQL_UpdateCost = "CRM_COST_KATSCLTT_UpdateCost";

        public int Create(CRM_COST_KATSCLTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@KHID", model.KHID),
                                        //new SqlParameter("@MDSL", model.MDSL),
                                        //new SqlParameter("@LJSQJE", model.LJSQJE),
                                        //new SqlParameter("@YHXNDJE", model.YHXNDJE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KATSCLTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KATSCLTTID", model.KATSCLTTID),
                                        new SqlParameter("@MDSL", model.MDSL),
                                        new SqlParameter("@LJSQJE", model.LJSQJE),
                                        new SqlParameter("@YHXNDJE", model.YHXNDJE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int UpdateCost(int KATSCLTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KATSCLTTID", KATSCLTTID)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateCost, parms);
        }

        public IList<CRM_COST_KATSCLTT> ReadByParam(CRM_COST_KATSCLTT model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KATSCLTTID", model.KATSCLTTID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@STAFFID", STAFFID),
                                        new SqlParameter("@CJSJ_BEGIN", model.CJSJ_BEGIN),
                                        new SqlParameter("@CJSJ_END", model.CJSJ_END),
                                        new SqlParameter("@FYHXQK", model.FYHXQK)

                                   };
            IList<CRM_COST_KATSCLTT> nodes = new List<CRM_COST_KATSCLTT>();
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
        public int Delete(int KATSCLTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KATSCLTTID", KATSCLTTID)
                                       

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

        private CRM_COST_KATSCLTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KATSCLTT node = new CRM_COST_KATSCLTT();
            node.KATSCLTTID = Convert.ToInt32(sdr["KATSCLTTID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.MDSL = Convert.ToInt32(sdr["MDSL"]);
            node.LJSQJE = Convert.ToDecimal(sdr["LJSQJE"]);
            node.YHXNDJE = Convert.ToDecimal(sdr["YHXNDJE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");


            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.MX_ISACTIVE = Convert.ToInt32(sdr["MX_ISACTIVE"]);


            node.YHXJE = Convert.ToDecimal(sdr["YHXJE"]);
            node.SJFY = Convert.ToDecimal(sdr["SJFY"]);



            return node;
        }





    }
}
