using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.PP;
using Sonluk.Entities.QM;
using Sonluk.Entities.System;
using Sonluk.IDataAccess.QM;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.QM
{
    public class QualityNotification : IQualityNotification
    {
        public MessageInfo Create(QNInfo node)
        {
            throw new NotImplementedException();
        }

        public MessageInfo CreateQ1(QNInfo node)
        {
            IRfcFunction func = RFC.Function("ZSL_QMFM_004");
            func.SetValue("I_ZKHTSPSBH", node.FlowSerialNumber);
            func.SetValue("I_ZCPMC", node.Product);
            func.SetValue("I_ZTXRQ", node.Date);
            func.SetValue("I_ZKHMC", node.Customer);
            func.SetValue("I_ZXH", node.Model);
            func.SetValue("I_ZSFTH", node.ReturnOrExchange);
            func.SetValue("I_ZTSWTMS", node.Complain);
            func.SetValue("I_ZYWBM", node.SalesDepartment);
            func.SetValue("I_ZYWY", node.Sales);
            func.SetValue("I_ZSDYPRQ", node.ReceiveDate);
            func.SetValue("I_ZDCSL", node.Quantity.ToString());
            func.SetValue("I_ZPCJE", node.Compensate);
            func.SetValue("I_ZSFYZSBG", node.Report);
            func.SetValue("I_ZTSSFGB", node.Closed);
            func.SetValue("I_ZSFWG", node.Outsourcing);
            func.SetValue("I_UNAME", node.Creator);

            IRfcTable importTableProducts = func.GetTable("IT_FWG");
            int index = 0;
            foreach (ProductInfo item in node.Products)
            {
                importTableProducts.Append(1);
                importTableProducts.CurrentIndex = index++;
                importTableProducts.SetValue("ZXHF", item.SerialNumber);
                importTableProducts.SetValue("ZTSLBF", item.ComplainType);
                importTableProducts.SetValue("ZTSWTMSF", item.Complain);
                importTableProducts.SetValue("ZSJDSSLF", item.Quantity.ToString());
                importTableProducts.SetValue("ZRQMF", item.Mark);
                importTableProducts.SetValue("ZSCXF", item.ProducingLine);
                importTableProducts.SetValue("ZSCRQF", item.ProducingDate);
                importTableProducts.SetValue("ZDCDJF", item.Level);
                importTableProducts.SetValue("ZTDCJF", item.CopperNailVendor);
                importTableProducts.SetValue("ZTDDDCJF", item.CopperNailPlater);
                importTableProducts.SetValue("ZTDPHF", item.CopperNailBatch);
                importTableProducts.SetValue("ZMFQCJF", item.SealCircleVendor);
                importTableProducts.SetValue("ZMFQCHF", item.SealCircleLathe);
                importTableProducts.SetValue("ZMFQPHF", item.SealCircleBatch);
                importTableProducts.SetValue("ZGKCJF", item.SteelShellVendor);
                importTableProducts.SetValue("ZGKPHF", item.SteelShellBatch);
                importTableProducts.SetValue("ZZJF", item.PositivePole);
                importTableProducts.SetValue("ZFJF", item.NegativePole);
                importTableProducts.SetValue("ZBBRQF", item.PackageDate);
                importTableProducts.SetValue("ZYYF", item.Reason);
                importTableProducts.SetValue("ZBZF", item.Remark);
                importTableProducts.SetValue("ZTSSFYXF", item.ComplainAvailable);
                importTableProducts.SetValue("ZGKCHF", item.GKCH);
                importTableProducts.SetValue("ZCHF", item.ZCHF);
            }
            IRfcTable importTableOutsourcings = func.GetTable("IT_WG");
            index = 0;
            foreach (ProductInfo item in node.Outsourcings)
            {
                importTableOutsourcings.Append(1);
                importTableOutsourcings.CurrentIndex = index++;
                importTableOutsourcings.SetValue("ZXHW", item.SerialNumber);
                importTableOutsourcings.SetValue("ZTSLXW", item.ComplainType);
                importTableOutsourcings.SetValue("ZTSWTMSW", item.Complain);
                importTableOutsourcings.SetValue("ZSJDSSLW", item.Quantity.ToString());
                importTableOutsourcings.SetValue("ZRQMW", item.Mark);
                importTableOutsourcings.SetValue("ZGYSW", item.Vendor);
                importTableOutsourcings.SetValue("ZSCRQW", item.ProducingDate);
                importTableOutsourcings.SetValue("ZYYW", item.Reason);
                importTableOutsourcings.SetValue("ZBZW", item.Remark);
                importTableOutsourcings.SetValue("ZTSSFYXW", item.ComplainAvailable);
            }
            MessageInfo message = new MessageInfo();

            try
            {
                RFC.Invoke(func, true);
                string code = func.GetString("O_REN");
                if (code.Equals("S"))
                {
                    message.Status = 2;
                    message.Key = func.GetString("O_QMNUM");
                }
                else
                {
                    message.Status = 1;
                }
                message.Value = func.GetString("O_MESSAGE");
                Console.WriteLine(message.Value);
            }
            catch (Exception e)
            {
                message.Value = e.Message;
                throw new ApplicationException(e.Message);
            }
            return message;
        }

        public MessageInfo Update(QNInfo node)
        {
            throw new NotImplementedException();
        }

        public MessageInfo UpdateZ3(QNInfo node)
        {
            IRfcFunction func = RFC.Function("ZSL_QMFM_003");
            func.SetValue("I_QMNUM", node.SerialNumber);
            func.SetValue("I_MGFRD", node.DefectiveQtyExternal);
            func.SetValue("I_ANZFEHLER", node.Defects);
            func.SetValue("I_MGEIG", node.DefectiveQtyInternal);
            func.SetValue("I_PRUEFLINR", node.SingleUnitToBeInspected);
            func.SetValue("I_FETXT", node.Remark);
            func.SetValue("I_REFNUM", node.ExternalReference);
            func.SetValue("I_MATXT01", node.Department);
            func.SetValue("I_MATXT02", node.ResponsibleDept);
            func.SetValue("I_LONG", node.Disqualification);
            func.SetValue("I_MATXT11", node.Review);
            func.SetValue("I_MATXT12", node.Rework);
            func.SetValue("I_UNAME", node.Creator);

            IRfcTable importTable = func.GetTable("IT_ITEM");
            int index = 0;
            foreach (QNItemInfo item in node.Items)
            {
                importTable.Append(1);
                importTable.CurrentIndex = index++;
                importTable.SetValue("URGRP", item.CodeGroup);
                importTable.SetValue("URCOD", item.CauseCode);
                importTable.SetValue("URTXT", item.CauseDescription);
            }
            MessageInfo message = new MessageInfo();

            try
            {
                RFC.Invoke(func, true);
                string code = func.GetString("O_REN");
                if (code.Equals("S"))
                {
                    message.Status = 2;
                }
                else
                {
                    message.Status = 1;
                }
                message.Value = func.GetString("O_MESSAGE");
                Console.WriteLine(message.Value);
            }
            catch (Exception e)
            {
                message.Value = e.Message;
                throw new ApplicationException(e.Message);
            }
            return message;
        }

        public MessageInfo UpdateZ2(QNInfo node)
        {
            IRfcFunction func = RFC.Function("ZSL_QMFM_001");
            func.SetValue("I_QMNUM", node.SerialNumber);
            func.SetValue("I_IDNLF", node.Model);
            func.SetValue("I_CGBM", node.PurchaseDepartment);
            func.SetValue("I_PSYJ", node.Review);
            func.SetValue("I_FGYJ", node.Rework);
            func.SetValue("I_UNAME", node.Creator);

            MessageInfo message = new MessageInfo();
            try
            {
                RFC.Invoke(func, true);
                string code = func.GetString("O_RESULT");
                if (code.Equals("S"))
                {
                    message.Status = 2;
                }
                else
                {
                    message.Status = 1;
                }
                message.Value = func.GetString("O_REASON");
                Console.WriteLine(message.Value);
            }
            catch (Exception e)
            {
                message.Value = e.Message;
                throw new ApplicationException(e.Message);
            }
            return message;
        }

        public MessageInfo Update(string serialNumber, string creator)
        {
            IRfcFunction func = RFC.Function("ZSL_QMFM_007");
            func.SetValue("I_QMNUM", serialNumber);
            func.SetValue("I_UNAME", creator);

            MessageInfo message = new MessageInfo();
            try
            {
                RFC.Invoke(func, true);
                string code = func.GetString("O_REN");
                if (code.Equals("S"))
                {
                    message.Status = 2;
                }
                else
                {
                    message.Status = 1;
                }
                message.Value = func.GetString("O_MESSAGE");
                Console.WriteLine(message.Value);
            }
            catch (Exception e)
            {
                message.Value = e.Message;
                throw new ApplicationException(e.Message);
            }
            return message;
        }

        public IList<QNInfo> Read()
        {
            throw new NotImplementedException();
        }

        public IList<QNInfo> Read(string type)
        {
            throw new NotImplementedException();
        }

        public IList<QNInfo> ReadZ2()
        {
            IList<QNInfo> nodes = new List<QNInfo>();
            IRfcFunction func = RFC.Function("ZSL_QMFM_005");

            try
            {

                IDictionary<string, int> nodesDictionary = new Dictionary<string, int>();

                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("IT_Z2");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    QNInfo node = new QNInfo();
                    node.SerialNumber = table.GetString("QMNUM");
                    node.Material = table.GetString("MATNR");
                    node.MaterialDescription = table.GetString("MAKTX");
                    node.Vendor = table.GetString("NAME1");
                    node.Batch = table.GetString("CHARG");
                    if (!table.GetString("RKMNG").Equals(""))
                        node.Quantity = table.GetDecimal("RKMNG");
                    if (!table.GetString("MGFRD").Equals(""))
                        node.Sampling = table.GetDecimal("MGFRD");
                    if (!table.GetString("MGEIG").Equals(""))
                        node.DisqualifiedQty = table.GetDecimal("MGEIG");
                    node.Unit = table.GetString("ZMEINS");
                    node.Date = table.GetString("STRMN");
                    node.VendorDevice = table.GetString("DEVICEID");
                    node.Disqualification = table.GetString("ZBZ");
                    node.Creator = table.GetString("INITS");
                    node.Items = new List<QNItemInfo>();
                    nodes.Add(node);

                    nodesDictionary.Add(node.SerialNumber, i);
                }

                IRfcTable tableItems = func.GetTable("IT_CA");
                for (int i = 0; i < tableItems.RowCount; i++)
                {
                    tableItems.CurrentIndex = i;

                    QNItemInfo node = new QNItemInfo();
                    node.SerialNumber = tableItems.GetString("QMNUM");
                    node.DefectType = tableItems.GetString("KURZTEXT");
                    node.DefectReason = tableItems.GetString("KUQTXT");
                    if (!tableItems.GetString("ANZFEHLER").Equals(""))
                        node.DefectQty = tableItems.GetInt("ANZFEHLER");

                    if (nodesDictionary.ContainsKey(node.SerialNumber))
                    {
                        nodes[nodesDictionary[node.SerialNumber]].Items.Add(node);
                    }
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<QNInfo> ReadZ3()
        {
            IList<QNInfo> nodes = new List<QNInfo>();
            IRfcFunction func = RFC.Function("ZSL_QMFM_006");

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("IT_Z3");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    QNInfo node = new QNInfo();
                    node.SerialNumber = table.GetString("QMNUM");
                    node.Material = table.GetString("MATNR");
                    node.MaterialDescription = table.GetString("MAKTX");
                    node.Vendor = table.GetString("NAME1");
                    node.VendorDevice = table.GetString("DEVICEID");
                    node.SemiFinishedStartingDate = table.GetString("AUSVN");
                    node.SemiFinishedEndDate = table.GetString("AUSBS");
                    node.Date = table.GetString("STRMN");
                    node.Creator = table.GetString("INITS");
                    node.Unit = table.GetString("MEINS");
                    node.DefectType = table.GetString("KURZTEXT");
                    nodes.Add(node);
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
