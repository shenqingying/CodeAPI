using Sonluk.Entities.BARCODE;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.BARCODE
{
  public  interface ISY_CODING
    {
        MES_RETURN Create(BARCODE_SY_CODING model);
        MES_RETURN CreateByImport(List<BARCODE_SY_CODING> model);
        MES_RETURN Update(BARCODE_SY_CODING model);
        IList<BARCODE_SY_CODING> ReadByParam(BARCODE_SY_CODING model);
        MES_RETURN Delete(int ID);
    }
}
