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
    public class OA_OPINION : IOA_OPINION
    {
        private const string SQL_Create = "CRM_OA_OPINION_Create";
        private const string SQL_Update = "CRM_OA_OPINION_Update";
        private const string SQL_ReadByParam = "CRM_OA_OPINION_ReadByParam";


        public int Create(CRM_OA_OPINION model)
        {
            SqlParameter[] parms = {
                                        
                                        new SqlParameter("@OAID", model.OAID),
                                        new SqlParameter("@OACSBH", model.OACSBH),
                                        new SqlParameter("@OACSLB", model.OACSLB),
                                        new SqlParameter("@SPRNAME", model.SPRNAME),
                                        new SqlParameter("@SPRNO", model.SPRNO),
                                        new SqlParameter("@ATTITUDE", model.ATTITUDE),
                                        new SqlParameter("@OPINION", model.OPINION),
                                        new SqlParameter("@SPSJ", model.SPSJ),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@HFNR", model.HFNR),
                                        new SqlParameter("@HFSJ", model.HFSJ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_OA_OPINION model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@OAID", model.OAID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@HFNR", model.HFNR),
                                        new SqlParameter("@HFSJ", model.HFSJ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }


        public IList<CRM_OA_OPINION> ReadByParam(CRM_OA_OPINION model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@OAID", model.OAID),
                                        new SqlParameter("@OACSBH", model.OACSBH),
                                        new SqlParameter("@OACSLB", model.OACSLB),
                                        new SqlParameter("@SPRNAME", model.SPRNAME),
                                        new SqlParameter("@SPRNO", model.SPRNO),
                                        new SqlParameter("@ATTITUDE", model.ATTITUDE),
                                        new SqlParameter("@OPINION", model.OPINION),
                                        new SqlParameter("@SPSJSTART", model.SPSJSTART),
                                        new SqlParameter("@SPSJEND", model.SPSJEND),
                                        new SqlParameter("@CJSJSTART", model.CJSJSTART),
                                        new SqlParameter("@CJSJEND", model.CJSJEND)
                                   };
            IList<CRM_OA_OPINION> nodes = new List<CRM_OA_OPINION>();
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
        //public CRM_HD_ZDF ReadByZDFID(int ZDFID)
        //{
        //    SqlParameter[] pamrs = {
        //                               new SqlParameter("@ZDFID",ZDFID)
        //                           };
        //    CRM_HD_ZDF node = new CRM_HD_ZDF();
        //    try
        //    {
        //        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByZDFID, pamrs))
        //        {
        //            if (sdr.Read())
        //            {
        //                node = ReadDataToObj(sdr);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw new ApplicationException(e.Message);
        //    }
        //    return node;

        //}


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

        private CRM_OA_OPINION ReadDataToObj(SqlDataReader sdr)
        {
            CRM_OA_OPINION node = new CRM_OA_OPINION();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.OAID = Convert.ToString(sdr["OAID"]);
            node.OACSBH = Convert.ToInt32(sdr["OACSBH"]);
            node.OACSLB = Convert.ToInt32(sdr["OACSLB"]);
            node.SPRNAME = Convert.ToString(sdr["SPRNAME"]);
            node.SPRNO = Convert.ToString(sdr["SPRNO"]);
            node.ATTITUDE = Convert.ToString(sdr["ATTITUDE"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.SPSJ = Convert.ToDateTime(sdr["SPSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.HFNR = Convert.ToString(sdr["HFNR"]);
            node.HFSJ = Convert.ToString(sdr["HFSJ"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            return node;
        }










    }
}
