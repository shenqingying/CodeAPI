using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class BAT_PACKAGE
    {
        private static readonly IBAT_PACKAGE mesdataAccess = MESDataAccess.CreateBAT_PACKAGE();
        private static readonly ISY_GC DA_SY_GC = MESDataAccess.CreateSY_GC();
        public MES_PD_GD_PACKINFO_SELECT SELECT_LIST(MES_PD_GD_PACKINFO_SEARCH model, int STAFFID)
        {
            //实例化
            MES_PD_GD_PACKINFO_SELECT rst = new MES_PD_GD_PACKINFO_SELECT();
            rst.MES_PD_GD_PACKINFO = new List<MES_PD_GD_PACKINFO>();
            rst.MES_RETURN = new MES_RETURN();
            rst.MES_RETURN.MESSAGE = "";

            //根据日期或工厂查询工单单号,并检查授权
            if (model.GC == "")
            {
                MES_SY_GC model_SY_GC = new MES_SY_GC();
                model_SY_GC.STAFFID = STAFFID;
                IList<MES_SY_GC> model_SY_GC_list = DA_SY_GC.SELECT_BY_ROLE(model_SY_GC);
                for (int i = 0; i < model_SY_GC_list.Count; i++)
                {
                    MES_PD_GD_PACKINFO_SELECT rst_child = new MES_PD_GD_PACKINFO_SELECT();
                    model.GC = model_SY_GC_list[i].GC;
                    rst_child = mesdataAccess.SELECT_ERPINFO(model);
                    if (rst_child.MES_RETURN.TYPE == "S")
                    {
                        for (int j = 0; j < rst_child.MES_PD_GD_PACKINFO.Count; j++)
                        {
                            rst.MES_PD_GD_PACKINFO.Add(rst_child.MES_PD_GD_PACKINFO[j]);
                        }
                    }
                    else
                    {
                        rst.MES_RETURN.TYPE = "E";
                        rst.MES_RETURN.MESSAGE = "查询失败，错误原因：" + rst_child.MES_RETURN.MESSAGE;
                        return rst;
                    }
                }
            }
            else if (FTY_AUZ_Verify(model.GC, STAFFID))
            {
                rst = mesdataAccess.SELECT_ERPINFO(model);
            }
            else
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "工厂未授权！";
                return rst;
            }

            //根据工单单号查询包装信息
            if (rst.MES_PD_GD_PACKINFO.Count == 0)
            {
                rst.MES_RETURN.TYPE = "W";
                rst.MES_RETURN.MESSAGE = "订单未找到！";
                return rst;
            }
            else
            {
                rst.MES_RETURN.TYPE = "S";
                for (int i = 0; i < rst.MES_PD_GD_PACKINFO.Count; i++)
                {
                    MES_PD_GD_PACKINFO child = new MES_PD_GD_PACKINFO();
                    child = mesdataAccess.SELECT_SINGLE(rst.MES_PD_GD_PACKINFO[i].GDDH);
                    if (child.MES_RETURN.TYPE == "S")
                    {
                        if (child.ISPACK)
                        {
                            rst.MES_PD_GD_PACKINFO[i].COUNTX = child.COUNTX;
                            rst.MES_PD_GD_PACKINFO[i].SNINFO = child.SNINFO;
                            rst.MES_PD_GD_PACKINFO[i].CXS = child.CXS;
                            rst.MES_PD_GD_PACKINFO[i].WG = child.WG;
                            rst.MES_PD_GD_PACKINFO[i].INSULATION = child.INSULATION;
                            rst.MES_PD_GD_PACKINFO[i].CODOWORD = child.CODOWORD;
                            rst.MES_PD_GD_PACKINFO[i].WORDSPACE = child.WORDSPACE;
                            rst.MES_PD_GD_PACKINFO[i].KPRQM = child.KPRQM;
                            rst.MES_PD_GD_PACKINFO[i].ISPACK = child.ISPACK;
                        }
                        rst.MES_RETURN.MESSAGE = rst.MES_RETURN.MESSAGE + " S：" + child.MES_RETURN.MESSAGE;
                    }
                    else
                    {
                        rst.MES_RETURN.TYPE = "E";
                        rst.MES_RETURN.MESSAGE = rst.MES_RETURN.MESSAGE + " E：" + child.MES_RETURN.MESSAGE;
                    }
                }
                return rst;
            }
        }

        public MES_PD_GD_PACKINFO SELECT_SINGLE(string GDDH, int STAFFID)
        {
            MES_PD_GD_PACKINFO rst = new MES_PD_GD_PACKINFO();
            rst.MES_RETURN = new MES_RETURN();
            MES_PD_GD_PACKINFO_SEARCH model_search = new MES_PD_GD_PACKINFO_SEARCH();
            model_search.GDDH = GDDH;
            MES_PD_GD_PACKINFO_SELECT rst_ERPINFO = mesdataAccess.SELECT_ERPINFO(model_search);
            if (FTY_AUZ_Verify(rst_ERPINFO.MES_PD_GD_PACKINFO[0].GC, STAFFID)) rst = mesdataAccess.SELECT_SINGLE(GDDH);
            else
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "工厂未授权！";
            }
            return rst;
        }
        public MES_RETURN COVER(MES_PD_GD_PACKINFO model, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            if (model.GDDH == null || model.GDDH == "")
            {
                if (model.ERPNO == null || 
                    model.ERPNO == "" || 
                    model.GC == null || 
                    model.GC == "")
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "工厂或生产订单号为空！";
                    return rst;
                }
                else
                {
                    MES_PD_GD_PACKINFO_SEARCH model_MES_PD_GD_PACKINFO_SEARCH = new MES_PD_GD_PACKINFO_SEARCH();
                    model_MES_PD_GD_PACKINFO_SEARCH.GC = model.GC;
                    model_MES_PD_GD_PACKINFO_SEARCH.ERPNO = model.ERPNO;
                    MES_PD_GD_PACKINFO_SELECT rst_ERPINFO = mesdataAccess.SELECT_ERPINFO(model_MES_PD_GD_PACKINFO_SEARCH);
                    if (rst_ERPINFO.MES_PD_GD_PACKINFO.Count == 0)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "未找到数据！";
                        return rst;
                    }
                    if (FTY_AUZ_Verify(rst_ERPINFO.MES_PD_GD_PACKINFO[0].GC, STAFFID))
                    {
                        model.GDDH = rst_ERPINFO.MES_PD_GD_PACKINFO[0].GDDH;
                        rst = mesdataAccess.COVER(model);
                        rst.MESSAGE = rst.MESSAGE;
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "工厂未授权！";
                        return rst;
                    }
                }
            }
            else
            {
                MES_PD_GD_PACKINFO_SEARCH model_MES_PD_GD_PACKINFO_SEARCH = new MES_PD_GD_PACKINFO_SEARCH();
                model_MES_PD_GD_PACKINFO_SEARCH.GDDH = model.GDDH;
                MES_PD_GD_PACKINFO_SELECT rst_ERPINFO = mesdataAccess.SELECT_ERPINFO(model_MES_PD_GD_PACKINFO_SEARCH);
                if (rst_ERPINFO.MES_PD_GD_PACKINFO.Count == 0)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "未找到数据！";
                    return rst;
                }
                if (FTY_AUZ_Verify(rst_ERPINFO.MES_PD_GD_PACKINFO[0].GC, STAFFID)) rst = mesdataAccess.COVER(model);
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "工厂未授权！";
                    return rst;
                }
            }
            return rst;
        }
        public MES_RETURN DELETE(string GDDH, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_PD_GD_PACKINFO_SEARCH model_search = new MES_PD_GD_PACKINFO_SEARCH();
            model_search.GDDH = GDDH;
            MES_PD_GD_PACKINFO_SELECT rst_ERPINFO = mesdataAccess.SELECT_ERPINFO(model_search);
            if (FTY_AUZ_Verify(rst_ERPINFO.MES_PD_GD_PACKINFO[0].GC, STAFFID)) rst = mesdataAccess.DELETE(GDDH);
            else
            {
                rst.TYPE = "E";
                rst.MESSAGE = "工厂未授权！";
            }
            return rst;
        }

        public Boolean FTY_AUZ_Verify(string fty, int STAFFID)
        {
            MES_SY_GC model = new MES_SY_GC();
            model.STAFFID = STAFFID;
            IList<MES_SY_GC> model_list = DA_SY_GC.SELECT_BY_ROLE(model);
            for (int i = 0; i < model_list.Count; i++)
            {
                if (model_list[i].GC == fty) return true;
            }
            return false;
        }
    }
}
