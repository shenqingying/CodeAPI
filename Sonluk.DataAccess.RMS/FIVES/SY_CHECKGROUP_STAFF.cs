using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Sonluk.IDataAccess.FIVES;
namespace Sonluk.DataAccess.RMS.FIVES
{
    public class SY_CHECKGROUP_STAFF : ISY_CHECKGROUP_STAFF
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_CHECKGROUP_STAFF_Create";
        private const string SQL_Update = "FIVES_SY_CHECKGROUP_STAFF_Update";
        private const string SQL_Read = "FIVES_SY_CHECKGROUP_STAFF_Read";
        private const string SQL_Delete = "DELETE FROM FIVES_SY_CHECKGROUP_STAFF WHERE STAFFID = @STAFFID AND GID =@GID";
        public MES_RETURN Create(FIVES_SY_CHECKGROUP_STAFF model) { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {                                     
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@ACTION",model.ACTION)

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

            } 
            catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKGROUP_STAFF_Create");
            } 
            return mr; 
        }	
        public MES_RETURN Update(FIVES_SY_CHECKGROUP_STAFF model) { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@ACTION",model.ACTION)
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) { }
                mr.TYPE = "S";
            } 
            catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKGROUP_STAFF_Update");

            } return mr;
        }
        public IList<FIVES_SY_CHECKGROUP_STAFFList> Read(FIVES_SY_CHECKGROUP_STAFF model)
        {
            IList<FIVES_SY_CHECKGROUP_STAFFList> nodes = new List<FIVES_SY_CHECKGROUP_STAFFList>();
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@ACTION",model.ACTION)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_TYPE_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(FIVES_SY_CHECKGROUP_STAFF model)
        {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@GID",model.GID)
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";
            } 
            catch (Exception e){
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKGROUP_STAFF_Delete");
            } 
            return mr; 
        }

        private FIVES_SY_CHECKGROUP_STAFFList ReadDataToModel(SqlDataReader sdr) 
        {
            FIVES_SY_CHECKGROUP_STAFFList node = new FIVES_SY_CHECKGROUP_STAFFList();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);  //人员ID
            node.GID = Convert.ToInt32(sdr["GID"]);  //分组ID
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //是否激活
            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            return node;
        }


    }
}
