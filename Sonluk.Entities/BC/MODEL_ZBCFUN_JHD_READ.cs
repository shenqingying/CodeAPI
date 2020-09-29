using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class MODEL_ZBCFUN_JHD_READ
    {
        ZSL_BCS013 _ES_HeadData;

        public ZSL_BCS013 ES_HeadData
        {
            get { return _ES_HeadData; }
            set { _ES_HeadData = value; }
        }
        List<ZSL_BCST014> _ET_ItemData;

        public List<ZSL_BCST014> ET_ItemData
        {
            get { return _ET_ItemData; }
            set { _ET_ItemData = value; }
        }




        MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }





    }
}
