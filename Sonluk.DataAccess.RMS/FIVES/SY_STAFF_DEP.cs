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
    public class SY_STAFF_DEP : ISY_STAFF_DEP
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_STAFF_DEP_Create"; 
        private const string SQL_Update = "FIVES_SY_STAFF_DEP_Update"; 
        private const string SQL_Read = "FIVES_SY_STAFF_DEP_Read"; 
        private const string SQL_Delete = "DELETE FROM FIVES_SY_STAFF_DEP WHERE STAFFID = @STAFFID";
        
        public MES_RETURN Create(FIVES_SY_STAFF_DEP model) { 
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = { 
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@DEPID",model.DEPID),
                                        new SqlParameter("@XJSTATUS",model.XJSTATUS),
                                        new SqlParameter("@CJSTATUS",model.CJSTATUS),
                                        new SqlParameter("@TZSTATUS",model.TZSTATUS),
                                        new SqlParameter("@XFDJSTATUS",model.XFDJSTATUS),
                                        new SqlParameter("@STDJSTATUS",model.STDJSTATUS),
                                        new SqlParameter("@JFDJSTATUS",model.JFDJSTATUS)

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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_STAFF_DEP_INSERT");
            } 
            return mr;
        }	
        public MES_RETURN Update(FIVES_SY_STAFF_DEP model) { 
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@DEPID",model.DEPID),
                                        new SqlParameter("@XJSTATUS",model.XJSTATUS),
                                        new SqlParameter("@CJSTATUS",model.CJSTATUS),
                                        new SqlParameter("@TZSTATUS",model.TZSTATUS),
                                        new SqlParameter("@XFDJSTATUS",model.XFDJSTATUS),
                                        new SqlParameter("@STDJSTATUS",model.STDJSTATUS),
                                        new SqlParameter("@JFDJSTATUS",model.JFDJSTATUS)
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms))
                {} 
                mr.TYPE = "E";
            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_STAFF_DEP_UPDATE");
            }
            return mr;
        }
        public MES_RETURN Delete(FIVES_SY_STAFF_DEP model)
        { 
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = { 
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@DEPID",model.DEPID),
                                        new SqlParameter("@XJSTATUS",model.XJSTATUS),
                                        new SqlParameter("@CJSTATUS",model.CJSTATUS),
                                        new SqlParameter("@TZSTATUS",model.TZSTATUS),
                                   }; 
            try {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";
            } catch (Exception e) {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_STAFF_DEP_DELETE");
            }
            return mr;
        }
        public IList<FIVES_SY_STAFF_DEPList> Read(FIVES_SY_STAFF_DEP model)
        {
            IList<FIVES_SY_STAFF_DEPList> nodes = new List<FIVES_SY_STAFF_DEPList>();
            SqlParameter[] parms = { 
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@DEPID",model.DEPID),
                                        new SqlParameter("@XJSTATUS",model.XJSTATUS),
                                        new SqlParameter("@CJSTATUS",model.CJSTATUS),
                                        new SqlParameter("@TZSTATUS",model.TZSTATUS),
                                        new SqlParameter("@OPINTID",model.OPINTID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_STAFF_DEP_READ");
                throw new ApplicationException(e.Message);
            }
        }
        private FIVES_SY_STAFF_DEPList ReadDataToModel(SqlDataReader sdr) {
            FIVES_SY_STAFF_DEPList node = new FIVES_SY_STAFF_DEPList();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);  //人员ID
            node.DEPID = Convert.ToInt32(sdr["DEPID"]);  //部门ID
            node.XJSTATUS = Convert.ToInt32(sdr["XJSTATUS"]);  //巡检状态
            node.CJSTATUS = Convert.ToInt32(sdr["CJSTATUS"]);  //抽检状态
            node.DNAME = Convert.ToString(sdr["DNAME"]);
            node.SNAME = Convert.ToString(sdr["SNAME"]);
            node.CID = Convert.ToInt32(sdr["CID"]);
            node.XID = Convert.ToInt32(sdr["XID"]);
            node.CNAME = Convert.ToString(sdr["CNAME"]);
            node.XNAME = Convert.ToString(sdr["XNAME"]);
            node.TZSTATUS = Convert.ToInt32(sdr["TZSTATUS"]);
            node.XFDJSTATUS = Convert.ToInt32(sdr["XFDJSTATUS"]);
            node.STDJSTATUS = Convert.ToInt32(sdr["STDJSTATUS"]);
            node.JFDJSTATUS = Convert.ToInt32(sdr["JFDJSTATUS"]);
            node.XFDJID = Convert.ToInt32(sdr["XFDJID"]);
            node.STDJID = Convert.ToInt32(sdr["STDJID"]);
            node.JFDJID = Convert.ToInt32(sdr["JFDJID"]);
            node.XFDJNAME = Convert.ToString(sdr["XFDJNAME"]);
            node.STDJNAME = Convert.ToString(sdr["STDJNAME"]);
            node.JFDJNAME = Convert.ToString(sdr["JFDJNAME"]);



            return node; 
        }


    }
}
