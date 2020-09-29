using Sonluk.DAFactory;
using Sonluk.Entities.FICO;
using Sonluk.IDataAccess.FICO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.FICO
{
  public  class FM_ElectricInvoice
    {
      private static readonly IFM_ElectricInvoice _DataAccess = RMSDataAccess.CreateFM_ElectricInvoice();

        public int Create(FICO_FM_ElectricInvoice model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(FICO_FM_ElectricInvoice model)
        {
            return _DataAccess.Update(model);
        }
        public IList<FICO_FM_ElectricInvoice> ReadByParam(FICO_FM_ElectricInvoice model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int ReadBySCAN(FICO_FM_ElectricInvoice model)
        {
            return _DataAccess.ReadBySCAN(model);
        }
        public int Delete(int ID)
        {
            return _DataAccess.Delete(ID);
        }
    }
}
