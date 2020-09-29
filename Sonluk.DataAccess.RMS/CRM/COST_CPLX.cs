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
    public class COST_CPLX : ICOST_CPLX
    {

        private const string SQL_Create = "CRM_COST_CPLX_Create";
        private const string SQL_Update = "CRM_COST_CPLX_Update";
        private const string SQL_ReadByParam = "CRM_COST_CPLX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CPLX_Delete";

        public int Create(CRM_COST_CPLX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CPLX", model.CPLX),
                                        new SqlParameter("@CPFL", model.CPFL),
                                        new SqlParameter("@FYZCFS", model.FYZCFS),
                                        new SqlParameter("@FYZC", model.FYZC),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CZR", model.CZR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CPLX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@CPLX", model.CPLX),
                                        new SqlParameter("@CPFL", model.CPFL),
                                        new SqlParameter("@FYZCFS", model.FYZCFS),
                                        new SqlParameter("@FYZC", model.FYZC),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CZR", model.CZR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CPLX> ReadByParam(CRM_COST_CPLX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@CPLX", model.CPLX),
                                        new SqlParameter("@CPFL", model.CPFL)

                                   };
            IList<CRM_COST_CPLX> nodes = new List<CRM_COST_CPLX>();
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
        public int Delete(int CPLXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CPLXID", CPLXID)
                                       

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

        private CRM_COST_CPLX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CPLX node = new CRM_COST_CPLX();
            node.CPLXID = Convert.ToInt32(sdr["CPLXID"]);
            node.CPLX = Convert.ToString(sdr["CPLX"]);
            node.CPFL = Convert.ToString(sdr["CPFL"]);
            node.FYZCFS = Convert.ToInt32(sdr["FYZCFS"]);
            node.FYZC = Convert.ToDecimal(sdr["FYZC"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZSJ = Convert.ToDateTime(sdr["CZSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.FYZCFSDES = Convert.ToString(sdr["FYZCFSDES"]);
            node.CZRNAME = Convert.ToString(sdr["CZRNAME"]);

            return node;
        }



    }
}
