﻿using Sonluk.DAFactory;
using Sonluk.Entities.MSG;
using Sonluk.IDataAccess.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MSG
{
    public class MSG_TYPE
    {
        private static readonly IMSG_TYPE _DataAccess = RMSDataAccess.CreateMSG_TYPE();


        public int Create(MSG_MSG_TYPE model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(MSG_MSG_TYPE model)
        {
            return _DataAccess.Update(model);
        }
        public IList<MSG_MSG_TYPE> ReadByParam(MSG_MSG_TYPE model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int MSGTYPEID)
        {
            return _DataAccess.Delete(MSGTYPEID);
        }




    }
}
