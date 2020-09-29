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
    public class HG_STAFFKHLX : IHG_STAFFKHLX
    {
        private const string SQL_Create = "CRM_HG_STAFFKHLX_Create";
        private const string SQL_Update = "CRM_HG_STAFFKHLX_Update";
        private const string SQL_Read = "CRM_HG_STAFFKHLX_Read";
        private const string SQL_Delete = "CRM_HG_STAFFKHLX_Delete";
        private const string SQL_ReadBySTAFFKHLXID = "CRM_HG_STAFFKHLX_ReadBySTAFFKHLXID";

        public int Create(CRM_HG_STAFFKHLX model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@STAFFKHLXID", model.STAFFKHLXID),
                                        new SqlParameter("@STAFFKHLXMC", model.STAFFKHLXMC),
                                        new SqlParameter("@MCSXRIGHT", model.MCSXRIGHT),
                                        new SqlParameter("@BASE", model.BASE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HG_STAFFKHLX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFKHLXID", model.STAFFKHLXID),
                                        new SqlParameter("@STAFFKHLXMC", model.STAFFKHLXMC),
                                        new SqlParameter("@MCSXRIGHT", model.MCSXRIGHT),
                                        new SqlParameter("@BASE", model.BASE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int Delete(int STAFFKHLXID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFKHLXID",STAFFKHLXID)
                                       
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);

        }
        public IList<CRM_HG_STAFFKHLX> Read()
        {
            IList<CRM_HG_STAFFKHLX> nodes = new List<CRM_HG_STAFFKHLX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, null))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObeject(sdr));
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;

        }

        public CRM_HG_STAFFKHLX ReadBySTAFFKHLXID(int STAFFKHLXID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFKHLXID", STAFFKHLXID)
                                   };
            CRM_HG_STAFFKHLX node = new CRM_HG_STAFFKHLX();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFKHLXID, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObeject(sdr);
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;

        }



        private CRM_HG_STAFFKHLX ReadDataToObeject(SqlDataReader sdr)
        {
            CRM_HG_STAFFKHLX node = new CRM_HG_STAFFKHLX();
            node.STAFFKHLXID = Convert.ToInt32(sdr["STAFFKHLXID"]);
            node.STAFFKHLXMC = Convert.ToString(sdr["STAFFKHLXMC"]);
            node.MCSXRIGHT = Convert.ToInt32(sdr["MCSXRIGHT"]);
            node.BASE = Convert.ToString(sdr["BASE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
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


                        //if (sql == SQL_Delete)
                        //{
                        //    ID = Convert.ToInt32(sdr["Return Value"]);
                        //}
                        //else
                        //{
                        ID = Convert.ToInt32(sdr["ID"]);
                        //}


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
