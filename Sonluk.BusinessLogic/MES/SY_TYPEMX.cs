using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_TYPEMX
    {
        private static readonly ISY_TYPEMX mesdetaAccess = MESDataAccess.CreateSY_TYPEMX();
        public IList<MES_SY_TYPEMXLIST> SELECT(MES_SY_TYPEMX model)
        {
            return mesdetaAccess.SELECT(model);
        }

        public MES_RETURN INSERT(MES_SY_TYPEMX model)
        {
            return mesdetaAccess.INSERT(model);
        }

        public MES_RETURN UPDATE(MES_SY_TYPEMX model)
        {
            return mesdetaAccess.UPDATE(model);
        }

        public MES_RETURN DELETE(int ID)
        {
            return mesdetaAccess.DELETE(ID);
        }

        public MES_RETURN SELECT_ZJDATE(MES_SY_TYPEMX model)
        {
            return mesdetaAccess.SELECT_ZJDATE(model);
        }

        public IList<MES_SY_TYPEMXLIST> SELECT_SBFL_BY_GZZX(string GC, string GZZXBH)
        {
            return mesdetaAccess.SELECT_SBFL_BY_GZZX(GC, GZZXBH);
        }
    }
}
