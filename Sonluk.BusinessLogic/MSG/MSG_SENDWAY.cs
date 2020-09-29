using Sonluk.DAFactory;
using Sonluk.Entities.MSG;
using Sonluk.IDataAccess.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MSG
{
    public class MSG_SENDWAY
    {
        private static readonly IMSG_SENDWAY _DataAccess = RMSDataAccess.CreateMSG_SENDWAY();


        public int Create(MSG_MSG_SENDWAY model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(MSG_MSG_SENDWAY model)
        {
            return _DataAccess.Update(model);
        }
        public IList<MSG_MSG_SENDWAY> ReadByParam(MSG_MSG_SENDWAY model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int SENDWAYID, int XGR)
        {
            return _DataAccess.Delete(SENDWAYID, XGR);
        }





    }
}
