using Sonluk.DAFactory;
using Sonluk.Entities.PS;
using Sonluk.IDataAccess.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.PS
{
    public class CNFH
    {
        private static readonly ICNFH detaAccess = PSDataAccess.CreateCNFH();
        public CNFHLIST ModifyCNFH(List<ZSL_GXCN> ZSL_GXCNList)
        {
            return detaAccess.ModifyCNFH(ZSL_GXCNList);
        }
        public WBSPARMS ReadWBSPARMS()
        {
            return detaAccess.ReadWBSPARMS();
        }
        public ZSL_NetworkList SELECTJGNETWORK(string I_PSPNR, List<ET_TCNRFPT> IT_RFPNT)
        {
            return detaAccess.SELECTJGNETWORK(I_PSPNR,IT_RFPNT);
        }
        public PS_MSG UpdateNetwork(List<ZSL_NETWORK> nodes)
        {
            return detaAccess.UpdateNetwork(nodes);
        }
        public ZSL_GXFHTABLE GXFHTABLE(PS_CXFHCS parslist)
        {
            return detaAccess.GXFHTABLE(parslist);
        }
        public PS_MSG SYNCCNDATA()
        {
            return detaAccess.SYNCCNDATA();
        }
        public ZSL_NetworkList NETWORKWARNING(int I_ROWS)
        {
            return detaAccess.NETWORKWARNING(I_ROWS);
        }
        public PS_MSG ZPSFUG_M_GZCN(ZSL_GZCN I_GZCN, List<ZSL_GZ_VLSCH> relationList, string flag)
        {
            return detaAccess.ZPSFUG_M_GZCN(I_GZCN, relationList,flag);
        }
        public ZSL_GZCNList ZPSFUG_Q_GZCN(string GZMS)
        {
            return detaAccess.ZPSFUG_Q_GZCN(GZMS);
        }
        public PS_MSG ZPSFUG_M_CALENDAR(ZSL_CALENDARList nodes, string I_CALENDAY, string I_WORKDAY)
        {
            return detaAccess.ZPSFUG_M_CALENDAR(nodes, I_CALENDAY, I_WORKDAY);
        }
        public ZSL_CALENDARList ZPSFUG_Q_CALENDAR(string ksdate, string jsdate)
        {
            return detaAccess.ZPSFUG_Q_CALENDAR(ksdate, jsdate);
        }
        public GZCNREPORT ZPSFUG_Q_GZCNREPORT(string ksdate, string jsdate,string flag)
        {
            return detaAccess.ZPSFUG_Q_GZCNREPORT(ksdate, jsdate,flag);
        }
    }
}
