using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.Entities.PS;
using Sonluk.Entities.SAP;
using Sonluk.IDataAccess.MES;
using Sonluk.IDataAccess.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.PS
{
    public class ZPSFUG
    {
        private static readonly IZPSFUG data_IZPSFUG = SAPDataAccess.CreateIZPSFUG();
        private static readonly ISY_EXCEPTION data_ISY_EXCEPTION = MESDataAccess.CreateISY_EXCEPTION();
        public List<ZSL_XMXX> ZPSFUG_Q_XMXXOA(string POSID, string PSPID)
        {
            List<ZSL_XMXX> rst_list = new List<ZSL_XMXX>();
            ZPSFUG_Q_XMXXOA_SELECT rst = new ZPSFUG_Q_XMXXOA_SELECT();
            try
            {
                rst = data_IZPSFUG.ZPSFUG_Q_XMXXOA(POSID, PSPID);
            }
            catch (Exception e)
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                ZSL_XMXX child_ZSL_XMXX = new ZSL_XMXX();
                rst.MES_RETURN = child_MES_RETURN;
                rst.CT_XM = child_ZSL_XMXX;
                data_ISY_EXCEPTION.INSERT_ALL(e.ToString(), "SAP.PS", POSID + "/" + PSPID, "PS.ZPSFUG");
            }
            rst_list.Add(rst.CT_XM);
            return rst_list;
        }
    }
}
