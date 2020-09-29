using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KQ_CC
    {
        private static readonly IKQ_CC _DataAccess = RMSDataAccess.CreateKQ_CC();
        public int Create_MX(CRM_KQ_CCMX model)
        {
            return _DataAccess.Create_MX(model);
        }
        public int Update_MX(CRM_KQ_CCMX model)
        {
            return _DataAccess.Update_MX(model);
        }
        public int Delete_MX(int ID)
        {
            return _DataAccess.Delete_MX(ID);
        }
        public IList<CRM_KQ_CCMX> Read_MXbyCCID(int CCID)
        {
            return _DataAccess.Read_MXbyCCID(CCID);
        }
        public IList<CRM_KQ_CCMXList> Read_MXQDbyCCID(int CCID)
        {
            //
            IList<CRM_KQ_CCMXList> models = _DataAccess.Read_MXQDbyCCID(CCID);
            for (int i = 0; i < models.Count; i++)
            {
                if(models[i].QDSJ == "1900-01-01 00:00:00")
                {
                    models[i].QDSJ = "";
                }
            }
            return models;
        }
        public int Create_TT(CRM_KQ_CCTT model)
        {
            return _DataAccess.Create_TT(model);
        }
        public int Update_TT(CRM_KQ_CCTT model)
        {
            return _DataAccess.Update_TT(model);
        }
        public int Delete_TT(int CCID)
        {
            return _DataAccess.Delete_TT(CCID);
        }
        public IList<CRM_KQ_CCTTList> Read_TTbySTAFFID(int STAFFID, int Status)
        {
            return _DataAccess.Read_TTbySTAFFID(STAFFID, Status);
        }
        public CRM_KQ_CCTT Read_TTbyCCID(int CCID)
        {
            return _DataAccess.Read_TTbyCCID(CCID);
        }
        public IList<CRM_KQ_CCTTList> Read_TTbyParam(CRM_KQ_CCTT model, int STATUS)
        {
            return _DataAccess.Read_TTbyParam(model, STATUS);
        }
    }
}
