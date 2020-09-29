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
    public class QYJS_MENU : IQYJS_MENU
    {
        private const string SQL_Create = "CRM_QYJS_MENU_Create";
        private const string SQL_Update = "CRM_QYJS_MENU_Update";
        private const string SQL_Delete = "CRM_QYJS_MENU_Delete";
        private const string SQL_ReadByID = "CRM_QYJS_MENU_ReadByID";
        private const string SQL_ReadByParam = "CRM_QYJS_MENU_ReadByParam";




        public int Create(CRM_QYJS_MENU model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PLOGID", model.PLOGID),
                                        new SqlParameter("@NAME", model.NAME),
                                        new SqlParameter("@NOTICE", model.NOTICE),
                                        new SqlParameter("@ML", model.ML),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@SORT", model.SORT),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_QYJS_MENU model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CATALOGID", model.CATALOGID),
                                        new SqlParameter("@PLOGID", model.PLOGID),
                                        new SqlParameter("@NAME", model.NAME),
                                        new SqlParameter("@NOTICE", model.NOTICE),
                                        new SqlParameter("@ML", model.ML),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@SORT", model.SORT),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int Delete(int CATALOGID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CATALOGID", CATALOGID)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public CRM_QYJS_MENU ReadbyID(int CATALOGID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CATALOGID",CATALOGID)
                                   };
            CRM_QYJS_MENU nodes = new CRM_QYJS_MENU();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByID, parms))
                {
                    if (sdr.Read())
                    {
                        nodes = ReadDataListToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_QYJS_MENU> ReadTTbyParam(CRM_QYJS_MENU model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@PLOGID",model.PLOGID),
                                       new SqlParameter("@NAME",model.NAME)
                                   };
            IList<CRM_QYJS_MENU> nodes = new List<CRM_QYJS_MENU>();
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


        private CRM_QYJS_MENU ReadDataToObj(SqlDataReader sdr)
        {
            CRM_QYJS_MENU node = new CRM_QYJS_MENU();
            node.CATALOGID = Convert.ToInt32(sdr["CATALOGID"]);
            node.PLOGID = Convert.ToInt32(sdr["PLOGID"]);
            node.NAME = Convert.ToString(sdr["NAME"]);
            node.NOTICE = Convert.ToString(sdr["NOTICE"]);
            node.ML = Convert.ToString(sdr["ML"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.SORT = Convert.ToInt32(sdr["SORT"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToString(sdr["CJSJ"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToString(sdr["XGSJ"]);
            return node;
        }

        private CRM_QYJS_MENU ReadDataListToObj(SqlDataReader sdr)
        {
            CRM_QYJS_MENU node = new CRM_QYJS_MENU();
            node.CATALOGID = Convert.ToInt32(sdr["CATALOGID"]);
            node.PLOGID = Convert.ToInt32(sdr["PLOGID"]);
            node.NAME = Convert.ToString(sdr["NAME"]);
            node.NOTICE = Convert.ToString(sdr["NOTICE"]);
            node.ML = Convert.ToString(sdr["ML"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.SORT = Convert.ToInt32(sdr["SORT"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToString(sdr["CJSJ"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToString(sdr["XGSJ"]);
            node.PLOGIDDES = Convert.ToString(sdr["PLOGIDDES"]);
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
