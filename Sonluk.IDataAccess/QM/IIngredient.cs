using Sonluk.Entities.Master;
using Sonluk.Entities.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.QM
{
    public interface IIngredient
    {
        IList<IngredientItemInfo> Read(string serialNumber);

        IList<IngredientInfo> Read(string material, string batch, string VendorBatch);

        IList<MaterialInfo> Material();

        IList<JSJYBBInfo> JSJYBBREAD(string VBELN, string POSNR);
    }
}
