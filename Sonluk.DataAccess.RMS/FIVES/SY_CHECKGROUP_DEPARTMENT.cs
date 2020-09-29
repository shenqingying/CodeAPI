using Sonluk.DataAccess.RMS.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.FIVES;
namespace Sonluk.DataAccess.RMS.FIVES
{
    public class SY_CHECKGROUP_DEPARTMENT : ISY_CHECKGROUP_DEPARTMENT
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_CHECKGROUP_DEPARTMENT_Create";
        private const string SQL_Update = "FIVES_SY_CHECKGROUP_DEPARTMENT_Update";
        private const string SQL_Read = "FIVES_SY_CHECKGROUP_DEPARTMENT_Read";
        private const string SQL_Delete = "DELETE FROM FIVES_SY_CHECKGROUP_DEPARTMENT WHERE GID = @GID AND DID = @DID";
        public MES_RETURN Create(FIVES_SY_CHECKGROUP_DEPARTMENT model)
        {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = { 
                                       new SqlParameter("@GID",model.GID),
                                       new SqlParameter("@DID",model.DID)

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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKGROUP_DEPARTMENT_Create");

            } 
            return mr;
        }
        public MES_RETURN Update(FIVES_SY_CHECKGROUP_DEPARTMENT model)
        {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = { 
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKGROUP_DEPARTMENT_Update");

            } 
            return mr;
        }
        public IList<FIVES_SY_CHECKGROUP_DEPARTMENT> Read(FIVES_SY_CHECKGROUP_DEPARTMENT model)
        {
            return null;
        }
        public MES_RETURN Delete(FIVES_SY_CHECKGROUP_DEPARTMENT model) { 
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@DID",model.DID)
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKGROUP_DEPARTMENT_Delete");

            } 
            return mr;
        }
        private FIVES_SY_CHECKGROUP_DEPARTMENT ReadDataToModel(SqlDataReader sdr)
        {
            FIVES_SY_CHECKGROUP_DEPARTMENT node = new FIVES_SY_CHECKGROUP_DEPARTMENT();
            node.GID = Convert.ToInt32(sdr["GID"]);  //权限分组ID
            node.DID = Convert.ToInt32(sdr["DID"]);  //部门ID
            return node;
        }



    }
}
