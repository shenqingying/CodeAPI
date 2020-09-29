using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.PS;
using Sonluk.IDataAccess.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.PS
{
    public class ComponentMove : IComponentMove
    {
        public PS_ZPSFUG_Q_CGDS Component_DSXX(string NPLNR)
        {
            PS_ZPSFUG_Q_CGDS ps = new PS_ZPSFUG_Q_CGDS();
            IRfcFunction func = RFC.Function("ZPSFUG_Q_CGDS");
            func.SetValue("I_NPLNR", NPLNR);
            Ps_cgds ps_cgds = new Ps_cgds();
            PS_MSG ps_msg = new PS_MSG();
            List<TLINE> LINES = new List<TLINE>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("T_OUT");
                if (table.RowCount > 0)
                {
                    table.CurrentIndex = 0;
                    ps_cgds.NPLNR = table.GetString("NPLNR");
                    ps_cgds.KTEXT = table.GetString("KTEXT");
                    ps_cgds.EBELN = table.GetString("EBELN");
                    ps_cgds.EBELP = table.GetString("EBELP");
                    ps_cgds.MENGE = table.GetDouble("MENGE");
                    ps_cgds.ERFMG_W = table.GetDouble("ERFMG_W");
                    ps_cgds.MEINS = table.GetString("MEINS");
                    ps_cgds.TXZ01 = table.GetString("TXZ01");
                    ps_cgds.LIFNR = table.GetString("LIFNR");
                    ps_cgds.NAME1 = table.GetString("NAME1");
                    ps_cgds.EKNAM = table.GetString("EKNAM");
                    ps_cgds.EKGRP = table.GetString("EKGRP");
                    ps_cgds.ARBPL = table.GetString("ARBPL");
                    ps_cgds.LARNT = table.GetString("LARNT");
                    ps_cgds.VORNR = table.GetString("VORNR");
                    ps_cgds.WERKS = table.GetString("WERKS");
                }
                IRfcTable table1 = func.GetTable("T_MSG");
                if (table1.RowCount > 0)
                {
                    table1.CurrentIndex = 0;
                    ps_msg.TYPE = table1.GetString("TYPE");
                    ps_msg.MESSAGE = table1.GetString("MESSAGE");
                }
                IRfcTable table2 = func.GetTable("LINES");
                for (int i = 0; i < table2.RowCount; i++)
                {
                    table2.CurrentIndex = i;
                    TLINE child = new TLINE();
                    child.TDFORMAT = table2.GetString("TDFORMAT");
                    child.TDLINE = table2.GetString("TDLINE");
                    LINES.Add(child);
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            ps.T_OUT = ps_cgds;
            ps.T_MSG = ps_msg;
            ps.LINES = LINES;
            return ps;
        }

        public string Component_ljds(ZSL_PSS_INC_CGDS i_in)
        {
            string rst = "";
            IRfcFunction func = RFC.Function("ZPSFUG_C_CGDS");
            IRfcStructure struc = func.GetStructure("I_IN");
            struc.SetValue("ERFMG", i_in.ERFMG);
            struc.SetValue("MENGE", i_in.MENGE);
            struc.SetValue("EBELN", i_in.EBELN);
            struc.SetValue("EBELP", i_in.EBELP);
            struc.SetValue("BKTXT", i_in.BKTXT);
            struc.SetValue("AUFNR", i_in.AUFNR);
            struc.SetValue("VORNR", i_in.VORNR);
            struc.SetValue("INITS", i_in.INITS);
            struc.SetValue("LARNT", i_in.LARNT);
            struc.SetValue("ARBPL", i_in.ARBPL);
            struc.SetValue("WERKS", i_in.WERKS);
            struc.SetValue("MEINS", i_in.MEINS);
            func.SetValue("I_IN", struc);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("T_MSG");
                if (table.RowCount > 0)
                {
                    table.CurrentIndex = 0;
                    rst = table.GetString("TYPE") + table.GetString("MESSAGE");

                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                rst = "E" + e.Message;
            }
            return rst;
        }


        public IList<ComponentCM> ComponentCM_GET(string IV_VERIF)
        {
            IList<ComponentCM> componentcm = new List<ComponentCM>();
            IRfcFunction func = RFC.Function("ZBCFUN_CW_GET");
            func.SetValue("IV_VERIF", IV_VERIF);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("ET_LGPLA");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ComponentCM child = new ComponentCM();
                    child.VERIF = table.GetString("VERIF");
                    child.LGPLA = table.GetString("LGPLA");
                    child.LGNUM = table.GetString("LGNUM");
                    componentcm.Add(child);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return componentcm;
        }

        public string ComponentPutAway(PS_componentputaway ps_componentputaway)
        {
            string rst = "";
            IRfcFunction func = RFC.Function("ZPSFUG_C_LJSJ");
            IRfcStructure struc = func.GetStructure("I_IN");
            struc.SetValue("RUFNM", ps_componentputaway.RUFNM);
            struc.SetValue("AUFNR", ps_componentputaway.AUFNR);
            struc.SetValue("MENGE", ps_componentputaway.MENGE);
            struc.SetValue("NLPLA", ps_componentputaway.NLPLA);
            struc.SetValue("ZMATNR", ps_componentputaway.ZMATNR);
            struc.SetValue("POSID", ps_componentputaway.POSID);
            struc.SetValue("ARBPL", ps_componentputaway.ARBPL);
            struc.SetValue("LARNT", ps_componentputaway.LARNT);
            struc.SetValue("VORNR", ps_componentputaway.VORNR);
            struc.SetValue("LGNUM", ps_componentputaway.LGNUM);
            struc.SetValue("LGTYP", ps_componentputaway.LGTYP);
            struc.SetValue("LGBER", ps_componentputaway.LGBER);
            struc.SetValue("LPTYP", ps_componentputaway.LPTYP);
            struc.SetValue("WERKS", ps_componentputaway.WERKS);
            struc.SetValue("LGORT", ps_componentputaway.LGORT);
            func.SetValue("I_IN", struc);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("T_MSG");
                if (table.RowCount > 0)
                {
                    table.CurrentIndex = 0;
                    rst = table.GetString("TYPE") + table.GetString("MESSAGE");

                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                rst = "E" + e.Message;
            }
            return rst;
        }

        public PS_ZPSFUG_Q_CMCC ComponentInventory_CM(string I_VERIF)
        {
            PS_ZPSFUG_Q_CMCC ps = new PS_ZPSFUG_Q_CMCC();
            List<PS_ComponentInventory> ps_out = new List<PS_ComponentInventory>();
            PS_MSG ps_msg = new PS_MSG();
            IRfcFunction func = RFC.Function("ZPSFUG_Q_CMCC");
            func.SetValue("I_VERIF", I_VERIF);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("T_OUT");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    PS_ComponentInventory child = new PS_ComponentInventory();
                    child.VERIF = table.GetString("VERIF");
                    child.LGNUM = table.GetString("LGNUM");
                    child.LGTYP = table.GetString("LGTYP");
                    child.LGBER = table.GetString("LGBER");
                    child.LGPLA = table.GetString("LGPLA");
                    child.LPTYP = table.GetString("LPTYP");
                    ps_out.Add(child);
                }
                IRfcTable table1 = func.GetTable("T_MSG");
                if (table1.RowCount > 0)
                {
                    table1.CurrentIndex = 0;
                    ps_msg.TYPE = table1.GetString("TYPE");
                    ps_msg.MESSAGE = table1.GetString("MESSAGE");
                }

            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            ps.T_OUT = ps_out;
            ps.T_MSG = ps_msg;
            return ps;
        }


        public PS_ZPSFUG_Q_WLCC ComponentInventory_Network(string I_AUFNR)
        {
            PS_ZPSFUG_Q_WLCC ps = new PS_ZPSFUG_Q_WLCC();
            ZSL_PSS_OUT_WLCC ps_network = new ZSL_PSS_OUT_WLCC();
            PS_MSG ps_msg = new PS_MSG();
            IRfcFunction func = RFC.Function("ZPSFUG_Q_WLCC");
            func.SetValue("I_AUFNR", I_AUFNR);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("T_OUT");
                if (table.RowCount > 0)
                {
                    table.CurrentIndex = 0;
                    ps_network.AUFNR = table.GetString("AUFNR");
                    ps_network.KTEXT = table.GetString("KTEXT");
                    ps_network.ZMATNR = table.GetString("ZMATNR");
                    ps_network.MAKTX = table.GetString("MAKTX");
                    ps_network.ZMENGE = table.GetString("ZMENGE");
                    ps_network.ZMEINS = table.GetString("ZMEINS");
                    ps_network.POSID = table.GetString("POSID");
                    ps_network.POST1 = table.GetString("POST1");
                    ps_network.WERKS = table.GetString("WERKS");
                    ps_network.VERNR = table.GetString("VERNR");
                    ps_network.VERNA = table.GetString("VERNA");
                    ps_network.PSPID = table.GetString("PSPID");
                    ps_network.POST1_OJ = table.GetString("POST1_OJ");
                }
                IRfcTable table1 = func.GetTable("T_MSG");
                if (table1.RowCount > 0)
                {
                    table1.CurrentIndex = 0;
                    ps_msg.TYPE = table1.GetString("TYPE");
                    ps_msg.MESSAGE = table1.GetString("MESSAGE");
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            ps.T_OUT = ps_network;
            ps.T_MSG = ps_msg;
            return ps;
        }

        public PS_ZPSFUG_Q_LJXJ ComponentSoldout_read(string I_SENUM, string I_ZROWSNUM)
        {
            PS_ZPSFUG_Q_LJXJ ps_rtn = new PS_ZPSFUG_Q_LJXJ();
            IRfcFunction func = RFC.Function("ZPSFUG_Q_LJXJ");
            func.SetValue("I_SENUM", I_SENUM);
            func.SetValue("I_ZROWSNUM", I_ZROWSNUM);
            ZSL_PSS_OUT_LJXJ ps_ljxj = new ZSL_PSS_OUT_LJXJ();
            List<ZSL_PSS_OUT_LJXJ01> PS_ljxj01 = new List<ZSL_PSS_OUT_LJXJ01>();
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable struc = func.GetTable("T_OUT_HEAD");
                if (struc.RowCount > 0)
                {
                    struc.CurrentIndex = 0;
                    ps_ljxj.POSID = struc.GetString("POSID");
                    ps_ljxj.POST1 = struc.GetString("POST1");
                    ps_ljxj.WERKS = struc.GetString("WERKS");
                    ps_ljxj.MATNR = struc.GetString("MATNR");
                    ps_ljxj.MAKTX = struc.GetString("MAKTX");
                    ps_ljxj.ACOUNT = struc.GetString("ACOUNT");
                    ps_ljxj.WPCOUNT = struc.GetString("WPCOUNT");
                    ps_ljxj.MEINS = struc.GetString("MEINS");
                    ps_ljxj.RSNUM = struc.GetString("RSNUM");
                    ps_ljxj.RSPOS = struc.GetString("RSPOS");
                    ps_ljxj.SOBKZ = struc.GetString("SOBKZ");
                }
                IRfcTable table = func.GetTable("T_OUT_ITEM");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_PSS_OUT_LJXJ01 child = new ZSL_PSS_OUT_LJXJ01();
                    child.LGPLA = table.GetString("LGPLA");
                    child.VERME = table.GetString("VERME");
                    PS_ljxj01.Add(child);
                }
                IRfcTable tablemsg = func.GetTable("T_MSG");
                tablemsg.CurrentIndex = 0;
                ps_msg.TYPE = tablemsg.GetString("TYPE");
                ps_msg.MESSAGE = tablemsg.GetString("MESSAGE");
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            ps_rtn.T_OUT_HEAD = ps_ljxj;
            ps_rtn.T_OUT_ITEM = PS_ljxj01;
            ps_rtn.T_MSG = ps_msg;
            return ps_rtn;
        }

        public PS_MSG ComponentSoldout(ZSL_PSS_INC_LJXJ ps_i)
        {
            PS_MSG ps = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_C_LJXJ");
                IRfcStructure struc = func.GetStructure("I_IN");
                struc.SetValue("RSNUM", ps_i.RSNUM);
                struc.SetValue("RSPOS", ps_i.RSPOS);
                struc.SetValue("MATNR", ps_i.MATNR);
                struc.SetValue("SENUM", ps_i.SENUM);
                struc.SetValue("ZROWSNUM", ps_i.ZROWSNUM);
                struc.SetValue("LGPLA", ps_i.LGPLA);
                struc.SetValue("VERME", ps_i.VERME);
                struc.SetValue("MENGE", ps_i.MENGE);
                struc.SetValue("LGBER", ps_i.LGBER);
                struc.SetValue("LPTYP", ps_i.LPTYP);
                struc.SetValue("LGNUM", ps_i.LGNUM);
                struc.SetValue("WERKS", ps_i.WERKS);
                struc.SetValue("LGORT", ps_i.LGORT);
                struc.SetValue("LGTYP", ps_i.LGTYP);
                struc.SetValue("ZJUDGE", ps_i.ZJUDGE);
                struc.SetValue("ZUSER", ps_i.ZUSER);
                func.SetValue("I_IN", struc);
                //IRfcTable struc1 = func.GetTable("T_IN");
                //struc1.Append();
                //struc1.CurrentRow.SetValue("MENGE", ps_t.MENGE);
                //struc1.CurrentRow.SetValue("LGPLA", ps_t.LGPLA);
                //struc1.CurrentRow.SetValue("VERME", ps_t.VERME);
                //func.SetValue("T_IN", struc1);
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("T_MSG");
                if (table.RowCount > 0)
                {
                    table.CurrentIndex = 0;
                    //rst = table.GetString("TYPE") + table.GetString("MESSAGE");
                    ps.TYPE = table.GetString("TYPE");
                    ps.MESSAGE = table.GetString("MESSAGE");
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ps.TYPE = "E";
                ps.MESSAGE = e.Message;
            }
            return ps;
        }

        public PS_MSG ComponentMoving_all(ZSL_PSS_INC_LJYC i_in)
        {
            PS_MSG ps = new PS_MSG();
            IRfcFunction func = RFC.Function("ZPSFUG_C_LJYC");
            IRfcStructure struc = func.GetStructure("I_IN");
            struc.SetValue("WERKS", i_in.WERKS);
            struc.SetValue("LGORT", i_in.LGORT);
            struc.SetValue("LGNUM", i_in.LGNUM);
            struc.SetValue("LPTYP", i_in.LPTYP);
            struc.SetValue("NLTYP", i_in.NLTYP);
            struc.SetValue("NLBER", i_in.NLBER);
            struc.SetValue("NLPLA", i_in.NLPLA);
            struc.SetValue("VLTYP", i_in.VLTYP);
            struc.SetValue("VLBER", i_in.VLBER);
            struc.SetValue("VLPLA", i_in.VLPLA);
            struc.SetValue("MATNR", i_in.MATNR);
            struc.SetValue("ANFME", i_in.ANFME);
            struc.SetValue("MEINS", i_in.MEINS);
            struc.SetValue("POSID", i_in.POSID);
            struc.SetValue("BESTQ", i_in.BESTQ);
            struc.SetValue("CHARG", i_in.CHARG);
            func.SetValue("I_IN", struc);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("T_MSG");
                if (table.RowCount > 0)
                {
                    table.CurrentIndex = 0;
                    ps.TYPE = table.GetString("TYPE");
                    ps.MESSAGE = table.GetString("MESSAGE");
                }
            }
            catch (Exception e)
            {
                ps.TYPE = "E";
                ps.MESSAGE = e.Message;
            }
            return ps;
        }
    }
}
