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
    public class CRM_PENDING : ICRM_PENDING
    {
        private const string SQL_Read_Summary = "CRM_PENDING_SURRARY";
        private const string SQL_Read_Detail = "CRM_PENDING_DETAIL";


        public IList<CRM_PENDING_SUMMARY> Read_Summary(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_PENDING_SUMMARY> nodes = new List<CRM_PENDING_SUMMARY>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Read_Summary,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToSummary(sdr));
                    }
                   
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_PENDING_DETAIL> Read_Detail(int STAFFID, int SummaryID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@SummaryID",SummaryID)
                                   };
            IList<CRM_PENDING_DETAIL> nodes = new List<CRM_PENDING_DETAIL>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Read_Detail,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToDetail(sdr));
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

        private CRM_PENDING_SUMMARY ReadDataToSummary(SqlDataReader sdr)
        {
            CRM_PENDING_SUMMARY node = new CRM_PENDING_SUMMARY();
            node.FINISHCOUNTS = Convert.ToInt32(sdr["FINISHCOUNTS"]);
            node.UNFINISHEDCOUNTS = Convert.ToInt32(sdr["UNFINISHEDCOUNTS"]);
            node.SUMMARYDES = Convert.ToString(sdr["SUMMARYDES"]);
            node.SUMMARYID = Convert.ToInt32(sdr["SUMMARYID"]);
            node.KHCOUNTS = Convert.ToInt32(sdr["KHCOUNTS"]);
            node.REQUIRECOUNTS = Convert.ToInt32(sdr["REQUIRECOUNTS"]);
            return node;
        }
        private CRM_PENDING_DETAIL ReadDataToDetail(SqlDataReader sdr)
        {
            CRM_PENDING_DETAIL node = new CRM_PENDING_DETAIL();
            node.BFJHDES = Convert.ToString(sdr["BFJHDES"]);
            node.BFJHID = Convert.ToInt32(sdr["BFJHID"]);
            node.FINISHCOUNTS = Convert.ToInt32(sdr["FINISHCOUNTS"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.REQUIRECOUNTS = Convert.ToInt32(sdr["REQUIRECOUNTS"]);
            node.UNFINISHEDCOUNTS = Convert.ToInt32(sdr["UNFINISHEDCOUNTS"]);
            node.BFID = Convert.ToInt32(sdr["BFID"]);
            return node;
        }



    }
}
