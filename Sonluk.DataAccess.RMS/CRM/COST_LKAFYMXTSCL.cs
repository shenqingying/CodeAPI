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
    public class COST_LKAFYMXTSCL : ICOST_LKAFYMXTSCL
    {
        private const string SQL_Create = "CRM_COST_LKAFYMXTSCL_Create";
        private const string SQL_Update = "CRM_COST_LKAFYMXTSCL_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAFYMXTSCL_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAFYMXTSCL_Delete";
        private const string SQL_Read_Unconnected = "CRM_COST_LKAFYMXTSCL_Read_Unconnected";

        public int Create(CRM_COST_LKAFYMXTSCL model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@CLFS", model.CLFS),
                                        new SqlParameter("@SQFYJE", model.SQFYJE),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@YJFB", model.YJFB),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@HAVEIMG", model.HAVEIMG),
                                        new SqlParameter("@RCYJXS", model.RCYJXS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAFYMXTSCL model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKATSCLMXID", model.LKATSCLMXID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@CLFS", model.CLFS),
                                        new SqlParameter("@SQFYJE", model.SQFYJE),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@YJFB", model.YJFB),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@HAVEIMG", model.HAVEIMG),
                                        new SqlParameter("@RCYJXS", model.RCYJXS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@HXR", model.HXR),



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_COST_LKAFYMXTSCL> ReadByParam(CRM_COST_LKAFYMXTSCL model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                       new SqlParameter("@LKATSCLMXID", model.LKATSCLMXID),
                                       new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                       new SqlParameter("@CX_BEGIN", model.CX_BEGIN),
                                       new SqlParameter("@CX_END", model.CX_END),
                                       new SqlParameter("@CX_MC", model.CX_MC),
                                       new SqlParameter("@CX_CRMID", model.CX_CRMID),
                                       new SqlParameter("@CX_ISACTIVE", model.CX_ISACTIVE),
                                       new SqlParameter("@CX_CLFS", model.CX_CLFS),
                                       //new SqlParameter("@MC", model.MC),
                                       //new SqlParameter("@HTYEAR", model.HTYEAR),
                                       //new SqlParameter("@HTMONTH", model.HTMONTH)


                                   };
            IList<CRM_COST_LKAFYMXTSCL> nodes = new List<CRM_COST_LKAFYMXTSCL>();
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

        public IList<CRM_COST_LKAFYMXTSCL> Read_Unconnected(CRM_COST_LKAFYMXTSCL model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                       new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR),
                                       new SqlParameter("@TT_LKAID", model.TT_LKAID)


                                   };
            IList<CRM_COST_LKAFYMXTSCL> nodes = new List<CRM_COST_LKAFYMXTSCL>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_Unconnected, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj2(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int Delete(int LKATSCLMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKATSCLMXID", LKATSCLMXID)
                                       

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

        private CRM_COST_LKAFYMXTSCL ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAFYMXTSCL node = new CRM_COST_LKAFYMXTSCL();
            node.LKATSCLMXID = Convert.ToInt32(sdr["LKATSCLMXID"]);
            node.LKAFYTTID = Convert.ToInt32(sdr["LKAFYTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.CLFS = Convert.ToInt32(sdr["CLFS"]);
            node.SQFYJE = Convert.ToDouble(sdr["SQFYJE"]);
            node.YJXS = Convert.ToDouble(sdr["YJXS"]);
            node.YJFB = Convert.ToDouble(sdr["YJFB"]);
            node.SJXS = Convert.ToDouble(sdr["SJXS"]);
            node.SJFB = Convert.ToDouble(sdr["SJFB"]);
            node.HAVEIMG = Convert.ToInt32(sdr["HAVEIMG"]);
            node.RCYJXS = Convert.ToInt32(sdr["RCYJXS"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.HXR = Convert.ToInt32(sdr["HXR"]);
            node.HXSJ = Convert.ToDateTime(sdr["HXSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.HXRNAME = Convert.ToString(sdr["HXRNAME"]);
            node.CLFSDES = Convert.ToString(sdr["CLFSDES"]);



            return node;
        }

        private CRM_COST_LKAFYMXTSCL ReadDataToObj2(SqlDataReader sdr)
        {
            CRM_COST_LKAFYMXTSCL node = new CRM_COST_LKAFYMXTSCL();
            node.LKATSCLMXID = Convert.ToInt32(sdr["LKATSCLMXID"]);
            node.LKAFYTTID = Convert.ToInt32(sdr["LKAFYTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.CLFS = Convert.ToInt32(sdr["CLFS"]);
            node.SQFYJE = Convert.ToDouble(sdr["SQFYJE"]);
            node.YJXS = Convert.ToDouble(sdr["YJXS"]);
            node.YJFB = Convert.ToDouble(sdr["YJFB"]);
            node.SJXS = Convert.ToDouble(sdr["SJXS"]);
            node.SJFB = Convert.ToDouble(sdr["SJFB"]);
            node.HAVEIMG = Convert.ToInt32(sdr["HAVEIMG"]);
            node.RCYJXS = Convert.ToInt32(sdr["RCYJXS"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.HXR = Convert.ToInt32(sdr["HXR"]);
            node.HXSJ = Convert.ToDateTime(sdr["HXSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            //node.MC = Convert.ToString(sdr["MC"]);
            //node.CRMID = Convert.ToString(sdr["CRMID"]);
            //node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            //node.HXRNAME = Convert.ToString(sdr["HXRNAME"]);
            //node.CLFSDES = Convert.ToString(sdr["CLFSDES"]);
            node.TT_HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.TT_FYLB = Convert.ToInt32(sdr["FYLB"]);

            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.CLFSDES = Convert.ToString(sdr["CLFSDES"]);
            return node;
        }




    }
}
