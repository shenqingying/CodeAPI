using Sonluk.IDataAccess.HR;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public sealed class HRDataAccess
    {
        private static readonly string assembly = AppConfig.Settings("RMS.DataAccess");
        private HRDataAccess() { }
        public static ISY_GS CreateSY_GS()
        {
            return (ISY_GS)Assembly.Load(assembly).CreateInstance(assembly + ".HR.SY_GS");
        }
        public static ISY_TYPEMX CreateSY_TYPEMX()
        {
            return (ISY_TYPEMX)Assembly.Load(assembly).CreateInstance(assembly + ".HR.SY_TYPEMX");
        }
        public static ISY_TYPE CreateSY_TYPE()
        {
            return (ISY_TYPE)Assembly.Load(assembly).CreateInstance(assembly + ".HR.SY_TYPE");
        }
        public static ISY_DEPT CreateSY_DEPT()
        {
            return (ISY_DEPT)Assembly.Load(assembly).CreateInstance(assembly + ".HR.SY_DEPT");
        }
        public static IGS_GSSL CreateGS_GSSL()
        {
            return (IGS_GSSL)Assembly.Load(assembly).CreateInstance(assembly + ".HR.GS_GSSL");
        }
        public static IXZGL_TAX_TAXSLMX CreateXZGL_TAX_TAXSLMX()
        {
            return (IXZGL_TAX_TAXSLMX)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_TAX_TAXSLMX");
        }
        public static ISY_DUTY CreateSY_DUTY()
        {
            return (ISY_DUTY)Assembly.Load(assembly).CreateInstance(assembly + ".HR.SY_DUTY");
        }
        public static IRY_RYINFO CreateRY_RYINFO()
        {
            return (IRY_RYINFO)Assembly.Load(assembly).CreateInstance(assembly + ".HR.RY_RYINFO");
        }
        public static IXZGL_FLFA CreateXZGL_FLFA()
        {
            return (IXZGL_FLFA)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_FLFA");
        }
        public static IXZGL_FLFAMX CreateXZGL_FLFAMX()
        {
            return (IXZGL_FLFAMX)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_FLFAMX");
        }
        public static IXZGL_XZDA_GZLB CreateXZGL_XZDA_GZLB()
        {
            return (IXZGL_XZDA_GZLB)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_XZDA_GZLB");
        }
        public static IXZGL_FFJLZD CreateXZGL_FFJLZD()
        {
            return (IXZGL_FFJLZD)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_FFJLZD");
        }
        public static IXZGL_XZDA CreateXZGL_XZDA()
        {
            return (IXZGL_XZDA)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_XZDA");
        }
        public static ISY_MYINFO CreateSY_MYINFO()
        {
            return (ISY_MYINFO)Assembly.Load(assembly).CreateInstance(assembly + ".HR.SY_MYINFO");
        }
        public static IXZGL_ZXFJKC CreateXZGL_ZXFJKC()
        {
            return (IXZGL_ZXFJKC)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_ZXFJKC");
        }
        public static IRY_BANKNO CreateRY_BANKNO()
        {
            return (IRY_BANKNO)Assembly.Load(assembly).CreateInstance(assembly + ".HR.RY_BANKNO");
        }
        public static IXZGL_FLDA CreateXZGL_FLDA()
        {
            return (IXZGL_FLDA)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_FLDA");
        }
        public static IKQ_JQGL CreateKQ_JQGL()
        {
            return (IKQ_JQGL)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_JQGL");
        }
        public static IKQ_JQGLMX CreateKQ_JQGLMX()
        {
            return (IKQ_JQGLMX)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_JQGLMX");
        }
        public static IXZGL_FLDATZ CreateXZGL_FLDATZ()
        {
            return (IXZGL_FLDATZ)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_FLDATZ");
        }
        public static IXZGL_FLDATZMX CreateXZGL_FLDATZMX()
        {
            return (IXZGL_FLDATZMX)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_FLDATZMX");
        }
        public static IXZGL_MBGL CreateXZGL_MBGL()
        {
            return (IXZGL_MBGL)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_MBGL");
        }
        public static IXZGL_MBGLMX CreateXZGL_MBGLMX()
        {
            return (IXZGL_MBGLMX)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_MBGLMX");
        }
        public static IXZGL_KKGL CreateXZGL_KKGL()
        {
            return (IXZGL_KKGL)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_KKGL");
        }
        public static IXZGL_KKGLMX CreateXZGL_KKGLMX()
        {
            return (IXZGL_KKGLMX)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_KKGLMX");
        }
        public static IXZGL_FFJL CreateXZGL_FFJL()
        {
            return (IXZGL_FFJL)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_FFJL");
        }
        public static IXZGL_FFJLMX CreateXZGL_FFJLMX()
        {
            return (IXZGL_FFJLMX)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_FFJLMX");
        }
        public static IGS_LY CreateGS_LY()
        {
            return (IGS_LY)Assembly.Load(assembly).CreateInstance(assembly + ".HR.GS_LY");
        }
        public static ISY_ZJH CreateSY_ZJH()
        {
            return (ISY_ZJH)Assembly.Load(assembly).CreateInstance(assembly + ".HR.SY_ZJH");
        }
        public static IXZGL_ZDGLGL CreateXZGL_ZDGLGL()
        {
            return (IXZGL_ZDGLGL)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_ZDGLGL");
        }
        public static IROLE_DEPT CreateROLE_DEPT()
        {
            return (IROLE_DEPT)Assembly.Load(assembly).CreateInstance(assembly + ".HR.ROLE_DEPT");
        }
        public static IRY_RYINFO_RSDA CreateRY_RYINFO_RSDA()
        {
            return (IRY_RYINFO_RSDA)Assembly.Load(assembly).CreateInstance(assembly + ".HR.RY_RYINFO_RSDA");
        }
        public static IKQ_KQINFO CreateIKQ_KQINFO()
        {
            return (IKQ_KQINFO)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_KQINFO");
        }
        public static IKQ_BD CreateIKQ_BD()
        {
            return (IKQ_BD)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_BD");
        }
        public static IKQ_BZ CreateIKQ_BZ()
        {
            return (IKQ_BZ)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_BZ");
        }
        public static IKQ_BZ_BDID CreateIKQ_BZ_BDID()
        {
            return (IKQ_BZ_BDID)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_BZ_BDID");
        }
        public static IKQ_DEPTKQ CreateIKQ_DEPTKQ()
        {
            return (IKQ_DEPTKQ)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_DEPTKQ");
        }
        public static IPX_PXZT CreatePX_PXZT()
        {
            return (IPX_PXZT)Assembly.Load(assembly).CreateInstance(assembly + ".HR.PX_PXZT");
        }
        public static IKQ_DEPTID_FZID CreateIKQ_DEPTID_FZID()
        {
            return (IKQ_DEPTID_FZID)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_DEPTID_FZID");
        }
        public static IKQ_PBFZ CreateIKQ_PBFZ()
        {
            return (IKQ_PBFZ)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_PBFZ");
        }
        public static IKQ_PBFZ_BZID CreateIKQ_PBFZ_BZID()
        {
            return (IKQ_PBFZ_BZID)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_PBFZ_BZID");
        }
        public static IKQ_RYID_BZID CreateIKQ_RYID_BZID()
        {
            return (IKQ_RYID_BZID)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_RYID_BZID");
        }
        public static IDA_DAINFO CreateIDA_DAINFO()
        {
            return (IDA_DAINFO)Assembly.Load(assembly).CreateInstance(assembly + ".HR.DA_DAINFO");
        }
        public static IBOOK_BOOKINFO CreateIBOOK_BOOKINFO()
        {
            return (IBOOK_BOOKINFO)Assembly.Load(assembly).CreateInstance(assembly + ".HR.BOOK_BOOKINFO");
        }
        public static IKQ_WCDJ CreateIKQ_WCDJ()
        {
            return (IKQ_WCDJ)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_WCDJ");
        }
        public static IKQ_GSKQ CreateIKQ_GSKQ()
        {
            return (IKQ_GSKQ)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_GSKQ");
        }
        public static IKQ_YCKQ CreateIKQ_YCKQ()
        {
            return (IKQ_YCKQ)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_YCKQ");
        }
        public static IXZGL_JJFL_HEARNAME CreateIXZGL_JJFL_HEARNAME()
        {
            return (IXZGL_JJFL_HEARNAME)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_JJFL_HEARNAME");
        }
        public static IXZGL_JJFL_HEAD CreateIXZGL_JJFL_HEAD()
        {
            return (IXZGL_JJFL_HEAD)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_JJFL_HEAD");
        }
        public static IXZGL_JJFL_MX CreateIXZGL_JJFL_MX()
        {
            return (IXZGL_JJFL_MX)Assembly.Load(assembly).CreateInstance(assembly + ".HR.XZGL_JJFL_MX");
        }
        public static IKQ_QJ CreateIKQ_QJ()
        {
            return (IKQ_QJ)Assembly.Load(assembly).CreateInstance(assembly + ".HR.KQ_QJ");
        }
        public static ISY_CHANGEINFO CreateISY_CHANGEINFO()
        {
            return (ISY_CHANGEINFO)Assembly.Load(assembly).CreateInstance(assembly + ".HR.SY_CHANGEINFO");
        }
        public static IADMINISTRATION_DORM CreateIADMINISTRATION_DORM()
        {
            return (IADMINISTRATION_DORM)Assembly.Load(assembly).CreateInstance(assembly + ".HR.ADMINISTRATION_DORM");
        }
        public static IADMINISTRATION_YHRY CreateIADMINISTRATION_YHRY()
        {
            return (IADMINISTRATION_YHRY)Assembly.Load(assembly).CreateInstance(assembly + ".HR.ADMINISTRATION_YHRY");
        }
    }
}
