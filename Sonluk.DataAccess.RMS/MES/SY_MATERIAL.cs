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
    public class SY_MATERIAL : ISY_MATERIAL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        string SQL_INSERT = "MES_SY_MATERIAL_INSERT";
        //string SQL_SELECT_COUNT = "SELECT COUNT(*) AS MCOUNT FROM MES_SY_MATERIAL AS A INNER JOIN MES_SY_MATERIAL_GROUP AS B ON A.GC=B.GC AND A.WLGROUP=B.WLGROUP  WHERE A.WLH = @WLH  AND B.GC=@GC AND B.WLGROUP = @WLGROUP";
        const string SQL_SELECT_COUNT = "SELECT COUNT(*) AS MCOUNT FROM MES_SY_MATERIAL AS A WHERE A.WLH=@WLH  AND A.GC=@GC";
        const string SQL_DELETE = "UPDATE MES_SY_MATERIAL SET ISDELETE=1 WHERE GC=@GC AND WLH=@WLH";
        const string SQL_UPDATE = "MES_SY_MATERIAL_UPDATE";
        const string SQL_SELECT = "MES_SY_MATERIAL_SELECT";
        private const string SQL_SELECT_LB = "MES_SY_MATERIAL_SELECT_LB";
        const string SQL_SELECT_BY_GZZX = "MES_SY_MATERIAL_SELECT_BY_GZZX";
        const string SQL_INSERT_DW = "MES_SY_MATERIAL_DW_INSERT";
        const string SQL_DW_SELECT = "MES_SY_MATERIAL_DW_SELECT";
        const string SQL_DW_UPDATE = "MES_SY_MATERIAL_DW_UPDATE";
        public MES_RETURN INSERT(MES_SY_MATERIAL model, int ISAUTO)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@JLRNAME",model.JLRNAME),
                                       new SqlParameter("@UNITSID",model.UNITSID),
                                       new SqlParameter("@UNITSNAME",model.UNITSNAME),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHNAME",model.DCXHNAME),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@DCDJNAME",model.DCDJNAME),
                                       new SqlParameter("@ISAUTO",ISAUTO),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@ISTRACE",model.ISTRACE)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL");
            }
            return rst;
        }

        public int SELECT_COUNT(MES_SY_MATERIAL model)
        {
            int rst = 0;
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WLH",model.WLH),
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

        public MES_RETURN DELETE(MES_SY_MATERIAL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLH",model.WLH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms))
                {
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL");
            }
            return rst;
        }

        public MES_RETURN UPDATE(MES_SY_MATERIAL model, int ISAUTO)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@JLRNAME",model.JLRNAME),
                                       new SqlParameter("@UNITSID",model.UNITSID),
                                       new SqlParameter("@UNITSNAME",model.UNITSNAME),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHNAME",model.DCXHNAME),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@DCDJNAME",model.DCDJNAME),
                                       new SqlParameter("@ISAUTO",ISAUTO),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@ISTRACE",model.ISTRACE)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL");
            }
            return rst;
        }

        public MES_SY_MATERIAL_SELECT SELECT(MES_SY_MATERIAL model)
        {
            MES_SY_MATERIAL_SELECT rst = new MES_SY_MATERIAL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_MATERIAL_LIST> child_MES_SY_MATERIAL_LIST = new List<MES_SY_MATERIAL_LIST>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@UNITSID",model.UNITSID),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@ISTRACE",model.ISTRACE)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_MATERIAL_LIST child = new MES_SY_MATERIAL_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRNAME = Convert.ToString(sdr["JLRNAME"]);
                        child.JLTIME = Convert.ToString(sdr["JLTIME"]);
                        child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHNAME = Convert.ToString(sdr["DCXHNAME"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJNAME = Convert.ToString(sdr["DCDJNAME"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.ISTRACE = Convert.ToInt32(sdr["ISTRACE"]);
                        child_MES_SY_MATERIAL_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_MATERIAL = child_MES_SY_MATERIAL_LIST;
            return rst;
        }
        public MES_SY_MATERIAL_SELECT SELECT_LB(MES_SY_MATERIAL model)
        {
            MES_SY_MATERIAL_SELECT rst = new MES_SY_MATERIAL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_MATERIAL_LIST> child_MES_SY_MATERIAL_LIST = new List<MES_SY_MATERIAL_LIST>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@UNITSID",model.UNITSID),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@ISTRACE",model.ISTRACE),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_MATERIAL_LIST child = new MES_SY_MATERIAL_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRNAME = Convert.ToString(sdr["JLRNAME"]);
                        child.JLTIME = Convert.ToString(sdr["JLTIME"]);
                        child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHNAME = Convert.ToString(sdr["DCXHNAME"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJNAME = Convert.ToString(sdr["DCDJNAME"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.ISTRACE = Convert.ToInt32(sdr["ISTRACE"]);
                        child_MES_SY_MATERIAL_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_MATERIAL = child_MES_SY_MATERIAL_LIST;
            return rst;
        }

        public MES_SY_MATERIAL_SELECT SELECT_BY_GZZX(MES_SY_MATERIAL model)
        {
            MES_SY_MATERIAL_SELECT rst = new MES_SY_MATERIAL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_MATERIAL_LIST> child_MES_SY_MATERIAL_LIST = new List<MES_SY_MATERIAL_LIST>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_GZZX, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_MATERIAL_LIST child = new MES_SY_MATERIAL_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRNAME = Convert.ToString(sdr["JLRNAME"]);
                        child.JLTIME = Convert.ToString(sdr["JLTIME"]);
                        child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHNAME = Convert.ToString(sdr["DCXHNAME"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJNAME = Convert.ToString(sdr["DCDJNAME"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.ISTRACE = Convert.ToInt32(sdr["ISTRACE"]);
                        child_MES_SY_MATERIAL_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_MATERIAL = child_MES_SY_MATERIAL_LIST;
            return rst;
        }

        public MES_RETURN INSERT_DW(MES_SY_MATERIAL_DW model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@MEINH",model.MEINH),
                                       new SqlParameter("@UMREZ",model.UMREZ),
                                       new SqlParameter("@UMREN",model.UMREN)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_DW, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL");
            }
            return rst;
        }

        public MES_SY_MATERIAL_DW_SELECT DW_SELECT(MES_SY_MATERIAL_DW model)
        {
            MES_SY_MATERIAL_DW_SELECT rst = new MES_SY_MATERIAL_DW_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_MATERIAL_DW> child_MES_SY_MATERIAL_DW = new List<MES_SY_MATERIAL_DW>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@MEINH",model.MEINH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DW_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_MATERIAL_DW child = new MES_SY_MATERIAL_DW();
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.MEINH = Convert.ToString(sdr["MEINH"]);
                        child.UMREZ = Convert.ToInt32(sdr["UMREZ"]);
                        child.UMREN = Convert.ToInt32(sdr["UMREN"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child_MES_SY_MATERIAL_DW.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL_DW");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_MATERIAL_DW = child_MES_SY_MATERIAL_DW;
            return rst;
        }
        public MES_RETURN DW_UPDATE(MES_SY_MATERIAL_DW model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@LB",model.LB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DW_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_MATERIAL_DW_UPDATE");
            }
            return rst;
        }
    }
}
