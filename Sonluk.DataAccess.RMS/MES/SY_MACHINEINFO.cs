using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class SY_MACHINEINFO : ISY_MACHINEINFO
    {
        SY_EXCEPTION SY_EXCEPTIONService = new SY_EXCEPTION();
        string SQL_INSERT = "MES_SY_MACHINEINFO_INSERT";
        string SQL_SELECT = "MES_SY_MACHINEINFO_SELECT";
        string SQL_SELECT_BBXX = "MES_SY_MACHINEINFO_SELECTXXBB";
        public MES_SY_MACHINEINFO insert(MES_SY_MACHINEINFO model)
        {
            MES_SY_MACHINEINFO rst = new MES_SY_MACHINEINFO();
            SqlParameter[] parms = { 
                                       new SqlParameter("@WKINFO",model.WKINFO),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@REMARK",model.REMARK)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.ID = Convert.ToInt32(sdr["ID"]);
                        rst.MNUMBER = Convert.ToString(sdr["MNUMBER"]);
                        rst.WKINFO = Convert.ToString(sdr["WKINFO"]);
                        rst.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
                        rst.GC = Convert.ToString(sdr["GC"]);
                        rst.REMARK = Convert.ToString(sdr["REMARK"]);
                    }
                }
                return rst;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_MACHINEINFO_SELECT");
                throw new ApplicationException(e.Message);
            }
        }


        public MES_SY_MACHINEINFO_SELECT SELECT(MES_SY_MACHINEINFO model)
        {
            MES_SY_MACHINEINFO_SELECT rst = new MES_SY_MACHINEINFO_SELECT();
            List<MES_SY_MACHINEINFO> child_MES_SY_MACHINEINFO = new List<MES_SY_MACHINEINFO>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@WKINFO",model.WKINFO)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_MACHINEINFO child = new MES_SY_MACHINEINFO();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.MNUMBER = Convert.ToString(sdr["MNUMBER"]);
                        child.WKINFO = Convert.ToString(sdr["WKINFO"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child_MES_SY_MACHINEINFO.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_MACHINEINFO_SELECT");
            }
            rst.MES_SY_MACHINEINFO = child_MES_SY_MACHINEINFO;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }


        public MES_SY_MACHINEINFO_SELECTBBXX SELECT_BBXX(MES_SY_MACHINEINFO_BBXX model)
        {
            MES_SY_MACHINEINFO_SELECTBBXX rst = new MES_SY_MACHINEINFO_SELECTBBXX();
            List<MES_SY_MACHINEINFO_BBXX> child_MES_SY_MACHINEINFO_BBXX = new List<MES_SY_MACHINEINFO_BBXX>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            SqlParameter[] parms = { };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BBXX, null))
                {
                    while (sdr.Read())
                    {
                        MES_SY_MACHINEINFO_BBXX child = new MES_SY_MACHINEINFO_BBXX();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.MNUMBER = Convert.ToString(sdr["MNUMBER"]);
                        child.WKINFO = Convert.ToString(sdr["WKINFO"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.PBID = Convert.ToInt32(sdr["PBID"]);
                        child.SYID = Convert.ToString(sdr["SYID"]);
                        child.NEWBB = Convert.ToString(sdr["NEWBB"]);
                        child.LASTNEWBB = Convert.ToString(sdr["LASTNEWBB"]);
                        child_MES_SY_MACHINEINFO_BBXX.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
                catch(Exception e){
                    child_MES_RETURN.TYPE="E";
                    child_MES_RETURN.MESSAGE=e.Message;
                    SY_EXCEPTIONService.INSERT(e.ToString(),"SY_MACHINEINFO_SELECTBBXX");
                }
            rst.MES_SY_MACHINEINFO_BBXX=child_MES_SY_MACHINEINFO_BBXX;
            rst.MES_RETURN=child_MES_RETURN;
            return rst;
            }
     }



}
