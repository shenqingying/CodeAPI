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
    public class SY_MATERIAL_GROUP : ISY_MATERIAL_GROUP
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        string SQL_INSERT = "MES_SY_MATERIAL_GROUP_INSERT";
        string SQL_SELECT_COUNT = "SELECT COUNT(*) AS MCOUNT FROM MES_SY_MATERIAL_GROUP WHERE WLGROUP=@WLGROUP AND GC=@GC";
        string SQL_SELECT = "MES_SY_MATERIAL_GROUP_SELECT";
        const string SQL_DELETE = "UPDATE MES_SY_MATERIAL_GROUP SET ISDELETE=1 WHERE GC=@GC AND WLGROUP=@WLGROUP";
        const string SQL_UPDATE = "MES_SY_MATERIAL_GROUP_UPDATE";
        private const string SQL_SELECT_LB = "MES_SY_MATERIAL_GROUP_SELECT_LB";
        public MES_RETURN INSERT(MES_SY_MATERIAL_GROUP model, int ISAUTO)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@WLGROUPNAME",model.WLGROUPNAME),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@CJRID",model.CJRID),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@ISAUTO",ISAUTO)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ISY_MATERIAL_GROUP");
            }
            return rst;
        }

        public int SELECT_COUNT(MES_SY_MATERIAL_GROUP model)
        {
            int rst = 0;
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
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
                throw new ApplicationException(e.Message);
            }
        }


        public MES_SY_MATERIAL_GROUP_SELECT SELECT(MES_SY_MATERIAL_GROUP model)
        {
            MES_SY_MATERIAL_GROUP_SELECT rst = new MES_SY_MATERIAL_GROUP_SELECT();
            List<MES_SY_MATERIAL_GROUP> child_MES_SY_MATERIAL_GROUP = new List<MES_SY_MATERIAL_GROUP>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WLGROUP",isnull(model.WLGROUP)),
                                       new SqlParameter("@WLGROUPNAME",isnull(model.WLGROUPNAME)),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",isnull(model.WLLBNAME)),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@GZZXBH",model.GZZXBH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_MATERIAL_GROUP node = new MES_SY_MATERIAL_GROUP();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        node.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        node.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        node.CJDATE = Convert.ToDateTime(sdr["CJDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        node.CJRID = Convert.ToInt32(sdr["CJRID"]);
                        node.CJR = Convert.ToString(sdr["CJR"]);
                        node.XGDATE = Convert.ToDateTime(sdr["XGDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        node.XGRID = Convert.ToInt32(sdr["XGRID"]);
                        node.XGR = Convert.ToString(sdr["XGR"]);
                        child_MES_SY_MATERIAL_GROUP.Add(node);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_SY_MATERIAL_GROUP = child_MES_SY_MATERIAL_GROUP;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ISY_MATERIAL_GROUP");
            }
            return rst;
        }
        public MES_SY_MATERIAL_GROUP_SELECT SELECT_LB(MES_SY_MATERIAL_GROUP model)
        {
            MES_SY_MATERIAL_GROUP_SELECT rst = new MES_SY_MATERIAL_GROUP_SELECT();
            List<MES_SY_MATERIAL_GROUP> child_MES_SY_MATERIAL_GROUP = new List<MES_SY_MATERIAL_GROUP>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WLGROUP",isnull(model.WLGROUP)),
                                       new SqlParameter("@WLGROUPNAME",isnull(model.WLGROUPNAME)),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",isnull(model.WLLBNAME)),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_MATERIAL_GROUP node = new MES_SY_MATERIAL_GROUP();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        node.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        node.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        node.CJDATE = Convert.ToDateTime(sdr["CJDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        node.CJRID = Convert.ToInt32(sdr["CJRID"]);
                        node.CJR = Convert.ToString(sdr["CJR"]);
                        node.XGDATE = Convert.ToDateTime(sdr["XGDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        node.XGRID = Convert.ToInt32(sdr["XGRID"]);
                        node.XGR = Convert.ToString(sdr["XGR"]);
                        child_MES_SY_MATERIAL_GROUP.Add(node);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_SY_MATERIAL_GROUP = child_MES_SY_MATERIAL_GROUP;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_MATERIAL_GROUP_SELECT_LB","MES");
            }
            return rst;
        }

        public MES_RETURN DELETE(MES_SY_MATERIAL_GROUP model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLGROUP",model.WLGROUP)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ISY_MATERIAL_GROUP");
            }
            return mr;
        }

        public MES_RETURN UPDATE(MES_SY_MATERIAL_GROUP model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@WLGROUPNAME",model.WLGROUPNAME),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@XGRID",model.XGRID),
                                       new SqlParameter("@XGR",model.XGR)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ISY_MATERIAL_GROUP");
            }
            return mr;
        }


        private string isnull(string s)
        {
            if (s == null)
            {
                s = "";
            }
            return s;
        }
    }
}
