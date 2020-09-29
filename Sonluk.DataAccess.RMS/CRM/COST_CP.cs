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
    public class COST_CP : ICOST_CP
    {
        private const string SQL_Create = "CRM_COST_CP_Create";
        private const string SQL_Update = "CRM_COST_CP_Update";
        private const string SQL_ReadByParam = "CRM_COST_CP_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CP_Delete";
        private const string SQL_ReportYEARData = "CRM_COST_CP_ReportYEARData";
        private const string SQL_JXSReport = "CRM_COST_CP_JXSReport";

        public int Create(CRM_COST_CP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CPFL", model.CPFL),
                                        new SqlParameter("@MCSJGJ", model.MCSJGJ),
                                        new SqlParameter("@MCSJSJ", model.MCSJSJ),
                                        new SqlParameter("@LASTYEARSJXL", model.LASTYEARSJXL),
                                        new SqlParameter("@THISYEARSLYG", model.THISYEARSLYG),
                                        new SqlParameter("@LASTYEARXSSJ", model.LASTYEARXSSJ),
                                        new SqlParameter("@THISYEARXSYG", model.THISYEARXSYG),
                                        new SqlParameter("@CCJXS", model.CCJXS),
                                        new SqlParameter("@MLXJ", model.MLXJ),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CPID", model.CPID),
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CPFL", model.CPFL),
                                        new SqlParameter("@MCSJGJ", model.MCSJGJ),
                                        new SqlParameter("@MCSJSJ", model.MCSJSJ),
                                        new SqlParameter("@LASTYEARSJXL", model.LASTYEARSJXL),
                                        new SqlParameter("@THISYEARSLYG", model.THISYEARSLYG),
                                        new SqlParameter("@LASTYEARXSSJ", model.LASTYEARXSSJ),
                                        new SqlParameter("@THISYEARXSYG", model.THISYEARXSYG),
                                        new SqlParameter("@CCJXS", model.CCJXS),
                                        new SqlParameter("@MLXJ", model.MLXJ),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CP> ReadByParam(CRM_COST_CP model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CPID", model.CPID),
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            IList<CRM_COST_CP> nodes = new List<CRM_COST_CP>();
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

        public CRM_COST_CP_YEARDATA ReportYEARData(int LKAYEARTTID,int ISACTIVE)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", LKAYEARTTID),
                                        new SqlParameter("@ISACTIVE", ISACTIVE)
                                   };
            CRM_COST_CP_YEARDATA nodes = new CRM_COST_CP_YEARDATA();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReportYEARData, parms))
                {
                    if (sdr.Read())
                    {
                        nodes = ReadYEARDataToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_CP_JXSReport> JXSReport(CRM_COST_CP_JXSReport model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@JXSSAPSN", model.JXSSAPSN),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@SAPCP", model.SAPCP)
                                   };
            IList<CRM_COST_CP_JXSReport> nodes = new List<CRM_COST_CP_JXSReport>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_JXSReport, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadJXSDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }



        public int Delete(int CPID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CPID", CPID)
                                       

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

        private CRM_COST_CP ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CP node = new CRM_COST_CP();
            node.CPID = Convert.ToInt32(sdr["CPID"]);
            node.LKAYEARTTID = Convert.ToInt32(sdr["LKAYEARTTID"]);
            node.SAPCP = Convert.ToString(sdr["SAPCP"]);
            node.CPFL = Convert.ToString(sdr["CPFL"]);
            node.MCSJGJ = Convert.ToDouble(sdr["MCSJGJ"]);
            node.MCSJSJ = Convert.ToDouble(sdr["MCSJSJ"]);
            node.LASTYEARSJXL = Convert.ToInt32(sdr["LASTYEARSJXL"]);
            node.THISYEARSLYG = Convert.ToInt32(sdr["THISYEARSLYG"]);
            node.LASTYEARXSSJ = Convert.ToDouble(sdr["LASTYEARXSSJ"]);
            node.THISYEARXSYG = Convert.ToDouble(sdr["THISYEARXSYG"]);
            node.LASTYEARXSSJ_SJ = Convert.ToDecimal(sdr["LASTYEARXSSJ_SJ"]);
            node.THISYEARXSYG_SJ = Convert.ToDecimal(sdr["THISYEARXSYG_SJ"]);
            node.CCJXS = Convert.ToDouble(sdr["CCJXS"]);
            node.MLXJ = Convert.ToDouble(sdr["MLXJ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.BZNUM = Convert.ToInt32(sdr["BZNUM"]);
            node.PRICE_OUT = Convert.ToDouble(sdr["PRICE_OUT"]);
            node.PRICE_IN = Convert.ToDouble(sdr["PRICE_IN"]);
            node.PROFIT_OUT = Convert.ToDouble(sdr["PROFIT_OUT"]);
            node.PROFIT_IN = Convert.ToDouble(sdr["PROFIT_IN"]);
            return node;
        }

        private CRM_COST_CP_YEARDATA ReadYEARDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CP_YEARDATA node = new CRM_COST_CP_YEARDATA();
            node.A_XS = Convert.ToDouble(sdr["A_XS"]);
            node.A_ZB = Convert.ToDouble(sdr["A_ZB"]);
            node.B_XS = Convert.ToDouble(sdr["B_XS"]);
            node.B_ZB = Convert.ToDouble(sdr["B_ZB"]);
            node.C_XS = Convert.ToDouble(sdr["C_XS"]);
            node.C_ZB = Convert.ToDouble(sdr["C_ZB"]);
            node.MCXS_LS = Convert.ToDouble(sdr["MCXS_LS"]);
            node.MCXS_GJ = Convert.ToDouble(sdr["MCXS_GJ"]);
            node.MLXJ = Convert.ToDouble(sdr["MLXJ"]);
            node.MLL = Convert.ToDouble(sdr["MLL"]);
            node.GSSJLR = Convert.ToDouble(sdr["GSSJLR"]);
            node.CCJXS_HT = Convert.ToDouble(sdr["CCJXS_HT"]);
            node.CCJXS_GS = Convert.ToDouble(sdr["CCJXS_GS"]);
            node.GSZCFY_HT = Convert.ToDouble(sdr["GSZCFY_HT"]);
            node.GSZCFY_GS = Convert.ToDouble(sdr["GSZCFY_GS"]);
            node.CXZFY = Convert.ToDouble(sdr["CXZFY"]);
            return node;
        }

        private CRM_COST_CP_JXSReport ReadJXSDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CP_JXSReport node = new CRM_COST_CP_JXSReport();
            node.YWYNAME = Convert.ToString(sdr["YWYNAME"]);
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.SAPCP = Convert.ToString(sdr["SAPCP"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.CCJXS = Convert.ToString(sdr["CCJXS"]);
            node.THISYEARXLYG = Convert.ToString(sdr["THISYEARXLYG"]);
            
            return node;
        }


    }
}
