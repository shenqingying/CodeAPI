using Sonluk.DAFactory;
using Sonluk.Entities.Master;
using Sonluk.Entities.QM;
using Sonluk.IDataAccess.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.QM
{
    public class Ingredient
    {
        private static readonly IIngredient _DetaAccess = QMDataAccess.CreateIngredient();

        public IList<IngredientItemInfo> Read(string serialNumber)
        {
            return _DetaAccess.Read(serialNumber);
        }

        public IList<IngredientInfo> Read(string material, string batch, string vendorBatch)
        {
            return _DetaAccess.Read(material, batch, vendorBatch);
        }

        public IList<MaterialInfo> Material()
        {
            return _DetaAccess.Material();
        }

        public IList<JSJYBBInfo> JSJYBBREAD(string VBELN, string POSNR)
        {
            return _DetaAccess.JSJYBBREAD(VBELN, POSNR);
        }
    }
}
