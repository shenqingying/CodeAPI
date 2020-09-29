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
    public class COST_CXHDPGHZ : ICOST_CXHDPGHZ
    {

        private const string SQL_Create = "CRM_COST_CXHDPGHZ_Create";
        private const string SQL_Update = "CRM_COST_CXHDPGHZ_Update";
        private const string SQL_ReadByParam = "CRM_COST_CXHDPGHZ_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CXHDPGHZ_Delete";
        private const string SQL_GetReport = "CRM_COST_CXHDPGHZ_GetReport";
        private const string SQL_DeleteByCXHDID = "CRM_COST_CXHDPGHZ_DeleteByCXHDID";

        public int Create(CRM_COST_CXHDPGHZ model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@SJHDSL", model.SJHDSL),
                                        new SqlParameter("@SJHDXS", model.SJHDXS),
                                        new SqlParameter("@FYZCFS", model.FYZCFS),
                                        new SqlParameter("@FYZC", model.FYZC),
                                        new SqlParameter("@FYZCJE", model.FYZCJE),
                                        new SqlParameter("@SJTHL", model.SJTHL),
                                        new SqlParameter("@BS", model.BS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CXHDPGHZ model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PGHZID", model.PGHZID),
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@SJHDSL", model.SJHDSL),
                                        new SqlParameter("@SJHDXS", model.SJHDXS),
                                        new SqlParameter("@FYZCFS", model.FYZCFS),
                                        new SqlParameter("@FYZC", model.FYZC),
                                        new SqlParameter("@FYZCJE", model.FYZCJE),
                                        new SqlParameter("@SJTHL", model.SJTHL),
                                        new SqlParameter("@BS", model.BS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CXHDPGHZ> ReadByParam(CRM_COST_CXHDPGHZ model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PGHZID", model.PGHZID),
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@CPLXID", model.CPLXID)

                                   };
            IList<CRM_COST_CXHDPGHZ> nodes = new List<CRM_COST_CXHDPGHZ>();
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
        public int Delete(int PGHZID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PGHZID", PGHZID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }
        public int DeleteByCXHDID(int CXHDID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", CXHDID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByCXHDID, parms);
        }
        public IList<CRM_COST_CXHDPGHZ> GetReport(CRM_COST_CXHDPGHZ model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", model.CXHDID)

                                   };
            IList<CRM_COST_CXHDPGHZ> nodes = new List<CRM_COST_CXHDPGHZ>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_GetReport, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadReportDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
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

        private CRM_COST_CXHDPGHZ ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CXHDPGHZ node = new CRM_COST_CXHDPGHZ();
            node.PGHZID = Convert.ToInt32(sdr["PGHZID"]);
            node.CXHDID = Convert.ToInt32(sdr["CXHDID"]);
            node.CPLXID = Convert.ToInt32(sdr["CPLXID"]);
            node.SJHDSL = Convert.ToInt32(sdr["SJHDSL"]);
            node.SJHDXS = Convert.ToDecimal(sdr["SJHDXS"]);
            node.FYZCFS = Convert.ToInt32(sdr["FYZCFS"]);
            node.FYZC = Convert.ToDecimal(sdr["FYZC"]);
            node.FYZCJE = Convert.ToDecimal(sdr["FYZCJE"]);
            node.SJTHL = Convert.ToDecimal(sdr["SJTHL"]);
            node.BS = Convert.ToDecimal(sdr["BS"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.CPLX = Convert.ToString(sdr["CPLX"]);
            node.FYZCFSDES = Convert.ToString(sdr["FYZCFSDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            return node;
        }

        private CRM_COST_CXHDPGHZ ReadReportDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CXHDPGHZ node = new CRM_COST_CXHDPGHZ();
            node.CXHDID = Convert.ToInt32(sdr["CXHDID"]);
            node.CPLXID = Convert.ToInt32(sdr["CPLXID"]);
            node.SJHDSL = Convert.ToInt32(sdr["SJHDSL"]);
            node.SJHDXS = Convert.ToDecimal(sdr["SJHDXS"]);
            node.FYZCFS = Convert.ToInt32(sdr["FYZCFS"]);
            node.FYZC = Convert.ToDecimal(sdr["FYZC"]);
            node.FYZCJE = Convert.ToDecimal(sdr["FYZCJE"]);
            node.SJTHL = Convert.ToDecimal(sdr["SJTHL"]);
            node.BS = Convert.ToDecimal(sdr["BS"]);

            node.CPFL = Convert.ToString(sdr["CPFL"]);
            node.CPLX = Convert.ToString(sdr["CPLX"]);
            node.FYZCFSDES = Convert.ToString(sdr["FYZCFSDES"]);
            return node;
        }




    }
}
