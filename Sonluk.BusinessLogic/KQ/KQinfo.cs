using Sonluk.DAFactory;
using Sonluk.Entities.KQ;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.KQ;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.KQ
{
    public class KQinfo
    {
        private static readonly IKQinfo _DetaAccess = KQDataAccess.CreateKQinfo();
        private static readonly ISY_RYGH data_ISY_RYGH = MESDataAccess.CreateISY_RYGH();
        public KQINFO getKQINFO(string date)
        {
            return _DetaAccess.getKQINFO(date);
        }

        public string StaffCardID(string cardno)
        {
            return _DetaAccess.StaffCardID(cardno);
        }

        public string GET_STAFFNAME_BYGH(string GH)
        {
            if (!string.IsNullOrEmpty(GH))
            {
                if (GH.Length > 0)
                {
                    char[] ch = new char[GH.Length];
                    ch = GH.ToCharArray();
                    if (ch[0] < 48 || ch[0] > 57)
                    {
                        MES_SY_RYGH model_MES_SY_RYGH = new MES_SY_RYGH();
                        model_MES_SY_RYGH.RYSCGH = GH;
                        model_MES_SY_RYGH.LB = 1;
                        MES_SY_RYGH_SELECT rst_MES_SY_RYGH_SELECT = data_ISY_RYGH.SELECT(model_MES_SY_RYGH);
                        if (rst_MES_SY_RYGH_SELECT.MES_RETURN.TYPE != "S")
                        {
                            return "";
                        }
                        if (rst_MES_SY_RYGH_SELECT.MES_SY_RYGH.Count > 0)
                        {
                            return rst_MES_SY_RYGH_SELECT.MES_SY_RYGH[0].RYNAME;
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return _DetaAccess.GET_STAFFNAME_BYGH(GH);
                    }
                }
                return _DetaAccess.GET_STAFFNAME_BYGH(GH);
            }
            else
            {
                return "";
            }
        }
        public HR_KQ_KQINFO_SELECT SELECT(HR_KQ_KQINFO model)
        {
            return _DetaAccess.SELECT(model);
        }
    }
}
