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
    public class KQ_YCKQSM : IKQ_YCKQSM
    {
        private const string SQL_Create = "CRM_KQ_YCKQSM_Create";
        private const string SQL_Update = "CRM_KQ_YCKQSM_Update";
        private const string SQL_ReadBySTAFFID = "CRM_KQ_YCKQSM_ReadBySTAFFID";//"SELECT * FROM CRM_KQ_YCKQSM WHERE STAFFID = @STAFFID AND ISACTIVE <> 0";
        private const string SQL_Delete = "CRM_KQ_YCKQSM_Delete";
        private const string SQL_ReadRLByStaff = "CRM_KQ_GetGZDATE";
        private const string SQL_ReadYGQJByStaff = "CRM_KQ_YGQJ_STAFF";
        private const string SQL_ReadCCTTByStaff = "CRM_KQ_CCTT_STAFF";
        private const string SQL_ReadByParam = "CRM_KQ_YCKQSM_ReadByParam";
        private const string SQL_UpdateStatus = "CRM_KQ_YCKQSM_UpdateStatus";

        public int Create(CRM_KQ_YCKQSM model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@YCKQID", model.YCKQID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@SMR", model.SMR),
                                        new SqlParameter("@SMRQ", model.SMRQ),
                                        new SqlParameter("@SMSXB", model.SMSXB),
                                        new SqlParameter("@SMRBMLD", model.SMRBMLD),
                                        new SqlParameter("@SMRBMZG", model.SMRBMZG),
                                        new SqlParameter("@SMSX", model.SMSX),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@KQQDID", model.KQQDID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_KQ_YCKQSM model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@YCKQID", model.YCKQID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@SMR", model.SMR),
                                        new SqlParameter("@SMRQ", model.SMRQ),
                                        new SqlParameter("@SMSXB", model.SMSXB),
                                        new SqlParameter("@SMRBMLD", model.SMRBMLD),
                                        new SqlParameter("@SMRBMZG", model.SMRBMZG),
                                        new SqlParameter("@SMSX", model.SMSX),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_KQ_YCKQSMList> ReadBySTAFFID(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_KQ_YCKQSMList> nodes = new List<CRM_KQ_YCKQSMList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_KQ_YCKQSMList> ReadByParam(CRM_KQ_YCKQSMList model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@SMRQ",model.SMRQ),
                                       new SqlParameter("@SMSXB",model.SMSXB),
                                       new SqlParameter("@SMRQ_BEGIN",model.SMRQ_BEGIN),
                                       new SqlParameter("@SMRQ_END",model.SMRQ_END),
                                       new SqlParameter("@DEP",model.DEP),
                                       new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                       new SqlParameter("@STAFFNO",model.STAFFNO),
                                       new SqlParameter("@STAFFTYPE",model.STAFFTYPE),
                                       new SqlParameter("@ISACTIVE",model.ISACTIVE)
                                   };
            IList<CRM_KQ_YCKQSMList> nodes = new List<CRM_KQ_YCKQSMList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
   
        public IList<CRM_KQ_YCKQList> Report_YC(int STAFFID, string fromdate, string todate)
        {
            SqlParameter[] parms_rl = {
                                          new SqlParameter("@STAFFID",STAFFID),
                                          new SqlParameter("@FROMDATE",fromdate),
                                          new SqlParameter("@TODATE",todate)
                                      };
            IList<CRM_KQ_YCKQList> nodes_rl = new List<CRM_KQ_YCKQList>();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadRLByStaff, parms_rl))
                {
                    while (sdr.Read())
                    {
                        CRM_KQ_YCKQList node = new CRM_KQ_YCKQList();
                        CRM_KQ_YCKQList node1 = new CRM_KQ_YCKQList();
                        node.DATE = Convert.ToString(sdr["DATE"]);
                        node1.DATE = Convert.ToString(sdr["DATE"]);
                        node.ISAM = true;
                        nodes_rl.Add(node);
                        node1.ISAM = false;
                        nodes_rl.Add(node1);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            DataAccess.RMS.CRM.KQ_QD KQ_QD = new KQ_QD();
            IList<CRM_KQ_QD> nodes_qd = KQ_QD.ReadByQDLXandQDGSID(1, STAFFID);
            for (int i = nodes_rl.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < nodes_qd.Count; j++)
                {
                    string date = nodes_qd[j].QDSJ;

                    nodes_qd[j].QDSJ = date.Substring(0, 10);
                    DateTime date1 = new DateTime();

                    date1 = Convert.ToDateTime(nodes_qd[j].QDSJ);
                    nodes_qd[j].QDSJ = date1.ToString("yyyy-MM-dd");

                    if (nodes_qd[j].SXB == 1)
                    {
                        if (nodes_rl[i].DATE == nodes_qd[j].QDSJ && nodes_rl[i].ISAM == true)
                        {
                            nodes_rl.Remove(nodes_rl[i]);
                        }
                    }
                    else if (nodes_qd[j].SXB == 2)
                    {
                        if (nodes_rl[i].DATE == nodes_qd[j].QDSJ && nodes_rl[i].ISAM == false)
                        {
                            nodes_rl.Remove(nodes_rl[i]);
                        }
                    }



                }
            }

            for (int i = nodes_rl.Count - 1; i >= 0; i--)
            {
                DateTime date1 = new DateTime();

                date1 = Convert.ToDateTime(nodes_rl[i].DATE);
                nodes_rl[i].DATE = date1.ToString("yyyy-MM-dd");
                int temp = Conflict_YGQJ(STAFFID, nodes_rl[i].DATE, nodes_rl[i].ISAM);
                if (temp > 0)
                {
                    nodes_rl.Remove(nodes_rl[i]);
                }
            }

            for (int i = nodes_rl.Count - 1; i >= 0; i--)
            {
                DateTime date1 = new DateTime();

                date1 = Convert.ToDateTime(nodes_rl[i].DATE);
                nodes_rl[i].DATE = date1.ToString("yyyy-MM-dd");
                int temp = Conflict_CCTT(STAFFID, nodes_rl[i].DATE, nodes_rl[i].ISAM);
                if (temp > 0)
                {
                    nodes_rl.Remove(nodes_rl[i]);
                }
            }



            return nodes_rl;

        }

        private int Conflict_YGQJ(int STAFF, string date, bool isAM)
        {

            date = isAM == true ? date + " 08:00:00.000" : date + " 17:00:00.000";

            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFF),
                                       new SqlParameter("@DATE",date)
                                   };


            return Binning(CommandType.StoredProcedure, SQL_ReadCCTTByStaff, parms);


        }
        private int Conflict_CCTT(int STAFF, string date, bool isAM)
        {
            date = isAM == true ? date + " 08:00:00.000" : date + " 17:00:00.000";

            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFF),
                                       new SqlParameter("@DATE",date)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_ReadCCTTByStaff, parms);
        }

        public int Delete(int YCKQID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@YCKQID", YCKQID)
                                        

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int UpdateStatus(int YCKQID, int ISACTIVE)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@YCKQID", YCKQID),
                                        new SqlParameter("@ISACTIVE", ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateStatus, parms);
        }

        private CRM_KQ_YCKQSMList ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KQ_YCKQSMList node = new CRM_KQ_YCKQSMList();
            node.YCKQID = Convert.ToInt32(sdr["YCKQID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.SMR = Convert.ToString(sdr["SMR"]);
            node.SMRQ = Convert.ToString(sdr["SMRQ"]);
            node.SMSXB = Convert.ToInt32(sdr["SMSXB"]);
            node.SMRBMLD = Convert.ToString(sdr["SMRBMLD"]);
            node.SMRBMZG = Convert.ToString(sdr["SMRBMZG"]);
            node.SMSX = Convert.ToString(sdr["SMSX"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.KQQDID = Convert.ToInt32(sdr["KQQDID"]);
            node.QDSJ = Convert.ToString(sdr["QDSJ"]);
            node.QDWZ = Convert.ToString(sdr["QDWZ"]);
            node.KQJL = Convert.ToString(sdr["KQJL"]);
            return node;
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
    }
}
