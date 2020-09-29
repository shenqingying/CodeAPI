using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.Entities.QM;
using Sonluk.Entities.SAP;
using Sonluk.IDataAccess.MES;
using Sonluk.IDataAccess.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.QM
{
    public class ZSL_QMFG_RFC
    {
        private static readonly IZSL_QMFG_RFC data_IZSL_QMFG_RFC = QMDataAccess.CreateIZSL_QMFG_RFC();
        private static readonly ISY_GZZX data_ISY_GZZX = MESDataAccess.CreateSY_GZZX();
        private static readonly IMES_ROLE data_MES_ROLE = MESDataAccess.CreateIMES_ROLE();

        public ZSL_QMFM_012_SELECT ZSL_QMFM_012(ZSL_QMFM_012_SELECT model)
        {
            ZSL_QMFM_012_SELECT rst = data_IZSL_QMFG_RFC.ZSL_QMFM_012(model);
            if (rst.MES_RETURN.TYPE == "S")
            {
                List<ZSL_QMS012> ET_YHINFO = new List<ZSL_QMS012>();
                if (model.GC != "" && model.GZZXBH != "")
                {
                    for (int a = 0; a < rst.ET_YHINFO.Count; a++)
                    {
                        if (rst.ET_YHINFO[a].WERKS == model.GC && rst.ET_YHINFO[a].ARBPL == model.GZZXBH && rst.ET_YHINFO[a].LIFNR_PO == "")
                        {
                            ET_YHINFO.Add(rst.ET_YHINFO[a]);
                        }
                    }
                }
                else
                {
                    MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                    model_MES_SY_GZZX.GC = model.GC;
                    model_MES_SY_GZZX.STAFFID = model.STAFFID;
                    List<MES_SY_GZZX> rst_MES_SY_GZZXlist = data_ISY_GZZX.SELECT_BY_ROLE(model_MES_SY_GZZX).ToList();
                    if (rst_MES_SY_GZZXlist.Count == 0)
                    {
                        ET_YHINFO = new List<ZSL_QMS012>();
                        rst.ET_YHINFO = ET_YHINFO;
                    }
                    for (int a = 0; a < rst.ET_YHINFO.Count; a++)
                    {
                        for (int b = 0; b < rst_MES_SY_GZZXlist.Count; b++)
                        {
                            if (rst.ET_YHINFO[a].WERKS == rst_MES_SY_GZZXlist[b].GC && rst.ET_YHINFO[a].ARBPL == rst_MES_SY_GZZXlist[b].GZZXBH && rst.ET_YHINFO[a].LIFNR_PO == "")
                            {
                                ET_YHINFO.Add(rst.ET_YHINFO[a]);
                                break;
                            }
                        }
                    }
                    MES_ROLE_GYS model_MES_ROLE_GYS = new MES_ROLE_GYS();
                    model_MES_ROLE_GYS.LB = 1;
                    model_MES_ROLE_GYS.STAFFID = model.STAFFID;
                    MES_ROLE_GYS_SELECT rst_MES_ROLE_GYS_SELECT = data_MES_ROLE.SELECT_GYS(model_MES_ROLE_GYS);
                    if (rst_MES_ROLE_GYS_SELECT.MES_RETURN.TYPE == "S")
                    {
                        for (int a = 0; a < rst.ET_YHINFO.Count; a++)
                        {
                            for (int b = 0; b < rst_MES_ROLE_GYS_SELECT.MES_ROLE_GYS.Count; b++)
                            {
                                if (rst.ET_YHINFO[a].WERKS == rst_MES_ROLE_GYS_SELECT.MES_ROLE_GYS[b].GC && rst.ET_YHINFO[a].LIFNR_PO == rst_MES_ROLE_GYS_SELECT.MES_ROLE_GYS[b].GYS)
                                {
                                    ET_YHINFO.Add(rst.ET_YHINFO[a]);
                                    break;
                                }
                            }
                        }
                    }
                }
                rst.ET_YHINFO = ET_YHINFO;
            }
            return rst;
        }
    }
}
