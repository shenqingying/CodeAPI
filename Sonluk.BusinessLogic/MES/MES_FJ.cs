using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class MES_FJ
    {
        private static readonly ISY_TYPEMX ISY_TYPEMXdata = MESDataAccess.CreateSY_TYPEMX();
        private static readonly ISY_MATERIAL ISY_MATERIALdata = MESDataAccess.CreateSY_MATERIAL();
        private static readonly IMES_MM IMES_MMdata = MESDataAccess.CreateMES_MM();
        private static readonly ISY_SYSCS ISY_SYSCSdata = MESDataAccess.CreateISY_SYSCS();
        private static readonly ISY_PFDH_WL ISY_PFDH_WLdata = MESDataAccess.CreateSY_PFDH_WL();
        public ZBCFUN_XFPC_READ SELECT_XFPC_BY_XFCD(int XFCD)
        {
            ZBCFUN_XFPC_READ rst = new ZBCFUN_XFPC_READ();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            if (XFCD == 0)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "输入的锌粉产地不能为空！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
            MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
            model_MES_SY_TYPEMX.ID = XFCD;
            List<MES_SY_TYPEMXLIST> rst_MES_SY_TYPEMXLIST = ISY_TYPEMXdata.SELECT(model_MES_SY_TYPEMX).ToList();
            if (rst_MES_SY_TYPEMXLIST.Count == 0)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "请检查选择的锌粉产地！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
            MES_SY_MATERIAL model_MES_SY_MATERIAL = new MES_SY_MATERIAL();
            model_MES_SY_MATERIAL.GC = rst_MES_SY_TYPEMXLIST[0].GC;
            model_MES_SY_MATERIAL.WLMS = rst_MES_SY_TYPEMXLIST[0].MXNAME;
            MES_SY_MATERIAL_SELECT rst_MES_SY_MATERIAL_SELECT = ISY_MATERIALdata.SELECT(model_MES_SY_MATERIAL);
            if (rst_MES_SY_MATERIAL_SELECT.MES_RETURN.TYPE != "S")
            {
                rst.MES_RETURN = rst_MES_SY_MATERIAL_SELECT.MES_RETURN;
                return rst;
            }
            if (rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL.Count != 1)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "请检查选择的锌粉产地对应物料号是否维护！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
            //rst = IMES_MMdata.GET_XFPC_READ(rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].GC, rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].WLH);
            rst = GET_XFPC_READ_NEW1(rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].GC, rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].WLH);
            return rst;
        }

        public ZBCFUN_XFPC_READ SELECT_PC(string GC, string WLH)
        {
            ZBCFUN_XFPC_READ rst = new ZBCFUN_XFPC_READ();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            if (GC == "" || WLH == "")
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "输入的锌粉产地不能为空！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
            //rst = IMES_MMdata.GET_XFPC_READ(GC, WLH);
            rst = GET_XFPC_READ_NEW1(GC, WLH);
            return rst;
        }
        public ZBCFUN_XFPC_READ GET_XFPC_READ_NEW1(string WERKS, string MATNR)
        {
            string mes_werks_pdly = "";
            if (WERKS == "")
            {
                mes_werks_pdly = "0";
            }
            else
            {
                mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_" + WERKS + "_GDLY");
            }

            MES_RETURN mr = new MES_RETURN();
            ZBCFUN_XFPC_READ rst = new ZBCFUN_XFPC_READ();
            if (mes_werks_pdly == "0")
            {
                rst = IMES_MMdata.GET_XFPC_READ(WERKS, MATNR);
            }
            else if (mes_werks_pdly == "1")
            {
                ZSL_BCS304 model_ZSL_BCS304 = new ZSL_BCS304();
                model_ZSL_BCS304.WERKS = WERKS;
                model_ZSL_BCS304.MATNR = MATNR;
                MES_SY_XFPC_SYNC_SELECT rst_MES_SY_XFPC_SYNC_SELECT = ISY_PFDH_WLdata.XFPC_SYNC_SELECT(model_ZSL_BCS304, 1);
                if (rst_MES_SY_XFPC_SYNC_SELECT.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_XFPC_SYNC_SELECT.MES_RETURN;
                    return rst;
                }
                List<ZSL_BCS304> rst_ZSL_BCS304 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCS304>>(Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_XFPC_SYNC_SELECT.ZSL_BCS304));
                rst.ET_CHARG = rst_ZSL_BCS304;
                mr.TYPE = "S";
                mr.MESSAGE = "";
                rst.MES_RETURN = mr;
            }
            return rst;
        }
    }
}
