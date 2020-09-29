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
    public class SY_CHECKPOINT_POINTCATEGROY : ISY_CHECKPOINT_POINTCATEGROY
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_CHECKPOINT_POINTCATEGROY_Create";
        private const string SQL_Update = "FIVES_SY_CHECKPOINT_POINTCATEGROY_Update";
        private const string SQL_Read = "FIVES_SY_CHECKPOINT_POINTCATEGROY_Read";
        private const string SQL_Delete = "DELETE FROM FIVES_SY_CHECKPOINT_POINTCATEGROY WHERE POINTID = @POINTID AND CATEGROYID = @CATEGROYID";
        public MES_RETURN Create(FIVES_SY_CHECKPOINT_POINTCATEGROY model) { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@POINTID",model.POINTID),
                                       new SqlParameter("@CATEGROYID",model.CATEGROYID)


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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_POINTCATEGROY_Create");

            } 
            return mr; 
        }	
        public MES_RETURN Update(FIVES_SY_CHECKPOINT_POINTCATEGROY model) {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = { 
                                         new SqlParameter("@POINTID",model.POINTID),
                                         new SqlParameter("@CATEGROYID",model.CATEGROYID)
                                   };
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_POINTCATEGROY_Update");

            } 
            return mr; 
        }
        public IList<FIVES_SY_CHECKPOINT_POINTCATEGROYList> Read(FIVES_SY_CHECKPOINT_POINTCATEGROY model)
        {
            IList<FIVES_SY_CHECKPOINT_POINTCATEGROYList> nodes = new List<FIVES_SY_CHECKPOINT_POINTCATEGROYList>();
            SqlParameter[] parms = { 
                                         new SqlParameter("@POINTID",model.POINTID),
                                         new SqlParameter("@CATEGROYID",model.CATEGROYID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_POINTCATEGROY_READ");
                throw new ApplicationException(e.Message);
            }
            
        }
        public MES_RETURN Delete(FIVES_SY_CHECKPOINT_POINTCATEGROY model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                         new SqlParameter("@POINTID",model.POINTID),
                                         new SqlParameter("@CATEGROYID",model.CATEGROYID)
                                   };
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_POINTCATEGROY_Delete");

            } 
            return mr; 
        }
        private FIVES_SY_CHECKPOINT_POINTCATEGROYList ReadDataToModel(SqlDataReader sdr)
        {
            FIVES_SY_CHECKPOINT_POINTCATEGROYList node = new FIVES_SY_CHECKPOINT_POINTCATEGROYList();
            node.POINTID = Convert.ToInt32(sdr["POINTID"]);  //检查点ID
            node.CATEGROYID = Convert.ToInt32(sdr["CATEGROYID"]);  //检查点分类ID
            node.CNAME = Convert.ToString(sdr["CNAME"]);
            node.LNAME = Convert.ToString(sdr["LNAME"]);
            node.PNAME = Convert.ToString(sdr["PNAME"]);
            return node;
        }



    }
}
