using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class BC_CHTT_FAKE
    {
        private static readonly IBC_CHTT_FAKE _DataAccess_CHTT_FAKE = RMSDataAccess.CreateIBC_CHTT_FAKE();

        public int TTCreate(CRM_BC_CHTT model)
        {
            return _DataAccess_CHTT_FAKE.TTCreate(model);
        }

        public int MXCreate(CRM_BC_CHMX model)
        {
            return _DataAccess_CHTT_FAKE.MXCreate(model);
        }
        public int TTMXDelete()
        {
            return _DataAccess_CHTT_FAKE.TTMXDelete();
        }


    }
}
