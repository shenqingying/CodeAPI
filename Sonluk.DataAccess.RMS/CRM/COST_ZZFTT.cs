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
    public class COST_ZZFTT : ICOST_ZZFTT
    {
        private const string SQL_Create = "CRM_COST_ZZFTT_Create";
        private const string SQL_Update = "CRM_COST_ZZFTT_Update";
        private const string SQL_ReadByParam = "CRM_COST_ZZFTT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_ZZFTT_Delete";
        private const string SQL_Read_Unconnected = "CRM_COST_ZZFTT_Read_Unconnected";
        private const string SQL_Read_Unconnected2 = "CRM_COST_ZZFTT_Read_Unconnected2";
        private const string SQL_Read_KA = "CRM_COST_ZZFTT_Read_KA";
        private const string SQL_Read_LKA = "CRM_COST_ZZFTT_Read_LKA";
        private const string SQL_ReadByCostitemid = "CRM_COST_ZZFTT_ReadByCostitemid";
        private const string SQL_UpdateTBSJ = "CRM_COST_ZZFTT_UpdateTBSJ";
        private const string SQL_Read_LKAUnconnected = "CRM_COST_ZZFTT_Read_LKAUnconnected";
        private const string SQL_Read_KAUnconnected = "CRM_COST_ZZFTT_Read_KAUnconnected";
        
        public int Create(CRM_COST_ZZFTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@ZZLX", model.ZZLX),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@PKHID", model.PKHID),
                                        new SqlParameter("@GGADDRESS", model.GGADDRESS),
                                        new SqlParameter("@LXR", model.LXR),
                                        new SqlParameter("@LXDH", model.LXDH),
                                        new SqlParameter("@QKSM", model.QKSM),
                                        new SqlParameter("@WZPG", model.WZPG),
                                        new SqlParameter("@ZZQYDXS", model.ZZQYDXS),
                                        new SqlParameter("@ZZHYDXS", model.ZZHYDXS),
                                        new SqlParameter("@SFYCXYZC", model.SFYCXYZC),
                                        new SqlParameter("@CXYFY", model.CXYFY),
                                        new SqlParameter("@SFCSCLFY", model.SFCSCLFY),
                                        new SqlParameter("@CLFY", model.CLFY),
                                        new SqlParameter("@XQRK", model.XQRK),
                                        new SqlParameter("@GGJL", model.GGJL),
                                        new SqlParameter("@GGSL", model.GGSL),
                                        new SqlParameter("@ZZF", model.ZZF),
                                        new SqlParameter("@GGZLF", model.GGZLF),
                                        new SqlParameter("@SQJE", model.SQJE),
                                        new SqlParameter("@ZLSTARTTIME", model.ZLSTARTTIME),
                                        new SqlParameter("@ZLENDTIME", model.ZLENDTIME),
                                        new SqlParameter("@GGGSID", model.GGGSID),
                                        new SqlParameter("@OPINION", model.OPINION),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@FINALCOST", model.FINALCOST),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@GGWSJE", model.GGWSJE),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_ZZFTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@ZZLX", model.ZZLX),
                                       // new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@PKHID", model.PKHID),
                                        new SqlParameter("@GGADDRESS", model.GGADDRESS),
                                        new SqlParameter("@LXR", model.LXR),
                                        new SqlParameter("@LXDH", model.LXDH),
                                        new SqlParameter("@QKSM", model.QKSM),
                                        new SqlParameter("@WZPG", model.WZPG),
                                        new SqlParameter("@ZZQYDXS", model.ZZQYDXS),
                                        new SqlParameter("@ZZHYDXS", model.ZZHYDXS),
                                        new SqlParameter("@SFYCXYZC", model.SFYCXYZC),
                                        new SqlParameter("@CXYFY", model.CXYFY),
                                        new SqlParameter("@SFCSCLFY", model.SFCSCLFY),
                                        new SqlParameter("@CLFY", model.CLFY),
                                        new SqlParameter("@XQRK", model.XQRK),
                                        new SqlParameter("@GGJL", model.GGJL),
                                        new SqlParameter("@GGSL", model.GGSL),
                                        new SqlParameter("@ZZF", model.ZZF),
                                        new SqlParameter("@GGZLF", model.GGZLF),
                                        new SqlParameter("@SQJE", model.SQJE),
                                        new SqlParameter("@ZLSTARTTIME", model.ZLSTARTTIME),
                                        new SqlParameter("@ZLENDTIME", model.ZLENDTIME),
                                        new SqlParameter("@GGGSID", model.GGGSID),
                                        new SqlParameter("@OPINION", model.OPINION),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@FINALCOST", model.FINALCOST),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@HXR", model.HXR),
                                        new SqlParameter("@TTID", model.TTID),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@GGWSJE", model.GGWSJE),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_ZZFTT> ReadByParam(CRM_COST_ZZFTT model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TTID", model.TTID),   
                                        new SqlParameter("@ZZLX", model.ZZLX),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@GGGSID", model.GGGSID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@KHLX", model.KHLX),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@STAFFID",STAFFID),
                                   };
            IList<CRM_COST_ZZFTT> nodes = new List<CRM_COST_ZZFTT>();
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
        public IList<CRM_COST_ZZFTT> Read_KA(CRM_COST_ZZFTT model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TTID", model.TTID),   
                                        new SqlParameter("@ZZLX", model.ZZLX),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@GGGSID", model.GGGSID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@STAFFID", STAFFID),
                                   };
            IList<CRM_COST_ZZFTT> nodes = new List<CRM_COST_ZZFTT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_KA, parms))
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



        public IList<CRM_COST_ZZFTT> Read_LKA(CRM_COST_ZZFTT model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TTID", model.TTID),   
                                        new SqlParameter("@ZZLX", model.ZZLX),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@GGGSID", model.GGGSID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@STAFFID",STAFFID),
                                   };
            IList<CRM_COST_ZZFTT> nodes = new List<CRM_COST_ZZFTT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_LKA, parms))
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
        public IList<CRM_COST_ZZFTT> ReadByCostitemid(CRM_COST_ZZFTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@TT_KHID", model.TT_KHID),
                                        new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR),
                                   };
            IList<CRM_COST_ZZFTT> nodes = new List<CRM_COST_ZZFTT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByCostitemid, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj4(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_ZZFTT> Read_LKAUnconnected(CRM_COST_ZZFTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@TT_KHID", model.TT_KHID),
                                        new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR),
                                   };
            IList<CRM_COST_ZZFTT> nodes = new List<CRM_COST_ZZFTT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_LKAUnconnected, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj4(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_ZZFTT> Read_KAUnconnected(CRM_COST_ZZFTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@TT_KHID", model.TT_KHID),
                                        new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR),
                                   };
            IList<CRM_COST_ZZFTT> nodes = new List<CRM_COST_ZZFTT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_KAUnconnected, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj4(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_ZZFTT> Read_Unconnected(CRM_COST_ZZFTT model)
        {
            SqlParameter[] parms = {    
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID)
                                   };
            IList<CRM_COST_ZZFTT> nodes = new List<CRM_COST_ZZFTT>();
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
        public IList<CRM_COST_ZZFTT> Read_Unconnected2(CRM_COST_ZZFTT model)
        {
            SqlParameter[] parms = {    
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID)
                                       
                                   };
            IList<CRM_COST_ZZFTT> nodes = new List<CRM_COST_ZZFTT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_Unconnected2, parms))
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

        public int Delete(int TTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TTID", TTID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }


        public int UpdateTBSJ(int TTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TTID", TTID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateTBSJ, parms);
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

        private CRM_COST_ZZFTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_ZZFTT node = new CRM_COST_ZZFTT();
            node.TTID = Convert.ToInt32(sdr["TTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.ZZLX = Convert.ToInt32(sdr["ZZLX"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.PKHID = Convert.ToInt32(sdr["PKHID"]);
            node.GGADDRESS = Convert.ToString(sdr["GGADDRESS"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.LXDH = Convert.ToString(sdr["LXDH"]);
            node.QKSM = Convert.ToString(sdr["QKSM"]);
            node.WZPG = Convert.ToString(sdr["WZPG"]);
            node.ZZQYDXS = Convert.ToDouble(sdr["ZZQYDXS"]);
            node.ZZHYDXS = Convert.ToDouble(sdr["ZZHYDXS"]);
            node.SFYCXYZC = Convert.ToInt32(sdr["SFYCXYZC"]);
            node.CXYFY = Convert.ToDouble(sdr["CXYFY"]);
            node.SFCSCLFY = Convert.ToInt32(sdr["SFCSCLFY"]);
            node.CLFY = Convert.ToDouble(sdr["CLFY"]);
            node.XQRK = Convert.ToString(sdr["XQRK"]);
            node.GGJL = Convert.ToString(sdr["GGJL"]);
            node.GGSL = Convert.ToInt32(sdr["GGSL"]);
            node.ZZF = Convert.ToDouble(sdr["ZZF"]);    
            node.GGZLF = Convert.ToDouble(sdr["GGZLF"]);
            node.SQJE = Convert.ToDouble(sdr["SQJE"]);
            node.ZLSTARTTIME = Convert.ToString(sdr["ZLSTARTTIME"]);
            node.ZLENDTIME = Convert.ToString(sdr["ZLENDTIME"]);
            node.GGGSID = Convert.ToInt32(sdr["GGGSID"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.HXR = Convert.ToInt32(sdr["HXR"]);
            node.HXSJ = Convert.ToDateTime(sdr["HXSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ZZLXDES = Convert.ToString(sdr["ZZLXDES"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.HXRDES = Convert.ToString(sdr["HXRDES"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.MCNAME = Convert.ToString(sdr["MCNAME"]);
            node.PKHIDDES = Convert.ToString(sdr["PKHIDDES"]);
            node.FINALCOST = Convert.ToDouble(sdr["FINALCOST"]);
            node.SQJEAll = Convert.ToDouble(sdr["SQJEAll"]);
            node.GGGSMCALL = Convert.ToString(sdr["GGGSMCALL"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHXZ = Convert.ToInt32(sdr["KHXZ"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.COSTITEMMC = Convert.ToString(sdr["COSTITEMMC"]);
            node.COSTITEMDES = Convert.ToString(sdr["COSTITEMDES"]);
            node.SL = Convert.ToInt32(sdr["SL"]);
            node.GGWSJE = Convert.ToDouble(sdr["GGWSJE"]);
            node.AMOUNT = Convert.ToDouble(sdr["AMOUNT"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            return node;
        }

        private CRM_COST_ZZFTT ReadDataToObj2(SqlDataReader sdr)
        {
            CRM_COST_ZZFTT node = new CRM_COST_ZZFTT();
            node.TTID = Convert.ToInt32(sdr["TTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.ZZLX = Convert.ToInt32(sdr["ZZLX"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.PKHID = Convert.ToInt32(sdr["PKHID"]);
            node.GGADDRESS = Convert.ToString(sdr["GGADDRESS"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.LXDH = Convert.ToString(sdr["LXDH"]);
            node.QKSM = Convert.ToString(sdr["QKSM"]);
            node.WZPG = Convert.ToString(sdr["WZPG"]);
            node.ZZQYDXS = Convert.ToDouble(sdr["ZZQYDXS"]);
            node.ZZHYDXS = Convert.ToDouble(sdr["ZZHYDXS"]);
            node.SFYCXYZC = Convert.ToInt32(sdr["SFYCXYZC"]);
            node.CXYFY = Convert.ToDouble(sdr["CXYFY"]);
            node.SFCSCLFY = Convert.ToInt32(sdr["SFCSCLFY"]);
            node.CLFY = Convert.ToDouble(sdr["CLFY"]);
            node.XQRK = Convert.ToString(sdr["XQRK"]);
            node.GGJL = Convert.ToString(sdr["GGJL"]);
            node.GGSL = Convert.ToInt32(sdr["GGSL"]);
            node.ZZF = Convert.ToDouble(sdr["ZZF"]);
            node.GGZLF = Convert.ToDouble(sdr["GGZLF"]);
            node.SQJE = Convert.ToDouble(sdr["SQJEAll"]);
            node.ZLSTARTTIME = Convert.ToString(sdr["ZLSTARTTIME"]);
            node.ZLENDTIME = Convert.ToString(sdr["ZLENDTIME"]);
            node.GGGSID = Convert.ToInt32(sdr["GGGSID"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.HXR = Convert.ToInt32(sdr["HXR"]);
            node.HXSJ = Convert.ToDateTime(sdr["HXSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.FINALCOST = Convert.ToDouble(sdr["FINALCOST"]);
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.ZZLXDES = Convert.ToString(sdr["ZZLXDES"]);
            node.MCNAME = Convert.ToString(sdr["MCNAME"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            return node;
        }
        private CRM_COST_ZZFTT ReadDataToObj3(SqlDataReader sdr)
        {
            CRM_COST_ZZFTT node = new CRM_COST_ZZFTT();
            node.TTID = Convert.ToInt32(sdr["TTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.ZZLX = Convert.ToInt32(sdr["ZZLX"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.PKHID = Convert.ToInt32(sdr["PKHID"]);
            node.GGADDRESS = Convert.ToString(sdr["GGADDRESS"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.LXDH = Convert.ToString(sdr["LXDH"]);
            node.QKSM = Convert.ToString(sdr["QKSM"]);
            node.WZPG = Convert.ToString(sdr["WZPG"]);
            node.ZZQYDXS = Convert.ToDouble(sdr["ZZQYDXS"]);
            node.ZZHYDXS = Convert.ToDouble(sdr["ZZHYDXS"]);
            node.SFYCXYZC = Convert.ToInt32(sdr["SFYCXYZC"]);
            node.CXYFY = Convert.ToDouble(sdr["CXYFY"]);
            node.SFCSCLFY = Convert.ToInt32(sdr["SFCSCLFY"]);
            node.CLFY = Convert.ToDouble(sdr["CLFY"]);
            node.XQRK = Convert.ToString(sdr["XQRK"]);
            node.GGJL = Convert.ToString(sdr["GGJL"]);
            node.GGSL = Convert.ToInt32(sdr["GGSL"]);
            node.ZZF = Convert.ToDouble(sdr["ZZF"]);
            node.GGZLF = Convert.ToDouble(sdr["GGZLF"]);
            node.SQJE = Convert.ToDouble(sdr["SQJE"]);
            node.ZLSTARTTIME = Convert.ToString(sdr["ZLSTARTTIME"]);
            node.ZLENDTIME = Convert.ToString(sdr["ZLENDTIME"]);
            node.GGGSID = Convert.ToInt32(sdr["GGGSID"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.HXR = Convert.ToInt32(sdr["HXR"]);
            node.HXSJ = Convert.ToDateTime(sdr["HXSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ZZLXDES = Convert.ToString(sdr["ZZLXDES"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.HXRDES = Convert.ToString(sdr["HXRDES"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.MCNAME = Convert.ToString(sdr["MCNAME"]);
            node.PKHIDDES = Convert.ToString(sdr["PKHIDDES"]);
            node.FINALCOST = Convert.ToDouble(sdr["FINALCOST"]);
            node.SQJEAll = Convert.ToDouble(sdr["SQJEAll"]);
            node.GGGSMCALL = Convert.ToString(sdr["GGGSMCALL"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHXZ = Convert.ToInt32(sdr["KHXZ"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.COSTITEMMC = Convert.ToString(sdr["COSTITEMMC"]);
            node.HXZLMXID = Convert.ToInt32(sdr["HXZLMXID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            return node;
        }
        private CRM_COST_ZZFTT ReadDataToObj4(SqlDataReader sdr)
        {
            CRM_COST_ZZFTT node = new CRM_COST_ZZFTT();
            node.TTID = Convert.ToInt32(sdr["TTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.ZZLX = Convert.ToInt32(sdr["ZZLX"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.PKHID = Convert.ToInt32(sdr["PKHID"]);
            node.GGADDRESS = Convert.ToString(sdr["GGADDRESS"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.LXDH = Convert.ToString(sdr["LXDH"]);
            node.QKSM = Convert.ToString(sdr["QKSM"]);
            node.WZPG = Convert.ToString(sdr["WZPG"]);
            node.ZZQYDXS = Convert.ToDouble(sdr["ZZQYDXS"]);
            node.ZZHYDXS = Convert.ToDouble(sdr["ZZHYDXS"]);
            node.SFYCXYZC = Convert.ToInt32(sdr["SFYCXYZC"]);
            node.CXYFY = Convert.ToDouble(sdr["CXYFY"]);
            node.SFCSCLFY = Convert.ToInt32(sdr["SFCSCLFY"]);
            node.CLFY = Convert.ToDouble(sdr["CLFY"]);
            node.XQRK = Convert.ToString(sdr["XQRK"]);
            node.GGJL = Convert.ToString(sdr["GGJL"]);
            node.GGSL = Convert.ToInt32(sdr["GGSL"]);
            node.ZZF = Convert.ToDouble(sdr["ZZF"]);
            node.GGZLF = Convert.ToDouble(sdr["GGZLF"]);
            node.SQJE = Convert.ToDouble(sdr["SQJE"]);
            node.ZLSTARTTIME = Convert.ToString(sdr["ZLSTARTTIME"]);
            node.ZLENDTIME = Convert.ToString(sdr["ZLENDTIME"]);
            node.GGGSID = Convert.ToInt32(sdr["GGGSID"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.HXR = Convert.ToInt32(sdr["HXR"]);
            node.HXSJ = Convert.ToDateTime(sdr["HXSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ZZLXDES = Convert.ToString(sdr["ZZLXDES"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.HXRDES = Convert.ToString(sdr["HXRDES"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.MCNAME = Convert.ToString(sdr["MCNAME"]);
            node.PKHIDDES = Convert.ToString(sdr["PKHIDDES"]);
            node.FINALCOST = Convert.ToDouble(sdr["FINALCOST"]);
            node.SQJEAll = Convert.ToDouble(sdr["SQJEAll"]);
            node.GGGSMCALL = Convert.ToString(sdr["GGGSMCALL"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHXZ = Convert.ToInt32(sdr["KHXZ"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.MCSX = Convert.ToInt32(sdr["MCSX"]);
            node.COSTITEMMC = Convert.ToString(sdr["COSTITEMMC"]);
            node.COSTITEMDES = Convert.ToString(sdr["COSTITEMDES"]);
            node.YHXJE = Convert.ToDouble(sdr["YHXJE"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            return node;
        }


    }
}
