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
    public class KH_KHBF : IKH_KHBF
    {
        private const string SQL_Create = "CRM_KH_KHBF_Create";
        private const string SQL_Update = "CRM_KH_KHBF_Update";
        private const string SQL_Read = "CRM_KH_KHBF_Read";
        private const string SQL_Delete = "CRM_KH_KHBF_Delete";
        private const string SQL_ReadByParms = "CRM_KH_KHBF_ReadByParms";

        public int Create(CRM_KH_KHBFList model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFID",model.BFID),
                                       new SqlParameter("@KHID",model.KHID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_KH_KHBFList model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFID",model.BFID),
                                       new SqlParameter("@KHID",model.KHID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_KH_KHBFList> Read(int BFID, int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFID",BFID),
                                       new SqlParameter("@KHID",KHID)
                                   };
            IList<CRM_KH_KHBFList> nodes = new List<CRM_KH_KHBFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Read,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToStruct(sdr,1));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_KH_KHBFList> ReadByParms(CRM_KH_KHBF_Parms model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFID", model.BFID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@KHLX", model.KHLX),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@GID", model.GID),
                                        new SqlParameter("@TYPE", model.TYPE)

                                   };
            IList<CRM_KH_KHBFList> nodes = new List<CRM_KH_KHBFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParms, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToStruct(sdr, 10));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }





        private CRM_KH_KHBFList ReadDataToStruct(SqlDataReader sdr, int level)
        {
            CRM_KH_KHBFList node = new CRM_KH_KHBFList();
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.BFID = Convert.ToInt32(sdr["BFID"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.DUTYID = Convert.ToInt32(sdr["DUTYID"]);
            node.DUTYNAME = Convert.ToString(sdr["DUTYNAME"]);
            node.BFZQ = Convert.ToInt32(sdr["BFZQ"]);
            node.BFZQDES = Convert.ToString(sdr["BFZQDES"]);
            node.BFCS = Convert.ToInt32(sdr["BFCS"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.MCSX = Convert.ToInt32(sdr["MCSX"]);
            if (level == 10)
            {
                node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            }
            
            return node;
        }







        public int Delete(CRM_KH_KHBFList model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFID",model.BFID),
                                       new SqlParameter("@KHID",model.KHID)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Delete, parms);
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

        //int IKH_KHBF.Create(CRM_KH_KHBFList model)
        //{
        //    throw new NotImplementedException();
        //}

        //int IKH_KHBF.Delete(CRM_KH_KHBFList model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
