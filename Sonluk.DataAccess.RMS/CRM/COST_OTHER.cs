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
    public class COST_OTHER :ICOST_OTHER
    {
        private const string SQL_Create = "CRM_COST_OTHER_Create";
        private const string SQL_Update = "CRM_COST_OTHER_Update";
        private const string SQL_ReadByParam = "CRM_COST_OTHER_ReadByParam";
        private const string SQL_Delete = "CRM_COST_OTHER_Delete";
        private const string SQL_Read_Unconnected = "CRM_COST_OTHER_Read_Unconnected";

        public int Create(CRM_COST_OTHER model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@HTMONTH", model.HTMONTH),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@MDID", model.MDID),
                                        new SqlParameter("@CXYFYLX", model.CXYFYLX),
                                        new SqlParameter("@SQJE", model.SQJE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_OTHER model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@OTHERID", model.OTHERID),
                                        new SqlParameter("@CXYFYLX", model.CXYFYLX),
                                        new SqlParameter("@SQJE", model.SQJE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_OTHER> ReadByParam(CRM_COST_OTHER model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@OTHERID", model.OTHERID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@HTMONTH", model.HTMONTH),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@MDID", model.MDID),
                                        new SqlParameter("@MDMC", model.MDMC),
                                        new SqlParameter("@MDCRMID", model.MDCRMID),
                                        new SqlParameter("@STAFFID", STAFFID)

                                   };
            IList<CRM_COST_OTHER> nodes = new List<CRM_COST_OTHER>();
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

        public IList<CRM_COST_OTHER> Read_Unconnected(CRM_COST_OTHER model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@KHID", model.KHID)

                                   };
            IList<CRM_COST_OTHER> nodes = new List<CRM_COST_OTHER>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_Unconnected, parms))
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

        public int Delete(int OTHERID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@OTHERID", OTHERID)
                                       

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

        private CRM_COST_OTHER ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_OTHER node = new CRM_COST_OTHER();
            node.OTHERID = Convert.ToInt32(sdr["OTHERID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.HTMONTH = Convert.ToString(sdr["HTMONTH"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.MDID = Convert.ToInt32(sdr["MDID"]);
            node.CXYFYLX = Convert.ToInt32(sdr["CXYFYLX"]);
            node.SQJE = Convert.ToDecimal(sdr["SQJE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CXYFYLXDES = Convert.ToString(sdr["CXYFYLXDES"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            //node.MDMC = Convert.ToString(sdr["MDMC"]);
            //node.MDCRMID = Convert.ToString(sdr["MDCRMID"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            return node;
        }





    }
}
