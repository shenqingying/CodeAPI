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
    public class SY_STAFF_EMTYPE : ISY_STAFF_EMTYPE
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_STAFF_EMTYPE_Create";
        private const string SQL_Update = "EM_SY_STAFF_EMTYPE_Update";
        private const string SQL_Read = "EM_SY_STAFF_EMTYPE_Read";
        private const string SQL_Delete = "EM_SY_STAFF_EMTYPE_Delete";
        private const string SQL_SELECT_EMTYPE_ROLE = "EM_SY_SELECT_EMTYPE_ROLE";
        private const string SQL_Read_BYTYPENAME = "EM_SY_STAFF_EMTYPE_ReadBYTYPENAME";
        
        public EM_SY_EMTYPE_LAY_SELECT SELECT_EMTYPE_ROLE(int STAFFID)
        {
            EM_SY_EMTYPE_LAY_SELECT node = new EM_SY_EMTYPE_LAY_SELECT();
            List<EM_SY_EMTYPE_LAY_LIST> nodes_list = new List<EM_SY_EMTYPE_LAY_LIST>();
            node.EM_SY_EMTYPE_LAY_LIST = nodes_list;
            MES_RETURN mr = new MES_RETURN();
            try
            {

                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_EMTYPE_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        EM_SY_EMTYPE_LAY_LIST child = new EM_SY_EMTYPE_LAY_LIST();
                        child.EMTYPEID = Convert.ToInt32(sdr["ID"]);
                        child.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
                        child.MXNAME = Convert.ToString(sdr["MXNAME"]);
                        if (Convert.ToInt32(sdr["STAFFID"]) > 0)
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        nodes_list.Add(child);
                    }
                }
                mr.TYPE = "S";
                mr.MESSAGE = "";
                node.MES_RETURN = mr;
                node.EM_SY_EMTYPE_LAY_LIST = nodes_list;
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                node.MES_RETURN = mr;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ZJH_ROLE_SELECT", "HR");
            }
            return node;
        }
        public MES_RETURN Create(EM_SY_STAFF_EMTYPE model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@EMTYPEID",model.EMTYPEID),
                                        new SqlParameter("@STAFFID",model.STAFFID)




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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_STAFF_EMTYPE_Create");

            }
            return mr;
        }
       
        public MES_RETURN Update(EM_SY_STAFF_EMTYPE model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                           new SqlParameter("@EMTYPEID",model.EMTYPEID),
                                        new SqlParameter("@STAFFID",model.STAFFID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_STAFF_EMTYPE_Update");

            }
            return mr;
        }
        public IList<EM_SY_STAFF_EMTYPE> ReadByEMTYPEMS(int staffid, string typems)
        {
            IList<EM_SY_STAFF_EMTYPE> nodes = new List<EM_SY_STAFF_EMTYPE>();
            SqlParameter[] parms = {
                                         new SqlParameter("@EMTYPENAME",typems),
                                        new SqlParameter("@STAFFID",staffid)
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_BYTYPENAME, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_STAFF_EMTYPE_Read");
                throw new ApplicationException(e.Message);
            }
        }
        public IList<EM_SY_STAFF_EMTYPE> Read(EM_SY_STAFF_EMTYPE model)
        {
            IList<EM_SY_STAFF_EMTYPE> nodes = new List<EM_SY_STAFF_EMTYPE>();
            SqlParameter[] parms = {
                                         new SqlParameter("@EMTYPEID",model.EMTYPEID),
                                        new SqlParameter("@STAFFID",model.STAFFID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_STAFF_EMTYPE_Read");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(EM_SY_STAFF_EMTYPE model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@EMTYPEID",model.EMTYPEID),
                                        new SqlParameter("@STAFFID",model.STAFFID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_STAFF_EMTYPE_Delete");

            }
            return mr;
        }
        private EM_SY_STAFF_EMTYPE ReadDataToModel(SqlDataReader sdr)
        {
            EM_SY_STAFF_EMTYPE node = new EM_SY_STAFF_EMTYPE();
            node.EMTYPEID = Convert.ToInt32(sdr["EMTYPEID"]);  //指导书类别ID
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);  //人员ID


            return node;
        }
    }
}
