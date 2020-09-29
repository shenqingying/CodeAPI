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
    public class COST_CBZX : ICOST_CBZX
    {
        private const string SQL_Create = "CRM_COST_CBZX_Create";
        private const string SQL_Update = "CRM_COST_CBZX_Update";
        private const string SQL_ReadByParam = "CRM_COST_CBZX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CBZX_Delete";

        public int Create(CRM_COST_CBZX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CBZXBH", model.CBZXBH),
                                        new SqlParameter("@CBZXMC", model.CBZXMC),
                                        new SqlParameter("@CLASS1", model.CLASS1),
                                        new SqlParameter("@CLASS2", model.CLASS2),
                                        new SqlParameter("@CLASS3", model.CLASS3),
                                        new SqlParameter("@CLASS4", model.CLASS4),
                                        new SqlParameter("@SORT", model.SORT),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CBZX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CBZXBH", model.CBZXBH),
                                        new SqlParameter("@CBZXMC", model.CBZXMC),
                                        new SqlParameter("@CLASS1", model.CLASS1),
                                        new SqlParameter("@CLASS2", model.CLASS2),
                                        new SqlParameter("@CLASS3", model.CLASS3),
                                        new SqlParameter("@CLASS4", model.CLASS4),
                                        new SqlParameter("@SORT", model.SORT),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CBZX> ReadByParam(CRM_COST_CBZX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CBZXBH", model.CBZXBH),
                                        new SqlParameter("@CBZXMC", model.CBZXMC),
                                        new SqlParameter("@CLASS1", model.CLASS1),
                                        new SqlParameter("@CLASS2", model.CLASS2),
                                        new SqlParameter("@CLASS3", model.CLASS3),
                                        new SqlParameter("@CLASS4", model.CLASS4)

                                   };
            IList<CRM_COST_CBZX> nodes = new List<CRM_COST_CBZX>();
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
        public int Delete(string CBZXBH)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CBZXBH", CBZXBH)
                                       

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

        private CRM_COST_CBZX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CBZX node = new CRM_COST_CBZX();
            node.CBZXBH = Convert.ToString(sdr["CBZXBH"]);
            node.CBZXMC = Convert.ToString(sdr["CBZXMC"]);
            node.CLASS1 = Convert.ToInt32(sdr["CLASS1"]);
            node.CLASS2 = Convert.ToInt32(sdr["CLASS2"]);
            node.CLASS3 = Convert.ToInt32(sdr["CLASS3"]);
            node.CLASS4 = Convert.ToInt32(sdr["CLASS4"]);
            node.SORT = Convert.ToInt32(sdr["SORT"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CLASS1DES = Convert.ToString(sdr["CLASS1DES"]);
            node.CLASS2DES = Convert.ToString(sdr["CLASS2DES"]);
            node.CLASS3DES = Convert.ToString(sdr["CLASS3DES"]);
            node.CLASS4DES = Convert.ToString(sdr["CLASS4DES"]);
            return node;
        }





    }
}
