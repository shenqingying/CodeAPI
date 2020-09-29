using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FIVES
{
    public interface  ICHECK_INFO
    {
        MES_RETURN Create(FIVES_CHECK_INFO model); 
        MES_RETURN Update(FIVES_CHECK_INFO model);
        IList<FIVES_CHECK_INFOList> Read(FIVES_CHECK_INFOList model);
        IList<FIVES_CHECK_INFOList> Read_HZINFO(FIVES_CHECK_INFOList model);
        MES_RETURN Delete(int ID);


    }
}
