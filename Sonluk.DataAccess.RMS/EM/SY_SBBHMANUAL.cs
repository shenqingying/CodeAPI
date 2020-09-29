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
    public class SY_SBBHMANUAL : ISY_SBBHMANUAL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_SBBHMANUAL_Create";
        private const string SQL_Update = "EM_SY_SBBHMANUAL_Update";
        private const string SQL_Read = "EM_SY_SBBHMANUAL_Read";
        private const string SQL_Delete = "EM_SY_SBBHMANUAL_Delete";
        public MES_RETURN Create(EM_SY_SBBHMANUAL model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        //new SqlParameter("@DID",model.DID),
                                        new SqlParameter("@SBBH",model.SBBH),
                                        new SqlParameter("@MANUALID",model.MANUALID),
                                        new SqlParameter("@XH",model.XH)



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
        public MES_RETURN Update(EM_SY_SBBHMANUAL model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@SBBH",model.SBBH),
                                        new SqlParameter("@MANUALID",model.MANUALID),
                                        new SqlParameter("@XH",model.XH)
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
        public IList<EM_SY_SBBHMANUAL> Read(EM_SY_SBBHMANUAL model)
        {
            IList<EM_SY_SBBHMANUAL> nodes = new List<EM_SY_SBBHMANUAL>();
            SqlParameter[] parms = {
                                        new SqlParameter("@SBBH",model.SBBH),
                                        new SqlParameter("@MANUALID",model.MANUALID),
                                        new SqlParameter("@XH",model.XH)
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
        public MES_RETURN Delete(EM_SY_SBBHMANUAL model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@SBBH",model.SBBH),
                                        new SqlParameter("@MANUALID",model.MANUALID),
                                       
                                       
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
        private EM_SY_SBBHMANUAL ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_SBBHMANUAL node = new EM_SY_SBBHMANUAL();
            node.SBBH = Convert.ToString(sdr["SBBH"]);  //设备编号
            node.MANUALID = Convert.ToInt32(sdr["MANUALID"]);  //电子文档ID
            node.XH = Convert.ToInt32(sdr["XH"]);  //序号
            node.MANUALMS = Convert.ToString(sdr["MANUALMS"]);
            node.SBBHMS = Convert.ToString(sdr["SBBHMS"]);


            return node;
        }

    }
}
