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
    public class COST_CXHD : ICOST_CXHD
    {

        private const string SQL_Create = "CRM_COST_CXHD_Create";
        private const string SQL_Update = "CRM_COST_CXHD_Update";
        private const string SQL_ReadByParam = "CRM_COST_CXHD_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CXHD_Delete";

        public int Create(CRM_COST_CXHD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@GSYEAR", model.GSYEAR),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@HDMC", model.HDMC),
                                        new SqlParameter("@HDBH", model.HDBH),
                                        new SqlParameter("@HDBEGINDATE", model.HDBEGINDATE),
                                        new SqlParameter("@HDENDDATE", model.HDENDDATE),
                                        new SqlParameter("@THBEGINDATE", model.THBEGINDATE),
                                        new SqlParameter("@THENDDATE", model.THENDDATE),
                                        new SqlParameter("@HDDX", model.HDDX),
                                        new SqlParameter("@HDMD", model.HDMD),
                                        new SqlParameter("@GSZCSM", model.GSZCSM),
                                        new SqlParameter("@CJHDWDSL", model.CJHDWDSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@PG", model.PG),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CXHD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@HDMC", model.HDMC),
                                        new SqlParameter("@HDBEGINDATE", model.HDBEGINDATE),
                                        new SqlParameter("@HDENDDATE", model.HDENDDATE),
                                        new SqlParameter("@THBEGINDATE", model.THBEGINDATE),
                                        new SqlParameter("@THENDDATE", model.THENDDATE),
                                        new SqlParameter("@HDDX", model.HDDX),
                                        new SqlParameter("@HDMD", model.HDMD),
                                        new SqlParameter("@GSZCSM", model.GSZCSM),
                                        new SqlParameter("@CJHDWDSL", model.CJHDWDSL),
                                        new SqlParameter("@YBAWDSL", model.YBAWDSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@PG", model.PG),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CXHD> ReadByParam(CRM_COST_CXHD model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@GSYEAR", model.GSYEAR),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@HDMC", model.HDMC),
                                        new SqlParameter("@HDBH", model.HDBH),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID", STAFFID)


                                   };
            IList<CRM_COST_CXHD> nodes = new List<CRM_COST_CXHD>();
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
        public int Delete(int CXHDID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", CXHDID)
                                       

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

        private CRM_COST_CXHD ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CXHD node = new CRM_COST_CXHD();
            node.CXHDID = Convert.ToInt32(sdr["CXHDID"]);
            node.GSYEAR = Convert.ToString(sdr["GSYEAR"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.HDMC = Convert.ToString(sdr["HDMC"]);
            node.HDBH = Convert.ToString(sdr["HDBH"]);
            node.HDBEGINDATE = Convert.ToString(sdr["HDBEGINDATE"]);
            node.HDENDDATE = Convert.ToString(sdr["HDENDDATE"]);
            node.THBEGINDATE = Convert.ToString(sdr["THBEGINDATE"]);
            node.THENDDATE = Convert.ToString(sdr["THENDDATE"]);
            node.HDDX = Convert.ToString(sdr["HDDX"]);
            node.HDMD = Convert.ToString(sdr["HDMD"]);
            node.GSZCSM = Convert.ToString(sdr["GSZCSM"]);
            node.CXHDFB = Convert.ToDecimal(sdr["CXHDFB"]);
            node.CJHDWDSL = Convert.ToInt32(sdr["CJHDWDSL"]);
            node.YBAWDSL = Convert.ToInt32(sdr["YBAWDSL"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.PG = Convert.ToString(sdr["PG"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

           
            return node;
        }






    }
}
