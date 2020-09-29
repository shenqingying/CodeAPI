using Sonluk.DAFactory;
using Sonluk.Entities.PS;
using Sonluk.IDataAccess.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.PS
{
    public class ComponentMove
    {
        private static readonly IComponentMove detaAccess = PSDataAccess.CreateComponentMove();

        public PS_ZPSFUG_Q_CGDS Component_DSXX(string NPLNR)
        {
            return detaAccess.Component_DSXX(NPLNR);
        }

        public string Component_ljds(ZSL_PSS_INC_CGDS i_in)
        {
            return detaAccess.Component_ljds(i_in);
        }

        public IList<ComponentCM> ComponentCM_GET(string IV_VERIF)
        {
            return detaAccess.ComponentCM_GET(IV_VERIF);
        }

        public string ComponentPutAway(PS_componentputaway ps_componentputaway)
        {
            return detaAccess.ComponentPutAway(ps_componentputaway);
        }

        public PS_ZPSFUG_Q_CMCC ComponentInventory_CM(string I_VERIF)
        {
            return detaAccess.ComponentInventory_CM(I_VERIF);
        }

        public PS_ZPSFUG_Q_WLCC ComponentInventory_Network(string I_AUFNR)
        {
            return detaAccess.ComponentInventory_Network(I_AUFNR);
        }

        public PS_ZPSFUG_Q_LJXJ ComponentSoldout_read(string I_SENUM, string I_ZROWSNUM)
        {
            return detaAccess.ComponentSoldout_read(I_SENUM, I_ZROWSNUM);
        }

        public PS_MSG ComponentSoldout(ZSL_PSS_INC_LJXJ ps_i)
        {
            return detaAccess.ComponentSoldout(ps_i);
        }

        public PS_MSG ComponentMoving_all(ZSL_PSS_INC_LJYC i_in)
        {
            return detaAccess.ComponentMoving_all(i_in);
        }
    }
}
