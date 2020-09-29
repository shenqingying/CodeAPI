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
    public class COST_LKAYEARMD : ICOST_LKAYEARMD
    {
        private const string SQL_Create = "CRM_COST_LKAYEARMD_Create";
        private const string SQL_Update = "CRM_COST_LKAYEARMD_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAYEARMD_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAYEARMD_Delete";
        private const string SQL_ReadMDQKbyKHID = "CRM_COST_LKAYEARMD_ReadMDQKbyKHID";
        private const string SQL_UpdateMDSL = "CRM_COST_LKAYEARMD_UpdateMDSL";

        public int Create(CRM_COST_LKAYEARMD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@MDLX", model.MDLX),
                                        new SqlParameter("@XYMDSL", model.XYMDSL),
                                        new SqlParameter("@YJCMDSL", model.YJCMDSL),
                                        new SqlParameter("@BNYJXZMDSL", model.BNYJXZMDSL),
                                        new SqlParameter("@DPJCSL", model.DPJCSL),
                                        new SqlParameter("@BAMDSL", model.BAMDSL),
                                        new SqlParameter("@ZYCLFS", model.ZYCLFS),
                                        new SqlParameter("@SLCLMJZB", model.SLCLMJZB),
                                        new SqlParameter("@BEIZ", model.BEIZ)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAYEARMD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MDID", model.MDID),
                                        new SqlParameter("@XYMDSL", model.XYMDSL),
                                        new SqlParameter("@YJCMDSL", model.YJCMDSL),
                                        new SqlParameter("@BNYJXZMDSL", model.BNYJXZMDSL),
                                        new SqlParameter("@DPJCSL", model.DPJCSL),
                                        new SqlParameter("@ZYCLFS", model.ZYCLFS),
                                        new SqlParameter("@SLCLMJZB", model.SLCLMJZB),
                                        new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int UpdateMDSL(int LKAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", LKAYEARTTID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateMDSL, parms);
        }

        public IList<CRM_COST_LKAYEARMD> ReadByParam(CRM_COST_LKAYEARMD model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@MDID", model.MDID)
                                   };
            IList<CRM_COST_LKAYEARMD> nodes = new List<CRM_COST_LKAYEARMD>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataListToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_LKAYEARMD> ReadMDQKbyKHID(int KHID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID", KHID)
                                   };
            IList<CRM_COST_LKAYEARMD> nodes = new List<CRM_COST_LKAYEARMD>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMDQKbyKHID, parms))
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

        public int Delete(int MDID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MDID", MDID)
                                       

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

        private CRM_COST_LKAYEARMD ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARMD node = new CRM_COST_LKAYEARMD();
            node.MDLX = Convert.ToInt32(sdr["MDLX"]);
            node.BAMDSL = Convert.ToInt32(sdr["BAMDSL"]);
            node.MDLXDES = Convert.ToString(sdr["MDLXDES"]);

            return node;
        }

        private CRM_COST_LKAYEARMD ReadDataListToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARMD node = new CRM_COST_LKAYEARMD();
            node.MDID = Convert.ToInt32(sdr["MDID"]);
            node.LKAYEARTTID = Convert.ToInt32(sdr["LKAYEARTTID"]);
            node.MDLX = Convert.ToInt32(sdr["MDLX"]);
            node.XYMDSL = Convert.ToInt32(sdr["XYMDSL"]);
            node.YJCMDSL = Convert.ToInt32(sdr["YJCMDSL"]);
            node.BNYJXZMDSL = Convert.ToInt32(sdr["BNYJXZMDSL"]);
            node.DPJCSL = Convert.ToInt32(sdr["DPJCSL"]);
            node.BAMDSL = Convert.ToInt32(sdr["BAMDSL"]);
            node.ZYCLFS = Convert.ToString(sdr["ZYCLFS"]);
            node.SLCLMJZB = Convert.ToDouble(sdr["SLCLMJZB"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.MDLXDES = Convert.ToString(sdr["MDLXDES"]);

            return node;
        }





    }
}
