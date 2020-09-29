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
    public class KH_GROUP_KH : IKH_GROUP_KH
    {
        private const string SQL_Create = "CRM_KH_GROUP_KH_Create";
        private const string SQL_Update = "CRM_KH_GROUP_KH_Update";
        private const string SQL_Delete = "CRM_KH_GROUP_KH_Delete";
        private const string SQL_ReadByKHID = "CRM_KH_GROUP_KH_ReadByKHID";//@"SELECT CRM_KH_GROUP_KH.GID,ISNULL((SELECT GNAME FROM CRM_KH_GROUP WHERE GID = CRM_KH_GROUP_KH.GID),'') AS GNAME FROM CRM_KH_KH INNER JOIN CRM_KH_GROUP_KH ON CRM_KH_KH.KHID = CRM_KH_GROUP_KH.KHID WHERE CRM_KH_KH.KHID = @KHID AND CRM_KH_KH.ISACTIVE <> 0";
        private const string SQL_Read = "CRM_KH_GROUP_KH_Read";//@"SELECT A.GID,A.KHID,C.CRMID,C.MC,B.GNAME FROM CRM_KH_GROUP_KH AS A INNER JOIN CRM_KH_GROUP AS B ON A.GID = B.GID INNER JOIN CRM_KH_KH AS C ON C.KHID = A.KHID WHERE C.ISACTIVE <> 0  AND C.ISDELETE = 0";
        private const string SQL_ReadBySTAFFID = "CRM_KH_GROUP_KH_ReadBySTAFFID";
        private const string SQL_DeleteByKHID = "CRM_KH_GROUP_KH_DeleteByKHID";
        private const string SQL_ReadStruct = "CRM_KH_GROUP_KH_ReadStruct";//@"SELECT A.*,ISNULL((SELECT GNAME FROM CRM_KH_GROUP WHERE GID = A.GID),'') AS GIDDES,ISNULL((SELECT MC FROM CRM_KH_KH WHERE CRM_KH_KH.KHID = A.KHID),' ') AS KHIDDES FROM CRM_KH_GROUP_KH AS A where  KHID=@KHID and GID=@GID";
        private const string SQL_ReadByGid = "CRM_KH_GROUP_KH_ReadByGid";//@"SELECT A.*,ISNULL((SELECT GNAME FROM CRM_KH_GROUP WHERE GID = A.GID),' ') AS GIDDES,ISNULL((SELECT MC FROM CRM_KH_KH WHERE CRM_KH_KH.KHID = A.KHID),' ') AS KHIDDES FROM CRM_KH_GROUP_KH AS A where  GID=@GID";
        private const string SQL_Report = "CRM_KH_GROUP_KH_Report";
        private const string SQL_Report2 = "CRM_KH_GROUP_KH_Report2";
        //private const string SQL_Update = "CRM_KH_GROUP_KH_Update";

        public int Create(int KHID, int GID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       new SqlParameter("@GID",GID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(int KHID, int oGID, int nGid)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       new SqlParameter("@oGID",oGID),
                                       new SqlParameter("@nGid",nGid)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_KH_GROUP_KHList> Report(string KHMC, int GID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHMC",KHMC),
                                       new SqlParameter("@GID",GID)
                                   };
            IList<CRM_KH_GROUP_KHList> nodes = new List<CRM_KH_GROUP_KHList>();
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

        public IList<CRM_KH_GROUP_KHList> Report2(CRM_KH_GROUP_KHList model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@GID",model.GID),
                                       new SqlParameter("@JXSMC",model.JXSMC),
                                       new SqlParameter("@JXSCRMID",model.JXSCRMID),
                                       new SqlParameter("@JXSSAPSN",model.JXSSAPSN)
                                   };
            IList<CRM_KH_GROUP_KHList> nodes = new List<CRM_KH_GROUP_KHList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report2, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToStruct2(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        //ISNULL((SELECT MC FROM CRM_KH_KH  AS B WHERE B.CRMID = A.PKHID),'''')
        public IList<CRM_KH_GROUP_KHList> ReadStruct(int KHID, int GID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       new SqlParameter("@GID",GID)
                                   };
            IList<CRM_KH_GROUP_KHList> nodes = new List<CRM_KH_GROUP_KHList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadStruct,parms))
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
                        node[1] = Convert.ToString(sdr["KHID"]);
                        node[2] = Convert.ToString(sdr["CRMID"]);
                        node[3] = Convert.ToString(sdr["MC"]);
                        node[4] = Convert.ToString(sdr["GNAME"]);
                        //A.GID,A.KHID,C.CRMID,C.MC,B.GNAME
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


        public IList<string[]> ReadByStaffid(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID) 
                                   };
            IList<string[]> nodes = new List<string[]>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        string[] node = new string[5];
                        node[0] = Convert.ToString(sdr["GID"]);
                        node[1] = Convert.ToString(sdr["KHID"]);
                        node[2] = Convert.ToString(sdr["CRMID"]);
                        node[3] = Convert.ToString(sdr["MC"]);
                        node[4] = Convert.ToString(sdr["GNAME"]);
                        //A.GID,A.KHID,C.CRMID,C.MC,B.GNAME
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

        //public IList<CRM_KH_GROUP_KHList> ReadByParm(int KHID,int GID)
        //{
        //    SqlParameter[] parms = {
        //                               new SqlParameter("@GID",GID),
        //                               new SqlParameter("@KHID",KHID)
        //                           };
        //    IList<CRM_KH_GROUP_KHList> nodes = new List<CRM_KH_GROUP_KHList>();
        //    try
        //    {
        //        using (SqlDataReader sdr = SQLServerHelper.ExecuteNonQuery(CommandType.Text,SQL_ReadByGid,parms))
        //        {

        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw new ApplicationException(e.Message);
        //    }
        //    return nodes;
        //}



        public IList<string[]> ReadByKHID(int KHID)
        {
            IList<string[]> nodes = new List<string[]>();

            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByKHID, parms))
                {
                    while (sdr.Read())
                    {
                        string[] node = new string[2];
                        node[0] = Convert.ToString(sdr["GID"]);
                        node[1] = Convert.ToString(sdr["GNAME1"]);
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


     

        

        public int Delete(int KHID, int GID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       new SqlParameter("@GID",GID)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Delete, parms);
        }
        public int DeletebyKHID(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_DeleteByKHID, parms);
        }

        //public int Update(int KHID, int GID)
        //{
        //    SqlParameter[] parms = {
        //                               new SqlParameter("@KHID",KHID),
        //                               new SqlParameter("@GID",GID)
        //                           };
        //    return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Update, parms);
        //}



     

       



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

        private CRM_KH_GROUP_KHList ReadDataToStruct(SqlDataReader sdr)
        {
            CRM_KH_GROUP_KHList node = new CRM_KH_GROUP_KHList();
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.KHIDDES = Convert.ToString(sdr["KHIDDES"]);
            node.GIDDES = Convert.ToString(sdr["GIDDES"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            return node;
        }

        private CRM_KH_GROUP_KHList ReadDataToStruct2(SqlDataReader sdr)
        {
            CRM_KH_GROUP_KHList node = new CRM_KH_GROUP_KHList();
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.KHIDDES = Convert.ToString(sdr["KHIDDES"]);
            node.GIDDES = Convert.ToString(sdr["GIDDES"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.JXSMC = Convert.ToString(sdr["JXSMC"]);
            node.JXSCRMID = Convert.ToString(sdr["JXSCRMID"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            return node;
        }

    }
}
