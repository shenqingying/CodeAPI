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
    public class COST_KAHXDJMX : ICOST_KAHXDJMX
    {
        private const string SQL_Create = "CRM_COST_KAHXDJMX_Create";
        private const string SQL_Update = "CRM_COST_KAHXDJMX_Update";
        private const string SQL_ReadByParam = "CRM_COST_KAHXDJMX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_KAHXDJMX_Delete";
        private const string SQL_ReadForPrint = "CRM_COST_KAHXDJMX_ReadForPrint";
        private const string SQL_AddPrintCount = "CRM_COST_KAHXDJMX_AddPrintCount";

        public int Create(CRM_COST_KAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJTTID", model.HXDJTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@FYHXXS", model.FYHXXS),
                                        new SqlParameter("@CWHSBH", model.CWHSBH),
                                        new SqlParameter("@CBZXBH", model.CBZXBH),
                                        new SqlParameter("@HXJE", model.HXJE),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@WSJE", model.WSJE),
                                        new SqlParameter("@HXRQ", model.HXRQ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@PRINTTHIS", model.PRINTTHIS),
                                        new SqlParameter("@PRINTKH", model.PRINTKH),
                                        new SqlParameter("@GID", model.GID),
                                        new SqlParameter("@GIDCBZXBH", model.GIDCBZXBH),
                                        new SqlParameter("@FKFKHID", model.FKFKHID),
                                        new SqlParameter("@DISPLAYTEMP", model.DISPLAYTEMP),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@HXDJTTID", model.HXDJTTID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@FYHXXS", model.FYHXXS),
                                        new SqlParameter("@CWHSBH", model.CWHSBH),
                                        new SqlParameter("@CBZXBH", model.CBZXBH),
                                        new SqlParameter("@HXJE", model.HXJE),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@WSJE", model.WSJE),
                                        new SqlParameter("@HXRQ", model.HXRQ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@PRINTTHIS", model.PRINTTHIS),
                                        new SqlParameter("@PRINTKH", model.PRINTKH),
                                        new SqlParameter("@GID", model.GID),
                                        new SqlParameter("@GIDCBZXBH", model.GIDCBZXBH),
                                        new SqlParameter("@FKFKHID", model.FKFKHID),
                                        new SqlParameter("@DISPLAYTEMP", model.DISPLAYTEMP),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int AddPrintCount(int HXDJMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", HXDJMXID)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_AddPrintCount, parms);
        }

        public IList<CRM_COST_KAHXDJMX> ReadByParam(CRM_COST_KAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@HXDJTTID", model.HXDJTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@CWHSBH", model.CWHSBH),
                                        new SqlParameter("@CBZXBH", model.CBZXBH),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@PRINTKHMC", model.PRINTKHMC),
                                        new SqlParameter("@CJSJ_BEGIN", model.CJSJ_BEGIN),
                                        new SqlParameter("@CJSJ_END", model.CJSJ_END),
                                        new SqlParameter("@CXYFYLX", model.CXYFYLX)

                                   };
            IList<CRM_COST_KAHXDJMX> nodes = new List<CRM_COST_KAHXDJMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj(sdr, model.COSTITEMID));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_KAHXDJMX> ReadForPrint(CRM_COST_KAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXIDSTR", model.HXDJMXIDSTR)

                                   };
            IList<CRM_COST_KAHXDJMX> nodes = new List<CRM_COST_KAHXDJMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadForPrint, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadPrintDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int HXDJMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", HXDJMXID)
                                       

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

        private CRM_COST_KAHXDJMX ReadDataToObj(SqlDataReader sdr, int COSTITEMID)
        {
            CRM_COST_KAHXDJMX node = new CRM_COST_KAHXDJMX();
            node.HXDJMXID = Convert.ToInt32(sdr["HXDJMXID"]);
            node.HXDJTTID = Convert.ToInt32(sdr["HXDJTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.FYHXXS = Convert.ToInt32(sdr["FYHXXS"]);
            node.CWHSBH = Convert.ToString(sdr["CWHSBH"]);
            node.CBZXBH = Convert.ToString(sdr["CBZXBH"]);
            node.HXJE = Convert.ToDecimal(sdr["HXJE"]);
            node.SL = Convert.ToInt32(sdr["SL"]);
            node.WSJE = Convert.ToDecimal(sdr["WSJE"]);
            node.HXRQ = Convert.ToString(sdr["HXRQ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.PRINTTHIS = Convert.ToInt32(sdr["PRINTTHIS"]);
            node.PRINTKH = Convert.ToInt32(sdr["PRINTKH"]);
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.GIDCBZXBH = Convert.ToString(sdr["GIDCBZXBH"]);
            node.FKFKHID = Convert.ToInt32(sdr["FKFKHID"]);
            node.DISPLAYTEMP = Convert.ToInt32(sdr["DISPLAYTEMP"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.PRINTCOUNT = Convert.ToInt32(sdr["PRINTCOUNT"]);
            node.PRINTKHMC = Convert.ToString(sdr["PRINTKHMC"]);


            node.GNAME = Convert.ToString(sdr["GNAME"]);


            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.SLDES = Convert.ToString(sdr["SLDES"]);
            node.FYHXXSDES = Convert.ToString(sdr["FYHXXSDES"]);
            node.CWHSBHDES = Convert.ToString(sdr["CWHSBHDES"]);
            node.CBZXBHDES = Convert.ToString(sdr["CBZXBHDES"]);
            node.GIDCBZXBHDES = Convert.ToString(sdr["GIDCBZXBHDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.FKFNAME = Convert.ToString(sdr["FKFNAME"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.KHSAPSN = Convert.ToString(sdr["KHSAPSN"]);
            node.FPHM = Convert.ToString(sdr["FPHM"]);
            node.MDID = Convert.ToInt32(sdr["MDID"]);
            node.MDMC = Convert.ToString(sdr["MDMC"]);

            node.ConnectedGID = Convert.ToInt32(sdr["ConnectedGID"]);
            node.ConnectedGNAME = Convert.ToString(sdr["ConnectedGNAME"]);

            node.ITEM_CWHSBH = Convert.ToString(sdr["ITEM_CWHSBH"]);
            node.ITEM_CWHSBHDES = Convert.ToString(sdr["ITEM_CWHSBHDES"]);

            node.SPJE = Convert.ToDecimal(sdr["SPJE"]);
            node.YHXJE = Convert.ToDecimal(sdr["YHXJE"]);
            node.HXJE = Convert.ToDecimal(sdr["HXJE"]);

            if (COSTITEMID == 54)
            {
                node.CXYFYLX = Convert.ToInt32(sdr["CXYFYLX"]);
                node.CXYFYLXDES = Convert.ToString(sdr["CXYFYLXDES"]);
            }

            return node;
        }

        private CRM_COST_KAHXDJMX ReadPrintDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAHXDJMX node = new CRM_COST_KAHXDJMX();
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.CWHSBH = Convert.ToString(sdr["CWHSBH"]);
            node.CBZXBH = Convert.ToString(sdr["CBZXBH"]);
            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.CWHSBHDES = Convert.ToString(sdr["CWHSBHDES"]);
            node.HXJE = Convert.ToDecimal(sdr["HXJE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.FKFSAPSN = Convert.ToString(sdr["FKFSAPSN"]);

            return node;
        }




    }
}
