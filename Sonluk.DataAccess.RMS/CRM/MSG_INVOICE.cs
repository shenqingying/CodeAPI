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
    public class MSG_INVOICE : IMSG_INVOICE
    {
        private const string SQL_Create = "CRM_MSG_INVOICE_Create";
        private const string SQL_Update = "CRM_MSG_INVOICE_Update";
        private const string SQL_ReadByParam = "CRM_MSG_INVOICE_ReadByParam";
        private const string SQL_Delete = "CRM_MSG_INVOICE_Delete";
        private const string SQL_ReadByKHID = "CRM_MSG_INVOICE_ReadByKHID";


        private const string SQL_AddCount = "CRM_MSG_INVOICE_AddCount";

        public int Create(CRM_MSG_INVOICE model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@FPHM", model.FPHM),
                                        new SqlParameter("@FPSL", model.FPSL),
                                        new SqlParameter("@KDDH", model.KDDH),
                                        new SqlParameter("@JSRQ", model.JSRQ),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_MSG_INVOICE model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@INVOICEID", model.INVOICEID),
                                        new SqlParameter("@FPHM", model.FPHM),
                                        new SqlParameter("@FPSL", model.FPSL),
                                        new SqlParameter("@KDDH", model.KDDH),
                                        new SqlParameter("@JSRQ", model.JSRQ),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public int AddCount(int INVOICEID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@INVOICEID", INVOICEID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_AddCount, parms);
        }
        public IList<CRM_MSG_INVOICEList> ReadByParam(CRM_MSG_INVOICEParam model)
        {
            SqlParameter[] parms = {
                                       
                                       new SqlParameter("@MC",model.MC),
                                       new SqlParameter("@FPHM",model.FPHM),
                                       new SqlParameter("@JSRQ_BEGIN",model.JSRQ_BEGIN),
                                       new SqlParameter("@JSRQ_END",model.JSRQ_END)
                                   };
            IList<CRM_MSG_INVOICEList> nodes = new List<CRM_MSG_INVOICEList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_MSG_INVOICEList> ReadByKHID(int KHID)
        {
            SqlParameter[] parms = {
                                       
                                       new SqlParameter("@KHID",KHID)
                                   };
            IList<CRM_MSG_INVOICEList> nodes = new List<CRM_MSG_INVOICEList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByKHID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int INVOICEID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@INVOICEID", INVOICEID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
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

        private CRM_MSG_INVOICEList ReadDataToObj(SqlDataReader sdr)
        {
            CRM_MSG_INVOICEList node = new CRM_MSG_INVOICEList();
            node.INVOICEID = Convert.ToInt32(sdr["INVOICEID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.FPHM = Convert.ToString(sdr["FPHM"]);
            node.FPSL = Convert.ToInt32(sdr["FPSL"]);
            node.KDDH = Convert.ToString(sdr["KDDH"]);
            node.JSRQ = Convert.ToString(sdr["JSRQ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CKCS = Convert.ToInt32(sdr["CKCS"]);
            return node;
        }

    }
}
