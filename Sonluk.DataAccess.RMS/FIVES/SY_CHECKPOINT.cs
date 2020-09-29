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
    public class SY_CHECKPOINT : ISY_CHECKPOINT
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_CHECKPOINT_Create";
        private const string SQL_Update = "FIVES_SY_CHECKPOINT_Update";
        private const string SQL_Read = "FIVES_SY_CHECKPOINT_Read";
        private const string SQL_Delete = "FIVES_SY_CHECKPOINT_DELETE";//UPDATE FIVES_SY_CHECKPOINT SET ISDELETE = 1 WHERE  POINTID = @POINTID ;
        private const string SQL_Compare = "FIVES_SY_CHECKPOINT_Compare";
        public MES_RETURN Create(FIVES_SY_CHECKPOINT model) {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                        new SqlParameter("@POINTID",model.POINTID),
                                        new SqlParameter("@LOCATIONMS",model.LOCATIONMS),
                                        new SqlParameter("@POINTMS",model.POINTMS),
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@DJ",model.DJ),
                                        new SqlParameter("@FREQUENCY",model.FREQUENCY),
                                        new SqlParameter("@ISNEED",model.ISNEED),
                                        new SqlParameter("@CODE",model.CODE)
                                    //    new SqlParameter("@VIEWS",model.VIEWS)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_Create");

            } 
            return mr;
        }	
        public MES_RETURN Update(FIVES_SY_CHECKPOINT model) {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = { 
                                        new SqlParameter("@POINTID",model.POINTID),
                                        new SqlParameter("@LOCATIONMS",model.LOCATIONMS),
                                        new SqlParameter("@POINTMS",model.POINTMS),
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@DJ",model.DJ),
                                        new SqlParameter("@FREQUENCY",model.FREQUENCY),
                                        new SqlParameter("@ISNEED",model.ISNEED),
                                        new SqlParameter("@CODE",model.CODE)
                                      //  new SqlParameter("@VIEWS",model.VIEWS)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_Update");

            } 
            return mr; 
        }
        public IList<FIVES_SY_CHECKPOINT> Read(FIVES_SY_CHECKPOINT model)
        {
            IList<FIVES_SY_CHECKPOINT> nodes = new List<FIVES_SY_CHECKPOINT>();
            SqlParameter[] parms = { 
                                        new SqlParameter("@POINTID",model.POINTID),
                                        new SqlParameter("@LOCATIONMS",model.LOCATIONMS),
                                        new SqlParameter("@POINTMS",model.POINTMS),
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@DJ",model.DJ)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public IList<FIVES_SY_CHECKPOINT> Compare(FIVES_SY_CHECKPOINT model)
        {
            IList<FIVES_SY_CHECKPOINT> nodes = new List<FIVES_SY_CHECKPOINT>();
            SqlParameter[] parms = { 
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@POINTID",model.POINTID),
                                        new SqlParameter("@KSTIME",model.KSTIME),
                                        new SqlParameter("@JSTIME",model.JSTIME),
                                        new SqlParameter("@NUM",model.NUM)
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Compare, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToCompareList(sdr));
                    }
                }
                return nodes;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_Compare");
                throw new ApplicationException(e.Message);
            }
        }
        public IList<FIVES_SY_CHECKPOINTList> ReadaddDepName(FIVES_SY_CHECKPOINT model)
        {
            IList<FIVES_SY_CHECKPOINTList> nodes = new List<FIVES_SY_CHECKPOINTList>();
            SqlParameter[] parms = { 
                                        new SqlParameter("@POINTID",model.POINTID),
                                        new SqlParameter("@LOCATIONMS",model.LOCATIONMS),
                                        new SqlParameter("@POINTMS",model.POINTMS),
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@DJ",model.DJ)
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToModelList(sdr));
                    }
                }
                return nodes;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_READ");
                throw new ApplicationException(e.Message);
            }
        }

        public MES_RETURN Delete(int ID) { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@POINTID",ID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_CHECKPOINT_Delete");

            } 
            return mr;
        }	
        private FIVES_SY_CHECKPOINT ReadDataToModel(SqlDataReader sdr) {
            FIVES_SY_CHECKPOINT node = new FIVES_SY_CHECKPOINT();
            node.POINTID = Convert.ToInt32(sdr["POINTID"]);  //检查点ID
            node.LOCATIONMS = Convert.ToString(sdr["LOCATIONMS"]);  //检查点位置
            node.POINTMS = Convert.ToString(sdr["POINTMS"]);  //检查点描述
            node.DID = Convert.ToInt32(sdr["DID"]);  //部门ID
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //状态
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除
            node.DJ = Convert.ToInt32(sdr["DJ"]);
            node.FREQUENCY = Convert.ToInt16(sdr["FREQUENCY"]);  //频率
            node.FREQUENCYNAME = Convert.ToString(sdr["FREQUENCYNAME"]);//频率描述
            node.ISNEED = Convert.ToInt16(sdr["ISNEED"]);  //显示是否需要点检人员
            node.CODE = Convert.ToString(sdr["CODE"]);  //排序字段
           // node.VIEWS = Convert.ToString(sdr["VIEWS"]);
            return node; 
        }
        private FIVES_SY_CHECKPOINTList ReadDataToModelList(SqlDataReader sdr)
        {
            FIVES_SY_CHECKPOINTList node = new FIVES_SY_CHECKPOINTList();
            node.POINTID = Convert.ToInt32(sdr["POINTID"]);  //检查点ID
            node.LOCATIONMS = Convert.ToString(sdr["LOCATIONMS"]);  //检查点位置
            node.POINTMS = Convert.ToString(sdr["POINTMS"]);  //检查点描述
            node.DID = Convert.ToInt32(sdr["DID"]);  //部门ID
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //状态
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除
            node.DNAME = Convert.ToString(sdr["DNAME"]);
            node.DJ = Convert.ToInt32(sdr["DJ"]);
            node.FREQUENCY = Convert.ToInt16(sdr["FREQUENCY"]);  //频率
            node.FREQUENCYNAME = Convert.ToString(sdr["FREQUENCYNAME"]);//频率描述
            node.ISNEED = Convert.ToInt16(sdr["ISNEED"]);  //显示是否需要点检人员
            node.CODE = Convert.ToString(sdr["CODE"]);
          //  node.VIEWS = Convert.ToString(sdr["VIEWS"]);
            return node;
        }
        private FIVES_SY_CHECKPOINT ReadDataToCompareList(SqlDataReader sdr)
        {
            FIVES_SY_CHECKPOINT node = new FIVES_SY_CHECKPOINT();
            node.POINTID = Convert.ToInt32(sdr["POINTID"]);  //检查点ID
            node.LOCATIONMS = Convert.ToString(sdr["LOCATIONMS"]);  //检查点位置
            node.POINTMS = Convert.ToString(sdr["POINTMS"]);  //检查点描述
            node.DID = Convert.ToInt32(sdr["DID"]);  //部门ID
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //状态
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除
            node.DJ = Convert.ToInt32(sdr["DJ"]);
            node.INFOID = Convert.ToInt32(sdr["INFOID"]);
            node.DEPARTMS = Convert.ToString(sdr["DEPARTMS"]);
            return node;
        }

    }
}
