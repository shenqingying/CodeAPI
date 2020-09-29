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
    public class SY_MANUALBB : ISY_MANUALBB
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_MANUALBB_Create";
        private const string SQL_Update = "EM_SY_MANUALBB_Update";
        private const string SQL_Read = "EM_SY_MANUALBB_Read";
        private const string SQL_Delete = "EM_SY_MANUALBB_Delete";
        public MES_RETURN Create(EM_SY_MANUALBB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       //new SqlParameter("@BBID",model.BBID),
                                new SqlParameter("@BBNAME",model.BBNAME),
                                new SqlParameter("@MANUALID",model.MANUALID),
                                new SqlParameter("@JLTIME",model.JLTIME),
                                new SqlParameter("@CJR",model.CJR),
                                new SqlParameter("@CJRNAME",model.CJRNAME),
                                new SqlParameter("@ISACTION",model.ISACTION),
                                new SqlParameter("@ISDELETE",model.ISDELETE),
                                new SqlParameter("@TM",model.TM),
                                new SqlParameter("@LANGU",model.LANGU),
                                new SqlParameter("@LANGUMS",model.LANGUMS)
                                
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUALBB_Create");

            }
            return mr;
        }
        public MES_RETURN Update(EM_SY_MANUALBB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@BBID",model.BBID),
                                        new SqlParameter("@BBNAME",model.BBNAME),
                                        new SqlParameter("@MANUALID",model.MANUALID),
                                        new SqlParameter("@JLTIME",model.JLTIME),
                                        new SqlParameter("@CJR",model.CJR),
                                        new SqlParameter("@CJRNAME",model.CJRNAME),
                                        new SqlParameter("@ISACTION",model.ISACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@TM",model.TM),
                                        new SqlParameter("@LANGU",model.LANGU),
                                        new SqlParameter("@LANGUMS",model.LANGUMS)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUALBB_Update");

            }
            return mr;
        }
        public IList<EM_SY_MANUALBB> Read(EM_SY_MANUALBB model)
        {
            IList<EM_SY_MANUALBB> nodes = new List<EM_SY_MANUALBB>();
            SqlParameter[] parms = {
                                        new SqlParameter("@BBID",model.BBID),
                                        new SqlParameter("@BBNAME",model.BBNAME),
                                        new SqlParameter("@MANUALID",model.MANUALID),
                                        new SqlParameter("@JLTIME",model.JLTIME),
                                        new SqlParameter("@CJR",model.CJR),
                                        new SqlParameter("@CJRNAME",model.CJRNAME),
                                        new SqlParameter("@ISACTION",model.ISACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@TM",model.TM),
                                        new SqlParameter("@LANGU",model.LANGU),
                                        new SqlParameter("@LANGUMS",model.LANGUMS)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUALBB_Read");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int BBID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@BBID",BBID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Delete, parms)) { }
                mr.TYPE = "S";


            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUALBB_Delete");

            }
            return mr;
        }
        private EM_SY_MANUALBB ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_MANUALBB node = new EM_SY_MANUALBB();
            node.BBID = Convert.ToInt32(sdr["BBID"]);  //版本ID
            node.BBNAME = Convert.ToString(sdr["BBNAME"]);  //版本号
            node.MANUALID = Convert.ToInt32(sdr["MANUALID"]);  //说明书ID
            node.JLTIME = Convert.ToString(sdr["JLTIME"]);  //创建时间
            node.CJR = Convert.ToInt32(sdr["CJR"]);  //创建人
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);  //创建人描述
            node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);  //是否激活
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);  //是否删除
            node.TM = Convert.ToString(sdr["TM"]);  //说明书版本条码（说明书条码+版本号生成）
            node.LANGU = Convert.ToInt32(sdr["LANGU"]);
            node.LANGUMS = Convert.ToString(sdr["LANGUMS"]);
            return node;
        }
    }
}
