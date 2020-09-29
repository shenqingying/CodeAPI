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
    public class NetWork : INetWork
    {
        public NetworkRead NetWork_READ(string AUFNR)
        {
            NetworkRead node = new NetworkRead();
            IRfcFunction func = RFC.Function("ZPSFUG_Q_BGCX");
            func.SetValue("I_AUFNR", AUFNR);
            NetworkINFO s_NETWORK = new NetworkINFO();
            List<Ps_vorINFO> children = new List<Ps_vorINFO>();
            List<Ps_trugINFO> children1 = new List<Ps_trugINFO>();
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                RFC.Invoke(func, false);
                IRfcStructure struc = func.GetStructure("E_NETWORK");
                s_NETWORK.Aufnr = struc.GetString("AUFNR");
                s_NETWORK.Ktext = struc.GetString("KTEXT");
                s_NETWORK.Posid = struc.GetString("POSID");
                s_NETWORK.Post1 = struc.GetString("POST1");
                s_NETWORK.Zmatnr = struc.GetString("ZMATNR");
                s_NETWORK.Maktx = struc.GetString("MAKTX");
                s_NETWORK.Zmenge = struc.GetDouble("ZMENGE");
                s_NETWORK.Zmeins = struc.GetString("ZMEINS");
                s_NETWORK.Gltrp = struc.GetString("GLTRP");
                s_NETWORK.Gstrp = struc.GetString("GSTRP");
                IRfcStructure struc1 = func.GetStructure("ET_RETURN");
                ps_msg.TYPE = struc1.GetString("TYPE");
                ps_msg.MESSAGE = struc1.GetString("MESSAGE");

                IRfcTable table = func.GetTable("E_VOR");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    Ps_vorINFO child = new Ps_vorINFO();
                    child.Vornr = table.GetString("VORNR");
                    child.LtxA1 = table.GetString("LTXA1");
                    child.Confirmnum = table.GetDouble("CONFIRMNUM");
                    child.Scrapnum = table.GetDouble("SCRAPNUM");
                    child.Arbei = table.GetDouble("ARBEI");
                    child.Arbeh = table.GetString("ARBEH");
                    child.Arbpl = table.GetString("ARBPL");
                    child.SUBNUM = table.GetDouble("SUBNUM");
                    child.USR02 = table.GetString("USR02");
                    child.USR03 = table.GetString("USR03");
                    child.STEUS = table.GetString("STEUS");
                    child.AUERU = table.GetString("AUERU");
                    child.KTSCH = table.GetString("KTSCH");
                    children.Add(child);
                }

                IRfcTable table1 = func.GetTable("E_TRUG");
                for (int i = 0; i < table1.RowCount; i++)
                {
                    table1.CurrentIndex = i;
                    Ps_trugINFO child1 = new Ps_trugINFO();
                    child1.Grund = table1.GetString("GRUND");
                    child1.Grdtx = table1.GetString("GRDTX");
                    children1.Add(child1);
                }

            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            node.E_network = s_NETWORK;
            node.E_vor = children;
            node.E_trug = children1;
            node.ET_RETURN = ps_msg;
            return node;
        }


        public string NetWork_CONFIRM(Ps_work ps_work, Ps_staff ps_staff)
        {

            string reslut = "";
            NetworkRead node = new NetworkRead();
            IRfcFunction func = RFC.Function("ZPSFUG_C_BGQR");
            IRfcStructure struc = func.GetStructure("IV_PARAMETER");
            IRfcStructure struc1 = func.GetStructure("IV_STAFF");
            struc.SetValue("VORNR", ps_work.Vornr);
            struc.SetValue("OPRZ1", ps_work.OpRz1);
            struc.SetValue("OPRE1", ps_work.Opre1);
            struc.SetValue("GRUND", ps_work.Grund);
            struc.SetValue("ISMNW", ps_work.Ismnw);
            struc.SetValue("PERNR", ps_work.Pernr);
            struc.SetValue("AUERU", ps_work.Aueru);
            struc.SetValue("LEKNW", ps_work.Leknw);
            struc.SetValue("IEDD", ps_work.Iedd);
            struc.SetValue("AUFNR", ps_work.Aufnr);
            struc.SetValue("LTXA1", ps_work.Ltxa1);
            struc.SetValue("ARBPL", ps_work.Arbpl);
            struc.SetValue("KTSCH", ps_work.KTSCH);
            struc1.SetValue("INITS", ps_staff.Inits);
            struc1.SetValue("PERNR", ps_staff.Pernr);
            struc1.SetValue("RUFNM", ps_staff.Rufnm);
            func.SetValue("IV_PARAMETER", struc);
            func.SetValue("IV_STAFF", struc1);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("ET_MESSAGE");
                table.CurrentIndex = 0;
                reslut = table.GetString("TYPE") + table.GetString("MESSAGE");

            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                reslut = "E" + e.Message;
            }
            return reslut;
        }


        public IList<PS_SXXGOA> PS_OA_XMXX(string PSPID, string POSID, string PSPIDPO, string POSIDPO)
        {
            IRfcFunction func = RFC.Function("ZPSFUG_Q_XXGOA");
            func.SetValue("PSPID", PSPID);
            func.SetValue("POSID", POSID);
            func.SetValue("PSPIDPO", PSPIDPO);
            func.SetValue("POSIDPO", POSIDPO);
            IList<PS_SXXGOA> children = new List<PS_SXXGOA>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("T_OUT");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    PS_SXXGOA child = new PS_SXXGOA();
                    child.PSPID = table.GetString("PSPID");
                    child.PSPT1 = table.GetString("PSPT1");
                    child.POSID = table.GetString("POSID");
                    child.POST1 = table.GetString("POST1");
                    child.VERNR = table.GetString("VERNR");
                    child.VERNA = table.GetString("VERNA");
                    children.Add(child);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return children;
        }

        public IList<PS_wlXX> PS_OA_wlxx(string MATNR, string MAKTX)
        {
            string returns = "";
            IRfcFunction func = RFC.Function("ZPSFUG_Q_WLXXGOA");
            func.SetValue("MATNR", MATNR);
            func.SetValue("MAKTX", MAKTX);
            IList<PS_wlXX> children = new List<PS_wlXX>();
            try
            {
                RFC.Invoke(func, false);
                returns = func.GetString("RETURNS");
                IRfcTable table = func.GetTable("T_OUT");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    PS_wlXX child = new PS_wlXX();
                    child.WERKS = table.GetString("WERKS");
                    child.MATNR = table.GetString("MATNR");
                    child.MAKTX = table.GetString("MAKTX");
                    child.MEINS = table.GetString("MEINS");
                    child.EKGRP = table.GetString("EKGRP");
                    child.EKNAM = table.GetString("EKNAM");
                    children.Add(child);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return children;
        }

        public IList<ZSL_PSS_OUT_NAME> PS_OA_GYSMC(string I_EBELN)
        {
            IList<ZSL_PSS_OUT_NAME> ps = new List<ZSL_PSS_OUT_NAME>();
            IRfcFunction func = RFC.Function("ZPSFUG_Q_NAME1");
            func.SetValue("I_EBELN", I_EBELN);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("T_OUT");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_PSS_OUT_NAME child = new ZSL_PSS_OUT_NAME();
                    child.LIFNR = table.GetString("LIFNR");
                    child.NAME1 = table.GetString("NAME1");
                    child.EBELP = table.GetString("EBELP");
                    child.MATNR = table.GetString("MATNR");
                    child.TXZ01 = table.GetString("TXZ01");
                    child.MENGE = table.GetString("MENGE");
                    child.MEINS = table.GetString("MEINS");
                    child.POSID = table.GetString("POSID");
                    child.PSPOST1 = table.GetString("PSPOST1");
                    child.PSPID = table.GetString("PSPID");
                    child.OJPOST1 = table.GetString("OJPOST1");
                    child.EKGRP = table.GetString("EKGRP");
                    child.EKNAM = table.GetString("EKNAM");
                    child.VERNR = table.GetString("VERNR");
                    child.VERNA = table.GetString("VERNA");
                    ps.Add(child);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return ps;
        }


        public string StaffINFO(string INITS)
        {
            string rst = "";
            IRfcFunction func = RFC.Function("ZSLFUG_Q_YGCX");
            IRfcStructure struc = func.GetStructure("IV_STAFF");
            struc.SetValue("INITS", INITS);
            func.SetValue("IV_STAFF", struc);
            try
            {
                RFC.Invoke(func, false);
                IRfcStructure strucout = func.GetStructure("E_STAFF");
                rst = strucout.GetString("RUFNM");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return rst;
        }


        public PS_ZPSFUG_Q_LJSJ NetWork_READ_main(string AUFNR)
        {
            IRfcFunction func = RFC.Function("ZPSFUG_Q_LJSJ");
            func.SetValue("I_AUFNR", AUFNR);
            PS_ZPSFUG_Q_LJSJ ps = new PS_ZPSFUG_Q_LJSJ();
            ZSL_PSS_OUT_LJSJ t_out = new ZSL_PSS_OUT_LJSJ();
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("T_OUT");
                if (table.RowCount > 0)
                {
                    table.CurrentIndex = 0;
                    t_out.AUFNR = table.GetString("AUFNR");
                    t_out.KTEXT = table.GetString("KTEXT");
                    t_out.ZMATNR = table.GetString("ZMATNR");
                    t_out.MAKTX = table.GetString("MAKTX");
                    t_out.ZMENGE = table.GetString("ZMENGE");
                    t_out.WMENGE = table.GetString("WMENGE");
                    t_out.ZMEINS = table.GetString("ZMEINS");
                    t_out.POSID = table.GetString("POSID");
                    t_out.POST1 = table.GetString("POST1");
                    t_out.VORNR = table.GetString("VORNR");
                    t_out.LARNT = table.GetString("LARNT");
                    t_out.ARBPL = table.GetString("ARBPL");
                    t_out.WERKS = table.GetString("WERKS");
                }
                IRfcTable table1 = func.GetTable("T_MSG");
                table1.CurrentIndex = 0;
                ps_msg.TYPE = table1.GetString("TYPE");
                ps_msg.MESSAGE = table1.GetString("MESSAGE");
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            ps.T_OUT = t_out;
            ps.T_MSG = ps_msg;
            return ps;
        }
    }
}
