using NPOI.SS.UserModel;
using Sonluk.BusinessLogic.LE.TRA;
using Sonluk.BusinessLogic.Master;
using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE
{
    public class OutboundDelivery
    {
        private static readonly IOutboundDelivery detaAccess = LEDataAccess.CreateOutboundDelivery();

        public IList<DeliveryInfo> Read(DeliveryInfo keywords)
        {
            IList<DeliveryInfo> nodes;
            if (keywords.SerialNumberSet != null && keywords.SerialNumberSet.Count > 0)
            {
                HashSet<string> serialNumberHashSet = new HashSet<string>(keywords.SerialNumberSet);
                nodes = new List<DeliveryInfo>();
                foreach (string serialNumber in serialNumberHashSet)
                {
                    DeliveryInfo node = Read(serialNumber, keywords.Status);
                    if (node.SerialNumber != null && !node.SerialNumber.Equals(""))
                        nodes.Add(node);
                }
            }
            else
            {
                nodes = detaAccess.Read(keywords);
            }

            return nodes;
        }

        public DeliveryInfo Read(string serialNumber, string status)
        {
            return detaAccess.Read(serialNumber, status);
        }

        public IList<DeliveryItemInfo> ItemRead(string serialNumber)
        {
            IList<DeliveryItemInfo> nodes = detaAccess.ItemRead(serialNumber);

            int count = nodes.Count;
            Goods goodsBL = new Goods();
            for (int i = 0; i < count; i++)
            {
                GoodsInfo goods = goodsBL.Read(nodes[i].Material);
                if (goods.ID > 0)
                {
                    if (goods.Quantity == 0)
                    {
                        nodes[i].Whole = Convert.ToInt32(nodes[i].Quantity);
                        nodes[i].Odd = 0;
                    }
                    else
                    {
                        nodes[i].Whole = Convert.ToInt32(nodes[i].Quantity) / Convert.ToInt32(goods.Quantity);
                        nodes[i].Odd = Convert.ToInt32(nodes[i].Quantity) % Convert.ToInt32(goods.Quantity);
                    }
                    nodes[i].Unit = goods.Unit;
                    nodes[i].GrossWeight = nodes[i].Whole * goods.GrossWeight;
                    nodes[i].NetWeight = nodes[i].Whole * goods.GrossWeight;
                    nodes[i].WeightUnit = goods.WeightUnit;
                    nodes[i].SingleQty = goods.Quantity;
                    nodes[i].SingleWeight = goods.GrossWeight;
                    nodes[i].SingleVolume = goods.Volume;
                }
                else
                {

                    Material matlBL = new Material();
                    IList<MaterialUnitInfo> units = matlBL.UnitConversion(nodes[i].Material, "CTN");

                    if (units.Count == 0)
                    {
                        MaterialUnitInfo unit = new MaterialUnitInfo();
                        unit.Rate = 1;
                        unit.GrossWeight = 1;
                        unit.Volume = 1;
                        units.Add(unit);
                    }

                    if (units[0].Rate == 0)
                    {
                        nodes[i].Whole = Convert.ToInt32(nodes[i].Quantity);
                        nodes[i].Odd = 0;
                    }
                    else
                    {
                        nodes[i].Whole = Convert.ToInt32(nodes[i].Quantity) / Convert.ToInt32(units[0].Rate);
                        nodes[i].Odd = Convert.ToInt32(nodes[i].Quantity) % Convert.ToInt32(units[0].Rate);
                    }

                    nodes[i].GrossWeight = nodes[i].Whole * units[0].GrossWeight;
                    nodes[i].NetWeight = nodes[i].Whole * units[0].GrossWeight;
                    nodes[i].Unit = "PCS";
                    nodes[i].WeightUnit = "KG";
                    nodes[i].SingleQty = units[0].Rate;
                    nodes[i].SingleWeight = units[0].GrossWeight;
                    nodes[i].SingleVolume = units[0].Volume;


                    goods.Name = nodes[i].MatlDescription;
                    goods.Material = nodes[i].Material;
                    goods.TypeID = 1;
                    goods.Type = "电池";
                    goods.Quantity = units[0].Rate;
                    goods.UnitID = 1;
                    goods.Unit = "PCS";
                    goods.GrossWeight = units[0].GrossWeight;
                    goods.NetWeight = units[0].GrossWeight;
                    goods.WeightUnitID = 2;
                    goods.WeightUnit = "KG";
                    goods.Volume = units[0].Volume;
                    goods.VolumeUnitID = 5;
                    goods.VolumeUnit = "M3";
                    goodsBL.Create(goods);
                }
            }
            return nodes;
        }

        public int Update(string serialNumber, int consignmentNote)
        {
            int success = 0;
            try 
            { 
                success=detaAccess.Update(serialNumber, consignmentNote, 3);
            }
            catch 
            { 
            
            }
            return success;
        }

        public MemoryStream Export(List<DeliveryInfo> nodes)
        {
            MemoryStream memoryStream = new MemoryStream();
            IWorkbook workbook;
            string templetPath = AppDomain.CurrentDomain.BaseDirectory + "/Templet/OutboundDelivery.xls";

            using (FileStream fs = File.OpenRead(templetPath))
            {
                workbook = WorkbookFactory.Create(fs);
            }
            ISheet sheet = workbook.GetSheetAt(0);
            int rowIndex = 1;
            foreach (DeliveryInfo node in nodes)
            {
                int cellIndex = 0;
                IRow row = sheet.CreateRow(rowIndex);
                row.CreateCell(cellIndex++).SetCellValue(rowIndex++);
                row.CreateCell(cellIndex++).SetCellValue(node.SerialNumber);
                row.CreateCell(cellIndex++).SetCellValue(node.Date);
                row.CreateCell(cellIndex++).SetCellValue(node.ShipToParty);
                row.CreateCell(cellIndex++).SetCellValue(node.ShipToPartyName);
                row.CreateCell(cellIndex++).SetCellValue(node.City);
                row.CreateCell(cellIndex++).SetCellValue(node.Telephone);
                row.CreateCell(cellIndex++).SetCellValue(node.Address);
                row.CreateCell(cellIndex++).SetCellValue(node.Remark);
                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.TotalWeight));
                row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(node.NetWeight));
                row.CreateCell(cellIndex++).SetCellValue(node.Unit);
                row.CreateCell(cellIndex++).SetCellValue(node.SalesOrganization);
                row.CreateCell(cellIndex++).SetCellValue(node.Customer);
                row.CreateCell(cellIndex++).SetCellValue(node.Type);
                row.CreateCell(cellIndex++).SetCellValue(node.DeliveryDate);
                row.CreateCell(cellIndex++).SetCellValue(node.PickingDate);
                row.CreateCell(cellIndex++).SetCellValue(node.Creator);
                row.CreateCell(cellIndex++).SetCellValue(node.CreateDate);
                row.CreateCell(cellIndex++).SetCellValue(node.CreateTime);
                row.CreateCell(cellIndex++).SetCellValue(node.ConsignmentNote);
                row.CreateCell(cellIndex++).SetCellValue(node.BillOfLoading);
                row.CreateCell(cellIndex++).SetCellValue(node.StoreLocation);
                row.CreateCell(cellIndex++).SetCellValue(node.Contact);
                row.CreateCell(cellIndex++).SetCellValue(node.ContactTelephone);
            }

            workbook.Write(memoryStream);
            return memoryStream;
        }

        public int UnLoad(int minSales, string deliveryNumberSet, string salesRange)
        {
            IList<string> numberSet = AnalyseNumberSet(deliveryNumberSet);
            double sales = 0;
            int returnFlag = 0;
            DeliveryInfo node;
            foreach (string number in numberSet)
            {
                node = detaAccess.ReadSales(number);
                if (salesRange.Equals(node.SalesOrganization + "/" + node.SalesDistr))
                    sales = sales + node.ConditionValue;
            }

            if (sales > minSales)
                returnFlag = 1;

            return returnFlag;
        }

        public int UnLoad(string deliveryNumberSet)
        {
            return UnLoad(40000, deliveryNumberSet, "1100/20");
        }

        private IList<string> AnalyseNumberSet(string deliveryNumberSet)
        {
            string[] numberSet = deliveryNumberSet.Split(new char[] { '/' });
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
