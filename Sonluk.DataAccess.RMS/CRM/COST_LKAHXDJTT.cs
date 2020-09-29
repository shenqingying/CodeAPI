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
    public class COST_LKAHXDJTT : ICOST_LKAHXDJTT
    {
        private const string SQL_Create = "CRM_COST_LKAHXDJTT_Create";
        private const string SQL_Update = "CRM_COST_LKAHXDJTT_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAHXDJTT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAHXDJTT_Delete";

        public int Create(CRM_COST_LKAHXDJTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@JXSID", model.JXSID),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAHXDJTT model)
        {
            SqlParameter[] parms = {
                                         new SqlParameter("@HXDJTTID", model.HXDJTTID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_COST_LKAHXDJTT> ReadByParam(CRM_COST_LKAHXDJTT model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJTTID", model.HXDJTTID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@LKANAME", model.LKANAME),
                                        new SqlParameter("@LKACRMID", model.LKACRMID),
                                        new SqlParameter("@JXSNAME", model.JXSNAME),
                                        new SqlParameter("@JXSSAPSN", model.JXSSAPSN),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID", STAFFID)


                                   };
            IList<CRM_COST_LKAHXDJTT> nodes = new List<CRM_COST_LKAHXDJTT>();
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


        public int Delete(int HXDJTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJTTID", HXDJTTID)
                                       

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

        private CRM_COST_LKAHXDJTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAHXDJTT node = new CRM_COST_LKAHXDJTT();
            node.HXDJTTID = Convert.ToInt32(sdr["HXDJTTID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.LKAID = Convert.ToInt32(sdr["LKAID"]);
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToString(sdr["CJSJ"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.LKANAME = Convert.ToString(sdr["LKANAME"]);
            node.LKACRMID = Convert.ToString(sdr["LKACRMID"]);
            node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);


            return node;
        }









    }
}
