using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class MSG_NOTICE : IMSG_NOTICE
    {
        private const string SQL_CreateTT = "CRM_MSG_NOTICE_CreateTT";
        private const string SQL_UpdateTT = "CRM_MSG_NOTICE_UpdateTT";
        private const string SQL_ReadTT = "CRM_MSG_NOTICE_ReadTT";
        private const string SQL_ReadTTbyTTID = "CRM_MSG_NOTICE_ReadTTbyTTID";
        private const string SQL_DeleteTT = "CRM_MSG_NOTICE_DeleteTT";
        private const string SQL_UpdateIsactive = "CRM_MSG_NOTICE_UpdateIsactive";


        private const string SQL_CreateMX = "CRM_MSG_NOTICE_CreateMX";
        private const string SQL_UpdateMX = "CRM_MSG_NOTICE_UpdateMX";
        private const string SQL_ReadMXbyTTID_KH = "CRM_MSG_NOTICE_ReadMXbyTTID_KH";
        private const string SQL_ReadMXbyTTID_STAFF = "CRM_MSG_NOTICE_ReadMXbyTTID_STAFF";
        private const string SQL_DeleteMX = "CRM_MSG_NOTICE_DeleteMX";
        private const string SQL_AddCount = "CRM_MSG_NOTICE_AddCount";
        private const string SQL_ReadMXbyParam = "CRM_MSG_NOTICE_ReadMXbyParam";


        private const string SQL_ReadBySTAFFID = "CRM_MSG_NOTICE_ReadBySTAFFID";

        public int CreateTT(CRM_MSG_NOTICETT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TITLE", model.TITLE),
                                        new SqlParameter("@NOTICE", model.NOTICE),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_CreateTT, parms);
        }

        public int CreateMX(CRM_MSG_NOTICEMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NOTICETTID", model.NOTICETTID),
                                        new SqlParameter("@USERID", model.USERID),
                                        new SqlParameter("@USERLX", model.USERLX),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_CreateMX, parms);
        }

        public int UpdateTT(CRM_MSG_NOTICETT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NOTICETTID", model.NOTICETTID),
                                        new SqlParameter("@TITLE", model.TITLE),
                                        new SqlParameter("@NOTICE", model.NOTICE),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateTT, parms);
        }

        public int UpdateIsactive(int NOTICETTID, int ISACTIVE)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NOTICETTID", NOTICETTID),
                                        new SqlParameter("@ISACTIVE", ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateIsactive, parms);
        }

        public int UpdateMX(CRM_MSG_NOTICEMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NOTICETTID", model.NOTICETTID),
                                        new SqlParameter("@USERID", model.USERID),
                                        new SqlParameter("@USERLX", model.USERLX),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateMX, parms);
        }
        public IList<CRM_MSG_NOTICETTList> ReadTT(CRM_MSG_NOTICETTParam model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@TITLE",model.TITLE),
                                       new SqlParameter("@NOTICE",model.NOTICE),
                                       new SqlParameter("@CJSJ_BEGIN",model.CJSJ_BEGIN),
                                       new SqlParameter("@CJSJ_END",model.CJSJ_END),
                                       new SqlParameter("@ISACTIVE",model.ISACTIVE)
                                   };
            IList<CRM_MSG_NOTICETTList> nodes = new List<CRM_MSG_NOTICETTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadTT, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadTTDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public CRM_MSG_NOTICETTList ReadTTbyTTID(int NOTICETTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@NOTICETTID",NOTICETTID)
                                   };
            CRM_MSG_NOTICETTList node = new CRM_MSG_NOTICETTList();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadTTbyTTID, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadTTDataToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public IList<CRM_MSG_NOTICEMXList_KH> ReadMXbyTTID_KH(int NOTICETTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@NOTICETTID",NOTICETTID)
                                   };
            IList<CRM_MSG_NOTICEMXList_KH> nodes = new List<CRM_MSG_NOTICEMXList_KH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXbyTTID_KH, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadMXDataToObj_KH(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_MSG_NOTICEMXList_STAFF> ReadMXbyTTID_STAFF(int NOTICETTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@NOTICETTID",NOTICETTID)
                                   };
            IList<CRM_MSG_NOTICEMXList_STAFF> nodes = new List<CRM_MSG_NOTICEMXList_STAFF>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXbyTTID_STAFF, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadMXDataToObj_STAFF(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int DeleteTT(int NOTICETTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NOTICETTID", NOTICETTID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteTT, parms);
        }

        public int DeleteMX(int NOTICEMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NOTICEMXID", NOTICEMXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteMX, parms);
        }

        public int AddCount(int NOTICETTID,int USERID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NOTICETTID", NOTICETTID),
                                        new SqlParameter("@USERID", USERID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_AddCount, parms);
        }

        public IList<CRM_MSG_NOTICETTList> ReadBySTAFFID(int STAFFID, int USERLX)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@USERLX",USERLX)
                                   };
            IList<CRM_MSG_NOTICETTList> nodes = new List<CRM_MSG_NOTICETTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadTTDataToObj1(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_MSG_NOTICEMX> ReadMXbyParam(CRM_MSG_NOTICEMX model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@NOTICETTID",model.NOTICETTID),
                                       new SqlParameter("@USERID",model.USERID),
                                       new SqlParameter("@USERLX",model.USERLX)
                                   };
            IList<CRM_MSG_NOTICEMX> nodes = new List<CRM_MSG_NOTICEMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXbyParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadMXDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }









        private int Binning(CommandType type, string sql, SqlParameter[] parms)
        {
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(type, sql, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["ID"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return ID;
        }

        private CRM_MSG_NOTICETTList ReadTTDataToObj(SqlDataReader sdr)
        {
            CRM_MSG_NOTICETTList node = new CRM_MSG_NOTICETTList();
            node.NOTICETTID = Convert.ToInt32(sdr["NOTICETTID"]);
            node.TITLE = Convert.ToString(sdr["TITLE"]);
            node.NOTICE = Convert.ToString(sdr["NOTICE"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            return node;
        }

        private CRM_MSG_NOTICETTList ReadTTDataToObj1(SqlDataReader sdr)
        {
            CRM_MSG_NOTICETTList node = new CRM_MSG_NOTICETTList();
            node.NOTICETTID = Convert.ToInt32(sdr["NOTICETTID"]);
            node.TITLE = Convert.ToString(sdr["TITLE"]);
            node.NOTICE = Convert.ToString(sdr["NOTICE"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.DEPIDDES = Convert.ToString(sdr["DEPIDDES"]);
            return node;
        }

        private CRM_MSG_NOTICEMX ReadMXDataToObj(SqlDataReader sdr)
        {
            CRM_MSG_NOTICEMXList_KH node = new CRM_MSG_NOTICEMXList_KH();
            node.NOTICEMXID = Convert.ToInt32(sdr["NOTICEMXID"]);
            node.NOTICETTID = Convert.ToInt32(sdr["NOTICETTID"]);
            node.USERID = Convert.ToInt32(sdr["USERID"]);
            node.USERLX = Convert.ToInt32(sdr["USERLX"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CKCS = Convert.ToInt32(sdr["CKCS"]);
            return node;
        }

        private CRM_MSG_NOTICEMXList_KH ReadMXDataToObj_KH(SqlDataReader sdr)
        {
            CRM_MSG_NOTICEMXList_KH node = new CRM_MSG_NOTICEMXList_KH();
            node.NOTICEMXID = Convert.ToInt32(sdr["NOTICEMXID"]);
            node.NOTICETTID = Convert.ToInt32(sdr["NOTICETTID"]);
            node.USERID = Convert.ToInt32(sdr["USERID"]);
            node.USERLX = Convert.ToInt32(sdr["USERLX"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.PKHID = Convert.ToString(sdr["PKHID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.USERLXDES = Convert.ToString(sdr["USERLXDES"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.PKHIDDES = Convert.ToString(sdr["PKHIDDES"]);
            return node;
        }

        private CRM_MSG_NOTICEMXList_STAFF ReadMXDataToObj_STAFF(SqlDataReader sdr)
        {
            CRM_MSG_NOTICEMXList_STAFF node = new CRM_MSG_NOTICEMXList_STAFF();
            node.NOTICEMXID = Convert.ToInt32(sdr["NOTICEMXID"]);
            node.NOTICETTID = Convert.ToInt32(sdr["NOTICETTID"]);
            node.USERID = Convert.ToInt32(sdr["USERID"]);
            node.USERLX = Convert.ToInt32(sdr["USERLX"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFLX = Convert.ToInt32(sdr["STAFFLX"]);
            node.DEPID = Convert.ToInt32(sdr["DEPID"]);
            node.USERLXDES = Convert.ToString(sdr["USERLXDES"]);
            node.STAFFLXDES = Convert.ToString(sdr["STAFFLXDES"]);
            node.DEPIDDES = Convert.ToString(sdr["DEPIDDES"]);
            return node;
        }

    }
}
