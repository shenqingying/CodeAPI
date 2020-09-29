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
    public class SY_MANUALPATH : ISY_MANUALPATH
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_MANUALPATH_Create";
        private const string SQL_Update = "EM_SY_MANUALPATH_Update";
        private const string SQL_Read = "EM_SY_MANUALPATH_Read";
        private const string SQL_Delete = "EM_SY_MANUALPATH_Delete";
        public MES_RETURN Create(EM_SY_MANUALPATH model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                    //new SqlParameter("@ID",model.ID),
                                    new SqlParameter("@CFLJ",model.CFLJ),
                                    new SqlParameter("@BBID",model.BBID),
                                    new SqlParameter("@CJR",model.CJR),
                                    new SqlParameter("@CJRNAME",model.CJRNAME),
                                    new SqlParameter("@JLTIME",model.JLTIME),
                                    new SqlParameter("@ISACTION",model.ISACTION),
                                    new SqlParameter("@ISDELETE",model.ISDELETE),
                                    new SqlParameter("@FILENAME",model.FILENAME),
                                    new SqlParameter("@FILESIZE",model.FILESIZE),
                                    new SqlParameter("@PATHID",model.PATHID),
                                    new SqlParameter("MS",model.MS)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUALPATH_Create");

            }
            return mr;
        }
        public MES_RETURN Update(EM_SY_MANUALPATH model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                           new SqlParameter("@ID",model.ID),
                                            new SqlParameter("@CFLJ",model.CFLJ),
                                            new SqlParameter("@BBID",model.BBID),
                                            new SqlParameter("@CJR",model.CJR),
                                            new SqlParameter("@CJRNAME",model.CJRNAME),
                                            new SqlParameter("@JLTIME",model.JLTIME),
                                            new SqlParameter("@ISACTION",model.ISACTION),
                                            new SqlParameter("@ISDELETE",model.ISDELETE),
                                            new SqlParameter("@FILENAME",model.FILENAME),
                                            new SqlParameter("@FILESIZE",model.FILESIZE),
                                            new SqlParameter("@PATHID",model.PATHID),
                                            new SqlParameter("MS",model.MS)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) { }
                mr.TYPE = "S";

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUALPATH_Update");

            }
            return mr;
        }
        public IList<EM_SY_MANUALPATH> Read(EM_SY_MANUALPATH model)
        {
            IList<EM_SY_MANUALPATH> nodes = new List<EM_SY_MANUALPATH>();
            SqlParameter[] parms = {
                                          new SqlParameter("@ID",model.ID),
                                        new SqlParameter("@CFLJ",model.CFLJ),
                                        new SqlParameter("@BBID",model.BBID),
                                        new SqlParameter("@CJR",model.CJR),
                                        new SqlParameter("@CJRNAME",model.CJRNAME),
                                        new SqlParameter("@JLTIME",model.JLTIME),
                                        new SqlParameter("@ISACTION",model.ISACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@FILENAME",model.FILENAME),
                                        new SqlParameter("MS",model.MS)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUALPATH_Read");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int ID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@ID",ID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUALPATH_Delete");

            }
            return mr;
        }
      





        private EM_SY_MANUALPATH ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_MANUALPATH node = new EM_SY_MANUALPATH();
            node.ID = Convert.ToInt32(sdr["ID"]);  //ID
            node.CFLJ = Convert.ToString(sdr["CFLJ"]);  //存放路径
            node.BBID = Convert.ToInt32(sdr["BBID"]);  //电子说明书版本ID
            node.CJR = Convert.ToInt32(sdr["CJR"]);  //创建人
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);  //创建人描述
            node.JLTIME = Convert.ToString(sdr["JLTIME"]);  //创建时间
            node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);  //是否激活
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);  //是否删除
            node.FILENAME = Convert.ToString(sdr["FILENAME"]);
            node.FILESIZE = Convert.ToString(sdr["FILESIZE"]);
            node.PATHID = Convert.ToInt32(sdr["PATHID"]);
            node.MS = Convert.ToString(sdr["MS"]);
            return node;
        }

    }
}
