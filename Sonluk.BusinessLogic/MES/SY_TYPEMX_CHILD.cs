using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_TYPEMX_CHILD
    {
        private static readonly ISY_TYPEMX_CHILD mesdetaAccess = MESDataAccess.CreateSY_TYPEMX_CHILD();
        public MES_SY_TYPEMX_CHILD_SELECT SELECT(MES_SY_TYPEMX_CHILD model)
        {
            return mesdetaAccess.SELECT(model);
        }
        public MES_RETURN INSERT(MES_SY_TYPEMX_CHILD model)
        {
            return mesdetaAccess.INSERT(model);
        }
        public MES_RETURN UPDATE(MES_SY_TYPEMX_CHILD model)
        {
            return mesdetaAccess.UPDATE(model);
        }
        public MES_RETURN DELETE(MES_SY_TYPEMX_CHILD model)
        {
            return mesdetaAccess.DELETE(model);
        }
    }
}
