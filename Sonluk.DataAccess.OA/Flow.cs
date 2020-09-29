using Oracle.DataAccess.Client;
using Sonluk.Entities.OA;
using Sonluk.Entities.PP;
using Sonluk.Entities.QM;
using Sonluk.IDataAccess.OA;
using Sonluk.DataAccess.OA.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Sonluk.DataAccess.Utility.Oracle;
using Sonluk.Entities.CRM;

namespace Sonluk.DataAccess.OA
{
    public class Flow : IFlow
    {
        private const string SQL_SELECT_BY_TEMPLATE = "SELECT FORM_RECORDID FROM COL_SUMMARY WHERE templete_ID = :TempleteID AND state=:Status AND FORM_RECORDID NOT IN (SELECT FLOWID FROM ZSonluk_Sync_Log WHERE status>0 AND templateID =:TemplateID)";
        private const string SQL_SELECT_Z3 = "SELECT field0001,field0035,field0093,field0006,field0064,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0066) as field0066,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0011) as field0011,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0015) as field0015,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0019) as field0019,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0021) as field0021,field0023,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0042) as field0042,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0057) as field0057,(SELECT NAME FROM ORG_MEMBER WHERE ORG_MEMBER.id = a.field0024) as field0024 ,(SELECT CODE FROM ORG_MEMBER WHERE ORG_MEMBER.id = a.field0024) as code FROM formmain_0393 a WHERE a.id = :ID";
        private const string SQL_SELECT_Z3_ITEM = "SELECT * FROM formson_0394 WHERE formmain_id =:ID";
        private const string SQL_SELECT_Q1 = "SELECT field0001,field0002,field0003,field0004,field0102,field0006,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0007) as field0007,field0012,(SELECT NAME FROM ORG_UNIT WHERE ORG_UNIT.id = a.field0014) as field0014,(SELECT NAME FROM ORG_MEMBER WHERE ORG_MEMBER.id = a.field0015) as field0015,(SELECT CODE FROM ORG_MEMBER WHERE ORG_MEMBER.id = a.field0015) as code,field0023,field0026,field0027,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0034) as field0034,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0035) as field0035,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0022) as field0022 FROM formmain_0144 a where a.id = :ID";
        private const string SQL_Q1_UPDATE = "UPDATE formmain_0144 SET field0090=:QUALITYNOTIFICATION where ID=:ID";
        private const string SQL_SELECT_Q1_PRODUCT = "SELECT field0039,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0040) as field0040,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0041) as field0041,field0042,field0043,field0045,field0046,field0047,field0048,field0049,field0050,field0051,field0052,field0053,field0054,field0055,field0056,field0057,field0058,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0063) as field0063,field0089,field0064,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0065) as field0065,field0114,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0115) as field0115 FROM formson_0145 a where a.formmain_id = :ID";
        private const string SQL_SELECT_Q1_OUTSOURCING = "SELECT field0071,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0099) as field0099,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0097) as field0097,field0108,field0075,field0076,field0088,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0080) as field0080,field0081,field0098,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0082) as field0082 FROM formson_0146 a where a.formmain_id = :ID";
        private const string SQL_LOG_INSERT = "INSERT INTO ZSonluk_Sync_Log VALUES (:FLOWID,to_timestamp(:DATETIME , 'yyyy-mm-dd hh24:mi:ss FF6'),:FLOWSN,:ACTION,:QUALITYNOTIFICATION,:TEMPLATEID,:REMARK,:STATUS)";
        private const string SQL_LOG_SELECT = "SELECT to_char(DateTime,'yyyy-mm-dd hh24:mi:ss FF6') AS DateTime,Action,Status,QualityNotification AS QN,FlowSN,(SELECT subject FROM CTP_TEMPLATE WHERE CTP_TEMPLATE.id = a.TemplateID) AS Template,Remark,FlowID,TemplateID FROM ZSonluk_Sync_Log a WHERE DateTime>to_date(:StartDate, 'yyyy-mm-dd') and DateTime<to_date(:EndDate , 'yyyy-mm-dd')+1 ORDER BY DateTime";
        private const string SQL_LOG_SELECT_FUZZY = "SELECT to_char(DateTime,'yyyy-mm-dd hh24:mi:ss FF6') AS DateTime,Action,Status,QualityNotification AS QN,FlowSN,(SELECT subject FROM CTP_TEMPLATE WHERE CTP_TEMPLATE.id = a.TemplateID) AS Template,Remark,FlowID,TemplateID FROM ZSonluk_Sync_Log a WHERE QualityNotification LIKE :keyword1 OR FlowSN LIKE :keyword2 OR Remark LIKE :keyword3 ORDER BY DateTime";
        private const string SQL_SELECT_Z2 = "SELECT field0001,field0014,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0007) as field0007,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0011) as field0011,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0041) as field0041,(select showvalue from CTP_ENUM_ITEM where CTP_ENUM_ITEM.id = a.field0056) as field0056,(SELECT NAME FROM ORG_MEMBER WHERE ORG_MEMBER.id = a.field0019) as field0019,(SELECT CODE FROM ORG_MEMBER WHERE ORG_MEMBER.id = a.field0019) as code FROM formmain_0106 a WHERE a.id = :ID";

        //从这里开始是CRM的OA
        private const string SQL_Readformmain_1827 = "SELECT formmain_1827.* FROM formmain_1827 WHERE formmain_1827.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_1843 = "SELECT formmain_1843.* FROM formmain_1843 WHERE formmain_1843.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_1857 = "SELECT formmain_1857.* FROM formmain_1857 WHERE formmain_1857.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_1882 = "SELECT formmain_1882.* FROM formmain_1882 WHERE formmain_1882.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_1861 = "SELECT formmain_1861.* FROM formmain_1861 WHERE formmain_1861.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_1865 = "SELECT formmain_1865.* FROM formmain_1865 WHERE formmain_1865.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_1874 = "SELECT formmain_1874.* FROM formmain_1874 WHERE formmain_1874.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_1879 = "SELECT formmain_1879.* FROM formmain_1879 WHERE formmain_1879.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_1915 = "SELECT formmain_1915.* FROM formmain_1915 WHERE formmain_1915.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2482 = "SELECT formmain_2482.* FROM formmain_2482 WHERE formmain_2482.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        //private const string SQL_Readformmain_2465 = "SELECT formmain_2465.* FROM formmain_2465 WHERE formmain_2465.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2465 = "SELECT formmain_3130.* FROM formmain_3130 WHERE formmain_3130.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2461 = "SELECT formmain_2461.* FROM formmain_2461 WHERE formmain_2461.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2434 = "SELECT formmain_2434.* FROM formmain_2434 WHERE formmain_2434.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2467 = "SELECT formmain_2467.* FROM formmain_2467 WHERE formmain_2467.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2575 = "SELECT formmain_2575.* FROM formmain_2575 WHERE formmain_2575.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2577 = "SELECT formmain_2577.* FROM formmain_2577 WHERE formmain_2577.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2581 = "SELECT formmain_2581.* FROM formmain_2581 WHERE formmain_2581.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2584 = "SELECT formmain_2584.* FROM formmain_2584 WHERE formmain_2584.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2612 = "SELECT formmain_2612.* FROM formmain_2612 WHERE formmain_2612.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Readformmain_2983 = "SELECT formmain_2983.* FROM formmain_2983 WHERE formmain_2983.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";

        private const string SQL_ReadBPMStatus = "SELECT COUNT(*) AS COUNT FROM COL_SUMMARY WHERE ID = :ID";


        //use for DaiFa
        private const string SQL_ReadDaiFaStatus = "SELECT count(*) as count FROM ctp_affair WHERE ctp_affair.object_id IN (SELECT ID FROM col_summary WHERE col_summary.ID = :ID) and state = 1";
        private const string SQL_ReadOpinion = "SELECT ORG_MEMBER.name as NAME,ORG_MEMBER.code as NO,to_char(create_date,'yyyy-mm-dd hh24:mi:ss') as TIME,ctp_comment_all.*"
                                            + "FROM ctp_comment_all join ORG_MEMBER on ORG_MEMBER.ID = ctp_comment_all.create_id where  module_id = :ID  and CTYPE = 0"
                                            + "order by ctp_comment_all.create_date";


        private const string SQL_Updateformmain_1827 = "update formmain_1827 set field0030 = 'OA' WHERE formmain_1827.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_1843 = "";
        private const string SQL_Updateformmain_1857 = "";
        private const string SQL_Updateformmain_1882 = "";
        private const string SQL_Updateformmain_1861 = "";
        private const string SQL_Updateformmain_1865 = "";
        private const string SQL_Updateformmain_1874 = "";
        private const string SQL_Updateformmain_1879 = "";
        private const string SQL_Updateformmain_1915 = "";
        private const string SQL_Updateformmain_2482 = "update formmain_2482 set field0276 = '' WHERE formmain_2482.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_2465 = "update formmain_2465 set field0027 = '' WHERE formmain_2465.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_2461 = "update formmain_2461 set field0013 = '' WHERE formmain_2461.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_2434 = "update formmain_2434 set field0032 = '' WHERE formmain_2434.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_2467 = "update formmain_2467 set field0021 = '' WHERE formmain_2467.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_2575 = "update formmain_2575 set field0001 = '' WHERE formmain_2575.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_2577 = "update formmain_2577 set field0034 = '' WHERE formmain_2577.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_2581 = "update formmain_2581 set field0017 = '' WHERE formmain_2581.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_2584 = "update formmain_2584 set field0008 = '' WHERE formmain_2584.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_2612 = "update formmain_2612 set field0007 = '' WHERE formmain_2612.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";
        private const string SQL_Updateformmain_2983 = "update formmain_2983 set field0033 = '' WHERE formmain_2983.ID IN (SELECT FORM_RECORDID FROM col_summary WHERE col_summary.ID = :ID)";






        public IList<FlowInfo> Read(string templateID, int status)
        {
            OracleParameter[] parms = {	
                new OracleParameter(":TempleteID", OracleDbType.Decimal),
                new OracleParameter(":Status", OracleDbType.Decimal),
                new OracleParameter(":TemplateID", OracleDbType.Decimal)};

            parms[0].Value = templateID;
            parms[1].Value = status;
            parms[2].Value = templateID;

            IList<FlowInfo> nodes = new List<FlowInfo>();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_SELECT_BY_TEMPLATE, parms))
                {
                    while (odr.Read())
                    {
                        FlowInfo node = new FlowInfo();
                        node.ID = Convert.ToString(odr["FORM_RECORDID"]);
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

        public IList<FlowInfo> Read(FlowInfo keywords)
        {
            throw new NotImplementedException();
        }

        public bool SyncLog(FlowLogInfo node)
        {
            OracleParameter[] parms = {	
                new OracleParameter(":FLOWID", OracleDbType.Decimal),
                new OracleParameter(":DATETIME", OracleDbType.Varchar2),
                new OracleParameter(":FLOWSN", OracleDbType.NVarchar2),
                new OracleParameter(":ACTION", OracleDbType.Varchar2),
                new OracleParameter(":QUALITYNOTIFICATION", OracleDbType.Varchar2),
                new OracleParameter(":TEMPLATEID", OracleDbType.Decimal),
                new OracleParameter(":REMARK", OracleDbType.NVarchar2),
                new OracleParameter(":STATUS", OracleDbType.Int16)};

            parms[0].Value = node.ID;
            parms[1].Value = node.Date;
            parms[2].Value = node.SerialNumber;
            parms[3].Value = node.Type;
            parms[4].Value = node.QualityNotification;
            parms[5].Value = node.TemplateID;
            parms[6].Value = node.Remark;
            parms[7].Value = node.Status;

            bool success = false;
            try
            {
                if (OracleHelper.ExecuteNonQuery(Connection.connectionString, CommandType.Text, SQL_LOG_INSERT, parms) == 1)
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

        public IList<FlowLogInfo> SyncLog(string startDate, string endDate)
        {

            OracleParameter[] parms = {	
                new OracleParameter(":StartDate", OracleDbType.Varchar2),
                new OracleParameter(":EndDate", OracleDbType.Varchar2)};

            parms[0].Value = startDate;
            parms[1].Value = endDate;
            IList<FlowLogInfo> nodes = new List<FlowLogInfo>();
            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_LOG_SELECT, parms))
                {
                    while (odr.Read())
                    {
                        FlowLogInfo node = new FlowLogInfo();

                        node.ID = Convert.ToString(odr["FlowID"]);
                        node.Date = Convert.ToString(odr["DateTime"]);
                        node.SerialNumber = Convert.ToString(odr["FlowSN"]);
                        node.Type = Convert.ToString(odr["ACTION"]);
                        node.QualityNotification = Convert.ToString(odr["QN"]);
                        node.TemplateID = Convert.ToString(odr["TemplateID"]);
                        node.Template = Convert.ToString(odr["Template"]);
                        node.Remark = Convert.ToString(odr["Remark"]);
                        node.Status = Convert.ToInt16(odr["Status"]);
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

        public IList<FlowLogInfo> SyncLog(string keyword)
        {

            OracleParameter[] parms = {	
                new OracleParameter(":keyword1", OracleDbType.NVarchar2),
                new OracleParameter(":keyword2", OracleDbType.NVarchar2),
                new OracleParameter(":keyword3", OracleDbType.NVarchar2)};

            keyword = "%" + keyword + "%";
            parms[0].Value = keyword;
            parms[1].Value = keyword;
            parms[2].Value = keyword;

            IList<FlowLogInfo> nodes = new List<FlowLogInfo>();
            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_LOG_SELECT_FUZZY, parms))
                {
                    while (odr.Read())
                    {
                        FlowLogInfo node = new FlowLogInfo();

                        node.ID = Convert.ToString(odr["FlowID"]);
                        node.Date = Convert.ToString(odr["DateTime"]);
                        node.SerialNumber = Convert.ToString(odr["FlowSN"]);
                        node.Type = Convert.ToString(odr["ACTION"]);
                        node.QualityNotification = Convert.ToString(odr["QN"]);
                        node.TemplateID = Convert.ToString(odr["TemplateID"]);
                        node.Template = Convert.ToString(odr["Template"]);
                        node.Remark = Convert.ToString(odr["Remark"]);
                        node.Status = Convert.ToInt16(odr["Status"]);
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

        public QNInfo ReadZ3(string ID)
        {
            OracleParameter param = new OracleParameter(":ID", OracleDbType.Decimal);
            param.Value = ID;

            QNInfo node = new QNInfo();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_SELECT_Z3, param))
                {

                    if (odr.Read())
                    {
                        node.SerialNumber = Convert.ToString(odr["field0001"]);
                        node.FlowSerialNumber = Convert.ToString(odr["field0035"]);
                        if (odr["field0093"] != DBNull.Value)
                            node.DefectiveQtyExternal = Convert.ToDecimal(odr["field0093"]);
                        if (odr["field0006"] != DBNull.Value)
                            node.Defects = Convert.ToInt32(odr["field0006"]);
                        if (odr["field0064"] != DBNull.Value)
                            node.DefectiveQtyInternal = Convert.ToDecimal(odr["field0064"]);
                        node.SingleUnitToBeInspected = Convert.ToString(odr["field0066"]);
                        node.Remark = Convert.ToString(odr["field0011"]);
                        node.ExternalReference = Convert.ToString(odr["field0015"]);
                        node.Department = Convert.ToString(odr["field0019"]);
                        node.ResponsibleDept = Convert.ToString(odr["field0021"]);
                        node.Disqualification = Convert.ToString(odr["field0023"]);
                        node.Review = Convert.ToString(odr["field0042"]);
                        node.Rework = Convert.ToString(odr["field0057"]);
                        node.Creator = Convert.ToString(odr["field0024"]);
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public IList<QNItemInfo> ReadZ3Item(string ID)
        {
            OracleParameter param = new OracleParameter(":ID", OracleDbType.Decimal);
            param.Value = ID;


            IList<QNItemInfo> nodes = new List<QNItemInfo>();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_SELECT_Z3_ITEM, param))
                {

                    while (odr.Read())
                    {
                        QNItemInfo node = new QNItemInfo();
                        node.CodeGroup = Convert.ToString(odr["field0071"]);
                        node.CauseCode = Convert.ToString(odr["field0072"]);
                        node.CauseDescription = Convert.ToString(odr["field0070"]);
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

        public bool UpdateQ1(string ID, string QualityNotification)
        {
            OracleParameter[] parms = {	
                new OracleParameter(":QUALITYNOTIFICATION", OracleDbType.Varchar2),
                new OracleParameter(":ID", OracleDbType.Decimal)};

            parms[0].Value = QualityNotification;
            parms[1].Value = ID;

            bool success = false;
            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_Q1_UPDATE, parms))
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

        public QNInfo ReadQ1(string ID)
        {
            OracleParameter param = new OracleParameter(":ID", OracleDbType.Decimal);
            param.Value = ID;

            QNInfo node = new QNInfo();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_SELECT_Q1, param))
                {

                    if (odr.Read())
                    {
                        node.FlowSerialNumber = Convert.ToString(odr["field0001"]);
                        node.Product = Convert.ToString(odr["field0002"]);
                        if (odr["field0003"] != DBNull.Value)
                            node.Date = Convert.ToDateTime(odr["field0003"]).ToString("yyyyMMdd");
                        if (odr["field0004"] != DBNull.Value)
                            node.Customer = Convert.ToString(odr["field0004"]);
                        else
                            node.Customer = Convert.ToString(odr["field0102"]);
                        node.Model = Convert.ToString(odr["field0006"]);
                        node.ReturnOrExchange = Convert.ToString(odr["field0007"]);
                        node.Complain = Convert.ToString(odr["field0012"]);
                        node.SalesDepartment = Convert.ToString(odr["field0014"]);
                        node.Sales = Convert.ToString(odr["field0015"]);
                        if (odr["field0023"] != DBNull.Value)
                            node.ReceiveDate = Convert.ToDateTime(odr["field0023"]).ToString("yyyyMMdd");
                        if (odr["field0026"] != DBNull.Value)
                            node.Quantity = Convert.ToDecimal(odr["field0026"]);
                        if (odr["field0027"] != DBNull.Value)
                            node.Compensate = Convert.ToDecimal(odr["field0027"]);
                        node.Report = Convert.ToString(odr["field0034"]);
                        node.Closed = Convert.ToString(odr["field0035"]);
                        node.Outsourcing = Convert.ToString(odr["field0022"]);
                        node.Creator = node.Sales;
                        node.CreatorCode = Convert.ToString(odr["CODE"]);
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public IList<ProductInfo> ReadQ1Product(string ID)
        {
            OracleParameter param = new OracleParameter(":ID", OracleDbType.Decimal);
            param.Value = ID;

            IList<ProductInfo> nodes = new List<ProductInfo>();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_SELECT_Q1_PRODUCT, param))
                {

                    while (odr.Read())
                    {
                        ProductInfo node = new ProductInfo();
                        node.SerialNumber = Convert.ToString(odr["field0039"]);
                        node.ComplainType = Convert.ToString(odr["field0040"]);
                        node.Complain = Convert.ToString(odr["field0041"]);

                        if (odr["field0042"] != DBNull.Value)
                            node.Quantity = Convert.ToDecimal(odr["field0042"]);

                        node.Mark = Convert.ToString(odr["field0043"]);
                        node.ProducingLine = Convert.ToString(odr["field0045"]);

                        if (odr["field0046"] != DBNull.Value)
                            node.ProducingDate = Convert.ToDateTime(odr["field0046"]).ToString("yyyyMMdd");

                        node.Level = Convert.ToString(odr["field0047"]);
                        node.CopperNailVendor = Convert.ToString(odr["field0048"]);
                        node.CopperNailPlater = Convert.ToString(odr["field0049"]);
                        node.CopperNailBatch = Convert.ToString(odr["field0050"]);
                        node.SealCircleVendor = Convert.ToString(odr["field0051"]);
                        node.SealCircleLathe = Convert.ToString(odr["field0052"]);
                        node.SealCircleBatch = Convert.ToString(odr["field0053"]);
                        node.SteelShellVendor = Convert.ToString(odr["field0054"]);
                        node.SteelShellBatch = Convert.ToString(odr["field0055"]);
                        node.PositivePole = Convert.ToString(odr["field0056"]);
                        node.NegativePole = Convert.ToString(odr["field0057"]);

                        if (odr["field0058"] != DBNull.Value)
                            node.PackageDate = Convert.ToDateTime(odr["field0058"]).ToString("yyyyMMdd");
                        //if (node.ComplainType != null && node.ComplainType.Equals("C类"))
                        //    node.Reason = Convert.ToString(odr["field0089"]);
                        //else
                        node.Reason = Convert.ToString(odr["field0063"]);

                        node.Remark = Convert.ToString(odr["field0064"]);
                        node.ComplainAvailable = Convert.ToString(odr["field0065"]);

                        node.GKCH = Convert.ToString(odr["field0114"]);
                        node.ZCHF = Convert.ToString(odr["field0115"]);
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

        public IList<ProductInfo> ReadQ1Outsourcing(string ID)
        {
            OracleParameter param = new OracleParameter(":ID", OracleDbType.Decimal);
            param.Value = ID;


            IList<ProductInfo> nodes = new List<ProductInfo>();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_SELECT_Q1_OUTSOURCING, param))
                {

                    while (odr.Read())
                    {
                        ProductInfo node = new ProductInfo();
                        node.SerialNumber = Convert.ToString(odr["field0071"]);
                        node.ComplainType = Convert.ToString(odr["field0099"]);
                        node.Complain = Convert.ToString(odr["field0097"]);

                        if (odr["field0108"] != DBNull.Value)
                            node.Quantity = Convert.ToDecimal(odr["field0108"]);
                        node.Mark = Convert.ToString(odr["field0075"]);
                        node.Vendor = Convert.ToString(odr["field0076"]);

                        if (odr["field0088"] != DBNull.Value)
                            node.ProducingDate = Convert.ToDateTime(odr["field0088"]).ToString("yyyyMMdd");

                        node.Reason = Convert.ToString(odr["field0098"]);

                        //if (node.ComplainType != null && node.ComplainType.Equals("C类"))
                        //    node.Reason = Convert.ToString(odr["field0098"]);
                        //else
                        //    node.Reason = Convert.ToString(odr["field0080"]);

                        node.Remark = Convert.ToString(odr["field0081"]);
                        node.ComplainAvailable = Convert.ToString(odr["field0082"]);
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

        public QNInfo ReadZ2(string ID)
        {
            OracleParameter param = new OracleParameter(":ID", OracleDbType.Decimal);
            param.Value = ID;

            QNInfo node = new QNInfo();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_SELECT_Z2, param))
                {
                    if (odr.Read())
                    {
                        node.SerialNumber = Convert.ToString(odr["field0001"]);
                        node.FlowSerialNumber = Convert.ToString(odr["field0014"]);
                        node.Model = Convert.ToString(odr["field0007"]);
                        node.PurchaseDepartment = Convert.ToString(odr["field0011"]);
                        node.Review = Convert.ToString(odr["field0041"]);
                        node.Rework = Convert.ToString(odr["field0056"]);
                        node.Creator = Convert.ToString(odr["field0019"]);
                        node.CreatorCode = Convert.ToString(odr["CODE"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }



        public int ReadOAFinishStatus(long ID, int OACSLB, int OAZT)
        {
            OracleParameter[] parms = {
                                          new OracleParameter(":ID",ID)
                                      };
            string sql = "";
            if (OACSLB == 92)
            {
                sql = SQL_Readformmain_1827;
            }
            else if (OACSLB == 93 || OACSLB == 1083)
            {
                //if (OAZT == 1)
                //{
                sql = SQL_Readformmain_1843;
                //}
                //else
                //{
                //    sql = SQL_Readformmain_1857;
                //}

            }
            else if (OACSLB == 105)
            {
                sql = SQL_Readformmain_1857;
            }
            else if (OACSLB == 551)
            {
                sql = SQL_Readformmain_1882;
            }
            else if (OACSLB == 921)
            {
                sql = SQL_Readformmain_1861;
            }
            else if (OACSLB == 922)
            {
                sql = SQL_Readformmain_1865;
            }
            else if (OACSLB == 923)
            {
                sql = SQL_Readformmain_1874;
            }
            else if (OACSLB == 104)
            {
                sql = SQL_Readformmain_1879;
            }
            else if (OACSLB == 990)
            {
                sql = SQL_Readformmain_1915;
            }
            else if (OACSLB == 1313)
            {
                sql = SQL_Readformmain_2482;
            }
            else if(OACSLB == 1360)
            {
                sql = SQL_Readformmain_2465;
            }
            else if (OACSLB == 1361)
            {
                sql = SQL_Readformmain_2461;
            }
            else if (OACSLB == 1362)
            {
                sql = SQL_Readformmain_2434;
            }
            else if (OACSLB == 2014 || OACSLB == 2051)
            {
                sql = SQL_Readformmain_2467;
            }
            else if (OACSLB == 2015 || OACSLB == 2021)
            {
                sql = SQL_Readformmain_2575;
            }
            else if (OACSLB == 2022)
            {
                sql = SQL_Readformmain_2577;
            }
            else if (OACSLB == 2023 || OACSLB == 4120)
            {
                sql = SQL_Readformmain_2581;
            }
            else if (OACSLB == 2024 || OACSLB == 4121)
            {
                sql = SQL_Readformmain_2584;
            }
            else if (OACSLB == 2027)
            {
                sql = SQL_Readformmain_2612;
            }
            else if (OACSLB == 2066 || OACSLB == 2079)
            {
                sql = SQL_Readformmain_2983;
            }
            int Status = 0;
            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, sql, parms))
                {
                    if (odr.Read())
                    {
                        //if (odr["FINISHEDFLAG"] != null)
                        //{
                        Status = Convert.ToInt32(odr["FINISHEDFLAG"]);
                        //}

                    }

                }
            }
            catch (Exception E)
            {

                throw new ApplicationException(E.Message);
            }
            return Status;
        }

        public int ReadOADaiFaStatus(long ID)
        {
            OracleParameter[] parms = {
                                          new OracleParameter(":ID",ID)
                                      };


            int Status = 0;
            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_ReadDaiFaStatus, parms))
                {
                    if (odr.Read())
                    {
                        //if (odr["FINISHEDFLAG"] != null)
                        //{
                        Status = Convert.ToInt32(odr["COUNT"]);
                        //}

                    }

                }
            }
            catch (Exception E)
            {

                throw new ApplicationException(E.Message);
            }
            return Status;
        }


        public IList<CRM_OA_OPINION> ReadOpinion(long ID)
        {
            OracleParameter[] parms = {
                                          new OracleParameter(":ID",ID)
                                      };

            IList<CRM_OA_OPINION> nodes = new List<CRM_OA_OPINION>();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_ReadOpinion, parms))
                {
                    while (odr.Read())
                    {
                        nodes.Add(ReadDataToListObj(odr));
                    }

                }
            }
            catch (Exception E)
            {

                throw new ApplicationException(E.Message);
            }
            return nodes;
        }



        public int ReadOABPMStatus(long ID)
        {
            OracleParameter[] parms = {
                                          new OracleParameter(":ID",ID)
                                      };
            int count = 0;
            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, SQL_ReadBPMStatus, parms))
                {
                    if (odr.Read())
                    {
                        count = Convert.ToInt32(odr["COUNT"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return count;
        }

        public void UpdateDataSource(long ID, int OACSLB)            //更改OA表单中的数据来源字段
        {
            OracleParameter[] parms = {
                                          new OracleParameter(":ID",ID)
                                      };
            string sql = "";
            if (OACSLB == 92)
            {
                sql = SQL_Updateformmain_1827;
            }
            else if (OACSLB == 93 || OACSLB == 1083)
            {
                //if (OAZT == 1)
                //{
                sql = SQL_Updateformmain_1843;
                //}
                //else
                //{
                //    sql = SQL_Updateformmain_1857;
                //}

            }
            else if (OACSLB == 105)
            {
                sql = SQL_Updateformmain_1857;
            }
            else if (OACSLB == 551)
            {
                sql = SQL_Updateformmain_1882;
            }
            else if (OACSLB == 921)
            {
                sql = SQL_Updateformmain_1861;
            }
            else if (OACSLB == 922)
            {
                sql = SQL_Updateformmain_1865;
            }
            else if (OACSLB == 923)
            {
                sql = SQL_Updateformmain_1874;
            }
            else if (OACSLB == 104)
            {
                sql = SQL_Updateformmain_1879;
            }
            else if (OACSLB == 990)
            {
                sql = SQL_Updateformmain_1915;
            }
            else if (OACSLB == 1313)
            {
                sql = SQL_Updateformmain_2482;
            }
            else if (OACSLB == 1360)
            {
                sql = SQL_Updateformmain_2465;
            }
            else if (OACSLB == 1361)
            {
                sql = SQL_Updateformmain_2461;
            }
            else if (OACSLB == 1362)
            {
                sql = SQL_Updateformmain_2434;
            }
            else if (OACSLB == 2014)
            {
                sql = SQL_Updateformmain_2467;
            }
            else if (OACSLB == 2015 || OACSLB == 2021)
            {
                sql = SQL_Updateformmain_2575;
            }
            else if (OACSLB == 2022)
            {
                sql = SQL_Updateformmain_2577;
            }
            else if (OACSLB == 2023 || OACSLB == 4120)
            {
                sql = SQL_Updateformmain_2581;
            }
            else if (OACSLB == 2024 || OACSLB == 4121)
            {
                sql = SQL_Updateformmain_2584;
            }
            else if (OACSLB == 2027)
            {
                sql = SQL_Updateformmain_2612;
            }
            else if (OACSLB == 2066 || OACSLB == 2079)
            {
                sql = SQL_Updateformmain_2983;
            }
            //int Status = 0;
            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(Connection.connectionString, CommandType.Text, sql, parms))
                {
                    //if (odr.Read())
                    //{
                    //    //if (odr["FINISHEDFLAG"] != null)
                    //    //{
                    //    Status = Convert.ToInt32(odr["FINISHEDFLAG"]);
                    //    //}

                    //}

                }
            }
            catch (Exception E)
            {

                throw new ApplicationException(E.Message);
            }
        }

        private CRM_OA_OPINION ReadDataToListObj(OracleDataReader sdr)
        {
            CRM_OA_OPINION node = new CRM_OA_OPINION();
            node.SPRNAME = Convert.ToString(sdr["NAME"]);
            node.SPRNO = Convert.ToString(sdr["NO"]);
            node.SPSJ = Convert.ToString(sdr["TIME"]);
            node.OPINION = Convert.ToString(sdr["CONTENT"]);
            node.ATTITUDE = ShowAttitude(Convert.ToString(sdr["EXT_ATT1"]));
            return node;
        }

        private string ShowAttitude(string str)
        {
            if (str == null)
            {
                return "";
            }
            else
            {
                switch (str)
                {
                    case "collaboration.dealAttitude.agree":
                        return "同意";
                    case "collaboration.dealAttitude.disagree":
                        return "不同意";
                    case "collaboration.dealAttitude.haveRead":
                        return "已阅";
                    default:
                        return str;
                }
            }
        }


    }
}
