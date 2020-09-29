using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Sonluk.IDataAccess.FIVES;
namespace Sonluk.DataAccess.RMS.FIVES
{
    public class SY_DICT : ISY_DICT
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_DICT_Create";
        private const string SQL_Update = "FIVES_SY_DICT_Update";
        private const string SQL_Read = "FIVES_SY_DICT_Read";
        private const string SQL_Delete = "FIVES_SY_DICT_Delete"; //"UPDATE FIVES_SY_DICT SET ISDELETE = 1 WHERE DICID = @DICID";
        public MES_RETURN Create(FIVES_SY_DICT model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        //new SqlParameter("@DICID",model.DICID),
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@DICNAME",model.DICNAME),
                                        new SqlParameter("@DICMEMO",model.DICMEMO),
                                        new SqlParameter("@ACTION",model.ACTION),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_DICT_INSERT");
            }
            return mr;
        }
        public MES_RETURN Update(FIVES_SY_DICT model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                        new SqlParameter("@DICID",model.DICID),
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@DICNAME",model.DICNAME),
                                        new SqlParameter("@DICMEMO",model.DICMEMO),
                                        new SqlParameter("@ACTION",model.ACTION),
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
                //mr.TYPE = "S";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_DICT_Update");
            } return mr;
        }
        public IList<FIVES_SY_DICT> Read(FIVES_SY_DICT model)
        {
            IList<FIVES_SY_DICT> nodes = new List<FIVES_SY_DICT>();
            SqlParameter[] parms = { 
                                        new SqlParameter("@DICID",model.DICID),
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@DICNAME",model.DICNAME),
                                        new SqlParameter("@DICMEMO",model.DICMEMO),
                                        new SqlParameter("@ACTION",model.ACTION),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_DICT_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int ID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@DICID",ID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Delete, parms)) {
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_DICT_Delete");
            }
            return mr;
        }
        private FIVES_SY_DICT ReadDataToModel(SqlDataReader sdr)
        {
            FIVES_SY_DICT node = new FIVES_SY_DICT();
            node.DICID = Convert.ToInt32(sdr["DICID"]);  //字典ID
            node.TYPEID = Convert.ToInt32(sdr["TYPEID"]);  //类别ID
            node.DICNAME = Convert.ToString(sdr["DICNAME"]);  //字典名称
            node.DICMEMO = Convert.ToString(sdr["DICMEMO"]);  //备注
            return node;
        }



    }
}
