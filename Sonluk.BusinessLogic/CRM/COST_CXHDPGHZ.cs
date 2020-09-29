using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CXHDPGHZ
    {
        private static readonly ICOST_CXHDPGHZ _DataAccess = RMSDataAccess.CreateCOST_CXHDPGHZ();


        public int Create(CRM_COST_CXHDPGHZ model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CXHDPGHZ model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CXHDPGHZ> ReadByParam(CRM_COST_CXHDPGHZ model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int PGHZID)
        {
            return _DataAccess.Delete(PGHZID);
        }
        public int DeleteByCXHDID(int CXHDID)
        {
            return _DataAccess.DeleteByCXHDID(CXHDID);
        }
        public IList<CRM_COST_CXHDPGHZ> GetReport(CRM_COST_CXHDPGHZ model)
        {
            return _DataAccess.GetReport(model);
        }

        public int AutoUpdate(int CXHDID)
        {
            CRM_COST_CXHDPGHZ cxmodel = new CRM_COST_CXHDPGHZ();
            cxmodel.CXHDID = CXHDID;
            IList<CRM_COST_CXHDPGHZ> data = _DataAccess.GetReport(cxmodel);
            if (data.Count != 0)
            {
                _DataAccess.DeleteByCXHDID(CXHDID);
                for (int i = 0; i < data.Count; i++)
                {
                    CRM_COST_CXHDPGHZ model = new CRM_COST_CXHDPGHZ();
                    model.CXHDID = data[i].CXHDID;
                    model.CPLXID = data[i].CPLXID;
                    model.SJHDSL = data[i].SJHDSL;
                    model.SJHDXS = data[i].SJHDXS;
                    model.FYZCFS = data[i].FYZCFS;
                    model.FYZC = data[i].FYZC;
                    model.FYZCJE = data[i].FYZCJE;
                    model.SJTHL = data[i].SJTHL;
                    model.BS = data[i].BS;
                    model.ISACTIVE = 1;
                    int PGHZID = _DataAccess.Create(model);

                }
                return 1;
            }
            return 0;
        }





    }
}
