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
    public class COST_LKAXS : ICOST_LKAXS
    {
        private const string SQL_CreateTT = "CRM_COST_LKAXSTT_Create";
        private const string SQL_UpdateTT = "CRM_COST_LKAXSTT_Update";
        private const string SQL_ReadTTByParam = "CRM_COST_LKAXSTT_ReadByParam";
        private const string SQL_DeleteTT = "CRM_COST_LKAXSTT_Delete";
        private const string SQL_ReadKHbasic = "CRM_COST_LKAXSTT_ReadKHbasic";     //



        private const string SQL_CreateMX = "CRM_COST_LKAXSMX_Create";
        private const string SQL_UpdateMX = "CRM_COST_LKAXSMX_Update";
        private const string SQL_DeleteMX = "CRM_COST_LKAXSMX_Delete";
        private const string SQL_ReadMXByTTID = "CRM_COST_LKAXSMX_ReadMXByTTID";

        public int CreateTT(CRM_COST_LKAXSTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@JXSID", model.JXSID),
                                        new SqlParameter("@YWYID", model.YWYID),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@LKAXSSJLX", model.LKAXSSJLX),
                                        new SqlParameter("@XSSOURCE", model.XSSOURCE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_CreateTT, parms);
        }
        public int CreateMX(CRM_COST_LKAXSMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAXSTTID", model.LKAXSTTID),
                                        new SqlParameter("@XSYEAR", model.XSYEAR),
                                        new SqlParameter("@XSMONTH", model.XSMONTH),
                                        new SqlParameter("@MCXS", model.MCXS),
                                        new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_CreateMX, parms);
        }

        public int UpdateTT(CRM_COST_LKAXSTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAXSTTID", model.LKAXSTTID),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@JXSID", model.JXSID),
                                        new SqlParameter("@YWYID", model.YWYID),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@LKAXSSJLX", model.LKAXSSJLX),
                                        new SqlParameter("@XSSOURCE", model.XSSOURCE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateTT, parms);
        }

        public int UpdateMX(CRM_COST_LKAXSMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAXSMXID", model.LKAXSMXID),
                                        new SqlParameter("@LKAXSTTID", model.LKAXSTTID),
                                        new SqlParameter("@XSYEAR", model.XSYEAR),
                                        new SqlParameter("@XSMONTH", model.XSMONTH),
                                        new SqlParameter("@MCXS", model.MCXS),
                                        new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateMX, parms);
        }

        public IList<CRM_COST_LKAXSTT> ReadTTByParam(CRM_COST_LKAXSTT model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAXSTTID", model.LKAXSTTID),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@LKAXSSJLX", model.LKAXSSJLX),
                                        new SqlParameter("@XSSOURCE", model.XSSOURCE),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@JXSID", model.JXSID),
                                        new SqlParameter("@YWYID", model.YWYID),
                                        new SqlParameter("@LKAIDDES", model.LKAIDDES),
                                        new SqlParameter("@JXSIDDES", model.JXSIDDES),
                                        new SqlParameter("@JXSSAPSN", model.JXSSAPSN),
                                        new SqlParameter("@STAFFID", STAFFID)
                                   };
            IList<CRM_COST_LKAXSTT> nodes = new List<CRM_COST_LKAXSTT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadTTByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadTTDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_LKAXSMX> ReadMXByTTID(CRM_COST_LKAXSMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAXSTTID", model.LKAXSTTID),
                                        new SqlParameter("@XSYEAR", model.XSYEAR),
                                        new SqlParameter("@XSMONTH", model.XSMONTH)
                                   };
            IList<CRM_COST_LKAXSMX> nodes = new List<CRM_COST_LKAXSMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXByTTID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadMXDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_LKAXSTT> ReadKHbasic(CRM_COST_LKAXSTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID", model.LKAID)
                                   };
            IList<CRM_COST_LKAXSTT> nodes = new List<CRM_COST_LKAXSTT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadKHbasic, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadBasicDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int DeleteTT(int LKAXSTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAXSTTID", LKAXSTTID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteTT, parms);
        }

        public int DeleteMX(int LKAXSMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAXSMXID", LKAXSMXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteMX, parms);
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

        private CRM_COST_LKAXSTT ReadTTDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAXSTT node = new CRM_COST_LKAXSTT();
            node.LKAXSTTID = Convert.ToInt32(sdr["LKAXSTTID"]);
            node.LKAID = Convert.ToInt32(sdr["LKAID"]);
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.YWYID = Convert.ToInt32(sdr["YWYID"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.LKAXSSJLX = Convert.ToInt32(sdr["LKAXSSJLX"]);
            node.XSSOURCE = Convert.ToInt32(sdr["XSSOURCE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.LKAIDDES = Convert.ToString(sdr["LKAIDDES"]);
            node.LKACRMID = Convert.ToString(sdr["LKACRMID"]);
            node.JXSIDDES = Convert.ToString(sdr["JXSIDDES"]);
            node.JXSCRMID = Convert.ToString(sdr["JXSCRMID"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.YWYIDDES = Convert.ToString(sdr["YWYIDDES"]);
            node.LKAXSSJLXDES = Convert.ToString(sdr["LKAXSSJLXDES"]);
            node.XSSOURCEDES = Convert.ToString(sdr["XSSOURCEDES"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            return node;
        }

        private CRM_COST_LKAXSMX ReadMXDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAXSMX node = new CRM_COST_LKAXSMX();
            node.LKAXSMXID = Convert.ToInt32(sdr["LKAXSMXID"]);
            node.LKAXSTTID = Convert.ToInt32(sdr["LKAXSTTID"]);
            node.XSYEAR = Convert.ToString(sdr["XSYEAR"]);
            node.XSMONTH = Convert.ToString(sdr["XSMONTH"]);
            node.MCXS = Convert.ToDouble(sdr["MCXS"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            return node;
        }

        private CRM_COST_LKAXSTT ReadBasicDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAXSTT node = new CRM_COST_LKAXSTT();
            node.LKAID = Convert.ToInt32(sdr["KHID"]);
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.YWYID = Convert.ToInt32(sdr["YWYID"]);
            node.SF = Convert.ToInt32(sdr["JXSSF"]);
            node.CS = Convert.ToInt32(sdr["JXSCS"]);
            node.LKAIDDES = Convert.ToString(sdr["MC"]);
            node.LKACRMID = Convert.ToString(sdr["CRMID"]);
            node.JXSIDDES = Convert.ToString(sdr["JXSMC"]);
            node.JXSCRMID = Convert.ToString(sdr["JXSCRMID"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.YWYIDDES = Convert.ToString(sdr["YWYNAME"]);
            node.SFDES = Convert.ToString(sdr["JXSSFDES"]);
            node.CSDES = Convert.ToString(sdr["JXSCSDES"]);
            return node;
        }


    }
}
