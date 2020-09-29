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
    public class COST_GSZCFS : ICOST_GSZCFS
    {

        private const string SQL_Create = "CRM_COST_GSZCFS_Create";
        private const string SQL_Update = "CRM_COST_GSZCFS_Update";
        private const string SQL_ReadByParam = "CRM_COST_GSZCFS_ReadByParam";
        private const string SQL_Delete = "CRM_COST_GSZCFS_Delete";

        public int Create(CRM_COST_GSZCFS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@YJHDSL", model.YJHDSL),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@FYZCJE", model.FYZCJE),
                                        new SqlParameter("@SNYJXS", model.SNYJXS),
                                        new SqlParameter("@SNYJSL", model.SNYJSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_GSZCFS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ZCFSID", model.ZCFSID),
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@YJHDSL", model.YJHDSL),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@FYZCJE", model.FYZCJE),
                                        new SqlParameter("@SNYJXS", model.SNYJXS),
                                        new SqlParameter("@SNYJSL", model.SNYJSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_GSZCFS> ReadByParam(CRM_COST_GSZCFS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ZCFSID", model.ZCFSID),
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@CPLXID", model.CPLXID)

                                   };
            IList<CRM_COST_GSZCFS> nodes = new List<CRM_COST_GSZCFS>();
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
        public int Delete(int ZCFSID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ZCFSID", ZCFSID)
                                       

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

        private CRM_COST_GSZCFS ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_GSZCFS node = new CRM_COST_GSZCFS();
            node.ZCFSID = Convert.ToInt32(sdr["ZCFSID"]);
            node.CXHDID = Convert.ToInt32(sdr["CXHDID"]);
            node.CPLXID = Convert.ToInt32(sdr["CPLXID"]);
            node.YJHDSL = Convert.ToInt32(sdr["YJHDSL"]);
            node.YJXS = Convert.ToDecimal(sdr["YJXS"]);
            node.FYZCJE = Convert.ToDecimal(sdr["FYZCJE"]);
            node.SNYJXS = Convert.ToDecimal(sdr["SNYJXS"]);
            node.SNYJSL = Convert.ToInt32(sdr["SNYJSL"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.FYZCFS = Convert.ToInt32(sdr["FYZCFS"]);
            node.FYZCFSDES = Convert.ToString(sdr["FYZCFSDES"]);
            node.FYZC = Convert.ToDecimal(sdr["FYZC"]);
            node.CPFL = Convert.ToString(sdr["CPFL"]);
            node.CPLX = Convert.ToString(sdr["CPLX"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            return node;
        }





    }
}
