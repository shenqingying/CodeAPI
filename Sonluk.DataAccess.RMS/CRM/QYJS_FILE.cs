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
    public class QYJS_FILE : IQYJS_FILE
    {
        private const string SQL_Create = "CRM_QYJS_FILE_Create";
        private const string SQL_Update = "CRM_QYJS_FILE_Update";
        private const string SQL_ReadByParam = "CRM_QYJS_FILE_ReadByParam";
        private const string SQL_Delete = "CRM_QYJS_FILE_Delete";
        private const string SQL_ReadByID = "CRM_QYJS_FILE_ReadByID";    //暂时没用

        public int Create(CRM_QYJS_FILE model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CATALOGID", model.CATALOGID),
                                        new SqlParameter("@WJM", model.WJM),
                                        new SqlParameter("@COVER", model.COVER),
                                        new SqlParameter("@ML", model.ML),
                                        new SqlParameter("@TITLE", model.TITLE),
                                        new SqlParameter("@WJMS", model.WJMS),
                                        new SqlParameter("@DOWNLOAD", model.DOWNLOAD),
                                        new SqlParameter("@PC", model.PC),
                                        new SqlParameter("@MOBILE", model.MOBILE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@SORT", model.SORT),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_QYJS_FILE model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@CATALOGID", model.CATALOGID),
                                        new SqlParameter("@WJM", model.WJM),
                                        new SqlParameter("@COVER", model.COVER),
                                        new SqlParameter("@ML", model.ML),
                                        new SqlParameter("@TITLE", model.TITLE),
                                        new SqlParameter("@WJMS", model.WJMS),
                                        new SqlParameter("@DOWNLOAD", model.DOWNLOAD),
                                        new SqlParameter("@PC", model.PC),
                                        new SqlParameter("@MOBILE", model.MOBILE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@SORT", model.SORT),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_QYJS_FILE> ReadByParam(CRM_QYJS_FILE model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@CATALOGID",model.CATALOGID),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@MOBILE",model.MOBILE)
                                   };
            IList<CRM_QYJS_FILE> nodes = new List<CRM_QYJS_FILE>();
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
        public CRM_QYJS_FILE ReadByID(int ID)
        {
            SqlParameter[] pamrs = {
                                       new SqlParameter("@ID",ID)
                                   };
            CRM_QYJS_FILE node = new CRM_QYJS_FILE();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByID, pamrs))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;

        }

        public int Delete(int ID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", ID)
                                       

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

        private CRM_QYJS_FILE ReadDataToObj(SqlDataReader sdr)
        {
            CRM_QYJS_FILE node = new CRM_QYJS_FILE();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.CATALOGID = Convert.ToInt32(sdr["CATALOGID"]);
            node.WJM = Convert.ToString(sdr["WJM"]);
            node.COVER = Convert.ToString(sdr["COVER"]);
            node.ML = Convert.ToString(sdr["ML"]);
            node.TITLE = Convert.ToString(sdr["TITLE"]);
            node.WJMS = Convert.ToString(sdr["WJMS"]);
            node.DOWNLOAD = Convert.ToInt32(sdr["DOWNLOAD"]);
            node.PC = Convert.ToInt32(sdr["PC"]);
            node.MOBILE = Convert.ToInt32(sdr["MOBILE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.SORT = Convert.ToInt32(sdr["SORT"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            return node;
        }



    }
}
