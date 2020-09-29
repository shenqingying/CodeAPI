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
    public class HG_DEPT : IHG_DEPT
    {
        private const string SQL_Create = "CRM_HG_DEPT_Create";
        private const string SQL_Update = "CRM_HG_DEPT_Update";
        private const string SQL_Read = "CRM_HG_DEPT_Read";//"SELECT * FROM CRM_HG_DEPT WHERE ISACTIVE = 1";
        private const string SQL_Delete = "CRM_HG_DEPT_Delete";
        private const string SQL_ReadByDEPID = "CRM_HG_DEPT_ReadByDEPID";//"SELECT A.*,ISNULL((SELECT DEPNAME FROM  CRM_HG_DEPT WHERE DEPID = A.PDEPID),' ') AS PDEPIDNAME FROM CRM_HG_DEPT AS A WHERE A.ISACTIVE = 1 AND A.DEPID = @DEPID";
        private const string SQL_ReadByName = "CRM_HG_DEPT_ReadByName";//"SELECT * FROM CRM_HG_DEPT WHERE ISACTIVE = 1 AND DEPNAME = @DEPNAME";
        private const string SQL_ReadByStaffid = "CRM_HG_DEPT_ReadByStaffid";

        public int Create(CRM_HG_DEPT model)
        {
            SqlParameter[] parms = {
                                      //new SqlParameter("@DEPID", model.DEPID),
                                      new SqlParameter("@DEPNAME", model.DEPNAME),
                                      new SqlParameter("@PDEPID", model.PDEPID),
                                      new SqlParameter("@DLEVEL", model.DLEVEL),
                                      new SqlParameter("@DEPADDRESS", model.DEPADDRESS),
                                      new SqlParameter("@DEPMEMO", model.DEPMEMO),
                                      new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                      new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HG_DEPT model)
        {
            SqlParameter[] parms = {
                                      new SqlParameter("@DEPID", model.DEPID),
                                      new SqlParameter("@DEPNAME", model.DEPNAME),
                                      new SqlParameter("@PDEPID", model.PDEPID),
                                      new SqlParameter("@DLEVEL", model.DLEVEL),
                                      new SqlParameter("@DEPADDRESS", model.DEPADDRESS),
                                      new SqlParameter("@DEPMEMO", model.DEPMEMO),
                                      new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                      new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }



        public IList<CRM_HG_DEPT> Read()
        {
            IList<CRM_HG_DEPT> nodes = new List<CRM_HG_DEPT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Read, null))
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
        public CRM_HG_DEPTList ReadByDEPID(int DEPID)
        {
            SqlParameter[] pamrs = {
                                       new SqlParameter("@DEPID",DEPID)
                                   };
            CRM_HG_DEPTList node = new CRM_HG_DEPTList();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByDEPID, pamrs))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToList(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;

        }

        public CRM_HG_DEPT ReadByName(string DEPNAME)
        {
            SqlParameter[] pamrs = {
                                       new SqlParameter("@DEPNAME",DEPNAME)
                                   };
            CRM_HG_DEPT node = new CRM_HG_DEPT();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByName, pamrs))
                {
                    if (sdr.Read())
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

        public IList<CRM_HG_DEPT> ReadByStaffid(int STAFFID)
        {
            SqlParameter[] pamrs = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_HG_DEPT> nodes = new List<CRM_HG_DEPT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByStaffid, pamrs))
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

        public int Delete(int DEPID)
        {
            SqlParameter[] parms = {
                                      new SqlParameter("@DEPID",DEPID)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Delete, parms);
        }




        private CRM_HG_DEPT ReadDataToObject(SqlDataReader sdr)
        {
            CRM_HG_DEPT node = new CRM_HG_DEPT();
            node.DEPID = Convert.ToInt32(sdr["DEPID"]);
            node.DEPNAME = Convert.ToString(sdr["DEPNAME"]);
            node.PDEPID = Convert.ToInt32(sdr["PDEPID"]);
            node.DLEVEL = Convert.ToString(sdr["DLEVEL"]);
            node.DEPADDRESS = Convert.ToString(sdr["DEPADDRESS"]);
            node.DEPMEMO = Convert.ToString(sdr["DEPMEMO"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);

            return node;
        }

        private CRM_HG_DEPTList ReadDataToList(SqlDataReader sdr)
        {
            CRM_HG_DEPTList node = new CRM_HG_DEPTList();
            node.DEPID = Convert.ToInt32(sdr["DEPID"]);
            node.DEPNAME = Convert.ToString(sdr["DEPNAME"]);
            node.PDEPID = Convert.ToInt32(sdr["PDEPID"]);
            node.DLEVEL = Convert.ToString(sdr["DLEVEL"]);
            node.DEPADDRESS = Convert.ToString(sdr["DEPADDRESS"]);
            node.DEPMEMO = Convert.ToString(sdr["DEPMEMO"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.PDEPIDNAME = Convert.ToString(sdr["PDEPIDNAME"]);
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
