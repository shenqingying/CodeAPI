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
    public class Complaint : IComplaint
    {
        private const string SQL_READ_SINGLE = "SELECT * FROM SP_YCDJ WHERE YCDJID=@ID";
        private const string SQL_READ_SET = "LE_TRA_Complaint_Select";
        private const string SQL_INSERT = "LE_TRA_Complaint_Insert";
        private const string SQL_UPDATE = "LE_TRA_Complaint_Update";
        private const string SQL_REPORT = "LE_TRA_Complaint_Report";

        public IList<ComplaintInfo> Read(ComplaintInfo keywords)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@GSID", keywords.Carrier.ID),
                new SqlParameter("@TSFS", keywords.TypeID),
                new SqlParameter("@TYDID", keywords.ConsignmentNote),
                new SqlParameter("@THRQ_LEFT", keywords.ReturnDate),
                new SqlParameter("@THRQ_RIGHT", keywords.ReturnDateEnd),
                new SqlParameter("@YDRQ_LEFT", keywords.AppointedDeliveryDate),
                new SqlParameter("@YDRQ_RIGHT", keywords.AppointedDeliveryDateEnd),
                new SqlParameter("@LXHBH", keywords.ContactLetter),
                new SqlParameter("@VBELN", keywords.Delivery),
                new SqlParameter("@WLBH", keywords.Material),
                new SqlParameter("@WLMS", keywords.MaterialDescription),
                new SqlParameter("@CLWC", keywords.Status)};

            IList<ComplaintInfo> nodes = new List<ComplaintInfo>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_READ_SET, parms))
                {
                    while (sdr.Read())
                    {
                        
                        ComplaintInfo node = new ComplaintInfo();
                        node.ID = Convert.ToInt32(sdr["YCDJID"]);
                        node.Carrier = new CompanyInfo();
                        node.Carrier.ID = Convert.ToInt32(sdr["GSID"]);
                        node.Carrier.ShortName = Convert.ToString(sdr["GSJC"]);
                        node.ConsignmentNote = Convert.ToInt32(sdr["TYDID"]);
                        node.ContactLetter = Convert.ToString(sdr["LXHBH"]);
                        node.Receiver = new CompanyInfo();
                        node.Receiver.ID = Convert.ToInt32(sdr["SHRID"]);
                        node.Receiver.ShortName = Convert.ToString(sdr["SHRJC"]);
                        node.ReturnDate = (Convert.ToDateTime(sdr["THRQ"])).ToString("yyyy-MM-dd");
                        node.AppointedDeliveryDate = (Convert.ToDateTime(sdr["YDRQ"])).ToString("yyyy-MM-dd");
                        node.DeliveryDate = (Convert.ToDateTime(sdr["SDRQ"])).ToString("yyyy-MM-dd");
                        node.DelayDays = Convert.ToInt32(sdr["CDTS"]);
                        node.TypeID = Convert.ToInt32(sdr["TSFS"]);
                        node.Type = Convert.ToString(sdr["TSFSMC"]);
                        node.PackageDamage = Convert.ToBoolean(sdr["BZPS"]);
                        node.PackagePollution = Convert.ToBoolean(sdr["BZWR"]);
                        node.GoodsGetWet = Convert.ToBoolean(sdr["HWLS"]);
                        node.GoodsDamage = Convert.ToBoolean(sdr["WLSH"]);
                        node.GoodsShortage = Convert.ToBoolean(sdr["WLDQ"]);
                        node.DamageValue = Convert.ToDecimal(sdr["SHJE"]);
                        node.ReworkValue = Convert.ToDecimal(sdr["CGF"]);
                        node.Compensation = Convert.ToDecimal(sdr["PCHJ"]);
                        node.Compensable = Convert.ToBoolean(sdr["XYPC"]);
                        node.Completed = Convert.ToBoolean(sdr["CLWC"]);
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

        public ComplaintInfo Read(int ID)
        {
            SqlParameter[] parms = { new SqlParameter("@ID", ID) };

            ComplaintInfo node = new ComplaintInfo();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_READ_SINGLE, parms))
                {
                    if (sdr.Read())
                    {
                        node.ID = Convert.ToInt32(sdr["YCDJID"]);
                        node.Carrier = new CompanyInfo();
                        node.Carrier.ID = Convert.ToInt32(sdr["GSID"]);
                        node.Carrier.ShortName = Convert.ToString(sdr["GSJC"]);
                        node.ConsignmentNote = Convert.ToInt32(sdr["TYDID"]);
                        node.ContactLetter = Convert.ToString(sdr["LXHBH"]);
                        node.Receiver = new CompanyInfo();
                        node.Receiver.ID = Convert.ToInt32(sdr["SHRID"]);
                        node.Receiver.ShortName = Convert.ToString(sdr["SHRJC"]);
                        node.ReturnDate = (Convert.ToDateTime(sdr["THRQ"])).ToString("yyyy-MM-dd");
                        node.AppointedDeliveryDate = (Convert.ToDateTime(sdr["YDRQ"])).ToString("yyyy-MM-dd");
                        node.DeliveryDate = (Convert.ToDateTime(sdr["SDRQ"])).ToString("yyyy-MM-dd");
                        node.DelayDays = Convert.ToInt32(sdr["CDTS"]);
                        node.TypeID = Convert.ToInt32(sdr["TSFS"]);
                        node.Type = Convert.ToString(sdr["TSFSMC"]);
                        node.PackageDamage = Convert.ToBoolean(sdr["BZPS"]);
                        node.PackagePollution = Convert.ToBoolean(sdr["BZWR"]);
                        node.GoodsGetWet = Convert.ToBoolean(sdr["HWLS"]);
                        node.GoodsDamage = Convert.ToBoolean(sdr["WLSH"]);
                        node.GoodsShortage = Convert.ToBoolean(sdr["WLDQ"]);
                        node.DamageValue = Convert.ToDecimal(sdr["SHJE"]);
                        node.ReworkValue = Convert.ToDecimal(sdr["CGF"]);
                        node.Compensation = Convert.ToDecimal(sdr["PCHJ"]);
                        node.Compensable = Convert.ToBoolean(sdr["XYPC"]);
                        node.Completed = Convert.ToBoolean(sdr["CLWC"]);
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

        public int Create(ComplaintInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@GSID", node.Carrier.ID),
                new SqlParameter("@GSJC", node.Carrier.ShortName),
                new SqlParameter("@TYDID", node.ConsignmentNote),
                new SqlParameter("@TSFSMC", node.Type),
                new SqlParameter("@TSFS", node.TypeID), 
                new SqlParameter("@SHRID", node.Receiver.ID), 
                new SqlParameter("@SHRJC", node.Receiver.ShortName), 
                new SqlParameter("@THRQ", node.ReturnDate),
                new SqlParameter("@LXHBH", node.ContactLetter),
                new SqlParameter("@YDRQ", node.AppointedDeliveryDate), 
                new SqlParameter("@SDRQ", node.DeliveryDate),
                new SqlParameter("@CDTS",node.DelayDays),
                new SqlParameter("@HWLS", node.GoodsGetWet),
                new SqlParameter("@BZPS", node.PackageDamage),
                new SqlParameter("@BZWR", node.PackagePollution), 
                new SqlParameter("@WLSH",  node.GoodsDamage), 
                new SqlParameter("@WLDQ", node.GoodsShortage),
                new SqlParameter("@SHJE", node.DamageValue),
                new SqlParameter("@CGF", node.ReworkValue),
                new SqlParameter("@XYPC", node.Compensable),
                new SqlParameter("@PCHJ", node.Compensation),
                new SqlParameter("@CLWC", node.Completed),
                new SqlParameter("@fillID", 0),
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

        public int Update(ComplaintInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@YCDJID", node.ID),
                new SqlParameter("@GSID", node.Carrier.ID),
                new SqlParameter("@GSJC", node.Carrier.ShortName),
                new SqlParameter("@TYDID", node.ConsignmentNote),
                new SqlParameter("@TSFSMC", node.Type),
                new SqlParameter("@TSFS", node.TypeID), 
                new SqlParameter("@SHRID", node.Receiver.ID), 
                new SqlParameter("@SHRJC", node.Receiver.ShortName), 
                new SqlParameter("@THRQ", node.ReturnDate),
                new SqlParameter("@LXHBH", node.ContactLetter),
                new SqlParameter("@YDRQ", node.AppointedDeliveryDate), 
                new SqlParameter("@SDRQ", node.DeliveryDate),
                new SqlParameter("@CDTS",node.DelayDays),
                new SqlParameter("@HWLS", node.GoodsGetWet),
                new SqlParameter("@BZPS", node.PackageDamage),
                new SqlParameter("@BZWR", node.PackagePollution), 
                new SqlParameter("@WLSH",  node.GoodsDamage), 
                new SqlParameter("@WLDQ", node.GoodsShortage),
                new SqlParameter("@SHJE", node.DamageValue),
                new SqlParameter("@CGF", node.ReworkValue),
                new SqlParameter("@XYPC", node.Compensable),
                new SqlParameter("@PCHJ", node.Compensation),
                new SqlParameter("@CLWC", node.Completed)};

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

        public IList<ComplaintInfo> Report(ComplaintInfo keywords)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@GSID", keywords.Carrier.ID),
                new SqlParameter("@TSFS", keywords.TypeID),
                new SqlParameter("@TYDID", keywords.ConsignmentNote),
                new SqlParameter("@THRQ_LEFT", keywords.ReturnDate),
                new SqlParameter("@THRQ_RIGHT", keywords.ReturnDateEnd),
                new SqlParameter("@YDRQ_LEFT", keywords.AppointedDeliveryDate),
                new SqlParameter("@YDRQ_RIGHT", keywords.AppointedDeliveryDateEnd),
                new SqlParameter("@LXHBH", keywords.ContactLetter),
                new SqlParameter("@VBELN", keywords.Delivery),
                new SqlParameter("@WLBH", keywords.Material),
                new SqlParameter("@WLMS", keywords.MaterialDescription),
                new SqlParameter("@CLWC", keywords.Status)};

            IList<ComplaintInfo> nodes = new List<ComplaintInfo>();
            int ID = -1;
            int index = -1;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_REPORT, parms))
                {
                    ComplaintInfo node;
                    while (sdr.Read())
                    {
                        if (Convert.ToInt32(sdr["YCDJID"]) != ID)
                        {
                            node = new ComplaintInfo();
                            node.ID = Convert.ToInt32(sdr["YCDJID"]);
                            node.Carrier = new CompanyInfo();
                            node.Carrier.ID = Convert.ToInt32(sdr["GSID"]);
                            node.Carrier.ShortName = Convert.ToString(sdr["GSJC"]);
                            node.ConsignmentNote = Convert.ToInt32(sdr["TYDID"]);
                            node.ContactLetter = Convert.ToString(sdr["LXHBH"]);
                            node.Receiver = new CompanyInfo();
                            node.Receiver.ID = Convert.ToInt32(sdr["SHRID"]);
                            node.Receiver.ShortName = Convert.ToString(sdr["SHRJC"]);
                            node.ReturnDate = (Convert.ToDateTime(sdr["THRQ"])).ToString("yyyy-MM-dd");
                            node.AppointedDeliveryDate = (Convert.ToDateTime(sdr["YDRQ"])).ToString("yyyy-MM-dd");
                            node.DeliveryDate = (Convert.ToDateTime(sdr["SDRQ"])).ToString("yyyy-MM-dd");
                            node.DelayDays = Convert.ToInt32(sdr["CDTS"]);
                            node.TypeID = Convert.ToInt32(sdr["TSFS"]);
                            node.Type = Convert.ToString(sdr["TSFSMC"]);
                            node.PackageDamage = Convert.ToBoolean(sdr["BZPS"]);
                            node.PackagePollution = Convert.ToBoolean(sdr["BZWR"]);
                            node.GoodsGetWet = Convert.ToBoolean(sdr["HWLS"]);
                            node.GoodsDamage = Convert.ToBoolean(sdr["WLSH"]);
                            node.GoodsShortage = Convert.ToBoolean(sdr["WLDQ"]);
                            node.DamageValue = Convert.ToDecimal(sdr["SHJE"]);
                            node.ReworkValue = Convert.ToDecimal(sdr["CGF"]);
                            node.Compensation = Convert.ToDecimal(sdr["PCHJ"]);
                            node.Compensable = Convert.ToBoolean(sdr["XYPC"]);
                            node.Completed = Convert.ToBoolean(sdr["CLWC"]);
                            node.CreatorID = Convert.ToInt32(sdr["fillID"]);
                            node.Creator = Convert.ToString(sdr["fillName"]);
                            node.CreateDate = (Convert.ToDateTime(sdr["fillTime"])).ToString("yyyy-MM-dd HH:mm:ss");
                            node.Items = new List<ComplaintItemInfo>();
                            ID = node.ID;

                            nodes.Add(node);
                            index++;
                        }

                        ComplaintItemInfo item = new ComplaintItemInfo();

                        item.ID = Convert.ToInt32(sdr["YCQDID"]);
                        item.HeaderID = Convert.ToInt32(sdr["YCDJID"]);
                        item.Delivery = Convert.ToString(sdr["VBELN"]);
                        item.Material = Convert.ToString(sdr["WLBH"]);
                        item.MaterialDescription = Convert.ToString(sdr["WLMS"]);
                        item.ReturnWholeQty = Convert.ToInt32(sdr["THJS"]);
                        item.ReturnQty = Convert.ToDecimal(sdr["THSL"]);
                        item.ReturnReason = Convert.ToString(sdr["THYYMC"]);
                        item.UnitValue = Convert.ToDecimal(sdr["DJ"]);
                        item.DamageQty = Convert.ToDecimal(sdr["SHSL"]);
                        item.DamageValue = Convert.ToDecimal(sdr["SHJE"]);
                        item.ReworkValue = Convert.ToDecimal(sdr["CGF"]);
                        item.Sales = Convert.ToString(sdr["YWY"]);
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
