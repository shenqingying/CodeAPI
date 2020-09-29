using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Sonluk.IDataAccess.CRM;
using Sonluk.Entities.CRM;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class HG_KHLX : IHG_KHLX
    {
        private const string SQL_Create = "CRM_HG_KHLX_Create";
        //private const string SQL_Update = "CRM_HG_KHLX_Update";
        private const string SQL_Read = "CRM_HG_KHLX_Read";
        private const string SQL_Delete = "CRM_HG_KHLX_Delete";

        public int Create(int STAFFKHLXID, int DICID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFKHLXID",STAFFKHLXID),
                                       new SqlParameter("@DICID",DICID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public IList<CRM_HG_KHLXList> Read(int STAFFKHLXID, int DICID)
        {
            IList<CRM_HG_KHLXList> nodes = new List<CRM_HG_KHLXList>();

            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFKHLXID",STAFFKHLXID),
                                       new SqlParameter("@DICID",DICID)
                                      
                                   };

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
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

        public int Delete(int STAFFKHLXID, int DICID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFKHLXID",STAFFKHLXID),
                                       new SqlParameter("@DICID",DICID)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Delete, parms);

        }

        private CRM_HG_KHLXList ReadDataToStruct(SqlDataReader sdr)
        {
            CRM_HG_KHLXList node = new CRM_HG_KHLXList();
            node.DICID = Convert.ToInt32(sdr["DICID"]);
            node.STAFFKHLXID = Convert.ToInt32(sdr["STAFFKHLXID"]);
            node.DICNAME = Convert.ToString(sdr["DICNAME"]);
            node.STAFFKHLXMC = Convert.ToString(sdr["STAFFKHLXMC"]);

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
