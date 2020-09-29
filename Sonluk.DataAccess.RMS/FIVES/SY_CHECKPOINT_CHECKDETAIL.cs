using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.FIVES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.FIVES
{
    public class SY_CHECKPOINT_CHECKDETAIL : ISY_CHECKPOINT_CHECKDETAIL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_CHECKPOINT_CHECKDETAIL_Create"; 
        private const string SQL_Update = "FIVES_SY_CHECKPOINT_CHECKDETAIL_Update";
        private const string SQL_Read   = "FIVES_SY_CHECKPOINT_CHECKDETAIL_Read";
        private const string SQL_Delete = "DELETE FROM FIVES_SY_CHECKPOINT_CHECKDETAI WHERE POINTID = @POINTID AND DETAILID = @DETAILID";
        public MES_RETURN Create(FIVES_SY_CHECKPOINT_CHECKDETAIL model)
        {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = { 
                                      new SqlParameter("@POINTID",model.POINTID),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_CHECKDETAIL_Create");

            } 
            return mr;
        }	
        public MES_RETURN Update(FIVES_SY_CHECKPOINT_CHECKDETAIL model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@POINTID",model.POINTID),
                                        new SqlParameter("@DETAILID",model.DETAILID)
                                   };
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_CHECKDETAIL_Update");

            }
            return mr; 
        }
        public IList<FIVES_SY_CHECKPOINT_CHECKDETAILLIST> Read(FIVES_SY_CHECKPOINT_CHECKDETAIL model)
        {
            IList<FIVES_SY_CHECKPOINT_CHECKDETAILLIST> nodes = new List<FIVES_SY_CHECKPOINT_CHECKDETAILLIST>();
            SqlParameter[] parms = { 
                                        new SqlParameter("@POINTID",model.POINTID),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_CHECKDETAIL_Read");
                throw new ApplicationException(e.Message);
            }

        }
        public MES_RETURN Delete(FIVES_SY_CHECKPOINT_CHECKDETAIL model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@POINTID",model.POINTID),
                                        new SqlParameter("@DETAILID",model.DETAILID)
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_CHECKDETAIL_Delete");

            } 
            return mr;
        }	
        private FIVES_SY_CHECKPOINT_CHECKDETAILLIST ReadDataToModel(SqlDataReader sdr)
        {
            FIVES_SY_CHECKPOINT_CHECKDETAILLIST node = new FIVES_SY_CHECKPOINT_CHECKDETAILLIST();
            node.POINTID = Convert.ToInt32(sdr["POINTID"]);  //检查点ID
            node.DETAILID = Convert.ToInt32(sdr["DETAILID"]);  //检查明细ID
            node.LNAME = Convert.ToString(sdr["LNAME"]);
            node.PNAME = Convert.ToString(sdr["PNAME"]);
            node.DNAME = Convert.ToString(sdr["DNAME"]);
            return node; 
        }


    }
}
