using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class BAT_SPECS_SAMP
    {
        private static readonly IBAT_SPECS_SAMP mesdataAccess = MESDataAccess.CreateBAT_SPECS_SAMP();
        private static readonly IBAT_SPECS DA_BAT_SPECS = MESDataAccess.CreateBAT_SPECS();

        public MES_DCCCCYSJ_SELECT SELECT(MES_DCCCCYSJ model)
        {
            return mesdataAccess.SELECT(model);
        }
        public MES_RETURN INSERT(MES_DCCCCYSJ model)
        {
            return mesdataAccess.INSERT(model);
        }
        public MES_RETURN UPDATE(MES_DCCCCYSJ model)
        {
            return mesdataAccess.UPDATE(model);
        }
        public MES_RETURN DELETE(int RI)
        {
            return mesdataAccess.DELETE(RI);
        }
    }
}
