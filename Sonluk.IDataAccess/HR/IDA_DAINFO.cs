using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IDA_DAINFO
    {
        MES_RETURN INSERT_DADM(HR_DA_DADM model);
        HR_DA_DADM_SELECT SELECT_DADM(HR_DA_DADM model);
        MES_RETURN UPDATE_DADM(HR_DA_DADM model);
        MES_RETURN DELETE_DADM(int DADMID);
        MES_RETURN INSERT_DAINFO(HR_DA_DAINFO model);
        HR_DA_DAINFO_SELECT SELECT_DAINFO(HR_DA_DAINFO model);
        MES_RETURN UPDATE_DAINFO(HR_DA_DAINFO model);
        MES_RETURN DELETE_DAINFO(int DAID);
        MES_RETURN INSERT_DAJYJL(HR_DA_DAJYJL model);
        HR_DA_DAJYJL_SELECT SELECT_DAJYJL(HR_DA_DAJYJL model);
        MES_RETURN UPDATE_DAJYJL(HR_DA_DAJYJL model);
    }
}
