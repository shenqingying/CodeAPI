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
    public class BOOK_BOOKINFO : IBOOK_BOOKINFO
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_BOOK_BOOKINFO_INSERT = "HR_BOOK_BOOKINFO_INSERT";
        const string SQL_BOOK_BOOKINFO_SELECT = "HR_BOOK_BOOKINFO_SELECT";
        const string SQL_BOOK_BOOKINFO_UPDATE = "HR_BOOK_BOOKINFO_UPDATE";
        const string SQL_BOOK_BOOKINFO_LOGOUT = "UPDATE HR_BOOK_BOOKINFO SET ISZX=1 WHERE BOOKNO=@BOOKNO";
        const string SQL_BOOK_LOOK_JY = "HR_BOOK_LOOK_JY";
        const string SQL_BOOK_LOOK_GH = "HR_BOOK_LOOK_GH";
        const string SQL_BOOK_LOOK_SELECT = "HR_BOOK_LOOK_SELECT";
        const string SQL_BOOK_LOOK_JY_SELECT = "HR_BOOK_LOOK_JY_SELECT";

        public MES_RETURN INSERT_BOOKINFO(HR_BOOK_BOOKINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@BOOKNO",model.BOOKNO),
                                       new SqlParameter("@BOOKNAME",model.BOOKNAME),
                                       new SqlParameter("@CBS",model.CBS),
                                       new SqlParameter("@ZZ",model.ZZ),
                                       new SqlParameter("@LX",model.LX),
                                       new SqlParameter("@PRICE",model.PRICE),
                                       new SqlParameter("@RKDATE",model.RKDATE),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BOOK_BOOKINFO_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_BOOK_BOOKINFO_INSERT", "HR");
            }
            return rst;
        }
        public HR_BOOK_BOOKINFO_SELECT SELECT_BOOKINFO(HR_BOOK_BOOKINFO model)
        {
            HR_BOOK_BOOKINFO_SELECT rst = new HR_BOOK_BOOKINFO_SELECT();
            List<HR_BOOK_BOOKINFO_LIST> model_HR_BOOK_BOOKINFO_LIST = new List<HR_BOOK_BOOKINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@BOOKNO",model.BOOKNO),
                                           new SqlParameter("@BOOKNAME",model.BOOKNAME),
                                           new SqlParameter("@LX",model.LX),
                                           new SqlParameter("@RKDATEKS",model.RKDATEKS),
                                           new SqlParameter("@RKDATEJS",model.RKDATEJS),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BOOK_BOOKINFO_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_BOOK_BOOKINFO_LIST child = new HR_BOOK_BOOKINFO_LIST();
                        child.BOOKNO = Convert.ToString(sdr["BOOKNO"]);
                        child.BOOKNAME = Convert.ToString(sdr["BOOKNAME"]);
                        child.CBS = Convert.ToString(sdr["CBS"]);
                        child.ZZ = Convert.ToString(sdr["ZZ"]);
                        child.LX = Convert.ToInt32(sdr["LX"]);
                        child.LXNAME = Convert.ToString(sdr["LXNAME"]);
                        child.PRICE = Convert.ToString(sdr["PRICE"]);
                        child.KC = Convert.ToInt32(sdr["KC"]);
                        child.RKCOUNT = Convert.ToInt32(sdr["RKCOUNT"]);
                        child.RKDATE = Convert.ToString(sdr["RKDATE"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISZX = Convert.ToInt32(sdr["ISZX"]);
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        model_HR_BOOK_BOOKINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_SELECT", "HR");
            }
            rst.HR_BOOK_BOOKINFO_LIST = model_HR_BOOK_BOOKINFO_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE_BOOKINFO(HR_BOOK_BOOKINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@BOOKNO",model.BOOKNO),
                                       new SqlParameter("@BOOKNAME",model.BOOKNAME),
                                       new SqlParameter("@CBS",model.CBS),
                                       new SqlParameter("@ZZ",model.ZZ),
                                       new SqlParameter("@LX",model.LX),
                                       new SqlParameter("@PRICE",model.PRICE),
                                       new SqlParameter("@RKDATE",model.RKDATE),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BOOK_BOOKINFO_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_BOOK_BOOKINFO_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN LOGOUT_BOOKINFO(HR_BOOK_BOOKINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@BOOKNO",model.BOOKNO)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_BOOK_BOOKINFO_LOGOUT, parms))
                {
                        rst.TYPE = "S";
                        rst.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_BOOK_BOOKINFO_LOGOUT", "HR");
            }
            return rst;
        }
        public MES_RETURN JY_BOOK(HR_BOOK_BOOKINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@BOOKNO",model.BOOKNO),
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@JYDATE",model.JYDATE),
                                       new SqlParameter("@CJR",model.CJR)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BOOK_LOOK_JY, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_BOOK_LOOK_JY", "HR");
            }
            return rst;
        }
        public MES_RETURN GH_BOOK(HR_BOOK_BOOKINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@BOOKNO",model.BOOKNO),
                                       new SqlParameter("@GHDATE",model.GHDATE),
                                       new SqlParameter("@XGR",model.XGR)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BOOK_LOOK_GH, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_BOOK_LOOK_JY", "HR");
            }
            return rst;
        }
        public HR_BOOK_BOOKINFO_SELECT SELECT_BOOK_LOOK(HR_BOOK_BOOKINFO model)
        {
            HR_BOOK_BOOKINFO_SELECT rst = new HR_BOOK_BOOKINFO_SELECT();
            List<HR_BOOK_BOOKINFO_LIST> model_HR_BOOK_BOOKINFO_LIST = new List<HR_BOOK_BOOKINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@BOOKNO",model.BOOKNO),
                                           new SqlParameter("@GHNO",model.GHNO),
                                           new SqlParameter("@JYDATEKS",model.JYDATEKS),
                                           new SqlParameter("@JYDATEJS",model.JYDATEJS),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BOOK_LOOK_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_BOOK_BOOKINFO_LIST child = new HR_BOOK_BOOKINFO_LIST();
                        child.BOOKNO = Convert.ToString(sdr["BOOKNO"]);
                        child.BOOKNAME = Convert.ToString(sdr["BOOKNAME"]);
                        child.CBS = Convert.ToString(sdr["CBS"]);
                        child.ZZ = Convert.ToString(sdr["ZZ"]);
                        child.LX = Convert.ToInt32(sdr["LX"]);
                        child.LXNAME = Convert.ToString(sdr["LXNAME"]);
                        child.PRICE = Convert.ToString(sdr["PRICE"]);
                        child.KC = Convert.ToInt32(sdr["KC"]);
                        child.RKCOUNT = Convert.ToInt32(sdr["RKCOUNT"]);
                        child.RKDATE = Convert.ToString(sdr["RKDATE"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISZX = Convert.ToInt32(sdr["ISZX"]);
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);

                        child.ISGH = Convert.ToInt32(sdr["ISGH"]);
                        child.GHDATE = Convert.ToString(sdr["GHDATE"]);
                        child.JYDATE = Convert.ToString(sdr["JYDATE"]);
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        model_HR_BOOK_BOOKINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_BOOK_LOOK_SELECT", "HR");
            }
            rst.HR_BOOK_BOOKINFO_LIST = model_HR_BOOK_BOOKINFO_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_BOOK_BOOKINFO_SELECT SELECT_BOOK_LOOK_JY(HR_BOOK_BOOKINFO model)
        {
            HR_BOOK_BOOKINFO_SELECT rst = new HR_BOOK_BOOKINFO_SELECT();
            List<HR_BOOK_BOOKINFO_LIST> model_HR_BOOK_BOOKINFO_LIST = new List<HR_BOOK_BOOKINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@BOOKNO",model.BOOKNO),
                                           new SqlParameter("@SELECTLB",model.SELECTLB)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BOOK_LOOK_JY_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_BOOK_BOOKINFO_LIST child = new HR_BOOK_BOOKINFO_LIST();
                        child.BOOKNO = Convert.ToString(sdr["BOOKNO"]);
                        child.BOOKNAME = Convert.ToString(sdr["BOOKNAME"]);
                        child.CBS = Convert.ToString(sdr["CBS"]);
                        child.ZZ = Convert.ToString(sdr["ZZ"]);
                        child.PRICE = Convert.ToString(sdr["PRICE"]);
                        child.BOOKCOUNT = Convert.ToInt32(sdr["BOOKCOUNT"]);
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.JYDATE = Convert.ToString(sdr["JYDATE"]);
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        model_HR_BOOK_BOOKINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_BOOK_LOOK_JY_SELECT", "HR");
            }
            rst.HR_BOOK_BOOKINFO_LIST = model_HR_BOOK_BOOKINFO_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}
