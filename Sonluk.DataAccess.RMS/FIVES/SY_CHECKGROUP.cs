using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using Sonluk.DataAccess.RMS.MES;
using Sonluk.IDataAccess.FIVES;
namespace Sonluk.DataAccess.RMS.FIVES
{
    public class SY_CHECKGROUP : ISY_CHECKGROUP
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_CHECKGROUP_Create";
        private const string SQL_Update = "FIVES_SY_CHECKGROUP_Update";
        private const string SQL_Read = "FIVES_SY_CHECKGROUP_Read";
        private const string SQL_Delete = "UPDATE FIVES_SY_CHECKGROUP SET ISDELETE = 1 WHERE GID = @GID";
        public MES_RETURN Create(FIVES_SY_CHECKGROUP model) {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@GMS",model.GMS),
                                        new SqlParameter("@FID",model.FID),
                                        new SqlParameter("@REMARK",model.REMARK),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKGROUP_Create");


            } 
            return mr; 
        }	
        public MES_RETURN Update(FIVES_SY_CHECKGROUP model) {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@GMS",model.GMS),
                                        new SqlParameter("@FID",model.FID),
                                        new SqlParameter("@REMARK",model.REMARK),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKGROUP_Update");

            } 
            return mr;  
        }
        public IList<FIVES_SY_CHECKGROUP> Read(FIVES_SY_CHECKGROUP model)
        {
            IList<FIVES_SY_CHECKGROUP> nodes = new List<FIVES_SY_CHECKGROUP>();
            SqlParameter[] parms = {
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@GMS",model.GMS),
                                        new SqlParameter("@FID",model.FID),
                                        new SqlParameter("@REMARK",model.REMARK),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKGROUP_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int ID) {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@GID",ID)
                                   };
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";

            } 
            catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKGROUP_Delete");



            } 
            return mr;
        }	
        private FIVES_SY_CHECKGROUP ReadDataToModel(SqlDataReader sdr) { 
            FIVES_SY_CHECKGROUP node = new FIVES_SY_CHECKGROUP();
            node.GID = Convert.ToInt32(sdr["GID"]);  //分组ID
            node.GMS = Convert.ToString(sdr["GMS"]);  //分组名称
            node.FID = Convert.ToInt32(sdr["FID"]);  //上级分组
            node.REMARK = Convert.ToString(sdr["REMARK"]);  //备注
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //是否激活
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除
            return node; 
        }


    }
}
