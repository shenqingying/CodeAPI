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
    public class STAFF_DEP:ISTAFF_DEP
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_STAFF_DEP_Create";
        private const string SQL_Update = "FIVES_STAFF_DEP_Update";
        private const string SQL_Read = "FIVES_STAFF_DEP_Read";
        private const string SQL_Delete = "FIVES_STAFF_DEP_DELETE";

        public MES_RETURN Create(FIVES_STAFF_DEP model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@DEPTID",model.DEPTID),
                                        new SqlParameter("@TYPEID",model.TYPEID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_STAFF_DEP_INSERT");
            }
            return mr;
        }
        public MES_RETURN Update(FIVES_STAFF_DEP model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@DEPTID",model.DEPTID),
                                        new SqlParameter("@TYPEID",model.TYPEID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms))
                { }
                mr.TYPE = "E";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_STAFF_DEP_UPDATE");
            }
            return mr;
        }
        public MES_RETURN Delete(FIVES_STAFF_DEP model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@DEPTID",model.DEPTID),
                                        new SqlParameter("@TYPEID",model.TYPEID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_STAFF_DEP_DELETE");
            }
            return mr;
        }
        public IList<FIVES_STAFF_DEP> Read(FIVES_STAFF_DEP model)
        {
            IList<FIVES_STAFF_DEP> nodes = new List<FIVES_STAFF_DEP>();
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@DEPTID",model.DEPTID),
                                        new SqlParameter("@TYPEID",model.TYPEID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_STAFF_DEP_READ");
                throw new ApplicationException(e.Message);
            }
        }
        private FIVES_STAFF_DEP ReadDataToModel(SqlDataReader sdr)
        {
            FIVES_STAFF_DEP node = new FIVES_STAFF_DEP();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);  //人员ID
            node.DEPTID = Convert.ToInt32(sdr["DEPTID"]);  //部门ID
            node.TYPEID = Convert.ToInt32(sdr["TYPEID"]);  //检查类型
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
            node.TYPENAME = Convert.ToString(sdr["TYPENAME"]);
            return node;
        }

    }
}
