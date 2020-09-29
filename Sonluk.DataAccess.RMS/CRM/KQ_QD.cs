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
    public class KQ_QD : IKQ_QD
    {
        private const string SQL_Create = "CRM_KQ_QD_Create";
        private const string SQL_Update = "CRM_KQ_QD_Update";
        private const string SQL_ReadByKQQDID = "CRM_KQ_QD_ReadByKQQDID";
        private const string SQL_ReadByQDLXandQDGSID = "CRM_KQ_QD_ReadByQDLXandQDGSID";//"SELECT * FROM CRM_KQ_QD WHERE QDLX = @QDLX AND  QDGSID = @QDGSID AND ISACTIVE = 1";

        private const string SQL_Delete = "CRM_KQ_QD_Delete";
        private const string SQL_Verify_QD = "CRM_KQ_QD_Verify";
        private const string SQL_ReadQD_COUNTS = "CRM_KQ_QD_ReadQD_COUNTS";
        private const string SQL_ReadYCQD_BYDATE = "CRM_KQ_QD_ReadYCQD_BYDATE";





        public int Create(CRM_KQ_QD model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@KQQDID", model.KQQDID),
                                        new SqlParameter("@QDLX", model.QDLX),
                                        new SqlParameter("@QDGSID", model.QDGSID),
                                        new SqlParameter("@QDGSHXMID", model.QDGSHXMID),
                                        new SqlParameter("@SXB", model.SXB),
                                        new SqlParameter("@QDSJ", model.QDSJ),
                                        new SqlParameter("@GJ", model.GJ),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@QDWZ", model.QDWZ),
                                        new SqlParameter("@QDJD", model.QDJD),
                                        new SqlParameter("@QDWD", model.QDWD),
                                        new SqlParameter("@KQJL", model.KQJL),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_KQ_QD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KQQDID", model.KQQDID),
                                        new SqlParameter("@QDLX", model.QDLX),
                                        new SqlParameter("@QDGSID", model.QDGSID),
                                        new SqlParameter("@QDGSHXMID", model.QDGSHXMID),
                                        new SqlParameter("@SXB", model.SXB),
                                        new SqlParameter("@QDSJ", model.QDSJ),
                                        new SqlParameter("@GJ", model.GJ),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@QDWZ", model.QDWZ),
                                        new SqlParameter("@QDJD", model.QDJD),
                                        new SqlParameter("@QDWD", model.QDWD),
                                        new SqlParameter("@KQJL", model.KQJL),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public CRM_KQ_QD ReadByKQQDID(int KQQDID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KQQDID",KQQDID)
                                   };
            CRM_KQ_QD node = new CRM_KQ_QD();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByKQQDID, parms))
                {
                    while (sdr.Read())
                    {
                        node = ReadDataToObject(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }



            return node;
        }

        public IList<string[]> Verify_QD(int STAFFID, string ED, string JD, double WXRC)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_HG_KQDZ> nodes = new List<CRM_HG_KQDZ>();
            IList<string[]> strArr = new List<string[]>();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Verify_QD, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToKQDZ(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            for (int i = 0; i < nodes.Count; i++)
            {


                double reED = Convert.ToDouble(nodes[i].ED);
                double reJD = Convert.ToDouble(nodes[i].JD);
                double RC = GetDistance(Convert.ToDouble(ED), Convert.ToDouble(JD), reED, reJD);
                int KQDZID = nodes[i].KQDZID;
                int res = nodes[i].KQRC + WXRC > RC ? 1 : 0;
                if (res == 1)
                {
                    string[] node = new string[2];
                    node[0] = KQDZID.ToString();
                    node[1] = RC.ToString();
                    strArr.Add(node);
                }



            }

            return strArr;


        }
        public int ReadQD_COUNTS(CRM_KQ_QD model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@QDLX",model.QDLX),
                                       new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                       new SqlParameter("@QDGSID",model.QDGSID),
                                       new SqlParameter("@SXB",model.SXB),
                                       new SqlParameter("@QDRQ",model.QDRQ)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_ReadQD_COUNTS, parms);
        }




        public IList<CRM_KQ_QD> ReadByQDLXandQDGSID(int QDLX, int QDGSID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@QDLX",QDLX),
                                       new SqlParameter("@QDGSID",QDGSID)
                                   };
            IList<CRM_KQ_QD> nodes = new List<CRM_KQ_QD>();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByQDLXandQDGSID, parms))
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



        public IList<CRM_KQ_QD> ReadYCQD_ByDATE(string QDRQ, int SXB, int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@QDRQ",QDRQ),
                                       new SqlParameter("@SXB",SXB),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_KQ_QD> nodes = new List<CRM_KQ_QD>();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadYCQD_BYDATE, parms))
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



        public int Delete(int KQQDID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KQQDID",KQQDID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }





        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double EARTH_RADIUS = 6378137;

            double radLat1 = Rad(lat1);
            double radLng1 = Rad(lng1);
            double radLat2 = Rad(lat2);
            double radLng2 = Rad(lng2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            return result;
        }
        private static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }

        private CRM_HG_KQDZ ReadDataToKQDZ(SqlDataReader sdr)
        {
            CRM_HG_KQDZ node = new CRM_HG_KQDZ();
            node.KQDZID = Convert.ToInt32(sdr["KQDZID"]);
            node.KQDZ = Convert.ToString(sdr["KQDZ"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.ED = Convert.ToString(sdr["ED"]);
            node.JD = Convert.ToString(sdr["JD"]);
            node.KQRC = Convert.ToInt32(sdr["KQRC"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            return node;
        }
        private CRM_KQ_QD ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KQ_QD node = new CRM_KQ_QD();
            node.KQQDID = Convert.ToInt32(sdr["KQQDID"]);
            node.QDLX = Convert.ToInt32(sdr["QDLX"]);
            node.QDGSID = Convert.ToInt32(sdr["QDGSID"]);
            node.QDGSHXMID = Convert.ToInt32(sdr["QDGSHXMID"]);
            node.SXB = Convert.ToInt32(sdr["SXB"]);
            node.QDSJ = Convert.ToString(sdr["QDSJ"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.QDWZ = Convert.ToString(sdr["QDWZ"]);
            node.QDJD = Convert.ToString(sdr["QDJD"]);
            node.QDWD = Convert.ToString(sdr["QDWD"]);
            node.KQJL = Convert.ToString(sdr["KQJL"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.QDRQ = Convert.ToDateTime(sdr["QDRQ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
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
