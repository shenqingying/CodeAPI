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
    public class CNFH : ICNFH
    {
        public CNFHLIST ModifyCNFH(List<ZSL_GXCN> ZSL_GXCNList)
        {
            CNFHLIST res = new CNFHLIST();
            List<ZSL_GXCN> nodes = new List<ZSL_GXCN>();
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_M_GXCN");
                IRfcTable i_table = func.GetTable("ET_TABLE");
                for (int i = 0; i < ZSL_GXCNList.Count; i++)
                {
                    i_table.Append();
                    i_table.SetValue("VLSCH", ZSL_GXCNList[i].VLSCH);
                    i_table.SetValue("CN", ZSL_GXCNList[i].CN);
                    i_table.SetValue("TXT", ZSL_GXCNList[i].TXT);
                    i_table.SetValue("FLAG", ZSL_GXCNList[i].FLAG);
                    i_table.SetValue("UNIT", ZSL_GXCNList[i].UNIT);
                  
                }
                RFC.Invoke(func, true);
                IRfcTable table = func.GetTable("ET_TABLE");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_GXCN node = new ZSL_GXCN();
                    node.VLSCH = table.GetString("VLSCH");
                    node.CN = table.GetString("CN");                   
                    node.TXT = table.GetString("TXT");
                    node.FLAG = table.GetString("FLAG");
                    node.UNIT = table.GetString("UNIT");
                    nodes.Add(node);
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
                  
         
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
          
            }
            res.ZSL_GXCN = nodes;
            res.PS_MSG = ps_msg;
            return res;
        }

        public WBSPARMS ReadWBSPARMS()
        {
            WBSPARMS res = new WBSPARMS();
            List<ET_PRPS> prpslist = new List<ET_PRPS>();
            List<ET_TCNRFPT> tcnrfpt = new List<ET_TCNRFPT>();
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_Q_WBSPARMS");
                RFC.Invoke(func, true);
                IRfcTable prps_table = func.GetTable("ET_PRPS");
                IRfcTable tcnrfpt_table = func.GetTable("ET_TCNRFPT");
                for (int i = 0; i < prps_table.RowCount; i++)
                {
                    prps_table.CurrentIndex = i;
                    ET_PRPS node = new ET_PRPS();
                    node.POSID = prps_table.GetString("POSID");
                    node.POST1 = prps_table.GetString("POST1");
                    node.PSPNR = prps_table.GetString("PSPNR");                   
                    prpslist.Add(node);
                }
                for (int i = 0; i < tcnrfpt_table.RowCount; i++)
                {
                    tcnrfpt_table.CurrentIndex = i;
                    ET_TCNRFPT node = new ET_TCNRFPT();
                    node.KTEXT = tcnrfpt_table.GetString("KTEXT");
                    node.RFPNT = tcnrfpt_table.GetString("RFPNT");
                    tcnrfpt.Add(node);
                }
                ps_msg.TYPE = "S";
            }
            catch (Exception e)
            {
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            res.ET_PRPS = prpslist;
            res.ET_TCNRFPT = tcnrfpt;
            res.PS_MSG = ps_msg;
            return res;
        }

        public ZSL_NetworkList SELECTJGNETWORK(string I_PSPNR, List<ET_TCNRFPT> IT_RFPNT)
        {
            ZSL_NetworkList res = new ZSL_NetworkList();
            List<ZSL_NETWORK> nodes = new List<ZSL_NETWORK>();
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_Q_JGNETWORK");

             
                IRfcTable i_table = func.GetTable("IT_RFPNT");
                for (int i = 0; i < IT_RFPNT.Count; i++)
                {
                    i_table.Append();                 
                    i_table.SetValue("RFPNT", IT_RFPNT[i].RFPNT);                          
                }

                func.SetValue("I_PSPNR", I_PSPNR);
                RFC.Invoke(func, true);

                IRfcTable table = func.GetTable("ET_NETWORK");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_NETWORK node = new ZSL_NETWORK();
                    node.AUFNR = table.GetString("AUFNR");
                    node.KTEXT = table.GetString("KTEXT");
                    node.ZMATNR = table.GetString("ZMATNR");
                    node.GSTRP = table.GetString("GSTRP");
                    node.GLTRP = table.GetString("GLTRP");
                    node.AUFPL = table.GetString("AUFPL");
                    nodes.Add(node);
                }

                ps_msg.TYPE = "S";

            }
            catch (Exception e)
            {               
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            res.ZSL_NETWORK = nodes;
            res.PS_MSG = ps_msg;
            return res;
            
        }

        public PS_MSG UpdateNetwork(List<ZSL_NETWORK> nodes)
        {
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_U_JGNETWORK");
                IRfcTable i_table = func.GetTable("IT_NETWORK");
                for (int i = 0; i < nodes.Count; i++)
                {
                    i_table.Append();
                    i_table.SetValue("AUFNR", nodes[i].AUFNR);
                    i_table.SetValue("GSTRP", nodes[i].GSTRP);
                    i_table.SetValue("GLTRP", nodes[i].GLTRP);
                }
                RFC.Invoke(func, true);
                IRfcTable table1 = func.GetTable("T_MSG");
                if (table1.RowCount > 0)
                {
                    table1.CurrentIndex = 0;
                    ps_msg.TYPE = table1.GetString("TYPE");
                    ps_msg.MESSAGE = table1.GetString("MESSAGE");
                }
                else
                {
                    ps_msg.TYPE = "S";

                }
            }
            catch (Exception e)
            {
                
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }

            return ps_msg;
        }
        public PS_MSG SYNCCNDATA()
        {
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_M_SYNCCNDATA");
                RFC.Invoke(func, true);
                ps_msg.TYPE = "S";
            }
            catch (Exception e)
            {
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
               
            }
            return ps_msg;
        }

        public ZSL_NetworkList NETWORKWARNING(int I_ROWS)
        {
            ZSL_NetworkList res = new ZSL_NetworkList();
            List<ZSL_NETWORK> nodes = new List<ZSL_NETWORK>();
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_Q_NETWORKWARNING");
                func.SetValue("I_ROWS", I_ROWS);
                RFC.Invoke(func, true);
                IRfcTable table = func.GetTable("ET_NETWORK");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_NETWORK node = new ZSL_NETWORK();
                    node.AUFNR = table.GetString("AUFNR");
                    node.KTEXT = table.GetString("KTEXT");
                    node.ZMATNR = table.GetString("ZMATNR");
                    node.GSTRP = table.GetString("GSTRP");
                    node.GLTRP = table.GetString("GLTRP");
                    node.AUFPL = table.GetString("AUFPL");

                    node.PSPID = table.GetString("PSPID");
                    node.POST1 = table.GetString("POST1");
                    node.POSID = table.GetString("POSID");
                    node.POST2 = table.GetString("POST2");
                    node.LTXA1 = table.GetString("LTXA1");
                    node.CYCLE = table.GetInt("CYCLE");
                    node.REMAINING = table.GetInt("REMAINING");
                    node.ZMAKTX = table.GetString("ZMAKTX");
                    node.ZMEINS = table.GetString("ZMEINS");
                    node.ZMENGE = table.GetInt("ZMENGE");
                    node.YJ = table.GetInt("YJ");
                    nodes.Add(node);
                }

                ps_msg.TYPE = "S";
            }
            catch (Exception e)
            {
                 ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
                throw;
            }

            res.ZSL_NETWORK = nodes;
            res.PS_MSG = ps_msg;
            return res;
        }

        public ZSL_GXFHTABLE GXFHTABLE(PS_CXFHCS parslist)
        {
            ZSL_GXFHTABLE nodes = new ZSL_GXFHTABLE();
            List<ZSL_GXCN> ZSL_GXCN_nodes = new List<ZSL_GXCN>();
            List<ZSL_ACTIVITY> ZSL_ACTIVITY_nodes = new List<ZSL_ACTIVITY>();
            List<ZSL_ACTIVITY_T> ZSL_ACTIVITY_T_nodes = new List<ZSL_ACTIVITY_T>();
            List<ZSL_GXCN_DAY> ZSL_GXCN_DAY_nodes = new List<ZSL_GXCN_DAY>();
            List<ZSL_GXCN_WEEK> ZSL_GXCN_WEEK_nodes = new List<ZSL_GXCN_WEEK>();
            List<ZSL_GXCN_MONTH> ZSL_GXCN_MONTH_nodes = new List<ZSL_GXCN_MONTH>();

            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_Q_GXFHTABLE");
                func.SetValue("I_BASEDATA", parslist.I_BASEDATA);
                func.SetValue("I_TEMPDATA", parslist.I_TEMPDATA);
                func.SetValue("I_DAYDATA", parslist.I_DAYDATA);
                func.SetValue("I_WEEKDATA", parslist.I_WEEKDATA);
                func.SetValue("I_MONTHDATA", parslist.I_MONTHDATA);
                func.SetValue("I_DAY", parslist.I_DAY);
                func.SetValue("I_DAY1", parslist.I_DAY1);
                RFC.Invoke(func, true);

                IRfcTable table1 = func.GetTable("ET_BASE");
                for (int i = 0; i < table1.RowCount; i++)
                {
                    table1.CurrentIndex = i;
                    ZSL_ACTIVITY node = new ZSL_ACTIVITY();
                    node.GC = table1.GetString("GC");
                    node.AUPFL = table1.GetString("AUPFL");
                    node.APLZL = table1.GetString("APLZL");
                    node.KSRQ = table1.GetString("KSRQ");
                    node.JSRQ = table1.GetString("JSRQ");
                    node.TCOUNT = table1.GetString("TCOUNT");
                    node.TOTAL = table1.GetString("TOTAL");
                    node.AVERAGE = table1.GetString("AVERAGE");
                    node.JLRQ = table1.GetString("JLRQ");
                    node.JLSJ = table1.GetString("JLSJ");
                    node.KTSCH = table1.GetString("KTSCH");
                    ZSL_ACTIVITY_nodes.Add(node);
                }
                IRfcTable table2 = func.GetTable("ET_TEMPBASE");
                for (int i = 0; i < table2.RowCount; i++)
                {
                    table2.CurrentIndex = i;
                    ZSL_ACTIVITY_T node = new ZSL_ACTIVITY_T();
                    node.GC = table2.GetString("GC");
                    node.AUPFL = table2.GetString("AUPFL");
                    node.APLZL = table2.GetString("APLZL");
                    node.KSRQ = table2.GetString("KSRQ");
                    node.JSRQ = table2.GetString("JSRQ");
                    node.TCOUNT = table2.GetString("TCOUNT");
                    node.TOTAL = table2.GetString("TOTAL");
                    node.AVERAGE = table2.GetString("AVERAGE");
                    node.JLRQ = table2.GetString("JLRQ");
                    node.JLSJ = table2.GetString("JLSJ");
                    ZSL_ACTIVITY_T_nodes.Add(node);
                }
                IRfcTable table3 = func.GetTable("ET_DAY");
                for (int i = 0; i < table3.RowCount; i++)
                {
                    table3.CurrentIndex = i;
                    ZSL_GXCN_DAY node = new ZSL_GXCN_DAY();
                    node.GC = table3.GetString("GC");
                    node.KTSCH = table3.GetString("KTSCH");
                    node.GXRQ = table3.GetString("GXRQ");
                    node.TOTAL = table3.GetString("TOTAL");
                    node.JLRQ = table3.GetString("JLRQ");
                    node.JLSJ = table3.GetString("JLSJ");
                    ZSL_GXCN_DAY_nodes.Add(node);
                }
                IRfcTable table4 = func.GetTable("ET_WEEK");
                for (int i = 0; i < table4.RowCount; i++)
                {
                    table4.CurrentIndex = i;
                    ZSL_GXCN_WEEK node = new ZSL_GXCN_WEEK();
                    node.GC = table4.GetString("GC");
                    node.KTSCH = table4.GetString("KTSCH");
                    node.CWEEK = table4.GetString("CWEEK");
                    node.CYEAR = table4.GetString("CYEAR");
                    node.TOTAL = table4.GetString("TOTAL");
                    node.JLRQ = table4.GetString("JLRQ");
                    node.JLSJ = table4.GetString("JLSJ");
                    ZSL_GXCN_WEEK_nodes.Add(node);
                }
                IRfcTable table5 = func.GetTable("ET_MONTH");
                for (int i = 0; i < table5.RowCount; i++)
                {
                    table5.CurrentIndex = i;
                    ZSL_GXCN_MONTH node = new ZSL_GXCN_MONTH();
                    node.GC = table5.GetString("GC");
                    node.KTSCH = table5.GetString("KTSCH");
                    node.GXMONTH = table5.GetString("GXMONTH");
                    node.TOTAL = table5.GetString("TOTAL");
                    node.JLRQ = table5.GetString("JLRQ");
                    node.JLSJ = table5.GetString("JLSJ");
                    node.CYEAR = table5.GetString("CYEAR");

                    ZSL_GXCN_MONTH_nodes.Add(node);
                }
                IRfcTable table = func.GetTable("ET_GXCN");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_GXCN node = new ZSL_GXCN();
                    node.VLSCH = table.GetString("VLSCH");
                    node.CN = table.GetString("CN");
                    node.TXT = table.GetString("TXT");
                    node.FLAG = table.GetString("FLAG");
                    node.UNIT = table.GetString("UNIT");
                    ZSL_GXCN_nodes.Add(node);
                }
                nodes.ZSL_ACTIVITY = ZSL_ACTIVITY_nodes;
                nodes.ZSL_ACTIVITY_T = ZSL_ACTIVITY_T_nodes;
                nodes.ZSL_GXCN_DAY = ZSL_GXCN_DAY_nodes;
                nodes.ZSL_GXCN_WEEK = ZSL_GXCN_WEEK_nodes;
                nodes.ZSL_GXCN_MONTH = ZSL_GXCN_MONTH_nodes;
                nodes.ZSL_GXCN = ZSL_GXCN_nodes;
                nodes.E_DAY = Convert.ToString(func.GetValue("E_DAY"));
                nodes.E_DAY1 = Convert.ToString(func.GetValue("E_DAY1"));

                ps_msg.TYPE = "S";

            }
            catch (Exception e)
            {

                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            nodes.PS_MSG = ps_msg;
            return nodes;
        }

        public ZSL_GZCNList ZPSFUG_Q_GZCN(string GZMS)
        {
            ZSL_GZCNList res = new ZSL_GZCNList();
            List<T435T> T435Tnodes = new List<T435T>();
            List<ZSL_GZ_VLSCH> ZSL_GZ_VLSCHnodes = new List<ZSL_GZ_VLSCH>();
            List<ZSL_GZCN> ZSL_GZCNnodes = new List<ZSL_GZCN>();
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_Q_GZCN");
                if (!string.IsNullOrEmpty(GZMS))
                {
                    func.SetValue("GZMS", GZMS);
                }                
                RFC.Invoke(func, true);
                IRfcTable table1 = func.GetTable("ET_T435T");
                for (int i = 0; i < table1.RowCount; i++)
                {
                    table1.CurrentIndex = i;
                    T435T node = new T435T();
                    node.MANDT = table1.GetString("MANDT");
                    node.SPRAS = table1.GetString("SPRAS");
                    node.TXT = table1.GetString("TXT");
                    node.VLSCH = table1.GetString("VLSCH");
                    T435Tnodes.Add(node);
                }
                IRfcTable table2 = func.GetTable("ET_RELATION");
                for (int i = 0; i < table2.RowCount; i++)
                {
                    table2.CurrentIndex = i;
                    ZSL_GZ_VLSCH node = new ZSL_GZ_VLSCH();
                    node.GZMS = table2.GetString("GZMS");
                    node.VLSCH = table2.GetString("VLSCH");
                    ZSL_GZ_VLSCHnodes.Add(node);
                }
                IRfcTable table3 = func.GetTable("ET_GZCN");
                for (int i = 0; i < table3.RowCount; i++)
                {
                    table3.CurrentIndex = i;
                    ZSL_GZCN node = new ZSL_GZCN();
                    node.GZMS = table3.GetString("GZMS");
                    node.CN = table3.GetString("CN");
                    node.UNIT = table3.GetString("UNIT");
                    ZSL_GZCNnodes.Add(node);
                }
                ps_msg.TYPE = "S";
            }
            catch (Exception e)
            {
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            res.ET_T435T = T435Tnodes;
            res.ZSL_GZ_VLSCH = ZSL_GZ_VLSCHnodes;
            res.ZSL_GZCN = ZSL_GZCNnodes;
            res.PS_MSG = ps_msg;
            return res;
        }
        public PS_MSG ZPSFUG_M_GZCN(ZSL_GZCN I_GZCN,List<ZSL_GZ_VLSCH> relationList,string flag)
        {
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_M_GZCN");
                IRfcStructure struc = func.GetStructure("I_GZCN");
                struc.SetValue("CN", I_GZCN.CN);
                struc.SetValue("GZMS", I_GZCN.GZMS);
                struc.SetValue("UNIT", I_GZCN.UNIT);
                func.SetValue("I_GZCN", struc);
                func.SetValue("I_FLAG", flag);
                
                IRfcTable i_table = func.GetTable("IT_RELATION");
                for (int i = 0; i < relationList.Count; i++)
                {
                    i_table.Append();
                    i_table.SetValue("GZMS", relationList[i].GZMS);
                    i_table.SetValue("VLSCH", relationList[i].VLSCH);
                    
                }
                RFC.Invoke(func, true);

                IRfcTable table1 = func.GetTable("T_MSG");
                table1.CurrentIndex = 0;
                ps_msg.TYPE = table1.GetString("TYPE");
                ps_msg.MESSAGE = table1.GetString("MESSAGE");
            }
            catch (Exception e)
            {
                
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
           
            return ps_msg;
        }
        public ZSL_CALENDARList ZPSFUG_Q_CALENDAR(string ksdate, string jsdate)
        {
            ZSL_CALENDARList res = new ZSL_CALENDARList();
            List<ZSL_WORKDAY> nodes_workday = new List<ZSL_WORKDAY>();
            List<ZSL_CALENDAR> nodes_calendar = new List<ZSL_CALENDAR>();
            PS_MSG ps_msg = new PS_MSG();
            ksdate = Convert.ToDateTime(ksdate).ToString("yyyyMMdd");
            jsdate = Convert.ToDateTime(jsdate).ToString("yyyyMMdd");
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_Q_CALENDAR");
                func.SetValue("KSDATE", ksdate);
                func.SetValue("JSDATE", jsdate);
                RFC.Invoke(func, true);
                IRfcTable table3 = func.GetTable("ET_WORKDAY");
                for (int i = 0; i < table3.RowCount; i++)
                {
                    table3.CurrentIndex = i;
                    ZSL_WORKDAY node = new ZSL_WORKDAY();
                    node.ISWORKDAY = table3.GetString("ISWORKDAY");
                    node.WEEKMS = table3.GetString("WEEKMS");
                    node.WEEKNO = table3.GetString("WEEKNO");
                    nodes_workday.Add(node);
                }
                IRfcTable table4 = func.GetTable("ET_CALENDAR");
                for (int i = 0; i < table4.RowCount; i++)
                {
                    table4.CurrentIndex = i;
                    ZSL_CALENDAR node = new ZSL_CALENDAR();
                    node.ISHOILDAY = table4.GetString("ISHOILDAY");
                    node.ISWORKDAY = table4.GetString("ISWORKDAY");
                    node.WEEKNO = table4.GetString("WEEKNO");
                    node.CDATE = table4.GetString("CDATE");
                    nodes_calendar.Add(node);
                }
                ps_msg.TYPE = "S";
                ps_msg.MESSAGE = table4.RowCount.ToString();
            }
            catch (Exception e)
            {
                ps_msg.TYPE = "E";
                ps_msg.MESSAGE = e.Message;
            }
            res.T_MSG = ps_msg;
            res.ZSL_CALENDAR = nodes_calendar;
            res.ZSL_WORKDAY = nodes_workday;
            return res;
        }
        public PS_MSG ZPSFUG_M_CALENDAR(ZSL_CALENDARList nodes, string I_CALENDAY, string I_WORKDAY)
        {
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_M_CALENDAR");
                func.SetValue("I_CALENDAY", I_CALENDAY);
                func.SetValue("I_WORKDAY", I_WORKDAY);
                IRfcTable i_table = func.GetTable("IT_WORKDAY");
                for (int i = 0; i < nodes.ZSL_WORKDAY.Count; i++)
                {
                    i_table.Append();
                    i_table.SetValue("WEEKNO", nodes.ZSL_WORKDAY[i].WEEKNO);
                    i_table.SetValue("WEEKMS", nodes.ZSL_WORKDAY[i].WEEKMS);
                    i_table.SetValue("ISWORKDAY", nodes.ZSL_WORKDAY[i].ISWORKDAY);                  
                }
                IRfcTable i_table1 = func.GetTable("IT_CALENDAR");
                for (int i = 0; i < nodes.ZSL_CALENDAR.Count; i++)
                {
                    i_table1.Append();
                    i_table1.SetValue("CDATE", nodes.ZSL_CALENDAR[i].CDATE);
                    i_table1.SetValue("WEEKNO", nodes.ZSL_CALENDAR[i].WEEKNO);
                    i_table1.SetValue("ISHOILDAY", nodes.ZSL_CALENDAR[i].ISHOILDAY);
                    i_table1.SetValue("ISWORKDAY", nodes.ZSL_CALENDAR[i].ISWORKDAY);
                }
                RFC.Invoke(func, true);
                IRfcTable table1 = func.GetTable("T_MSG");
                table1.CurrentIndex = 0;
                ps_msg.TYPE = table1.GetString("TYPE");
                ps_msg.MESSAGE = table1.GetString("MESSAGE");

            }
            catch (Exception e)
            {
               ps_msg.TYPE = "E";
               ps_msg.MESSAGE = e.Message;
            }
            return ps_msg;
        }
        public GZCNREPORT ZPSFUG_Q_GZCNREPORT(string ksdate, string jsdate,string flag)
        {
            GZCNREPORT node = new GZCNREPORT();
            List<ZSL_GZCN> ed = new List<ZSL_GZCN>();
            List<ZSL_GZCN> sj = new List<ZSL_GZCN>();
            List<ZSL_GZCN> past = new List<ZSL_GZCN>();
            PS_MSG ps_msg = new PS_MSG();
            try
            {
                IRfcFunction func = RFC.Function("ZPSFUG_Q_GZCNREPORT");
                func.SetValue("KSDATE", ksdate);
                func.SetValue("JSDATE", jsdate);
                func.SetValue("FLAG", flag);
                RFC.Invoke(func, true);
                node.ES_DATE =  func.GetString("ES_DATE");
                node.ES_INTERVAL = func.GetString("ES_INTERVAL");
                IRfcTable i_table1 = func.GetTable("ET_GZCN_ED");
                IRfcTable i_table2 = func.GetTable("ET_GZCN_SJ");
                IRfcTable i_table3 = func.GetTable("ET_GZCN_PAST");
                for (int i = 0; i < i_table1.RowCount; i++)
                {
                    i_table1.CurrentIndex = i;
                    ZSL_GZCN node1 = new ZSL_GZCN();
                    node1.GZMS = i_table1.GetString("GZMS");
                    node1.CN = i_table1.GetString("CN");
                    node1.UNIT = i_table1.GetString("UNIT");                  
                    ed.Add(node1);
                }
                for (int i = 0; i < i_table2.RowCount; i++)
                {
                    i_table2.CurrentIndex = i;
                    ZSL_GZCN node1 = new ZSL_GZCN();
                    node1.GZMS = i_table2.GetString("GZMS");
                    node1.CN = i_table2.GetString("CN");
                    node1.UNIT = i_table2.GetString("UNIT");                  
                    sj.Add(node1);
                }
                for (int i = 0; i < i_table3.RowCount; i++)
                {
                    i_table3.CurrentIndex = i;
                    ZSL_GZCN node1 = new ZSL_GZCN();
                    node1.GZMS = i_table3.GetString("GZMS");
                    node1.CN = i_table3.GetString("CN");
                    node1.UNIT = i_table3.GetString("UNIT");
                    past.Add(node1);
                }

                ps_msg.TYPE = "S";
            }
            catch (Exception e)
            {
               ps_msg.TYPE = "E";
               ps_msg.MESSAGE = e.Message;
            }
            node.PS_MSG = ps_msg;
            node.ET_GZCN_ED = ed;
            node.ET_GZCN_SJ = sj;
            node.ET_GZCN_PAST = past;
            return node;
        }
       

    }
}
