using Sonluk.Entities.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.PS
{
    public interface IComponentMove
    {
        PS_ZPSFUG_Q_CGDS Component_DSXX(string NPLNR);

        string Component_ljds(ZSL_PSS_INC_CGDS i_in);

        IList<ComponentCM> ComponentCM_GET(string IV_VERIF);
        string ComponentPutAway(PS_componentputaway ps_componentputaway);
        PS_ZPSFUG_Q_CMCC ComponentInventory_CM(string I_VERIF);
        PS_ZPSFUG_Q_WLCC ComponentInventory_Network(string I_AUFNR);
        PS_ZPSFUG_Q_LJXJ ComponentSoldout_read(string I_SENUM, string I_ZROWSNUM);
        PS_MSG ComponentSoldout(ZSL_PSS_INC_LJXJ ps_i);
        PS_MSG ComponentMoving_all(ZSL_PSS_INC_LJYC i_in);
    }
}
