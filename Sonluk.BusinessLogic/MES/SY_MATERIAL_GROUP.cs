using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_MATERIAL_GROUP
    {
        private static readonly ISY_MATERIAL_GROUP mesdetaAccess = MESDataAccess.CreateSY_MATERIAL_GROUP();

        public MES_RETURN INSERT(MES_SY_MATERIAL_GROUP model, int ISAUTO)
        {
            return mesdetaAccess.INSERT(model, ISAUTO);
        }

        public int SELECT_COUNT(MES_SY_MATERIAL_GROUP model)
        {
            return mesdetaAccess.SELECT_COUNT(model);
        }

        public MES_SY_MATERIAL_GROUP_SELECT SELECT(MES_SY_MATERIAL_GROUP model)
        {
            return mesdetaAccess.SELECT(model);
        }

        public MES_RETURN DELETE(MES_SY_MATERIAL_GROUP model)
        {
            return mesdetaAccess.DELETE(model);
        }

        public MES_RETURN UPDATE(MES_SY_MATERIAL_GROUP model)
        {
            return mesdetaAccess.UPDATE(model);
        }
        public MES_SY_MATERIAL_GROUP_SELECT SELECT_LB(MES_SY_MATERIAL_GROUP model)
        {
            return mesdetaAccess.SELECT_LB(model);
        }
    }
}
