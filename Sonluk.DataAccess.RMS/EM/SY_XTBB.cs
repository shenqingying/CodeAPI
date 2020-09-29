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
    public class SY_XTBB : ISY_XTBB
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_XTBB_Create";
        private const string SQL_Update = "EM_SY_XTBB_Update";
        private const string SQL_Read = "EM_SY_XTBB_Read";
        private const string SQL_Delete = "EM_SY_XTBB_Delete";
        public MES_RETURN Create(EM_SY_XTBB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                    new SqlParameter("@BBID",model.BBID),
                                    new SqlParameter("@REMARK",model.REMARK),
                                    new SqlParameter("@CFLJ",model.CFLJ),
                                    new SqlParameter("@ISZXBB",model.ISZXBB),
                                    new SqlParameter("@ISACTION",model.ISACTION),
                                    new SqlParameter("@ISDELETE",model.ISDELETE),
                                    new SqlParameter("@SYTYPE",model.SYTYPE)
                                    
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_XTBB_Create");

            }
            return mr;
        }
        public MES_RETURN Update(EM_SY_XTBB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                          new SqlParameter("@BBID",model.BBID),
                                        new SqlParameter("@REMARK",model.REMARK),
                                        new SqlParameter("@CFLJ",model.CFLJ),
                                        new SqlParameter("@ISZXBB",model.ISZXBB),
                                        new SqlParameter("@ISACTION",model.ISACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@SYTYPE",model.SYTYPE)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) { }
                mr.TYPE = "S";

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_XTBB_Update");

            }
            return mr;
        }
        public IList<EM_SY_XTBB> Read(EM_SY_XTBB model)
        {
            IList<EM_SY_XTBB> nodes = new List<EM_SY_XTBB>();
            SqlParameter[] parms = {
                                        new SqlParameter("@BBID",model.BBID),
                                    new SqlParameter("@REMARK",model.REMARK),
                                    new SqlParameter("@CFLJ",model.CFLJ),
                                    new SqlParameter("@ISZXBB",model.ISZXBB),
                                    new SqlParameter("@ISACTION",model.ISACTION),
                                    new SqlParameter("@ISDELETE",model.ISDELETE),
                                    new SqlParameter("@SYTYPE",model.SYTYPE)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_XTBB_Read");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int BBID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@BBID",BBID)
                                
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_XTBB_Delete");

            }
            return mr;
        }
        private EM_SY_XTBB ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_XTBB node = new EM_SY_XTBB();
           


            return node;
        }
    }
}
