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
    public class SY_DEPTPUSHRY : ISY_DEPTPUSHRY
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_DEPTPUSHRY_Create";

        private const string SQL_Read = "FIVES_SY_DEPTPUSHRY_Read";
        private const string SQL_Delete = "DELETE FROM FIVES_SY_DEPTPUSHRY WHERE STAFFID = @STAFFID";
        public MES_RETURN Create(FIVES_SY_DEPTPUSHRY model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {                                     
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@DEPTID",model.DEPTID)
                                       

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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_DEPTPUSHRY_Create");
            }
            return mr;
        }

        public IList<FIVES_SY_DEPTPUSHRY> Read(FIVES_SY_DEPTPUSHRY model)
        {
            IList<FIVES_SY_DEPTPUSHRY> nodes = new List<FIVES_SY_DEPTPUSHRY>();
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@DEPTID",model.DEPTID),
                                        
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_DEPTPUSHRY_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(FIVES_SY_DEPTPUSHRY model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                      
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete, parms)) { }
                mr.TYPE = "S";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_DEPTPUSHRY_Delete");
            }
            return mr;
        }

        private FIVES_SY_DEPTPUSHRY ReadDataToModel(SqlDataReader sdr)
        {
            FIVES_SY_DEPTPUSHRY node = new FIVES_SY_DEPTPUSHRY();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);  //人员ID
            node.DEPTID = Convert.ToInt32(sdr["DEPTID"]);  //ID
            node.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            return node;
        }
    }
}
