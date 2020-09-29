using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.Master;
using Sonluk.Entities.QM;
using Sonluk.IDataAccess.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.QM
{
    public class Ingredient : IIngredient
    {
        public IList<IngredientItemInfo> Read(string serialNumber)
        {
            IRfcFunction func = RFC.Function("ZSL_QMFM_008");
            func.SetValue("I_ZPLDH", serialNumber);


            IList<IngredientItemInfo> nodes = new List<IngredientItemInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("IT_ITEM");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    IngredientItemInfo node = new IngredientItemInfo();
                    node.SerialNumber = table.GetString("ZPLDH");
                    node.Item = table.GetString("ZHXMBH");
                    node.Material = table.GetString("ZWLH");
                    node.MaterialDescription = table.GetString("MAKTX");
                    node.InspectionLot = table.GetString("ZJYP");
                    node.Batch = table.GetString("CHARG");
                    node.Vendor = table.GetString("LIFNR");
                    node.VendorDescription = table.GetString("NAME1");
                    node.VendorBatch = table.GetString("LICHN");
                    nodes.Add(node);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<IngredientInfo> Read(string material, string batch, string vendorBatch)
        {
            IRfcFunction func = RFC.Function("ZSL_QMFM_009");
            func.SetValue("I_MATNR", material);
            func.SetValue("I_CHARG", batch);
            func.SetValue("I_LICHN", vendorBatch);

            IList<IngredientInfo> nodes = new List<IngredientInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("IT_ITEM");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    IngredientInfo node = new IngredientInfo();
                    node.SerialNumber = table.GetString("ZPLDH");
                    node.Creator = table.GetString("ZCJR");
                    node.CreateDate = table.GetString("ZCCRQ");
                    nodes.Add(node);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<MaterialInfo> Material()
        {
            IRfcFunction func = RFC.Function("ZSL_QMFM_010");
            IList<MaterialInfo> nodes = new List<MaterialInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("IT_ITEM");
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

        public IList<JSJYBBInfo> JSJYBBREAD(string VBELN, string POSNR)
        {
            IRfcFunction func = RFC.Function("ZSL_QMFM_011");
            func.SetValue("VBELN", VBELN);
            func.SetValue("POSNR", POSNR);
            IList<JSJYBBInfo> nodes = new List<JSJYBBInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable tableITEMS = func.GetTable("ITEMS");
                IRfcTable tableZRQMBZ = func.GetTable("ZRQMBZ");
                for (int i = 0; i < tableITEMS.RowCount; i++)
                {
                    tableITEMS.CurrentIndex = i;
                    
                    JSJYBBInfo node = new JSJYBBInfo();
                    node.VBELN = tableITEMS.GetString("VBELN");
                    node.POSNR = tableITEMS.GetString("POSNR");
                    node.UMREZ = tableITEMS.GetString("UMREZ");
                    node.KWMENG = tableITEMS.GetString("KWMENG");
                    node.MEINS = tableITEMS.GetString("MEINS");
                    node.MATNR = tableITEMS.GetString("MATNR");
                    node.MAKTX = tableITEMS.GetString("MAKTX");
                    try
                    {
                        tableZRQMBZ.CurrentIndex = i;
                        node.TDLINE = tableZRQMBZ.GetString("TDLINE");
                    }
                    catch
                    {
                        node.TDLINE = "";
                    }
                    
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
