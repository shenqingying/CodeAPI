using Sonluk.DAFactory;
using Sonluk.Entities.API;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class PMM_STAFF
    {
        private static readonly IPMM_STAFF mesdataAccess = MESDataAccess.CreatePMM_STAFF();

        public MES_PMM_STAFF_SELECT SELECT(MES_PMM_STAFF model)
        {
            return mesdataAccess.SELECT(model);
        }
        public MES_RETURN COVER(MES_PMM_STAFF model)
        {
            return mesdataAccess.COVER(model);
        }
        public MES_RETURN DELETE(MES_PMM_STAFF model)
        {
            return mesdataAccess.DELETE(model);
        }

        #region

        public ApiReturn Read(MES_PMM_STAFF model)
        {
            return mesdataAccess.Read(model);
        }
        public ApiReturn Update(MES_PMM_STAFF model)
        {
            return mesdataAccess.Update(model);
        }
        public ApiReturn Delete(MES_PMM_STAFF model)
        {
            return mesdataAccess.Delete(model);
        }

        #endregion
    }
}
