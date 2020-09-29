using Sonluk.DataAccess.RMS.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sonluk.Entities.MES;
using Sonluk.Entities.FIVES;
using Sonluk.IDataAccess.FIVES;
namespace Sonluk.DataAccess.RMS.FIVES
{
    public class SY_STATION : ISY_STATION
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_STATION_Create";
        private const string SQL_Update = "FIVES_SY_STATION_Update";
        private const string SQL_Read = "FIVES_SY_STATION_Read";
        private const string SQL_Delete = "UPDATE  FIVES_SY_STATION SET ISDELETE = 1 WHERE SID = @SID";
        public MES_RETURN Create(FIVES_SY_STATION model) { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {    
                                        new SqlParameter("@SID",model.SID),
                                        new SqlParameter("@MS",model.MS),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_STATION_Create");

            } 
            return mr; 
        }	
        public MES_RETURN Update(FIVES_SY_STATION model) {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {    
                                        new SqlParameter("@SID",model.SID),
                                        new SqlParameter("@MS",model.MS),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_STATION_Update");

            } 
            return mr;
        }
        public IList<FIVES_SY_STATION> Read(FIVES_SY_STATION model)
        {
            IList<FIVES_SY_STATION> nodes = new List<FIVES_SY_STATION>();
            SqlParameter[] parms = {    
                                        new SqlParameter("@SID",model.SID),
                                        new SqlParameter("@MS",model.MS),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_STATION_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int ID) { 
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = { 
                                       new SqlParameter("@SID",ID),
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_STATION_DELETE");

            } 
            return mr;
        }	
        private FIVES_SY_STATION ReadDataToModel(SqlDataReader sdr) {
            FIVES_SY_STATION node = new FIVES_SY_STATION();
            node.SID = Convert.ToInt32(sdr["SID"]);  //负责人ID
            node.MS = Convert.ToString(sdr["MS"]);  //负责人描述
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //状态
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除
            return node;
        }


    }
}
