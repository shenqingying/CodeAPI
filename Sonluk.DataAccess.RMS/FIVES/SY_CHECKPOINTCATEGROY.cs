using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.DataAccess.RMS.MES;
using System.Data;
using System.Data.SqlClient;
using Sonluk.Entities.MES;
using Sonluk.Entities.FIVES;
using Sonluk.IDataAccess.FIVES;

namespace Sonluk.DataAccess.RMS.FIVES
{
    public class SY_CHECKPOINTCATEGROY : ISY_CHECKPOINTCATEGROY
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_CHECKPOINTCATEGROY_Create";
        private const string SQL_Update = "FIVES_SY_CHECKPOINTCATEGROY_Update";
        private const string SQL_Read = "FIVES_SY_CHECKPOINTCATEGROY_Read";
        private const string SQL_Delete = "UPDATE FIVES_SY_CHECKPOINTCATEGROY SET ISDELETE = 1 WHERE CATEGROYID = @CATEGROYID";
        public MES_RETURN Create(FIVES_SY_CHECKPOINTCATEGROY model) { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@CATEGROYID",model.CATEGROYID),
                                        new SqlParameter("@CATEGROYMS",model.CATEGROYMS),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE)

                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Create, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINTCATEGROY_Create");

            } 
            return mr;
        }	
        public MES_RETURN Update(FIVES_SY_CHECKPOINTCATEGROY model) {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@CATEGROYID",model.CATEGROYID),
                                        new SqlParameter("@CATEGROYMS",model.CATEGROYMS),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE)
                                   };
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINTCATEGROY_Update");

            } 
            return mr; 
        }
        public IList<FIVES_SY_CHECKPOINTCATEGROY> Read(FIVES_SY_CHECKPOINTCATEGROY model)
        {
            IList<FIVES_SY_CHECKPOINTCATEGROY> nodes = new List<FIVES_SY_CHECKPOINTCATEGROY>();
            SqlParameter[] parms = {
                                        new SqlParameter("@CATEGROYID",model.CATEGROYID),
                                        new SqlParameter("@CATEGROYMS",model.CATEGROYMS),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINTCATEGROY_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int ID) { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@CATEGROYID",ID)
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINTCATEGROY_Delete");

            } 
            return mr;
        }	
        private FIVES_SY_CHECKPOINTCATEGROY ReadDataToModel(SqlDataReader sdr) {
            FIVES_SY_CHECKPOINTCATEGROY node = new FIVES_SY_CHECKPOINTCATEGROY();
            node.CATEGROYID = Convert.ToInt32(sdr["CATEGROYID"]);  //检查点分类ID
            node.CATEGROYMS = Convert.ToString(sdr["CATEGROYMS"]);  //检查点明细描述
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //状态
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除
            return node;
        }


    }
}
