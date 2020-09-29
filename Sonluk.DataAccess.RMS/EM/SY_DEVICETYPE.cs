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
    public class SY_DEVICETYPE : ISY_DEVICETYPE
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_DEVICETYPE_Create";
        private const string SQL_Update = "EM_SY_DEVICETYPE_Update";
        private const string SQL_Read = "EM_SY_DEVICETYPE_Read";
        private const string SQL_Delete = "EM_SY_DEVICETYPE_Delete";
        public MES_RETURN Create(EM_SY_DEVICETYPE model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        //new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@DMS",model.DMS),
                                        new SqlParameter("@XH",model.XH),
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
        public MES_RETURN Update(EM_SY_DEVICETYPE model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@DMS",model.DMS),
                                        new SqlParameter("@XH",model.XH),
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
        public IList<EM_SY_DEVICETYPE> Read(EM_SY_DEVICETYPE model)
        {
            IList<EM_SY_DEVICETYPE> nodes = new List<EM_SY_DEVICETYPE>();
            SqlParameter[] parms = {
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@DMS",model.DMS),
                                        new SqlParameter("@XH",model.XH),
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
        public MES_RETURN Delete(int DID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@DID",DID),
                                       
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
        private EM_SY_DEVICETYPE ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_DEVICETYPE node = new EM_SY_DEVICETYPE();
            node.DID = Convert.ToInt32(sdr["DID"]);  //DID
            node.DMS = Convert.ToString(sdr["DMS"]);  //设备类型描述
            node.XH = Convert.ToInt32(sdr["XH"]);  //序号
            node.BZ = Convert.ToString(sdr["BZ"]);  //备注
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);  //是否删除


            return node;
        }



    }
}
