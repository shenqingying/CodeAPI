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
    public class SY_MATERIAL_BZCOUNT : ISY_MATERIAL_BZCOUNT
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();

        const string SQL_INSERT = "MES_SY_MATERIAL_BZCOUNT_INSERT";
        const string SQL_DELETE = "MES_SY_MATERIAL_BZCOUNT_DELETE";
        const string SQL_UPDATE = "MES_SY_MATERIAL_BZCOUNT_UPDATE";
        const string SQL_SELECT = "MES_SY_MATERIAL_BZCOUNT_SELECT";
        private const string SQL_SELECT_LB = "MES_SY_MATERIAL_BZCOUNT_SELECT_LB";
        public MES_RETURN INSERT(MES_SY_MATERIAL_BZCOUNT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@BZCOUNT",model.BZCOUNT),
                                       new SqlParameter("@BZBS",model.BZBS)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL_BZCOUNT_INSERT");
            }
            return rst;
        }

        public MES_RETURN DELETE(MES_SY_MATERIAL_BZCOUNT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL_BZCOUNT_DELETE");
            }
            return rst;
        }

        public MES_RETURN UPDATE(MES_SY_MATERIAL_BZCOUNT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@BZCOUNT",model.BZCOUNT),
                                       new SqlParameter("@BZBS",model.BZBS)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL_BZCOUNT_UPDATE");
            }
            return rst;
        }

        public MES_SY_MATERIAL_BZCOUNT_SELECT SELECT(MES_SY_MATERIAL_BZCOUNT model)
        {
            MES_SY_MATERIAL_BZCOUNT_SELECT rst = new MES_SY_MATERIAL_BZCOUNT_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_MATERIAL_BZCOUNT> child_MES_SY_MATERIAL_BZCOUNT = new List<MES_SY_MATERIAL_BZCOUNT>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_MATERIAL_BZCOUNT child = new MES_SY_MATERIAL_BZCOUNT();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLNAME = Convert.ToString(sdr["WLNAME"]);
                        child.BZCOUNT = Convert.ToInt32(sdr["BZCOUNT"]);
                        child.BZBS = Convert.ToInt32(sdr["BZBS"]);
                        child_MES_SY_MATERIAL_BZCOUNT.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL_BZCOUNT_SELECT");
            }
            rst.MES_SY_MATERIAL_BZCOUNT = child_MES_SY_MATERIAL_BZCOUNT;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_SY_MATERIAL_BZCOUNT_SELECT SELECT_LB(MES_SY_MATERIAL_BZCOUNT model)
        {
            MES_SY_MATERIAL_BZCOUNT_SELECT rst = new MES_SY_MATERIAL_BZCOUNT_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_MATERIAL_BZCOUNT> child_MES_SY_MATERIAL_BZCOUNT = new List<MES_SY_MATERIAL_BZCOUNT>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_MATERIAL_BZCOUNT child = new MES_SY_MATERIAL_BZCOUNT();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLNAME = Convert.ToString(sdr["WLNAME"]);
                        child.BZCOUNT = Convert.ToInt32(sdr["BZCOUNT"]);
                        child.BZBS = Convert.ToInt32(sdr["BZBS"]);
                        child_MES_SY_MATERIAL_BZCOUNT.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SY_MATERIAL_BZCOUNT_SELECT_LB","MES");
            }
            rst.MES_SY_MATERIAL_BZCOUNT = child_MES_SY_MATERIAL_BZCOUNT;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}
