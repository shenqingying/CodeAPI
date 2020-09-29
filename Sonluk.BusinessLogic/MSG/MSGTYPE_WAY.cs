using Sonluk.DAFactory;
using Sonluk.Entities.MSG;
using Sonluk.IDataAccess.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MSG
{
    public class MSGTYPE_WAY
    {
        private static readonly IMSGTYPE_WAY _DataAccess = RMSDataAccess.CreateMSGTYPE_WAY();


        public int Create(MSG_MSGTYPE_WAY model)
        {
            return _DataAccess.Create(model);
        }
        public IList<MSG_MSGTYPE_WAY> ReadByParam(MSG_MSGTYPE_WAY model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(MSG_MSGTYPE_WAY model)
        {
            return _DataAccess.Delete(model);
        }
        public int DeleteByTYPEID(int TYPEID)
        {
            return _DataAccess.DeleteByTYPEID(TYPEID);
        }



    }
}
