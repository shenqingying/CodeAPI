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
    public class SY_CHECKDETAILS : ISY_CHECKDETAILS
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_CHECKDETAILS_Create";
        private const string SQL_Update = "FIVES_SY_CHECKDETAILS_Update";
        private const string SQL_Read = "FIVES_SY_CHECKDETAILS_Read";
        private const string SQL_Delete = "FIVES_SY_CHECKDETAILS_DELETE";//"UPDATE  FIVES_SY_CHECKDETAILS SET ISDELETE = 1 WHERE DETAILID = @DETAILID";
        public MES_RETURN Create(FIVES_SY_CHECKDETAILS model) { 
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                       new SqlParameter("@DETAILID",model.DETAILID),
                                        new SqlParameter("@CATEGROYID",model.CATEGROYID),
                                        new SqlParameter("@DETAILMS",model.DETAILMS),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKDETAILS_Create");

            } 
            return mr; 
        }	
        public MES_RETURN Update(FIVES_SY_CHECKDETAILS model) { 
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                        new SqlParameter("@DETAILID",model.DETAILID),
                                        new SqlParameter("@CATEGROYID",model.CATEGROYID),
                                        new SqlParameter("@DETAILMS",model.DETAILMS),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE)
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKDETAILS_Update");

            } 
            return mr;
        }
        public IList<FIVES_SY_CHECKDETAILSList> Read(FIVES_SY_CHECKDETAILS model)
        {
            IList<FIVES_SY_CHECKDETAILSList> nodes = new List<FIVES_SY_CHECKDETAILSList>();
            SqlParameter[] parms = {
                                         new SqlParameter("@DETAILID",model.DETAILID),
                                        new SqlParameter("@CATEGROYID",model.CATEGROYID),
                                        new SqlParameter("@DETAILMS",model.DETAILMS),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKDETAILS_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int ID) {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                        new SqlParameter("@DETAILID",ID)
                                   };
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Delete, parms)) {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
               

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKDETAILS_Delete");

            } 
            return mr; 
        }	
        private FIVES_SY_CHECKDETAILSList ReadDataToModel(SqlDataReader sdr) {
            FIVES_SY_CHECKDETAILSList node = new FIVES_SY_CHECKDETAILSList();
            node.DETAILID = Convert.ToInt32(sdr["DETAILID"]);  //检查明细ID
            node.CATEGROYID = Convert.ToInt32(sdr["CATEGROYID"]);  //检查分类ID
            node.DETAILMS = Convert.ToString(sdr["DETAILMS"]);  //检查明细描述
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //状态
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除
            node.CNAME = Convert.ToString(sdr["CNAME"]);

            return node;
        }

    }
}
