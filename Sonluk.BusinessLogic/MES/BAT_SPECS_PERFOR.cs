using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class BAT_SPECS_PERFOR
    {
        private static readonly IBAT_SPECS_PERFOR mesdataAccess = MESDataAccess.CreateBAT_SPECS_PERFOR();

        public MES_RETURN COVER_LIST(MES_DCDXNSZ_SELECT model)
        {
            MES_RETURN rst = new MES_RETURN();
            int updateNum = 0;
            int insertNum = 0;
            for (int i = 0; i < model.MES_DCDXNSZ.Count; i++)
            {
                rst = COVER(model.MES_DCDXNSZ[i]);
                if (rst.TYPE == "S")
                {
                    if (rst.MESSAGE.Contains("新增")) insertNum++;
                    else if (rst.MESSAGE.Contains("更新")) updateNum++;
                }
                if (rst.TYPE == "E")
                {
                    rst.MESSAGE = "已导入 " + (insertNum + updateNum) + " / " + model.MES_DCDXNSZ.Count + " 条数据，其中新增" + insertNum + "条，更新" + updateNum + "条，但是，第" + (i + 1) + "条数据导入失败（该条及之后的数据均已中止导入），错误信息：" + rst.MESSAGE;
                    return rst;
                }
            }
            rst.MESSAGE = "共导入 " + (insertNum + updateNum) + " / " + model.MES_DCDXNSZ.Count + " 条数据，其中新增" + insertNum + "条，更新" + updateNum + "条！";
            return rst;
        }

        public MES_RETURN MCOVER_LIST(MES_DCDXNSZ_SELECT model)
        {
            return mesdataAccess.MCOVER(model.MES_DCDXNSZ);
        }

        public MES_RETURN COVER(MES_DCDXNSZ model)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_DCDXNSZ_SEARCH search_MES_DCDXNSZ_SEARCH = new MES_DCDXNSZ_SEARCH();
            search_MES_DCDXNSZ_SEARCH.DATES = model.RQ;
            search_MES_DCDXNSZ_SEARCH.DCXH = model.DCXH;
            search_MES_DCDXNSZ_SEARCH.SDDJ = model.SDDJ;
            search_MES_DCDXNSZ_SEARCH.SCX = model.SCX;
            MES_DCDXNSZ_SELECT rst_MES_DCDXNSZ_SEARCH = SELECT(search_MES_DCDXNSZ_SEARCH);
            if (rst_MES_DCDXNSZ_SEARCH.MES_DCDXNSZ.Count > 0)
            {
                if (rst_MES_DCDXNSZ_SEARCH.MES_DCDXNSZ[0].RI == model.RI)
                {
                    rst = UPDATE(model);
                    if (rst.TYPE == "S") rst.MESSAGE = "已更新数值！";
                }
                else if (model.RI <= 0)
                {
                    model.RI = rst_MES_DCDXNSZ_SEARCH.MES_DCDXNSZ[0].RI;
                    rst = UPDATE(model);
                    if (rst.TYPE == "S") rst.MESSAGE = "存在相同内容，已覆盖更新！";
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "存在相同内容，无法修改！";
                }
            }
            else
            {
                if (model.RI <= 0)
                {
                    rst = INSERT(model);
                    if (rst.TYPE == "S") rst.MESSAGE = "已新增！";
                }
                else
                {
                    rst = DELETE(model.RI);
                    rst = INSERT(model);
                    if (rst.TYPE == "S") rst.MESSAGE = "已更新！";
                }
            }
            return rst;
        }

        public MES_DCDXNSZ_SELECT SELECT(MES_DCDXNSZ_SEARCH model)
        {
            return mesdataAccess.SELECT(model);
        }
        public MES_RETURN INSERT(MES_DCDXNSZ model)
        {
            return mesdataAccess.INSERT(model);
        }
        public MES_RETURN UPDATE(MES_DCDXNSZ model)
        {
            return mesdataAccess.UPDATE(model);
        }
        public MES_RETURN DELETE(int RI)
        {
            return mesdataAccess.DELETE(RI);
        }
    }
}
