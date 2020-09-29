using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.HR
{
    public class XZGL_FFJLZD : IXZGL_FFJLZD
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_FFJLZD_INSERT";
        const string SQL_SELECT = "HR_XZGL_FFJLZD_SELECT";
        const string SQL_UPDATE = "HR_XZGL_FFJLZD_UPDATE";
        const string SQL_FORMULA_VERIFY = "HR_SY_FORMULA_VERIFY";
        const string SQL_YYTABLE = "HR_XZGL_FFJLZD_YYTABLE_SELECT";
        const string SQL_YYTABLEZD = "HR_XZGL_FFJLZD_YYTABLEZD_SELECT";
        const string SQL_YYTABLEZD_INSERT = "HR_XZGL_FFJLZD_YYTABLEZD_INSERT";
        const string SQL_YYTABLEZD_UPDATE = "HR_XZGL_FFJLZD_YYTABLEZD_UPDATE";
        public MES_RETURN INSERT(HR_XZGL_FFJLZD model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLZDMS",model.FFJLZDMS),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@ISHAVEGS",model.ISHAVEGS),
                                       new SqlParameter("@FORMULA",model.FORMULA),
                                       new SqlParameter("@ISQTYY",model.ISQTYY),
                                       new SqlParameter("@QTYYTABLE",model.QTYYTABLE),
                                       new SqlParameter("@QTYYZD",model.QTYYZD),
                                       new SqlParameter("@ZDLB",model.ZDLB),
                                       new SqlParameter("@JSLEVEL",model.JSLEVEL),
                                       new SqlParameter("@ISJJX",model.ISJJX),
                                       new SqlParameter("@JSORDER",model.JSORDER),
                                       new SqlParameter("@SORTNO",model.SORTNO),
                                       new SqlParameter("@XSBLGZ",model.XSBLGZ),
                                       new SqlParameter("@YXXSW",model.YXXSW),
                                       new SqlParameter("@MYPW",model.MYPW)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLZD_INSERT", "HR");
            }
            return rst;
        }
        public HR_XZGL_FFJLZD_SELECT SELECT(HR_XZGL_FFJLZD model)
        {
            HR_XZGL_FFJLZD_SELECT rst = new HR_XZGL_FFJLZD_SELECT();
            List<HR_XZGL_FFJLZD> child_HR_XZGL_FFJLZD = new List<HR_XZGL_FFJLZD>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@ZDID",model.ZDID),
                                       new SqlParameter("@MXID",model.MXID),
                                       new SqlParameter("@ISJJX",model.ISJJX),
                                       new SqlParameter("@ISGDZD",model.ISGDZD)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_FFJLZD child = new HR_XZGL_FFJLZD();
                        child.ZDID = Convert.ToInt32(sdr["ZDID"]);
                        child.FFJLZDNAME = Convert.ToString(sdr["FFJLZDNAME"]);
                        child.FFJLZDMS = Convert.ToString(sdr["FFJLZDMS"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.ISHAVEGS = Convert.ToInt32(sdr["ISHAVEGS"]);
                        child.FORMULA = Convert.ToString(sdr["FORMULA"]);
                        child.ISQTYY = Convert.ToInt32(sdr["ISQTYY"]);
                        child.QTYYTABLE = Convert.ToString(sdr["QTYYTABLE"]);
                        child.QTYYZD = Convert.ToString(sdr["QTYYZD"]);
                        child.ZDLB = Convert.ToInt32(sdr["ZDLB"]);
                        child.ZDLBNAME = Convert.ToString(sdr["ZDLBNAME"]);
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.JSLEVEL = Convert.ToInt32(sdr["JSLEVEL"]);
                        child.ISJJX = Convert.ToInt32(sdr["ISJJX"]);
                        child.JSORDER = Convert.ToInt32(sdr["JSORDER"]);
                        child.ISGDZD = Convert.ToInt32(sdr["ISGDZD"]);
                        child.SORTNO = Convert.ToInt32(sdr["SORTNO"]);
                        child.XSBLGZ = Convert.ToInt32(sdr["XSBLGZ"]);
                        child.XSBLGZNAME = Convert.ToString(sdr["XSBLGZNAME"]);
                        child.YXXSW = Convert.ToInt32(sdr["YXXSW"]);
                        child_HR_XZGL_FFJLZD.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLZD_SELECT", "HR");
            }
            rst.HR_XZGL_FFJLZD = child_HR_XZGL_FFJLZD;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN GS_FORMULA_VERIFY(string FORMULA)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SQLYZ",FORMULA)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_FORMULA_VERIFY, parms))
                {
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "公式错误！";
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_FORMULA_VERIFY", "HR");
            }
            return rst;
        }
        public HR_XZGL_FFJLZD_YYTABLE_SELECT SELECT_YYTABLE(HR_XZGL_FFJLZD_YYTABLE model)
        {
            HR_XZGL_FFJLZD_YYTABLE_SELECT rst = new HR_XZGL_FFJLZD_YYTABLE_SELECT();
            List<HR_XZGL_FFJLZD_YYTABLE_LIST> child_HR_XZGL_FFJLZD_YYTABLE_LIST = new List<HR_XZGL_FFJLZD_YYTABLE_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@TABLELB",model.TABLELB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_YYTABLE, parms))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_FFJLZD_YYTABLE_LIST child = new HR_XZGL_FFJLZD_YYTABLE_LIST();
                        child.TABLENAME = Convert.ToString(sdr["TABLENAME"]);
                        child.TABLEMS = Convert.ToString(sdr["TABLEMS"]);
                        child_HR_XZGL_FFJLZD_YYTABLE_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLZD_YYTABLE_SELECT", "HR");
            }
            rst.HR_XZGL_FFJLZD_YYTABLE_LIST = child_HR_XZGL_FFJLZD_YYTABLE_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_XZGL_FFJLZD_YYTABLEZD_SELECT SELECT_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model)
        {
            HR_XZGL_FFJLZD_YYTABLEZD_SELECT rst = new HR_XZGL_FFJLZD_YYTABLEZD_SELECT();
            List<HR_XZGL_FFJLZD_YYTABLEZD_LIST> child_HR_XZGL_FFJLZD_YYTABLEZD_LIST = new List<HR_XZGL_FFJLZD_YYTABLEZD_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TABLENAME",model.TABLENAME),
                                       new SqlParameter("@MXID",model.MXID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_YYTABLEZD, parms))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_FFJLZD_YYTABLEZD_LIST child = new HR_XZGL_FFJLZD_YYTABLEZD_LIST();
                        child.TABLENAME = Convert.ToString(sdr["TABLENAME"]);
                        child.ZDNAME = Convert.ToString(sdr["ZDNAME"]);
                        child.ZDMS = Convert.ToString(sdr["ZDMS"]);
                        child.ZDVALUE = Convert.ToDecimal(sdr["ZDVALUE"]);
                        child_HR_XZGL_FFJLZD_YYTABLEZD_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLZD_YYTABLEZD_SELECT", "HR");
            }
            rst.HR_XZGL_FFJLZD_YYTABLEZD_LIST = child_HR_XZGL_FFJLZD_YYTABLEZD_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_FFJLZD model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ZDID",model.ZDID),
                                       new SqlParameter("@FFJLZDMS",model.FFJLZDMS),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@ISHAVEGS",model.ISHAVEGS),
                                       new SqlParameter("@FORMULA",model.FORMULA),
                                       new SqlParameter("@JSLEVEL",model.JSLEVEL),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@ISJJX",model.ISJJX),
                                       new SqlParameter("@JSORDER",model.JSORDER),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@SORTNO",model.SORTNO),
                                       new SqlParameter("@XSBLGZ",model.XSBLGZ),
                                       new SqlParameter("@YXXSW",model.YXXSW),
                                       new SqlParameter("@QTYYTABLE",model.QTYYTABLE),
                                       new SqlParameter("@QTYYZD",model.QTYYZD)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLZD_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN INSERT_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ZDMS",model.ZDMS),
                                       new SqlParameter("@ZDVALUE",model.ZDVALUE)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_YYTABLEZD_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLZD_YYTABLEZD_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TABLENAME",model.TABLENAME),
                                       new SqlParameter("@ZDNAME",model.ZDNAME),
                                       new SqlParameter("@ZDVALUE",model.ZDVALUE),
                                       new SqlParameter("@LB",LB),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_YYTABLEZD_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLZD_YYTABLEZD_UPDATE", "HR");
            }
            return rst;
        }
    }
}
