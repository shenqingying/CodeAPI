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
    public class COST_LKAHXZLTT : ICOST_LKAHXZLTT
    {
        private const string SQL_Create = "CRM_COST_LKAHXZLTT_Create";
        private const string SQL_Update = "CRM_COST_LKAHXZLTT_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAHXZLTT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAHXZLTT_Delete";
        private const string SQL_ReadTTGLinfo = "CRM_COST_LKAHXZLTT_ReadTTGLinfo";
        private const string SQL_ReadByPublic = "CRM_COST_HXZLTT_ReadByPublic";

        public int Create(CRM_COST_LKAHXZLTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        //new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        //new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@JXSID", model.JXSID),
                                        new SqlParameter("@BNDXSRW", model.BNDXSRW),
                                        new SqlParameter("@BNDALRW", model.BNDALRW),
                                        new SqlParameter("@XSWCL", model.XSWCL),
                                        new SqlParameter("@ALWCL", model.ALWCL),
                                        new SqlParameter("@SPJE", model.SPJE),
                                        new SqlParameter("@YHXJE", model.YHXJE),
                                        new SqlParameter("@HTNDYGXS", model.HTNDYGXS),
                                        new SqlParameter("@MQLKAXSSJ", model.MQLKAXSSJ),
                                        new SqlParameter("@LKABNDWCL", model.LKABNDWCL),
                                        new SqlParameter("@FYHXXS", model.FYHXXS),
                                        new SqlParameter("@LKAYJCMDSL", model.LKAYJCMDSL),
                                        new SqlParameter("@CRMBAMD", model.CRMBAMD),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAHXZLTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", model.HXZLTTID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@BNDXSRW", model.BNDXSRW),
                                        new SqlParameter("@BNDALRW", model.BNDALRW),
                                        new SqlParameter("@XSWCL", model.XSWCL),
                                        new SqlParameter("@ALWCL", model.ALWCL),
                                        new SqlParameter("@SPJE", model.SPJE),
                                        new SqlParameter("@YHXJE", model.YHXJE),
                                        new SqlParameter("@HTNDYGXS", model.HTNDYGXS),
                                        new SqlParameter("@MQLKAXSSJ", model.MQLKAXSSJ),
                                        new SqlParameter("@LKABNDWCL", model.LKABNDWCL),
                                        new SqlParameter("@FYHXXS", model.FYHXXS),
                                        new SqlParameter("@LKAYJCMDSL", model.LKAYJCMDSL),
                                        new SqlParameter("@CRMBAMD", model.CRMBAMD),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SPZT", model.SPZT),
                                        new SqlParameter("@OPINION", model.OPINION),
                                        new SqlParameter("@XGR", model.XGR)



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_COST_LKAHXZLTT> ReadByParam(CRM_COST_LKAHXZLTT model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", model.HXZLTTID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@LKANAME", model.LKANAME),
                                        new SqlParameter("@LKACRMID", model.LKACRMID),
                                        new SqlParameter("@JXSNAME", model.JXSNAME),
                                        new SqlParameter("@JXSSAPSN", model.JXSSAPSN),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID", STAFFID)


                                   };
            IList<CRM_COST_LKAHXZLTT> nodes = new List<CRM_COST_LKAHXZLTT>();
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
        public IList<CRM_COST_HXZLTT> ReadByPublic(CRM_COST_HXZLTT model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", model.HXZLTTID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@LKANAME", model.LKANAME),
                                        new SqlParameter("@LKACRMID", model.LKACRMID),
                                        new SqlParameter("@JXSNAME", model.JXSNAME),
                                        new SqlParameter("@JXSSAPSN", model.JXSSAPSN),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID", STAFFID)


                                   };
            IList<CRM_COST_HXZLTT> nodes = new List<CRM_COST_HXZLTT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByPublic, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj3(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public CRM_COST_LKAHXZLTT ReadTTGLinfo(CRM_COST_LKAHXZLTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE)


                                   };
            CRM_COST_LKAHXZLTT nodes = new CRM_COST_LKAHXZLTT();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadTTGLinfo, parms))
                {
                    if (sdr.Read())
                    {
                        nodes = ReadDataToObj2(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int Delete(int HXZLTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", HXZLTTID)
                                       

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

        private CRM_COST_LKAHXZLTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAHXZLTT node = new CRM_COST_LKAHXZLTT();
            node.HXZLTTID = Convert.ToInt32(sdr["HXZLTTID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.LKAID = Convert.ToInt32(sdr["LKAID"]);
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.BNDXSRW = Convert.ToDouble(sdr["BNDXSRW"]);
            node.BNDALRW = Convert.ToDouble(sdr["BNDALRW"]);
            node.XSWCL = Convert.ToDouble(sdr["XSWCL"]);
            node.ALWCL = Convert.ToDouble(sdr["ALWCL"]);
            node.SPJE = Convert.ToDouble(sdr["SPJE"]);
            node.YHXJE = Convert.ToDouble(sdr["YHXJE"]);
            node.LKAXSSJLX = Convert.ToInt32(sdr["LKAXSSJLX"]);
            node.HTNDYGXS = Convert.ToDouble(sdr["HTNDYGXS"]);
            node.MQLKAXSSJ = Convert.ToDouble(sdr["MQLKAXSSJ"]);
            node.LKABNDWCL = Convert.ToDouble(sdr["LKABNDWCL"]);
            node.FYHXXS = Convert.ToInt32(sdr["FYHXXS"]);
            node.LKAYJCMDSL = Convert.ToInt32(sdr["LKAYJCMDSL"]);
            node.CRMBAMD = Convert.ToInt32(sdr["CRMBAMD"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.SPZT = Convert.ToInt32(sdr["SPZT"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.LKANAME = Convert.ToString(sdr["LKANAME"]);
            node.LKACRMID = Convert.ToString(sdr["LKACRMID"]);
            node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.LKAXSSJLXDES = Convert.ToString(sdr["LKAXSSJLXDES"]);
            node.FYHXXSDES = Convert.ToString(sdr["FYHXXSDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);


            return node;
        }

        private CRM_COST_LKAHXZLTT ReadDataToObj2(SqlDataReader sdr)
        {
            CRM_COST_LKAHXZLTT node = new CRM_COST_LKAHXZLTT();
            node.SPJE = Convert.ToDouble(sdr["SPJE"]);
            node.YHXJE = Convert.ToDouble(sdr["YHXJE"]);
            node.LKAXSSJLX = Convert.ToInt32(sdr["LKAXSSJLX"]);
            node.HTNDYGXS = Convert.ToDouble(sdr["HTNDYGXS"]);
            node.MQLKAXSSJ = Convert.ToDouble(sdr["MQLKAXSSJ"]);
            if (node.HTNDYGXS == 0)
                node.LKABNDWCL = 0;
            else
                node.LKABNDWCL = Math.Round(Convert.ToDouble(sdr["MQLKAXSSJ"]) / Convert.ToDouble(sdr["HTNDYGXS"]) * 100, 2);
            node.LKAYJCMDSL = Convert.ToInt32(sdr["LKAYJCMDSL"]);
            node.CRMBAMD = Convert.ToInt32(sdr["CRMBAMD"]);


            return node;
        }
        private CRM_COST_HXZLTT ReadDataToObj3(SqlDataReader sdr)
        {
            CRM_COST_HXZLTT node = new CRM_COST_HXZLTT();
            node.HXZLTTID = Convert.ToInt32(sdr["HXZLTTID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.LKAID = Convert.ToInt32(sdr["LKAID"]);
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.BNDXSRW = Convert.ToDouble(sdr["BNDXSRW"]);
            node.BNDALRW = Convert.ToDouble(sdr["BNDALRW"]);
            node.XSWCL = Convert.ToDouble(sdr["XSWCL"]);
            node.ALWCL = Convert.ToDouble(sdr["ALWCL"]);
            node.SPJE = Convert.ToDouble(sdr["SPJE"]);
            node.YHXJE = Convert.ToDouble(sdr["YHXJE"]);
            node.LKAXSSJLX = Convert.ToInt32(sdr["LKAXSSJLX"]);
            node.HTNDYGXS = Convert.ToDouble(sdr["HTNDYGXS"]);
            node.MQLKAXSSJ = Convert.ToDouble(sdr["MQLKAXSSJ"]);
            node.LKABNDWCL = Convert.ToDouble(sdr["LKABNDWCL"]);
            node.FYHXXS = Convert.ToInt32(sdr["FYHXXS"]);
            node.LKAYJCMDSL = Convert.ToInt32(sdr["LKAYJCMDSL"]);
            node.CRMBAMD = Convert.ToInt32(sdr["CRMBAMD"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.SPZT = Convert.ToInt32(sdr["SPZT"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.LKANAME = Convert.ToString(sdr["LKANAME"]);
            node.LKACRMID = Convert.ToString(sdr["LKACRMID"]);
            node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.LKAXSSJLXDES = Convert.ToString(sdr["LKAXSSJLXDES"]);
            node.FYHXXSDES = Convert.ToString(sdr["FYHXXSDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);


            return node;
        }









    }
}
