using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface ICity
    {

        IList<CityInfo> ReadByExcelCity();
        IList<CityInfo> Read(bool available);

        CityInfo Read(int ID);

        CityInfo Read(string name);

        int Create(CityInfo node);

        int Update(CityInfo node);

        int Delete(int ID);

        int DeleteProvince(int ID);
    }
}
