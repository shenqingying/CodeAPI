using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_MATERIAL_BZCOUNT
    {
        private static readonly ISY_MATERIAL_BZCOUNT mesdetaAccess = MESDataAccess.CreateSY_MATERIAL_BZCOUNT();
        public MES_RETURN INSERT(MES_SY_MATERIAL_BZCOUNT model)
        {
            return mesdetaAccess.INSERT(model);
        }
        public MES_RETURN DELETE(MES_SY_MATERIAL_BZCOUNT model)
        {
            return mesdetaAccess.DELETE(model);
        }
        public MES_RETURN UPDATE(MES_SY_MATERIAL_BZCOUNT model)
        {
            return mesdetaAccess.UPDATE(model);
        }
        public MES_SY_MATERIAL_BZCOUNT_SELECT SELECT(MES_SY_MATERIAL_BZCOUNT model)
        {
            return mesdetaAccess.SELECT(model);
        }
        public MES_SY_MATERIAL_BZCOUNT_SELECT SELECT_LB(MES_SY_MATERIAL_BZCOUNT model)
        {
            return mesdetaAccess.SELECT_LB(model);
        }
    }
}
