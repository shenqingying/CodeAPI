﻿using Sonluk.DAFactory;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.EM
{
    public class SY_DEVICEDETAILDOC
    {
        private static readonly ISY_DEVICEDETAILDOC _DataAccess = RMSDataAccess.CreateEMSY_DEVICEDETAILDOC();

        public MES_RETURN Create(EM_SY_DEVICEDETAILDOC model)
        {
            return _DataAccess.Create(model);
        }
        public MES_RETURN Update(EM_SY_DEVICEDETAILDOC model)
        {
            return _DataAccess.Update(model);
        }
        public IList<EM_SY_DEVICEDETAILDOC> Read(EM_SY_DEVICEDETAILDOC model)
        {
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(int ID)
        {
            return _DataAccess.Delete(ID);
        }
    }
}
