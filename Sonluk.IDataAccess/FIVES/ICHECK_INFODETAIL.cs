using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FIVES
{
    public interface ICHECK_INFODETAIL
    {
        MES_RETURN Create(List<FIVES_CHECK_INFODETAIL> model); 
        MES_RETURN Update(FIVES_CHECK_INFODETAIL model);
        IList<FIVES_CHECK_INFODETAILList> Read(FIVES_CHECK_INFODETAIL model);
        MES_RETURN Delete(int ID);
        IList<FIVES_CHECK_INFODETAILList> ReadLastCheck(int pointid);
        

    }
}
