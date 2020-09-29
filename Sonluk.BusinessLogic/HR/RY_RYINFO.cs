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
    public class RY_RYINFO
    {
        private static readonly IRY_RYINFO IRY_RYINFOdata = HRDataAccess.CreateRY_RYINFO();
        public HR_RY_RYINFO_SELECT INSERT(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.INSERT(model);
        }
        public HR_RY_RYINFO_SELECT SELECT(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.SELECT(model);
        }
        public MES_RETURN UPDATE(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.UPDATE(model);
        }
        public MES_RETURN UPDATE_ALL(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.UPDATE_ALL(model);
        }
        public MES_RETURN UPDATE_PIC(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.UPDATE_PIC(model);
        }
        public MES_RETURN UPDATE_CHECK(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.UPDATE_CHECK(model);
        }
        public MES_RETURN UPDATE_YGTYPE(List<HR_RY_RYINFO> model, int YGTYPE, int ZZZT)
        {
            return IRY_RYINFOdata.UPDATE_YGTYPE(model, YGTYPE, ZZZT);
        }
        public MES_RETURN UPDATE_DEPT(List<HR_RY_RYINFO> model, int DEPT, int GSBM)
        {
            return IRY_RYINFOdata.UPDATE_DEPT(model, DEPT, GSBM);
        }
        public MES_RETURN UPDATE_JOBS(List<HR_RY_RYINFO> model, int JOBS)
        {
            return IRY_RYINFOdata.UPDATE_JOBS(model, JOBS);
        }
        public MES_RETURN UPDATE_QUIT(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.UPDATE_QUIT(model);
        }
        public MES_RETURN UPDATE_CHANGEINFO(HR_RY_RYINFO_CHANGEINFO model)
        {
            return IRY_RYINFOdata.UPDATE_CHANGEINFO(model);
        }
        public MES_RETURN UPDATE_ISINGH(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.UPDATE_ISINGH(model);
        }
        public MES_RETURN UPDATE_DUTYNAME(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.UPDATE_DUTYNAME(model);
        }
        public HR_RY_RYINFO_SELECT SELECT_GSGL(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.SELECT_GSGL(model);
        }
        public HR_RY_RYINFO_SELECT SELECT_WJGL(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.SELECT_WJGL(model);
        }
        public HR_RY_RYINFO_SELECT SELECT_WBZW(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.SELECT_WBZW(model);
        }
        public MES_RETURN INSERT_RONGY(HR_RY_RONGY model)
        {
            return IRY_RYINFOdata.INSERT_RONGY(model);
        }
        public HR_RY_RONGY_SELECT SELECT_RONGY(HR_RY_RONGY model)
        {
            return IRY_RYINFOdata.SELECT_RONGY(model);
        }
        public MES_RETURN UPDATE_RONGY(HR_RY_RONGY model)
        {
            return IRY_RYINFOdata.UPDATE_RONGY(model);
        }
        public MES_RETURN DELETE_RONGY(int RONGYID)
        {
            return IRY_RYINFOdata.DELETE_RONGY(RONGYID);
        }
        public MES_RETURN INSERT_RONGY_RYID(int RONGYID, int RYID)
        {
            return IRY_RYINFOdata.INSERT_RONGY_RYID(RONGYID, RYID);
        }
        public MES_RETURN DELETE_RONGY_RYID(int RONGYID)
        {
            return IRY_RYINFOdata.DELETE_RONGY_RYID(RONGYID);
        }
        public HR_RY_RONGY_SELECT SELECT_RONGY_RYID(int RYID)
        {
            return IRY_RYINFOdata.SELECT_RONGY_RYID(RYID);
        }
        public HR_RY_RYINFO_SELECT SELECT_LB(HR_RY_RYINFO model, int LB)
        {
            return IRY_RYINFOdata.SELECT_LB(model, LB);
        }
        public MES_RETURN INSERT_RONGY_FILE(HR_RY_RONGY model)
        {
            return IRY_RYINFOdata.INSERT_RONGY_FILE(model);
        }
        public HR_RY_RONGY_SELECT SELECT_RONGY_FILE(int RONGYID)
        {
            return IRY_RYINFOdata.SELECT_RONGY_FILE(RONGYID);
        }
        public MES_RETURN DELETE_RONGY_FILE(int RYFILEID)
        {
            return IRY_RYINFOdata.DELETE_RONGY_FILE(RYFILEID);
        }
        public HR_RY_LZINFO_SELECT SELECT_LZINFO(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.SELECT_LZINFO(model);
        }
        public HR_RY_CHANGEINFO_SELECT SELECT_RY_CHANGEINFO(HR_RY_RYINFO_CHANGEINFO model)
        {
            return IRY_RYINFOdata.SELECT_RY_CHANGEINFO(model);
        }
        public MES_RETURN UPDATE_LB(HR_RY_RYINFO model)
        {
            return IRY_RYINFOdata.UPDATE_LB(model);
        }
    }
}
