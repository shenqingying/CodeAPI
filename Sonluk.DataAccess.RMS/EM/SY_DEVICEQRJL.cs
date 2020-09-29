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
    public class SY_DEVICEQRJL : ISY_DEVICEQRJL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_DEVICEQRJL_Create";
        //private const string SQL_Update = "EM_SY_DEVICETYPE_Update";
        private const string SQL_Read = "EM_SY_DEVICEQRJL_Read";
        //private const string SQL_Delete = "EM_SY_DEVICETYPE_Delete";
        public MES_RETURN Create(EM_SY_DEVICEQRJL model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        //new SqlParameter("@ID",model.ID),
                                        new SqlParameter("@SBBH",model.SBBH),
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@TYPE",model.TYPE),
                                        new SqlParameter("@BZ",model.BZ),
                                        new SqlParameter("@CJTIME",model.CJTIME),
                                        new SqlParameter("@CJR",model.CJR),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@MACADRESS",model.MACADRESS)
                                        


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
        public IList<EM_SY_DEVICEQRJL> Read(EM_SY_DEVICEQRJL model)
        {
            IList<EM_SY_DEVICEQRJL> nodes = new List<EM_SY_DEVICEQRJL>();
            SqlParameter[] parms = {
                                        new SqlParameter("@ID",model.ID),
                                        new SqlParameter("@SBBH",model.SBBH),
                                        new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@TYPE",model.TYPE),
                                        new SqlParameter("@BZ",model.BZ),
                                        new SqlParameter("@KSTIME",model.KSTIME),
                                        new SqlParameter("@JSTIME",model.JSTIME),
                                        new SqlParameter("@CJR",model.CJR),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@MACADRESS",model.MACADRESS)
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
        private EM_SY_DEVICEQRJL ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_DEVICEQRJL node = new EM_SY_DEVICEQRJL();
            node.ID = Convert.ToInt32(sdr["ID"]);  //ID
            node.SBBH = Convert.ToString(sdr["SBBH"]);  //设备编号
            node.DID = Convert.ToInt32(sdr["DID"]);  //单机类型
            node.TYPE = Convert.ToString(sdr["TYPE"]);  //确认类型·
            node.BZ = Convert.ToString(sdr["BZ"]);  //备注
            node.CJTIME = Convert.ToString(sdr["CJTIME"]);  //创建时间
            node.CJR = Convert.ToInt32(sdr["CJR"]);  //创建人
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);  //创建人
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);  //是否删除
            node.SBMS = Convert.ToString(sdr["SBMS"]);
            node.MACADRESS = Convert.ToString(sdr["MACADRESS"]);

            return node;
        }
    }
}
