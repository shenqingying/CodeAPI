using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.FIVES;
using System.Data;
using System.Data.SqlClient;
using Sonluk.DataAccess.RMS.MES;
using Sonluk.IDataAccess.FIVES;
namespace Sonluk.DataAccess.RMS.FIVES
{
    public class SY_TYPE : ISY_TYPE
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_SY_TYPE_Create";
        private const string SQL_Update = "FIVES_SY_TYPE_Update";
        private const string SQL_Read = "FIVES_SY_TYPE_Read";
        private const string SQL_Delete = "UPDATE  FIVES_SY_TYPE SET ISDELETE = 1 WHERE TYPEID = @TYPEID";

        public MES_RETURN Create(FIVES_SY_TYPE model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                     //new SqlParameter("@TYPEID",model.TYPEID),
                                     new SqlParameter("@TYPENAME",model.TYPENAME),
                                     new SqlParameter("@TYPEMEMO",model.TYPEMEMO),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_TYPE_INSERT");
            }
            return mr;
        }


        public MES_RETURN Update(FIVES_SY_TYPE model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@TYPENAME",model.TYPENAME),
                                        new SqlParameter("@TYPEMEMO",model.TYPEMEMO),
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
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_TYPE_UPDATE");
            }
            return mr;
        }
        public IList<FIVES_SY_TYPE> Read(FIVES_SY_TYPE model)
        {
            IList<FIVES_SY_TYPE> nodes = new List<FIVES_SY_TYPE>();
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@TYPENAME",model.TYPENAME),
                                        new SqlParameter("@TYPEMEMO",model.TYPEMEMO),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_SY_TYPE_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public MES_RETURN Delete(int ID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@TYPEID",ID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_TYPE_DELETE");
            }
            return mr;
        }
        private FIVES_SY_TYPE ReadDataToModel(SqlDataReader sdr)
        {
            FIVES_SY_TYPE node = new FIVES_SY_TYPE();
            node.TYPEID = Convert.ToInt32(sdr["TYPEID"]);  //类别ID
            node.TYPENAME = Convert.ToString(sdr["TYPENAME"]);  //类别名称
            node.TYPEMEMO = Convert.ToString(sdr["TYPEMEMO"]);  //备注
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //是否激活
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除

            return node;
        }



    }
}
