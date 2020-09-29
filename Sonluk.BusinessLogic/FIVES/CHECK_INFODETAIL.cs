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
    public class CHECK_INFODETAIL
    {
        private static readonly ICHECK_INFODETAIL _DataAccess = RMSDataAccess.CreateCHECK_INFODETAIL();

        public MES_RETURN Create(List<FIVES_CHECK_INFODETAIL> model) 
        {
            return _DataAccess.Create(model); 
        }
        public MES_RETURN Update(FIVES_CHECK_INFODETAIL model) 
        { 
            return _DataAccess.Update(model);
        }
        public IList<FIVES_CHECK_INFODETAILList> Read(FIVES_CHECK_INFODETAIL model) 
        { 
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(int ID) 
        { 
            return _DataAccess.Delete(ID);
        }

    }
}
