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
    public class HG_STAFFDICT : IHG_STAFFDICT
    {
        private const string SQL_Create = "CRM_HG_STAFFDICT_Create";
        private const string SQL_ReadByParam = "CRM_HG_STAFFDICT_ReadByParam";
        private const string SQL_Delete = "CRM_HG_STAFFDICT_Delete";

        public int Create(CRM_HG_STAFFDICT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@DICID", model.DICID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }


        public IList<CRM_HG_STAFFDICT> ReadByParam(CRM_HG_STAFFDICT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@DICID", model.DICID),
                                        new SqlParameter("@TYPEID", model.TYPEID),
                                        new SqlParameter("@FID", model.FID)

                                   };
            IList<CRM_HG_STAFFDICT> nodes = new List<CRM_HG_STAFFDICT>();
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

        public int Delete(int STAFFID, int DICID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID", STAFFID),
                                        new SqlParameter("@DICID", DICID)
                                       

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

        private CRM_HG_STAFFDICT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_HG_STAFFDICT node = new CRM_HG_STAFFDICT();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.DICID = Convert.ToInt32(sdr["DICID"]);
            node.TYPEID = Convert.ToInt32(sdr["TYPEID"]);
            node.FID = Convert.ToInt32(sdr["FID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.DICNAME = Convert.ToString(sdr["DICNAME"]);
            node.TYPENAME = Convert.ToString(sdr["TYPENAME"]);

            return node;
        }






    }
}
