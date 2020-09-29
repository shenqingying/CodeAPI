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
    class BAT_SPECS_SAMP : IBAT_SPECS_SAMP
    {
        const string SQL_SELECT = "MES_DCCCCYSJ_SELECT";
        const string SQL_UPDATE = "MES_DCCCCYSJ_UPDATE";
        const string SQL_INSERT = "MES_DCCCCYSJ_INSERT";
        const string SQL_DELETE = "MES_DCCCCYSJ_DELETE";

        public MES_DCCCCYSJ_SELECT SELECT(MES_DCCCCYSJ model)
        {
            MES_DCCCCYSJ_SELECT rst = new MES_DCCCCYSJ_SELECT();
            rst.MES_DCCCCYSJ = new List<MES_DCCCCYSJ>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHRI",model.DCXHRI),
                                       new SqlParameter("@DCBZ",model.DCBZ),
                                       new SqlParameter("@DCBZRI",model.DCBZRI)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_DCCCCYSJ child = new MES_DCCCCYSJ();
                        child.RI = Convert.ToInt32(sdr["RI"]);
                        child.DCXH = Convert.ToString(sdr["DCXH"]);
                        child.DCXHRI = Convert.ToInt32(sdr["DCXHRI"]);
                        child.DCBZ = Convert.ToString(sdr["DCBZ"]);
                        child.DCBZRI = Convert.ToInt32(sdr["DCBZRI"]);
                        child.SZ = Convert.ToString(sdr["SZ"]);
                        rst.MES_DCCCCYSJ.Add(child);
                    }

                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "SELECTED";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_RETURN UPDATE(MES_DCCCCYSJ model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RI",model.RI),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHRI",model.DCXHRI),
                                       new SqlParameter("@DCBZ",model.DCBZ),
                                       new SqlParameter("@DCBZRI",model.DCBZRI),
                                       new SqlParameter("@SZ",model.SZ)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    if (sdr.Read())
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
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_RETURN INSERT(MES_DCCCCYSJ model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHRI",model.DCXHRI),
                                       new SqlParameter("@DCBZ",model.DCBZ),
                                       new SqlParameter("@DCBZRI",model.DCBZRI),
                                       new SqlParameter("@SZ",model.SZ)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    if (sdr.Read())
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
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_RETURN DELETE(int RI)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RI",RI)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms)) { }
                rst.TYPE = "S";
                rst.MESSAGE = RI + "DELETED";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }
    }
}
