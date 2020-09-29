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
    public class SY_GC : ISY_GC
    {

        private const string SQL_DELETE = "UPDATE MES_SY_GC SET ISDELETE = 1 WHERE GC=@GC";
        private const string SQL_UPDATE = "UPDATE MES_SY_GC SET GCMS=@GCMS,GCDYMS=@GCDYMS,ISACTION=@ISACTION,GCADDRESS=@GCADDRESS,ISAUTOWORKSPACE=@ISAUTOWORKSPACE,GCDM=@GCDM WHERE GC=@GC";
        private const string SQL_INSERT = "INSERT MES_SY_GC(GC,GCMS,GCDYMS,ISDELETE,ISACTION,GCADDRESS,ISAUTOWORKSPACE,GCDM) VALUES(@GC,@GCMS,@GCDYMS,0,@ISACTION,@GCADDRESS,@ISAUTOWORKSPACE,@GCDM)";
        string SQL_SELECT_COUNT = "SELECT COUNT(*) AS MCOUNT FROM MES_SY_GC WHERE GC=@GC";
        string SQL_SELECT_BY_ROLE = "MES_SY_GC_SELECT_BYROLE";
        string SQL_SELECT = "MES_SY_GC_SELECT";
        const string SQL_SELECT_LAY = "SELECT A.*,ISNULL(B.STAFFID,0) AS STAFFID FROM MES_SY_GC AS A LEFT JOIN MES_ROLE_GC AS B ON A.GC=B.GC AND B.STAFFID=@STAFFID WHERE ISDELETE=0";
        SY_EXCEPTION SY_EXCEPTIONService = new SY_EXCEPTION();
        public IList<MES_SY_GC> read(MES_SY_GC model)
        {

            IList<MES_SY_GC> rst = new List<MES_SY_GC>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@ISACTION",model.ISACTION)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GC node = new MES_SY_GC();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GCMS = Convert.ToString(sdr["GCMS"]);
                        node.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        node.GCADDRESS = Convert.ToString(sdr["GCADDRESS"]);
                        node.ISAUTOWORKSPACE = Convert.ToBoolean(sdr["ISAUTOWORKSPACE"]);
                        node.GCDM = Convert.ToString(sdr["GCDM"]);
                        rst.Add(node);
                    }
                }
            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GC");
                throw new ApplicationException(e.Message);
            }
            return rst;
        }


        public MES_RETURN delete(string GC)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { new SqlParameter("@GC", GC) };

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms)) { }
                mr.TYPE = "S";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GC");
            }
            return mr;
        }


        public MES_RETURN UPDATE(MES_SY_GC model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GCMS",model.GCMS),
                                       new SqlParameter("@GCDYMS",model.GCDYMS),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@GCADDRESS",model.GCADDRESS),
                                       new SqlParameter("@ISAUTOWORKSPACE",model.ISAUTOWORKSPACE),
                                       new SqlParameter("@GCDM",model.GCDM)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_UPDATE, parms)) { }
                mr.TYPE = "S";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GC");
            }
            return mr;
        }


        public MES_RETURN insert(MES_SY_GC model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GCMS",model.GCMS),
                                       new SqlParameter("@GCDYMS",model.GCDYMS),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@GCADDRESS",model.GCADDRESS),
                                       new SqlParameter("@ISAUTOWORKSPACE",model.ISAUTOWORKSPACE),
                                       new SqlParameter("@GCDM",model.GCDM)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT, parms)) { }
                mr.TYPE = "S";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GC");
            }
            return mr;
        }


        public int SELECT_COUNT(MES_SY_GC model)
        {

            int rst = 0;
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_COUNT, parms))
                {
                    while (sdr.Read())
                    {
                        rst = Convert.ToInt32(sdr["MCOUNT"]);
                    }
                }

            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GC");
                throw new ApplicationException(e.Message);
            }
            return rst;
        }


        public IList<MES_SY_GC> SELECT_BY_ROLE(MES_SY_GC model)
        {

            IList<MES_SY_GC> rst = new List<MES_SY_GC>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GCMS",model.GCMS),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GC node = new MES_SY_GC();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GCMS = Convert.ToString(sdr["GCMS"]);
                        node.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        node.GCADDRESS = Convert.ToString(sdr["GCADDRESS"]);
                        node.ISAUTOWORKSPACE = Convert.ToBoolean(sdr["ISAUTOWORKSPACE"]);
                        node.GCDM = Convert.ToString(sdr["GCDM"]);
                        rst.Add(node);
                    }
                }
            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GC");
                throw new ApplicationException(e.Message);
            }
            return rst;
        }

        public MES_SY_GC_LAY_SELECT SELECT_LAY(int STAFFID)
        {

            MES_SY_GC_LAY_SELECT rst = new MES_SY_GC_LAY_SELECT();
            List<MES_SY_GC_LAY> child_MES_SY_GC_LAY = new List<MES_SY_GC_LAY>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_LAY, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GC_LAY node = new MES_SY_GC_LAY();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GCMS = Convert.ToString(sdr["GCMS"]);
                        node.STAFFID = STAFFID;
                        if (Convert.ToInt32(sdr["STAFFID"]) > 0)
                        {
                            node.LAY_CHECKED = true;
                        }
                        else
                        {
                            node.LAY_CHECKED = false;
                        }
                        child_MES_SY_GC_LAY.Add(node);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GC_SELECT_LAY");
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_GC_LAY = child_MES_SY_GC_LAY;
            return rst;
        }
    }
}
