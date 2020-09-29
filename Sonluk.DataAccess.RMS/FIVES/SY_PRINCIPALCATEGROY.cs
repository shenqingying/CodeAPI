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
    public class SY_PRINCIPALCATEGROY : ISY_PRINCIPALCATEGROY
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_PRINCIPALCATEGROY_Create";
        private const string SQL_Update = "FIVES_SY_PRINCIPALCATEGROY_Update";
        private const string SQL_Read = "FIVES_SY_PRINCIPALCATEGROY_Read";
        private const string SQL_Delete = "DELETE FROM FIVES_SY_PRINCIPALCATEGROY WHERE SID = @SID AND CATEGROYID = @CATEGROYID";
        public MES_RETURN Create(FIVES_SY_PRINCIPALCATEGROY model) { 
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                       new SqlParameter("@SID",model.SID),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_PRINCIPALCATEGROY_Create");

            } 
            return mr; 
        }	
        public MES_RETURN Update(FIVES_SY_PRINCIPALCATEGROY model) { 
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                       new SqlParameter("@SID",model.SID),
                                       new SqlParameter("@CATEGROYID",model.CATEGROYID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_PRINCIPALCATEGROY_Update");

            } 
            return mr; 
        }
        public IList<FIVES_SY_PRINCIPALCATEGROYList> Read(FIVES_SY_PRINCIPALCATEGROY model)
        {
            IList<FIVES_SY_PRINCIPALCATEGROYList> nodes = new List<FIVES_SY_PRINCIPALCATEGROYList>();
            SqlParameter[] parms = {
                                       new SqlParameter("@SID",model.SID),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_PRINCIPALCATEGROY_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(FIVES_SY_PRINCIPALCATEGROY model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@SID",model.SID),
                                       new SqlParameter("@CATEGROYID",model.CATEGROYID)
                                   };
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_PRINCIPALCATEGROY_Delete");

            } 
            return mr;
        }
        private FIVES_SY_PRINCIPALCATEGROYList ReadDataToModel(SqlDataReader sdr)
        {
            FIVES_SY_PRINCIPALCATEGROYList node = new FIVES_SY_PRINCIPALCATEGROYList();
            node.SID = Convert.ToInt32(sdr["SID"]);  //岗位ID
            node.CATEGROYID = Convert.ToInt32(sdr["CATEGROYID"]);  //检查点分类ID
            node.SNAME = Convert.ToString(sdr["SNAME"]);
            node.CNAME = Convert.ToString(sdr["CNAME"]);
            return node;
        }


    }
}
