﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_MATERIAL_GROUP_SELECT
    {
        private List<MES_SY_MATERIAL_GROUP> _MES_SY_MATERIAL_GROUP;

        public List<MES_SY_MATERIAL_GROUP> MES_SY_MATERIAL_GROUP
        {
            get { return _MES_SY_MATERIAL_GROUP; }
            set { _MES_SY_MATERIAL_GROUP = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}