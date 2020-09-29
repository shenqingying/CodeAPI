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
    public class ConsignmentNoteItem : IConsignmentNoteItem
    {
        private const string SQL_INSERT = "LE_TRA_ConsignmentNote_Item_Insert";
        private const string SQL_READ = "SELECT * FROM SP_TYDMX WHERE TYDID = @ID";

        public bool Create(CNItemInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@TYDMXID", node.ID),
                new SqlParameter("@TYDID", node.Header),
                new SqlParameter("@LBID", node.GoodsType.TypeID),
                new SqlParameter("@LBMC", node.GoodsType.Type),
                new SqlParameter("@XSID", node.PackageType.TypeID),
                new SqlParameter("@XSMC", node.PackageType.Type),
                new SqlParameter("@ZJS", node.Whole),
                new SqlParameter("@LTJ", node.Odd),
                new SqlParameter("@ZS", node.Total),
                new SqlParameter("@ZL", node.Weight),
                new SqlParameter("@TJ", node.Volume),
                new SqlParameter("@JFZL", node.Weight),
                new SqlParameter("@JFDJ", node.UnitPrice),
                new SqlParameter("@DJID", 0),
                new SqlParameter("@DJMC",""),
                new SqlParameter("@YF", node.Cost),
                new SqlParameter("@BJJE", node.UnitInsurance),
                new SqlParameter("@BJF", node.Insurance),
                new SqlParameter("@ZSF", node.DirectCost),
                new SqlParameter("@ZZF", node.TransitCost),
                new SqlParameter("@QTF", node.OtherCost),
                new SqlParameter("@YFXJ", node.TotalCost)};
            bool success = false;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    success = true;
                }
            }
            catch (Exception e )
            {
                throw new ApplicationException(e.Message);
            }

            return success;
        }

        public IList<CNItemInfo> Read(int headerID)
        {
            SqlParameter[] parms = { new SqlParameter("@ID", headerID) };

            IList<CNItemInfo> nodes = new List<CNItemInfo>();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_READ, parms))
                {
                    while (sdr.Read())
                    {
                        CNItemInfo node = new CNItemInfo();
                        node.ID = Convert.ToInt32(sdr["TYDMXID"]);
                        node.Header = Convert.ToInt32(sdr["TYDID"]);
                        node.GoodsType = new GoodsInfo();
                        node.GoodsType.TypeID = Convert.ToInt32(sdr["LBID"]);
                        node.GoodsType.Type = Convert.ToString(sdr["LBMC"]);
                        node.PackageType = new PackageInfo();
                        node.PackageType.TypeID = Convert.ToInt32(sdr["XSID"]);
                        node.PackageType.Type = Convert.ToString(sdr["XSMC"]);
                        node.Whole = Convert.ToInt32(sdr["ZJS"]);
                        node.Odd = Convert.ToInt32(sdr["LTJ"]);
                        node.Total = Convert.ToInt32(sdr["ZS"]);
                        node.Weight = Convert.ToDecimal(sdr["ZL"]);
                        node.Volume = Convert.ToDecimal(sdr["TJ"]);
                        node.Weight = Convert.ToDecimal(sdr["JFZL"]);
                        node.UnitPrice = Convert.ToDecimal(sdr["JFDJ"]);
                        //DJID
                        //DJMC
                        node.Cost = Convert.ToDecimal(sdr["YF"]);
                        node.UnitInsurance = Convert.ToDecimal(sdr["BJJE"]);
                        node.Insurance = Convert.ToDecimal(sdr["BJF"]);
                        node.DirectCost = Convert.ToDecimal(sdr["ZSF"]);
                        node.TransitCost = Convert.ToDecimal(sdr["ZZF"]);
                        node.OtherCost = Convert.ToDecimal(sdr["QTF"]);
                        node.TotalCost = Convert.ToDecimal(sdr["YFXJ"]);
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

        public bool Delete(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
