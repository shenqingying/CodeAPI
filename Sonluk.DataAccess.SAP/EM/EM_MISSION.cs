using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.EM
{
    public class EM_MISSION : IEM_MISSION
    {
        public ZSD_XBZ_MAINRESULT ZSD_XBZ_MAIN(ZSD_XBZ_MAINRESULT importList)
        {
            ZSD_XBZ_MAINRESULT res = new ZSD_XBZ_MAINRESULT();
            res.MES_RETURN = new MES_RETURN();
            res.ET_TABLE_PLUS = new List<ZSL_SDT075_PLUS>();
            IRfcFunction func = RFC.Function("ZSD_XBZ_MAIN");
            
                func.SetValue("FUNTYPE", importList.EM_MISSION_IMPORT.FUNTYPE);
                func.SetValue("DATEBEGIN", importList.EM_MISSION_IMPORT.DATEBEGIN);


                func.SetValue("DATEEND", importList.EM_MISSION_IMPORT.DATEEND);
                func.SetValue("MISSION", importList.EM_MISSION_IMPORT.MISSION);
                if (!string.IsNullOrEmpty(importList.EM_MISSION_IMPORT.MATNR))
                {
                    func.SetValue("MATNR", importList.EM_MISSION_IMPORT.MATNR.Length > 0 ? importList.EM_MISSION_IMPORT.MATNR.PadLeft(18, '0') : "");
                }
                if (!string.IsNullOrEmpty(importList.EM_MISSION_IMPORT.VBELN))
                {
                    func.SetValue("VBELN", importList.EM_MISSION_IMPORT.VBELN.Length > 0 ? importList.EM_MISSION_IMPORT.VBELN.PadLeft(10, '0') : "");
                }
                
                func.SetValue("POSNR", importList.EM_MISSION_IMPORT.POSNR);
                func.SetValue("STATUS", importList.EM_MISSION_IMPORT.STATUS);
                func.SetValue("CJR", importList.EM_MISSION_IMPORT.CJR);
                func.SetValue("STATUSSTR", importList.EM_MISSION_IMPORT.STATUSSTR); 
           
            IRfcTable i_table = func.GetTable("ET_TABLE");
            for (int i = 0; i < importList.ET_TABLE.Count; i++)
            {
                i_table.Append();
                i_table.SetValue("MISSION", importList.ET_TABLE[i].MISSION);
                i_table.SetValue("STATUS", importList.ET_TABLE[i].STATUS);
                i_table.SetValue("XGR", importList.ET_TABLE[i].XGR);
               

            }
            RFC.Invoke(func, true);
            IRfcTable ET_TABLE_PLUS = func.GetTable("ET_TABLE_PLUS");
            for (int i = 0; i < ET_TABLE_PLUS.RowCount; i++)
            {
                ET_TABLE_PLUS.CurrentIndex = i;
                ZSL_SDT075_PLUS node = new ZSL_SDT075_PLUS();
                node.WERKS = ET_TABLE_PLUS.GetString("WERKS");
                node.MISSION = ET_TABLE_PLUS.GetString("MISSION");
                node.MATNR = ET_TABLE_PLUS.GetString("MATNR").TrimStart('0');
                node.VBELN = ET_TABLE_PLUS.GetString("VBELN").TrimStart('0');
                node.POSNR = ET_TABLE_PLUS.GetString("POSNR").TrimStart('0');
                node.STATUS = ET_TABLE_PLUS.GetString("STATUS");
                node.XGR = ET_TABLE_PLUS.GetString("XGR");
                node.CJR = ET_TABLE_PLUS.GetString("CJR");
                node.CJRQ = ET_TABLE_PLUS.GetString("CJRQ");
                node.CJSJ = ET_TABLE_PLUS.GetString("CJSJ");
                node.MAKTX = ET_TABLE_PLUS.GetString("MAKTX");
                node.KUNAG = ET_TABLE_PLUS.GetString("KUNAG");
                node.NAME1 = ET_TABLE_PLUS.GetString("NAME1");
                node.BSTDK = ET_TABLE_PLUS.GetString("BSTDK");
                if (node.BSTDK == "0000-00-00") node.BSTDK = "";
                node.GSTRP = ET_TABLE_PLUS.GetString("GSTRP");
                if (node.GSTRP == "0000-00-00") node.GSTRP = "";
                res.ET_TABLE_PLUS.Add(node);
                //ZSL_BCS112 child = new ZSL_BCS112();
                //child.MATNR = tb_ET_MATDATA_H.GetString("MATNR");
                //child.MAKTX = tb_ET_MATDATA_H.GetString("MAKTX");
                //child_ET_MATDATA_H.Add(child);
            }
            IRfcTable MSGtable = func.GetTable("T_MSG");
            if (MSGtable.RowCount > 0)
            {
                MSGtable.CurrentIndex = 0;
                res.MES_RETURN.TYPE = MSGtable.GetString("TYPE");
                res.MES_RETURN.MESSAGE = MSGtable.GetString("MESSAGE");
            }
            return res;
        }
        public ZSD_XBZ_CHANGEINFORESULT ZSD_XBZ_CHANGEINFO(string FUNTYPE, string MISSION)
        {
            ZSD_XBZ_CHANGEINFORESULT res = new ZSD_XBZ_CHANGEINFORESULT();
            res.MES_RETURN = new MES_RETURN();
            res.ET_TABLE = new List<ZSL_SDT076>();
            IRfcFunction func = RFC.Function("ZSD_XBZ_CHANGEINFO");
            func.SetValue("FUNTYPE", FUNTYPE);
            func.SetValue("MISSION", MISSION);
            RFC.Invoke(func, true);
            IRfcTable et_table = func.GetTable("ET_TABLE");
            for (int i = 0; i < et_table.RowCount; i++)
            {
                et_table.CurrentIndex = i;
                ZSL_SDT076 node = new ZSL_SDT076();
                node.ITEM = et_table.GetString("ITEM").TrimStart('0');
                node.MISSION = et_table.GetString("MISSION");
                node.STATUS = et_table.GetString("STATUS");
                node.XGR = et_table.GetString("XGR");
                node.XGRQ = et_table.GetString("XGRQ");
                node.XGSJ = et_table.GetString("XGSJ");
                res.ET_TABLE.Add(node);
            }



            IRfcTable MSGtable = func.GetTable("T_MSG");
            if (MSGtable.RowCount > 0)
            {
                MSGtable.CurrentIndex = 0;
                res.MES_RETURN.TYPE = MSGtable.GetString("TYPE");
                res.MES_RETURN.MESSAGE = MSGtable.GetString("MESSAGE");
            }
            return res;
        }
    }
}
