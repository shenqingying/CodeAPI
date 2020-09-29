using NPOI.SS.UserModel;
using Sonluk.BusinessLogic.BC;
using Sonluk.DAFactory;
using Sonluk.Entities.BC;
using Sonluk.Entities.LE;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Complaint
    {
        private static readonly IComplaint _DetaAccess = LETRADataAccess.CreateComplaint();

        public IList<ComplaintInfo> Read(ComplaintInfo keywords)
        {
            return _DetaAccess.Read(keywords);
        }

        public ComplaintInfo Read(int ID)
        {
            ComplaintInfo node = _DetaAccess.Read(ID);
            if (node.ID > 0)
            {
                ComplaintItem itemBL = new ComplaintItem();
                node.Items = itemBL.Read(node.ID);
            }
            else
            {
                node.ReturnDate = DateTime.Now.ToString("yyyy-MM-dd");
                node.Carrier = new CompanyInfo();
                node.Receiver = new CompanyInfo();
                node.Items = new List<ComplaintItemInfo>();
            }
            return node;
        }

        public ComplaintInfo Generate(int consignmentNote)
        {
            ConsignmentNote cnBL = new ConsignmentNote();
            CNInfo cn = cnBL.Read(consignmentNote);

            ComplaintInfo node = new ComplaintInfo();
            node.Carrier = cn.Carrier;
            node.ConsignmentNote = consignmentNote;
            node.Receiver = cn.Receiver;
            node.AppointedDeliveryDate = cn.DeliveryDate;

            node.Items = new List<ComplaintItemInfo>();
            OutboundDelivery odBL = new OutboundDelivery();
            User userBL = new User();
            IList<string> numberSet = SplitDeliverySet(cn.Delivery);
            foreach (string number in numberSet)
            {
                DeliveryInfo od = odBL.Read(number, "2");

                IList<DeliveryItemInfo> odItems = odBL.ItemRead(number);

                foreach (DeliveryItemInfo odItem in odItems)
                {
                    ComplaintItemInfo item = new ComplaintItemInfo();
                    item.Delivery = number;
                    item.Material = odItem.Material;
                    item.MaterialDescription = odItem.MatlDescription;
                    item.ReturnQty = odItem.Quantity;
                    item.DamageQty = odItem.Quantity;
                    item.ReturnWholeQty = Convert.ToInt16(odItem.Quantity / odItem.SingleQty);
                    item.Sales = (userBL.Read(od.Creator)).Address.FullName;
                    node.Items.Add(item);

                }
            }


            return node;
        }

        public int Create(ComplaintInfo node)
        {
            int ID = _DetaAccess.Create(node);

            if (node.Items != null)
            {
                ComplaintItem itemBL = new ComplaintItem();
                int count = node.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    node.Items[i].HeaderID = ID;
                    itemBL.Create(node.Items[i]);
                }
            }
            return ID;
        }

        public int Update(ComplaintInfo node)
        {
            int ID = _DetaAccess.Update(node);

            if (node.Items != null)
            {
                ComplaintItem itemBL = new ComplaintItem();
                int count = node.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    node.Items[i].HeaderID = ID;
                    itemBL.Create(node.Items[i]);
                }
            }
            return ID;
        }

        public int Modify(ComplaintInfo node)
        {
            int ID = 0;
            if (node.ID > 0)
            {
                ID = Update(node);
            }
            else
            {
                ID = Create(node);
            }

            return ID;
        }

        public int Delete(int ID)
        {
            return _DetaAccess.Delete(ID);
        }

        public IList<ComplaintInfo> Report(ComplaintInfo keywords)
        {
            return _DetaAccess.Report(keywords);
        }

        public MemoryStream Export(string type, List<ComplaintInfo> nodes)
        {
            MemoryStream memoryStream = new MemoryStream();
            IWorkbook workbook;
            string templetPath = AppDomain.CurrentDomain.BaseDirectory;
            switch (type)
            {
                case "List": templetPath = templetPath + "/Templet/ConsignmentNoteComplaint.xls"; break;
                case "Report": templetPath = templetPath + "/Templet/ConsignmentNoteComplaintReport.xls"; break;
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
                        foreach (ComplaintInfo node in nodes)
                        {
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            row.CreateCell(cellIndex++).SetCellValue(node.ID);
                            row.CreateCell(cellIndex++).SetCellValue(node.Carrier.ShortName);
                            row.CreateCell(cellIndex++).SetCellValue(node.ConsignmentNote);
                            row.CreateCell(cellIndex++).SetCellValue(node.ContactLetter);
                            row.CreateCell(cellIndex++).SetCellValue(node.Receiver.ShortName);
                            row.CreateCell(cellIndex++).SetCellValue(node.ReturnDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.AppointedDeliveryDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.DeliveryDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.DelayDays);
                            row.CreateCell(cellIndex++).SetCellValue(node.Type);
                            row.CreateCell(cellIndex++).SetCellValue(node.PackageDamage ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.GoodsGetWet ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.PackagePollution ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.GoodsDamage ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.GoodsShortage ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.DamageValue));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.ReworkValue));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Compensation));
                            row.CreateCell(cellIndex++).SetCellValue(node.Compensable ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.Completed ? mark : "");
                            row.CreateCell(cellIndex++).SetCellValue(node.Creator);
                            row.CreateCell(cellIndex++).SetCellValue(node.CreateDate);
                        }
                        break;
                    }
                case "Report":
                    {
                        foreach (ComplaintInfo node in nodes)
                        {
                            foreach (ComplaintItemInfo item in node.Items)
                            {
                                int cellIndex = 0;
                                IRow row = sheet.CreateRow(rowIndex++);
                                row.CreateCell(cellIndex++).SetCellValue(node.ID);
                                row.CreateCell(cellIndex++).SetCellValue(node.Carrier.ShortName);
                                row.CreateCell(cellIndex++).SetCellValue(node.ConsignmentNote);
                                row.CreateCell(cellIndex++).SetCellValue(node.ContactLetter);
                                row.CreateCell(cellIndex++).SetCellValue(node.Receiver.ShortName);
                                row.CreateCell(cellIndex++).SetCellValue(node.ReturnDate);
                                row.CreateCell(cellIndex++).SetCellValue(node.AppointedDeliveryDate);
                                row.CreateCell(cellIndex++).SetCellValue(node.DeliveryDate);
                                row.CreateCell(cellIndex++).SetCellValue(node.DelayDays);
                                row.CreateCell(cellIndex++).SetCellValue(node.Type);
                                row.CreateCell(cellIndex++).SetCellValue(node.PackageDamage ? mark : "");
                                row.CreateCell(cellIndex++).SetCellValue(node.GoodsGetWet ? mark : "");
                                row.CreateCell(cellIndex++).SetCellValue(node.PackagePollution ? mark : "");
                                row.CreateCell(cellIndex++).SetCellValue(node.GoodsDamage ? mark : "");
                                row.CreateCell(cellIndex++).SetCellValue(node.GoodsShortage ? mark : "");
                                row.CreateCell(cellIndex++).SetCellValue(node.Compensable ? mark : "");
                                row.CreateCell(cellIndex++).SetCellValue(node.Completed ? mark : "");
                                row.CreateCell(cellIndex++).SetCellValue(item.Delivery);
                                row.CreateCell(cellIndex++).SetCellValue(item.Material);
                                row.CreateCell(cellIndex++).SetCellValue(item.MaterialDescription);
                                row.CreateCell(cellIndex++).SetCellValue(item.ReturnWholeQty);
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.ReturnQty));
                                row.CreateCell(cellIndex++).SetCellValue(item.ReturnReason);
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.UnitValue));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.DamageQty));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.DamageValue));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.ReworkValue));
                                row.CreateCell(cellIndex++).SetCellValue(item.Sales);
                                row.CreateCell(cellIndex++).SetCellValue(node.Creator);
                                row.CreateCell(cellIndex++).SetCellValue(node.CreateDate);

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
