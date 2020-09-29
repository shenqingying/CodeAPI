using Sonluk.Entities.FICO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FICO
{
  public  interface IFM_ElectricInvoice
    {
      int Create(FICO_FM_ElectricInvoice model);
      int Update(FICO_FM_ElectricInvoice model);
      IList<FICO_FM_ElectricInvoice> ReadByParam(FICO_FM_ElectricInvoice model);
      int ReadBySCAN(FICO_FM_ElectricInvoice model);
      int Delete(int CID);
    }
}
