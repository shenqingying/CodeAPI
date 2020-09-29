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
    public class CHECK_INFODETAIL : ICHECK_INFODETAIL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_CHECK_INFODETAIL_Create";
        private const string SQL_Update = "FIVES_CHECK_INFODETAIL_Update";
        private const string SQL_Read = "FIVES_CHECK_INFODETAIL_Read";
        private const string SQL_Delete = "UPDATE FIVES_CHECK_INFODETAIL SET ISDELETE = 1 WHERE DETAILID = @DETAILID";
        private const string SQL_ReadLastCheck = "SELECT * from FIVES_CHECK_INFODETAIL where INFOID in(SELECT TOP 1 INFOID  FROM FIVES_CHECK_INFO where OPINTID = @pointid and action = 1 and isdelete = 0 order by JLTIME desc) and action = 1 and isdelete = 0";
        public MES_RETURN Create(List<FIVES_CHECK_INFODETAIL> model) { 
            MES_RETURN mr = new MES_RETURN();
            //SqlParameter[] parms = { 
            //                            new SqlParameter("@DETAILID",model.DETAILID),
            //                            new SqlParameter("@INFOID",model.INFOID),
            //                            new SqlParameter("@TYPEID",model.TYPEID),
            //                            new SqlParameter("@TYPEMS",model.TYPEMS),
            //                            new SqlParameter("@SCROEID",model.SCROEID),
            //                            new SqlParameter("@SCROEMS",model.SCROEMS),
            //                            new SqlParameter("@JLTIME",model.JLTIME),
            //                            new SqlParameter("@REMARK",model.REMARK),
            //                            new SqlParameter("@ACTION",model.ACTION),
            //                            new SqlParameter("@ISDELETE",model.ISDELETE)

            //                       }; 
            DataTable dt = new DataTable();
            dt.Columns.Add("DETAILID", typeof(string));
            dt.Columns.Add("INFOID", typeof(string));
            dt.Columns.Add("TYPEID", typeof(string));
            dt.Columns.Add("TYPEMS", typeof(string));
            dt.Columns.Add("SCROEID", typeof(string));
            dt.Columns.Add("SCROEMS", typeof(string));
            dt.Columns.Add("REMARK", typeof(string));
            dt.Columns.Add("ACTION", typeof(string));
            dt.Columns.Add("ISDELETE", typeof(string));
            if (model.Count == 0)
            {
                 mr.TYPE = "E";
                mr.MESSAGE = "传入新增数据为空！";
            }
            foreach (FIVES_CHECK_INFODETAIL node in model)
            {
                DataRow dr = dt.NewRow();
                dr[0] = node.DETAILID;
                dr[1] = node.INFOID;
                dr[2] = node.TYPEID;
                dr[3] = node.TYPEMS;
                dr[4] = node.SCROEID;
                dr[5] = node.SCROEMS;
                dr[6] = node.REMARK;
                dr[7] = node.ACTION;
                dr[8] = node.ISDELETE;
                dt.Rows.Add(dr);
            }

            SqlParameter[] parms = {
                                       new SqlParameter("@LIST",dt)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFODETAIL_Create");

            } 
            return mr; 
        }	
        public MES_RETURN Update(FIVES_CHECK_INFODETAIL model) {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                        new SqlParameter("@DETAILID",model.DETAILID),
                                        new SqlParameter("@INFOID",model.INFOID),
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@TYPEMS",model.TYPEMS),
                                        new SqlParameter("@SCROEID",model.SCROEID),
                                        new SqlParameter("@SCROEMS",model.SCROEMS),
                                        new SqlParameter("@JLTIME",model.JLTIME),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFODETAIL_Update");

            } 
            return mr; 
        }
        public IList<FIVES_CHECK_INFODETAILList> Read(FIVES_CHECK_INFODETAIL model)
        {
            IList<FIVES_CHECK_INFODETAILList> nodes = new List<FIVES_CHECK_INFODETAILList>();
            SqlParameter[] parms = {
                                        new SqlParameter("@DETAILID",model.DETAILID),
                                        new SqlParameter("@INFOID",model.INFOID),
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@TYPEMS",model.TYPEMS),
                                        new SqlParameter("@SCROEID",model.SCROEID),
                                        new SqlParameter("@SCROEMS",model.SCROEMS),
                                        new SqlParameter("@JLTIME",model.JLTIME),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFODETAIL_READ");
                throw new ApplicationException(e.Message);
            }
            
        }
        public IList<FIVES_CHECK_INFODETAILList> ReadLastCheck(int pointid)
        {
            IList<FIVES_CHECK_INFODETAILList> nodes = new List<FIVES_CHECK_INFODETAILList>();
            SqlParameter[] parms = {
                                        new SqlParameter("@pointid",pointid),
                                        
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_ReadLastCheck, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFODETAIL_READ");
                throw new ApplicationException(e.Message);
            }

        }
        public MES_RETURN Delete(int ID) {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                       new SqlParameter("@DETAILID",ID)
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";

            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFODETAIL_Delete");

            } 
            return mr; 
        }	
        private FIVES_CHECK_INFODETAILList ReadDataToModel(SqlDataReader sdr) {
            FIVES_CHECK_INFODETAILList node = new FIVES_CHECK_INFODETAILList();
            node.DETAILID = Convert.ToInt32(sdr["DETAILID"]);  //检查明细ID
            node.INFOID = Convert.ToInt32(sdr["INFOID"]);  //检查抬头ID
            node.TYPEID = Convert.ToInt32(sdr["TYPEID"]);  //检查明细类型ID
            node.TYPEMS = Convert.ToString(sdr["TYPEMS"]);  //检查明细描述
            node.SCROEID = Convert.ToInt32(sdr["SCROEID"]);  //明细结果
            node.SCROEMS = Convert.ToString(sdr["SCROEMS"]);  //明细结果描述
            node.JLTIME = Convert.ToString(sdr["JLTIME"]);  //记录时间
            node.REMARK = Convert.ToString(sdr["REMARK"]);  //备注
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //状态
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除
            return node; 
        }

    }
}
