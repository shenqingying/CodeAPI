using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.CRM
{
    public class KH_HZHB : IKH_HZHB_SAP
    {
        public SAP_HZHBList SyncSapRead(IList<SAP_KH> t_KH,int khlx)
        {

            SAP_HZHBList nodes = new SAP_HZHBList();
            IList<SAP_KH> KH_nodes = new List<SAP_KH>();
            IList<SAP_KHXS> XS_nodes = new List<SAP_KHXS>();
            IList<SAP_HZHB> HB_nodes = new List<SAP_HZHB>();
           
           
            
            try
            {
                IRfcFunction func = RFC.Function("ZSD_CUS_READ");
                func.SetValue("I_KHLX", khlx);
                IRfcTable i_table = func.GetTable("ET_KH");
               
                for (int i = 0; i < t_KH.Count; i++)
                {
                    i_table.Append();
                    i_table.SetValue("KUNNR", t_KH[i].KUNNR);
                }
                func.SetValue("ET_KH", i_table);
                RFC.Invoke(func, false);
                IRfcTable KH_table = func.GetTable("ET_KH");
                if (KH_table.RowCount > 0)
                {
                    for (int i = 0; i < KH_table.RowCount; i++)
                    {
                        SAP_KH KH_node = new SAP_KH();
                        KH_table.CurrentIndex = i;
                        KH_node.KUNNR = KH_table.GetString("KUNNR");
                        KH_node.NAME1 = KH_table.GetString("NAME1");
                        KH_node.BEZEI = KH_table.GetString("BEZEI");
                        KH_node.ORT01 = KH_table.GetString("ORT01");
                        KH_node.STREET = KH_table.GetString("STREET");
                        KH_node.TEL_NUMBER = KH_table.GetString("TEL_NUMBER");
                        KH_node.STCEG = KH_table.GetString("STCEG");
                        KH_node.YHZH = KH_table.GetString("YHZH");
                        KH_node.BANKA = KH_table.GetString("BANKA");
                        KH_node.NAME2 = KH_table.GetString("NAME2");
                        KH_node.TELF1 = KH_table.GetString("TELF1");
                        KH_nodes.Add(KH_node);
                    }
                    nodes.ET_KH = KH_nodes.ToList();
                }
                IRfcTable XS_table = func.GetTable("ET_KHXS");
                if (XS_table.RowCount > 0)
                {
                    for (int i = 0; i < XS_table.RowCount; i++)
                    {

                        SAP_KHXS XS_node = new SAP_KHXS();
                        XS_table.CurrentIndex = i;
                        XS_node.KUNNR = XS_table.GetString("KUNNR");
                        XS_node.VKORG = XS_table.GetString("VKORG");
                        XS_node.VTWEG = XS_table.GetString("VTWEG");
                        XS_node.SPART = XS_table.GetString("SPART");
                        XS_node.BZIRK = XS_table.GetString("BZIRK");
                        XS_node.VKBUR = XS_table.GetString("VKBUR");
                        XS_node.VKGRP = XS_table.GetString("VKGRP");

                        XS_nodes.Add(XS_node);
                    }
                    nodes.ET_KHXS = XS_nodes.ToList();
                }
                IRfcTable HB_table = func.GetTable("ET_KHHZ");
                if (HB_table.RowCount > 0)
                {
                    for (int i = 0; i < HB_table.RowCount; i++)
                    {
                        SAP_HZHB HB_node = new SAP_HZHB();
                        HB_table.CurrentIndex = i;
                        HB_node.KUNNR = HB_table.GetString("KUNNR");
                        HB_node.VKORG = HB_table.GetString("VKORG");
                        HB_node.VTWEG = HB_table.GetString("VTWEG");
                        HB_node.SPART = HB_table.GetString("SPART");
                        HB_node.PARVW = HB_table.GetString("PARVW");
                        HB_node.PARZA = HB_table.GetString("PARZA");
                        HB_node.KUNN2 = HB_table.GetString("KUNN2");
                        HB_nodes.Add(HB_node);
                        
                    }
                    nodes.ET_KHHZ = HB_nodes.ToList();
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
