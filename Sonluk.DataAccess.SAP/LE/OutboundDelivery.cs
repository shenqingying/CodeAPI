using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Utility;
using System.Text.RegularExpressions;

namespace Sonluk.DataAccess.SAP.LE
{
    public class OutboundDelivery : IOutboundDelivery
    {
        public IList<DeliveryInfo> Read(DeliveryInfo keywords)
        {
            IRfcFunction func = RFC.Function("ZOD_READ");
            func.SetValue("SVKORG", keywords.SalesOrganization);
            func.SetValue("SVBELN", keywords.SerialNumber);
            func.SetValue("BWADAT", keywords.DeliveryDate);
            func.SetValue("EWADAT", keywords.DeliveryDateEnd);
            func.SetValue("SKUNAG", keywords.Customer);
            func.SetValue("SVSTEL", "");
            func.SetValue("SKUNNR", keywords.ShipToParty);
            func.SetValue("SLFART", keywords.Type);
            func.SetValue("BKODAT", keywords.PickingDate);
            func.SetValue("EKODAT", keywords.PickingDateEnd);
            func.SetValue("SSDABW", "");
            func.SetValue("SERNAM", keywords.Creator);
            func.SetValue("BERDAT", keywords.CreateDate);
            func.SetValue("EERDAT", keywords.CreateDateEnd);
            func.SetValue("SFLAG", keywords.Status);

            IList<DeliveryInfo> nodes = new List<DeliveryInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("LIKPLIST");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    DeliveryInfo node = new DeliveryInfo();
                    node.SerialNumber = Regex.Replace(table.GetString("VBELN"), @"^[0]*", ""); 
                    node.Date = table.GetString("BLDAT");
                    node.ShipToParty = Regex.Replace(table.GetString("KUNNR"), @"^[0]*", "");
                    node.ShipToPartyName = table.GetString("NAME1");
                    node.City = table.GetString("ORT01");
                    node.Telephone = table.GetString("TELF1");
                    node.Address = table.GetString("STRAS");
                    node.Remark = table.GetString("ZTEXT");
                    node.TotalWeight = table.GetDecimal("BTGEW");
                    node.NetWeight = table.GetDecimal("NTGEW");
                    node.Unit = table.GetString("GEWEI");
                    node.SalesOrganization = table.GetString("VKORG");
                    node.Customer = Regex.Replace(table.GetString("KUNAG"), @"^[0]*", ""); 
                    node.Type = table.GetString("LFART");
                    node.DeliveryDate = table.GetString("WADAT");
                    node.PickingDate = table.GetString("KODAT");
                    node.Creator = table.GetString("ERNAM");
                    node.CreateDate = table.GetString("ERDAT");
                    node.CreateTime = table.GetString("ERZET");
                    node.ConsignmentNote = table.GetString("ZTYD");
                    node.BillOfLoading = table.GetString("ZZBH1");
                    node.StoreLocation = table.GetString("ZZCK1");
                    node.Contact = table.GetString("ZZRY1");
                    node.ContactTelephone = table.GetString("ZZDH1");

                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public DeliveryInfo Read(string serialNumber,string status)
        {
            IRfcFunction func = RFC.Function("ZSPLIKPSINGLE");
            func.SetValue("SVBELN", serialNumber);
            func.SetValue("SFLAG", status);

            DeliveryInfo node = new DeliveryInfo();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("LIKPLIST");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    node.SerialNumber = Regex.Replace(table.GetString("VBELN"), @"^[0]*", "");
                    node.Date = table.GetString("BLDAT");
                    node.ShipToParty = Regex.Replace(table.GetString("KUNNR"), @"^[0]*", "");
                    node.ShipToPartyName = table.GetString("NAME1");
                    node.City = table.GetString("ORT01");
                    node.Telephone = table.GetString("TELF1");
                    node.Address = table.GetString("STRAS");
                    node.Remark = table.GetString("ZTEXT");
                    node.TotalWeight = table.GetDecimal("BTGEW");
                    node.NetWeight = table.GetDecimal("NTGEW");
                    node.Unit = table.GetString("GEWEI");
                    node.SalesOrganization = table.GetString("VKORG");
                    node.Customer = Regex.Replace(table.GetString("KUNAG"), @"^[0]*", "");
                    node.Type = table.GetString("LFART");
                    node.DeliveryDate = table.GetString("WADAT");
                    node.PickingDate = table.GetString("KODAT");
                    node.Creator = table.GetString("ERNAM");
                    node.CreateDate = table.GetString("ERDAT");
                    node.CreateTime = table.GetString("ERZET");
                    node.ConsignmentNote = table.GetString("ZTYD");
                    node.BillOfLoading = table.GetString("ZZBH1");
                    node.StoreLocation = table.GetString("ZZCK1");
                    node.Contact = table.GetString("ZZRY1");
                    node.ContactTelephone = table.GetString("ZZDH1");
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public IList<DeliveryItemInfo> ItemRead(string serialNumber)
        {
            IRfcFunction func = RFC.Function("ZSPLIPS");
            func.SetValue("SVBELN", serialNumber);
            func.SetValue("SFLAG", 0);
            IList<DeliveryItemInfo> nodes = new List<DeliveryItemInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("LIPSLIST");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    DeliveryItemInfo node = new DeliveryItemInfo();
                    node.SerialNumber = Regex.Replace(table.GetString("VBELN"), @"^[0]*", ""); 
                    node.Number = table.GetInt("POSNR");
                    node.Material = Regex.Replace(table.GetString("MATNR"), @"^[0]*", ""); 
                    node.MatlDescription = table.GetString("MAKTX");
                    node.Quantity = table.GetDecimal("LGMNG");
                    node.Unit = table.GetString("MEINS");
                    //node.Whole = table.GetInt("VBELN");
                    //node.Odd = table.GetInt("VBELN");
                    node.NetWeight = table.GetDecimal("NTGEW");
                    node.GrossWeight = table.GetDecimal("BRGEW");
                    node.WeightUnit = table.GetString("GEWEI");
                    node.ReferenceDocument = Regex.Replace(table.GetString("VGBEL"), @"^[0]*", ""); 
                    node.ReferenceDocumentItem = table.GetInt("VGPOS");
                    node.StgeLoc = table.GetString("LGORT");
                    node.CustomerMatlDesc = table.GetString("ARKTX");
                    node.Batch = table.GetString("CHARG");
                    node.BatchSplit = table.GetInt("UECHA");


                    //node.SingleQty = table.GetDecimal("VBELN");
                    //node.SingleWeight = table.GetDecimal("VBELN");
                    //node.SingleVolume = table.GetDecimal("VBELN");
                    //node.Plant = table.GetString("VBELN");
                    //node.MatlGroup = table.GetString("VBELN");
                    //node.Type = table.GetString("VBELN");
                    //node.Creator = table.GetString("VBELN");
                    //node.CreateDate = table.GetString("VBELN");
                    //node.CreateTime = table.GetString("VBELN");
                    //node.Status;





                    //node.Date = table.GetString("BLDAT");
                    //node.ShipToParty = Regex.Replace(table.GetString("KUNNR"), @"^[0]*", "");
                    //node.ShipToPartyName = table.GetString("NAME1");
                    //node.City = table.GetString("ORT01");
                    //node.Telephone = table.GetString("TELF1");
                    //node.Address = table.GetString("STRAS");
                    //node.Remark = table.GetString("ZTEXT");
                    //node.TotalWeight = table.GetString("BTGEW");
                    //node.NetWeight = table.GetString("NTGEW");
                    //node.Unit = table.GetString("GEWEI");

                    //node.Type = table.GetString("LFART");

                    //node.Creator = table.GetString("ERNAM");
                    //node.CreateDate = table.GetString("ERDAT");
                    //node.CreateTime = table.GetString("ERZET");

                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public int Update(string serialNumber, int consignmentNote, int status)
        {
            IRfcFunction func = RFC.Function("ZSPLIKPUP");
            func.SetValue("IVBELN", serialNumber);
            func.SetValue("IZTYD", consignmentNote);
            func.SetValue("DELETE", status);

            int success = 0;
            try
            {
                RFC.Invoke(func, false);
                success = 1;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return success;
        }

        public DeliveryInfo ReadSales(string number)
        {
            IRfcFunction func = RFC.Function("Z_DELIVERY_SALES");
            func.SetValue("VBELN", number);
            DeliveryInfo node = new DeliveryInfo();
            try
            {
                RFC.Invoke(func, false);
                node.ConditionValue = func.GetDouble("KWERT");
                node.SalesOrganization = func.GetString("VKORG");
                node.SalesDistr = func.GetString("VTWEG");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }


    }
}
