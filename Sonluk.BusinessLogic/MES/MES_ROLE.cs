using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class MES_ROLE
    {
        private static readonly IMES_ROLE data_MES_ROLE = MESDataAccess.CreateIMES_ROLE();
        public MES_ROLE_GYS_SELECT SELECT_GYS(MES_ROLE_GYS model)
        {
            return data_MES_ROLE.SELECT_GYS(model);
        }
    }
}
