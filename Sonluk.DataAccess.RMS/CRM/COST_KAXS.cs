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
    public class COST_KAXS : ICOST_KAXS
    {
        private const string SQL_Create = "CRM_COST_KAXS_Create";
        private const string SQL_Update = "CRM_COST_KAXS_Update";
        private const string SQL_ReadByParam = "CRM_COST_KAXS_ReadByParam";
        private const string SQL_Delete = "CRM_COST_KAXS_Delete";
        private const string SQL_Report = "CRM_COST_KAXS_Report";  //   KA销售报表
        private const string SQL_Report_KP = "CRM_COST_KAXS_Report_KP";
        private const string SQL_Report_FH = "CRM_COST_KAXS_Report_FH";
        private const string SQL_Report_MX = "CRM_COST_KAXS_Report_MX";
        private const string SQL_Report_MXFH = "CRM_COST_KAXS_Report_MXFH";
        private const string SQL_Report_Compare = "CRM_COST_KAXS_Report_Compare";

        public int Create(CRM_COST_KAXS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@XSLX", model.XSLX),
                                        new SqlParameter("@SJLX", model.SJLX),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@KAYEAR", model.KAYEAR),
                                        new SqlParameter("@KAMONTH", model.KAMONTH),
                                        new SqlParameter("@JXXS", model.JXXS),
                                        new SqlParameter("@TXXS", model.TXXS),
                                        new SqlParameter("@HJXS", model.HJXS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                       
                                    
                                      
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KAXS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@XSLX", model.XSLX),
                                        new SqlParameter("@SJLX", model.SJLX),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@KAYEAR", model.KAYEAR),
                                        new SqlParameter("@KAMONTH", model.KAMONTH),
                                        new SqlParameter("@JXXS", model.JXXS),
                                        new SqlParameter("@TXXS", model.TXXS),
                                        new SqlParameter("@HJXS", model.HJXS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@KAXSID", model.KAXSID)
                                        
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_KAXS> ReadByParam(CRM_COST_KAXS model)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@KAXSID", model.KAXSID),
                                        new SqlParameter("@XSLX", model.XSLX),
                                        new SqlParameter("@SJLX", model.SJLX),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@TIME_BEGIN", model.TIME_BEGIN),
                                        new SqlParameter("@TIME_END", model.TIME_END),
                                        new SqlParameter("@KAYEAR", model.KAYEAR),
                                        new SqlParameter("@KAMONTH", model.KAMONTH),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@PKHID", model.PKHID),
                                        new SqlParameter("@CRMID", model.CRMID)
                                   };
            IList<CRM_COST_KAXS> nodes = new List<CRM_COST_KAXS>();
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
        public IList<CRM_COST_KAXS> Report(CRM_COST_KAXS model)
        {
            SqlParameter[] parms = { 
                                        new SqlParameter("@SJLX", model.SJLX),
                                        new SqlParameter("@GMEMO", model.GMEMO),
                                        new SqlParameter("@KAYEAR", model.KAYEAR),
                                        new SqlParameter("@GNAME", model.GNAME)
                                   };
            IList<CRM_COST_KAXS> nodes = new List<CRM_COST_KAXS>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report, parms))
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

        public IList<CRM_COST_KAXSReportKP> Report_KP(CRM_COST_KAXSReportKP model)
        {
            SqlParameter[] parms = { 
                                        new SqlParameter("@GMEMO", model.GMEMO),
                                        new SqlParameter("@YEAR", model.YEAR),
                                        new SqlParameter("@SJLX", model.SJLX),
                                        new SqlParameter("@GNAME", model.GNAME)
                                   };
            IList<CRM_COST_KAXSReportKP> nodes = new List<CRM_COST_KAXSReportKP>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_KP, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadKPDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_COST_KAXSReportFH> Report_FH(CRM_COST_KAXSReportFH model)
        {
            SqlParameter[] parms = { 
                                        new SqlParameter("@GMEMO", model.GMEMO),
                                        new SqlParameter("@YEAR", model.YEAR),
                                        new SqlParameter("@SJLX", model.SJLX),
                                        new SqlParameter("@GNAME", model.GNAME)
                                   };
            IList<CRM_COST_KAXSReportFH> nodes = new List<CRM_COST_KAXSReportFH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_FH, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadFHDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_COST_KAXSReportMX> Report_MX(CRM_COST_KAXSReportMX model)
        {
            SqlParameter[] parms = { 
                                      
                                        new SqlParameter("@KAYEAR", model.KAYEAR),
                                        new SqlParameter("@SJLX", model.SJLX),
                                        new SqlParameter("@MC", model.MC),
                                    
                                   };
            IList<CRM_COST_KAXSReportMX> nodes = new List<CRM_COST_KAXSReportMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_MX, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadMXDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_COST_KAXS_Report_MXFH> Report_MXFH(CRM_COST_KAXS_Report_MXFH model)
        {
            SqlParameter[] parms = { 
                                      
                                        new SqlParameter("@KAYEAR", model.KAYEAR),
                                        new SqlParameter("@SJLX", model.SJLX),
                                         new SqlParameter("@MC", model.MC),
                                    
                                   };
            IList<CRM_COST_KAXS_Report_MXFH> nodes = new List<CRM_COST_KAXS_Report_MXFH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_MXFH, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadMXFHDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_COST_KAXSReport_Compare> Report_Compare(CRM_COST_KAXSReport_Compare model)
        {
            SqlParameter[] parms = { 
                                      
                                        new SqlParameter("@SJLX", model.SJLX),
                                        new SqlParameter("@XSLX", model.XSLX),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@GMEMO", model.GMEMO),
                                    
                                   };
            IList<CRM_COST_KAXSReport_Compare> nodes = new List<CRM_COST_KAXSReport_Compare>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_Compare, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadCompareDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int Delete(int KAXSID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KAXSID", KAXSID)
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


        private CRM_COST_KAXS ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAXS node = new CRM_COST_KAXS();
            node.KAXSID = Convert.ToInt32(sdr["KAXSID"]);
            node.XSLX = Convert.ToInt32(sdr["XSLX"]);
            node.SJLX = Convert.ToInt32(sdr["SJLX"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.KAYEAR = Convert.ToString(sdr["KAYEAR"]);
            node.KAMONTH = Convert.ToString(sdr["KAMONTH"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.JXXS = Convert.ToDouble(sdr["JXXS"]);
            node.TXXS = Convert.ToDouble(sdr["TXXS"]);
            node.HJXS = Convert.ToDouble(sdr["HJXS"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.XSLXDES = Convert.ToString(sdr["XSLXDES"]);
            node.SJLXDES = Convert.ToString(sdr["SJLXDES"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            return node;
        }
        private CRM_COST_KAXS ReadDataToObj2(SqlDataReader sdr)
        {
            CRM_COST_KAXS node = new CRM_COST_KAXS();

            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.POSHJ1 = Convert.ToDouble(sdr["POSHJ1"]);
            node.POSHJ2 = Convert.ToDouble(sdr["POSHJ2"]);
            node.POSHJ3 = Convert.ToDouble(sdr["POSHJ3"]);
            node.POSHJ4 = Convert.ToDouble(sdr["POSHJ4"]);
            node.POSHJ5 = Convert.ToDouble(sdr["POSHJ5"]);
            node.POSHJ6 = Convert.ToDouble(sdr["POSHJ6"]);
            node.POSHJ7 = Convert.ToDouble(sdr["POSHJ7"]);
            node.POSHJ8 = Convert.ToDouble(sdr["POSHJ8"]);
            node.POSHJ9 = Convert.ToDouble(sdr["POSHJ9"]);
            node.POSHJ10 = Convert.ToDouble(sdr["POSHJ10"]);
            node.POSHJ11 = Convert.ToDouble(sdr["POSHJ11"]);
            node.POSHJ12 = Convert.ToDouble(sdr["POSHJ12"]);
            node.POSHJ13 = Convert.ToDouble(sdr["POSHJ13"]);

            return node;
        }

        private CRM_COST_KAXSReportKP ReadKPDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAXSReportKP node = new CRM_COST_KAXSReportKP();
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.KP1 = Convert.ToString(sdr["KP1"]);
            node.ZK1 = Convert.ToString(sdr["ZK1"]);
            node.HJ1 = Convert.ToString(sdr["HJ1"]);
            node.KP2 = Convert.ToString(sdr["KP2"]);
            node.ZK2 = Convert.ToString(sdr["ZK2"]);
            node.HJ2 = Convert.ToString(sdr["HJ2"]);
            node.KP3 = Convert.ToString(sdr["KP3"]);
            node.ZK3 = Convert.ToString(sdr["ZK3"]);
            node.HJ3 = Convert.ToString(sdr["HJ3"]);
            node.KP4 = Convert.ToString(sdr["KP4"]);
            node.ZK4 = Convert.ToString(sdr["ZK4"]);
            node.HJ4 = Convert.ToString(sdr["HJ4"]);
            node.KP5 = Convert.ToString(sdr["KP5"]);
            node.ZK5 = Convert.ToString(sdr["ZK5"]);
            node.HJ5 = Convert.ToString(sdr["HJ5"]);
            node.KP6 = Convert.ToString(sdr["KP6"]);
            node.ZK6 = Convert.ToString(sdr["ZK6"]);
            node.HJ6 = Convert.ToString(sdr["HJ6"]);
            node.KP7 = Convert.ToString(sdr["KP7"]);
            node.ZK7 = Convert.ToString(sdr["ZK7"]);
            node.HJ7 = Convert.ToString(sdr["HJ7"]);
            node.KP8 = Convert.ToString(sdr["KP8"]);
            node.ZK8 = Convert.ToString(sdr["ZK8"]);
            node.HJ8 = Convert.ToString(sdr["HJ8"]);
            node.KP9 = Convert.ToString(sdr["KP9"]);
            node.ZK9 = Convert.ToString(sdr["ZK9"]);
            node.HJ9 = Convert.ToString(sdr["HJ9"]);
            node.KP10 = Convert.ToString(sdr["KP10"]);
            node.ZK10 = Convert.ToString(sdr["ZK10"]);
            node.HJ10 = Convert.ToString(sdr["HJ10"]);
            node.KP11 = Convert.ToString(sdr["KP11"]);
            node.ZK11 = Convert.ToString(sdr["ZK11"]);
            node.HJ11 = Convert.ToString(sdr["HJ11"]);
            node.KP12 = Convert.ToString(sdr["KP12"]);
            node.ZK12 = Convert.ToString(sdr["ZK12"]);
            node.HJ12 = Convert.ToString(sdr["HJ12"]);
            node.KP = Convert.ToString(sdr["KP"]);
            node.ZK = Convert.ToString(sdr["ZK"]);
            node.HJ = Convert.ToString(sdr["HJ"]);

            return node;
        }
        private CRM_COST_KAXSReportFH ReadFHDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAXSReportFH node = new CRM_COST_KAXSReportFH();
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.XS1 = Convert.ToString(sdr["XS1"]) == "0.00" ? "" : Convert.ToString(sdr["XS1"]);
            node.ZK1 = Convert.ToString(sdr["ZK1"]) == "0.00" ? "" : Convert.ToString(sdr["ZK1"]);
            node.TH1 = Convert.ToString(sdr["TH1"]) == "0.00" ? "" : Convert.ToString(sdr["TH1"]);


            node.XS2 = Convert.ToString(sdr["XS2"]) == "0.00" ? "" : Convert.ToString(sdr["XS2"]);
            node.ZK2 = Convert.ToString(sdr["ZK2"]) == "0.00" ? "" : Convert.ToString(sdr["ZK2"]);
            node.TH2 = Convert.ToString(sdr["TH2"]) == "0.00" ? "" : Convert.ToString(sdr["TH2"]);

            node.XS3 = Convert.ToString(sdr["XS3"]) == "0.00" ? "" : Convert.ToString(sdr["XS3"]);
            node.ZK3 = Convert.ToString(sdr["ZK3"]) == "0.00" ? "" : Convert.ToString(sdr["ZK3"]);
            node.TH3 = Convert.ToString(sdr["TH3"]) == "0.00" ? "" : Convert.ToString(sdr["TH3"]);

            node.XS4 = Convert.ToString(sdr["XS4"]) == "0.00" ? "" : Convert.ToString(sdr["XS4"]);
            node.ZK4 = Convert.ToString(sdr["ZK4"]) == "0.00" ? "" : Convert.ToString(sdr["ZK4"]);
            node.TH4 = Convert.ToString(sdr["TH4"]) == "0.00" ? "" : Convert.ToString(sdr["TH4"]);

            node.XS5 = Convert.ToString(sdr["XS5"]) == "0.00" ? "" : Convert.ToString(sdr["XS5"]);
            node.ZK5 = Convert.ToString(sdr["ZK5"]) == "0.00" ? "" : Convert.ToString(sdr["ZK5"]);
            node.TH5 = Convert.ToString(sdr["TH5"]) == "0.00" ? "" : Convert.ToString(sdr["TH5"]);

            node.XS6 = Convert.ToString(sdr["XS6"]) == "0.00" ? "" : Convert.ToString(sdr["XS6"]);
            node.ZK6 = Convert.ToString(sdr["ZK6"]) == "0.00" ? "" : Convert.ToString(sdr["ZK6"]);
            node.TH6 = Convert.ToString(sdr["TH6"]) == "0.00" ? "" : Convert.ToString(sdr["TH6"]);

            node.XS7 = Convert.ToString(sdr["XS7"]) == "0.00" ? "" : Convert.ToString(sdr["XS7"]);
            node.ZK7 = Convert.ToString(sdr["ZK7"]) == "0.00" ? "" : Convert.ToString(sdr["ZK7"]);
            node.TH7 = Convert.ToString(sdr["TH7"]) == "0.00" ? "" : Convert.ToString(sdr["TH7"]);

            node.XS8 = Convert.ToString(sdr["XS8"]) == "0.00" ? "" : Convert.ToString(sdr["XS8"]);
            node.ZK8 = Convert.ToString(sdr["ZK8"]) == "0.00" ? "" : Convert.ToString(sdr["ZK8"]);
            node.TH8 = Convert.ToString(sdr["TH8"]) == "0.00" ? "" : Convert.ToString(sdr["TH8"]);

            node.XS9 = Convert.ToString(sdr["XS9"]) == "0.00" ? "" : Convert.ToString(sdr["XS9"]);
            node.ZK9 = Convert.ToString(sdr["ZK9"]) == "0.00" ? "" : Convert.ToString(sdr["ZK9"]);
            node.TH9 = Convert.ToString(sdr["TH9"]) == "0.00" ? "" : Convert.ToString(sdr["TH9"]);

            node.XS10 = Convert.ToString(sdr["XS10"]) == "0.00" ? "" : Convert.ToString(sdr["XS10"]);
            node.ZK10 = Convert.ToString(sdr["ZK10"]) == "0.00" ? "" : Convert.ToString(sdr["ZK10"]);
            node.TH10 = Convert.ToString(sdr["TH10"]) == "0.00" ? "" : Convert.ToString(sdr["TH10"]);

            node.XS11 = Convert.ToString(sdr["XS11"]) == "0.00" ? "" : Convert.ToString(sdr["XS11"]);
            node.ZK11 = Convert.ToString(sdr["ZK11"]) == "0.00" ? "" : Convert.ToString(sdr["ZK11"]);
            node.TH11 = Convert.ToString(sdr["TH11"]) == "0.00" ? "" : Convert.ToString(sdr["TH11"]);

            node.XS12 = Convert.ToString(sdr["XS12"]) == "0.00" ? "" : Convert.ToString(sdr["XS12"]);
            node.ZK12 = Convert.ToString(sdr["ZK12"]) == "0.00" ? "" : Convert.ToString(sdr["ZK12"]);
            node.TH12 = Convert.ToString(sdr["TH12"]) == "0.00" ? "" : Convert.ToString(sdr["TH12"]);

            node.XS = Convert.ToString(sdr["XS"]) == "0.00" ? "" : Convert.ToString(sdr["XS"]);
            node.ZK = Convert.ToString(sdr["ZK"]) == "0.00" ? "" : Convert.ToString(sdr["ZK"]);
            node.TH = Convert.ToString(sdr["TH"]) == "0.00" ? "" : Convert.ToString(sdr["TH"]);

            node.HJ1 = Convert.ToString(Convert.ToDouble(sdr["XS1"]) + Convert.ToDouble(sdr["ZK1"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS1"]) + Convert.ToDouble(sdr["ZK1"]));
            if (Convert.ToDouble(sdr["TH1"]) == 0)
            {
                node.THL1 = "";
            }
            else
            {
                node.THL1 = Convert.ToString(Convert.ToDouble(sdr["TH1"]) / (Convert.ToDouble(sdr["HJ1"]) + Convert.ToDouble(sdr["TH1"])) + "%");

            }

            node.HJ2 = Convert.ToString(Convert.ToDouble(sdr["XS2"]) + Convert.ToDouble(sdr["ZK2"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS2"]) + Convert.ToDouble(sdr["ZK2"]));
            if (Convert.ToDouble(sdr["TH2"]) == 0)
            {
                node.THL2 = "";
            }
            else
            {
                node.THL2 = Convert.ToString(Convert.ToDouble(sdr["TH2"]) / (Convert.ToDouble(sdr["HJ2"]) + Convert.ToDouble(sdr["TH2"])) + "%");

            }

            node.HJ3 = Convert.ToString(Convert.ToDouble(sdr["XS3"]) + Convert.ToDouble(sdr["ZK3"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS3"]) + Convert.ToDouble(sdr["ZK3"]));
            if (Convert.ToDouble(sdr["TH3"]) == 0)
            {
                node.THL3 = "";
            }
            else
            {
                node.THL3 = Convert.ToString(Convert.ToDouble(sdr["TH3"]) / (Convert.ToDouble(sdr["HJ3"]) + Convert.ToDouble(sdr["TH3"])) + "%");

            }

            node.HJ4 = Convert.ToString(Convert.ToDouble(sdr["XS4"]) + Convert.ToDouble(sdr["ZK4"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS4"]) + Convert.ToDouble(sdr["ZK4"]));
            if (Convert.ToDouble(sdr["TH4"]) == 0)
            {
                node.THL4 = "";
            }
            else
            {
                node.THL4 = Convert.ToString(Convert.ToDouble(sdr["TH4"]) / (Convert.ToDouble(sdr["HJ4"]) + Convert.ToDouble(sdr["TH4"])) + "%");

            }

            node.HJ5 = Convert.ToString(Convert.ToDouble(sdr["XS5"]) + Convert.ToDouble(sdr["ZK5"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS5"]) + Convert.ToDouble(sdr["ZK5"]));
            if (Convert.ToDouble(sdr["TH5"]) == 0)
            {
                node.THL5 = "";
            }
            else
            {
                node.THL5 = Convert.ToString(Convert.ToDouble(sdr["TH5"]) / (Convert.ToDouble(sdr["HJ5"]) + Convert.ToDouble(sdr["TH5"])) + "%");

            }

            node.HJ6 = Convert.ToString(Convert.ToDouble(sdr["XS6"]) + Convert.ToDouble(sdr["ZK6"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS6"]) + Convert.ToDouble(sdr["ZK6"]));
            if (Convert.ToDouble(sdr["TH6"]) == 0)
            {
                node.THL6 = "";
            }
            else
            {
                node.THL6 = Convert.ToString(Convert.ToDouble(sdr["TH6"]) / (Convert.ToDouble(sdr["HJ6"]) + Convert.ToDouble(sdr["TH6"])) + "%");

            }

            node.HJ7 = Convert.ToString(Convert.ToDouble(sdr["XS7"]) + Convert.ToDouble(sdr["ZK7"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS7"]) + Convert.ToDouble(sdr["ZK7"]));
            if (Convert.ToDouble(sdr["TH7"]) == 0)
            {
                node.THL7 = "";
            }
            else
            {
                node.THL7 = Convert.ToString(Convert.ToDouble(sdr["TH7"]) / (Convert.ToDouble(sdr["HJ7"]) + Convert.ToDouble(sdr["TH7"])) + "%");

            }

            node.HJ8 = Convert.ToString(Convert.ToDouble(sdr["XS8"]) + Convert.ToDouble(sdr["ZK8"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS8"]) + Convert.ToDouble(sdr["ZK8"]));
            if (Convert.ToDouble(sdr["TH8"]) == 0)
            {
                node.THL8 = "";
            }
            else
            {
                node.THL8 = Convert.ToString(Convert.ToDouble(sdr["TH8"]) / (Convert.ToDouble(sdr["HJ8"]) + Convert.ToDouble(sdr["TH8"])) + "%");

            }

            node.HJ9 = Convert.ToString(Convert.ToDouble(sdr["XS9"]) + Convert.ToDouble(sdr["ZK9"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS9"]) + Convert.ToDouble(sdr["ZK9"]));
            if (Convert.ToDouble(sdr["TH9"]) == 0)
            {
                node.THL9 = "";
            }
            else
            {
                node.THL9 = Convert.ToString(Convert.ToDouble(sdr["TH9"]) / (Convert.ToDouble(sdr["HJ9"]) + Convert.ToDouble(sdr["TH9"])) + "%");

            }

            node.HJ10 = Convert.ToString(Convert.ToDouble(sdr["XS10"]) + Convert.ToDouble(sdr["ZK10"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS10"]) + Convert.ToDouble(sdr["ZK10"]));
            if (Convert.ToDouble(sdr["TH10"]) == 0)
            {
                node.THL10 = "";
            }
            else
            {
                node.THL10 = Convert.ToString(Convert.ToDouble(sdr["TH10"]) / (Convert.ToDouble(sdr["HJ10"]) + Convert.ToDouble(sdr["TH10"])) + "%");

            }

            node.HJ11 = Convert.ToString(Convert.ToDouble(sdr["XS11"]) + Convert.ToDouble(sdr["ZK11"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS11"]) + Convert.ToDouble(sdr["ZK11"]));
            if (Convert.ToDouble(sdr["TH11"]) == 0)
            {
                node.THL11 = "";
            }
            else
            {
                node.THL11 = Convert.ToString(Convert.ToDouble(sdr["TH11"]) / (Convert.ToDouble(sdr["HJ11"]) + Convert.ToDouble(sdr["TH11"])) + "%");

            }

            node.HJ12 = Convert.ToString(Convert.ToDouble(sdr["XS12"]) + Convert.ToDouble(sdr["ZK12"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS12"]) + Convert.ToDouble(sdr["ZK12"]));
            if (Convert.ToDouble(sdr["TH12"]) == 0)
            {
                node.THL12 = "";
            }
            else
            {
                node.THL12 = Convert.ToString(Convert.ToDouble(sdr["TH12"]) / (Convert.ToDouble(sdr["HJ12"]) + Convert.ToDouble(sdr["TH12"])) + "%");

            }

            node.HJ = Convert.ToString(Convert.ToDouble(sdr["XS"]) + Convert.ToDouble(sdr["ZK"])) == "0" ? "" : Convert.ToString(Convert.ToDouble(sdr["XS"]) + Convert.ToDouble(sdr["ZK"]));
            if (Convert.ToDouble(sdr["TH"]) == 0)
            {
                node.THL = "";
            }
            else
            {
                node.THL = Convert.ToString(Convert.ToDouble(sdr["TH"]) / (Convert.ToDouble(sdr["HJ"]) + Convert.ToDouble(sdr["TH"])) + "%");

            }

            return node;
        }
        private CRM_COST_KAXSReportMX ReadMXDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAXSReportMX node = new CRM_COST_KAXSReportMX();
            node.SF = Convert.ToString(sdr["SF"]);
            node.CS = Convert.ToString(sdr["CS"]);
            node.XTMC = Convert.ToString(sdr["XTMC"]);
            node.MDMC = Convert.ToString(sdr["MDMC"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.YWY = Convert.ToString(sdr["YWY"]);
            node.TX1 = Convert.ToDouble(sdr["TX1"]);
            node.JX1 = Convert.ToDouble(sdr["JX1"]);
            node.HJ1 = Convert.ToDouble(sdr["HJ1"]);
            node.TX2 = Convert.ToDouble(sdr["TX2"]);
            node.JX2 = Convert.ToDouble(sdr["JX2"]);
            node.HJ2 = Convert.ToDouble(sdr["HJ2"]);
            node.TX3 = Convert.ToDouble(sdr["TX3"]);
            node.JX3 = Convert.ToDouble(sdr["JX3"]);
            node.HJ3 = Convert.ToDouble(sdr["HJ3"]);
            node.TX4 = Convert.ToDouble(sdr["TX4"]);
            node.JX4 = Convert.ToDouble(sdr["JX4"]);
            node.HJ4 = Convert.ToDouble(sdr["HJ4"]);
            node.TX5 = Convert.ToDouble(sdr["TX5"]);
            node.JX5 = Convert.ToDouble(sdr["JX5"]);
            node.HJ5 = Convert.ToDouble(sdr["HJ5"]);
            node.TX6 = Convert.ToDouble(sdr["TX6"]);
            node.JX6 = Convert.ToDouble(sdr["JX6"]);
            node.HJ6 = Convert.ToDouble(sdr["HJ6"]);
            node.TX7 = Convert.ToDouble(sdr["TX7"]);
            node.JX7 = Convert.ToDouble(sdr["JX7"]);
            node.HJ7 = Convert.ToDouble(sdr["HJ7"]);
            node.TX8 = Convert.ToDouble(sdr["TX8"]);
            node.JX8 = Convert.ToDouble(sdr["JX8"]);
            node.HJ8 = Convert.ToDouble(sdr["HJ8"]);
            node.TX9 = Convert.ToDouble(sdr["TX9"]);
            node.JX9 = Convert.ToDouble(sdr["JX9"]);
            node.HJ9 = Convert.ToDouble(sdr["HJ9"]);
            node.TX10 = Convert.ToDouble(sdr["TX10"]);
            node.JX10 = Convert.ToDouble(sdr["JX10"]);
            node.HJ10 = Convert.ToDouble(sdr["HJ10"]);
            node.TX11 = Convert.ToDouble(sdr["TX11"]);
            node.JX11 = Convert.ToDouble(sdr["JX11"]);
            node.HJ11 = Convert.ToDouble(sdr["HJ11"]);
            node.TX12 = Convert.ToDouble(sdr["TX12"]);
            node.JX12 = Convert.ToDouble(sdr["JX12"]);
            node.HJ12 = Convert.ToDouble(sdr["HJ12"]);
            node.TX13 = Convert.ToDouble(sdr["TX13"]);
            node.JX13 = Convert.ToDouble(sdr["JX13"]);
            node.HJ13 = Convert.ToDouble(sdr["HJ13"]);
        
       

         
     

            return node;
        }
        private CRM_COST_KAXS_Report_MXFH ReadMXFHDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAXS_Report_MXFH node = new CRM_COST_KAXS_Report_MXFH();
            node.SF = Convert.ToString(sdr["SF"]);
            node.CS = Convert.ToString(sdr["CS"]);
            node.XTMC = Convert.ToString(sdr["XTMC"]);
            node.MDMC = Convert.ToString(sdr["MDMC"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.YWY = Convert.ToString(sdr["YWY"]);

            node.JXXH1 = Convert.ToString(sdr["JXXH1"]) == "" ? "0" : Convert.ToString(sdr["JXXH1"]);
            node.JXZK1 = Convert.ToString(sdr["JXZK1"]) == "" ? "0" : Convert.ToString(sdr["JXZK1"]);
            node.TXXH1 = Convert.ToString(sdr["TXXH1"]) == "" ? "0" : Convert.ToString(sdr["TXXH1"]);
            node.TXZK1 = Convert.ToString(sdr["TXZK1"]) == "" ? "0" : Convert.ToString(sdr["TXZK1"]);
            node.JXTH1 = Convert.ToString(sdr["JXTH1"]) == "" ? "0" : Convert.ToString(sdr["JXTH1"]);
            node.TXTH1 = Convert.ToString(sdr["TXTH1"]) == "" ? "0" : Convert.ToString(sdr["TXTH1"]);

            node.HJ1 = Convert.ToString(Convert.ToDouble(node.JXXH1) + Convert.ToDouble(node.JXZK1) + Convert.ToDouble(node.TXXH1) + Convert.ToDouble(node.TXZK1))
         == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH1) + Convert.ToDouble(node.JXZK1) + Convert.ToDouble(node.TXXH1) + Convert.ToDouble(node.TXZK1));
            node.HJTH1 = Convert.ToString(Convert.ToDouble(node.JXTH1) + Convert.ToDouble(node.TXTH1)) == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXTH1) + Convert.ToDouble(node.TXTH1));
            if(string.IsNullOrEmpty(Convert.ToString(sdr["JXTH1"])))
            {
                node.THL1 = "";
            }
            else
            {
                node.THL1 = Convert.ToString(Convert.ToDouble(node.JXTH1) / (Convert.ToDouble(node.JXTH1) + Convert.ToDouble(node.TXTH1)) + "%"); 

            }
            node.JXXH2 = Convert.ToString(sdr["JXXH2"]) == "" ? "0" : Convert.ToString(sdr["JXXH2"]);
            node.JXZK2 = Convert.ToString(sdr["JXZK2"]) == "" ? "0" : Convert.ToString(sdr["JXZK2"]);
            node.TXXH2 = Convert.ToString(sdr["TXXH2"]) == "" ? "0" : Convert.ToString(sdr["TXXH2"]);
            node.TXZK2 = Convert.ToString(sdr["TXZK2"]) == "" ? "0" : Convert.ToString(sdr["TXZK2"]);
            node.JXTH2 = Convert.ToString(sdr["JXTH2"]) == "" ? "0" : Convert.ToString(sdr["JXTH2"]);
            node.TXTH2 = Convert.ToString(sdr["TXTH2"]) == "" ? "0" : Convert.ToString(sdr["TXTH2"]);
            node.HJ2 = Convert.ToString(Convert.ToDouble(node.JXXH2) + Convert.ToDouble(node.JXZK2) + Convert.ToDouble(node.TXXH2) + Convert.ToDouble(node.TXZK2))
         == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH2) + Convert.ToDouble(node.JXZK2) + Convert.ToDouble(node.TXXH2) + Convert.ToDouble(node.TXZK2));
            node.HJTH2 = Convert.ToString(Convert.ToDouble(node.JXTH2) + Convert.ToDouble(node.TXTH2))  == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXTH2) + Convert.ToDouble(node.TXTH2));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH2"])))
            {
                node.THL2 = "";
            }
            else
            {
                node.THL2 = Convert.ToString(Convert.ToDouble(node.JXTH2) / (Convert.ToDouble(node.JXTH2) + Convert.ToDouble(node.TXTH2)) + "%");

            }

            node.JXXH3 = Convert.ToString(sdr["JXXH3"]) == "" ? "0" : Convert.ToString(sdr["JXXH3"]);
            node.JXZK3 = Convert.ToString(sdr["JXZK3"]) == "" ? "0" : Convert.ToString(sdr["JXZK3"]);
            node.TXXH3 = Convert.ToString(sdr["TXXH3"]) == "" ? "0" : Convert.ToString(sdr["TXXH3"]);
            node.TXZK3 = Convert.ToString(sdr["TXZK3"]) == "" ? "0" : Convert.ToString(sdr["TXZK3"]);
            node.JXTH3 = Convert.ToString(sdr["JXTH3"]) == "" ? "0" : Convert.ToString(sdr["JXTH3"]);
            node.TXTH3 = Convert.ToString(sdr["TXTH3"]) == "" ? "0" : Convert.ToString(sdr["TXTH3"]);
            node.HJ3 = Convert.ToString(Convert.ToDouble(node.JXXH3) + Convert.ToDouble(node.JXZK3) + Convert.ToDouble(node.TXXH3) + Convert.ToDouble(node.TXZK3))
         == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH3) + Convert.ToDouble(node.JXZK3) + Convert.ToDouble(node.TXXH3) + Convert.ToDouble(node.TXZK3));
            node.HJTH3 = Convert.ToString(Convert.ToDouble(node.JXTH3) + Convert.ToDouble(node.TXTH3)) == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXTH3) + Convert.ToDouble(node.TXTH3));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH3"])))
            {
                node.THL3 = "";
            }
            else
            {
                node.THL3 = Convert.ToString(Convert.ToDouble(node.JXTH3) / (Convert.ToDouble(node.JXTH3) + Convert.ToDouble(node.TXTH3)) + "%");

            }

            node.JXXH4 = Convert.ToString(sdr["JXXH4"]) == "" ? "0" : Convert.ToString(sdr["JXXH4"]);
            node.JXZK4 = Convert.ToString(sdr["JXZK4"]) == "" ? "0" : Convert.ToString(sdr["JXZK4"]);
            node.TXXH4 = Convert.ToString(sdr["TXXH4"]) == "" ? "0" : Convert.ToString(sdr["TXXH4"]);
            node.TXZK4 = Convert.ToString(sdr["TXZK4"]) == "" ? "0" : Convert.ToString(sdr["TXZK4"]);
            node.JXTH4 = Convert.ToString(sdr["JXTH4"]) == "" ? "0" : Convert.ToString(sdr["JXTH4"]);
            node.TXTH4 = Convert.ToString(sdr["TXTH4"]) == "" ? "0" : Convert.ToString(sdr["TXTH4"]);
            node.HJ4 = Convert.ToString(Convert.ToDouble(node.JXXH4) + Convert.ToDouble(node.JXZK4) + Convert.ToDouble(node.TXXH4) + Convert.ToDouble(node.TXZK4))
         == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH4) + Convert.ToDouble(node.JXZK4) + Convert.ToDouble(node.TXXH4) + Convert.ToDouble(node.TXZK4));
            node.HJTH4 = Convert.ToString(Convert.ToDouble(node.JXTH4) + Convert.ToDouble(node.TXTH4))== "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXTH4) + Convert.ToDouble(node.TXTH4));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH4"])))
            {
                node.THL4 = "";
            }
            else
            {
                node.THL4 = Convert.ToString(Convert.ToDouble(node.JXTH4) / (Convert.ToDouble(node.JXTH4) + Convert.ToDouble(node.TXTH4)) + "%");

            }

            node.JXXH5 = Convert.ToString(sdr["JXXH5"]) == "" ? "0" : Convert.ToString(sdr["JXXH5"]);
            node.JXZK5 = Convert.ToString(sdr["JXZK5"]) == "" ? "0" : Convert.ToString(sdr["JXZK5"]);
            node.TXXH5 = Convert.ToString(sdr["TXXH5"]) == "" ? "0" : Convert.ToString(sdr["TXXH5"]);
            node.TXZK5 = Convert.ToString(sdr["TXZK5"]) == "" ? "0" : Convert.ToString(sdr["TXZK5"]);
            node.JXTH5 = Convert.ToString(sdr["JXTH5"]) == "" ? "0" : Convert.ToString(sdr["JXTH5"]);
            node.TXTH5 = Convert.ToString(sdr["TXTH5"]) == "" ? "0" : Convert.ToString(sdr["TXTH5"]);
            node.HJ5 = Convert.ToString(Convert.ToDouble(node.JXXH5) + Convert.ToDouble(node.JXZK5) + Convert.ToDouble(node.TXXH5) + Convert.ToDouble(node.TXZK5))
         == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH5) + Convert.ToDouble(node.JXZK5) + Convert.ToDouble(node.TXXH5) + Convert.ToDouble(node.TXZK5));
            node.HJTH5 = Convert.ToString(Convert.ToDouble(node.JXTH5) + Convert.ToDouble(node.TXTH5))== "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXTH5) + Convert.ToDouble(node.TXTH5));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH5"])))
            {
                node.THL5 = "";
            }
            else
            {
                node.THL5 = Convert.ToString(Convert.ToDouble(node.JXTH5) / (Convert.ToDouble(node.JXTH5) + Convert.ToDouble(node.TXTH5)) + "%");

            }

            node.JXXH6 = Convert.ToString(sdr["JXXH6"]) == "" ? "0" : Convert.ToString(sdr["JXXH6"]);
            node.JXZK6 = Convert.ToString(sdr["JXZK6"]) == "" ? "0" : Convert.ToString(sdr["JXZK6"]);
            node.TXXH6 = Convert.ToString(sdr["TXXH6"]) == "" ? "0" : Convert.ToString(sdr["TXXH6"]);
            node.TXZK6 = Convert.ToString(sdr["TXZK6"]) == "" ? "0" : Convert.ToString(sdr["TXZK6"]);
            node.JXTH6 = Convert.ToString(sdr["JXTH6"]) == "" ? "0" : Convert.ToString(sdr["JXTH6"]);
            node.TXTH = Convert.ToString(sdr["TXTH6"]) == "" ? "0" : Convert.ToString(sdr["TXTH6"]);
            node.HJ6 = Convert.ToString(Convert.ToDouble(node.JXXH6) + Convert.ToDouble(node.JXZK6) + Convert.ToDouble(node.TXXH6) + Convert.ToDouble(node.TXZK6))
         == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH6) + Convert.ToDouble(node.JXZK6) + Convert.ToDouble(node.TXXH6) + Convert.ToDouble(node.TXZK6));
            node.HJTH6 = Convert.ToString(Convert.ToDouble(node.JXTH6) + Convert.ToDouble(node.TXTH6))== "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXTH6) + Convert.ToDouble(node.TXTH6));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH6"])))
            {
                node.THL6 = "";
            }
            else
            {
                node.THL6 = Convert.ToString(Convert.ToDouble(node.JXTH6) / (Convert.ToDouble(node.JXTH6) + Convert.ToDouble(node.TXTH6)) + "%");

            }

            node.JXXH7 = Convert.ToString(sdr["JXXH7"]) == "" ? "0" : Convert.ToString(sdr["JXXH7"]);
            node.JXZK7 = Convert.ToString(sdr["JXZK7"]) == "" ? "0" : Convert.ToString(sdr["JXZK7"]);
            node.TXXH7 = Convert.ToString(sdr["TXXH7"]) == "" ? "0" : Convert.ToString(sdr["TXXH7"]);
            node.TXZK7 = Convert.ToString(sdr["TXZK7"]) == "" ? "0" : Convert.ToString(sdr["TXZK7"]);
            node.JXTH7 = Convert.ToString(sdr["JXTH7"]) == "" ? "0" : Convert.ToString(sdr["JXTH7"]);
            node.TXTH7 = Convert.ToString(sdr["TXTH7"]) == "" ? "0" : Convert.ToString(sdr["TXTH7"]);
            node.HJ7 = Convert.ToString(Convert.ToDouble(node.JXXH7) + Convert.ToDouble(node.JXZK7) + Convert.ToDouble(node.TXXH7) + Convert.ToDouble(node.TXZK7))
         == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH7) + Convert.ToDouble(node.JXZK7) + Convert.ToDouble(node.TXXH7) + Convert.ToDouble(node.TXZK7));
            node.HJTH7 = Convert.ToString(Convert.ToDouble(node.JXTH7) + Convert.ToDouble(node.TXTH7))== "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXTH7) + Convert.ToDouble(node.TXTH7));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH7"])))
            {
                node.THL7 = "";
            }
            else
            {
                node.THL7 = Convert.ToString(Convert.ToDouble(node.JXTH7) / (Convert.ToDouble(node.JXTH7) + Convert.ToDouble(node.TXTH7)) + "%");

            }

            node.JXXH8 = Convert.ToString(sdr["JXXH8"]) == "" ? "0" : Convert.ToString(sdr["JXXH8"]);
            node.JXZK8 = Convert.ToString(sdr["JXZK8"]) == "" ? "0" : Convert.ToString(sdr["JXZK8"]);
            node.TXXH8 = Convert.ToString(sdr["TXXH8"]) == "" ? "0" : Convert.ToString(sdr["TXXH8"]);
            node.TXZK8 = Convert.ToString(sdr["TXZK8"]) == "" ? "0" : Convert.ToString(sdr["TXZK8"]);
            node.JXTH8 = Convert.ToString(sdr["JXTH8"]) == "" ? "0" : Convert.ToString(sdr["JXTH8"]);
            node.TXTH8 = Convert.ToString(sdr["TXTH8"]) == "" ? "0" : Convert.ToString(sdr["TXTH8"]);
            node.HJ8 = Convert.ToString(Convert.ToDouble(node.JXXH8) + Convert.ToDouble(node.JXZK8) + Convert.ToDouble(node.TXXH8) + Convert.ToDouble(node.TXZK8))
         == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH8) + Convert.ToDouble(node.JXZK8) + Convert.ToDouble(node.TXXH8) + Convert.ToDouble(node.TXZK8));
            node.HJTH8 = Convert.ToString(Convert.ToDouble(node.JXTH8) + Convert.ToDouble(node.TXTH8))== "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXTH8) + Convert.ToDouble(node.TXTH8));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH8"])))
            {
                node.THL8 = "";
            }
            else
            {
                node.THL8 = Convert.ToString(Convert.ToDouble(node.JXTH8) / (Convert.ToDouble(node.JXTH8) + Convert.ToDouble(node.TXTH8)) + "%");

            }

            node.JXXH9 = Convert.ToString(sdr["JXXH9"]) == "" ? "0" : Convert.ToString(sdr["JXXH9"]);
            node.JXZK9 = Convert.ToString(sdr["JXZK9"]) == "" ? "0" : Convert.ToString(sdr["JXZK9"]);
            node.TXXH9 = Convert.ToString(sdr["TXXH9"]) == "" ? "0" : Convert.ToString(sdr["TXXH9"]);
            node.TXZK9 = Convert.ToString(sdr["TXZK9"]) == "" ? "0" : Convert.ToString(sdr["TXZK9"]);
            node.JXTH9 = Convert.ToString(sdr["JXTH9"]) == "" ? "0" : Convert.ToString(sdr["JXTH9"]);
            node.TXTH9 = Convert.ToString(sdr["TXTH9"]) == "" ? "0" : Convert.ToString(sdr["TXTH9"]);
            node.HJ9 = Convert.ToString(Convert.ToDouble(node.JXXH9) + Convert.ToDouble(node.JXZK9) + Convert.ToDouble(node.TXXH9) + Convert.ToDouble(node.TXZK9))
         == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH9) + Convert.ToDouble(node.JXZK9) + Convert.ToDouble(node.TXXH9) + Convert.ToDouble(node.TXZK9));
            node.HJTH9 = Convert.ToString(Convert.ToDouble(node.JXTH9) + Convert.ToDouble(node.TXTH9))== "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXTH9) + Convert.ToDouble(node.TXTH9));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH9"])))
            {
                node.THL9 = "";
            }
            else
            {
                node.THL9 = Convert.ToString(Convert.ToDouble(node.JXTH9) / (Convert.ToDouble(node.JXTH9) + Convert.ToDouble(node.TXTH9)) + "%");

            }

            node.JXXH10 = Convert.ToString(sdr["JXXH10"]) == "" ? "0" : Convert.ToString(sdr["JXXH10"]);
            node.JXZK10 = Convert.ToString(sdr["JXZK10"]) == "" ? "0" : Convert.ToString(sdr["JXZK10"]);
            node.TXXH10 = Convert.ToString(sdr["TXXH10"]) == "" ? "0" : Convert.ToString(sdr["TXXH10"]);
            node.TXZK10 = Convert.ToString(sdr["TXZK10"]) == "" ? "0" : Convert.ToString(sdr["TXZK10"]);
            node.JXTH10 = Convert.ToString(sdr["JXTH10"]) == "" ? "0" : Convert.ToString(sdr["JXTH10"]);
            node.TXTH10 = Convert.ToString(sdr["TXTH10"]) == "" ? "0" : Convert.ToString(sdr["TXTH10"]);
            node.HJ10 = Convert.ToString(Convert.ToDouble(node.JXXH10) + Convert.ToDouble(node.JXZK10) + Convert.ToDouble(node.TXXH10) + Convert.ToDouble(node.TXZK10))
          == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH10) + Convert.ToDouble(node.JXZK10) + Convert.ToDouble(node.TXXH10) + Convert.ToDouble(node.TXZK10));
            node.HJTH10 = Convert.ToString(Convert.ToDouble(node.JXTH10) + Convert.ToDouble(node.TXTH10))== "0" ? "" :  Convert.ToString(Convert.ToDouble(node.JXTH10) + Convert.ToDouble(node.TXTH10));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH10"])))
            {
                node.THL10 = "";
            }
            else
            {
                node.THL10 = Convert.ToString(Convert.ToDouble(node.JXTH10) / (Convert.ToDouble(node.JXTH10) + Convert.ToDouble(node.TXTH10)) + "%");

            }

            node.JXXH11 = Convert.ToString(sdr["JXXH11"]) == "" ? "0" : Convert.ToString(sdr["JXXH11"]);
            node.JXZK11 = Convert.ToString(sdr["JXZK11"]) == "" ? "0" : Convert.ToString(sdr["JXZK11"]);
            node.TXXH11 = Convert.ToString(sdr["TXXH11"]) == "" ? "0" : Convert.ToString(sdr["TXXH11"]);
            node.TXZK11 = Convert.ToString(sdr["TXZK11"]) == "" ? "0" : Convert.ToString(sdr["TXZK11"]);
            node.JXTH11 = Convert.ToString(sdr["JXTH11"]) == "" ? "0" : Convert.ToString(sdr["JXTH11"]);
            node.TXTH11 = Convert.ToString(sdr["TXTH11"]) == "" ? "0" : Convert.ToString(sdr["TXTH11"]);
            node.HJ11 = Convert.ToString(Convert.ToDouble(node.JXXH11) + Convert.ToDouble(node.JXZK11) + Convert.ToDouble(node.TXXH11) + Convert.ToDouble(node.TXZK11))
          == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH11) + Convert.ToDouble(node.JXZK11) + Convert.ToDouble(node.TXXH11) + Convert.ToDouble(node.TXZK11));
            node.HJTH11 = Convert.ToString(Convert.ToDouble(node.JXTH11) + Convert.ToDouble(node.TXTH11))== "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXTH11) + Convert.ToDouble(node.TXTH11));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH11"])))
            {
                node.THL11 = "";
            }
            else
            {
                node.THL11 = Convert.ToString(Convert.ToDouble(node.JXTH11) / (Convert.ToDouble(node.JXTH11) + Convert.ToDouble(node.TXTH11)) + "%");

            }

            node.JXXH12 = Convert.ToString(sdr["JXXH12"]) == "" ? "0" : Convert.ToString(sdr["JXXH12"]);
            node.JXZK12 = Convert.ToString(sdr["JXZK12"]) == "" ? "0" : Convert.ToString(sdr["JXZK12"]);
            node.TXXH12 = Convert.ToString(sdr["TXXH12"]) == "" ? "0" : Convert.ToString(sdr["TXXH12"]);
            node.TXZK12 = Convert.ToString(sdr["TXZK12"]) == "" ? "0" : Convert.ToString(sdr["TXZK12"]);
            node.JXTH12 = Convert.ToString(sdr["JXTH12"]) == "" ? "0" : Convert.ToString(sdr["JXTH12"]);
            node.TXTH12 = Convert.ToString(sdr["TXTH12"]) == "" ? "0" : Convert.ToString(sdr["TXTH12"]);
            node.HJ12 = Convert.ToString(Convert.ToDouble(node.JXXH12) + Convert.ToDouble(node.JXZK12) + Convert.ToDouble(node.TXXH12) + Convert.ToDouble(node.TXZK12))
          == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH12) + Convert.ToDouble(node.JXZK12) + Convert.ToDouble(node.TXXH12) + Convert.ToDouble(node.TXZK12));
            node.HJTH12 = Convert.ToString(Convert.ToDouble(node.JXTH12) + Convert.ToDouble(node.TXTH12))== "0" ? "" :Convert.ToString(Convert.ToDouble(node.JXTH12) + Convert.ToDouble(node.TXTH12));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH12"])))
            {
                node.THL12 = "";
            }
            else
            {
                node.THL12 = Convert.ToString(Convert.ToDouble(node.JXTH12) / (Convert.ToDouble(node.JXTH12) + Convert.ToDouble(node.TXTH12)) + "%");

            }

            node.JXXH = Convert.ToString(sdr["JXXH"]) == "" ? "0" : Convert.ToString(sdr["JXXH"]);
            node.JXZK = Convert.ToString(sdr["JXZK"]) == "" ? "0" : Convert.ToString(sdr["JXZK"]);
            node.TXXH = Convert.ToString(sdr["TXXH"]) == "" ? "0" : Convert.ToString(sdr["TXXH"]);
            node.TXZK = Convert.ToString(sdr["TXZK"]) == "" ? "0" : Convert.ToString(sdr["TXZK"]);
            node.JXTH = Convert.ToString(sdr["JXTH"]) == "" ? "0" : Convert.ToString(sdr["JXTH"]);
            node.TXTH = Convert.ToString(sdr["TXTH"]) == "" ? "0" : Convert.ToString(sdr["TXTH"]);
            node.HJ = Convert.ToString(Convert.ToDouble(node.JXXH) + Convert.ToDouble(node.JXZK) + Convert.ToDouble(node.TXXH) + Convert.ToDouble(node.TXZK))
        == "0" ? "" : Convert.ToString(Convert.ToDouble(node.JXXH) + Convert.ToDouble(node.JXZK) + Convert.ToDouble(node.TXXH) + Convert.ToDouble(node.TXZK));
            node.HJTH = Convert.ToString(Convert.ToDouble(node.JXTH) + Convert.ToDouble(node.TXTH))== "0" ? "" :Convert.ToString(Convert.ToDouble(node.JXTH) + Convert.ToDouble(node.TXTH));
            if (string.IsNullOrEmpty(Convert.ToString(sdr["JXTH"])))
            {
                node.THL = "";
            }
            else
            {
                node.THL = Convert.ToString(Convert.ToDouble(node.JXTH) / (Convert.ToDouble(node.JXTH) + Convert.ToDouble(node.TXTH)) + "%");

            }

            node.JXXH1 = Convert.ToString(sdr["JXXH1"]) == "0" ? "" : Convert.ToString(sdr["JXXH1"]);
            node.JXZK1 = Convert.ToString(sdr["JXZK1"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK1"]);
            node.TXXH1 = Convert.ToString(sdr["TXXH1"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH1"]);
            node.TXZK1 = Convert.ToString(sdr["TXZK1"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK1"]);
            node.JXTH1 = Convert.ToString(sdr["JXTH1"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH1"]);
            node.TXTH1 = Convert.ToString(sdr["TXTH1"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH1"]);

            node.JXXH2 = Convert.ToString(sdr["JXXH2"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH2"]);
            node.JXZK2 = Convert.ToString(sdr["JXZK2"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK2"]);
            node.TXXH2 = Convert.ToString(sdr["TXXH2"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH2"]);
            node.TXZK2 = Convert.ToString(sdr["TXZK2"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK2"]);
            node.JXTH2 = Convert.ToString(sdr["JXTH2"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH2"]);
            node.TXTH2 = Convert.ToString(sdr["TXTH2"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH2"]);

            node.JXXH3 = Convert.ToString(sdr["JXXH3"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH3"]);
            node.JXZK3 = Convert.ToString(sdr["JXZK3"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK3"]);
            node.TXXH3 = Convert.ToString(sdr["TXXH3"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH3"]);
            node.TXZK3 = Convert.ToString(sdr["TXZK3"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK3"]);
            node.JXTH3 = Convert.ToString(sdr["JXTH3"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH3"]);
            node.TXTH3 = Convert.ToString(sdr["TXTH3"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH3"]);

            node.JXXH4 = Convert.ToString(sdr["JXXH4"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH4"]);
            node.JXZK4 = Convert.ToString(sdr["JXZK4"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK4"]);
            node.TXXH4 = Convert.ToString(sdr["TXXH4"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH4"]);
            node.TXZK4 = Convert.ToString(sdr["TXZK4"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK4"]);
            node.JXTH4 = Convert.ToString(sdr["JXTH4"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH4"]);
            node.TXTH4 = Convert.ToString(sdr["TXTH4"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH4"]);

            node.JXXH5 = Convert.ToString(sdr["JXXH5"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH5"]);
            node.JXZK5 = Convert.ToString(sdr["JXZK5"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK5"]);
            node.TXXH5 = Convert.ToString(sdr["TXXH5"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH5"]);
            node.TXZK5 = Convert.ToString(sdr["TXZK5"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK5"]);
            node.JXTH5 = Convert.ToString(sdr["JXTH5"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH5"]);
            node.TXTH5 = Convert.ToString(sdr["TXTH5"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH5"]);

            node.JXXH6 = Convert.ToString(sdr["JXXH6"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH6"]);
            node.JXZK6 = Convert.ToString(sdr["JXZK6"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK6"]);
            node.TXXH6 = Convert.ToString(sdr["TXXH6"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH6"]);
            node.TXZK6 = Convert.ToString(sdr["TXZK6"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK6"]);
            node.JXTH6 = Convert.ToString(sdr["JXTH6"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH6"]);
            node.TXTH6 = Convert.ToString(sdr["TXTH6"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH6"]);

            node.JXXH7 = Convert.ToString(sdr["JXXH7"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH7"]);
            node.JXZK7 = Convert.ToString(sdr["JXZK7"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK7"]);
            node.TXXH7 = Convert.ToString(sdr["TXXH7"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH7"]);
            node.TXZK7 = Convert.ToString(sdr["TXZK7"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK7"]);
            node.JXTH7 = Convert.ToString(sdr["JXTH7"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH7"]);
            node.TXTH7 = Convert.ToString(sdr["TXTH7"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH7"]);

            node.JXXH8 = Convert.ToString(sdr["JXXH8"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH8"]);
            node.JXZK8 = Convert.ToString(sdr["JXZK8"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK8"]);
            node.TXXH8 = Convert.ToString(sdr["TXXH8"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH8"]);
            node.TXZK8 = Convert.ToString(sdr["TXZK8"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK8"]);
            node.JXTH8 = Convert.ToString(sdr["JXTH8"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH8"]);
            node.TXTH8 = Convert.ToString(sdr["TXTH8"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH8"]);

            node.JXXH9 = Convert.ToString(sdr["JXXH9"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH9"]);
            node.JXZK9 = Convert.ToString(sdr["JXZK9"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK9"]);
            node.TXXH9 = Convert.ToString(sdr["TXXH9"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH9"]);
            node.TXZK9 = Convert.ToString(sdr["TXZK9"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK9"]);
            node.JXTH9 = Convert.ToString(sdr["JXTH9"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH9"]);
            node.TXTH9 = Convert.ToString(sdr["TXTH9"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH9"]);

            node.JXXH10 = Convert.ToString(sdr["JXXH10"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH10"]);
            node.JXZK10 = Convert.ToString(sdr["JXZK10"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK10"]);
            node.TXXH10 = Convert.ToString(sdr["TXXH10"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH10"]);
            node.TXZK10 = Convert.ToString(sdr["TXZK10"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK10"]);
            node.JXTH10 = Convert.ToString(sdr["JXTH10"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH10"]);
            node.TXTH10 = Convert.ToString(sdr["TXTH10"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH10"]);


            node.JXXH11 = Convert.ToString(sdr["JXXH11"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH11"]);
            node.JXZK11 = Convert.ToString(sdr["JXZK11"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK11"]);
            node.TXXH11 = Convert.ToString(sdr["TXXH11"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH11"]);
            node.TXZK11 = Convert.ToString(sdr["TXZK11"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK11"]);
            node.JXTH11 = Convert.ToString(sdr["JXTH11"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH11"]);
            node.TXTH11 = Convert.ToString(sdr["TXTH11"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH11"]);


            node.JXXH12 = Convert.ToString(sdr["JXXH12"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH12"]);
            node.JXZK12 = Convert.ToString(sdr["JXZK12"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK12"]);
            node.TXXH12 = Convert.ToString(sdr["TXXH12"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH12"]);
            node.TXZK12 = Convert.ToString(sdr["TXZK12"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK12"]);
            node.JXTH12 = Convert.ToString(sdr["JXTH12"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH12"]);
            node.TXTH12 = Convert.ToString(sdr["TXTH12"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH12"]);


            node.JXXH = Convert.ToString(sdr["JXXH"]) == "0.00" ? "" : Convert.ToString(sdr["JXXH"]);
            node.JXZK = Convert.ToString(sdr["JXZK"]) == "0.00" ? "" : Convert.ToString(sdr["JXZK"]);
            node.TXXH = Convert.ToString(sdr["TXXH"]) == "0.00" ? "" : Convert.ToString(sdr["TXXH"]);
            node.TXZK = Convert.ToString(sdr["TXZK"]) == "0.00" ? "" : Convert.ToString(sdr["TXZK"]);
            node.JXTH = Convert.ToString(sdr["JXTH"]) == "0.00" ? "" : Convert.ToString(sdr["JXTH"]);
            node.TXTH = Convert.ToString(sdr["TXTH"]) == "0.00" ? "" : Convert.ToString(sdr["TXTH"]);




            return node;
        }
        private CRM_COST_KAXSReport_Compare ReadCompareDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAXSReport_Compare node = new CRM_COST_KAXSReport_Compare();
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.SORT = Convert.ToInt32(sdr["SORT"]);
            node.CURRENT_HJ = Convert.ToString(sdr["CURRENT_HJ"]) == "0.00" ? "" : Convert.ToString(sdr["CURRENT_HJ"]);
            node.PAST_HJ = Convert.ToString(sdr["PAST_HJ"]) == "0.00" ? "" : Convert.ToString(sdr["PAST_HJ"]);

            node.COMPARE_NUM1 = Convert.ToString(Convert.ToDecimal(sdr["CURRENT_HJ"]) - Convert.ToDecimal(sdr["PAST_HJ"]))
                == "0.00" ? "" : Convert.ToString(Convert.ToDecimal(sdr["CURRENT_HJ"]) - Convert.ToDecimal(sdr["PAST_HJ"]));

            if(Convert.ToDecimal(sdr["PAST_HJ"]) == 0)
            {
                node.COMPARE_NUM2 = "";
            }
            else
            {
                node.COMPARE_NUM2 = Convert.ToString(Math.Round((Convert.ToDecimal(sdr["CURRENT_HJ"]) - Convert.ToDecimal(sdr["PAST_HJ"])) / Convert.ToDecimal(sdr["PAST_HJ"]), 2, MidpointRounding.AwayFromZero) + "%");
            }


        

            return node;
        }



    }
}
