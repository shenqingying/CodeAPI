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
    public class KH_GROUP_STAFF : IKH_GROUP_STAFF
    {
        private const string SQL_Create = "CRM_KH_GROUP_STAFF_Create";
        //private const string SQL_Update = "CRM_KH_GROUP_KH_Update";
        private const string SQL_Delete = "CRM_KH_GROUP_STAFF_Delete";
        //private const string SQL_ReadByKHID = @"SELECT CRM_KH_GROUP_KH.GID,(SELECT GNAME FROM CRM_KH_GROUP WHERE GID = CRM_KH_GROUP_KH.GID) AS GNAME FROM CRM_KH_KH INNER JOIN CRM_KH_GROUP_KH ON CRM_KH_KH.KHID = CRM_KH_GROUP_KH.KHID WHERE CRM_KH_KH.KHID = @KHID";
        private const string SQL_ReadByStaffID = "CRM_KH_GROUP_STAFF_ReadByStaffID";//"SELECT CRM_KH_GROUP_STAFF.GID,ISNULL((SELECT GNAME FROM CRM_KH_GROUP WHERE GID = CRM_KH_GROUP_STAFF.GID),' ') AS GNAME FROM CRM_HG_STAFF INNER JOIN CRM_KH_GROUP_STAFF ON CRM_HG_STAFF.STAFFID = CRM_KH_GROUP_STAFF.STAFFID WHERE CRM_HG_STAFF.STAFFID = @STAFFID AND CRM_HG_STAFF.ISACTIVE = 1";
        private const string SQL_Read = "CRM_KH_GROUP_STAFF_Read";//@"SELECT A.STAFFID,A.GID,B.STAFFNAME,B.STAFFNO,C.GNAME FROM CRM_KH_GROUP_STAFF AS A INNER JOIN CRM_HG_STAFF AS B ON A.STAFFID = B.STAFFID INNER JOIN CRM_KH_GROUP AS C ON  C.GID = A.GID WHERE B.ISACTIVE = 1";
        private const string SQL_ReadStruct = "CRM_KH_GROUP_STAFF_ReadStruct";//"select a.*,ISNULL((SELECT GNAME FROM CRM_KH_GROUP WHERE GID = A.GID),' ') AS GIDDES,ISNULL((SELECT STAFFNAME FROM CRM_HG_STAFF where STAFFID = a.STAFFID),' ') AS STAFFDES from CRM_KH_GROUP_STAFF as a where STAFFID=@STAFFID and GID=@GID";
        private const string SQL_Update = "CRM_KH_GROUP_STAFF_Update";
        private const string SQL_Report = "CRM_KH_GROUP_STAFF_Report";

        public int Create(int STAFFID, int GID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@GID",GID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(int STAFFID, int oGID, int nGid)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@oGID",oGID),
                                       new SqlParameter("@nGid",nGid)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_KH_GROUP_STAFFList> Report(string STAFFNAME, int GID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFNAME",STAFFNAME),
                                       new SqlParameter("@GID",GID)
                                   };
            IList<CRM_KH_GROUP_STAFFList> nodes = new List<CRM_KH_GROUP_STAFFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Report,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToStruct(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }





        public CRM_KH_GROUP_STAFFList ReadStruct(int STAFFID, int GID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@GID",GID)
                                   };
            CRM_KH_GROUP_STAFFList node = new CRM_KH_GROUP_STAFFList();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadStruct,parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToStruct(sdr);
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);

            }
            return node;
        }




      
      
        public IList<string[]> Read()
        {
            IList<string[]> nodes = new List<string[]>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, null))
                {
                    while (sdr.Read())
                    {
                        string[] node = new string[5];
                        node[0] = Convert.ToString(sdr["GID"]);
                        node[1] = Convert.ToString(sdr["GNAME"]);
                        node[2] = Convert.ToString(sdr["STAFFID"]);
                        node[3] = Convert.ToString(sdr["STAFFNAME"]);
                        node[4] = Convert.ToString(sdr["STAFFNO"]);
                        //A.STAFFID,A.GID,B.STAFFID,B.STAFFNO,C.GNAME
                        nodes.Add(node);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }




        public IList<string[]> ReadByStaffID(int StaffID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",StaffID)
                                   };
            IList<string[]> nodes = new List<string[]>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadByStaffID,parms))
                {
                    while (sdr.Read())
                    {
                        string[] node = new string[2];
                        node[0] = Convert.ToString(sdr["GID"]);
                        node[1] = Convert.ToString(sdr["GNAME"]);
                        nodes.Add(node);
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int STAFFID, int GID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@GID",GID)
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

        private CRM_KH_GROUP_STAFFList ReadDataToStruct(SqlDataReader sdr)
        {
            CRM_KH_GROUP_STAFFList node = new CRM_KH_GROUP_STAFFList();
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.GIDDES = Convert.ToString(sdr["GIDDES"]);
            node.STAFFIDDES = Convert.ToString(sdr["STAFFIDDES"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            return node;
        }
    }
}
