using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.LE.TRA
{
    public class FeedbackItem : IFeedbackItem
    {
        private const string SQL_EXISTS = "SELECT HDQRID FROM SP_HDQRMX WHERE TYDID = @CNID";
        private const string SQL_INSERT = "LE_TRA_Feedback_Item_Insert";
        private const string SQL_SELECT = "SELECT * FROM SP_HDQRMX WHERE HDQRID = @ID";
        private const string SQL_DELETE = "DELETE FROM SP_HDQRMX WHERE HDQRID = @ID";

        public List<FeedbackItemInfo> Read(int headerID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@ID", headerID)};

            List<FeedbackItemInfo> nodes = new List<FeedbackItemInfo>();
  
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {

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

                        nodes.Add(item);

                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public int Exists(int consignmentNote)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@CNID", consignmentNote)};

            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_EXISTS, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["HDQRID"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return ID;
        }

        public int Create(FeedbackItemInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@HDQRID",node.HeaderID),
                new SqlParameter("@TYDID",node.ConsignmentNote),
                new SqlParameter("@FHRQ",node.DepartureDate),
                new SqlParameter("@DZ",node.Destination),
                new SqlParameter("@PM",node.GoodsType),
                new SqlParameter("@JS",node.WholeQty),
                new SqlParameter("@ZL",node.Weight),
                new SqlParameter("@TJ",node.Volume),
                new SqlParameter("@JFZL",node.ChargedWeight),
                new SqlParameter("@DJ", node.UnitPrice),
                new SqlParameter("@YF",node.Cost),
                new SqlParameter("@ZSF",node.DirectCost),
                new SqlParameter("@ZXF",node.HandlingCost),
                new SqlParameter("@QTF",node.OtherCost),
                new SqlParameter("@FYXJ",node.TotalCost),
                new SqlParameter("@SJZF",node.Payment),
                new SqlParameter("@QR",node.Confirmed),
                new SqlParameter("@ZF",node.Normal),
                new SqlParameter("@BZ",node.Remark )};

            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    ID = 1;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return ID;
        }

        public int Update(int ID)
        {
            throw new NotImplementedException();
        }

        public int Delete(int headerID)
        {
            SqlParameter[] parms = { new SqlParameter("@ID",headerID)};

            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms))
                {
                    ID = headerID;
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
