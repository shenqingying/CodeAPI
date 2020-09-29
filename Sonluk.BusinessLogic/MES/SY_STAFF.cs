using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_STAFF
    {
        private static readonly ISY_STAFF SY_STAFFdata = MESDataAccess.CreateSY_STAFF();
        private static readonly ISY_SYSCS ISY_SYSCSdata = MESDataAccess.CreateISY_SYSCS();
        public MES_SY_STAFF_SELECT SELECT(MES_SY_STAFF model)
        {
            MES_SY_STAFF_SELECT rst = new MES_SY_STAFF_SELECT();
            rst = SY_STAFFdata.SELECT(model);
            if (rst.MES_RETURN.TYPE == "S")
            {
                if (rst.MES_SY_STAFF.Count > 0)
                {
                    string PWUPDATECOUNT = ISY_SYSCSdata.SELECT("PWUPDATECOUNT");
                    if (PWUPDATECOUNT == "0" || PWUPDATECOUNT == "")
                    {
                        PWUPDATECOUNT = "56";
                    }
                    for (int a = 0; a < rst.MES_SY_STAFF.Count; a++)
                    {
                        if (rst.MES_SY_STAFF[a].UPDATEPWDATE != "")
                        {
                            DateTime dtime1 = DateTime.Now;
                            DateTime dtime2 = Convert.ToDateTime(rst.MES_SY_STAFF[a].UPDATEPWDATE);
                            dtime2 = dtime2.AddDays(Convert.ToInt32(PWUPDATECOUNT));
                            TimeSpan dtspan = dtime1 - dtime2;
                            if (dtspan.TotalSeconds > 0)
                            {
                                rst.MES_SY_STAFF[a].ISCQ = 1;
                            }
                            else
                            {
                                rst.MES_SY_STAFF[a].ISCQ = 0;
                            }
                        }
                    }
                }
            }
            return rst;
        }
        public MES_RETURN UPDATE_STAFFPW(int STAFFID, string OLDPW, string NEWPW)
        {
            return SY_STAFFdata.UPDATE_STAFFPW(STAFFID, OLDPW, NEWPW);
        }
    }
}
