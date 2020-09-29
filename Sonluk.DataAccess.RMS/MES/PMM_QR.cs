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
    class PMM_QR : IPMM_QR
    {
        const string SQL_PMM_QLTY_SELECT = "MES_PMM_QLTY_SELECT";
        const string SQL_PMM_QLTY_INSERT = "MES_PMM_QLTY_INSERT";
        const string SQL_PMM_QLTY_UPDATE = "MES_PMM_QLTY_UPDATE";
        const string SQL_PMM_QLTY_DELETE = "MES_PMM_QLTY_DELETE";
        const string SQL_PMM_REP_SELECT = "MES_PMM_REP_SELECT";
        const string SQL_PMM_REP_INSERT = "MES_PMM_REP_INSERT";
        const string SQL_PMM_REP_UPDATE = "MES_PMM_REP_UPDATE";
        const string SQL_PMM_REP_DELETE = "MES_PMM_REP_DELETE";
        const string SQL_PMM_QR_SELECT = "MES_PMM_QR_SELECT_BY_QCODE";
        const string SQL_PMM_QR_COVER = "MES_PMM_QR_COVER";
        const string SQL_PMM_QR_DELETE = "MES_PMM_QR_DELETE";

        public MES_PMM_QR_SELECT QLTY_SELECT(MES_PMM_QR model)
        {
            MES_PMM_QR_SELECT rst = new MES_PMM_QR_SELECT();
            rst.MES_PMM_QR = new List<MES_PMM_QR>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@QCODE",model.QCODE),
                                       new SqlParameter("@QNAME",model.QNAME),
                                       new SqlParameter("@ISACTION",model.QISACTION)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_QLTY_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PMM_QR child = new MES_PMM_QR();
                        child.QID = Convert.ToInt32(sdr["QID"]);
                        child.QCODE = Convert.ToString(sdr["QCODE"]);
                        child.QNAME = Convert.ToString(sdr["QNAME"]);
                        child.QISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        rst.MES_PMM_QR.Add(child);
                    }
                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "无";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN QLTY_INSERT(MES_PMM_QR model, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@QCODE",model.QCODE),
                                       new SqlParameter("@QNAME",model.QNAME),
                                       new SqlParameter("@ISACTION",model.QISACTION),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_QLTY_INSERT, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN QLTY_UPDATE(MES_PMM_QR model, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@QID",model.QID),
                                       new SqlParameter("@QCODE",model.QCODE),
                                       new SqlParameter("@QNAME",model.QNAME),
                                       new SqlParameter("@ISACTION",model.QISACTION),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_QLTY_UPDATE, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN QLTY_DELETE(int QID, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@QID",QID),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_QLTY_DELETE, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_PMM_QR_SELECT REP_SELECT(MES_PMM_QR model)
        {
            MES_PMM_QR_SELECT rst = new MES_PMM_QR_SELECT();
            rst.MES_PMM_QR = new List<MES_PMM_QR>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RCODE",model.RCODE),
                                       new SqlParameter("@RNAME",model.RNAME),
                                       new SqlParameter("@ISACTION",model.RISACTION)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_REP_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PMM_QR child = new MES_PMM_QR();
                        child.RID = Convert.ToInt32(sdr["RID"]);
                        child.RCODE = Convert.ToString(sdr["RCODE"]);
                        child.RNAME = Convert.ToString(sdr["RNAME"]);
                        child.RISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        rst.MES_PMM_QR.Add(child);
                    }
                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "无";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN REP_INSERT(MES_PMM_QR model, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RCODE",model.RCODE),
                                       new SqlParameter("@RNAME",model.RNAME),
                                       new SqlParameter("@ISACTION",model.RISACTION),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_REP_INSERT, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN REP_UPDATE(MES_PMM_QR model, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RID",model.RID),
                                       new SqlParameter("@RCODE",model.RCODE),
                                       new SqlParameter("@RNAME",model.RNAME),
                                       new SqlParameter("@ISACTION",model.RISACTION),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_REP_UPDATE, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN REP_DELETE(int RID, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RID",RID),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_REP_DELETE, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_PMM_QR_SELECT QR_SELECT_BY_QCODE(int QID)
        {
            MES_PMM_QR_SELECT rst = new MES_PMM_QR_SELECT();
            rst.MES_PMM_QR = new List<MES_PMM_QR>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@QID",QID),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_QR_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PMM_QR child = new MES_PMM_QR();
                        child.QID = Convert.ToInt32(sdr["QID"]);
                        child.RID = Convert.ToInt32(sdr["RID"]);
                        child.RCODE = Convert.ToString(sdr["RCODE"]);
                        child.RNAME = Convert.ToString(sdr["RNAME"]);
                        rst.MES_PMM_QR.Add(child);
                    }
                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "无";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN QR_COVER(MES_PMM_QR model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@QID",model.QID),
                                       new SqlParameter("@RID",model.RID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_QR_COVER, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN QR_DELETE(MES_PMM_QR model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@QID",model.QID),
                                       new SqlParameter("@RID",model.RID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_QR_DELETE, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }
    }
}
