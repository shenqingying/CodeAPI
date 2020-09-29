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
    public class HG_BZGZSJ : IHG_BZGZSJ
    {
        private const string SQL_Create = "CRM_HG_BZGZSJ_Create";
        private const string SQL_Update = "CRM_HG_BZGZSJ_Update";
        private const string SQL_Read = "CRM_HG_BZGZSJ_Read";//"SELECT * FROM CRM_HG_BZGZSJ WHERE BZID IN (SELECT BZID  FROM CRM_HG_STAFF WHERE STAFFID = @STAFFID AND SCANCEL = 0 AND ISACTIVE = 1) AND ISACTIVE = 1";
        //private const string SQL_Read1 = "CRM_HG_BZGZSJ_Read1"//"SELECT * FROM CRM_HG_BZGZSJ WHERE ISACTIVE = 1";
        private const string SQL_Delete = "CRM_HG_BZGZSJ_Delete";
        private const string SQL_ReadByBZNAME = "CRM_HG_BZGZSJ_ReadByBZNAME";//"SELECT * FROM CRM_HG_BZGZSJ WHERE BZNAME = @BZNAME AND ISACTIVE = 1";
        private const string SQL_ReadByBZID = "CRM_HG_BZGZSJ_ReadByBZID";//"SELECT * FROM CRM_HG_BZGZSJ WHERE BZID = @BZID AND ISACTIVE = 1";


        public int Create(CRM_HG_BZGZSJ model)
        {
            SqlParameter[] parms = {
                                       //new SqlParameter("@BZID", model.BZID),
                                       new SqlParameter("@BZNAME", model.BZNAME),
                                       new SqlParameter("@KSSJ", model.KSSJ),
                                       new SqlParameter("@JSSJ", model.JSSJ),
                                       new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                       new SqlParameter("@BEIZ", model.BEIZ),

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HG_BZGZSJ model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BZID", model.BZID),
                                       new SqlParameter("@BZNAME", model.BZNAME),
                                       new SqlParameter("@KSSJ", model.KSSJ),
                                       new SqlParameter("@JSSJ", model.JSSJ),
                                       new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                       new SqlParameter("@BEIZ", model.BEIZ),

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_HG_BZGZSJ> Read(int STAFFID)
        {
            //string sql;
            //if (STAFFID > 0)
            //{
            //    sql = SQL_Read;
            //}
            //else
            //{
            //    sql = SQL_Read1;
            //}

            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_HG_BZGZSJ> nodes = new List<CRM_HG_BZGZSJ>();
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
        public CRM_HG_BZGZSJ ReadByBZNAME(string BZNAME)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BZNAME",BZNAME)
                                   };
            CRM_HG_BZGZSJ node = new CRM_HG_BZGZSJ();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByBZNAME, parms))
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
        public CRM_HG_BZGZSJ ReadByBZID(int BZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BZID",BZID)
                                   };
            CRM_HG_BZGZSJ node = new CRM_HG_BZGZSJ();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByBZID, parms))
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

        public int Delete(int BZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BZID",BZID)
                                   };
            return Binning(CommandType.StoredProcedure,SQL_Delete,parms);
        }

      





        private CRM_HG_BZGZSJ ReadDataToObject(SqlDataReader sdr)
        {
            CRM_HG_BZGZSJ node = new CRM_HG_BZGZSJ();
            node.BZID = Convert.ToInt32(sdr["BZID"]);
            node.BZNAME = Convert.ToString(sdr["BZNAME"]);
            node.KSSJ = Convert.ToString(sdr["KSSJ"]);
            node.JSSJ = Convert.ToString(sdr["JSSJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
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
