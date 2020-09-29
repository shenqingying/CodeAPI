using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IReceiver
    {
        IList<CompanyInfo> Read();

        IList<CompanyInfo> Read(int city);

        CompanyInfo Read(string serialNumber);

        CompanyInfo Read(string serialNumber, int city);

        IList<CompanyInfo> Select(string keyword);

        int Create(CompanyInfo node);

        int Update(CompanyInfo node);

        int Delete(int ID);
    }
}
