using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class PMM_MTC
    {
        private static readonly IPMM_MTC DA_PMM_MTC = MESDataAccess.CreatePMM_MTC();
        private static readonly IPMM_MTC_CAVE DA_PMM_MTC_CAVE = MESDataAccess.CreatePMM_MTC_CAVE();
        private static readonly IPMM_MTC_REP DA_PMM_MTC_REP = MESDataAccess.CreatePMM_MTC_REP();
        private static readonly IPMM_MOULD DA_PMM_MOULD = MESDataAccess.CreatePMM_MOULD();

        public MES_PMM_MTC_SELECT SELECT(MES_PMM_MTC model)
        {
            if (model.MES_PMM_MOULD == null) model.MES_PMM_MOULD = new MES_PMM_MOULD();
            MES_PMM_MTC_SELECT rst = DA_PMM_MTC.SELECT(model);
            if (rst.MES_RETURN.TYPE != "S") return rst;
            for (int i = 0; i < rst.MES_PMM_MTC.Count; i++)
            {
                //初始化
                rst.MES_PMM_MTC[i].MES_PMM_MTC_CAVE = new List<MES_PMM_MTC_CAVE>();
                rst.MES_PMM_MTC[i].MES_PMM_MTC_REP = new List<MES_PMM_MTC_REP>();

                //获取腔号信息
                MES_PMM_MTC_CAVE search_CAVE = new MES_PMM_MTC_CAVE();
                MES_PMM_MTC_CAVE_SELECT rst_CAVE = new MES_PMM_MTC_CAVE_SELECT();
                search_CAVE.MTCID = rst.MES_PMM_MTC[i].MTCID;
                rst_CAVE = DA_PMM_MTC_CAVE.SELECT(search_CAVE);
                if (rst_CAVE.MES_RETURN.TYPE == "S") rst.MES_PMM_MTC[i].MES_PMM_MTC_CAVE = rst_CAVE.MES_PMM_MTC_CAVE;
                else
                {
                    rst.MES_RETURN = rst_CAVE.MES_RETURN;
                    return rst;
                }

                //获取维修内容信息
                MES_PMM_MTC_REP search_REP = new MES_PMM_MTC_REP();
                MES_PMM_MTC_REP_SELECT rst_REP = new MES_PMM_MTC_REP_SELECT();
                search_REP.MTCID = rst.MES_PMM_MTC[i].MTCID;
                rst_REP = DA_PMM_MTC_REP.SELECT(search_REP);
                if (rst_CAVE.MES_RETURN.TYPE == "S") rst.MES_PMM_MTC[i].MES_PMM_MTC_REP = rst_REP.MES_PMM_MTC_REP;
                else
                {
                    rst.MES_RETURN = rst_CAVE.MES_RETURN;
                    return rst;
                }
            }
            return rst;
        }

        public MES_RETURN INSERT(MES_PMM_MTC model)
        {
            //新建维修记录
            MES_RETURN rst = DA_PMM_MTC.INSERT(model);
            if (rst.TYPE != "S")
            {
                rst.MESSAGE = "未能新建维修记录，原因：" + rst.MESSAGE;
                return rst;
            }
            else
            {
                model.MTCID = rst.TID;
            }
            //新建腔号记录
            if (model.MES_PMM_MTC_CAVE != null)
            {
                for (int i = 0; i < model.MES_PMM_MTC_CAVE.Count; i++)
                {
                    model.MES_PMM_MTC_CAVE[i].MTCID = model.MTCID;
                    MES_RETURN child = DA_PMM_MTC_CAVE.INSERT(model.MES_PMM_MTC_CAVE[i]);
                    if (child.TYPE != "S")
                    {
                        rst.TYPE = child.TYPE;
                        rst.MESSAGE = "已新建维修记录，但是未能写入腔号，原因：" + child.MESSAGE;
                        return rst;
                    }
                }
            }
            //新建维修内容
            if (model.MES_PMM_MTC_REP != null)
            {
                for (int i = 0; i < model.MES_PMM_MTC_REP.Count; i++)
                {
                    model.MES_PMM_MTC_REP[i].MTCID = model.MTCID;
                    MES_RETURN child = DA_PMM_MTC_REP.INSERT(model.MES_PMM_MTC_REP[i]);
                    if (child.TYPE != "S")
                    {
                        rst.TYPE = child.TYPE;
                        rst.MESSAGE = "已新建维修记录，但是未能写入维修内容，原因：" + child.MESSAGE;
                        return rst;
                    }
                }
            }
            return rst;
        }

        public MES_RETURN UPDATE_SAVE(MES_PMM_MTC model)
        {
            //更新维修记录
            model.OPERATE = "SAVE";
            MES_RETURN rst = DA_PMM_MTC.UPDATE(model);
            if (rst.TYPE != "S")
            {
                rst.MESSAGE = "未能更新维修记录，原因：" + rst.MESSAGE;
                return rst;
            }
            //更新腔号记录
            if (model.MES_PMM_MTC_CAVE != null)
            {
                MES_RETURN rst_CAVE_IN_UPDATE_SAVE = DA_PMM_MTC_CAVE.DELETE(model.MTCID);
                if (rst_CAVE_IN_UPDATE_SAVE.TYPE != "S")
                {
                    rst.TYPE = rst_CAVE_IN_UPDATE_SAVE.TYPE;
                    rst.MESSAGE = "已更新维修记录，但未能去除旧腔号，原因：" + rst_CAVE_IN_UPDATE_SAVE.MESSAGE;
                    return rst;
                }
                for (int i = 0; i < model.MES_PMM_MTC_CAVE.Count; i++)
                {
                    model.MES_PMM_MTC_CAVE[i].MTCID = model.MTCID;
                    MES_RETURN child = DA_PMM_MTC_CAVE.INSERT(model.MES_PMM_MTC_CAVE[i]);
                    if (child.TYPE != "S")
                    {
                        rst.TYPE = child.TYPE;
                        rst.MESSAGE = "已更新维修记录，但是未能更新腔号，原因：" + child.MESSAGE;
                        return rst;
                    }
                }
            }
            //更新维修内容
            if (model.MES_PMM_MTC_REP != null)
            {
                MES_RETURN rst_REP_IN_UPDATE_SAVE = DA_PMM_MTC_REP.DELETE(model.MTCID);
                if (rst_REP_IN_UPDATE_SAVE.TYPE != "S")
                {
                    rst.TYPE = rst_REP_IN_UPDATE_SAVE.TYPE;
                    rst.MESSAGE = "已更新维修记录，但未能去除维修内容，原因：" + rst_REP_IN_UPDATE_SAVE.MESSAGE;
                    return rst;
                }
                for (int i = 0; i < model.MES_PMM_MTC_REP.Count; i++)
                {
                    model.MES_PMM_MTC_REP[i].MTCID = model.MTCID;
                    MES_RETURN child = DA_PMM_MTC_REP.INSERT(model.MES_PMM_MTC_REP[i]);
                    if (child.TYPE != "S")
                    {
                        rst.TYPE = child.TYPE;
                        rst.MESSAGE = "已新更新修记录，但是未能更新维修内容，原因：" + child.MESSAGE;
                        return rst;
                    }
                }
            }
            return rst;
        }

        public MES_RETURN UPDATE_START(MES_PMM_MTC model)
        {
            model.OPERATE = "START";
            return DA_PMM_MTC.UPDATE(model);
        }

        public MES_RETURN UPDATE_BACK(MES_PMM_MTC model)
        {
            model.OPERATE = "BACK";
            return DA_PMM_MTC.UPDATE(model);
        }

        public MES_RETURN UPDATE_MM(MES_PMM_MTC model)
        {
            model.OPERATE = "MM";
            return DA_PMM_MTC.UPDATE(model);
        }

        public MES_RETURN UPDATE_WT(MES_PMM_MTC model)
        {
            model.OPERATE = "WT";
            return DA_PMM_MTC.UPDATE(model);
        }

        public MES_RETURN UPDATE_QC(MES_PMM_MTC model)
        {
            model.OPERATE = "QC";
            return DA_PMM_MTC.UPDATE(model);
        }

        public MES_RETURN UPDATE_TEC(MES_PMM_MTC model)
        {
            model.OPERATE = "TEC";
            return DA_PMM_MTC.UPDATE(model);
        }

        public MES_RETURN UPDATE_CFMBACK(MES_PMM_MTC model)
        {
            return DA_PMM_MTC.UPDATE_CFMBACK(model);
        }

        public MES_RETURN DELETE(MES_PMM_MTC model)
        {
            return DA_PMM_MTC.DELETE(model);
        }
    }
}
