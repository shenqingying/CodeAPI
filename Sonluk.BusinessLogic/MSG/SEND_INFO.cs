using Sonluk.DAFactory;
using Sonluk.Entities.MSG;
using Sonluk.IDataAccess.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MSG
{
    public class SEND_INFO
    {
        private static readonly ISEND_INFO _DataAccess = RMSDataAccess.CreateSEND_INFO();


        public int Create(MSG_SEND_INFO model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(MSG_SEND_INFO model)
        {
            return _DataAccess.Update(model);
        }
        public IList<MSG_SEND_INFO> ReadByParam(MSG_SEND_INFO model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int INFOID)
        {
            return _DataAccess.Delete(INFOID);
        }




    }
}
