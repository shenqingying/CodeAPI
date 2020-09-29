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
    public class ConsignmentNote : IConsignmentNote
    {

        private const string SQL_EXISTS_ID = "SELECT TYDID FROM SP_TYD  WHERE TYDID=@ID";
        private const string SQL_EXISTS = "SELECT A.TYDID,B.TYDZT FROM SP_TYJHD A,SP_TYD B WHERE A.TYDID=B.TYDID AND VBELN=@SerialNumber AND B.TYDZT<>@Status";
        private const string SQL_RECORD = "INSERT INTO SP_TYJHD(VBELN,TYDID,STATUS) VALUES(@SerialNumber,@ID,0)";
        private const string SQL_JHDUPDATE = "UPDATE SP_TYJHD SET [STATUS]=@STATUS,FILLNAME=@FILLNAME,FILLID=@FILLID,FILLTIME=getdate() WHERE VBELN=@VBELN";
        private const string SQL_CNDeliveryUPDATE = "LE_TRA_CNDelivery_Update";
        private const string SQL_READ_CNDeliveryBYTydid = "SELECT * FROM SP_TYJHD WHERE TYDID = @ID";
        private const string SQL_READ_CNDeliveryBYVbeln = "SELECT * FROM SP_TYJHD WHERE TYDID IN (SELECT TYDID FROM SP_TYJHD A where A.VBELN = @VBELN)";
        private const string SQL_MAX_ID = "SELECT MAX(TYDID)+1 ID FROM SP_TYD";
        private const string SQL_READ_SET = "LE_TRA_ConsignmentNote_Select";
        private const string SQL_READ_SINGLE = "SELECT * FROM SP_TYD WHERE TYDID = @ID";
        private const string SQL_REPORT = "LE_TRA_ConsignmentNote_Report";
        private const string SQL_CURRENT_NUMBER = "SELECT TOP 1 DH FROM SP_TYD WHERE GSID=@ID ORDER BY TYDID DESC";
        private const string SQL_INSERT = "LE_TRA_ConsignmentNote_Insert";
        private const string SQL_UPDATE = "LE_TRA_ConsignmentNote_Update";
        private const string SQL_DELETE = "UPDATE SP_TYD SET TYDZT=3 WHERE TYDID=@ID";

        public int Exists(int ID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@ID", ID)};
            ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_EXISTS_ID, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["TYDID"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return ID;
        }

        public int Exists(string serialNumber, int status)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@SerialNumber", serialNumber),
                new SqlParameter("@Status",status)};

            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_EXISTS, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["TYDID"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return ID;
        }

        public int Record(string serialNumber, int ID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@SerialNumber", serialNumber),
                new SqlParameter("@ID",ID)};

            int success = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_RECORD, parms))
                {
                    if (sdr.Read())
                    {
                        success = ID;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return success;
        }

        public bool JHDUPDATE(string serialNumber, int TYDID, int STATUS, string FILLNAME, string FILLID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@VBELN", serialNumber),
                new SqlParameter("@TYDID", TYDID),
                new SqlParameter("@STATUS",STATUS),
                new SqlParameter("@FILLNAME", FILLNAME),
                new SqlParameter("@FILLID", FILLID)
            };

            bool success = false;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_CNDeliveryUPDATE, parms))
                {
                    success = true;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return success;

        }

        public IList<CNInfo> Read(CNInfo keywords)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@TYDID",keywords.ID),
                new SqlParameter("@GSID", keywords.Carrier.ID),
                new SqlParameter("@DZDID", keywords.Destination.ID),
                new SqlParameter("@SN",keywords.SerialNumber),
                new SqlParameter("@DH",keywords.Number),
                new SqlParameter("@TYRQ_LEFT",keywords.Date),
                new SqlParameter("@TYRQ_RIGHT",keywords.DateEnd),
                new SqlParameter("@BDRQ_LEFT",keywords.DeliveryDate),
                new SqlParameter("@BDRQ_RIGHT",keywords.DeliveryDateEnd),
                new SqlParameter("@SAPDN",keywords.Delivery),
                new SqlParameter("@SHRDW",keywords.Receiver.Name),
                new SqlParameter("@SLXR",keywords.Receiver.Contact),
                new SqlParameter("@SSJ",keywords.Receiver.Cellphone),
                new SqlParameter("@SLXDH",keywords.Receiver.Telephone),
                new SqlParameter("@SHRDZ",keywords.Receiver.Address),
                new SqlParameter("@TBSM",keywords.Instruction),
                new SqlParameter("@BZ",keywords.Remark),
                new SqlParameter("@TYDZT",keywords.Status),
                new SqlParameter("@TYLB",keywords.TYLB),
                new SqlParameter("@FKLB",keywords.FKLB)};

            IList<CNInfo> nodes = new List<CNInfo>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_READ_SET, parms))
                {
                    while (sdr.Read())
                    {
                        CNInfo node = new CNInfo();
                        node.ID = Convert.ToInt32(sdr["TYDID"]);
                        node.Carrier = new CompanyInfo();
                        node.Carrier.ID = Convert.ToInt32(sdr["GSID"]);
                        node.Carrier.ShortName = Convert.ToString(sdr["GSJC"]);
                        node.Carrier.Name = Convert.ToString(sdr["GSMC"]);
                        node.SAP = Convert.ToBoolean(sdr["isSAP"]);
                        node.Date = (Convert.ToDateTime(sdr["TYRQ"])).ToString("yyyy-MM-dd");
                        node.SerialNumber = Convert.ToString(sdr["SN"]);
                        node.Number = Convert.ToString(sdr["DH"]);
                        node.Total = Convert.ToInt32(sdr["TYDH"]);
                        node.Source = new CityInfo();
                        node.Source.ID = Convert.ToInt32(sdr["FZDID"]);
                        node.Source.Name = Convert.ToString(sdr["FZDMC"]);
                        node.Destination = new CityInfo();
                        node.Destination.ID = Convert.ToInt32(sdr["DZDID"]);
                        node.Destination.Name = Convert.ToString(sdr["DZDMC"]);
                        node.Sender = new CompanyInfo();
                        node.Sender.ID = Convert.ToInt32(sdr["TYRID"]);
                        node.Sender.ShortName = Convert.ToString(sdr["TYRJC"]);
                        node.Sender.Name = Convert.ToString(sdr["TYRDW"]);
                        node.Sender.Address = Convert.ToString(sdr["TYRDZ"]);
                        node.Sender.Contact = Convert.ToString(sdr["LXR"]);
                        node.Sender.Telephone = Convert.ToString(sdr["LXDH"]);
                        node.Sender.Cellphone = Convert.ToString(sdr["SJ"]);
                        node.Receiver = new CompanyInfo();
                        node.Receiver.ID = Convert.ToInt32(sdr["SHRID"]);
                        node.Receiver.ShortName = Convert.ToString(sdr["SHRJC"]);
                        node.Receiver.Name = Convert.ToString(sdr["SHRDW"]);
                        node.Receiver.Address = Convert.ToString(sdr["SHRDZ"]);
                        node.Receiver.Contact = Convert.ToString(sdr["SLXR"]);
                        node.Receiver.Telephone = Convert.ToString(sdr["SLXDH"]);
                        node.Receiver.Cellphone = Convert.ToString(sdr["SSJ"]);
                        node.Weight = Convert.ToDecimal(sdr["JFZL"]);
                        node.Volume = Convert.ToDecimal(sdr["TJ"]); //Add by xsw
                        node.UnitPrice = Convert.ToDecimal(sdr["JFDJ"]);
                        node.Cost = Convert.ToDecimal(sdr["YF"]);
                        node.Insurance = Convert.ToDecimal(sdr["BXF"]);
                        node.DirectCost = Convert.ToDecimal(sdr["ZSF"]);
                        node.TransitCost = Convert.ToDecimal(sdr["ZZF"]);
                        node.OtherCost = Convert.ToDecimal(sdr["QTF"]);
                        node.TotalCost = Convert.ToDecimal(sdr["HJ"]);
                        node.Compensation = Convert.ToInt32(sdr["PCBS"]);
                        node.DefaultArrivalLimit = Convert.ToInt32(sdr["WDTZ"]);
                        node.DeliveryCount = Convert.ToInt32(sdr["SHD"]);
                        node.InvoiceCount = Convert.ToInt32(sdr["FP"]);
                        node.CertificationCount = Convert.ToInt32(sdr["ZM"]);
                        node.DeliveryDate = (Convert.ToDateTime(sdr["BDRQ"])).ToString("yyyy-MM-dd");
                        node.Delivery = Convert.ToString(sdr["SAPDN"]);
                        node.Instruction = Convert.ToString(sdr["TBSM"]);
                        node.PickUpByReceiver = Convert.ToBoolean(sdr["ZT"]);
                        node.HomeDelivery = Convert.ToBoolean(sdr["SHSM"]);
                        node.PickUpByCertificate = Convert.ToBoolean(sdr["PZJT"]);
                        node.PickUpByFax = Convert.ToBoolean(sdr["PCZT"]);
                        node.Feedback = Convert.ToBoolean(sdr["TYDHZ"]);
                        node.DeliveryFeedback = Convert.ToBoolean(sdr["SHDHZ"]);
                        node.Stamp = Convert.ToBoolean(sdr["BXGZ"]);
                        node.Dispatch = Convert.ToBoolean(sdr["JJ"]);
                        node.Requirement = Convert.ToString(sdr["QTYQ"]);
                        if (sdr["HDQR"] != DBNull.Value)
                            node.FeedbackRecord = Convert.ToBoolean(sdr["HDQR"]);
                        if (sdr["YCDJ"] != DBNull.Value)
                            node.ComplaintRecord = Convert.ToBoolean(sdr["YCDJ"]);
                        node.Status = Convert.ToInt16(sdr["TYDZT"]);
                        node.CreatorID = Convert.ToInt32(sdr["fillID"]);
                        node.Creator = Convert.ToString(sdr["fillName"]);
                        node.CreateDate = (Convert.ToDateTime(sdr["fillTime"])).ToString("yyyy-MM-dd HH:mm:ss");
                        node.Remark = Convert.ToString(sdr["BZ"]);
                        if (sdr["JHDFK"] != DBNull.Value)
                            node.JHDFK = Convert.ToBoolean(sdr["JHDFK"]);
                        if (sdr["JHDWHLIST"] != DBNull.Value)
                            node.JHDWHLIST = Convert.ToString(sdr["JHDWHLIST"]);
                        node.TYLB = Convert.ToInt32(sdr["TYLB"]);
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

        public CNInfo Read(int ID)
        {
            SqlParameter[] parms = { new SqlParameter("@ID", ID) };

            CNInfo node = new CNInfo();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_READ_SINGLE, parms))
                {
                    if (sdr.Read())
                    {
                        node.ID = Convert.ToInt32(sdr["TYDID"]);
                        node.Carrier = new CompanyInfo();
                        node.Carrier.ID = Convert.ToInt32(sdr["GSID"]);
                        node.Carrier.ShortName = Convert.ToString(sdr["GSJC"]);
                        node.Carrier.Name = Convert.ToString(sdr["GSMC"]);
                        node.SAP = Convert.ToBoolean(sdr["isSAP"]);
                        node.Date = (Convert.ToDateTime(sdr["TYRQ"])).ToString("yyyy-MM-dd");
                        node.SerialNumber = Convert.ToString(sdr["SN"]);
                        node.Number = Convert.ToString(sdr["DH"]);
                        node.Total = Convert.ToInt32(sdr["TYDH"]);
                        node.Source = new CityInfo();
                        node.Source.ID = Convert.ToInt32(sdr["FZDID"]);
                        node.Source.Name = Convert.ToString(sdr["FZDMC"]);
                        node.Destination = new CityInfo();
                        node.Destination.ID = Convert.ToInt32(sdr["DZDID"]);
                        node.Destination.Name = Convert.ToString(sdr["DZDMC"]);
                        node.Sender = new CompanyInfo();
                        node.Sender.ID = Convert.ToInt32(sdr["TYRID"]);
                        node.Sender.ShortName = Convert.ToString(sdr["TYRJC"]);
                        node.Sender.Name = Convert.ToString(sdr["TYRDW"]);
                        node.Sender.Address = Convert.ToString(sdr["TYRDZ"]);
                        node.Sender.Contact = Convert.ToString(sdr["LXR"]);
                        node.Sender.Telephone = Convert.ToString(sdr["LXDH"]);
                        node.Sender.Cellphone = Convert.ToString(sdr["SJ"]);
                        node.Receiver = new CompanyInfo();
                        node.Receiver.ID = Convert.ToInt32(sdr["SHRID"]);
                        node.Receiver.ShortName = Convert.ToString(sdr["SHRJC"]);
                        node.Receiver.Name = Convert.ToString(sdr["SHRDW"]);
                        node.Receiver.Address = Convert.ToString(sdr["SHRDZ"]);
                        node.Receiver.Contact = Convert.ToString(sdr["SLXR"]);
                        node.Receiver.Telephone = Convert.ToString(sdr["SLXDH"]);
                        node.Receiver.Cellphone = Convert.ToString(sdr["SSJ"]);
                        node.Weight = Convert.ToDecimal(sdr["JFZL"]);
                        node.UnitPrice = Convert.ToDecimal(sdr["JFDJ"]);
                        node.Cost = Convert.ToDecimal(sdr["YF"]);
                        node.Insurance = Convert.ToDecimal(sdr["BXF"]);
                        node.DirectCost = Convert.ToDecimal(sdr["ZSF"]);
                        node.TransitCost = Convert.ToDecimal(sdr["ZZF"]);
                        node.OtherCost = Convert.ToDecimal(sdr["QTF"]);
                        node.TotalCost = Convert.ToDecimal(sdr["HJ"]);
                        node.Compensation = Convert.ToInt32(sdr["PCBS"]);
                        node.DefaultArrivalLimit = Convert.ToInt32(sdr["WDTZ"]);
                        node.DeliveryCount = Convert.ToInt32(sdr["SHD"]);
                        node.InvoiceCount = Convert.ToInt32(sdr["FP"]);
                        node.CertificationCount = Convert.ToInt32(sdr["ZM"]);
                        node.DeliveryDate = (Convert.ToDateTime(sdr["BDRQ"])).ToString("yyyy-MM-dd");
                        node.Delivery = Convert.ToString(sdr["SAPDN"]);
                        node.Instruction = Convert.ToString(sdr["TBSM"]);
                        node.PickUpByReceiver = Convert.ToBoolean(sdr["ZT"]);
                        node.HomeDelivery = Convert.ToBoolean(sdr["SHSM"]);
                        node.PickUpByCertificate = Convert.ToBoolean(sdr["PZJT"]);
                        node.PickUpByFax = Convert.ToBoolean(sdr["PCZT"]);
                        node.Feedback = Convert.ToBoolean(sdr["TYDHZ"]);
                        node.DeliveryFeedback = Convert.ToBoolean(sdr["SHDHZ"]);
                        node.Stamp = Convert.ToBoolean(sdr["BXGZ"]);
                        node.Dispatch = Convert.ToBoolean(sdr["JJ"]);
                        node.Requirement = Convert.ToString(sdr["QTYQ"]);
                        if (sdr["HDQR"] != DBNull.Value)
                            node.FeedbackRecord = Convert.ToBoolean(sdr["HDQR"]);
                        if (sdr["YCDJ"] != DBNull.Value)
                            node.ComplaintRecord = Convert.ToBoolean(sdr["YCDJ"]);
                        node.Status = Convert.ToInt16(sdr["TYDZT"]);
                        node.CreatorID = Convert.ToInt32(sdr["fillID"]);
                        node.Creator = Convert.ToString(sdr["fillName"]);
                        node.CreateDate = (Convert.ToDateTime(sdr["fillTime"])).ToString("yyyy-MM-dd HH:mm:ss");
                        node.Remark = Convert.ToString(sdr["BZ"]);
                        if (sdr["JHDFK"] != DBNull.Value)
                            node.JHDFK = Convert.ToBoolean(sdr["JHDFK"]);
                        if (sdr["JHDWHLIST"] != DBNull.Value)
                            node.JHDWHLIST = Convert.ToString(sdr["JHDWHLIST"]);
                        if (sdr["ZSCOST"] != DBNull.Value)
                        {
                            node.ZSCost = Convert.ToDecimal(sdr["ZSCOST"]);
                        }
                        node.TYLB = Convert.ToInt32(sdr["TYLB"]);
                        //if (node.Carrier.ShortName.Trim() != "")
                        //{
                        //    node.PrintTxt = node.Carrier.ShortName.Trim() + "  ";
                        //}
                        //if (node.Destination.Name.Trim() != "")
                        //{
                        //    node.PrintTxt = node.PrintTxt + node.Destination.Name.Trim() + "  ";
                        //}
                        //if (node.Receiver.Contact.Trim() != "")
                        //{
                        //    if (node.Receiver.Contact.Trim().Length>1)
                        //        node.PrintTxt = node.PrintTxt + node.Receiver.Contact.Trim().Substring(0, 1);
                        //    else
                        //        node.PrintTxt = node.PrintTxt + node.Receiver.Contact.Trim();
                        //}
                        node.PrintTxt = node.Carrier.ShortName + "  " + node.Destination.Name + "  " + node.Receiver.Contact.Substring(0,1);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public IList<CNDeliveryInfo> ReadCNDeliveryByID(int ID)
        {
            SqlParameter[] parms = { new SqlParameter("@ID", ID) };

            IList<CNDeliveryInfo> nodes = new List<CNDeliveryInfo>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_READ_CNDeliveryBYTydid, parms))
                {
                    while (sdr.Read())
                    {
                        CNDeliveryInfo node = new CNDeliveryInfo();
                        node.TYDID = Convert.ToInt32(sdr["TYDID"]);
                        node.VBELN = Convert.ToString(sdr["VBELN"]);
                        if (sdr["STATUS"] != null && sdr["STATUS"].ToString() != "")
                            node.STATUS = Convert.ToInt32(sdr["STATUS"]);
                        if (sdr["FILLNAME"] != null && sdr["FILLNAME"].ToString() != "")
                            node.FILLNAME = Convert.ToString(sdr["FILLNAME"]);
                        if (sdr["FILLTIME"] != null && sdr["FILLTIME"].ToString() != "")
                            node.FILLTIME = (Convert.ToDateTime(sdr["FILLTIME"])).ToString("yyyy-MM-dd HH:mm");
                        if (sdr["FILLID"] != null && sdr["FILLID"].ToString() != "")
                            node.FILLID = Convert.ToString(sdr["FILLID"]);
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

        public IList<CNDeliveryInfo> ReadCNDelivery(string VBELN)
        {
            SqlParameter[] parms = { new SqlParameter("@VBELN", VBELN) };

            IList<CNDeliveryInfo> nodes = new List<CNDeliveryInfo>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_READ_CNDeliveryBYVbeln, parms))
                {
                    while (sdr.Read())
                    {
                        CNDeliveryInfo node = new CNDeliveryInfo();
                        node.TYDID = Convert.ToInt32(sdr["TYDID"]);
                        node.VBELN = Convert.ToString(sdr["VBELN"]);
                        if (sdr["STATUS"] != null && sdr["STATUS"].ToString() != "")
                            node.STATUS = Convert.ToInt32(sdr["STATUS"]);
                        if (sdr["FILLNAME"] != null && sdr["FILLNAME"].ToString() != "")
                            node.FILLNAME = Convert.ToString(sdr["FILLNAME"]);
                        if (sdr["FILLTIME"] != null && sdr["FILLTIME"].ToString() != "")
                            node.FILLTIME = (Convert.ToDateTime(sdr["FILLTIME"])).ToString("yyyy-MM-dd HH:mm");
                        if (sdr["FILLID"] != null && sdr["FILLID"].ToString() != "")
                            node.FILLID = Convert.ToString(sdr["FILLID"]);
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

        public IList<CNInfo> Report(CNInfo keywords)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@TYDID",keywords.ID),
                new SqlParameter("@GSID", keywords.Carrier.ID),
                new SqlParameter("@DZDID", keywords.Destination.ID),
                new SqlParameter("@SN",keywords.SerialNumber),
                new SqlParameter("@DH",keywords.Number),
                new SqlParameter("@TYRQ_LEFT",keywords.Date),
                new SqlParameter("@TYRQ_RIGHT",keywords.DateEnd),
                new SqlParameter("@BDRQ_LEFT",keywords.DeliveryDate),
                new SqlParameter("@BDRQ_RIGHT",keywords.DeliveryDateEnd),
                new SqlParameter("@SAPDN",keywords.Delivery),
                new SqlParameter("@SHRDW",keywords.Receiver.Name),
                new SqlParameter("@SLXR",keywords.Receiver.Contact),
                new SqlParameter("@SSJ",keywords.Receiver.Cellphone),
                new SqlParameter("@SLXDH",keywords.Receiver.Telephone),
                new SqlParameter("@SHRDZ",keywords.Receiver.Address),
                new SqlParameter("@TBSM",keywords.Instruction),
                new SqlParameter("@BZ",keywords.Remark),
                new SqlParameter("@TYDZT",keywords.Status),
                new SqlParameter("@TYLB",keywords.TYLB)};

            IList<CNInfo> nodes = new List<CNInfo>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_REPORT, parms))
                {
                    while (sdr.Read())
                    {
                        CNInfo node = new CNInfo();
                        node.ID = Convert.ToInt32(sdr["TYDID"]);
                        node.Carrier = new CompanyInfo();
                        node.Carrier.ID = Convert.ToInt32(sdr["GSID"]);
                        node.Carrier.ShortName = Convert.ToString(sdr["GSJC"]);
                        node.Carrier.Name = Convert.ToString(sdr["GSMC"]);
                        node.SAP = Convert.ToBoolean(sdr["isSAP"]);
                        node.Date = (Convert.ToDateTime(sdr["TYRQ"])).ToString("yyyy-MM-dd");
                        node.SerialNumber = Convert.ToString(sdr["SN"]);
                        node.Number = Convert.ToString(sdr["DH"]);
                        node.Total = Convert.ToInt32(sdr["TYDH"]);
                        node.Source = new CityInfo();
                        node.Source.ID = Convert.ToInt32(sdr["FZDID"]);
                        node.Source.Name = Convert.ToString(sdr["FZDMC"]);
                        node.Destination = new CityInfo();
                        node.Destination.ID = Convert.ToInt32(sdr["DZDID"]);
                        node.Destination.Name = Convert.ToString(sdr["DZDMC"]);
                        node.Sender = new CompanyInfo();
                        node.Sender.ID = Convert.ToInt32(sdr["TYRID"]);
                        node.Sender.ShortName = Convert.ToString(sdr["TYRJC"]);
                        node.Sender.Name = Convert.ToString(sdr["TYRDW"]);
                        node.Sender.Address = Convert.ToString(sdr["TYRDZ"]);
                        node.Sender.Contact = Convert.ToString(sdr["LXR"]);
                        node.Sender.Telephone = Convert.ToString(sdr["LXDH"]);
                        node.Sender.Cellphone = Convert.ToString(sdr["SJ"]);
                        node.Receiver = new CompanyInfo();
                        node.Receiver.ID = Convert.ToInt32(sdr["SHRID"]);
                        node.Receiver.ShortName = Convert.ToString(sdr["SHRJC"]);
                        node.Receiver.Name = Convert.ToString(sdr["SHRDW"]);
                        node.Receiver.Address = Convert.ToString(sdr["SHRDZ"]);
                        node.Receiver.Contact = Convert.ToString(sdr["SLXR"]);
                        node.Receiver.Telephone = Convert.ToString(sdr["SLXDH"]);
                        node.Receiver.Cellphone = Convert.ToString(sdr["SSJ"]);
                        node.Weight = Convert.ToDecimal(sdr["JFZL"]);
                        node.Volume = Convert.ToDecimal(sdr["TJ"]);  //Add by xsw
                        node.UnitPrice = Convert.ToDecimal(sdr["JFDJ"]);
                        node.Cost = Convert.ToDecimal(sdr["YF"]);
                        node.Insurance = Convert.ToDecimal(sdr["BXF"]);
                        node.DirectCost = Convert.ToDecimal(sdr["ZSF"]);
                        node.TransitCost = Convert.ToDecimal(sdr["ZZF"]);
                        node.OtherCost = Convert.ToDecimal(sdr["QTF"]);
                        node.TotalCost = Convert.ToDecimal(sdr["HJ"]);
                        node.Compensation = Convert.ToInt32(sdr["PCBS"]);
                        node.DefaultArrivalLimit = Convert.ToInt32(sdr["WDTZ"]);
                        node.DeliveryCount = Convert.ToInt32(sdr["SHD"]);
                        node.InvoiceCount = Convert.ToInt32(sdr["FP"]);
                        node.CertificationCount = Convert.ToInt32(sdr["ZM"]);
                        node.DeliveryDate = (Convert.ToDateTime(sdr["BDRQ"])).ToString("yyyy-MM-dd");
                        node.Delivery = Convert.ToString(sdr["SAPDN"]);
                        node.Instruction = Convert.ToString(sdr["TBSM"]);
                        node.PickUpByReceiver = Convert.ToBoolean(sdr["ZT"]);
                        node.HomeDelivery = Convert.ToBoolean(sdr["SHSM"]);
                        node.PickUpByCertificate = Convert.ToBoolean(sdr["PZJT"]);
                        node.PickUpByFax = Convert.ToBoolean(sdr["PCZT"]);
                        node.Feedback = Convert.ToBoolean(sdr["TYDHZ"]);
                        node.DeliveryFeedback = Convert.ToBoolean(sdr["SHDHZ"]);
                        node.Stamp = Convert.ToBoolean(sdr["BXGZ"]);
                        node.Dispatch = Convert.ToBoolean(sdr["JJ"]);
                        node.Requirement = Convert.ToString(sdr["QTYQ"]);
                        if (sdr["HDQR"] != DBNull.Value)
                            node.FeedbackRecord = Convert.ToBoolean(sdr["HDQR"]);
                        if (sdr["YCDJ"] != DBNull.Value)
                            node.ComplaintRecord = Convert.ToBoolean(sdr["YCDJ"]);
                        node.Status = Convert.ToInt16(sdr["TYDZT"]);
                        node.CreatorID = Convert.ToInt32(sdr["fillID"]);
                        node.Creator = Convert.ToString(sdr["fillName"]);
                        node.CreateDate = (Convert.ToDateTime(sdr["fillTime"])).ToString("yyyy-MM-dd HH:mm:ss");
                        node.Remark = Convert.ToString(sdr["BZ"]);
                        node.TYLB = Convert.ToInt32(sdr["TYLB"]);
                        node.Sum = new List<int>();
                        if (sdr["m1"] != DBNull.Value)
                            node.Sum.Add(Convert.ToInt32(sdr["m1"]));
                        else
                            node.Sum.Add(0);
                        if (sdr["m2"] != DBNull.Value)
                            node.Sum.Add(Convert.ToInt32(sdr["m2"]));
                        else
                            node.Sum.Add(0);
                        if (sdr["m3"] != DBNull.Value)
                            node.Sum.Add(Convert.ToInt32(sdr["m3"]));
                        else
                            node.Sum.Add(0);
                        if (sdr["m0"] != DBNull.Value)
                            node.Sum.Add(Convert.ToInt32(sdr["m0"]));
                        else
                            node.Sum.Add(0);
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

        public string CurrentNumber(int carrierID)
        {
            SqlParameter[] parms = { new SqlParameter("@ID", carrierID) };

            string number = "";
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_CURRENT_NUMBER, parms))
                {
                    if (sdr.Read())
                    {
                        number = Convert.ToString(sdr["DH"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return number;
        }

        public int Create(CNInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@GSID", node.Carrier.ID),
                new SqlParameter("@GSJC", node.Carrier.ShortName),
                new SqlParameter("@GSMC", node.Carrier.ShortName),
                new SqlParameter("@isSAP", node.SAP),
                new SqlParameter("@TYRQ", node.Date),
                new SqlParameter("@DH", node.Number), 
                new SqlParameter("@TYDH", node.Total), 
                new SqlParameter("@FZDID", node.Source.ID),
                new SqlParameter("@FZDMC", node.Source.Name), 
                new SqlParameter("@DZDID", node.Destination.ID), 
                new SqlParameter("@DZDMC", node.Destination.Name), 
                new SqlParameter("@YZDID", ""), 
                new SqlParameter("@YZDMC", ""),
                new SqlParameter("@ZZDID", ""), 
                new SqlParameter("@ZZDMC", ""),
                new SqlParameter("@TYRID", node.Sender.ID), 
                new SqlParameter("@TYRJC", node.Sender.Name), 
                new SqlParameter("@TYRDW", node.Sender.Name),
                new SqlParameter("@TYRDZ", node.Sender.Address), 
                new SqlParameter("@LXR", node.Sender.Contact), 
                new SqlParameter("@LXDH", node.Sender.Telephone), 
                new SqlParameter("@SJ", node.Sender.Cellphone), 
                new SqlParameter("@SHRID", node.Receiver.ID),
                new SqlParameter("@SHRJC", node.Receiver.Name), 
                new SqlParameter("@SHRDW", node.Receiver.Name), 
                new SqlParameter("@SHRDZ", node.Receiver.Address), 
                new SqlParameter("@SLXR", node.Receiver.Contact),
                new SqlParameter("@SLXDH", node.Receiver.Telephone),
                new SqlParameter("@SSJ", node.Receiver.Cellphone),
                new SqlParameter("@JFZL", node.Weight),
                new SqlParameter("@JFDJ", node.UnitPrice),
                new SqlParameter("@YF", node.Cost), 
                new SqlParameter("@BXF", node.Insurance),
                new SqlParameter("@ZSF",node.DirectCost),
                new SqlParameter("@ZZF", node.TransitCost),
                new SqlParameter("@QTF", node.OtherCost),
                new SqlParameter("@HJ", node.TotalCost), 
                new SqlParameter("@PCBS",  node.Compensation), 
                new SqlParameter("@WDTZ", node.DefaultArrivalLimit),
                new SqlParameter("@SHD", node.DeliveryCount),
                new SqlParameter("@FP", node.InvoiceCount),
                new SqlParameter("@ZM", node.CertificationCount),
                new SqlParameter("@BDRQ", node.DeliveryDate),
                new SqlParameter("@SAPDN", node.Delivery),
                new SqlParameter("@TBSM", node.Instruction),
                new SqlParameter("@ZT", node.PickUpByReceiver),
                new SqlParameter("@SHSM", node.HomeDelivery),
                new SqlParameter("@PZJT", node.PickUpByCertificate),
                new SqlParameter("@PCZT", node.PickUpByFax),
                new SqlParameter("@TYDHZ", node.Feedback),
                new SqlParameter("@SHDHZ", node.DeliveryFeedback),
                new SqlParameter("@BXGZ", node.Stamp),
                new SqlParameter("@JJ", node.Dispatch),
                new SqlParameter("@QTYQ", node.Requirement),
                new SqlParameter("@fillID", node.CreatorID),
                new SqlParameter("@fillName", node.Creator), 
                new SqlParameter("@BZ", node.Remark),
                new SqlParameter("@ZSCOST",node.ZSCost),
                new SqlParameter("@TYLB",node.TYLB)
                                   };

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

        public bool Update(CNInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@TYDID", node.ID),
                new SqlParameter("@GSID", node.Carrier.ID),
                new SqlParameter("@GSJC", node.Carrier.ShortName),
                new SqlParameter("@GSMC", node.Carrier.ShortName),
                new SqlParameter("@isSAP", node.SAP),
                new SqlParameter("@TYRQ", node.Date),
                new SqlParameter("@SN", node.SerialNumber), 
                new SqlParameter("@DH", node.Number), 
                new SqlParameter("@TYDH", node.Total), 
                new SqlParameter("@FZDID", node.Source.ID),
                new SqlParameter("@FZDMC", node.Source.Name), 
                new SqlParameter("@DZDID", node.Destination.ID), 
                new SqlParameter("@DZDMC", node.Destination.Name), 
                new SqlParameter("@YZDID", ""), 
                new SqlParameter("@YZDMC", ""),
                new SqlParameter("@ZZDID", ""), 
                new SqlParameter("@ZZDMC", ""),
                new SqlParameter("@TYRID", node.Sender.ID), 
                new SqlParameter("@TYRJC", node.Sender.Name), 
                new SqlParameter("@TYRDW", node.Sender.Name),
                new SqlParameter("@TYRDZ", node.Sender.Address), 
                new SqlParameter("@LXR", node.Sender.Contact), 
                new SqlParameter("@LXDH", node.Sender.Telephone), 
                new SqlParameter("@SJ", node.Sender.Cellphone), 
                new SqlParameter("@SHRID", node.Receiver.ID),
                new SqlParameter("@SHRJC", node.Receiver.Name), 
                new SqlParameter("@SHRDW", node.Receiver.Name), 
                new SqlParameter("@SHRDZ", node.Receiver.Address), 
                new SqlParameter("@SLXR", node.Receiver.Contact),
                new SqlParameter("@SLXDH", node.Receiver.Telephone),
                new SqlParameter("@SSJ", node.Receiver.Cellphone),
                new SqlParameter("@JFZL", node.Weight),
                new SqlParameter("@JFDJ", node.UnitPrice),
                new SqlParameter("@YF", node.Cost), 
                new SqlParameter("@BXF", node.Insurance),
                new SqlParameter("@ZSF",node.DirectCost),
                new SqlParameter("@ZZF", node.TransitCost),
                new SqlParameter("@QTF", node.OtherCost),
                new SqlParameter("@HJ", node.TotalCost), 
                new SqlParameter("@PCBS",  node.Compensation), 
                new SqlParameter("@WDTZ", node.DefaultArrivalLimit),
                new SqlParameter("@SHD", node.DeliveryCount),
                new SqlParameter("@FP", node.InvoiceCount),
                new SqlParameter("@ZM", node.CertificationCount),
                new SqlParameter("@BDRQ", node.DeliveryDate),
                new SqlParameter("@SAPDN", node.Delivery),
                new SqlParameter("@TBSM", node.Instruction),
                new SqlParameter("@ZT", node.PickUpByReceiver),
                new SqlParameter("@SHSM", node.HomeDelivery),
                new SqlParameter("@PZJT", node.PickUpByCertificate),
                new SqlParameter("@PCZT", node.PickUpByFax),
                new SqlParameter("@TYDHZ", node.Feedback),
                new SqlParameter("@SHDHZ", node.DeliveryFeedback),
                new SqlParameter("@BXGZ", node.Stamp),
                new SqlParameter("@JJ", node.Dispatch),
                new SqlParameter("@QTYQ", node.Requirement),
                new SqlParameter("@fillID", node.CreatorID),
                new SqlParameter("@fillName", node.Creator), 
                new SqlParameter("@BZ", node.Remark),
                new SqlParameter("@ZSCOST",node.ZSCost),
                new SqlParameter("@TYLB",node.TYLB)
                                   };

            bool success = false;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    success = true;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return success;
        }

        public int Delete(int ID)
        {
            SqlParameter[] parms = { new SqlParameter("@ID", ID) };

            CNInfo node = new CNInfo();
            int success = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms))
                {
                    success = ID;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return success;
        }



    }
}
