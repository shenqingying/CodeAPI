using NPOI.SS.UserModel;
using Sonluk.DAFactory;
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
    public class Feedback
    {
        private static readonly IFeedback _DetaAccess = LETRADataAccess.CreateFeedback();

        public IList<FeedbackInfo> Read(FeedbackInfo keywords)
        {
            return _DetaAccess.Read(keywords);
        }

        public FeedbackInfo Read(int ID)
        {
            FeedbackInfo node = _DetaAccess.Read(ID); ;
            if (node.ID > 0)
            {
                FeedbackItem itemBL = new FeedbackItem();
                node.Items = itemBL.Read(ID);
            }
            else
            {
                node.Date = DateTime.Now.ToString("yyyy-MM-dd");
                node.Carrier = new CompanyInfo();
                node.Items = new List<FeedbackItemInfo>();
            }
            return node;
        }

        public int Create(FeedbackInfo node)
        {
            int ID = _DetaAccess.Create(node);
            if (ID > 0 && node.Items != null)
            {
                int count = node.Items.Count;
                FeedbackItem itemBL = new FeedbackItem();
                for (int i = 0; i < count; i++)
                {
                    node.Items[i].HeaderID = ID;
                    itemBL.Create(node.Items[i]);
                }
            }
            return ID;
        }

        public int Update(FeedbackInfo node)
        {
            int ID = _DetaAccess.Update(node);
            if (ID > 0 && node.Items != null)
            {
                int count = node.Items.Count;
                FeedbackItem itemBL = new FeedbackItem();
                if (itemBL.Delete(ID) > 0) 
                {
                    for (int i = 0; i < count; i++)
                    {
                        node.Items[i].HeaderID = ID;
                        itemBL.Create(node.Items[i]);
                    }
                }
            }
            return ID;
        }

        public string Verify(FeedbackInfo node)
        {
            string message = "";

            if (node.Items != null)
            {
                ConsignmentNote cnBL = new ConsignmentNote();
                FeedbackItem itemBL = new FeedbackItem();
                IList<int> IDList = new List<int>();
                foreach (FeedbackItemInfo item in node.Items)
                {
                    if (IDList.Contains(item.ConsignmentNote))
                    {
                        message = message + item.ConsignmentNote + "重复;";
                        break;
                    }
                    else
                    {
                        IDList.Add(item.ConsignmentNote);
                    }

                    if (cnBL.Exists(item.ConsignmentNote) == 0)
                    {
                        message = message + item.ConsignmentNote + "不存在;";
                        break;
                    }
                    else
                    {
                        if (itemBL.Exists(item.ConsignmentNote) > 0)
                        {
                            message = message + item.ConsignmentNote + "已存在反馈;";
                            break;
                        }
                    }
                }
            }

            return message;
        }

        public int Modify(FeedbackInfo node)
        {
            int ID = 0;
            if (node.ID > 0)
                ID = Update(node);
            else
                ID = Create(node);
            return ID;
        }

        public int Delete(int ID)
        {
            return _DetaAccess.Delete(ID);
        }

        public IList<FeedbackItemInfo> Import(MemoryStream memoryStream)
        {
            List<FeedbackItemInfo> nodes = new List<FeedbackItemInfo>();

            IWorkbook workbook = WorkbookFactory.Create(memoryStream);
            ISheet sheet = workbook.GetSheetAt(0);
            int rowIndex = 1;
            IRow row = sheet.GetRow(rowIndex);
            FeedbackItemInfo sum = new FeedbackItemInfo();
            while (row != null)
            {
                if (!(row.GetCell(0).ToString()).Equals(""))
                {
                    FeedbackItemInfo node = new FeedbackItemInfo();
                    int index = 0;
                    node.ConsignmentNote = Convert.ToInt32(row.GetCell(index++).ToString());

                    if (row.GetCell(index).CellType == CellType.Numeric)
                    {
                        node.DepartureDate = (Convert.ToDateTime(row.GetCell(index++).DateCellValue)).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        node.DepartureDate = row.GetCell(index++).ToString();
                    }
                    //node.DepartureDate = (Convert.ToDateTime(row.GetCell(index++).ToString())).ToString("yyyy-MM-dd");
                    //node.DepartureDate = row.GetCell(index++).DateCellValue.ToString("yyyy-MM-dd");
                    //node.DepartureDate = row.GetCell(index++).ToString();
                    node.Destination = row.GetCell(index++).ToString();
                    node.GoodsType = row.GetCell(index++).ToString();
                    if (row.GetCell(index) != null && !(row.GetCell(index).ToString()).Equals(""))
                    {
                        node.WholeQty = Convert.ToInt32(row.GetCell(index++).ToString());
                    }
                    else
                        index++;
                    if (row.GetCell(index) != null && !(row.GetCell(index).ToString()).Equals(""))
                    {
                        node.Weight = Convert.ToDecimal(row.GetCell(index++).ToString());
                    }
                    else
                        index++;
                    if (row.GetCell(index) != null && !(row.GetCell(index).ToString()).Equals(""))
                    {
                        node.Volume = Convert.ToDecimal(row.GetCell(index++).ToString());
                    }
                    else
                        index++;
                    node.ChargedWeight = node.Volume * 250 + node.Weight;
                    if (row.GetCell(index) != null && !(row.GetCell(index).ToString()).Equals(""))
                    {
                        if (row.GetCell(index).CellType == CellType.Formula)
                        {
                            node.UnitPrice = decimal.Round((decimal)row.GetCell(index++).NumericCellValue, 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            node.UnitPrice = Convert.ToDecimal(row.GetCell(index++).ToString());
                        }
                    }
                    else
                        index++;
                    if (row.GetCell(index) != null && !(row.GetCell(index).ToString()).Equals(""))
                    {
                        if (row.GetCell(index).CellType == CellType.Formula)
                        {
                            node.Cost = decimal.Round((decimal)row.GetCell(index++).NumericCellValue, 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            node.Cost = Convert.ToDecimal(row.GetCell(index++).ToString());
                        }
                    }
                    else
                        index++;
                    if (row.GetCell(index) != null && !(row.GetCell(index).ToString()).Equals(""))
                    {
                        node.DirectCost = Convert.ToDecimal(row.GetCell(index++).ToString());
                    }
                    else
                        index++;
                    if (row.GetCell(index) != null && !(row.GetCell(index).ToString()).Equals(""))
                    {
                        node.HandlingCost = Convert.ToDecimal(row.GetCell(index++).ToString());
                    }
                    else
                        index++;
                    if (row.GetCell(index) != null && !(row.GetCell(index).ToString()).Equals(""))
                    {
                        node.OtherCost = Convert.ToDecimal(row.GetCell(index++).ToString());
                    }
                    else
                        index++;
                    if (row.GetCell(index) != null && !(row.GetCell(index).ToString()).Equals(""))
                    {
                        if (row.GetCell(index).CellType == CellType.Formula)
                        {
                            node.TotalCost = decimal.Round((decimal)row.GetCell(index++).NumericCellValue, 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            node.TotalCost = Convert.ToDecimal(row.GetCell(index++).ToString());
                        }
                    }
                    else
                        index++;
                    node.Payment = node.TotalCost;
                    row = sheet.GetRow(++rowIndex);
                    nodes.Add(node);
                }
                else
                {
                    break;
                }
            }
            nodes.Add(sum);
            return nodes;
        }

        public IList<FeedbackInfo> Report(FeedbackInfo keywords)
        {
            return _DetaAccess.Report(keywords);
        }

        public MemoryStream Export(string type, List<FeedbackInfo> nodes)
        {
            MemoryStream memoryStream = new MemoryStream();
            IWorkbook workbook;
            string templetPath = AppDomain.CurrentDomain.BaseDirectory;
            switch (type)
            {
                case "List": templetPath = templetPath + "/Templet/ConsignmentNoteFeedback.xls"; break;
                case "Report": templetPath = templetPath + "/Templet/ConsignmentNoteFeedbackReport.xls"; break;
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
                        foreach (FeedbackInfo node in nodes)
                        {
                            int cellIndex = 0;
                            IRow row = sheet.CreateRow(rowIndex++);
                            row.CreateCell(cellIndex++).SetCellValue(node.ID);
                            row.CreateCell(cellIndex++).SetCellValue(node.Carrier.ShortName);
                            row.CreateCell(cellIndex++).SetCellValue(node.Date);
                            row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Payment));
                            row.CreateCell(cellIndex++).SetCellValue(node.Remark);
                            row.CreateCell(cellIndex++).SetCellValue(node.Status);
                            row.CreateCell(cellIndex++).SetCellValue(node.Creator);
                            row.CreateCell(cellIndex++).SetCellValue(node.CreateDate);
                        }
                        break;
                    }
                case "Report":
                    {
                        foreach (FeedbackInfo node in nodes)
                        {
                            foreach (FeedbackItemInfo item in node.Items)
                            {
                                int cellIndex = 0;
                                IRow row = sheet.CreateRow(rowIndex++);
                                row.CreateCell(cellIndex++).SetCellValue(item.ConsignmentNote);
                                row.CreateCell(cellIndex++).SetCellValue(node.Carrier.ShortName);
                                row.CreateCell(cellIndex++).SetCellValue(node.ID);
                                row.CreateCell(cellIndex++).SetCellValue(item.DepartureDate);
                                row.CreateCell(cellIndex++).SetCellValue(item.Destination);
                                row.CreateCell(cellIndex++).SetCellValue(item.GoodsType);
                                row.CreateCell(cellIndex++).SetCellValue(item.WholeQty);
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.Weight));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.Volume));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.ChargedWeight));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.UnitPrice));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.Cost));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.DirectCost));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.HandlingCost));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.OtherCost));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.TotalCost));
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(item.Payment));
                                row.CreateCell(cellIndex++).SetCellValue(item.Confirmed ? mark : "");
                                row.CreateCell(cellIndex++).SetCellValue(item.Normal ? mark : "");
                                row.CreateCell(cellIndex++).SetCellValue(item.Remark);
                                row.CreateCell(cellIndex++).SetCellValue(node.Date);
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.Payment));
                                row.CreateCell(cellIndex++).SetCellValue(node.Remark);
                                row.CreateCell(cellIndex++).SetCellValue(node.Status);
                                row.CreateCell(cellIndex++).SetCellValue(node.Creator);
                                row.CreateCell(cellIndex++).SetCellValue(node.CreateDate);

                            }

                        }

                    }
                    break;
            }
            workbook.Write(memoryStream);
            return memoryStream;

        }
    }
}
