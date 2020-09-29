using iTextSharp.text;
using iTextSharp.text.pdf;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using Sonluk.BusinessLogic.BC;
using Sonluk.BusinessLogic.FI;
using Sonluk.BusinessLogic.Master;
using Sonluk.BusinessLogic.SD;
using Sonluk.DAFactory;
using Sonluk.Entities.Common;
using Sonluk.Entities.MM;
using Sonluk.Entities.Print;
using Sonluk.Entities.SD;
using Sonluk.Entities.System;
using Sonluk.Entities.BC;
using Sonluk.IDataAccess.MM;
using Sonluk.Utility;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Sonluk.BusinessLogic.MM
{
    public class PurchaseOrder
    {
        private static readonly IPurchaseOrder detaAccess = DataAccess.CreatePurchaseOrder();
        private static readonly IScheduleRequisition SapdetaAccess = DataAccess.CreateScheduleRequisition();
        private IList<POItemInfo> _Nodes;
        private AutoResetEvent[] _Events;

        public POInfo Read(string serialNumber)
        {
            POInfo node = detaAccess.Read(serialNumber);

            PurchasingGroup purGroup = new PurchasingGroup();
            node.PurGroup = purGroup.Read(node.Header.PurGroup);

            Vendor vendor = new Vendor();
            node.Vendor = vendor.Read(node.Header.Vendor);

            Company company = new Company();
            node.Company = company.Read(node.Header.Company);

            node.CustomText = CustomText(serialNumber).ToList();

            Tax tax = new Tax();
            SalesOrder salesOrder = new SalesOrder();
            int length = node.Items.Count;
            for (int i = 0; i < length; i++)
            {
                node.Items[i].Schedule = Schedule(serialNumber, node.Items[i].Number).ToList();
                node.Items[i].CustomText = CustomText(serialNumber, node.Items[i].Number).ToList();
                node.Items[i].SDCustomText = salesOrder.CustomText(node.Items[i].SDDoc, node.Items[i].SDocItem, node.Items[i].MatlGroup).ToList();

                node.Items[i].TaxRate = tax.Rate(node.Items[i].TaxCode);
                node.Items[i].UnitPrice = node.Items[i].NetPrice / node.Items[i].PriceUnit;
                node.Items[i].UnitPriceWidthTax = node.Items[i].UnitPrice * (1 + node.Items[i].TaxRate / 1000);
                node.Items[i].Tax = node.Items[i].NetValue * (node.Items[i].TaxRate / 1000);

                node.Header.AmountWithoutTax = node.Header.AmountWithoutTax + node.Items[i].NetValue;
                node.Header.Tax = node.Header.Tax + node.Items[i].Tax;
                node.Header.Amount = node.Header.Amount + node.Items[i].NetValue * (1 + node.Items[i].TaxRate / 1000);
            }

            return node;
        }

        public IList<POItemInfo> Read(POKeywordInfo keyword)
        {
            if (keyword.DisplayGRDate != null && keyword.DisplayMRDate == null)
            {
                keyword.DisplayMRDate = "0";
            }
            else if (keyword.DisplayGRDate != null && keyword.DisplayMRDate != null)
            {
                keyword.DisplayMRDate = null;
            }
            return detaAccess.Read(keyword);
        }

        public IList<POItemInfo> Read(SOKeywordInfo keyword)
        {
            return detaAccess.Read(keyword);
        }

        public IList<POItemInfo> Read(List<SOKeywordInfo> keywords)
        {
            List<POItemInfo> nodes = new List<POItemInfo>();
            foreach (SOKeywordInfo keyword in keywords)
            {
                nodes.AddRange(Read(keyword));
            }
            return nodes;
        }

        public IList<POItemInfo> Read(MemoryStream soNodes)
        {
            List<POItemInfo> nodesSet = new List<POItemInfo>();

            IWorkbook workbook = WorkbookFactory.Create(soNodes);
            ISheet sheet = workbook.GetSheetAt(0);
            int rowIndex = 1;
            IRow row = sheet.GetRow(rowIndex);

            while (row != null)
            {
                SOKeywordInfo keyword = new SOKeywordInfo();
                keyword.Number = row.GetCell(0).ToString();
                keyword.Item = Convert.ToInt32(row.GetCell(1).ToString());
                keyword.Date = row.GetCell(3).DateCellValue.ToString("yyyy-MM-dd");

                IList<POItemInfo> nodes = Read(keyword);

                int length = nodes.Count;

                for (int i = 0; i < length; i++)
                {
                    nodes[i].NewDelivDate = keyword.Date;
                }

                row = sheet.GetRow(++rowIndex);
                nodesSet.AddRange(nodes);
            }
            return nodesSet;
        }

        public IList<POItemHistoryInfo> History(string serialNumber, int itemNumber)
        {
            IList<POItemHistoryInfo> nodes = detaAccess.History(serialNumber, itemNumber);
            int length = nodes.Count;
            for (int i = 0; i < length; i++)
            {
                nodes[i].HistTypeDescription = HistoryDocTypeDescription(nodes[i].HistType);
            }
            return nodes;
        }

        public bool Release(string serialNumber, string releaseCode)
        {
            Enqueue enqueueBL = new Enqueue();
            bool dequeue = enqueueBL.Wait("EKKO", serialNumber);
            string code = "";
            bool success = false;
            if (dequeue)
            {
                code = detaAccess.Release(serialNumber, releaseCode);

                if (code.Equals("X"))
                    success = true;
            }
            return success;
        }

        public bool ResetRelease(string serialNumber, string releaseCode)
        {
            Enqueue enqueueBL = new Enqueue();
            bool dequeue = enqueueBL.Wait("EKKO", serialNumber);
            string code = "";
            bool success = false;
            if (dequeue)
            {
                code = detaAccess.ResetRelease(serialNumber, releaseCode);

                if (code.Equals("X"))
                    success = true;
            }
            return success;

        }

        public bool UpdateDeliveryDate(POItemInfo node)
        {
            string code = "";
            bool success = false;

            if (node.Prev == -1)
            {
                ResetRelease(node.PONumber, node.ReleaseCode);
            }

            success = false;
            Enqueue enqueueBL = new Enqueue();
            bool enqueue = enqueueBL.Wait("EKKO", node.PONumber);
            code = detaAccess.UpdateDeliveryDate(node);

            if (code.Equals("023"))
            {
                success = true;
            }

            if (node.Next == 0)
            {
                Release(node.PONumber, node.ReleaseCode);
            }
            Console.WriteLine(node.PONumber + ";" + success);
            return success;
        }

        public IList<MessageInfo> UpdateDeliveryDate(List<POItemInfo> nodes)
        {
            IList<MessageInfo> messages = new List<MessageInfo>();
            foreach (POItemInfo node in nodes)
            {
                messages.Add(new MessageInfo(node.Index, UpdateDeliveryDate(node)));
            }
            return messages;
        }

        public IList<MessageInfo> UpdateDeliveryDateParallel(List<POItemInfo> nodes)
        {
            _Nodes = nodes;
            int threadsIndex = 0;
            int length = _Nodes.Count;

            _Events = new AutoResetEvent[AnalyseDeliveryDateData(length)];
            for (int i = 0; i < length; i++)
            {
                if (_Nodes[i].Prev == -1)
                {
                    Thread thread = new Thread(UpdateDeliveryDate);
                    _Events[threadsIndex] = new AutoResetEvent(false);
                    _Nodes[i].Thread = threadsIndex++;
                    thread.Start(i);
                }
            }

            WaitHandle.WaitAll(_Events);

            IList<MessageInfo> messages = new List<MessageInfo>();
            foreach (POItemInfo node in _Nodes)
            {
                messages.Add(new MessageInfo(node.Index, node.Status));
            }

            return messages;

        }

        private void UpdateDeliveryDate(object index)
        {

            int i = (int)index;
            POItemInfo node = _Nodes[i];
            node.Status = UpdateDeliveryDate(node);

            if (node.Next > 0)
            {
                _Nodes[node.Next].Thread = node.Thread;
                UpdateDeliveryDate(node.Next);
            }
            else
            {
                _Events[node.Thread].Set();
            }
        }

        private int AnalyseDeliveryDateData(int length)
        {
            IDictionary<string, int> POSet = new Dictionary<string, int>();
            for (int i = 0; i < length; i++)
            {
                POItemInfo node = _Nodes[i];
                if (!POSet.ContainsKey(node.PONumber))
                {
                    POSet.Add(node.PONumber, i);
                    node.Prev = -1;
                }
                else
                {
                    node.Prev = POSet[node.PONumber];
                    POSet[node.PONumber] = i;
                    _Nodes[node.Prev].Next = i;
                }
            }
            return POSet.Count;
        }

        public MemoryStream Export(string type, List<POItemInfo> itemNodes)
        {
            MemoryStream memoryStream = new MemoryStream();
            IWorkbook workbook;
            string templetPath = AppDomain.CurrentDomain.BaseDirectory;
            switch (type)
            {
                case "Purchaser": templetPath = templetPath + "/Templet/PurchaseOrderListPurchaser.xls"; break;
                case "Vendor": templetPath = templetPath + "/Templet/PurchaseOrderListVendor.xls"; break;
                case "UpdateDeliveryDate": templetPath = templetPath + "/Templet/PurchaseOrderListUpdateDeliveryDate.xls"; break;
                case "Sync": templetPath = templetPath + "/Templet/PurchaseOrderListSync.xls"; break;
                case "PlanExport": templetPath = templetPath + "/Templet/PurchaseOrderListPlanExport.xls"; break;
            }

            using (FileStream fs = File.OpenRead(templetPath))
            {
                workbook = WorkbookFactory.Create(fs);
            }
            ISheet sheet = workbook.GetSheetAt(0);
            int rowIndex = 1;

            switch (type)
            {
                case "Purchaser":
                    {
                        foreach (POItemInfo node in itemNodes)
                        {
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            row.CreateCell(cellIndex++).SetCellValue(node.PONumber);
                            row.CreateCell(cellIndex++).SetCellValue(node.Number);
                            row.CreateCell(cellIndex++).SetCellValue(node.Line);
                            row.CreateCell(cellIndex++).SetCellValue(node.SDDoc);
                            row.CreateCell(cellIndex++).SetCellValue(node.SDocItem);
                            row.CreateCell(cellIndex++).SetCellValue(node.Aufnr);
                            row.CreateCell(cellIndex++).SetCellValue(node.Vendor);
                            row.CreateCell(cellIndex++).SetCellValue(node.Date);
                            row.CreateCell(cellIndex++).SetCellValue(node.Material);
                            row.CreateCell(cellIndex++).SetCellValue(node.MaterialDescription);
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Quantity));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.DelivQty));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Quantity) - Convert.ToDouble(node.DelivQty));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.PcsInCtn));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.PcsInPal));
                            row.CreateCell(cellIndex++).SetCellValue(node.DelivDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.DelivDest);
                            row.CreateCell(cellIndex++).SetCellValue(node.PrintDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.StgeLoc);
                            row.CreateCell(cellIndex++).SetCellValue(node.MatlGroup);
                            row.CreateCell(cellIndex++).SetCellValue(node.PurGroup);
                            row.CreateCell(cellIndex++).SetCellValue(node.NoMoreGR);
                            row.CreateCell(cellIndex++).SetCellValue(node.PstngDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.DocDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.ReqDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.BaseUOM);
                            row.CreateCell(cellIndex++).SetCellValue(node.Plant);
                            row.CreateCell(cellIndex++).SetCellValue(node.PlantName);

                        }
                        break;
                    }
                case "Vendor":
                    {
                        foreach (POItemInfo node in itemNodes)
                        {
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            row.CreateCell(cellIndex++).SetCellValue(node.PONumber);
                            row.CreateCell(cellIndex++).SetCellValue(node.Number);
                            row.CreateCell(cellIndex++).SetCellValue(node.Line);
                            row.CreateCell(cellIndex++).SetCellValue(node.SDDoc);
                            row.CreateCell(cellIndex++).SetCellValue(node.SDocItem);
                            row.CreateCell(cellIndex++).SetCellValue(node.Aufnr);
                            row.CreateCell(cellIndex++).SetCellValue(node.Date);
                            row.CreateCell(cellIndex++).SetCellValue(node.Material);
                            row.CreateCell(cellIndex++).SetCellValue(node.MaterialDescription);
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Quantity));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.DelivQty));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Quantity) - Convert.ToDouble(node.DelivQty));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.PcsInCtn));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.PcsInPal));
                            row.CreateCell(cellIndex++).SetCellValue(node.BaseUOM);
                            row.CreateCell(cellIndex++).SetCellValue(node.DelivDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.DelivDest);
                            row.CreateCell(cellIndex++).SetCellValue(node.PrintDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.StgeLoc);
                            row.CreateCell(cellIndex++).SetCellValue(node.PurGroup);
                            row.CreateCell(cellIndex++).SetCellValue(node.NoMoreGR);
                            row.CreateCell(cellIndex++).SetCellValue(node.Plant);
                            row.CreateCell(cellIndex++).SetCellValue(node.PlantName);
                        }
                        break;

                    }
                case "UpdateDeliveryDate":
                    {
                        foreach (POItemInfo node in itemNodes)
                        {
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            row.CreateCell(cellIndex++).SetCellValue(node.PONumber);
                            row.CreateCell(cellIndex++).SetCellValue(node.Number);
                            row.CreateCell(cellIndex++).SetCellValue(node.Line);
                            row.CreateCell(cellIndex++).SetCellValue(node.SDDoc);
                            row.CreateCell(cellIndex++).SetCellValue(node.SDocItem);
                            row.CreateCell(cellIndex++).SetCellValue(node.Date);
                            row.CreateCell(cellIndex++).SetCellValue(node.Vendor);
                            row.CreateCell(cellIndex++).SetCellValue(node.Material);
                            row.CreateCell(cellIndex++).SetCellValue(node.MaterialDescription);
                            row.CreateCell(cellIndex++).SetCellValue(node.DelivDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.NewDelivDate);
                            row.CreateCell(cellIndex++).SetCellValue(node.CustChngStatus);
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Quantity));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.DelivQty));
                            row.CreateCell(cellIndex++).SetCellValue(node.BaseUOM);
                            row.CreateCell(cellIndex++).SetCellValue(node.PurGroup);
                            row.CreateCell(cellIndex++).SetCellValue(node.MatlGroup);
                            row.CreateCell(cellIndex++).SetCellValue(node.Plant);
                            row.CreateCell(cellIndex++).SetCellValue(node.NoMoreGR);
                        }
                        break;

                    }
                case "Sync":
                    {
                        #region
                        ICellStyle style = workbook.CreateCellStyle();
                        IFont font = workbook.CreateFont();
                        font.FontName = "宋体";
                        font.FontHeightInPoints = 11;
                        font.Color = HSSFColor.Orange.Index;
                        style.SetFont(font);

                        ICellStyle dateStyle = workbook.CreateCellStyle();
                        IFont dateFont = workbook.CreateFont();
                        dateFont.FontName = "宋体";
                        dateFont.FontHeightInPoints = 11;
                        dateFont.Color = HSSFColor.Orange.Index;
                        dateStyle.SetFont(font);
                        dateStyle.Alignment = HorizontalAlignment.Center;

                        foreach (POItemInfo node in itemNodes)
                        {
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            if (!string.IsNullOrEmpty(node.Vendor))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.Vendor);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.SDDoc))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.SDDoc);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            row.CreateCell(cellIndex++).SetCellValue(node.SDocItem);
                            if (!string.IsNullOrEmpty(node.PONumber))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.PONumber);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            row.CreateCell(cellIndex++).SetCellValue(node.Number);
                            row.CreateCell(cellIndex++).SetCellValue(node.Line);
                            if (!string.IsNullOrEmpty(node.Material))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.Material);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.MaterialDescription))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.MaterialDescription);
                            }
                            else
                            {
                                cellIndex++;
                            }

                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.InitialQuantity));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Quantity));
                            if (!string.IsNullOrEmpty(node.InitialDelivDate))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.InitialDelivDate);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.DelivDate))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.DelivDate);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.DelivDest))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.DelivDest);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.CustChngStatus))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.CustChngStatus);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.ScheReq))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.ScheReq);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.PurGroup))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.PurGroup);
                            }
                            else
                            {
                                cellIndex++;
                            }


                            if (node.InitialQuantity != node.Quantity)
                                row.GetCell(9).CellStyle = style;
                            if (!string.IsNullOrEmpty(node.InitialDelivDate) && !string.IsNullOrEmpty(node.DelivDate))
                            {
                                if (!node.InitialDelivDate.Equals(node.DelivDate))
                                    row.GetCell(11).CellStyle = dateStyle;
                            }
                            if (!string.IsNullOrEmpty(node.DelivDest))
                            {
                                if (node.DelivDest != "")
                                    row.GetCell(12).CellStyle = style;
                            }


                        }
                        break;
                        #endregion

                    }
                case "PlanExport":
                    {
                  
                        //ScheduleLineInfo
                        List<ScheduleLineInfo> excelList = new List<ScheduleLineInfo>();
                        foreach (POItemInfo node in itemNodes)
                        {
                            ScheReqInfo infoNode = SapdetaAccess.Read(node.SDDoc);
                            if (infoNode.Items != null)
                            {
                                if (infoNode.Items.Count > 0)
                                {
                                    excelList.AddRange(SapdetaAccess.Read(node.SDDoc).Items);
                                }
                            }


                        }
                        foreach (ScheduleLineInfo node in excelList)
                        {
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            if (!string.IsNullOrEmpty(node.Number))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.Number);
                            }
                            else
                            {
                                cellIndex++;
                            }
                           
                            row.CreateCell(cellIndex++).SetCellValue(node.Item);
                         
                            row.CreateCell(cellIndex++).SetCellValue(node.Line);
                            if (!string.IsNullOrEmpty(node.Material))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.Material);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            
                            if (!string.IsNullOrEmpty(node.MaterialDescription))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.MaterialDescription);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.InitialQuantity));
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Quantity));

                            if (!string.IsNullOrEmpty(node.InitialDate))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.InitialDate);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.Date))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.Date);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.Destination))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.Destination);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.PurGroup))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.PurGroup);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.SalesOrder))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.SalesOrder);
                            }
                            else
                            {
                                cellIndex++;
                            }
                           
                            row.CreateCell(cellIndex++).SetCellValue(node.SOItem);
                          
                            if (!string.IsNullOrEmpty(node.Vendor))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.Vendor);
                            }
                            else
                            {
                                cellIndex++;
                            }
                            if (!string.IsNullOrEmpty(node.StatusDescription))
                            {
                                row.CreateCell(cellIndex++).SetCellValue(node.StatusDescription);
                            }
                            else
                            {
                                cellIndex++;
                            }
     
                        }
                            
                        break;
                    }
              
            }

            workbook.Write(memoryStream);
            return memoryStream;

        }

        public IList<FileStreamInfo> Export(List<POItemInfo> itemNodes, int type)
        {
            IList<string> pos = new List<string>();
            foreach (POItemInfo itemNode in itemNodes)
            {
                if (!pos.Contains(itemNode.PONumber))
                {
                    pos.Add(itemNode.PONumber);
                }
            }

            IList<FileStreamInfo> files = new List<FileStreamInfo>();

            foreach (string po in pos)
            {
                FileStreamInfo file = new FileStreamInfo();
                file.Name = "PO_" + po;
                file.Extension = "pdf";
                RandomString rs = new RandomString();
                file.TattedCode = rs.Create(6);
                file.Bytes = Export(po, type).ToArray();
                files.Add(file);
            }

            return files;
        }

        public MemoryStream Export(string serialNumber, int type)
        {
            MemoryStream memoryStream = new MemoryStream();
            PurchaseOrder pobl = new PurchaseOrder();
            POInfo po = pobl.Read(serialNumber);
            UpdatePrintDate(serialNumber);

            float fontSize = 10;
            float remarkFontSize = 9;
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\simsun.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            FontSelector selector = Fonts(fontSize);

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            document.OpenDocument();
            document.AddTitle("采购订单");
            document.AddSubject(po.Header.Number);
            document.AddAuthor("Sonluk");
            document.AddCreator("Sonluk");

            float[] headerwidths = { 5, 11, 47, 5, 11, 11, 10 };
            string[] tableTitle = { "序号", "物料号码", "物料描述", "单位", "数量", "交货日期", "备注" };
            int tableWidth = 7;
            switch (type)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        tableWidth = 10;
                        headerwidths = new float[] { 5, 11, 17, 5, 10, 11, 11, 11, 11, 8 };
                        tableTitle = new string[] { "序号", "物料号码", "物料描述", "单位", "数量", "不含税单价", "不含税金额", "税额", "交货日期", "备注" };
                        break;
                    }
                case 3:
                    {
                        tableWidth = 10;
                        headerwidths = new float[] { 5, 11, 17, 5, 10, 11, 11, 11, 11, 8 };
                        tableTitle = new string[] { "序号", "物料号码", "物料描述", "单位", "数量", "含税单价", "不含税金额", "税额", "交货日期", "备注" };
                        break;
                    }
            }

            PdfPTable header = new PdfPTable(4);
            header.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] headerCellWidth = { 35, 20, 5, 30 };
            header.SetWidths(headerCellWidth);

            header.AddCell(new Paragraph(po.CustomText[0].Content, new Font(baseFont, fontSize)));
            header.AddCell("");
            header.AddCell("");
            PdfPCell docSN = new PdfPCell(new Paragraph("编号：CG4010A", new Font(baseFont, fontSize)));
            docSN.Border = Rectangle.NO_BORDER;
            docSN.HorizontalAlignment = Element.ALIGN_RIGHT;
            header.AddCell(docSN);
            string templetPath = AppDomain.CurrentDomain.BaseDirectory;
            Image logo = Image.GetInstance(templetPath + "/Content/images/logo-po.png");
            logo.ScaleAbsolute(72, 57);
            PdfPCell logoCell = new PdfPCell(logo);
            logoCell.Border = Rectangle.NO_BORDER;
            logoCell.PaddingBottom = 5;
            header.AddCell(logoCell);

            PdfPCell title = new PdfPCell(new Paragraph("采 购 订 单", new Font(baseFont, 20, Font.BOLD)));
            title.Border = Rectangle.NO_BORDER;
            title.HorizontalAlignment = Element.ALIGN_CENTER;
            header.AddCell(title);
            header.AddCell("  ");

            PdfPTable company = new PdfPTable(1);
            company.DefaultCell.Border = Rectangle.NO_BORDER;
            company.AddCell(new Paragraph(po.Company.Name, new Font(baseFont, fontSize)));
            company.AddCell(new Paragraph("中国浙江宁波市高新区星光路128号", new Font(baseFont, fontSize)));
            company.AddCell(new Paragraph("联系电话:0574-87916666", new Font(baseFont, fontSize)));
            company.AddCell(new Paragraph("邮政编码:" + po.Company.PostCode, new Font(baseFont, fontSize)));
            PdfPCell companyCell = new PdfPCell(company);
            companyCell.Border = Rectangle.NO_BORDER;
            header.AddCell(companyCell);

            PdfPTable vendor = new PdfPTable(2);
            vendor.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] vendorCellWidth = { 9, 49 };
            vendor.SetWidths(vendorCellWidth);
            vendor.AddCell(new Paragraph("订单号:", new Font(baseFont, fontSize)));
            vendor.AddCell(new Paragraph(po.Header.Number, new Font(baseFont, fontSize)));
            vendor.AddCell(new Paragraph("供应商:", new Font(baseFont, fontSize)));
            vendor.AddCell(new Paragraph(Convert.ToInt32(po.Vendor.SerialNumber) + "/" + po.Vendor.Name, new Font(baseFont, fontSize)));
            vendor.AddCell(new Paragraph("联系人:", new Font(baseFont, fontSize)));
            vendor.AddCell(new Paragraph(po.Header.VendorSales, new Font(baseFont, fontSize)));
            vendor.AddCell(new Paragraph("联系方式:", new Font(baseFont, fontSize)));
            vendor.AddCell(new Paragraph(po.Header.VendorTelephone, new Font(baseFont, fontSize)));

            if (type > 1)
            {
                vendor.AddCell(new Paragraph("订单币种:", new Font(baseFont, fontSize)));
                vendor.AddCell(new Paragraph(po.Header.Currency, new Font(baseFont, fontSize)));
            }
            else
            {
                vendor.AddCell(" ");
                vendor.AddCell(" ");
            }

            PdfPCell vendorCell = new PdfPCell(vendor);
            vendorCell.Border = Rectangle.NO_BORDER;
            vendorCell.Colspan = 3;
            header.AddCell(vendorCell);


            PdfPTable purchaser = new PdfPTable(2);
            purchaser.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] purchaserCellWidth = { 9, 21 };
            purchaser.SetWidths(purchaserCellWidth);
            purchaser.AddCell(new Paragraph("订单日期:", new Font(baseFont, fontSize)));
            purchaser.AddCell(new Paragraph(po.Header.Date, new Font(baseFont, fontSize)));
            purchaser.AddCell(new Paragraph("采购员:", new Font(baseFont, fontSize)));
            purchaser.AddCell(new Paragraph(po.PurGroup.Description, new Font(baseFont, fontSize)));
            purchaser.AddCell(new Paragraph("联系方式:", new Font(baseFont, fontSize)));
            purchaser.AddCell(new Paragraph(po.PurGroup.TelephoneDiallingCode, new Font(baseFont, fontSize)));
            purchaser.AddCell(new Paragraph("交货地点:", new Font(baseFont, fontSize)));
            purchaser.AddCell(new Paragraph("宁波市高新区星光路128号", new Font(baseFont, fontSize)));
            purchaser.AddCell(new Paragraph("页码:", new Font(baseFont, fontSize)));
            purchaser.AddCell(new Paragraph("  "));
            PdfPCell purchaserCell = new PdfPCell(purchaser);
            purchaserCell.Border = Rectangle.NO_BORDER;
            header.AddCell(purchaserCell);


            PdfPCell headerCell = new PdfPCell(header);
            headerCell.Border = Rectangle.NO_BORDER;
            headerCell.Colspan = tableWidth;


            PdfPTable aTable = new PdfPTable(tableWidth);

            aTable.SetWidths(headerwidths);
            aTable.WidthPercentage = 100;

            aTable.HeaderRows = 2;
            aTable.AddCell(headerCell);

            for (int i = 0; i < tableTitle.Length; i++)
            {
                Paragraph p = new Paragraph(tableTitle[i], new Font(baseFont, fontSize, Font.BOLD));
                PdfPCell cell = new PdfPCell(p);

                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                aTable.AddCell(cell);
            }

            for (int i = 0; i < po.Items.Count; i++)
            {
                PdfPCell indexCell = new PdfPCell(new Paragraph(po.Items[i].Number.ToString(), new Font(baseFont, fontSize)));
                indexCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.AddCell(indexCell);

                string material = "";
                if (!po.Items[i].Material.Equals(""))
                    material = Convert.ToInt64(po.Items[i].Material).ToString();
                PdfPCell materiaCell = new PdfPCell(new Paragraph(material, new Font(baseFont, fontSize)));

                materiaCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.AddCell(materiaCell);
                aTable.AddCell(new Paragraph(po.Items[i].MaterialDescription, new Font(baseFont, fontSize)));
                PdfPCell unitCell = new PdfPCell(new Paragraph(po.Items[i].BaseUOM, new Font(baseFont, fontSize)));
                unitCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.AddCell(unitCell);
                PdfPCell qtyCell = new PdfPCell(new Paragraph(po.Items[i].Quantity.ToString("###,###,###,##0.###"), new Font(baseFont, fontSize)));
                qtyCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                aTable.AddCell(qtyCell);

                if (type > 1)
                {
                    if (type == 2)
                    {
                        PdfPCell unitPriceCell = new PdfPCell(new Paragraph(po.Items[i].UnitPrice.ToString("###,###,###,##0.000000"), new Font(baseFont, fontSize)));
                        unitPriceCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        aTable.AddCell(unitPriceCell);
                    }
                    else
                    {
                        PdfPCell unitPriceWidthTaxCell = new PdfPCell(new Paragraph(po.Items[i].UnitPriceWidthTax.ToString("###,###,###,##0.000000"), new Font(baseFont, fontSize)));
                        unitPriceWidthTaxCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        aTable.AddCell(unitPriceWidthTaxCell);
                    }
                    PdfPCell netValueCell = new PdfPCell(new Paragraph(po.Items[i].NetValue.ToString("###,###,###,##0.00"), new Font(baseFont, fontSize)));
                    netValueCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    aTable.AddCell(netValueCell);
                    PdfPCell taxCell = new PdfPCell(new Paragraph(po.Items[i].Tax.ToString("###,###,###,##0.00"), new Font(baseFont, fontSize)));
                    taxCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    aTable.AddCell(taxCell);
                }
                PdfPCell dateCell = new PdfPCell(new Paragraph(po.Items[i].Schedule[0].Date, new Font(baseFont, fontSize)));
                dateCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.AddCell(dateCell);
                aTable.AddCell(new Paragraph(po.Items[i].Remarks, new Font(baseFont, fontSize)));


                PdfPTable textTable = new PdfPTable(1);
                textTable.DefaultCell.Border = Rectangle.NO_BORDER;
                string so = "";
                if (po.Items[i].SDocItem != 0)
                    so = Convert.ToInt64(po.Items[i].SDDoc) + "/" + po.Items[i].SDocItem;
                textTable.AddCell(new Paragraph("作业单：" + so + "   要求：", new Font(baseFont, fontSize)));
                string prevSDTextID = "";
                foreach (CustomTextInfo text in po.Items[i].SDCustomText)
                {
                    if (text.Content.Length > 0)
                    {
                        if (!prevSDTextID.Equals(text.ID))
                        {
                            prevSDTextID = text.ID;
                            textTable.AddCell(new Paragraph("【" + text.Title + "】", new Font(baseFont, fontSize)));

                        }
                        textTable.AddCell(new Paragraph(selector.Process(text.Content)));

                    }
                }
                foreach (CustomTextInfo text in po.Items[i].CustomText)
                {
                    if (text.Content.Length > 0)
                    {
                        textTable.AddCell(new Paragraph(text.Content, new Font(baseFont, fontSize)));
                    }
                }
                textTable.AddCell(" ");
                PdfPCell textCell = new PdfPCell(textTable);
                textCell.Colspan = tableWidth;
                aTable.AddCell(textCell);

            }


            if (type > 1)
            {
                PdfPTable sumPriceTable = new PdfPTable(2);
                float[] sumPriceTableCellWidth = { 17, 83 };
                sumPriceTable.SetWidths(sumPriceTableCellWidth);
                sumPriceTable.AddCell(new Paragraph("不含税金额合计：", new Font(baseFont, fontSize)));
                PdfPCell amountWithoutTaxCell = new PdfPCell(new Paragraph(po.Header.AmountWithoutTax.ToString("###,###,###,##0.00"), new Font(baseFont, fontSize)));
                amountWithoutTaxCell.HorizontalAlignment = Element.ALIGN_CENTER;
                sumPriceTable.AddCell(amountWithoutTaxCell);
                sumPriceTable.AddCell(new Paragraph("税额合计：", new Font(baseFont, fontSize)));
                PdfPCell taxCell = new PdfPCell(new Paragraph(po.Header.Tax.ToString("###,###,###,##0.00"), new Font(baseFont, fontSize)));
                taxCell.HorizontalAlignment = Element.ALIGN_CENTER;
                sumPriceTable.AddCell(taxCell);
                sumPriceTable.AddCell(new Paragraph("总计：", new Font(baseFont, fontSize)));
                PdfPCell amountCell = new PdfPCell(new Paragraph(po.Header.Amount.ToString("###,###,###,##0.00"), new Font(baseFont, fontSize)));
                amountCell.HorizontalAlignment = Element.ALIGN_CENTER;
                sumPriceTable.AddCell(amountCell);

                PdfPCell sumPriceCell = new PdfPCell(sumPriceTable);
                sumPriceCell.Colspan = tableWidth;
                aTable.AddCell(sumPriceCell);

            }

            PdfPTable remarkTable = new PdfPTable(1);
            remarkTable.DefaultCell.Border = Rectangle.NO_BORDER;
            remarkTable.AddCell(" ");
            remarkTable.AddCell(new Paragraph("1.以上订单内容参照相关合同或协议执行；", new Font(baseFont, remarkFontSize)));
            remarkTable.AddCell(new Paragraph("2.请按交货日期及时交货，若无法及时交货请提前与本公司取得联系，否则造成损失由供方承担；", new Font(baseFont, remarkFontSize)));
            remarkTable.AddCell(new Paragraph("3.交货检验时须提供交货单，交货单信息需满足本公司需求，如质量检验不合格则拒收；", new Font(baseFont, remarkFontSize)));
            FontSelector remarkSelector = Fonts(remarkFontSize);
            remarkTable.AddCell(remarkSelector.Process("4.备注：" + po.CustomText[1].Content));
            remarkTable.AddCell(" ");
            remarkTable.AddCell(new Paragraph("供应商收到订单后请确认签字并回传，谢谢！", new Font(baseFont, remarkFontSize)));
            remarkTable.AddCell(" ");

            PdfPCell footerCell = new PdfPCell(remarkTable);
            footerCell.Colspan = tableWidth;
            aTable.AddCell(footerCell);


            PdfPTable signTable = new PdfPTable(4);
            signTable.DefaultCell.Border = Rectangle.NO_BORDER;
            signTable.DefaultCell.PaddingTop = 15;
            signTable.DefaultCell.PaddingBottom = 15;
            float[] signCellWidth = { 15, 35, 15, 35 };

            signTable.SetWidths(signCellWidth);
            signTable.AddCell(new Paragraph("采购工程师：", new Font(baseFont, fontSize)));
            signTable.AddCell(" ");
            signTable.AddCell(new Paragraph("供应商确认：", new Font(baseFont, fontSize)));
            signTable.AddCell(" ");
            signTable.AddCell(new Paragraph("订单确认日期：", new Font(baseFont, fontSize)));
            signTable.AddCell(" ");
            signTable.AddCell(new Paragraph("确认日期：", new Font(baseFont, fontSize)));
            signTable.AddCell(" ");

            PdfPCell signCellCell = new PdfPCell(signTable);
            signCellCell.Colspan = tableWidth;
            signCellCell.Border = Rectangle.NO_BORDER;
            aTable.AddCell(signCellCell);

            document.Add(aTable);
            //writer.
            document.Close();

            PdfReader reader = new PdfReader(memoryStream.ToArray());
            MemoryStream outputMemoryStream = new MemoryStream();
            using (PdfStamper stamper = new PdfStamper(reader, outputMemoryStream))
            {
                int PageCount = reader.NumberOfPages;

                for (int i = 1; i <= PageCount; i++)
                {
                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_LEFT, new Phrase(String.Format("第{0}页/共{1}页", i, PageCount), new Font(baseFont, fontSize)), 439, 662, 0);
                }
            };

            return outputMemoryStream;

        }

        private static FontSelector Fonts(float fontSize)
        {
            string fontsFilePath = @"C:\Windows\Fonts\";
            string[] fonts = (AppConfig.Settings("Fonts")).Split(';');

            FontSelector selector = new FontSelector();

            foreach (string font in fonts)
            {
                BaseFont baseFont = BaseFont.CreateFont(fontsFilePath + font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                selector.AddFont(new Font(baseFont, fontSize));
            }
            selector.AddFont(FontFactory.GetFont(FontFactory.TIMES_ROMAN, fontSize));
            return selector;
        }

        private string HistoryDocTypeDescription(string histType)
        {
            string description = "";
            switch (histType)
            {
                case "1": description = "AAf->预付定金请求"; break;
                case "2": description = "AAfV->DP 请求清除"; break;
                case "3": description = "AnzV->预付定金清除"; break;
                case "A": description = "Anz->预付定金"; break;
                case "B": description = "NAbr->后续结算"; break;
                case "C": description = "NeuR->杂项提供"; break;
                case "D": description = "Lerf->服务条目"; break;
                case "E": description = "WE->收货"; break;
                case "F": description = "BzWE->交货成本"; break;
                case "G": description = "BzRE->交货成本"; break;
                case "I": description = "BzKP->删除成本帐户维护"; break;
                case "J": description = "RLfs->退回交货"; break;
                case "K": description = "KtoP->帐户维护"; break;
                case "L": description = "Lfs->交货单"; break;
                case "M": description = "BzRe->交货成本库存日志"; break;
                case "O": description = "LB->外协加工"; break;
                case "Q": description = "RE-L->发票收据"; break;
                case "R": description = "RE->发票收据"; break;
                case "T": description = "VRe->提前输入发票"; break;
                case "U": description = "WA->发货"; break;
            }
            return description;
        }

        public IList<PageInfo<POInfo>> AnalysePrintData(string type, int status, string pageSize, List<POItemInfo> itemNodes)
        {
            IDictionary<string, POInfo> nodesDictionary = new Dictionary<string, POInfo>();
            List<POInfo> nodes;
            Company company = new Company();

            foreach (POItemInfo itemNode in itemNodes)
            {
                if (type.Equals("DeliveryGCL"))
                {
                    itemNode.CustomText = detaAccess.CustomText(itemNode.PONumber, itemNode.Number).ToList();
                }
             
                if (nodesDictionary.ContainsKey(itemNode.PONumber))
                {
                    nodesDictionary[itemNode.PONumber].Items.Add(itemNode);
                }
                else
                {
                    POInfo node = new POInfo();
                    node.Header = new POHeaderInfo();
                    node.Header.Number = itemNode.PONumber;
                    node.Header.Company = itemNode.Plant;
                    node.Header.CompanyName = itemNode.PlantName;//itemNode.PlantName;//(company.Read(itemNode.Plant)).Name;
                    node.Header.Date = itemNode.Date;
                    node.Status = 1;
                    node.Items = new List<POItemInfo>();
                    node.Items.Add(itemNode);
                    nodesDictionary.Add(node.Header.Number, node);
                    
                }
            }

            nodes = nodesDictionary.Values.ToList();
            List<POInfoClassify> nodes_List = new List<POInfoClassify>();
            List<List<POInfo>> werksNodeList = new List<List<POInfo>>();
            if (type.Equals("DeliveryGCL"))
            {
                foreach (POInfo node_poinfo in nodes)
                {
                    foreach (POItemInfo item in node_poinfo.Items)
                    {
                        bool is_aufnr = string.IsNullOrEmpty(item.Aufnr) ? false : true;
                        int findIndex = nodes_List.FindIndex(p => p.IsAufnr == is_aufnr && p.Werk == item.Plant);
                        if (findIndex == -1)
                        {
                            POInfoClassify node = new POInfoClassify();
                            node.Werk = item.Plant;
                            node.IsAufnr = is_aufnr;
                            node.Nodes = new List<POInfo>();
                            POInfo node_po = new POInfo();
                            node_po.Header = new POHeaderInfo();
                            node_po.Header.Number = item.PONumber;
                            node_po.Header.Company = item.Plant;
                            node_po.Header.CompanyName = item.PlantName;//(company.Read(itemNode.Plant)).Name;
                            node_po.Header.Date = item.Date;
                            node_po.Status = 1;
                            node_po.Items = new List<POItemInfo>();
                            node_po.Items.Add(item);
                            node.Nodes.Add(node_po);
                            nodes_List.Add(node);
                        }
                        else
                        {
                            POInfoClassify node_classify = nodes_List[findIndex];
                            bool isPass = false;
                            for (int i = 0; i < node_classify.Nodes.Count; i++)
                            {
                                POInfo poList = node_classify.Nodes[i];
                                if (poList.Header.Number == item.PONumber)
                                {
                                    isPass = true;
                                    //poList.Items.Add(item);
                                    nodes_List[findIndex].Nodes[i].Items.Add(item);
                                    break;
                                }                               
                            }
                            if (!isPass)
                            {
                                POInfo node_po = new POInfo();
                                node_po.Header = new POHeaderInfo();
                                node_po.Header.Number = item.PONumber;
                                node_po.Header.Company = item.Plant;
                                node_po.Header.CompanyName = item.PlantName;//(company.Read(itemNode.Plant)).Name;
                                node_po.Header.Date = item.Date;
                                node_po.Status = 1;
                                node_po.Items = new List<POItemInfo>();
                                node_po.Items.Add(item);
                                nodes_List[findIndex].Nodes.Add(node_po);
                            }
                           
                         
                        }
                        
                      
                    }
                }
            }
            if (type.Equals("IQCPM"))
            {
                
                Dictionary<string, POInfo> werksDictionary = new Dictionary<string, POInfo>();
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (!werksDictionary.ContainsKey(nodes[i].Header.Company))
                    {
                        werksDictionary.Add(nodes[i].Header.Company, nodes[i]);
                    }                                       
                }
                List<string> werksArr = new List<string>();
                foreach (KeyValuePair<string, POInfo> item in werksDictionary)
                {
                    werksArr.Add(item.Key);
                }
               
                for (int i = 0; i < werksArr.Count; i++)
                {
                    List<POInfo> werknodes = new List<POInfo>(); 
                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (werksArr[i].Equals(nodes[j].Header.Company))
                        {
                            werknodes.Add(nodes[j]);
                        }
                    }
                    werksNodeList.Add(werknodes);
                }
            }



            IList<PageInfo<POInfo>> pages = null;
            switch (type)
            {
                case "Delivery": pages = AnalysePrintDelivery(nodes, 20); break;
                case "DeliveryF": pages = AnalysePrintDeliveryF(nodes, 21); break;
                case "IQCPM":
                    {
                        int size = 23;
                        if (pageSize.Equals("241-140"))
                            size = 6;
                        if (pageSize.Equals("241-280"))
                            size = 21;
                        List<PageInfo<POInfo>> werkspages = new List<PageInfo<POInfo>>();
                        for (int i = 0; i < werksNodeList.Count; i++)
                        {
                            werkspages.AddRange(AnalysePrintIQCPM(werksNodeList[i], size));
                        }
                        //pages = AnalysePrintIQCPM(nodes, size);
                        pages = werkspages; 
                        break;
                    }
                case "PurchaseOrder": pages = AnalysePrintPurchaseOrder(status, 40, nodes); break;
                case "DeliveryGCL":
                    {

                        List<PageInfo<POInfo>> nodes_res = new List<PageInfo<POInfo>>();
                        for (int i = 0; i < nodes_List.Count; i++)
                        {
                            nodes_res.AddRange(AnalysePrintDeliveryGCL(nodes_List[i].Nodes, 190, nodes_List[i].IsAufnr).ToList());
                        }
                        pages = nodes_res; break;
                    }

            }
            return pages;

        }
       
        public IList<PageInfo<POInfo>> AnalysePrintDelivery(List<POInfo> nodes, int linesCount)
        {
            List<PageInfo<POInfo>> pages = new List<PageInfo<POInfo>>();
            int pagination = -1;
            PageInfo<POInfo> page;
            int length = nodes.Count;
            for (int i = 0; i < length; i++)
            {
                page = new PageInfo<POInfo>();
                page.Children = new List<POInfo>();
                pages.Add(page);
                pagination++;

                nodes[i].Items.OrderBy(s => s.Number);
                pages[pagination].Children.Add(nodes[i]);
                int itemCount = nodes[i].Items.Count;
                if (itemCount > linesCount)
                {
                    int pageCount = itemCount / linesCount;
                    if (itemCount % linesCount != 0)
                    {
                        pageCount++;
                    }
                    for (int j = 1; j < pageCount; j++)
                    {
                        POInfo node = new POInfo();
                        node.Header = new POHeaderInfo();
                        node.Header.Number = nodes[i].Header.Number;
                        node.Header.CompanyName = nodes[i].Header.CompanyName;
                        node.Header.Date = nodes[i].Header.Date;
                        node.Header.Status = "j + 1";
                        node.Items = new List<POItemInfo>();

                        int pageItemCount = linesCount;
                        if ((itemCount - j * linesCount) < linesCount)
                            pageItemCount = itemCount - j * linesCount;
                        for (int k = 0; k < pageItemCount; k++)
                        {
                            node.Items.Add(nodes[i].Items[j + k + linesCount - 1]);

                        }
                        nodes.Insert(i + j, node);
                        length++;
                    }
                    nodes[i].Items.RemoveRange(linesCount, itemCount - linesCount);
                }
            }
            return pages;
        }
        public IList<PageInfo<POInfo>> AnalysePrintDeliveryF(List<POInfo> nodes, int linesCount)
        {
            List<PageInfo<POInfo>> pages = new List<PageInfo<POInfo>>();
            int length = nodes.Count;
            int index = 0;
            int pagination = -1;
            PageInfo<POInfo> page;


            for (int i = 0; i < length; i++)
            {
                if (index == 0)
                {
                    page = new PageInfo<POInfo>();
                    page.Children = new List<POInfo>();
                    pages.Add(page);
                    pagination++;
                }

                nodes[i].Items.OrderBy(s => s.Number);
                int itemCount = nodes[i].Items.Count;
                if ((linesCount - index) >= 3)
                {
                    int remaining = (linesCount - index - 1) / 2;
                    pages[pagination].Children.Add(nodes[i]);
                    if (remaining > itemCount)
                    {
                        index = index + 1 + itemCount * 2;
                    }
                    else
                    {
                        if (remaining < itemCount)
                        {
                            POInfo node = new POInfo();
                            node.Header = new POHeaderInfo();
                            node.Header.Number = nodes[i].Header.Number;
                            node.Header.CompanyName = nodes[i].Header.CompanyName;
                            node.Header.Date = nodes[i].Header.Date;
                            node.Items = new List<POItemInfo>();

                            for (int k = remaining; k < itemCount; k++)
                            {
                                node.Items.Add(nodes[i].Items[k]);
                            }
                            nodes.Insert(i + 1, node);
                            nodes[i].Items.RemoveRange(remaining, itemCount - remaining);
                            length++;
                        }

                        index = 0;
                    }

                }
                else
                {
                    i--;
                    index = 0;
                }
            }
            return pages;
        }
        public IList<PageInfo<POInfo>> AnalysePrintDeliveryGCL(List<POInfo> nodes, int linesCount,bool isAufnr)
        {           
           
            //--------------------linesCount 默认一页是100个   采购订单是4  行项目是10  每个备注信息都是2--------------------
            List<PageInfo<POInfo>> pages = new List<PageInfo<POInfo>>();
            
            int length = nodes.Count;
            int index = 0;

            int pagination = -1;
            PageInfo<POInfo> page;
            for (int i = 0; i < length; i++)
            {
                if (index == 0)
                {
                    page = new PageInfo<POInfo>();
                    page.Children = new List<POInfo>();
                    pages.Add(page);
                    pagination++;
                }
                POInfo oPnInfo = nodes[i];
                List<POItemInfo> originalItem = nodes[i].Items;
                List<POItemInfo> tempItem = new List<POItemInfo>();
                int cutIndex = 0;
                bool isCut = false;
                for (int j = 0; j < nodes[i].Items.Count; j++)
                {
                   
                    int remarkHeight = nodes[i].Items[j].CustomText.Count(s => !s.Content.Equals("")) * 4;
                    int koHeigth = j == 0 ? 8 : 0;
                    int poHeight = isAufnr ? 21 : 8;
                    if (linesCount - index >= remarkHeight + koHeigth + poHeight)
                    {
                        tempItem.Add(nodes[i].Items[j]);
                        index += remarkHeight + koHeigth + poHeight;
                    }
                    else
                    {
                        cutIndex = j;
                        isCut = true;
                        break;
                    }
                }
                if (tempItem.Count > 0)
                {
                    nodes[i].Items = tempItem;
                    pages[pagination].Children.Add(nodes[i]);
                }
                if (isCut)
                {

                    POInfo node = new POInfo();
                    node.Header = new POHeaderInfo();
                    node.Header.Number = oPnInfo.Header.Number;
                    node.Header.Company = oPnInfo.Header.Company;
                    node.Header.CompanyName = oPnInfo.Header.CompanyName;
                    node.Header.Date = oPnInfo.Header.Date;
                    node.Items = new List<POItemInfo>();
                    tempItem = new List<POItemInfo>();
                    for (int k = cutIndex; k < originalItem.Count; k++)
                    {
                        tempItem.Add(originalItem[k]);
                    }
                    node.Items = tempItem;
                    nodes.Insert(i + 1, node);
                    //nodes[i].Items = tempItem;
                    length++;
                    index = 0;
                }


            }





            return pages;

        }

        public IList<PageInfo<POInfo>> AnalysePrintIQCPM(List<POInfo> nodes, int linesCount)
        {
            List<PageInfo<POInfo>> pages = new List<PageInfo<POInfo>>();

            int length = nodes.Count;
            int index = 0;
            int pagination = -1;
            PageInfo<POInfo> page;


            for (int i = 0; i < length; i++)
            {
                if (index == 0)
                {
                    page = new PageInfo<POInfo>();
                    page.Children = new List<POInfo>();
                    pages.Add(page);
                    pagination++;
                }

                nodes[i].Items.OrderBy(s => s.Number);
                int itemCount = nodes[i].Items.Count;
                if ((linesCount - index) >= 4)
                {
                    int remaining = (linesCount - index - 1) / 3;
                    pages[pagination].Children.Add(nodes[i]);
                    if (remaining > itemCount)
                    {
                        index = index + 1 + itemCount * 3;
                    }
                    else
                    {
                        if (remaining < itemCount)
                        {
                            POInfo node = new POInfo();
                            node.Header = new POHeaderInfo();
                            node.Header.Number = nodes[i].Header.Number;
                            node.Header.CompanyName = nodes[i].Header.CompanyName;
                            node.Header.Date = nodes[i].Header.Date;
                            node.Items = new List<POItemInfo>();

                            for (int k = remaining; k < itemCount; k++)
                            {
                                node.Items.Add(nodes[i].Items[k]);
                            }
                            nodes.Insert(i + 1, node);
                            nodes[i].Items.RemoveRange(remaining, itemCount - remaining);
                            length++;
                        }

                        index = 0;
                    }

                }
                else
                {
                    i--;
                    index = 0;
                }
            }
            return pages;
        }

        public IList<PageInfo<POInfo>> AnalysePrintPurchaseOrder(int status, int linesMax, List<POInfo> nodes)
        {
            List<PageInfo<POInfo>> pages = new List<PageInfo<POInfo>>();
            int length = nodes.Count;
            PageInfo<POInfo> page;
            POInfo node;
            POInfo newNode;
            for (int i = 0; i < length; i++)
            {
                page = new PageInfo<POInfo>();
                page.Children = new List<POInfo>();
                page.Children.Add(Read(nodes[i].Header.Number));
                page.Status = status;
                pages.Add(page);

                UpdatePrintDate(nodes[i].Header.Number);
            }

            int itemsLength = 0;
            int textsLength = 0;
            int index = 0;
            bool full = false;

            int linesCount = 0;

            string prevPONumber = "";

            for (int i = 0; i < length; i++)
            {
                full = false;
                node = pages[i].Children[0];
                if (prevPONumber != node.Header.Number)
                {
                    prevPONumber = node.Header.Number;
                    index = 1;
                }
                else
                {
                    index++;
                    for (int j = i; j > i - index; j--)
                    {
                        pages[j].TotalPage = index;
                    }
                }
                linesCount = 1;

                #region 行项目
                itemsLength = node.Items.Count;
                for (int j = 0; j < itemsLength; j++)
                {

                    if (linesCount + 3 > linesMax)
                    {
                        newNode = new POInfo();
                        newNode.Header = node.Header;
                        newNode.PurGroup = node.PurGroup;
                        newNode.Vendor = node.Vendor;
                        newNode.Company = node.Company;
                        newNode.CustomText = node.CustomText;
                        newNode.Items = new List<POItemInfo>();

                        for (int k = j; k < itemsLength; k++)
                        {
                            newNode.Items.Add(node.Items[k]);
                        }
                        node.Items.RemoveRange(j, itemsLength - j);

                        page = new PageInfo<POInfo>();
                        page.Status = status;
                        page.Children = new List<POInfo>();
                        page.Children.Add(newNode);
                        pages.Insert(i + 1, page);
                        length++;
                        full = true;
                        break;
                    }
                    else
                    {
                        linesCount = linesCount + 3;
                    }

                    string prevSDTextID = "";
                    #region 销售文本
                    textsLength = node.Items[j].SDCustomText.Count;
                    int height = 0;
                    for (int k = 0; k < textsLength; k++)
                    {
                        if (node.Items[j].SDCustomText[k].Content.Length > 0)
                        {
                            if (!prevSDTextID.Equals(node.Items[j].SDCustomText[k].ID))
                            {
                                prevSDTextID = node.Items[j].SDCustomText[k].ID;
                                height = 2;
                            }
                            else
                            {
                                height = 1;
                            }

                            if (linesCount + height > linesMax)
                            {
                                newNode = new POInfo();
                                newNode.Header = node.Header;
                                newNode.PurGroup = node.PurGroup;
                                newNode.Vendor = node.Vendor;
                                newNode.Company = node.Company;
                                newNode.CustomText = node.CustomText;
                                newNode.Items = new List<POItemInfo>();

                                POItemInfo item = new POItemInfo();
                                item.SDDoc = node.Items[j].SDDoc;
                                item.SDocItem = node.Items[j].SDocItem;
                                item.SDCustomText = new List<CustomTextInfo>();
                                for (int m = k; m < textsLength; m++)
                                {
                                    item.SDCustomText.Add(node.Items[j].SDCustomText[m]);
                                }
                                node.Items[j].SDCustomText.RemoveRange(k, textsLength - k);
                                item.CustomText = new List<CustomTextInfo>();
                                for (int m = 0; m < node.Items[j].CustomText.Count; m++)
                                {
                                    item.CustomText.Add(node.Items[j].CustomText[m]);
                                }
                                node.Items[j].CustomText = new List<CustomTextInfo>();
                                newNode.Items.Add(item);

                                for (int m = j + 1; m < itemsLength; m++)
                                {
                                    newNode.Items.Add(node.Items[m]);
                                }
                                node.Items.RemoveRange(j + 1, itemsLength - j - 1);

                                page = new PageInfo<POInfo>();
                                page.Status = status;
                                page.Children = new List<POInfo>();
                                page.Children.Add(newNode);
                                pages.Insert(i + 1, page);
                                length++;
                                full = true;
                            }
                            else
                            {
                                linesCount = linesCount + height;
                            }

                        }
                        if (full)
                            break;
                    }
                    #endregion
                    if (full)
                        break;
                    linesCount++;

                    #region 文本
                    textsLength = node.Items[j].CustomText.Count;
                    for (int k = 0; k < textsLength; k++)
                    {
                        if (node.Items[j].CustomText[k].Content.Length > 0)
                        {
                            if (linesCount + 1 > linesMax)
                            {
                                newNode = new POInfo();
                                newNode.Header = node.Header;
                                newNode.PurGroup = node.PurGroup;
                                newNode.Vendor = node.Vendor;
                                newNode.Company = node.Company;
                                newNode.CustomText = node.CustomText;
                                newNode.Items = new List<POItemInfo>();

                                POItemInfo item = new POItemInfo();
                                item.CustomText = new List<CustomTextInfo>();
                                for (int m = k; m < textsLength; m++)
                                {
                                    item.CustomText.Add(node.Items[j].CustomText[m]);
                                }
                                node.Items[j].CustomText.RemoveRange(k, textsLength - k);
                                newNode.Items.Add(item);

                                for (int m = j + 1; m < itemsLength; m++)
                                {
                                    newNode.Items.Add(node.Items[m]);
                                }
                                node.Items.RemoveRange(j + 1, itemsLength - j - 1);

                                page = new PageInfo<POInfo>();
                                page.Status = status;
                                page.Children = new List<POInfo>();
                                page.Children.Add(newNode);
                                pages.Insert(i + 1, page);
                                length++;
                                full = true;
                                break;
                            }
                            else
                            {
                                linesCount++;
                            }

                        }
                    }
                    #endregion

                }
                #endregion

                #region 金额及备注判断 高：11 line
                if (status > 1 && full == false)
                {
                    if (linesCount + 8 > linesMax)
                    {

                        newNode = new POInfo();
                        newNode.Header = node.Header;
                        newNode.PurGroup = node.PurGroup;
                        newNode.Vendor = node.Vendor;
                        newNode.Company = node.Company;
                        newNode.CustomText = node.CustomText;
                        newNode.Items = new List<POItemInfo>();

                        page = new PageInfo<POInfo>();
                        page.Status = status;
                        page.Children = new List<POInfo>();
                        page.Children.Add(newNode);
                        pages.Insert(i + 1, page);
                        length++;
                    }
                }
                #endregion

                pages[i].Index = index;
                pages[i].TotalPage = index;
            }

            return pages;
        }

        public bool UpdatePrintDate(string number)
        {
            DateTime now = DateTime.Now;
            return detaAccess.UpdatePrintDate(number, now.ToString("yyyyMMdd"), now.ToString("HHmmss"));
        }

        public bool UpdatePrintDate(IList<string> numbers)
        {
            DateTime now = DateTime.Now;
            foreach (string number in numbers)
            {
                detaAccess.UpdatePrintDate(number, now.ToString("yyyyMMdd"), now.ToString("HHmmss"));
            }
            return true;
        }

        public IList<CustomTextInfo> CustomText(string serialNumber)
        {
            return CustomText(serialNumber, 0);
        }

        public IList<CustomTextInfo> CustomText(string serialNumber, int item)
        {
            return detaAccess.CustomText(serialNumber, item);
        }

        public IList<ScheduleLineInfo> Schedule(string serialNumber, int item)
        {
            return detaAccess.Schedule(serialNumber, item);
        }

        public bool UpdateSchedule(POInfo node)
        {
            IList<ScheduleLineInfo> scheline;
            for (int i = 0; i < node.Items.Count; i++)
            {
                scheline = Schedule(node.Header.Number, node.Items[i].Number);
                if (scheline.Count > node.Items[i].Schedule.Count)
                {
                    for (int j = node.Items[i].Schedule.Count; j < scheline.Count; j++)
                    {
                        node.Items[i].Schedule.Add(scheline[j]);
                        node.Items[i].Schedule[j].Delete = "X";
                    }
                }
            }

            string code = "";
            bool success = false;

            ResetRelease(node.Header.Number, node.Header.ReleaseCode);

            Enqueue enqueueBL = new Enqueue();
            bool enqueue = enqueueBL.Wait("EKKO", node.Header.Number);
            code = detaAccess.UpdateSchedule(node);

            if (code.Equals("023"))
            {
                success = true;
            }

            Release(node.Header.Number, node.Header.ReleaseCode);

            return success;
        }

        public IList<FileStreamInfo> GetStorageIdentificationPDF(string CGXM, string TPM, string GYS, int TS, int XS, int SL,string MODE,string LTBS)
        {
            IList<FileStreamInfo> files = new List<FileStreamInfo>();
            FileStreamInfo file = new FileStreamInfo();

            file.Name = "PO_" + CGXM;
            file.Extension = "pdf";
            RandomString rs = new RandomString();
            file.TattedCode = rs.Create(6);
            StorageIdentification l_si = detaAccess.GetRKBSPrint(CGXM, TPM, GYS, TS, XS, SL,MODE,LTBS);
            file.Bytes = l_si.IdentificationPDF; //outputMemoryStream.ToArray();
            files.Add(file);

            return files;
        }

        public IList<ZSL_BCS104> GetStorageIdentificationList(string CGXM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            StorageIdentification l_si = detaAccess.GetRKBSPrint(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS);
            return l_si.Zsl_bcs104;
        }

        public string GenerateStorageIdentification(string CGXM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            StorageIdentification l_si = detaAccess.GetRKBSPrint(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS);
            return l_si.ET_RETURN;
        }

        public IList<FileStreamInfo> GetStorageIdentificationZHPDF(int GLTS, string DYFS, string USER, string MODE, int FS, IList<ZSL_BCS104> itemNodes)
        {
            IList<FileStreamInfo> files = new List<FileStreamInfo>();
            FileStreamInfo file = new FileStreamInfo();

            
            file.Extension = "pdf";
            RandomString rs = new RandomString();
            file.TattedCode = rs.Create(6);
            StorageIdentification l_si = detaAccess.GetRKBSZHPrint(GLTS, DYFS, USER, MODE, FS, itemNodes);
            file.Name = "PO_" + l_si.Zsl_bcs104[0].Zhm;
            file.Bytes = l_si.IdentificationPDF; //outputMemoryStream.ToArray();
            files.Add(file);

            return files;
        }

        public IList<ZSL_BCS104> GetStorageIdentificationZHList(int GLTS, string DYFS, string USER, string MODE, int FS, IList<ZSL_BCS104> itemNodes)
        {
            StorageIdentification l_si = detaAccess.GetRKBSZHPrint(GLTS, DYFS, USER, MODE, FS, itemNodes);
            return l_si.Zsl_bcs104;
        }

        public string GenerateStorageIdentificationZH(int GLTS, string DYFS, string USER, string MODE, int FS, IList<ZSL_BCS104> itemNodes)
        {
            StorageIdentification l_si = detaAccess.GetRKBSZHPrint(GLTS, DYFS, USER, MODE, FS, itemNodes);
            return l_si.ET_RETURN;
        }

        public string ZBCFUN_RKBS_CHANGE(string IV_TPM, string IV_MODE, string IV_USER)
        {
            //string message = "";
            //string msg = "";
            //string[] la_tpm = IV_TPM.Split(Environment.NewLine.ToCharArray());

            ////传入托盘码
            //for (int i = 0; i < la_tpm.Length; i++)
            //{
            //    if (la_tpm[i].Trim() != "")
            //    {
            //        msg = detaAccess.ZBCFUN_RKBS_CHANGE(IV_TPM, IV_MODE, IV_USER);
            //    }
            //}

            return detaAccess.ZBCFUN_RKBS_CHANGE(IV_TPM, IV_MODE, IV_USER);
        }
        public string ZMMFUN_GCDZ_READ(string werks)
        {
            return detaAccess.ZMMFUN_GCDZ_READ(werks);
        }
        public ZMMFUN_PURBS_READ ZMMFUN_PURBS_READ(List<ZSL_BCS303_CT> IT_PURCT)
        {
            return detaAccess.ZMMFUN_PURBS_READ(IT_PURCT);
        }
    }
}
