using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class SY_TYPEMX : ISY_TYPEMX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        string SQL_SELECT = "MES_SY_TYPEMX_SELECT";
        string SQL_INSERT = "MES_SY_TYPEMX_INSERT";
        string SQL_UPDATE = "MES_SY_TYPEMX_UPDATE";
        string SQL_DELETE = "UPDATE MES_SY_TYPEMX SET ISDELETE = 1 WHERE ID=@ID";
        string SQL_SELECT_COUNT = "SELECT COUNT(*) AS MCOUNT FROM MES_SY_TYPEMX WHERE ISDELETE = 0 AND TYPEID=@TYPEID AND MXNAME=@MXNAME AND GC=@GC";
        const string SQL_SELECT_ZJDATE = "MES_SY_TYPEMX_SELECT_ZJDATE";
        const string SQL_SELECT_SBFL_BY_GZZX = "MES_SY_TYPEMX_SELECT_SBFL_BY_GZZX";
        public IList<MES_SY_TYPEMXLIST> SELECT(MES_SY_TYPEMX model)
        {
            IList<MES_SY_TYPEMXLIST> rst = new List<MES_SY_TYPEMXLIST>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@TYPEID",model.TYPEID),
                                       new SqlParameter("@MXNAME",model.MXNAME),
                                       new SqlParameter("@GC",model.GC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_TYPEMXLIST child = new MES_SY_TYPEMXLIST();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.TYPEID = Convert.ToInt32(sdr["TYPEID"]);
                        child.TYPENAME = Convert.ToString(sdr["TYPENAME"]);
                        child.MXNAME = Convert.ToString(sdr["MXNAME"]);
                        child.MXNO = Convert.ToString(sdr["MXNO"]);
                        child.MXREMARK = Convert.ToString(sdr["MXREMARK"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.MAXVALUE = Convert.ToString(sdr["MAXVALUE"]);
                        child.MINVALUE = Convert.ToString(sdr["MINVALUE"]);
                        rst.Add(child);
                    }
                }
                return rst;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_SELECT");
                throw new ApplicationException(e.Message);
            }
        }

        public MES_RETURN INSERT(MES_SY_TYPEMX model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@TYPEID",model.TYPEID),
                                       new SqlParameter("@MXNAME",model.MXNAME),
                                       new SqlParameter("@MXNO",model.MXNO),
                                       new SqlParameter("@MXREMARK",model.MXREMARK),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@MAXVALUE",model.MAXVALUE),
                                       new SqlParameter("@MINVALUE",model.MINVALUE)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_INSERT");
            }
            return mr;
        }

        public MES_RETURN UPDATE(MES_SY_TYPEMX model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@MXNAME",model.MXNAME),
                                       new SqlParameter("@MXNO",model.MXNO),
                                       new SqlParameter("@MXREMARK",model.MXREMARK),
                                       new SqlParameter("@MAXVALUE",model.MAXVALUE),
                                       new SqlParameter("@MINVALUE",model.MINVALUE)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms)) { }
                mr.TYPE = "S";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_UPDATE");
            }
            return mr;
        }


        public MES_RETURN DELETE(int ID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",ID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms)) { }
                mr.TYPE = "S";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_DELETE");
            }
            return mr;
        }

        public int SELECT_COUNT(MES_SY_TYPEMX model)
        {
            int rst = 0;
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TYPEID",model.TYPEID),
                                       new SqlParameter("@MXNAME",model.MXNAME),
                                       new SqlParameter("@GC",model.GC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_COUNT, parms))
                {
                    while (sdr.Read())
                    {
                        rst = Convert.ToInt32(sdr["MCOUNT"]);
                    }
                }
                return rst;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_SELECT_COUNT");
                throw new ApplicationException(e.Message);
            }
        }


        public MES_RETURN SELECT_ZJDATE(MES_SY_TYPEMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TYPEID",model.TYPEID),
                                       new SqlParameter("@MXNAME",model.MXNAME),
                                       new SqlParameter("@GC",model.GC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ZJDATE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TID = Convert.ToInt32(sdr["ID"]);
                    }
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_SELECT_ZJDATE");
            }
            return rst;
        }

        public IList<MES_SY_TYPEMXLIST> SELECT_SBFL_BY_GZZX(string GC, string GZZXBH)
        {
            IList<MES_SY_TYPEMXLIST> rst = new List<MES_SY_TYPEMXLIST>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",GC),
                                       new SqlParameter("@GZZXBH",GZZXBH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_SBFL_BY_GZZX, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_TYPEMXLIST child = new MES_SY_TYPEMXLIST();
                        child.ID = Convert.ToInt32(sdr["SBFL"]);
                        child.MXNAME = Convert.ToString(sdr["MXNAME"]);
                        child.MXNO = Convert.ToString(sdr["MXNO"]);
                        rst.Add(child);
                    }
                }
                return rst;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_SELECT_SBFL_BY_GZZX");
                throw new ApplicationException(e.Message);
            }
        }
    }
}
