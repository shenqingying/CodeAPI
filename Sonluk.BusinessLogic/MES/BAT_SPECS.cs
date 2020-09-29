using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class BAT_SPECS
    {
        private static readonly IBAT_SPECS mesdataAccess = MESDataAccess.CreateBAT_SPECS();

        public MES_DCBZ_SELECT SELECT_SPECS_FULL(MES_DCBZ model)
        {
            MES_DCBZ_SELECT rst = new MES_DCBZ_SELECT();
            rst.MES_DCBZ = new List<MES_DCBZ>();
            rst.MES_RETURN = new MES_RETURN();
            MES_DCBZ child = new MES_DCBZ();
            child.MES_DCCCBZ = new List<MES_DCCCBZ>();
            child.MES_DCDXN = new List<MES_DCDXN>();
            MES_DCBZ_SELECT dataList = mesdataAccess.SELECT_LIST(model);
            MES_DCBZ_SELECT dataSpecs = mesdataAccess.SELECT_SPECS(model);
            MES_DCBZ_SELECT dataPerfor = mesdataAccess.SELECT_PERFOR(model);
            if (dataList.MES_RETURN.TYPE == "S" && dataSpecs.MES_RETURN.TYPE == "S" && dataPerfor.MES_RETURN.TYPE == "S")
            {
                child = dataList.MES_DCBZ[0];
                child.MES_DCCCBZ = dataSpecs.MES_DCBZ[0].MES_DCCCBZ;
                child.MES_DCDXN = dataPerfor.MES_DCBZ[0].MES_DCDXN;
                rst.MES_DCBZ.Add(child);
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = dataList.MES_RETURN.MESSAGE + dataSpecs.MES_RETURN.MESSAGE + dataPerfor.MES_RETURN.MESSAGE;
            }
            else
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = dataList.MES_RETURN.MESSAGE + dataSpecs.MES_RETURN.MESSAGE + dataPerfor.MES_RETURN.MESSAGE;
            }
            return rst;
        }
        public MES_DCBZ_SELECT SELECT_SPECS(MES_DCBZ model)
        {
            return mesdataAccess.SELECT_SPECS(model);
        }
        public MES_DCBZ_SELECT SELECT_PERFOR(MES_DCBZ model)
        {
            return mesdataAccess.SELECT_PERFOR(model);
        }
        public MES_DCBZ_SELECT SELECT_LIST(MES_DCBZ model)
        {
            return mesdataAccess.SELECT_LIST(model);
        }
        public MES_DCBZ_SELECT SELECT_LIST_LEFT(string DCXH)
        {
            return mesdataAccess.SELECT_LIST_LEFT(DCXH);
        }
        public MES_RETURN INSERT_FULL(MES_DCBZ model)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_RETURN rstSpecs = mesdataAccess.INSERT_SPECS(model);
            MES_RETURN rstPerfor = mesdataAccess.INSERT_PERFOR(model);
            if (rstSpecs.TYPE == "S" && rstPerfor.TYPE == "S")
            {
                rst.TYPE = "S";
                rst.MESSAGE = rstSpecs.MESSAGE + rstPerfor.MESSAGE;
            }
            else
            {
                rst.TYPE = "E";
                rst.MESSAGE = rstSpecs.MESSAGE + rstPerfor.MESSAGE;
            }
            return rst;
        }
        public MES_RETURN INSERT_SPECS(MES_DCBZ model)
        {
            return mesdataAccess.INSERT_SPECS(model);
        }
        public MES_RETURN INSERT_PERFOR(MES_DCBZ model)
        {
            return mesdataAccess.INSERT_PERFOR(model);
        }
        public MES_RETURN UPDATE(MES_DCBZ model)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_RETURN rstCheck = mesdataAccess.UPDATE_SPECS_CHECK(model);
            if (rstCheck.TYPE == "E") return rstCheck;
            MES_RETURN rstDelete = mesdataAccess.DELETE(model.DCXH);
            if (rstCheck.TYPE == "S") rstDelete.MESSAGE = "";
            MES_RETURN rstSpecs = mesdataAccess.INSERT_SPECS(model);
            if (rstCheck.TYPE == "S") rstSpecs.MESSAGE = "";
            MES_RETURN rstPerfor = mesdataAccess.INSERT_PERFOR(model);
            if (rstCheck.TYPE == "S") rstPerfor.MESSAGE = "";

            if (rstDelete.TYPE == "S" && rstSpecs.TYPE == "S" && rstPerfor.TYPE == "S")
            {
                rst.TYPE = "S";
                rst.MESSAGE = "更新成功";
            }
            else
            {
                rst.TYPE = "E";
                rst.MESSAGE = "更新失败，错误原因：" + rstDelete.MESSAGE + rstSpecs.MESSAGE + rstPerfor.MESSAGE;
            }
            return rst;
        }
        public MES_RETURN DELETE(string DCXH)
        {
            return mesdataAccess.DELETE_WITH_CHECK(DCXH);
        }
    }
}
