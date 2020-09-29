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
    public class SY_POINTCATEGROY_DETAIL : ISY_POINTCATEGROYDETAIL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_POINTCATEGROY_DETAIL_Create";
        private const string SQL_Update = "FIVES_SY_POINTCATEGROY_DETAIL_Update";
        private const string SQL_Read = "FIVES_SY_POINTCATEGROY_DETAIL_Read";
        private const string SQL_Delete = "DELETE FROM FIVES_SY_POINTCATEGROY_DETAIL WHERE CATEGROYID = @CATEGROYID AND DETAILID = @DETAILID";
        public MES_RETURN Create(FIVES_SY_POINTCATEGROY_DETAIL model) { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@CATEGROYID",model.CATEGROYID),
                                        new SqlParameter("@DETAILID",model.DETAILID)

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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_POINTCATEGROY_DETAIL_Create");

            } 
            return mr;
        }	
        public MES_RETURN Update(FIVES_SY_POINTCATEGROY_DETAIL model) { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                         new SqlParameter("@CATEGROYID",model.CATEGROYID),
                                         new SqlParameter("@DETAILID",model.DETAILID)
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_POINTCATEGROY_DETAIL_Update");

            } 
            return mr;
        }
        public IList<FIVES_SY_POINTCATEGROY_DETAILList> Read(FIVES_SY_POINTCATEGROY_DETAIL model)
        {
            IList<FIVES_SY_POINTCATEGROY_DETAILList> nodes = new List<FIVES_SY_POINTCATEGROY_DETAILList>();
            SqlParameter[] parms = {
                                         new SqlParameter("@CATEGROYID",model.CATEGROYID),
                                         new SqlParameter("@DETAILID",model.DETAILID)
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
        public MES_RETURN Delete(FIVES_SY_POINTCATEGROY_DETAIL model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                         new SqlParameter("@CATEGROYID",model.CATEGROYID),
                                        new SqlParameter("@DETAILID",model.DETAILID)
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_POINTCATEGROY_DETAIL_DELETE");

            }
            return mr;
        }
        private FIVES_SY_POINTCATEGROY_DETAILList ReadDataToModel(SqlDataReader sdr)
        {
            FIVES_SY_POINTCATEGROY_DETAILList node = new FIVES_SY_POINTCATEGROY_DETAILList();
            node.CATEGROYID = Convert.ToInt32(sdr["CATEGROYID"]);  //检查点分类ID
            node.DETAILID = Convert.ToInt32(sdr["DETAILID"]);  //检查明细ID
            node.CNAME = Convert.ToString(sdr["CNAME"]);
            node.DNAME = Convert.ToString(sdr["DNAME"]);
            return node;
        }

    }
}
