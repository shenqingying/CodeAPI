using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.DAFactory;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.FIVES;


namespace Sonluk.BusinessLogic.FIVES
{
    public class SY_CHECKPOINTCATEGROY
    {
        private static readonly ISY_CHECKPOINTCATEGROY _DataAccess = RMSDataAccess.CreateSY_CHECKPOINTCATEGROY();

        public MES_RETURN Create(FIVES_SY_CHECKPOINTCATEGROY model) 
        { 
            return _DataAccess.Create(model); 
        } 
        public MES_RETURN Update(FIVES_SY_CHECKPOINTCATEGROY model) 
        { 
            return _DataAccess.Update(model); 
        }
        public IList<FIVES_SY_CHECKPOINTCATEGROY> Read(FIVES_SY_CHECKPOINTCATEGROY model) 
        { 
            return _DataAccess.Read(model); 
        }
        public MES_RETURN Delete(int ID) 
        { 
            return _DataAccess.Delete(ID);
        }	

    }
}
