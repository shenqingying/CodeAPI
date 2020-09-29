using Sonluk.Entities.LE;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE.TRA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.LE.TRA
{
    public class Feedback : IFeedback
    {
        private const string SQL_SELECT_SET = "LE_TRA_Feedback_Select";
        private const string SQL_SELECT_SINGLE = "SELECT * FROM SP_HDQR WHERE HDQRID = @ID";
        private const string SQL_REPORT = "LE_TRA_Feedback_Report";
        private const string SQL_INSERT = "LE_TRA_Feedback_Insert";
        private const string SQL_UPDATE = "LE_TRA_Feedback_Update";

        
        public IList<FeedbackInfo> Read(FeedbackInfo keywords)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@GSID", keywords.Carrier.ID),
                new SqlParameter("@DZ", keywords.Destination),
                new SqlParameter("@TYDID", keywords.ConsignmentNote),
                new SqlParameter("@FHRQ_LEFT", keywords.DepartureDate),
                new SqlParameter("@FHRQ_RIGHT", keywords.DepartureDateEnd),
                new SqlParameter("@HDRQ_LEFT", keywords.Date),
                new SqlParameter("@HDRQ_RIGHT", keywords.DateEnd),
                new SqlParameter("@HDMEMO", keywords.Remark),
                new SqlParameter("@BZ", keywords.ItemRemark)};

            IList<FeedbackInfo> nodes = new List<FeedbackInfo>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_SET, parms))
                {
                    while (sdr.Read())
                    {
                        FeedbackInfo node = new FeedbackInfo();
                        node.ID = Convert.ToInt32(sdr["HDQRID"]);
                        node.Carrier = new CompanyInfo();
                        node.Carrier.ID = Convert.ToInt32(sdr["GSID"]);
                        node.Carrier.ShortName = Convert.ToString(sdr["GSJC"]);
                        node.Date = (Convert.ToDateTime(sdr["HDRQ"])).ToString("yyyy-MM-dd");
                        node.Payment = Convert.ToDecimal(sdr["FKJE"]);
                        node.Remark = Convert.ToString(sdr["HDMEMO"]);
                        node.Status = Convert.ToInt16(sdr["HDZT"]);
                        node.CreatorID = Convert.ToInt32(sdr["fillID"]);
                        node.Creator = Convert.ToString(sdr["fillName"]);
                        node.CreateDate = (Convert.ToDateTime(sdr["fillTime"])).ToString("yyyy-MM-dd HH:mm:ss");
                        nodes.Add(node);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public FeedbackInfo Read(int ID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@ID", ID)};

            FeedbackInfo node = new FeedbackInfo();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SINGLE, parms))
                {
                    if (sdr.Read())
                    {
                        node.ID = Convert.ToInt32(sdr["HDQRID"]);
                        node.Carrier = new CompanyInfo();
                        node.Carrier.ID = Convert.ToInt32(sdr["GSID"]);
                        node.Carrier.ShortName = Convert.ToString(sdr["GSJC"]);
                        node.Date = (Convert.ToDateTime(sdr["HDRQ"])).ToString("yyyy-MM-dd");
                        node.Payment = Convert.ToDecimal(sdr["FKJE"]);
                        node.Remark = Convert.ToString(sdr["HDMEMO"]);
                        node.Status = Convert.ToInt16(sdr["HDZT"]);
                        node.CreatorID = Convert.ToInt32(sdr["fillID"]);
                        node.Creator = Convert.ToString(sdr["fillName"]);
                        node.CreateDate = (Convert.ToDateTime(sdr["fillTime"])).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public int Create(FeedbackInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@GSID", node.Carrier.ID),
                new SqlParameter("@GSJC", node.Carrier.ShortName),
                new SqlParameter("@HDRQ", node.Date),
                new SqlParameter("@FKJE", node.Payment),
                new SqlParameter("@HDMEMO", node.Remark),
                new SqlParameter("@HDZT", node.Status),
                new SqlParameter("@fillID", node.CreatorID),
                new SqlParameter("@fillName", node.Creator)};

            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
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

        public int Update(FeedbackInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@HDQRID", node.ID),
                new SqlParameter("@GSID", node.Carrier.ID),
                new SqlParameter("@GSJC", node.Carrier.ShortName),
                new SqlParameter("@HDRQ", node.Date),
                new SqlParameter("@FKJE", node.Payment),
                new SqlParameter("@HDMEMO", node.Remark),
                new SqlParameter("@HDZT", node.Status),
                new SqlParameter("@fillID", node.CreatorID),
                new SqlParameter("@fillName", node.Creator)};

            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
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

        public int Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IList<FeedbackInfo> Report(FeedbackInfo keywords)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@GSID", keywords.Carrier.ID),
                new SqlParameter("@DZ", keywords.Destination),
                new SqlParameter("@TYDID", keywords.ConsignmentNote),
                new SqlParameter("@FHRQ_LEFT", keywords.DepartureDate),
                new SqlParameter("@FHRQ_RIGHT", keywords.DepartureDateEnd),
                new SqlParameter("@HDRQ_LEFT", keywords.Date),
                new SqlParameter("@HDRQ_RIGHT", keywords.DateEnd),
                new SqlParameter("@HDMEMO", keywords.Remark),
                new SqlParameter("@BZ", keywords.ItemRemark)};

            Logger.Write("Sonluk.DataAccess.LE.TRA.Complaint", keywords.ConsignmentNote.ToString());

            IList<FeedbackInfo> nodes = new List<FeedbackInfo>();
            int ID = -1;
            int index = -1;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_REPORT, parms))
                {
                    FeedbackInfo node;
                    while (sdr.Read())
                    {
                        if (Convert.ToInt32(sdr["HDQRID"]) != ID)
                        {
                            node = new FeedbackInfo();
                            node.ID = Convert.ToInt32(sdr["HDQRID"]);
                            node.Carrier = new CompanyInfo();
                            node.Carrier.ID = Convert.ToInt32(sdr["GSID"]);
                            node.Carrier.ShortName = Convert.ToString(sdr["GSJC"]);
                            node.Date = (Convert.ToDateTime(sdr["HDRQ"])).ToString("yyyy-MM-dd");
                            node.Payment = Convert.ToDecimal(sdr["FKJE"]);
                            node.Remark = Convert.ToString(sdr["HDMEMO"]);
                            node.Status = Convert.ToInt16(sdr["HDZT"]);
                            node.CreatorID = Convert.ToInt32(sdr["HDZT"]);
                            node.Creator = Convert.ToString(sdr["fillName"]);
                            node.CreateDate = (Convert.ToDateTime(sdr["fillTime"])).ToString("yyyy-MM-dd HH:mm:ss");
                            node.Items = new List<FeedbackItemInfo>();
                            ID = node.ID;

                            nodes.Add(node);
                            index++;
                        }

                        FeedbackItemInfo item = new FeedbackItemInfo();

                        item.HeaderID = Convert.ToInt32(sdr["HDQRID"]);
                        item.ConsignmentNote = Convert.ToInt32(sdr["TYDID"]);
                        item.DepartureDate = (Convert.ToDateTime(sdr["FHRQ"])).ToString("yyyy-MM-dd");
                        item.Destination = Convert.ToString(sdr["DZ"]);
                        item.GoodsType = Convert.ToString(sdr["PM"]);
                        item.WholeQty = Convert.ToInt32(sdr["JS"]);
                        item.Weight = Convert.ToDecimal(sdr["ZL"]);
                        item.Volume = Convert.ToDecimal(sdr["TJ"]);
                        item.ChargedWeight = Convert.ToDecimal(sdr["JFZL"]);
                        item.UnitPrice = Convert.ToDecimal(sdr["DJ"]);
                        item.Cost = Convert.ToDecimal(sdr["YF"]);
                        item.DirectCost = Convert.ToDecimal(sdr["ZSF"]);
                        item.HandlingCost = Convert.ToDecimal(sdr["ZXF"]);
                        item.OtherCost = Convert.ToDecimal(sdr["QTF"]);
                        item.TotalCost = Convert.ToDecimal(sdr["FYXJ"]);
                        item.Payment = Convert.ToDecimal(sdr["SJZF"]);
                        item.Confirmed = Convert.ToBoolean(sdr["QR"]);
                        item.Normal = Convert.ToBoolean(sdr["ZF"]);
                        item.Remark = Convert.ToString(sdr["BZ"]);

                        nodes[index].Items.Add(item);

                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }





    }
}
