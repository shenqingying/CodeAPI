using Sonluk.Entities.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.PS
{
    public interface ICNFH
    {
        CNFHLIST ModifyCNFH(List<ZSL_GXCN> ZSL_GXCNList);
        WBSPARMS ReadWBSPARMS();
        ZSL_NetworkList SELECTJGNETWORK(string I_PSPNR, List<ET_TCNRFPT> IT_RFPNT);
        PS_MSG UpdateNetwork(List<ZSL_NETWORK> nodes);
        ZSL_GXFHTABLE GXFHTABLE(PS_CXFHCS parslist);
        PS_MSG SYNCCNDATA();
        ZSL_NetworkList NETWORKWARNING(int I_ROWS);
        PS_MSG ZPSFUG_M_GZCN(ZSL_GZCN I_GZCN, List<ZSL_GZ_VLSCH> relationList, string flag);
        ZSL_GZCNList ZPSFUG_Q_GZCN(string GZMS);
        PS_MSG ZPSFUG_M_CALENDAR(ZSL_CALENDARList nodes, string I_CALENDAY, string I_WORKDAY);
        ZSL_CALENDARList ZPSFUG_Q_CALENDAR(string ksdate, string jsdate);
        GZCNREPORT ZPSFUG_Q_GZCNREPORT(string ksdate, string jsdate,string flag);
    }
}
