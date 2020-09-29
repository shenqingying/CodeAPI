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
    public class COST_CLFMX_CLFHX : ICOST_CLFMX_CLFHX
    {
        private const string SQL_Create = "CRM_COST_CLFMX_CLFHX_Create";
        private const string SQL_Update = "CRM_COST_CLFMX_CLFHX_Update";  //没有存储过程
        private const string SQL_ReadByParam = "CRM_COST_CLFMX_CLFHX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CLFMX_CLFHX_Delete";
        private const string SQL_DeleteByCLFHXID = "CRM_COST_CLFMX_CLFHX_DeleteByCLFHXID";

        private const string SQL_ReadByCLFHXID = "CRM_COST_CLFMX_CLFHX _ReadByCLFHXID";
        private const string SQL_ReadByCLFMXID = "CRM_COST_CLFMX_CLFHX _ReadByCLFMXID";
        //  private const string SQL_DeleteByCLFMXID = "CRM_COST_CLFMX_CLFHX_DeleteByCLFMXID";CRM_COST_CLFMX_CLFHX_ReadByCLFHXID


        public int Create(CRM_COST_CLFMX_CLFHX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFMXID", model.CLFMXID),
                                        new SqlParameter("@CLFHXID", model.CLFHXID),
                                        
                                       
                                    
                                      
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CLFMX_CLFHX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFMXID", model.CLFMXID),
                                        new SqlParameter("@CLFHXID", model.CLFHXID),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CLFMX_CLFHX> ReadByParam(CRM_COST_CLFMX_CLFHX model)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@CLFMXID", model.CLFMXID),
                                        new SqlParameter("@CLFHXID", model.CLFHXID),
                                        
                                   };
            IList<CRM_COST_CLFMX_CLFHX> nodes = new List<CRM_COST_CLFMX_CLFHX>();
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


        public IList<CRM_COST_CLFMX_CLFHX> ReadByCLFHXID(int CLFHXID)
        {
            SqlParameter[] parms = {  
                                       
                                        new SqlParameter("@CLFHXID",CLFHXID),
                                        
                                   };
            IList<CRM_COST_CLFMX_CLFHX> nodes = new List<CRM_COST_CLFMX_CLFHX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByCLFHXID, parms))
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
        public IList<CRM_COST_CLFMX_CLFHX> ReadByCLFMXID(int CLFMXID)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@CLFMXID",CLFMXID),
                                       
                                        
                                   };
            IList<CRM_COST_CLFMX_CLFHX> nodes = new List<CRM_COST_CLFMX_CLFHX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByCLFMXID, parms))
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
        public int Delete(CRM_COST_CLFMX_CLFHX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFMXID", model.CLFMXID),
                                        new SqlParameter("@CLFHXID", model.CLFHXID),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }
        public int DeleteByCLFHXID(int CLFHXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFHXID", CLFHXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByCLFHXID, parms);
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


        private CRM_COST_CLFMX_CLFHX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CLFMX_CLFHX node = new CRM_COST_CLFMX_CLFHX();
            node.CLFHXID = Convert.ToInt32(sdr["CLFHXID"]);
            node.CLFMXID = Convert.ToInt32(sdr["CLFMXID"]);
            return node;
        }
    }
}
