using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class PX_PXZT
    {
        private static readonly IPX_PXZT IPX_PXZTdata = HRDataAccess.CreatePX_PXZT();
        public MES_RETURN INSERT_PXZT(HR_PX_PXZT model)
        {
            return IPX_PXZTdata.INSERT_PXZT(model);
        }
        public HR_PX_PXZT_SELECT SELECT_PXZT(HR_PX_PXZT model)
        {
            return IPX_PXZTdata.SELECT_PXZT(model);
        }
        public MES_RETURN UPDATE_PXZT(HR_PX_PXZT model)
        {
            return IPX_PXZTdata.UPDATE_PXZT(model);
        }
        public MES_RETURN INSERT_PXZT_FJ(HR_PX_PXZT model)
        {
            return IPX_PXZTdata.INSERT_PXZT_FJ(model);
        }
        public HR_PX_PXZT_SELECT SELECT_PXZT_FJ(int PXZTID)
        {
            return IPX_PXZTdata.SELECT_PXZT_FJ(PXZTID);
        }
        public MES_RETURN INSERT_PXZTMX(HR_PX_PXZT model)
        {
            return IPX_PXZTdata.INSERT_PXZTMX(model);
        }
        public HR_PX_PXZT_SELECT SELECT_PXZTMX(HR_PX_PXZT model)
        {
            return IPX_PXZTdata.SELECT_PXZTMX(model);
        }
        public MES_RETURN DELETE_PXZT(int PXZTID)
        {
            return IPX_PXZTdata.DELETE_PXZT(PXZTID);
        }
        public MES_RETURN DELETE_PXZT_FJ(int FJID)
        {
            return IPX_PXZTdata.DELETE_PXZT_FJ(FJID);
        }
        public MES_RETURN DELETE_PXZTMX(int PXZTMXID)
        {
            return IPX_PXZTdata.DELETE_PXZTMX(PXZTMXID);
        }
        public HR_PX_PXZT_SELECT SELECT_PXZT_RY(HR_PX_PXZT model)
        {
            return IPX_PXZTdata.SELECT_PXZT_RY(model);
        }
        public MES_RETURN PXZT_BMRY_INSERT(HR_PX_PXZT_BMRY model)
        {
            return IPX_PXZTdata.PXZT_BMRY_INSERT(model);
        }
        public MES_RETURN PXZT_BMRY_UPDATE(HR_PX_PXZT_BMRY model)
        {
            return IPX_PXZTdata.PXZT_BMRY_UPDATE(model);
        }
        public HR_PX_PXZT_BMRY_SELECT PXZT_BMRY_SELECT(HR_PX_PXZT_BMRY model)
        {
            return IPX_PXZTdata.PXZT_BMRY_SELECT(model);
        }
    }
}
