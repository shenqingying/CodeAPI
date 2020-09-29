using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_PLDH
    {
        private static readonly ISY_PLDH mesdetaAccess = MESDataAccess.CreateSY_PLDH();
        private static readonly ISY_YERACOUNT ISY_YERACOUNTdata = MESDataAccess.CreateSY_YERACOUNT();
        private static readonly ISY_TYPEMX data_ISY_TYPEMX = MESDataAccess.CreateSY_TYPEMX();
        public MES_RETURN INSERT(MES_SY_PLDH model)
        {
            MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
            model_MES_SY_TYPEMX.ID = model.PFLB;
            List<MES_SY_TYPEMXLIST> model_MES_SY_TYPEMXLIST_list = data_ISY_TYPEMX.SELECT(model_MES_SY_TYPEMX).ToList();
            if (model_MES_SY_TYPEMXLIST_list.Count > 0)
            {
                MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                if (model_MES_SY_TYPEMXLIST_list[0].MXREMARK == "1")
                {
                    model_MES_SY_YERACOUNT.TMLB = 4;
                }
                else
                {
                    model_MES_SY_YERACOUNT.TMLB = 6;
                }
                model_MES_SY_YERACOUNT.GC = model.GC;
                model.PLDH = ISY_YERACOUNTdata.SELECT(model_MES_SY_YERACOUNT);
                MES_RETURN mr = mesdetaAccess.INSERT(model);
                mr.GC = model.GC;
                mr.BH = model.PLDH;
                return mr;
            }
            else
            {
                MES_RETURN mr = new MES_RETURN();
                mr.TYPE = "E";
                mr.MESSAGE = "类别错误！";
                return mr;
            }
        }

        public MES_RETURN SELECT_COUNT(MES_SY_PLDH model)
        {
            return mesdetaAccess.SELECT_COUNT(model);
        }
        public MES_SY_PLDH_SELECT SELECT_LIST(MES_SY_PLDH model)
        {
            return mesdetaAccess.SELECT_LIST(model);
        }
        public MES_SY_PLDH_SELECT SELECT(MES_SY_PLDH model)
        {
            return mesdetaAccess.SELECT(model);
        }
        public MES_RETURN PLDH_SBBH_INSERT(MES_SY_PLDH_SBBH model)
        {
            return mesdetaAccess.PLDH_SBBH_INSERT(model);
        }
        public MES_RETURN PLDH_SBBH_UPDATE(MES_SY_PLDH_SBBH model)
        {
            return mesdetaAccess.PLDH_SBBH_UPDATE(model);
        }
        public MES_SY_PLDH_SBBH_SELECT PLDH_SBBH_SELECT(MES_SY_PLDH_SBBH model)
        {
            return mesdetaAccess.PLDH_SBBH_SELECT(model);
        }
        public MES_RETURN UPDATE(MES_SY_PLDH model)
        {
            return mesdetaAccess.UPDATE(model);
        }
    }
}
