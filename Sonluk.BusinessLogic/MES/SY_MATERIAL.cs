using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_MATERIAL
    {
        private static readonly ISY_MATERIAL mesdetaAccess = MESDataAccess.CreateSY_MATERIAL();
        public MES_RETURN INSERT(MES_SY_MATERIAL model, int ISAUTO)
        {
            return mesdetaAccess.INSERT(model, ISAUTO);
        }
        public int SELECT_COUNT(MES_SY_MATERIAL model)
        {
            return mesdetaAccess.SELECT_COUNT(model);
        }

        public MES_RETURN DELETE(MES_SY_MATERIAL model)
        {
            return mesdetaAccess.DELETE(model);
        }

        public MES_RETURN UPDATE(MES_SY_MATERIAL model, int ISAUTO)
        {
            return mesdetaAccess.UPDATE(model, ISAUTO);
        }

        public MES_SY_MATERIAL_SELECT SELECT(MES_SY_MATERIAL model)
        {
            return mesdetaAccess.SELECT(model);
        }
        public MES_SY_MATERIAL_SELECT SELECT_BY_GZZX(MES_SY_MATERIAL model)
        {
            return mesdetaAccess.SELECT_BY_GZZX(model);
        }
        public MES_RETURN INSERT_DW(MES_SY_MATERIAL_DW model)
        {
            return mesdetaAccess.INSERT_DW(model);
        }
        public MES_SY_MATERIAL_DW_SELECT DW_SELECT(MES_SY_MATERIAL_DW model)
        {
            return mesdetaAccess.DW_SELECT(model);
        }
        public MES_RETURN DW_UPDATE(MES_SY_MATERIAL_DW model)
        {
            return mesdetaAccess.DW_UPDATE(model);
        }
        public MES_SY_MATERIAL_SELECT SELECT_LB(MES_SY_MATERIAL model)
        {
            return mesdetaAccess.SELECT_LB(model);
        }
    }
}
