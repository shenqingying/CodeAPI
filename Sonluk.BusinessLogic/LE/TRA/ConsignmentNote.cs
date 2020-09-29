using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Sonluk.BusinessLogic.Master;
using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE;
using Sonluk.IDataAccess.LE.TRA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class ConsignmentNote
    {
        private static readonly IConsignmentNote _DetaAccess = LETRADataAccess.CreateConsignmentNote();
        private static readonly ICity _CityDetaAccess = LETRADataAccess.CreateCity();
        private static readonly IRoute _RouteDetaAccess = LETRADataAccess.CreateRoute();
        private static readonly IOutboundDelivery _DeliverydetaAccess = LEDataAccess.CreateOutboundDelivery();
        public int Exists(int ID)
        {
            return _DetaAccess.Exists(ID);
        }

        public int Exists(string serialNumber)
        {
            return _DetaAccess.Exists(serialNumber, 3);
        }

        public int Record(string serialNumber, int ID)
        {
            int success = 0;
            try
            {
                success = _DetaAccess.Record(serialNumber, ID);
            }
            catch
            {

            }
            return success;
        }

        public IList<CNDeliveryInfo> CNDeliveryUPDATE(string serialNumber, int TYDID, int STATUS, string FILLNAME, string FILLID)
        {
            _DetaAccess.JHDUPDATE(serialNumber, TYDID, STATUS, FILLNAME, FILLID);
            return _DetaAccess.ReadCNDelivery(serialNumber);
        }

        public IList<CNInfo> Read(CNInfo keywords)
        {
            return _DetaAccess.Read(keywords);
        }

        public IList<CNDeliveryInfo> ReadCNDeliveryByID(int ID)
        {
            return _DetaAccess.ReadCNDeliveryByID(ID);
        }

        public IList<CNDeliveryInfo> ReadCNDelivery(string serialNumber)
        {
            return _DetaAccess.ReadCNDelivery(serialNumber);
        }

        public CNInfo Read(int ID)
        {
            CNInfo node;
            if (ID > 0)
            {
                node = _DetaAccess.Read(ID);
                ConsignmentNoteItem itemBL = new ConsignmentNoteItem();
                node.Items = itemBL.Read(ID).ToList();

                OutboundDelivery odBL = new OutboundDelivery();
                if (odBL.UnLoad(node.Delivery) == 1)
                {
                    node.Unload = "提供卸货";

                }
                if (node.Instruction.Contains("提供卸货") && node.TransitCost == 0)
                {
                    for (int i = 0; i < node.Items.Count; i++)
                    {
                        node.Items[i].TransitCost = Convert.ToDecimal(node.Items[i].Total * 0.5);
                    }
                }
            }
            else
            {
                node = new CNInfo();
                node.Date = DateTime.Now.ToString("yyyy-MM-dd");
                Carrier carrierBL = new Carrier();
                node.Carrier = (carrierBL.Read())[0];
                node.Number = CurrentNumber(node.Carrier.ID);
                Sender senderBL = new Sender();
                node.Sender = (senderBL.Read())[0];
                City cityBL = new City();
                node.Source = cityBL.Read(node.Sender.CityID);
                node.Destination = new CityInfo();
                node.Receiver = new CompanyInfo();
                node.Items = new List<CNItemInfo>();
            }

            return node;
        }

        public IList<CNInfo> Report(CNInfo keywords)
        {
            return _DetaAccess.Report(keywords);
        }

        public string CurrentNumber(int carrierID)
        {
            string raw = _DetaAccess.CurrentNumber(carrierID);
            int count = raw.Length;
            string code = "";
            string tempString = "";
            int temp = 0;
            bool finish = false;
            bool carry = false;
            for (int i = count - 1; i >= 0; i--)
            {
                if (finish)
                    break;
                tempString = raw.Substring(i, 1);
                raw = raw.Substring(0, i);
                if (Int32.TryParse(tempString, out temp))
                {
                    if (temp == 9)
                    {
                        temp = 0;
                        carry = true;
                    }
                    else
                    {
                        temp++;
                        finish = true;
                    }
                    tempString = temp.ToString();
                }
                else
                {
                    if (carry)
                        finish = true;
                }
                code = tempString + code;
            }
            code = raw + code;
            return code;
        }

        public CNInfo Generate(List<string> deliverySet, int carrier, bool replace)
        {
            CNInfo node = new CNInfo();
            string serialNum = "", khbh = "";//zwk 取第一个交货单的相关地址信息 2020-05-11 
            try
            {
                node.Date = DateTime.Now.ToString("yyyy-MM-dd");

                Carrier carrierBL = new Carrier();
                node.Carrier = carrierBL.Read(carrier);
                node.Number = CurrentNumber(node.Carrier.ID);

                Sender senderBL = new Sender();
                node.Sender = (senderBL.Read())[0];
                City cityBL = new City();
                node.Source = cityBL.Read(node.Sender.CityID);
                string destinationCity = "";
                string SDaddress = "";
                string SDContact = "";
                string SDContactTelephone = "";
                string customer = "";
                string SerialNumber = "";
                decimal weight = 0m;
                string SalesOrganization = "";

                node.DeliveryCount = 0;
                node.Delivery = "";
                OutboundDelivery odBL = new OutboundDelivery();
                DeliveryInfo keywords = new DeliveryInfo();
                keywords.SerialNumberSet = deliverySet;
                keywords.Status = "0";
                IList<DeliveryInfo> deliveryList = odBL.Read(keywords);
                int page = 0;
                int pageLine = 0;

                IDictionary<int, int> goodsTypeDictionary = new Dictionary<int, int>();
                node.Items = new List<CNItemInfo>();
                Goods goodsBL = new Goods();
                Package packageBL = new Package();

                node.ID = 0;
                foreach (DeliveryInfo delivery in deliveryList)
                {
                    if (replace && node.ID == 0)
                    {
                        node.ID = Exists(delivery.SerialNumber);
                        if (node.ID > 0)
                            node.SerialNumber = (Read(node.ID)).SerialNumber;
                    }

                    IList<DeliveryItemInfo> items = odBL.ItemRead(delivery.SerialNumber);
                    serialNum = delivery.SerialNumber;//zwk 取第一个交货单的相关地址信息 2020-05-11 
                    customer = delivery.ShipToParty;
                    destinationCity = delivery.City;
                    SDaddress = delivery.StoreLocation;
                    SDContact = delivery.Contact;
                    SDContactTelephone = delivery.ContactTelephone;

                    SerialNumber = delivery.SerialNumber;
                    node.Instruction = delivery.Remark;
                    SalesOrganization = delivery.SalesOrganization;


                    if (!delivery.BillOfLoading.Equals("") || !delivery.StoreLocation.Equals("") || !delivery.Contact.Equals("") || !delivery.ContactTelephone.Equals(""))
                        node.Remark = node.Remark + "[交货单]:" + delivery.SerialNumber + "[进仓编号]:" + delivery.BillOfLoading + "[仓库地址]:" + delivery.StoreLocation + "[联系人]:" + delivery.Contact + "[联系电话]:" + delivery.ContactTelephone;
                    int itemCount = items.Count;
                    foreach (DeliveryItemInfo item in items)
                    {
                        if (item.BatchSplit > 0)
                            itemCount--;
                        GoodsInfo goods = goodsBL.Read(item.Material);
                        int index = 0;
                        if (!goodsTypeDictionary.ContainsKey(goods.TypeID))
                        {
                            index = goodsTypeDictionary.Count;
                            goodsTypeDictionary.Add(goods.TypeID, index);
                            CNItemInfo newItem = new CNItemInfo();
                            newItem.GoodsType = goods;
                            newItem.PackageType = packageBL.Type(1);
                            node.Items.Add(newItem);
                        }
                        else
                        {
                            index = goodsTypeDictionary[goods.TypeID];
                        }

                        CNItemInfo cnItem = node.Items[goodsTypeDictionary[goods.TypeID]];
                        cnItem.Whole = cnItem.Whole + item.Whole;
                        if (item.Odd > 0)
                            cnItem.Odd = cnItem.Odd + 1;
                        cnItem.Weight = cnItem.Weight + item.Whole * item.SingleWeight;
                        weight = weight + item.Whole * item.SingleWeight;
                        //Logger.Write("BusinessLogic.LE.TRA.Generate", cnItem.Volume.ToString() + "=" + item.Whole.ToString() + "X" + item.SingleVolume.ToString() + "=" + (item.Whole * item.SingleVolume).ToString());
                        cnItem.Volume = cnItem.Volume + item.Whole * item.SingleVolume;

                    }

                    if (delivery.SerialNumber.IndexOf("84") == 0)
                        pageLine = 6;
                    else
                        pageLine = 7;
                    page = (itemCount + pageLine - 1) / pageLine;
                    node.Delivery = node.Delivery + delivery.SerialNumber + "-" + page + "/";
                    node.DeliveryCount = node.DeliveryCount + page;
                }

                node.Destination = cityBL.Read(destinationCity);
                Receiver receiverBL = new Receiver();
                khbh = customer;
                if (node.Destination.ID > 0)
                {
                    node.Receiver = receiverBL.Read(customer, node.Destination.ID);
                    if (node.Receiver.ID < 1)
                    {
                        receiverBL.Create(customer);
                        node.Receiver = receiverBL.Read(customer, node.Destination.ID);
                    }
                }
                else
                {
                    node.Receiver = receiverBL.Read(customer);
                    if (node.Receiver.ID < 1)
                    {
                        receiverBL.Create(customer);
                        node.Receiver = receiverBL.Read(customer);
                    }
                    node.Destination = cityBL.Read(node.Receiver.CityID);
                }
                //外销的从仓库信息中取地址信息，内销的在客户信息中取相关信息 zwk 2020-05-11
                if (SalesOrganization == "1400" || SalesOrganization == "2200" || SalesOrganization == "5200")//ZSPLIKPSINGLE
                {
                    DeliveryInfo deliveryNode = _DeliverydetaAccess.Read(serialNum, "0");

                    //node.Receiver.Address = SDaddress;
                    //node.Receiver.Contact = SDContact;
                    //node.Receiver.Telephone = SDContactTelephone;
                    node.Receiver.Address = deliveryNode.StoreLocation;
                    node.Receiver.Contact = deliveryNode.Contact;
                    node.Receiver.Telephone = deliveryNode.ContactTelephone;
                    node.Receiver.Name = "   ";
                    node.Receiver.Cellphone = "";
                }
                else
                {
                    Customer customerBL = new Customer();
                    CompanyGeneralInfo raw = (customerBL.Read(khbh)).General[0];
                    node.Receiver.Address = raw.HouseNumberAndStreet;
                    //node.Receiver.Contact = raw.FirstTelephoneNumber;
                    //node.Receiver.Telephone = SDContactTelephone;
                    //node.Receiver.Name = "   ";
                    //node.Receiver.Cellphone = "";
                }

                Route routeBL = new Route();
                RouteInfo route = routeBL.Read(node.Source.ID, node.Destination.ID, weight, node.Date);
                if (weight < 2000)
                {
                    node.ZSCost = Convert.ToDecimal(routeBL.ReadZSF(node.Source.ID, node.Destination.ID));
                }
                node.UnitPrice = route.Price;
                node.DeliveryDate = route.Arrival;
                for (int i = 0; i < node.Items.Count; i++)
                {
                    node.Items[i].Total = node.Items[i].Whole + node.Items[i].Odd;
                    node.Items[i].Cost = node.UnitPrice * node.Items[i].Weight;
                    if (odBL.UnLoad(node.Delivery) == 1)
                    {
                        node.Items[i].TransitCost = Convert.ToDecimal(node.Items[i].Total * 0.5);
                    }
                }

            }
            catch (Exception e)
            {
                Logger.Write("BusinessLogic.LE.TRA.Generate", e.Message);
                node.ID = -1;
            }
            return node;
        }

        public int Create(CNInfo node)
        {
            if (node.Carrier == null)
                node.Carrier = new CompanyInfo();
            if (node.Sender == null)
                node.Sender = new CompanyInfo();
            if (node.Receiver == null)
                node.Receiver = new CompanyInfo();
            if (node.Source == null)
                node.Source = new CityInfo();
            if (node.Destination == null)
                node.Destination = new CityInfo();

            int ID = _DetaAccess.Create(node);

            if (ID > 0 && node.Items != null)
            {
                ConsignmentNoteItem itemBL = new ConsignmentNoteItem();
                for (int i = 0; i < node.Items.Count; i++)
                {
                    if (node.Items[i].Total > 0)
                    {
                        node.Items[i].ID = i + 1;
                        node.Items[i].Header = ID;
                        node.Items[i].UnitPrice = node.UnitPrice;
                        itemBL.Create(node.Items[i]);
                    }
                }

                if (node.Delivery != null && !node.Delivery.Equals(""))
                {
                    OutboundDelivery odBL = new OutboundDelivery();
                    IList<string> numberSet = SplitDeliverySet(node.Delivery);

                    Regex reg = new Regex(@"^8[0-9]{7}$");
                    foreach (string number in numberSet)
                    {
                        if (reg.IsMatch(number))
                        {
                            Record(number, ID);
                            odBL.Update(number, ID);
                        }
                    }
                }
            }

            return ID;
        }

        public bool Update(CNInfo node)
        {
            bool success = _DetaAccess.Update(node);
            if (success)
            {
                ConsignmentNoteItem itemBL = new ConsignmentNoteItem();
                for (int i = 0; i < node.Items.Count; i++)
                {
                    if (node.Items[i].Total > 0)
                    {
                        node.Items[i].ID = i + 1;
                        node.Items[i].Header = node.ID;
                        node.Items[i].UnitPrice = node.UnitPrice;
                        itemBL.Create(node.Items[i]);
                    }
                }
            }

            return success;
        }

        public int Delete(int ID)
        {
            return _DetaAccess.Delete(ID);
        }

        public MemoryStream Export(string type, List<CNInfo> nodes)
        {
            MemoryStream memoryStream = new MemoryStream();
            IWorkbook workbook;
            string templetPath = AppDomain.CurrentDomain.BaseDirectory;
            switch (type)
            {
                case "List": templetPath = templetPath + "/Templet/ConsignmentNote.xls"; break;
                case "Report": templetPath = templetPath + "/Templet/ConsignmentNoteReport.xls"; break;
                case "Msg": templetPath = templetPath + "/Templet/ConsignmentNoteMsg.xls"; break;
                case "Feedback": templetPath = templetPath + "/Templet/ConsignmentNoteCost.xls"; break;
            }

            using (FileStream fs = File.OpenRead(templetPath))
            {
                workbook = WorkbookFactory.Create(fs);
            }
            ISheet sheet = workbook.GetSheetAt(0);
            int rowIndex = 1;
            string mark = "●";
            switch (type)
            {
                case "List":
                    {
                        foreach (CNInfo node in nodes)
                        {
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            row.CreateCell(cellIndex++).SetCellValue(node.ID);
                            row.CreateCell(cellIndex++).SetCellValue(node.Carrier.Name);
                            row.CreateCell(cellIndex++).SetCellValue(node.Date);
                            row.CreateCell(cellIndex++).SetCellValue(node.DeliveryDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.SerialNumber);
                            row.CreateCell(cellIndex++).SetCellValue(node.Total);
                            row.CreateCell(cellIndex++).SetCellValue(node.Source.Name);
                            row.CreateCell(cellIndex++).SetCellValue(node.Destination.Name);
                            row.CreateCell(cellIndex++).SetCellValue(node.FeedbackRecord ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.ComplaintRecord ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.Sender.Name);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.ShortName);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.Name);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.Address);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.Contact);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.Telephone);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.Cellphone);
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Weight));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Volume)); //Add by xsw
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.UnitPrice));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Cost));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Insurance));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.DirectCost));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.TransitCost));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.OtherCost));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.TotalCost));
                            row.CreateCell(cellIndex++).SetCellValue(node.Compensation);
                            row.CreateCell(cellIndex++).SetCellValue(node.DefaultArrivalLimit);
                            row.CreateCell(cellIndex++).SetCellValue(node.DeliveryCount);
                            row.CreateCell(cellIndex++).SetCellValue(node.InvoiceCount);
                            row.CreateCell(cellIndex++).SetCellValue(node.CertificationCount);
                            row.CreateCell(cellIndex++).SetCellValue(node.Delivery);
                            row.CreateCell(cellIndex++).SetCellValue(node.Instruction);
                            row.CreateCell(cellIndex++).SetCellValue(node.Remark);
                            row.CreateCell(cellIndex++).SetCellValue(node.PickUpByReceiver ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.HomeDelivery ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.PickUpByCertificate ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.PickUpByFax ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.Feedback ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.DeliveryFeedback ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.Stamp ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.Dispatch ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.Requirement);
                            row.CreateCell(cellIndex++).SetCellValue(node.Status);
                            row.CreateCell(cellIndex++).SetCellValue(node.Number);
                            row.CreateCell(cellIndex++).SetCellValue(node.Creator);
                            row.CreateCell(cellIndex++).SetCellValue(node.CreateDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.JHDFK ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.JHDWHLIST);

                        }
                        break;
                    }
                case "Report":
                    {
                       
                        foreach (CNInfo node in nodes)
                        {
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            row.CreateCell(cellIndex++).SetCellValue(node.ID);
                            row.CreateCell(cellIndex++).SetCellValue(node.Carrier.Name);
                            row.CreateCell(cellIndex++).SetCellValue(node.Date);
                            row.CreateCell(cellIndex++).SetCellValue(node.DeliveryDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.Sum[0]);
                            row.CreateCell(cellIndex++).SetCellValue(node.Sum[1]);
                            row.CreateCell(cellIndex++).SetCellValue(node.Sum[2]);
                            row.CreateCell(cellIndex++).SetCellValue(node.Sum[3]);
                            row.CreateCell(cellIndex++).SetCellValue(node.Total);
                            row.CreateCell(cellIndex++).SetCellValue(node.Destination.Name);
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Weight));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Volume)); //Add by xsw
                            row.CreateCell(cellIndex++).SetCellValue(node.Instruction);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.Address);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.Contact);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.Telephone);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.Cellphone);
                            row.CreateCell(cellIndex++).SetCellValue(node.Creator);
                            row.CreateCell(cellIndex++).SetCellValue(node.Delivery);

                        }
                        break;

                    }
                case "Msg":
                    {
                        rowIndex = 0;
                       
                        foreach (CNInfo node in nodes)
                        {                       
                            if (string.IsNullOrWhiteSpace(node.Receiver.Cellphone))
                            {
                                continue;
                            }
                            if (node.Receiver.Cellphone.Trim().Length != 11)
                            {
                                continue;
                            }
                            try
                            {
                                long.Parse(node.Receiver.Cellphone);
                            }
                            catch (Exception)
                            {
                                continue;
                            }                           
                            string cell2 = node.Receiver.Contact + "先生，您的" + node.Destination.Name + "货物" +
                                            node.Total.ToString() + "件预计于" + node.Date +
                                            node.Carrier.Name + "物流出运，预计" + node.DeliveryDate +
                                            "到达，如有疑问请及时联系我们！服务电话 0574-83887727（周一~~周六8:00--16:42）【中银(宁波)电池有限公司】";
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.Cellphone);
                            row.CreateCell(cellIndex++).SetCellValue(cell2);                      

                        }
                        break;
                    }
                case "Feedback":
                    {
                      
                        ICellStyle colorStyle = workbook.CreateCellStyle();
                        HSSFFont ffont = (HSSFFont)workbook.CreateFont();
                        ffont.Color = 10;
                        ffont.FontHeightInPoints = 11;
                        
                        colorStyle.SetFont(ffont);
                        colorStyle.FillPattern = (FillPattern)1;
                        colorStyle.FillForegroundColor = 13;
                        RouteInfo jgList = _RouteDetaAccess.Read(41);
                        Price priceBL = new Price();
                        jgList.Prices = priceBL.Read(jgList.ID).ToList();
                        List<CityInfo> cityList = _CityDetaAccess.ReadByExcelCity().ToList();
                        string ZJ = "浙江";
                        string GD = "广东";
                        string WXP = "危险品";
                        //nodes = (from o in nodes orderby o.Date, o.Destination.Name, o.Receiver.Name select o).ToList();
                        nodes = nodes.OrderBy(p => p.Date).ThenBy(p=>p.Destination.Name).ThenBy(p=>p.Receiver.Name).ToList();
                        for (int i = 0; i < nodes.Count; i++)
                        {
                            CNInfo node = nodes[i];
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            row.CreateCell(cellIndex++).SetCellValue(node.ID);
                            row.CreateCell(cellIndex++).SetCellValue(node.Date);
                            if (node.Destination.Name.Equals("北仑"))
                            {
                                ICell cell = row.CreateCell(cellIndex++);
                                cell.SetCellValue(node.Receiver.Name);
                                if (node.TYLB == 3)
                                {
                                    cell.CellStyle = colorStyle;
                                }
                                
                            }
                            else
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.Destination.Name);
                            }

                            row.CreateCell(cellIndex++).SetCellValue("电池");
                            row.CreateCell(cellIndex++).SetCellValue(node.Total);
                            double w = Convert.ToDouble(node.Weight);
                            double v = Convert.ToDouble(node.Volume);
                            double u = Convert.ToDouble(node.UnitPrice);
                            double fy = (w + v * 0.004) * u;
                            row.CreateCell(cellIndex++).SetCellValue(w);
                            row.CreateCell(cellIndex++).SetCellValue(v);
                            row.CreateCell(cellIndex++).SetCellValue(u);
                            bool iscalc = true;
                            if (node.Carrier != null)
                            {
                                if (node.Carrier.Name.Equals("城市配送")||node.Carrier.Name.Equals("自提"))
                                {
                                    double zero = 0;
                                    row.CreateCell(cellIndex++).SetCellValue(zero);
                                    row.CreateCell(cellIndex++).SetCellValue(zero);
                                    row.CreateCell(cellIndex++).SetCellValue(zero);
                                    row.CreateCell(cellIndex++).SetCellValue(zero);
                                    row.CreateCell(cellIndex++).SetCellValue(zero);
                                    iscalc = false;
                                }
                            }
                            if (iscalc)
                            {
                                if (node.Destination.Name.Equals("北仑"))
                                {
                                    //逻辑处理
                                    int ksIndex = nodes.FindIndex(p => p.Receiver.Name == node.Receiver.Name && p.Date == node.Date);
                                    int jsIndex = nodes.FindLastIndex(p => p.Receiver.Name == node.Receiver.Name && p.Date == node.Date);
                                    double total = 0;
                                    double weight = 0;
                                    for (int j = ksIndex; j < jsIndex + 1; j++)
                                    {
                                        double w1 = Convert.ToDouble(nodes[j].Weight);
                                        double v1 = Convert.ToDouble(nodes[j].Volume);
                                        double u1 = Convert.ToDouble(nodes[j].UnitPrice);
                                        weight += Convert.ToDouble(nodes[j].Weight);
                                        total += (w1 + v1 * 0.004) * u1;
                                    }
                                    if (!string.IsNullOrEmpty(node.Instruction))
                                    {
                                        if (node.Instruction.IndexOf(WXP) > -1)
                                        {
                                            if (i == ksIndex)
                                            {
                                                row.CreateCell(cellIndex++).SetCellValue(1800);
                                            }
                                            else
                                            {
                                                row.CreateCell(cellIndex++).SetCellValue(0);
                                            }
                                        }
                                        else
                                        {
                                            if (total >= 100)
                                            {
                                                if (node.TYLB == 3)
                                                {
                                                    double p = 0;
                                                    for (int j = 0; j < jgList.Prices.Count; j++)
                                                    {

                                                        if (weight >= Convert.ToDouble(jgList.Prices[j].LowerWeightLimit) && weight <= Convert.ToDouble(jgList.Prices[j].UpperWeightLimit))
                                                        {
                                                            p = Convert.ToDouble(jgList.Prices[j].Value);
                                                            break;
                                                        }
                                                    }
                                                    if (i == ksIndex)
                                                    {
                                                        row.CreateCell(cellIndex++).SetCellValue(p * weight);
                                                    }
                                                    else
                                                    {
                                                        row.CreateCell(cellIndex++).SetCellValue(0);
                                                    }
                                                }
                                                else
                                                {
                                                    row.CreateCell(cellIndex++).SetCellValue(fy);
                                                }
                                               
                                            }
                                            else
                                            {
                                                if (i == ksIndex)
                                                {

                                                    row.CreateCell(cellIndex++).SetCellValue(100);
                                                }
                                                else
                                                {
                                                    row.CreateCell(cellIndex++).SetCellValue(0);
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (total >= 100)
                                        {
                                           
                                            if (node.TYLB == 3)
                                            {
                                                double p = 0;
                                                for (int j = 0; j < jgList.Prices.Count; j++)
                                                {

                                                    if (weight >= Convert.ToDouble(jgList.Prices[j].LowerWeightLimit) && weight <= Convert.ToDouble(jgList.Prices[j].UpperWeightLimit))
                                                    {
                                                        p = Convert.ToDouble(jgList.Prices[j].Value);
                                                        break;
                                                    }
                                                }
                                                if (i == ksIndex)
                                                {
                                                    row.CreateCell(cellIndex++).SetCellValue(p*weight);
                                                }
                                                else
                                                {
                                                    row.CreateCell(cellIndex++).SetCellValue(0);
                                                }
                                            }
                                            else
                                            {
                                                row.CreateCell(cellIndex++).SetCellValue(fy);
                                            }
                                            
                                        }
                                        else
                                        {
                                            if (i == ksIndex)
                                            {
                                                row.CreateCell(cellIndex++).SetCellValue(100);
                                            }
                                            else
                                            {
                                                row.CreateCell(cellIndex++).SetCellValue(0);
                                            }
                                        }
                                    }


                                }
                                else
                                {
                                    row.CreateCell(cellIndex++).SetCellValue(fy);
                                }
                                double zsf = 0;//直送费

                                if (node.Weight <= 2000)
                                {
                                    for (int j = 0; j < cityList.Count; j++)
                                    {
                                        if (cityList[j].Remark.Trim() == node.Destination.Name.Trim())
                                        {

                                            if (cityList[j].Name.Trim() == ZJ)
                                            {

                                                zsf = cityList[j].Remark.Trim().Equals("北仑") ? 0 : 80;
                                            }
                                            else if (cityList[j].Name.Trim() == GD)
                                            {
                                                zsf = 100;
                                            }
                                            else
                                            {
                                                zsf = 50;
                                            }
                                            break;
                                        }
                                    }
                                }

                                row.CreateCell(cellIndex++).SetCellValue(zsf);//直送费      




                                if (!string.IsNullOrEmpty(node.Instruction))
                                {
                                    double zxf = node.Instruction.IndexOf("提供卸货") > -1 ? node.Total * 0.5 : 0;//装卸费
                                    row.CreateCell(cellIndex++).SetCellValue(zxf);//装卸费  
                                }
                                else
                                {
                                    row.CreateCell(cellIndex++).SetCellValue(0);//装卸费  
                                }
                                if (!string.IsNullOrEmpty(node.Instruction))
                                {
                                    if (node.Destination.Name.Equals("上海") && node.Instruction.IndexOf(WXP) > -1)
                                    {
                                        //逻辑处理
                                        int ksIndex = nodes.FindIndex(p => p.Receiver.Name == node.Receiver.Name && p.Date == node.Date);
                                        int jsIndex = nodes.FindLastIndex(p => p.Receiver.Name == node.Receiver.Name && p.Date == node.Date);
                                        if (i == ksIndex)
                                        {
                                            row.CreateCell(cellIndex++).SetCellValue(900);
                                        }
                                        else
                                        {
                                            row.CreateCell(cellIndex++).SetCellValue(0);
                                        }
                                        row.CreateCell(2).SetCellValue(node.Receiver.Name);
                                    }
                                    else
                                    {
                                        row.CreateCell(cellIndex++).SetCellValue(0);
                                    }
                                }
                                else
                                {
                                    row.CreateCell(cellIndex++).SetCellValue(0);
                                }
                            }
                            
                           


                        }
                     
                     
                                            
                        break;
                    }

            }

            workbook.Write(memoryStream);
            return memoryStream;

        }

        private IList<string> SplitDeliverySet(string deliverySet)
        {
            string[] numberSet = deliverySet.Split(new char[] { '/' });
            int numberSetLength = numberSet.Length;
            IList<string> numberList = new List<string>();
            for (int i = 0; i < numberSetLength; i++)
            {
                string[] number = numberSet[i].Split(new char[] { '-' });
                if (!number[0].Trim().Equals(""))
                    numberList.Add(number[0].Trim());
            }
            return numberList;
        }

    }
}
