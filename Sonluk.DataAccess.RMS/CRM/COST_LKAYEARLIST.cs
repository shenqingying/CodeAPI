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
    public class COST_LKAYEARLIST : ICOST_LKAYEARLIST
    {
        private const string SQL_Create = "CRM_COST_LKAYEARLIST_Create";
        private const string SQL_Update = "CRM_COST_LKAYEARLIST_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAYEARLIST_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAYEARLIST_Delete";
        private const string SQL_ReadListByKHID = "CRM_COST_LKAYEARLIST_ReadListByKHID";
        private const string SQL_DeleteByTTID = "CRM_COST_LKAYEARLIST_DeleteByTTID";

        public int Create(CRM_COST_LKAYEARLIST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@LAST2YEAR_HT", model.LAST2YEAR_HT),
                                        new SqlParameter("@LAST2YEAR_GS", model.LAST2YEAR_GS),
                                        new SqlParameter("@LASTYEAR_HT", model.LASTYEAR_HT),
                                        new SqlParameter("@LASTYEAR_GS", model.LASTYEAR_GS),
                                        new SqlParameter("@THISYEAR_HT", model.THISYEAR_HT),
                                        new SqlParameter("@THISYEAR_GS", model.THISYEAR_GS),
                                        new SqlParameter("@CCJ_HT", model.CCJ_HT),
                                        new SqlParameter("@CCJ_GS", model.CCJ_GS),
                                        new SqlParameter("@BEIZ", model.BEIZ)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAYEARLIST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LISTID", model.LISTID),
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@LAST2YEAR_HT", model.LAST2YEAR_HT),
                                        new SqlParameter("@LAST2YEAR_GS", model.LAST2YEAR_GS),
                                        new SqlParameter("@LASTYEAR_HT", model.LASTYEAR_HT),
                                        new SqlParameter("@LASTYEAR_GS", model.LASTYEAR_GS),
                                        new SqlParameter("@THISYEAR_HT", model.THISYEAR_HT),
                                        new SqlParameter("@THISYEAR_GS", model.THISYEAR_GS),
                                        new SqlParameter("@CCJ_HT", model.CCJ_HT),
                                        new SqlParameter("@CCJ_GS", model.CCJ_GS),
                                        new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_LKAYEARLIST> ReadByParam(CRM_COST_LKAYEARLIST model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@LISTID", model.LISTID),
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID)
                                   };
            IList<CRM_COST_LKAYEARLIST> nodes = new List<CRM_COST_LKAYEARLIST>();
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

        public IList<CRM_COST_LKAYEARLIST> ReadListByKHID(int KHID,string YEAR)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID", KHID),
                                        new SqlParameter("@YEAR", YEAR)
                                   };
            IList<CRM_COST_LKAYEARLIST> nodes = new List<CRM_COST_LKAYEARLIST>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadListByKHID, parms))
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

        public int Delete(int LISTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LISTID", LISTID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int DeleteByTTID(int LKAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", LKAYEARTTID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByTTID, parms);
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

        private CRM_COST_LKAYEARLIST ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARLIST node = new CRM_COST_LKAYEARLIST();
            node.LISTID = Convert.ToInt32(sdr["LISTID"]);
            node.LKAYEARTTID = Convert.ToInt32(sdr["LKAYEARTTID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.LAST2YEAR_HT = Convert.ToDouble(sdr["LAST2YEAR_HT"]);
            node.LAST2YEAR_GS = Convert.ToDouble(sdr["LAST2YEAR_GS"]);
            node.LASTYEAR_HT = Convert.ToDouble(sdr["LASTYEAR_HT"]);
            node.LASTYEAR_GS = Convert.ToDouble(sdr["LASTYEAR_GS"]);
            node.THISYEAR_HT = Convert.ToDouble(sdr["THISYEAR_HT"]);
            node.THISYEAR_GS = Convert.ToDouble(sdr["THISYEAR_GS"]);
            node.CCJ_HT = Convert.ToDouble(sdr["CCJ_HT"]);
            node.CCJ_GS = Convert.ToDouble(sdr["CCJ_GS"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);

            return node;
        }

        private CRM_COST_LKAYEARLIST ReadDataToObj2(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARLIST node = new CRM_COST_LKAYEARLIST();
            node.KHID = Convert.ToInt32(sdr["LKAID"]);
            node.LAST2YEAR_HT = Convert.ToDouble(sdr["LAST2YEAR_HT"]);
            node.LAST2YEAR_GS = Convert.ToDouble(sdr["LAST2YEAR_GS"]);
            node.LASTYEAR_HT = Convert.ToDouble(sdr["LASTYEAR_HT"]);
            node.LASTYEAR_GS = Convert.ToDouble(sdr["LASTYEAR_GS"]);
            node.THISYEAR_HT = Convert.ToDouble(sdr["THISYEAR_HT"]);
            node.THISYEAR_GS = Convert.ToDouble(sdr["THISYEAR_GS"]);
            node.CCJ_HT = Convert.ToDouble(sdr["CCJ_HT"]);
            node.CCJ_GS = Convert.ToDouble(sdr["CCJ_GS"]);
            node.KHMC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);

            return node;
        }


    }
}
