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
    public class KH_GROUP : IKH_GROUP
    {
        private const string SQL_Create = "CRM_KH_GROUP_Create";
        private const string SQL_Update = "CRM_KH_GROUP_Update";
        private const string SQL_Read = "CRM_KH_GROUP_Read";//"SELECT * FROM CRM_KH_GROUP";
        private const string SQL_ReadByParam = "CRM_KH_GROUP_ReadByParam";

        private const string SQL_ReadbyGid = "CRM_KH_GROUP_ReadbyGid";//"SELECT A.*,ISNULL((SELECT GNAME FROM CRM_KH_GROUP WHERE GID = A.PGID),' ') AS PGNAME  FROM CRM_KH_GROUP AS A WHERE GID = @GID";
        private const string SQL_Delete = "CRM_KH_GROUP_Delete";
        private const string SQL_ReadByStaffid = "CRM_KH_GROUP_ReadBySTaffid";
//@"WITH RES AS 
//(
//	SELECT distinct CRM_KH_GROUP.GID FROM CRM_KH_GROUP INNER JOIN CRM_KH_GROUP_STAFF ON CRM_KH_GROUP.GID = CRM_KH_GROUP_STAFF.GID where CRM_KH_GROUP_STAFF.staffid = @STAFFID
//	union all select A.GID FROM CRM_KH_GROUP AS A JOIN RES AS B ON A.PGID = B.GID
//)
//--SELECT DISTINCT * FROM RES
//SELECT a.GID,a.XSQYID,a.PGID,a.GNAME,a.KHJLID,a.GMEMO,a.FGLDID FROM CRM_KH_GROUP as a where  A.GID IN (select distinct RES.GID  from RES);";//"CRM_KH_GROUP_KH_ReadBySTAFFID";
        private const string SQL_ReadGidByGNAME = "CRM_KH_GROUP_ReadGidByGNAME";



        public int Create(CRM_KH_GROUP model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@GID", model.GID),
                                        new SqlParameter("@XSQYID", model.XSQYID),
                                        new SqlParameter("@PGID", model.PGID),
                                        new SqlParameter("@GNAME", model.GNAME),
                                        new SqlParameter("@KHJLID", model.KHJLID),
                                        new SqlParameter("@GMEMO", model.GMEMO),
                                        new SqlParameter("@FGLDID",model.FGLDID),
                                        new SqlParameter("@CPLX",model.CPLX),
                                        new SqlParameter("@SORT",model.SORT)
                                    };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_KH_GROUP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@GID", model.GID),
                                        new SqlParameter("@XSQYID", model.XSQYID),
                                        new SqlParameter("@PGID", model.PGID),
                                        new SqlParameter("@GNAME", model.GNAME),
                                        new SqlParameter("@KHJLID", model.KHJLID),
                                        new SqlParameter("@GMEMO", model.GMEMO),
                                        new SqlParameter("@FGLDID",model.FGLDID),
                                        new SqlParameter("@CPLX",model.CPLX),
                                        new SqlParameter("@SORT",model.SORT)
                                    };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_KH_GROUPList> Read()
        {
            IList<CRM_KH_GROUPList> nodes = new List<CRM_KH_GROUPList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, null))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjectList(sdr,2));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_KH_GROUPList> ReadByParam(CRM_KH_GROUPList model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@GNAME", model.GNAME),
                                        new SqlParameter("@GMEMO", model.GMEMO)

                                   };
            IList<CRM_KH_GROUPList> nodes = new List<CRM_KH_GROUPList>();
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
        
         public IList<CRM_KH_GROUPList> ReadBySTAFFID(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_KH_GROUPList> nodes = new List<CRM_KH_GROUPList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByStaffid, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjectList(sdr,2));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


         public int ReadGidByGNAME(string gname)
         {
             SqlParameter[] parms = {
                                        new SqlParameter("@GNAME",gname)
                                    };
             int GID = 0;
             try
             {
                 using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadGidByGNAME,parms))
                 {
                     if (sdr.Read())
                     {
                         GID = Convert.ToInt32(sdr["GID"]);
                     }
                 }
             }
             catch (Exception E)
             {
                 
                 throw new ApplicationException(E.Message);
             }
             return GID;

         }








        public CRM_KH_GROUPList ReadbyGId(int GID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@GID",GID)
                                   };
            CRM_KH_GROUPList node = new CRM_KH_GROUPList();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadbyGid,parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObjectList(sdr,1);
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public int Delect(int GID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@GID",SqlDbType.Int),
                                       new SqlParameter("@res",SqlDbType.Int)
                                   };
            parms[0].Value = GID;
            parms[1].Direction = ParameterDirection.Output;
            int res = 0;
            try
            {
                SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Delete, parms);
                res = Convert.ToInt32(parms[1].Value.ToString());
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return res;
        }





        private CRM_KH_GROUPList ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_GROUPList node = new CRM_KH_GROUPList();
           
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.XSQYID = Convert.ToInt32(sdr["XSQYID"]);
            node.PGID = Convert.ToInt32(sdr["PGID"]);
            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.KHJLID = Convert.ToInt32(sdr["KHJLID"]);
            node.GMEMO = Convert.ToString(sdr["GMEMO"]);
            node.FGLDID = Convert.ToInt32(sdr["FGLDID"]);
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.SORT = Convert.ToInt32(sdr["SORT"]);
          
           

            //node.ISACTIVE = Convert.ToBoolean(sdr["ISACTIVE"]);
            return node;
        }
        private CRM_KH_GROUPList ReadDataToObjectList(SqlDataReader sdr,int level)
        {
            CRM_KH_GROUPList node = new CRM_KH_GROUPList();

            node.GID = Convert.ToInt32(sdr["GID"]);
            node.XSQYID = Convert.ToInt32(sdr["XSQYID"]);
            node.PGID = Convert.ToInt32(sdr["PGID"]);
            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.KHJLID = Convert.ToInt32(sdr["KHJLID"]);
            node.GMEMO = Convert.ToString(sdr["GMEMO"]);
            node.FGLDID = Convert.ToInt32(sdr["FGLDID"]);
            node.PGNAME = "";
            node.NAME1 = "";
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.SORT = Convert.ToInt32(sdr["SORT"]);
            if (level == 1)
            {
                node.PGNAME = Convert.ToString(sdr["PGNAME"]);
            }
            else if (level == 2)
            {
                node.NAME1 = Convert.ToString(sdr["GNAME1"]);
            }
        
          
              
            
            


            //node.ISACTIVE = Convert.ToBoolean(sdr["ISACTIVE"]);
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


        private CRM_KH_GROUPList ReadDataToObj(SqlDataReader sdr)
        {
            CRM_KH_GROUPList node = new CRM_KH_GROUPList();
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.XSQYID = Convert.ToInt32(sdr["XSQYID"]);
            node.PGID = Convert.ToInt32(sdr["PGID"]);
            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.KHJLID = Convert.ToInt32(sdr["KHJLID"]);
            node.FGLDID = Convert.ToInt32(sdr["FGLDID"]);
            node.GMEMO = Convert.ToString(sdr["GMEMO"]);
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.SORT = Convert.ToInt32(sdr["SORT"]);
            node.CPLXDES = Convert.ToString(sdr["CPLXDES"]);
            return node;
        }



    }
}
