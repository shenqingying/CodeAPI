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
    public class COST_CLFMX : ICOST_CLFMX
    {
        private const string SQL_Create = "CRM_COST_CLFMX_Create";
        private const string SQL_Update = "CRM_COST_CLFMX_Update";
        private const string SQL_ReadByParam = "CRM_COST_CLFMX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CLFMX_Delete";
        private const string SQL_ReadPart = "CRM_COST_CLFMX_ReadPart";//差旅费核销  新增
        private const string SQL_ReadByTTID = "CRM_COST_CLFMX_ReadByTTID"; //

        public int Create(CRM_COST_CLFMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFTTID", model.CLFTTID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@BEGINADDRESS", model.BEGINADDRESS),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@ENDADDRESS", model.ENDADDRESS),
                                        new SqlParameter("@JT_PLANE", model.JT_PLANE),
                                        new SqlParameter("@JT_TRAIN", model.JT_TRAIN),
                                        new SqlParameter("@JT_BUS", model.JT_BUS),
                                        new SqlParameter("@JT_BILL", model.JT_BILL),
                                        new SqlParameter("@ZS_DAYS", model.ZS_DAYS),
                                        new SqlParameter("@ZS_JE", model.ZS_JE),
                                        new SqlParameter("@ZS_SFZYFP", model.ZS_SFZYFP),
                                        new SqlParameter("@ZS_FPBHSJE", model.ZS_FPBHSJE),
                                        new SqlParameter("@ZS_BILL", model.ZS_BILL),
                                        new SqlParameter("@BT_DAYS", model.BT_DAYS),
                                        new SqlParameter("@BT_BZ", model.BT_BZ),
                                        new SqlParameter("@BT_JE", model.BT_JE),
                                        new SqlParameter("@QT_ITEM", model.QT_ITEM),
                                        new SqlParameter("@QT_JE", model.QT_JE),
                                        new SqlParameter("@QT_SFZYFP", model.QT_SFZYFP),
                                        new SqlParameter("@QT_FPBHSJE", model.QT_FPBHSJE),
                                        new SqlParameter("@QT_BILL", model.QT_BILL),
                                        new SqlParameter("@QT_CCQLC", model.QT_CCQLC),
                                        new SqlParameter("@QT_CCHLC", model.QT_CCHLC),
                                        new SqlParameter("@QT_CCQJLC", model.QT_CCQJLC),
                                        new SqlParameter("@QT_JDMC", model.QT_JDMC),
                                        new SqlParameter("@QT_JDDZ", model.QT_JDDZ),
                                        new SqlParameter("@QT_JDLXFS", model.QT_JDLXFS),
                                        new SqlParameter("@QT_JDLXR", model.QT_JDLXR),
                                        new SqlParameter("@QT_PP", model.QT_PP),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CLFMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFTTID", model.CLFTTID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@BEGINADDRESS", model.BEGINADDRESS),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@ENDADDRESS", model.ENDADDRESS),
                                        new SqlParameter("@JT_PLANE", model.JT_PLANE),
                                        new SqlParameter("@JT_TRAIN", model.JT_TRAIN),
                                        new SqlParameter("@JT_BUS", model.JT_BUS),
                                        new SqlParameter("@JT_BILL", model.JT_BILL),
                                        new SqlParameter("@ZS_DAYS", model.ZS_DAYS),
                                        new SqlParameter("@ZS_JE", model.ZS_JE),
                                        new SqlParameter("@ZS_SFZYFP", model.ZS_SFZYFP),
                                        new SqlParameter("@ZS_FPBHSJE", model.ZS_FPBHSJE),
                                        new SqlParameter("@ZS_BILL", model.ZS_BILL),
                                        new SqlParameter("@BT_DAYS", model.BT_DAYS),
                                        new SqlParameter("@BT_BZ", model.BT_BZ),
                                        new SqlParameter("@BT_JE", model.BT_JE),
                                        new SqlParameter("@QT_ITEM", model.QT_ITEM),
                                        new SqlParameter("@QT_JE", model.QT_JE),
                                        new SqlParameter("@QT_SFZYFP", model.QT_SFZYFP),
                                        new SqlParameter("@QT_FPBHSJE", model.QT_FPBHSJE),
                                        new SqlParameter("@QT_BILL", model.QT_BILL),
                                        new SqlParameter("@QT_CCQLC", model.QT_CCQLC),
                                        new SqlParameter("@QT_CCHLC", model.QT_CCHLC),
                                        new SqlParameter("@QT_CCQJLC", model.QT_CCQJLC),
                                        new SqlParameter("@QT_JDMC", model.QT_JDMC),
                                        new SqlParameter("@QT_JDDZ", model.QT_JDDZ),
                                        new SqlParameter("@QT_JDLXFS", model.QT_JDLXFS),
                                        new SqlParameter("@QT_JDLXR", model.QT_JDLXR),
                                        new SqlParameter("@QT_PP", model.QT_PP),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@CLFMXID", model.CLFMXID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CLFMX> ReadByParam(CRM_COST_CLFMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFMXID", model.CLFMXID),
                                        new SqlParameter("@CLFTTID", model.CLFTTID),
                                        new SqlParameter("@ZS_DAYS", model.ZS_DAYS),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CBZX", model.CBZX),
                                        new SqlParameter("@HJ", model.HJ)
                                        
                                   };
            IList<CRM_COST_CLFMX> nodes = new List<CRM_COST_CLFMX>();
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
        public IList<CRM_COST_CLFMX> ReadPart(CRM_COST_CLFMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFMXID", model.CLFMXID),
                                        new SqlParameter("@CLFTTID", model.CLFTTID),
                                        new SqlParameter("@ZS_DAYS", model.ZS_DAYS),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CBZX", model.CBZX),
                                        new SqlParameter("@HJ", model.HJ)
                                        
                                   };
            IList<CRM_COST_CLFMX> nodes = new List<CRM_COST_CLFMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadPart, parms))
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
        public IList<CRM_COST_CLFMX> ReadByTTID(int CLFTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFTTID", CLFTTID),
                                   };
            IList<CRM_COST_CLFMX> nodes = new List<CRM_COST_CLFMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByTTID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadByTTIDToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int CLFMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFMXID", CLFMXID)
                                       

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


        private CRM_COST_CLFMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CLFMX node = new CRM_COST_CLFMX();
            node.CLFMXID = Convert.ToInt32(sdr["CLFMXID"]);
            node.CLFTTID = Convert.ToInt32(sdr["CLFTTID"]);
            node.BEGINDATE = Convert.ToDateTime(sdr["BEGINDATE"]).ToString("yyyy-MM-dd");
            node.BEGINADDRESS = Convert.ToString(sdr["BEGINADDRESS"]);
            node.ENDDATE = Convert.ToDateTime(sdr["ENDDATE"]).ToString("yyyy-MM-dd");
            node.ENDADDRESS = Convert.ToString(sdr["ENDADDRESS"]);
            node.JT_PLANE = Convert.ToDouble(sdr["JT_PLANE"]);
            node.JT_TRAIN = Convert.ToDouble(sdr["JT_TRAIN"]);
            node.JT_BUS = Convert.ToDouble(sdr["JT_BUS"]);
            node.JT_BILL = Convert.ToInt32(sdr["JT_BILL"]);
            node.ZS_DAYS = Convert.ToDouble(sdr["ZS_DAYS"]);
            node.ZS_JE = Convert.ToDouble(sdr["ZS_JE"]);
            node.ZS_SFZYFP = Convert.ToInt32(sdr["ZS_SFZYFP"]);
            node.ZS_FPBHSJE = Convert.ToDouble(sdr["ZS_FPBHSJE"]);
            node.ZS_BILL = Convert.ToInt32(sdr["ZS_BILL"]);
            node.BT_DAYS = Convert.ToDouble(sdr["BT_DAYS"]);
            node.BT_BZ = Convert.ToDouble(sdr["BT_BZ"]);
            node.BT_JE = Convert.ToDouble(sdr["BT_JE"]);
            node.QT_ITEM = Convert.ToInt32(sdr["QT_ITEM"]);
            node.QT_JE = Convert.ToDouble(sdr["QT_JE"]);
            node.QT_SFZYFP = Convert.ToInt32(sdr["QT_SFZYFP"]);
            node.QT_FPBHSJE = Convert.ToDouble(sdr["QT_FPBHSJE"]);
            node.QT_BILL = Convert.ToInt32(sdr["QT_BILL"]);
            node.QT_CCQLC = Convert.ToString(sdr["QT_CCQLC"]);
            node.QT_CCHLC = Convert.ToString(sdr["QT_CCHLC"]);
            node.QT_CCQJLC = Convert.ToString(sdr["QT_CCQJLC"]);
            node.QT_JDMC = Convert.ToString(sdr["QT_JDMC"]);
            node.QT_JDDZ = Convert.ToString(sdr["QT_JDDZ"]);
            node.QT_JDLXFS = Convert.ToString(sdr["QT_JDLXFS"]);
            node.QT_JDLXR = Convert.ToString(sdr["QT_JDLXR"]);
            node.QT_PP = Convert.ToString(sdr["QT_PP"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.FGLD = Convert.ToInt32(sdr["FGLD"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CBZX = Convert.ToInt32(sdr["CBZX"]);
            node.HJ = Convert.ToDouble(sdr["HJ"]);
            node.COSTITEMMC = Convert.ToString(sdr["COSTITEMMC"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            return node;
        }

        private CRM_COST_CLFMX ReadByTTIDToObj(SqlDataReader sdr)
        {
            CRM_COST_CLFMX node = new CRM_COST_CLFMX();
            node.CLFMXID = Convert.ToInt32(sdr["CLFMXID"]);
            node.CLFTTID = Convert.ToInt32(sdr["CLFTTID"]);
            node.BEGINDATE = Convert.ToDateTime(sdr["BEGINDATE"]).ToString("yyyy-MM-dd ");
            node.BEGINADDRESS = Convert.ToString(sdr["BEGINADDRESS"]);
            node.ENDDATE = Convert.ToDateTime(sdr["ENDDATE"]).ToString("yyyy-MM-dd");
            node.ENDADDRESS = Convert.ToString(sdr["ENDADDRESS"]);
            node.JT_PLANE = Convert.ToDouble(sdr["JT_PLANE"]);
            node.JT_TRAIN = Convert.ToDouble(sdr["JT_TRAIN"]);
            node.JT_BUS = Convert.ToDouble(sdr["JT_BUS"]);
            node.JT_BILL = Convert.ToInt32(sdr["JT_BILL"]);
            node.ZS_DAYS = Convert.ToDouble(sdr["ZS_DAYS"]);
            node.ZS_JE = Convert.ToDouble(sdr["ZS_JE"]);
            node.ZS_SFZYFP = Convert.ToInt32(sdr["ZS_SFZYFP"]);
            node.ZS_FPBHSJE = Convert.ToDouble(sdr["ZS_FPBHSJE"]);
            node.ZS_BILL = Convert.ToInt32(sdr["ZS_BILL"]);
            node.BT_DAYS = Convert.ToDouble(sdr["BT_DAYS"]);
            node.BT_BZ = Convert.ToDouble(sdr["BT_BZ"]);
            node.BT_JE = Convert.ToDouble(sdr["BT_JE"]);
            node.QT_ITEM = Convert.ToInt32(sdr["QT_ITEM"]);
            node.QT_JE = Convert.ToDouble(sdr["QT_JE"]);
            node.QT_SFZYFP = Convert.ToInt32(sdr["QT_SFZYFP"]);
            node.QT_FPBHSJE = Convert.ToDouble(sdr["QT_FPBHSJE"]);
            node.QT_BILL = Convert.ToInt32(sdr["QT_BILL"]);
            node.QT_CCQLC = Convert.ToString(sdr["QT_CCQLC"]);
            node.QT_CCHLC = Convert.ToString(sdr["QT_CCHLC"]);
            node.QT_CCQJLC = Convert.ToString(sdr["QT_CCQJLC"]);
            node.QT_JDMC = Convert.ToString(sdr["QT_JDMC"]);
            node.QT_JDDZ = Convert.ToString(sdr["QT_JDDZ"]);
            node.QT_JDLXFS = Convert.ToString(sdr["QT_JDLXFS"]);
            node.QT_JDLXR = Convert.ToString(sdr["QT_JDLXR"]);
            node.QT_PP = Convert.ToString(sdr["QT_PP"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.COSTITEMMC = Convert.ToString(sdr["COSTITEMMC"]);
            return node;
        }
    }
}
