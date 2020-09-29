using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ZS_SY_CLPB
    {
        private static readonly IZS_SY_CLPB data_IZS_SY_CLPB = MESDataAccess.CreateIZS_SY_CLPB();
        public MES_RETURN INSERT(MES_ZS_SY_CLPB model)
        {
            return data_IZS_SY_CLPB.INSERT(model);
        }
        public MES_RETURN UPDATE(MES_ZS_SY_CLPB model)
        {
            return data_IZS_SY_CLPB.UPDATE(model);
        }
        public MES_ZS_SY_CLPB_SELECT SELECT(MES_ZS_SY_CLPB model)
        {
            return data_IZS_SY_CLPB.SELECT(model);
        }
        public MES_RETURN INSERT_WL(MES_ZS_SY_CLPB_WL model)
        {
            return data_IZS_SY_CLPB.INSERT_WL(model);
        }
        public MES_RETURN UPDATE_WL(MES_ZS_SY_CLPB_WL model)
        {
            return data_IZS_SY_CLPB.UPDATE_WL(model);
        }
        public MES_ZS_SY_CLPB_WL_SELECT SELECT_WL(MES_ZS_SY_CLPB_WL model)
        {
            return data_IZS_SY_CLPB.SELECT_WL(model);
        }
    }
}
