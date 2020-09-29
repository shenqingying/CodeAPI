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
    public class HG_ROLE : IHG_ROLE
    {
        //hg_role
        private const string SQL_Create = "CRM_HG_ROLE_Create";
        private const string SQL_Update = "CRM_HG_ROLE_Update";
        private const string SQL_Read = "CRM_HG_ROLE_Read";//"SELECT * FROM CRM_HG_ROLE WHERE ISACTIVE = 1";
        private const string SQL_Delete = "CRM_HG_ROLE_Delete";

        //hg_staffrole
        private const string SQL_Create_STAFFROLE = "CRM_HG_STAFFROLE_Create";
        private const string SQL_Read_STAFFROLEbyROLEID = "CRM_HG_STAFFROLE_ReadSTAFFROLEbyROLEID";//"SELECT * FROM CRM_HG_STAFFROLE WHERE  ROLEID = @ROLEID";
        private const string SQL_Read_STAFFROLEbySTAFFID = "CRM_HG_STAFFROLE_ReadSTAFFROLEbySTAFFID";
//    @"SELECT A.*,
//        ISNULL((SELECT STAFFNAME FROM CRM_HG_STAFF WHERE STAFFID = A.STAFFID),' ') AS STAFFNAME,
//         ISNULL((SELECT STAFFNO FROM CRM_HG_STAFF WHERE STAFFID = A.STAFFID),' ') AS STAFFNO,
//         ISNULL((SELECT ROLENAME FROM CRM_HG_ROLE WHERE ROLEID = A.ROLEID),' ') AS ROLEIDDES
//         FROM CRM_HG_STAFFROLE AS A  WHERE STAFFID = @STAFFID";
        private const string SQL_Delete_STAFFROLE = "CRM_HG_STAFFROLE_Delete";
        private const string SQL_Delete_STAFFROLEByStaffid = "delete from CRM_HG_STAFFROLE where STAFFID = @STAFFID";




        //hg_rolegight 
        private const string SQL_Create_ROLERIGHT = "CRM_HG_ROLERIGHT_Create";
        //private const string SQL_Read_ROLERIGHTByRIGHTID = "CRM_HG_ROLERIGHT_ReadROLERIGHTByRIGHTID";//"SELECT * FROM CRM_HG_ROLERIGHT WHERE RIGHTID = @RIGHTID";
        private const string SQL_Read_ROLERIGHTByROLEID = "CRM_HG_ROLERIGHT_ReadROLERIGHTByROLEID";//"SELECT RIGHTID FROM CRM_HG_ROLERIGHT WHERE ROLEID = @ROLEID";
        private const string SQL_Delete_ROLERIGHT = "CRM_HG_ROLERIGHT_Delete";





        public int Create(CRM_HG_ROLE model)
        {
            SqlParameter[] parms ={
                                      //new SqlParameter("@ROLEID", model.ROLEID),
                                      new SqlParameter("@ROLENAME", model.ROLENAME),
                                      new SqlParameter("@ROLEMEMO", model.ROLEMEMO),
                                      new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                  };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HG_ROLE model)
        {
            SqlParameter[] parms ={
                                      new SqlParameter("@ROLEID", model.ROLEID),
                                      new SqlParameter("@ROLENAME", model.ROLENAME),
                                      new SqlParameter("@ROLEMEMO", model.ROLEMEMO),
                                      new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                  };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
     
        public IList<CRM_HG_ROLE> Read()
        {
            IList<CRM_HG_ROLE> nodes = new List<CRM_HG_ROLE>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, null))
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
        public int Delete(int ROLEID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ROLEID",ROLEID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }




        public int Create_STAFFROLE(int STAFFID, int ROLEID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@ROLEID",ROLEID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create_STAFFROLE, parms);
        }
        public IList<string[]> Read_STAFFROLEbyROLEID(int ROLEID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ROLEID",ROLEID)
                                   };
            IList<string[]> nodes = new List<string[]>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_STAFFROLEbyROLEID, parms))
                {
                    while (sdr.Read())
                    {
                        string[] node = new string[2];
                        node[0] = Convert.ToString(sdr["STAFFID"]);
                        node[1] = Convert.ToString(sdr["ROLEID"]);
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



        public IList<int> Read_ROLERIGHTByROLEID(int ROLEID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ROLEID",ROLEID)
                                   };
             IList<int> nodes = new List<int>();
             try
             {
                 using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_ROLERIGHTByROLEID, parms))
                 {
                     while (sdr.Read())
                     {
                         int node;
                         node = Convert.ToInt32(sdr["RIGHTID"]);
                        
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








        public int Delete_STAFFROLE(int STAFFID, int ROLEID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@ROLEID",ROLEID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete_STAFFROLE, parms);
        }


        public int Create_ROLERIGHT(int ROLEID, int RIGHTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ROLEID",ROLEID),
                                       new SqlParameter("@RIGHTID",RIGHTID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create_ROLERIGHT, parms);
        }
        public IList<string[]> Read_ROLERIGHTByRIGHTID(int RIGHTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@RIGHTID",RIGHTID)
                                   };
            IList<string[]> nodes = new List<string[]>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Read_STAFFROLEbyROLEID, parms))
                {
                    while (sdr.Read())
                    {
                        string[] node = new string[2];
                        node[0] = Convert.ToString(sdr["STAFFID"]);
                        node[1] = Convert.ToString(sdr["ROLEID"]);
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
        public int Delete_ROLERIGHT(int ROLEID, int RIGHTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ROLEID",ROLEID),
                                       new SqlParameter("@RIGHTID",RIGHTID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete_ROLERIGHT, parms);
        }


        public IList<CRM_HG_STAFFROLEList> Read_STAFFROLEbySTAFFID(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_HG_STAFFROLEList> nodes = new List<CRM_HG_STAFFROLEList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_STAFFROLEbySTAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjectSTAFFROLELIST(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete_STAFFROLEByStaffid(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            //return Binning(CommandType.Text, SQL_Delete_STAFFROLEByStaffid, parms);
            return SQLServerHelper.ExecuteNonQuery(CommandType.Text, SQL_Delete_STAFFROLEByStaffid, parms);
        }





        private CRM_HG_STAFFROLEList ReadDataToObjectSTAFFROLELIST(SqlDataReader sdr)
        {
            CRM_HG_STAFFROLEList node = new CRM_HG_STAFFROLEList();
            node.ROLEID = Convert.ToInt32(sdr["ROLEID"]);
            node.ROLEIDDES = Convert.ToString(sdr["ROLEIDDES"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            return node;
        }



        private CRM_HG_ROLE ReadDataToObject(SqlDataReader sdr)
        {
            CRM_HG_ROLE node = new CRM_HG_ROLE();
            node.ROLEID = Convert.ToInt32(sdr["ROLEID"]);
            node.ROLENAME = Convert.ToString(sdr["ROLENAME"]);
            node.ROLEMEMO = Convert.ToString(sdr["ROLEMEMO"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);

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
