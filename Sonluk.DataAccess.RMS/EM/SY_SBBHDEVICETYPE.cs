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
    public class SY_SBBHDEVICETYPE : ISY_SBBHDEVICETYPE
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_SBBHDEVICETYPE_Create";
        //private const string SQL_Update = "EM_SY_INFOREPORT_Update";
        private const string SQL_Read = "EM_SY_SBBHDEVICETYPE_Read";
        private const string SQL_Delete = "EM_SY_SBBHDEVICETYPE_Delete";
        public MES_RETURN Create(EM_SY_SBBHDEVICETYPE model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                    //new SqlParameter("@ID",model.ID),
                                    new SqlParameter("@DID",model.DID),
                                    new SqlParameter("@SBBH",model.SBBH)
                                   
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_SBBHDEVICETYPE_Create");

            }
            return mr;
        }

        public IList<EM_SY_SBBHDEVICETYPELIST> Read(EM_SY_SBBHDEVICETYPE model)
        {
            IList<EM_SY_SBBHDEVICETYPELIST> nodes = new List<EM_SY_SBBHDEVICETYPELIST>();
            SqlParameter[] parms = {
                                          new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@SBBH",model.SBBH)
                                        
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        EM_SY_SBBHDEVICETYPELIST node = new EM_SY_SBBHDEVICETYPELIST();
                        node.DID = Convert.ToInt32(sdr["DID"]);
                        node.DMS = Convert.ToString(sdr["DMS"]);
                        node.SBBH = Convert.ToString(sdr["SBBH"]);
                        node.SBMS = Convert.ToString(sdr["SBMS"]);
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GZZX = Convert.ToString(sdr["GZZX"]);
                        node.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        nodes.Add(node);
                    }
                }
                return nodes;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_SBBHDEVICETYPE_Read");
                throw new ApplicationException(e.Message);
            }
        }

        public MES_RETURN Delete(EM_SY_SBBHDEVICETYPE model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                         new SqlParameter("@DID",model.DID),
                                         new SqlParameter("@SBBH",model.SBBH)
                                
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_SBBHDEVICETYPE_Delete");

            }
            return mr;
        }




    }
}
