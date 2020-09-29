using Sonluk.IDataAccess.MES;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public sealed class MESDataAccess
    {
        private static readonly string assembly = AppConfig.Settings("RMS.DataAccess");
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");

        private MESDataAccess() { }
        public static ISY_GC CreateSY_GC()
        {
            return (ISY_GC)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_GC");
        }
        public static ISY_MACHINEINFO CreateSY_MACHINEINFO()
        {
            return (ISY_MACHINEINFO)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_MACHINEINFO");
        }
        public static ISY_TYPE CreateSY_TYPE()
        {
            return (ISY_TYPE)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_TYPE");
        }
        public static ISY_TYPEMX CreateSY_TYPEMX()
        {
            return (ISY_TYPEMX)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_TYPEMX");
        }
        public static ISY_GZZX CreateSY_GZZX()
        {
            return (ISY_GZZX)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_GZZX");
        }
        public static ISY_GZZX_SBH CreateSY_GZZX_SBH()
        {
            return (ISY_GZZX_SBH)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_GZZX_SBH");
        }
        public static IMM_CK CreateMM_CK()
        {
            return (IMM_CK)Assembly.Load(assembly).CreateInstance(assembly + ".MES.MM_CK");
        }
        public static ISY_PFDH CreateSY_PFDH()
        {
            return (ISY_PFDH)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_PFDH");
        }
        public static ISY_MATERIAL_GROUP CreateSY_MATERIAL_GROUP()
        {
            return (ISY_MATERIAL_GROUP)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_MATERIAL_GROUP");
        }
        public static ISY_MATERIAL CreateSY_MATERIAL()
        {
            return (ISY_MATERIAL)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_MATERIAL");
        }
        public static IPD_GD CreatePD_GD()
        {
            return (IPD_GD)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PD_GD");
        }
        public static ISY_YERACOUNT CreateSY_YERACOUNT()
        {
            return (ISY_YERACOUNT)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_YERACOUNT");
        }
        public static IPD_SCRW CreatePD_SCRW()
        {
            return (IPD_SCRW)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PD_SCRW");
        }
        public static ITM_TMINFO CreateTM_TMINFO()
        {
            return (ITM_TMINFO)Assembly.Load(assembly).CreateInstance(assembly + ".MES.TM_TMINFO");
        }
        public static IPD_TL CreatePD_TL()
        {
            return (IPD_TL)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PD_TL");
        }
        public static ITM_GL CreateTM_GL()
        {
            return (ITM_GL)Assembly.Load(assembly).CreateInstance(assembly + ".MES.TM_GL");
        }
        public static ITM_CZR CreateTM_CZR()
        {
            return (ITM_CZR)Assembly.Load(assembly).CreateInstance(assembly + ".MES.TM_CZR");
        }
        public static IROLE_GZZX CreateROLE_GZZX()
        {
            return (IROLE_GZZX)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ROLE_GZZX");
        }
        public static IROLE_ASSEMBLE CreateROLE_ASSEMBLE()
        {
            return (IROLE_ASSEMBLE)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ROLE_ASSEMBLE");
        }
        public static IPUBLIC_FUNC CreatePUBLIC_FUNC()
        {
            return (IPUBLIC_FUNC)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PUBLIC_FUNC");
        }
        public static IROLR_GZZX_GW CreateROLR_GZZX_GW()
        {
            return (IROLR_GZZX_GW)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ROLR_GZZX_GW");
        }
        public static IROLE_CK CreateROLE_CK()
        {
            return (IROLE_CK)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ROLE_CK");
        }
        public static ISY_GZZX_WLLB CreateSY_GZZX_WLLB()
        {
            return (ISY_GZZX_WLLB)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_GZZX_WLLB");
        }
        public static ISY_GZZX_SBH_WLLB CreateSY_GZZX_SBH_WLLB()
        {
            return (ISY_GZZX_SBH_WLLB)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_GZZX_SBH_WLLB");
        }
        public static ISY_DCXH_COUNT CreateSY_DCXH_COUNT()
        {
            return (ISY_DCXH_COUNT)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_DCXH_COUNT");
        }
        public static ISY_PFDH_WL CreateSY_PFDH_WL()
        {
            return (ISY_PFDH_WL)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_PFDH_WL");
        }
        public static ITM_WLPZ CreateTM_WLPZ()
        {
            return (ITM_WLPZ)Assembly.Load(assembly).CreateInstance(assembly + ".MES.TM_WLPZ");
        }
        public static ITM_ZFDCMX CreateTM_ZFDCMX()
        {
            return (ITM_ZFDCMX)Assembly.Load(assembly).CreateInstance(assembly + ".MES.TM_ZFDCMX");
        }
        public static ISY_PLDH CreateSY_PLDH()
        {
            return (ISY_PLDH)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_PLDH");
        }
        public static ISY_XTBB CreateSY_XTBB()
        {
            return (ISY_XTBB)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_XTBB");
        }
        public static ISY_STAFF CreateSY_STAFF()
        {
            return (ISY_STAFF)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_STAFF");
        }
        public static IROLE_GC CreateROLE_GC()
        {
            return (IROLE_GC)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ROLE_GC");
        }
        public static IROLE_RY_ASSEMBLE CreateROLE_RY_ASSEMBLE()
        {
            return (IROLE_RY_ASSEMBLE)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ROLE_RY_ASSEMBLE");
        }
        public static IPD_TL_ERROR CreatePD_TL_ERROR()
        {
            return (IPD_TL_ERROR)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PD_TL_ERROR");
        }
        public static ISY_MATERIAL_BZCOUNT CreateSY_MATERIAL_BZCOUNT()
        {
            return (ISY_MATERIAL_BZCOUNT)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_MATERIAL_BZCOUNT");
        }
        public static IRIGHT_ROLE CreateRIGHT_ROLE()
        {
            return (IRIGHT_ROLE)Assembly.Load(assembly).CreateInstance(assembly + ".MES.RIGHT_ROLE");
        }
        public static ISY_MACBB CreateSY_MACBB()
        {
            return (ISY_MACBB)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_MACBB");
        }
        public static ISY_PFDH_CHILD CreateSY_PFDH_CHILD()
        {
            return (ISY_PFDH_CHILD)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_PFDH_CHILD");
        }
        public static ISY_PLDH_PH CreateSY_PLDH_PH()
        {
            return (ISY_PLDH_PH)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_PLDH_PH");
        }
        public static IPD_GD_BOM CreatePD_GD_BOM()
        {
            return (IPD_GD_BOM)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PD_GD_BOM");
        }
        public static ISY_TYPEMX_CHILD CreateSY_TYPEMX_CHILD()
        {
            return (ISY_TYPEMX_CHILD)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_TYPEMX_CHILD");
        }
        public static ISY_CHANGEINFO CreateSY_CHANGEINFO()
        {
            return (ISY_CHANGEINFO)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_CHANGEINFO");
        }
        public static ISY_SCDATE_TH CreateSY_SCDATE_TH()
        {
            return (ISY_SCDATE_TH)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_SCDATE_TH");
        }
        public static ISY_SYSCS CreateISY_SYSCS()
        {
            return (ISY_SYSCS)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_SYSCS");
        }
        public static ISY_EXCEPTION CreateISY_EXCEPTION()
        {
            return (ISY_EXCEPTION)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_EXCEPTION");
        }
        public static ISY_LANGUAGE_YM CreateISY_LANGUAGE_YM()
        {
            return (ISY_LANGUAGE_YM)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_LANGUAGE_YM");
        }
        public static ISY_TPM_SYNC CreateISY_TPM_SYNC()
        {
            return (ISY_TPM_SYNC)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_TPM_SYNC");
        }
        public static IBAT_SPECS CreateBAT_SPECS()
        {
            return (IBAT_SPECS)Assembly.Load(assembly).CreateInstance(assembly + ".MES.BAT_SPECS");
        }
        public static IBAT_SPECS_SAMP CreateBAT_SPECS_SAMP()
        {
            return (IBAT_SPECS_SAMP)Assembly.Load(assembly).CreateInstance(assembly + ".MES.BAT_SPECS_SAMP");
        }
        public static IBAT_SPECS_PERFOR CreateBAT_SPECS_PERFOR()
        {
            return (IBAT_SPECS_PERFOR)Assembly.Load(assembly).CreateInstance(assembly + ".MES.BAT_SPECS_PERFOR");
        }
        public static ISY_LANGUAGE_RETURN CreateISY_LANGUAGE_RETURN()
        {
            return (ISY_LANGUAGE_RETURN)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_LANGUAGE_RETURN");
        }
        public static IBAT_PACKAGE CreateBAT_PACKAGE()
        {
            return (IBAT_PACKAGE)Assembly.Load(assembly).CreateInstance(assembly + ".MES.BAT_PACKAGE");
        }
        public static IBAT_REPORT CreateBAT_REPORT()
        {
            return (IBAT_REPORT)Assembly.Load(assembly).CreateInstance(assembly + ".MES.BAT_REPORT");
        }
        public static IFB_QMP CreateIFB_QMP()
        {
            return (IFB_QMP)Assembly.Load(assembly).CreateInstance(assembly + ".MES.FB_QMP");
        }
        public static ISY_RYGH CreateISY_RYGH()
        {
            return (ISY_RYGH)Assembly.Load(assembly).CreateInstance(assembly + ".MES.SY_RYGH");
        }
        public static IBAT_QLTY CreateBAT_QLTY()
        {
            return (IBAT_QLTY)Assembly.Load(assembly).CreateInstance(assembly + ".MES.BAT_QLTY");
        }
        public static IBAT_QLTY_STAFF CreateBAT_QLTY_STAFF()
        {
            return (IBAT_QLTY_STAFF)Assembly.Load(assembly).CreateInstance(assembly + ".MES.BAT_QLTY_STAFF");
        }
        public static IBAT_QLTY_TMARK CreateBAT_QLTY_TMARK()
        {
            return (IBAT_QLTY_TMARK)Assembly.Load(assembly).CreateInstance(assembly + ".MES.BAT_QLTY_TMARK");
        }
        public static IPMM_QR CreatePMM_QR()
        {
            return (IPMM_QR)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PMM_QR");
        }
        public static IPMM_MOULD CreatePMM_MOULD()
        {
            return (IPMM_MOULD)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PMM_MOULD");
        }
        public static IPMM_SYS CreatePMM_SYS()
        {
            return (IPMM_SYS)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PMM_SYS");
        }
        public static IPMM_STAFF CreatePMM_STAFF()
        {
            return (IPMM_STAFF)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PMM_STAFF");
        }
        public static IPMM_MTC CreatePMM_MTC()
        {
            return (IPMM_MTC)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PMM_MTC");
        }
        public static IPMM_MTC_CAVE CreatePMM_MTC_CAVE()
        {
            return (IPMM_MTC_CAVE)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PMM_MTC_CAVE");
        }
        public static IPMM_MTC_REP CreatePMM_MTC_REP()
        {
            return (IPMM_MTC_REP)Assembly.Load(assembly).CreateInstance(assembly + ".MES.PMM_MTC_REP");
        }
        public static IZS_SY_CLPB CreateIZS_SY_CLPB()
        {
            return (IZS_SY_CLPB)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ZS_SY_CLPB");
        }
        public static IZS_SY_TL CreateIZS_SY_TL()
        {
            return (IZS_SY_TL)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ZS_SY_TL");
        }
        public static IZS_QJ_QJJL CreateIZS_QJ_QJJL()
        {
            return (IZS_QJ_QJJL)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ZS_QJ_QJJL");
        }
        public static IZS_SY_JL CreateIZS_SY_JL()
        {
            return (IZS_SY_JL)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ZS_SY_JL");
        }
        public static IZS_SY_KU CreateIZS_SY_KU()
        {
            return (IZS_SY_KU)Assembly.Load(assembly).CreateInstance(assembly + ".MES.ZS_SY_KU");
        }
        public static IMES_SYNC CreateIMES_SYNC()
        {
            return (IMES_SYNC)Assembly.Load(assembly).CreateInstance(assembly + ".MES.MES_SYNC");
        }
        public static IMES_ROLE CreateIMES_ROLE()
        {
            return (IMES_ROLE)Assembly.Load(assembly).CreateInstance(assembly + ".MES.MES_ROLE");
        }













        public static IMES_MM CreateMES_MM()
        {
            return (IMES_MM)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".MES.MES_MM");
        }
        public static IMES_PLDH CreateMES_PLDH()
        {
            return (IMES_PLDH)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".MES.MES_PLDH");
        }
        public static IMES_PP CreateMES_PP()
        {
            return (IMES_PP)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".MES.MES_PP");
        }
        public static IMES_TPM CreateMES_TPM()
        {
            return (IMES_TPM)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".MES.MES_TPM");
        }

    }
}
