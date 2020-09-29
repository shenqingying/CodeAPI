using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class DA_DAINFO
    {
        private static readonly IDA_DAINFO IDA_DAINFOdata = HRDataAccess.CreateIDA_DAINFO();
        public MES_RETURN INSERT_DADM(HR_DA_DADM model) 
        {
            return IDA_DAINFOdata.INSERT_DADM(model);
        }
        public HR_DA_DADM_SELECT SELECT_DADM(HR_DA_DADM model)
        {
            return IDA_DAINFOdata.SELECT_DADM(model);
        }
        public MES_RETURN UPDATE_DADM(HR_DA_DADM model)
        {
            return IDA_DAINFOdata.UPDATE_DADM(model);
        }
        public MES_RETURN DELETE_DADM(int DADMID)
        {
            return IDA_DAINFOdata.DELETE_DADM(DADMID);
        }
        public MES_RETURN INSERT_DAINFO(HR_DA_DAINFO model)
        {
            return IDA_DAINFOdata.INSERT_DAINFO(model);
        }
        public HR_DA_DAINFO_SELECT SELECT_DAINFO(HR_DA_DAINFO model)
        {
            return IDA_DAINFOdata.SELECT_DAINFO(model);
        }
        public MES_RETURN UPDATE_DAINFO(HR_DA_DAINFO model)
        {
            return IDA_DAINFOdata.UPDATE_DAINFO(model);
        }
        public MES_RETURN DELETE_DAINFO(int DAID)
        {
            return IDA_DAINFOdata.DELETE_DAINFO(DAID);
        }
        public MES_RETURN INSERT_DAJYJL(HR_DA_DAJYJL model)
        {
            return IDA_DAINFOdata.INSERT_DAJYJL(model);
        }
        public HR_DA_DAJYJL_SELECT SELECT_DAJYJL(HR_DA_DAJYJL model)
        {
            return IDA_DAINFOdata.SELECT_DAJYJL(model);
        }
        public MES_RETURN UPDATE_DAJYJL(HR_DA_DAJYJL model)
        {
            return IDA_DAINFOdata.UPDATE_DAJYJL(model);
        }
    }
}
