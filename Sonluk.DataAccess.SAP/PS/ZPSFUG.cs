using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.MES;
using Sonluk.Entities.PS;
using Sonluk.Entities.SAP;
using Sonluk.IDataAccess.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.PS
{
    public class ZPSFUG : IZPSFUG
    {
        public ZPSFUG_Q_XMXXOA_SELECT ZPSFUG_Q_XMXXOA(string POSID, string PSPID)
        {
            ZPSFUG_Q_XMXXOA_SELECT rst = new ZPSFUG_Q_XMXXOA_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            ZSL_XMXX child_ZSL_XMXX = new ZSL_XMXX();
            IRfcFunction func = RFC.Function("ZPSFUG_Q_XMXXOA");
            func.SetValue("POSID", POSID);
            func.SetValue("PSPID", PSPID);
            RFC.Invoke(func, false);
            IRfcStructure struc_CT_XM = func.GetStructure("CT_XM");
            child_ZSL_XMXX.XMMS = struc_CT_XM.GetString("XMMS");
            child_ZSL_XMXX.XMLX = struc_CT_XM.GetString("XMLX");
            child_ZSL_XMXX.GC = struc_CT_XM.GetString("GC");
            child_ZSL_XMXX.ZCBH = struc_CT_XM.GetString("ZCBH");
            child_ZSL_XMXX.POSID = "";
            child_ZSL_XMXX.PSPID = "";

            IRfcStructure struc_CT_RETURN = func.GetStructure("CT_RETURN");
            child_MES_RETURN.TYPE = struc_CT_RETURN.GetString("TYPE");
            child_MES_RETURN.MESSAGE = struc_CT_RETURN.GetString("MESSAGE");

            rst.MES_RETURN = child_MES_RETURN;
            rst.CT_XM = child_ZSL_XMXX;
            return rst;
        }
    }
}
