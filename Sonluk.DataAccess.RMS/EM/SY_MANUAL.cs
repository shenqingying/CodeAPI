using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.EM
{
    public class SY_MANUAL : ISY_MANUAL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_MANUAL_Create";
        private const string SQL_Update = "EM_SY_MANUAL_Update";
        private const string SQL_Read = "EM_SY_MANUAL_Read";
        private const string SQL_Delete = "EM_SY_MANUAL_Delete";
        public MES_RETURN Create(EM_SY_MANUAL model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        //new SqlParameter("@MANUALID",model.MANUALID),
                                        new SqlParameter("@GC",model.GC),
                                        new SqlParameter("@TM",model.TM),
                                        new SqlParameter("@TYPE",model.TYPE),
                                        new SqlParameter("@TYPENAME",model.TYPENAME),
                                        new SqlParameter("@REMARK",model.REMARK),
                                        new SqlParameter("@CJR",model.CJR),
                                        new SqlParameter("@CJRNAME",model.CJRNAME),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@MANUALMS",model.MANUALMS)

                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Create, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUAL_Create");

            }
            return mr;
        }
        public MES_RETURN Update(EM_SY_MANUAL model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@MANUALID",model.MANUALID),
                                        new SqlParameter("@GC",model.GC),
                                        new SqlParameter("@TM",model.TM),
                                        new SqlParameter("@TYPE",model.TYPE),
                                        new SqlParameter("@TYPENAME",model.TYPENAME),
                                        new SqlParameter("@REMARK",model.REMARK),
                                        new SqlParameter("@CJR",model.CJR),
                                        new SqlParameter("@CJRNAME",model.CJRNAME),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@MANUALMS",model.MANUALMS)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUAL_Update");

            }
            return mr;
        }
        public IList<EM_SY_MANUAL> Read(EM_SY_MANUAL model)
        {
            IList<EM_SY_MANUAL> nodes = new List<EM_SY_MANUAL>();
            SqlParameter[] parms = {
                                        new SqlParameter("@MANUALID",model.MANUALID),
                                        new SqlParameter("@GC",model.GC),
                                        new SqlParameter("@TM",model.TM),
                                        new SqlParameter("@TYPE",model.TYPE),
                                        new SqlParameter("@TYPENAME",model.TYPENAME),
                                        new SqlParameter("@REMARK",model.REMARK),
                                        new SqlParameter("@CJR",model.CJR),
                                        new SqlParameter("@CJRNAME",model.CJRNAME),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@MANUALMS",model.MANUALMS)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFO_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int MANUALID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@MANUALID",MANUALID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Delete, parms)) {
                    sdr.Read();
                    mr.TYPE = Convert.ToString(sdr["TYPE"]);
                    mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                }
               


            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUAL_Delete");

            }
            return mr;
        }	
        private EM_SY_MANUAL ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_MANUAL node = new EM_SY_MANUAL();
            node.MANUALID = Convert.ToInt32(sdr["MANUALID"]);  //说明书ID
            node.GC = Convert.ToString(sdr["GC"]);  //工厂
            node.TM = Convert.ToString(sdr["TM"]);  //说明书条码（包装作业指导书放物料号）
            node.TYPE = Convert.ToInt32(sdr["TYPE"]);  //说明书类别ID
            node.TYPENAME = Convert.ToString(sdr["TYPENAME"]);  //说明书类别描述
            node.REMARK = Convert.ToString(sdr["REMARK"]);  //备注
            node.CJR = Convert.ToInt32(sdr["CJR"]);  //创建人
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);  //创建人描述
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);  //是否删除
            node.MANUALMS = Convert.ToString(sdr["MANUALMS"]);
            node.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.BBNAME = Convert.ToString(sdr["BBNAME"]);
            return node;
        }
        
    }
}
