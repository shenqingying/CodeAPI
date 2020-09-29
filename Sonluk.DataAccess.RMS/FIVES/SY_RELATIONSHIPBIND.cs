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
    public class SY_RELATIONSHIPBIND : ISY_RELATIONSHIPBIND
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_RELATIONSHIPBIND_Create";
        private const string SQL_Update = "FIVES_SY_RELATIONSHIPBIND_Update"; 
        private const string SQL_Read = "FIVES_SY_RELATIONSHIPBIND_Read";
        private const string SQL_Delete = "DELETE FROM FIVES_SY_RELATIONSHIPBIND WHERE OBJ1 = @OBJ1 AND OBJ2 = @OBJ2";
        private const string SQL_Delete_OJB1 = "DELETE FROM FIVES_SY_RELATIONSHIPBIND WHERE OBJ1 = @OBJ1 AND TYPE = @TYPE";
        private const string SQL_Delete_OJB2 = "DELETE FROM FIVES_SY_RELATIONSHIPBIND WHERE OBJ2 = @OBJ2 AND TYPE = @TYPE";
        private const string SQL_ReadBYpoint = "FIVES_SY_RELATIONSHIPBIND_ReadByPointID";
        public MES_RETURN Create(FIVES_SY_RELATIONSHIPBIND model) {
            MES_RETURN mr = new MES_RETURN(); 
            SqlParameter[] parms = {
                                        new SqlParameter("@OBJ1",model.OBJ1),
                                        new SqlParameter("@OBJ2",model.OBJ2),
                                        new SqlParameter("@TYPE",model.TYPE),
                                        new SqlParameter("@ACTION",model.ACTION)

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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_RELATIONSHIPBIND_Create");
            } 
            return mr;
        }	
        public MES_RETURN Update(FIVES_SY_RELATIONSHIPBIND model) { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@OBJ1",model.OBJ1),
                                        new SqlParameter("@OBJ2",model.OBJ2),
                                        new SqlParameter("@TYPE",model.TYPE),
                                        new SqlParameter("@ACTION",model.ACTION)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_RELATIONSHIPBIND_Update");

            } 
            return mr;
        }
        public IList<FIVES_SY_RELATIONSHIPBINDList> Read(FIVES_SY_RELATIONSHIPBIND model)
        {
            IList<FIVES_SY_RELATIONSHIPBINDList> nodes = new List<FIVES_SY_RELATIONSHIPBINDList>();
            SqlParameter[] parms = {
                                        new SqlParameter("@OBJ1",model.OBJ1),
                                        new SqlParameter("@OBJ2",model.OBJ2),
                                        new SqlParameter("@TYPE",model.TYPE),
                                        new SqlParameter("@ACTION",model.ACTION)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_RELATIONSHIPBIND_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public IList<FIVES_SY_RELATIONSHIPBINDList> ReadbyPoint(FIVES_SY_RELATIONSHIPBIND model)
        {
            IList<FIVES_SY_RELATIONSHIPBINDList> nodes = new List<FIVES_SY_RELATIONSHIPBINDList>();
            SqlParameter[] parms = {
                                        new SqlParameter("@OBJ1",model.OBJ1),
                                        //new SqlParameter("@OBJ2",model.OBJ2),
                                        new SqlParameter("@TYPE",model.TYPE)
                                        //new SqlParameter("@ACTION",model.ACTION)
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBYpoint, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_RELATIONSHIPBIND_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(FIVES_SY_RELATIONSHIPBIND model) 
        { 
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@OBJ1",model.OBJ1),
                                        new SqlParameter("@OBJ2",model.OBJ2),
                                        new SqlParameter("@TYPE",model.TYPE)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_RELATIONSHIPBIND_Delete");

            } 
            return mr; 
        }
        public MES_RETURN Delete_OJB1(FIVES_SY_RELATIONSHIPBIND model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@OBJ1",model.OBJ1),
                                        new SqlParameter("@OBJ2",model.OBJ2),  
                                        new SqlParameter("@TYPE",model.TYPE)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete_OJB1, parms)) { }
                mr.TYPE = "S";

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_RELATIONSHIPBIND_Delete");

            }
            return mr;
        }
        public MES_RETURN Delete_OJB2(FIVES_SY_RELATIONSHIPBIND model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@OBJ1",model.OBJ1),
                                        new SqlParameter("@OBJ2",model.OBJ2),    
                                        new SqlParameter("@TYPE",model.TYPE)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Delete_OJB2, parms)) { }
                mr.TYPE = "S";

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_RELATIONSHIPBIND_Delete");

            }
            return mr;
        }	
        private FIVES_SY_RELATIONSHIPBINDList ReadDataToModel(SqlDataReader sdr) 
        {
            FIVES_SY_RELATIONSHIPBINDList node = new FIVES_SY_RELATIONSHIPBINDList();
            node.OBJ1 = Convert.ToInt32(sdr["OBJ1"]);  //对象1
            node.OBJ2 = Convert.ToInt32(sdr["OBJ2"]);  //对象2
            node.TYPE = Convert.ToInt32(sdr["TYPE"]);  //关联类型
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //激活状态
            node.OBJ1NAME = Convert.ToString(sdr["OBJ1NAME"]);
            node.OBJ2NAME = Convert.ToString(sdr["OBJ2NAME"]);
            node.TYPENAME = Convert.ToString(sdr["TYPENAME"]);
            node.TYPEREMARK = Convert.ToString(sdr["TYPEREMARK"]);
            return node;
        }


    }
}
