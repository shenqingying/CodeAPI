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
    public class SY_STAFFIDBINDPB : ISY_STAFFIDBINDPB
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_STAFFIDBINDPB_Create";
        private const string SQL_Update = "EM_SY_STAFFIDBINDPB_Update";
        private const string SQL_Read = "EM_SY_STAFFIDBINDPB_Read";
        private const string SQL_Delete = "EM_SY_STAFFIDBINDPB_Delete";
        public MES_RETURN Create(EM_SY_STAFFIDBINDPB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@PBID",model.PBID)



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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_STAFFIDBINDPB_Create");

            }
            return mr;
        }
        public MES_RETURN Update(EM_SY_STAFFIDBINDPB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                         new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@PBID",model.PBID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_STAFFIDBINDPB_Update");

            }
            return mr;
        }
        public IList<EM_SY_STAFFIDBINDPB> Read(EM_SY_STAFFIDBINDPB model)
        {
            IList<EM_SY_STAFFIDBINDPB> nodes = new List<EM_SY_STAFFIDBINDPB>();
            SqlParameter[] parms = {
                                         new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@PBID",model.PBID)
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToModel(sdr));
                    }
                }
                return nodes;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_STAFFIDBINDPB_Read");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(EM_SY_STAFFIDBINDPB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@PBID",model.PBID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_STAFFIDBINDPB_Delete");

            }
            return mr;
        }
        private EM_SY_STAFFIDBINDPB ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_STAFFIDBINDPB node = new EM_SY_STAFFIDBINDPB();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);  //单机设备编号
            node.PBID = Convert.ToInt32(sdr["PBID"]);  //安卓平板


            return node;
        }
    }
}
