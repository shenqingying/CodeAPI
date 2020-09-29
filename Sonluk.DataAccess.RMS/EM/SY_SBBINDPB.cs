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
    public class SY_SBBINDPB : ISY_SBBINDPB
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_SBBINDPB_Create";
        private const string SQL_Update = "EM_SY_SBBINDPB_Update";
        private const string SQL_Read = "EM_SY_SBBINDPB_Read";
        private const string SQL_Delete = "EM_SY_SBBINDPB_Delete";
        public MES_RETURN Create(EM_SY_SBBINDPB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@SBBH",model.SBBH),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_SBBINDPB_Create");

            }
            return mr;
        }
        public MES_RETURN Update(EM_SY_SBBINDPB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@SBBH",model.SBBH),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_SBBINDPB_Update");

            }
            return mr;
        }
        public IList<EM_SY_SBBINDPB> Read(EM_SY_SBBINDPB model)
        {
            IList<EM_SY_SBBINDPB> nodes = new List<EM_SY_SBBINDPB>();
            SqlParameter[] parms = {
                                        new SqlParameter("@SBBH",model.SBBH),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_SBBINDPB_Read");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(EM_SY_SBBINDPB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@SBBH",model.SBBH),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_SBBINDPB_Delete");

            }
            return mr;
        }
        private EM_SY_SBBINDPB ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_SBBINDPB node = new EM_SY_SBBINDPB();
            node.SBBH = Convert.ToString(sdr["SBBH"]);  //单机设备编号
            node.PBID = Convert.ToInt32(sdr["PBID"]);  //安卓平板
            node.SBMS = Convert.ToString(sdr["SBMS"]);
            node.MACIP = Convert.ToString(sdr["MACIP"]);
            node.IMAGEID = Convert.ToString(sdr["IMAGEID"]);
            node.JG = Convert.ToInt32(sdr["JG"]);
            node.REMARK1 = Convert.ToString(sdr["REMARK1"]);
            node.REMARK2 = Convert.ToString(sdr["REMARK2"]);
            node.TXTYPENAME = Convert.ToString(sdr["TXTYPENAME"]);
            return node;
        }
    }
}
