using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.EM
{
    public class SY_DEVICE_CONTRACT : ISY_DEVICE_CONTRACT
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_DEVICE_CONTRACT_Create";
        //private const string SQL_Update = "EM_SY_DEVICE_CONTRACT_Update";
        private const string SQL_Read = "EM_SY_DEVICE_CONTRACT_Read";
        private const string SQL_Delete = "EM_SY_DEVICE_CONTRACT_Delete";
        public MES_RETURN Create(EM_SY_DEVICE_CONTRACT model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@GZZX",model.GZZXBH),
                                        new SqlParameter("@GC",model.GC),
                                        new SqlParameter("@RYID",model.RYID)                                      

                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Create, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_DEVICE_CONTRACT_Create");

            }
            return mr;
        }
       
        public IList<EM_SY_DEVICE_CONTRACT> Read(EM_SY_DEVICE_CONTRACT model)
        {
            IList<EM_SY_DEVICE_CONTRACT> nodes = new List<EM_SY_DEVICE_CONTRACT>();
            SqlParameter[] parms = {
                                        new SqlParameter("@GZZX",model.GZZXBH),
                                        new SqlParameter("@GC",model.GC),
                                        new SqlParameter("@RYID",model.RYID)
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        EM_SY_DEVICE_CONTRACT node = new EM_SY_DEVICE_CONTRACT();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.RYID = Convert.ToInt32(sdr["RYID"]);
                        node.GZZXBH = Convert.ToString(sdr["GZZX"]);
                        nodes.Add(node);
                    }
                }
                return nodes;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_DEVICE_CONTRACT_Read");
                throw new ApplicationException(e.Message);
            }

        }
        public MES_RETURN Delete(EM_SY_DEVICE_CONTRACT model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@GZZX",model.GZZXBH),
                                        new SqlParameter("@GC",model.GC),
                                        new SqlParameter("@RYID",model.RYID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Delete, parms)) { }
                mr.TYPE = "S";


            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_DEVICE_CONTRACT_Delete");

            }
            return mr;
        }	

    }
}
