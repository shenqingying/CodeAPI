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
    public class HG_RIGHTGROUP : IHG_RIGHTGROUP
    {
        private const string SQL_Create = "CRM_HG_RIGHTGROUP_Create";
        private const string SQL_Update = "CRM_HG_RIGHTGROUP_Update";
        private const string SQL_Read = "CRM_HG_RIGHTGROUP_Read";//"SELECT * FROM CRM_HG_RIGHTGROUP WHERE ISACTIVE = 1";
        private const string SQL_Delete = "CRM_HG_RIGHTGROUP_Delete";

        public int Create(CRM_HG_RIGHTGROUP model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@RGROUPID", model.RGROUPID),
                                        new SqlParameter("@RGROUPNAME", model.RGROUPNAME),
                                        new SqlParameter("@PRGROUPID", model.PRGROUPID),
                                        new SqlParameter("@PRIGHTNO", model.PRIGHTNO),
                                        new SqlParameter("@RGROUPMEMO", model.RGROUPMEMO),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@IMAGELJ",model.IMAGELJ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_HG_RIGHTGROUP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@RGROUPID", model.RGROUPID),
                                        new SqlParameter("@RGROUPNAME", model.RGROUPNAME),
                                        new SqlParameter("@PRGROUPID", model.PRGROUPID),
                                        new SqlParameter("@PRIGHTNO", model.PRIGHTNO),
                                        new SqlParameter("@RGROUPMEMO", model.RGROUPMEMO),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@IMAGELJ",model.IMAGELJ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

      

        public IList<CRM_HG_RIGHTGROUP> Read()
        {
            IList<CRM_HG_RIGHTGROUP> nodes = new List<CRM_HG_RIGHTGROUP>();
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

        public int Delete(int RGROUPID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@RGROUPID",RGROUPID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }







        private CRM_HG_RIGHTGROUP ReadDataToObject(SqlDataReader sdr)
        {
            CRM_HG_RIGHTGROUP node = new CRM_HG_RIGHTGROUP();
            node.RGROUPID = Convert.ToInt32(sdr["RGROUPID"]);
            node.RGROUPNAME = Convert.ToString(sdr["RGROUPNAME"]);
            node.PRGROUPID = Convert.ToInt32(sdr["PRGROUPID"]);
            node.PRIGHTNO = Convert.ToInt32(sdr["PRIGHTNO"]);
            node.RGROUPMEMO = Convert.ToString(sdr["RGROUPMEMO"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.IMAGELJ = Convert.ToString(sdr["IMAGELJ"]);
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
