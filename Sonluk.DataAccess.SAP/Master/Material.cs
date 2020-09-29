using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.Master
{
    public class Material : IMaterial
    {
        public IList<MaterialInfo> Read(int language)
        {
            IRfcFunction func = RFC.Function("ZMATERIAL_READ");
            func.SetValue("LANGUAGE", language);

            IList<MaterialInfo> nodes = new List<MaterialInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("MATERIAL");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    MaterialInfo node = new MaterialInfo();
                    node.SerialNumber = table.GetString("MATNR");
                    node.Description = table.GetString("MAKTX");

                    nodes.Add(node);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<MaterialUnitInfo> UnitConversion(string serialNumber,string unit)
        {
            IRfcFunction func = RFC.Function("ZMATL_UNIT_READ");
            func.SetValue("MATERIAL", serialNumber);
            func.SetValue("UNIT", unit);
            IList<MaterialUnitInfo> nodes = new List<MaterialUnitInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("UNITS");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    MaterialUnitInfo node = new MaterialUnitInfo();
                    node.Target = table.GetString("MEINH");
                    node.Rate= table.GetDecimal("UMREZ");
                    node.GrossWeight = table.GetDecimal("BRGEW");
                    node.Volume = table.GetDecimal("VOLUM");

                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<MaterialUnitInfo> UnitConversion(string serialNumber, string customer, string salesOrganization, string distributionChannel)
        {
            IRfcFunction func = RFC.Function("ZRFC_GET_ITEMDATA");

            func.SetValue("I_MATNR", serialNumber);
            func.SetValue("I_KUNNR", customer);
            func.SetValue("I_VKORG", salesOrganization);
            func.SetValue("I_VTWEG", distributionChannel);

            IList<MaterialUnitInfo> nodes = new List<MaterialUnitInfo>();
            try
            {
                RFC.Invoke(func, false);
                string materialDesc = func.GetString("O_ARKTX");
                string unit = func.GetString("O_MEINS");
                decimal price = func.GetDecimal("O_KBETR");
                IRfcTable table = func.GetTable("O_UMCON");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    MaterialUnitInfo node = new MaterialUnitInfo();
                    node.MaterialDescription = materialDesc;
                    node.Base = unit;
                    node.BasePrice = price;
                    node.Target = table.GetString("MEIN");
                    node.TargetDescription = table.GetString("MEINS");
                    node.Rate = table.GetDecimal("CONV");

                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<MaterialInfo> SalesOnline(string customer, string salesOrganization, string distributionChannel, string division)
        {
            IRfcFunction func = RFC.Function("ZRFC_PUT_ITEM2");

            func.SetValue("I_KUNNR", customer);
            if (salesOrganization!="")
                func.SetValue("I_VKORG", salesOrganization);
            if (distributionChannel != "")
                func.SetValue("I_VTWEG", distributionChannel);
            func.SetValue("I_SPART", division);

            IList<MaterialInfo> nodes = new List<MaterialInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("O_MATNR");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    MaterialInfo node = new MaterialInfo();
                    node.SalesOrganization = table.GetString("VKORG");
                    node.DistributionChannel = table.GetString("VTWEG");
                    node.SerialNumber = table.GetString("MATNR");
                    node.Description = table.GetString("ARKTX");
                    node.BarCode = table.GetString("ZCPTXM");
                    node.Conversion = table.GetDecimal("CONV");
                    node.Unit = table.GetString("MEINS");
                    node.SalesUnit = table.GetString("VRKME");
                    nodes.Add(node);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<MaterialInfo> Promotion(string salesOrganization, string distributionChannel, string division)
        {
            IRfcFunction func = RFC.Function("ZRFC_PUT_ITEMCX");
            func.SetValue("I_VKORG", salesOrganization);
            func.SetValue("I_VTWEG", distributionChannel);
            func.SetValue("I_SPART", division);

            IList<MaterialInfo> nodes = new List<MaterialInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("O_MATNR1");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    MaterialInfo node = new MaterialInfo();
                    node.SerialNumber = table.GetString("MATNR");
                    node.Description = table.GetString("MAKTX");
                    node.Conversion = table.GetDecimal("UMREZ");
                    node.Unit = table.GetString("MEINS");
                    node.SalesUnit= table.GetString("VRKME");
                    nodes.Add(node);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public decimal Price(string serialNumber, string customer, string salesOrganization, string distributionChannel)
        {
            IRfcFunction func = RFC.Function("ZRFC_GET_PRICE1");

            func.SetValue("I_MATNR", serialNumber);
            func.SetValue("I_KUNNR", customer);
            func.SetValue("I_VKORG", salesOrganization);
            func.SetValue("I_VTWEG", distributionChannel);

            decimal price = -1;
            try
            {
                RFC.Invoke(func, false);
                price = func.GetDecimal("O_KBETR");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return price;
        }


    }
}
