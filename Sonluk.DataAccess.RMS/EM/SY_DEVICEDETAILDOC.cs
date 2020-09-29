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
    public class SY_DEVICEDETAILDOC : ISY_DEVICEDETAILDOC
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_DEVICEDETAILDOC_Create";
        private const string SQL_Update = "EM_SY_DEVICEDETAILDOC_Update";
        private const string SQL_Read = "EM_SY_DEVICEDETAILDOC_Read";
        private const string SQL_Delete = "EM_SY_DEVICEDETAILDOC_Delete";
        public MES_RETURN Create(EM_SY_DEVICEDETAILDOC model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        //new SqlParameter("@DOCID",model.DOCID),
                                        new SqlParameter("@MS",model.MS),
                                        new SqlParameter("@XH",model.XH),
                                        new SqlParameter("@LANGU",model.LANGU),
                                        new SqlParameter("@LANGUMS",model.LANGUMS),
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@BZ",model.BZ),
                                        new SqlParameter("@ISDELETE",model.ISDELETE)



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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_DEVICETYPE_Create");

            }
            return mr;
        }
        public MES_RETURN Update(EM_SY_DEVICEDETAILDOC model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@DOCID",model.DOCID),
                                        new SqlParameter("@MS",model.MS),
                                        new SqlParameter("@XH",model.XH),
                                        new SqlParameter("@LANGU",model.LANGU),
                                        new SqlParameter("@LANGUMS",model.LANGUMS),
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@BZ",model.BZ),
                                        new SqlParameter("@ISDELETE",model.ISDELETE)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_DEVICETYPE_Update");

            }
            return mr;
        }
        public IList<EM_SY_DEVICEDETAILDOC> Read(EM_SY_DEVICEDETAILDOC model)
        {
            IList<EM_SY_DEVICEDETAILDOC> nodes = new List<EM_SY_DEVICEDETAILDOC>();
            SqlParameter[] parms = {
                                        new SqlParameter("@DOCID",model.DOCID),
                                        new SqlParameter("@MS",model.MS),
                                        new SqlParameter("@XH",model.XH),
                                        new SqlParameter("@LANGU",model.LANGU),
                                        new SqlParameter("@LANGUMS",model.LANGUMS),
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@BZ",model.BZ),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_DEVICETYPE_Read");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int DOCID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@DOCID",DOCID),
                                       
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_DEVICETYPE_Delete");

            }
            return mr;
        }
        private EM_SY_DEVICEDETAILDOC ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_DEVICEDETAILDOC node = new EM_SY_DEVICEDETAILDOC();
            node.DOCID = Convert.ToInt32(sdr["DOCID"]);  //DOCID
            node.MS = Convert.ToString(sdr["MS"]);  //描述
            node.XH = Convert.ToInt32(sdr["XH"]);  //序号
            node.LANGU = Convert.ToInt32(sdr["LANGU"]);  //语言
            node.LANGUMS = Convert.ToString(sdr["LANGUMS"]);
            node.DID = Convert.ToInt32(sdr["DID"]);  //单机类型
            node.BZ = Convert.ToString(sdr["BZ"]);  //备注
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);  //是否删除



            return node;
        }
    }
}
