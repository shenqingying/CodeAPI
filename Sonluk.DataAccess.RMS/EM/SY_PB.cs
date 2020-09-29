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
    public class SY_PB : ISY_PB
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_PB_Create";
        private const string SQL_Update = "EM_SY_PB_Update";
        private const string SQL_Read = "EM_SY_PB_Read";
        private const string SQL_Delete = "EM_SY_PB_Delete";
        public MES_RETURN Create(EM_SY_PB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       //new SqlParameter("@PBID",model.PBID),
                                        new SqlParameter("@PBMS",model.PBMS),
                                        new SqlParameter("@PBBH",model.PBBH),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@BZ",model.BZ)                                       
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_PB_Create");

            }
            return mr;
        }
        public MES_RETURN Update(EM_SY_PB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@PBID",model.PBID),
                                        new SqlParameter("@PBMS",model.PBMS),
                                        new SqlParameter("@PBBH",model.PBBH),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@BZ",model.BZ) 
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_PB_Update");

            }
            return mr;
        }
        public IList<EM_SY_PB> Read(EM_SY_PB model)
        {
            IList<EM_SY_PB> nodes = new List<EM_SY_PB>();
            SqlParameter[] parms = {
                                        new SqlParameter("@PBID",model.PBID),
                                        new SqlParameter("@PBMS",model.PBMS),
                                        new SqlParameter("@PBBH",model.PBBH),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@BZ",model.BZ) 
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_PB_Read");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int PBID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@PBID",PBID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_PB_Delete");

            }
            return mr;
        }
        private EM_SY_PB ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_PB node = new EM_SY_PB();
            node.PBID = Convert.ToInt32(sdr["PBID"]);  //PBID
            node.PBMS = Convert.ToString(sdr["PBMS"]);  //平板设备描述
            node.PBBH = Convert.ToString(sdr["PBBH"]);  //平板设备编号
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);  //ISDELETE
            node.BZ = Convert.ToString(sdr["BZ"]);  //BZ
            return node;
        }
    }
}
