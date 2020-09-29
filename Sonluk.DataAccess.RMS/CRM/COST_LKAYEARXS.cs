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
    public class COST_LKAYEARXS :ICOST_LKAYEARXS
    {
        private const string SQL_Create = "CRM_COST_LKAYEARXS_Create";
        private const string SQL_Update = "CRM_COST_LKAYEARXS_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAYEARXS_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAYEARXS_Delete";
        private const string SQL_UpdateSonlukXS = "CRM_COST_LKAYEARXS_UpdateSonlukXS";

        public int Create(CRM_COST_LKAYEARXS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@PP", model.PP),
                                        new SqlParameter("@LASTYEARSJXS", model.LASTYEARSJXS),
                                        new SqlParameter("@THISYEARYJXS", model.THISYEARYJXS),
                                        new SqlParameter("@TBZJ", model.TBZJ),
                                        new SqlParameter("@BEIZ", model.BEIZ)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAYEARXS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@XSID", model.XSID),
                                        new SqlParameter("@LASTYEARSJXS", model.LASTYEARSJXS),
                                        new SqlParameter("@THISYEARYJXS", model.THISYEARYJXS),
                                        new SqlParameter("@TBZJ", model.TBZJ),
                                        new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_LKAYEARXS> ReadByParam(CRM_COST_LKAYEARXS model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@XSID", model.XSID),
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID)
                                   };
            IList<CRM_COST_LKAYEARXS> nodes = new List<CRM_COST_LKAYEARXS>();
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
        public int Delete(int XSID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@XSID", XSID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int UpdateSonlukXS(int LKAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", LKAYEARTTID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateSonlukXS, parms);
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

        private CRM_COST_LKAYEARXS ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARXS node = new CRM_COST_LKAYEARXS();
            node.XSID = Convert.ToInt32(sdr["XSID"]);
            node.LKAYEARTTID = Convert.ToInt32(sdr["LKAYEARTTID"]);
            node.PP = Convert.ToInt32(sdr["PP"]);
            node.LASTYEARSJXS = Convert.ToDouble(sdr["LASTYEARSJXS"]);
            node.THISYEARYJXS = Convert.ToDouble(sdr["THISYEARYJXS"]);
            node.TBZJ = Convert.ToDouble(sdr["TBZJ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.PPDES = Convert.ToString(sdr["PPDES"]);
            return node;
        }




    }
}
