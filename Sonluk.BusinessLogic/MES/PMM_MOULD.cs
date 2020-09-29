using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class PMM_MOULD
    {
        private static readonly IPMM_MOULD mesdataAccess = MESDataAccess.CreatePMM_MOULD();
        private static readonly SY_GZZX BL_SY_GZZX = new SY_GZZX();

        public MES_PMM_MOULD_SELECT SELECT(MES_PMM_MOULD model, int STAFFID)
        {
            MES_SY_GZZX search_MES_SY_GZZX = new MES_SY_GZZX();
            search_MES_SY_GZZX.GC = model.GC;
            search_MES_SY_GZZX.STAFFID = STAFFID;
            List<MES_SY_GZZX> rst_SY_GZZX = BL_SY_GZZX.SELECT_BY_ROLE(search_MES_SY_GZZX).ToList();
            MES_PMM_MOULD_SELECT rst = mesdataAccess.SELECT(model, STAFFID);
            if (rst.MES_PMM_MOULD != null && rst.MES_RETURN != null && rst.MES_RETURN.TYPE == "S")
            {
                for (int i = 0; i < rst.MES_PMM_MOULD.Count; i++)
                {
                    bool delete = true;
                    for (int j = 0; j < rst_SY_GZZX.Count; j++)
                    {
                        if (rst.MES_PMM_MOULD[i].GZZXBH == rst_SY_GZZX[j].GZZXBH)
                        {
                            delete = false;
                            break;
                        }
                    }
                    if (delete) rst.MES_PMM_MOULD.Remove(rst.MES_PMM_MOULD[i]);
                }
            }
            return rst;
        }

        public MES_PMM_MOULD_SELECT SELECT_ALL(MES_PMM_MOULD model, int STAFFID)
        {
            return mesdataAccess.SELECT(model, STAFFID);
        }

        public MES_RETURN INSERT(MES_PMM_MOULD model, int STAFFID)
        {
            return mesdataAccess.INSERT(model, STAFFID);
        }

        public MES_RETURN UPDATE(MES_PMM_MOULD model, int STAFFID)
        {
            return mesdataAccess.UPDATE(model, STAFFID);
        }

        public MES_RETURN DELETE(string MID, int STAFFID)
        {
            return mesdataAccess.DELETE(MID, STAFFID);
        }
    }
}
