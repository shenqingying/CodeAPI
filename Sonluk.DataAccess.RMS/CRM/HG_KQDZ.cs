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
    public class HG_KQDZ : IHG_KQDZ
    {
        private const string SQL_Create = "CRM_HG_KQDZ_Create";
        private const string SQL_Update = "CRM_HG_KQDZ_Update";
        private const string SQL_Read = "CRM_HG_KQDZ_Read";
        //private const string SQL_ReadBySTAFFID = "SELECT A.KQDZID,A.KQDZ,ISNULL(A.GJ,0) AS GJ ,ISNULL(A.SF,0) AS SF,ISNULL(A.CS,0) AS CS,A.ED,A.JD,A.KQRC,A.ISACTIVE,A.CJSJ,A.STAFFID FROM CRM_HG_KQDZ AS A INNER JOIN CRM_HG_RYKQ ON CRM_HG_RYKQ.KQDZID = A.KQDZID  WHERE A.ISACTIVE = 2 AND CRM_HG_RYKQ.STAFFID = @STAFFID";
        private const string SQL_ReadBySTAFFID = "CRM_HG_KQDZBySTAFFID";
        private const string SQL_Delete = "CRM_HG_KQDZ_Delete";
        private const string SQL_ReadBylikeKQDZ = "CRM_HG_KQDZ_ReadBylikeKQDZ";//"SELECT A.KQDZ,A.KQDZID,ISNULL(A.GJ,0) AS GJ ,ISNULL(A.SF,0) AS SF,ISNULL(A.CS,0) AS CS,A.ED,A.JD,A.KQRC,A.ISACTIVE,A.ISACTIVE,A.CJSJ,A.STAFFID,A.DWDZMS FROM CRM_HG_KQDZ AS A where KQDZ like @KQDZ AND A.ISACTIVE = 2";
        private const string SQL_Report = "CRM_HG_KQDZ_Report";

        public int Create(CRM_HG_KQDZ model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@KQDZID", model.KQDZID),
                                        new SqlParameter("@KQDZ", model.KQDZ),
                                        new SqlParameter("@GJ", model.GJ),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@ED", model.ED),
                                        new SqlParameter("@JD", model.JD),
                                        new SqlParameter("@KQRC", model.KQRC),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@CJSJ",model.CJSJ),
                                        new SqlParameter("@DWDZMS",model.DWDZMS)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HG_KQDZ model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KQDZID", model.KQDZID),
                                        new SqlParameter("@KQDZ", model.KQDZ),
                                        new SqlParameter("@GJ", model.GJ),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@ED", model.ED),
                                        new SqlParameter("@JD", model.JD),
                                        new SqlParameter("@KQRC", model.KQRC),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@CJSJ",model.CJSJ),
                                        new SqlParameter("@DWDZMS",model.DWDZMS)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
       
        public IList<CRM_HG_KQDZ> Read(int KQDZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KQDZID",KQDZID)
                                   };
            IList<CRM_HG_KQDZ> nodes = new List<CRM_HG_KQDZ>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
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
        public IList<CRM_HG_KQDZ> ReadBySTAFFID(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_HG_KQDZ> nodes = new List<CRM_HG_KQDZ>();
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

        public IList<CRM_HG_KQDZ> ReadBylikeKQDZ(string KQDZ)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KQDZ",KQDZ )
                                   };
            IList<CRM_HG_KQDZ> nodes = new List<CRM_HG_KQDZ>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBylikeKQDZ, parms))
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

        public IList<CRM_HG_KQDZList> Report(CRM_HG_KQDZList model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@KQDZID",model.KQDZID),
                                       new SqlParameter("@ISACTIVE",model.ISACTIVE)
                                   };
            IList<CRM_HG_KQDZList> nodes = new List<CRM_HG_KQDZList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject1(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;

        }

        public int Delete(int KQDZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KQDZID",KQDZID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }






        private CRM_HG_KQDZList ReadDataToObject1(SqlDataReader sdr)
        {
            CRM_HG_KQDZList node = new CRM_HG_KQDZList();
            node.KQDZID = Convert.ToInt32(sdr["KQDZID"]);
            node.KQDZ = Convert.ToString(sdr["KQDZ"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.ED = Convert.ToString(sdr["ED"]);
            node.JD = Convert.ToString(sdr["JD"]);
            node.KQRC = Convert.ToInt32(sdr["KQRC"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFIDDES = Convert.ToString(sdr["STAFFIDDES"]);
            node.DWDZMS = Convert.ToString(sdr["DWDZMS"]);
            return node;
        }


        private CRM_HG_KQDZ ReadDataToObject(SqlDataReader sdr)
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
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.DWDZMS = Convert.ToString(sdr["DWDZMS"]);
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
