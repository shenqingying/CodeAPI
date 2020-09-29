using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.FIVES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.FIVES
{
    public class CHECK_INFO : ICHECK_INFO
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "FIVES_CHECK_INFO_Create";
        private const string SQL_Update = "FIVES_CHECK_INFO_Update";
        private const string SQL_Read = "FIVES_CHECK_INFO_Read";
        private const string SQL_Read_HZINFO = "FIVES_CHECK_INFO_Read_HZINFO";
        private const string SQL_Delete = "FIVES_CHECK_INFO_Delete";

        public MES_RETURN Create(FIVES_CHECK_INFO model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@INFOID",model.INFOID),
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@TYPEMS",model.TYPEMS),
                                        new SqlParameter("@SCOREID",model.SCOREID),
                                        new SqlParameter("@SCOREMS",model.SCOREMS),
                                        new SqlParameter("@JLTIME",model.JLTIME),
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                        new SqlParameter("@REMARK",model.REMARK),
                                        new SqlParameter("@GC",model.GC),
                                        new SqlParameter("@DEPARTID",model.DEPARTID),
                                        new SqlParameter("@DEPARTMS",model.DEPARTMS),
                                        new SqlParameter("@OPINTID",model.OPINTID),
                                        new SqlParameter("@OPINTMS",model.OPINTMS),
                                        new SqlParameter("@WORKSHOPID",model.WORKSHOPID),
                                        new SqlParameter("@WORKSHOPMS",model.WORKSHOPMS),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@OPINTLOCATION",model.OPINTLOCATION),
                                        new SqlParameter("@HG",model.HG),
                                        new SqlParameter("@SHOWTIME",model.SHOWTIME),
                                        new SqlParameter("@SHOWNAME",model.SHOWNAME),
                                        new SqlParameter("@SHOWNAMEMS",model.SHOWNAMEMS),
                                        new SqlParameter("@POSITION",model.POSITION)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Create, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFO_Create");

            }
            return mr;
        }
        public MES_RETURN Update(FIVES_CHECK_INFO model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@INFOID",model.INFOID),
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@TYPEMS",model.TYPEMS),
                                        new SqlParameter("@SCOREID",model.SCOREID),
                                        new SqlParameter("@SCOREMS",model.SCOREMS),
                                        new SqlParameter("@JLTIME",model.JLTIME),
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                        new SqlParameter("@REMARK",model.REMARK),
                                        new SqlParameter("@GC",model.GC),
                                        new SqlParameter("@DEPARTID",model.DEPARTID),
                                        new SqlParameter("@DEPARTMS",model.DEPARTMS),
                                        new SqlParameter("@OPINTID",model.OPINTID),
                                        new SqlParameter("@OPINTMS",model.OPINTMS),
                                        new SqlParameter("@WORKSHOPID",model.WORKSHOPID),
                                        new SqlParameter("@WORKSHOPMS",model.WORKSHOPMS),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@OPINTLOCATION",model.OPINTLOCATION),
                                        new SqlParameter("@HG",model.HG),
                                        new SqlParameter("@SHOWTIME",model.SHOWTIME),
                                        new SqlParameter("@SHOWNAME",model.SHOWNAME),
                                        new SqlParameter("@SHOWNAMEMS",model.SHOWNAMEMS),
                                        new SqlParameter("@POSITION",model.POSITION)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms)) { }
                mr.TYPE = "S";

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFO_Update");

            }
            return mr;
        }
        public IList<FIVES_CHECK_INFOList> Read(FIVES_CHECK_INFOList model)
        {
            IList<FIVES_CHECK_INFOList> nodes = new List<FIVES_CHECK_INFOList>();
            SqlParameter[] parms = {
                                        new SqlParameter("@INFOID",model.INFOID),
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@TYPEMS",model.TYPEMS),
                                        new SqlParameter("@SCOREID",model.SCOREID),
                                        new SqlParameter("@SCOREMS",model.SCOREMS),
                                        new SqlParameter("@JLTIME",model.JLTIME),
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                        new SqlParameter("@REMARK",model.REMARK),
                                        new SqlParameter("@GC",model.GC),
                                        new SqlParameter("@DEPARTID",model.DEPARTID),
                                        new SqlParameter("@DEPARTMS",model.DEPARTMS),
                                        new SqlParameter("@OPINTID",model.OPINTID),
                                        new SqlParameter("@OPINTMS",model.OPINTMS),
                                        new SqlParameter("@WORKSHOPID",model.WORKSHOPID),
                                        new SqlParameter("@WORKSHOPMS",model.WORKSHOPMS),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@OPINTLOCATION",model.OPINTLOCATION),
                                        new SqlParameter("@KSTIME",model.KSTIME),
                                        new SqlParameter("@JSTIME",model.JSTIME),
                                        new SqlParameter("@HG",model.HG),
                                        new SqlParameter("@SHOWTIME",model.SHOWTIME),
                                        new SqlParameter("@SHOWNAME",model.SHOWNAME),
                                        new SqlParameter("@SHOWNAMEMS",model.SHOWNAMEMS),
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToModel(sdr));
                    }
                }
                return nodes;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFO_READ");
                throw new ApplicationException(e.Message);
            }
        }
        public IList<FIVES_CHECK_INFOList> Read_HZINFO(FIVES_CHECK_INFOList model)
        {
            IList<FIVES_CHECK_INFOList> nodes = new List<FIVES_CHECK_INFOList>();
            SqlParameter[] parms = {
                                        new SqlParameter("@INFOID",model.INFOID),
                                        new SqlParameter("@TYPEID",model.TYPEID),
                                        new SqlParameter("@TYPEMS",model.TYPEMS),
                                        new SqlParameter("@SCOREID",model.SCOREID),
                                        new SqlParameter("@SCOREMS",model.SCOREMS),
                                        new SqlParameter("@JLTIME",model.JLTIME),
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                        new SqlParameter("@REMARK",model.REMARK),
                                        new SqlParameter("@GC",model.GC),
                                        new SqlParameter("@DEPARTID",model.DEPARTID),
                                        new SqlParameter("@DEPARTMS",model.DEPARTMS),
                                        new SqlParameter("@OPINTID",model.OPINTID),
                                        new SqlParameter("@OPINTMS",model.OPINTMS),
                                        new SqlParameter("@WORKSHOPID",model.WORKSHOPID),
                                        new SqlParameter("@WORKSHOPMS",model.WORKSHOPMS),
                                        new SqlParameter("@ACTION",model.ACTION),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@OPINTLOCATION",model.OPINTLOCATION),
                                        new SqlParameter("@KSTIME",model.KSTIME),
                                        new SqlParameter("@JSTIME",model.JSTIME),
                                        new SqlParameter("@HG",model.HG),
                                        new SqlParameter("@SHOWTIME",model.SHOWTIME),
                                        new SqlParameter("@SHOWNAME",model.SHOWNAME),
                                        new SqlParameter("@SHOWNAMEMS",model.SHOWNAMEMS)
                                        
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_HZINFO, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadHZDataToModel(sdr));
                    }
                }
                return nodes;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFO_Read_HZINFO");
                throw new ApplicationException(e.Message);
            }
        }

        public MES_RETURN Delete(int ID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@INFOID",ID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Delete, parms)) { }
                mr.TYPE = "S";


            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "FIVES_CHECK_INFO_Delete");

            }
            return mr;
        }
        private FIVES_CHECK_INFOList ReadDataToModel(SqlDataReader sdr)
        {
            FIVES_CHECK_INFOList node = new FIVES_CHECK_INFOList();
            node.INFOID = Convert.ToInt32(sdr["INFOID"]);  //检查信息ID
            node.TYPEID = Convert.ToInt32(sdr["TYPEID"]);  //检查类型ID
            node.TYPEMS = Convert.ToString(sdr["TYPEMS"]);  //检查类型描述
            node.SCOREID = Convert.ToInt32(sdr["SCOREID"]);  //检查结果类型
            node.SCOREMS = Convert.ToString(sdr["SCOREMS"]);  //检查结果描述
            node.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");  //记录时间
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);  //人员ID
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);  //人员名字
            node.REMARK = Convert.ToString(sdr["REMARK"]);  //备注
            node.GC = Convert.ToString(sdr["GC"]);  //工厂
            node.DEPARTID = Convert.ToInt32(sdr["DEPARTID"]);  //部门ID
            node.DEPARTMS = Convert.ToString(sdr["DEPARTMS"]);  //部门描述
            node.OPINTID = Convert.ToInt32(sdr["OPINTID"]);  //检查点ID
            node.OPINTMS = Convert.ToString(sdr["OPINTMS"]);  //检查点描述
            node.WORKSHOPID = Convert.ToInt32(sdr["WORKSHOPID"]);  //车间ID
            node.WORKSHOPMS = Convert.ToString(sdr["WORKSHOPMS"]);  //车间描述
            node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //状态
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除
            node.OPINTLOCATION = Convert.ToString(sdr["OPINTLOCATION"]);  //检查点位置
            node.HG = Convert.ToInt16(sdr["HG"]);//合格
            node.SHOWTIME = Convert.ToDateTime(sdr["SHOWTIME"]).ToString("yyyy-MM-dd HH:mm:ss");  //显示时间
            node.SHOWNAME = Convert.ToInt16(sdr["SHOWNAME"]);  //显示姓名id
            node.SHOWNAMEMS = Convert.ToString(sdr["SHOWNAMEMS"]);//显示姓名
            node.POSITION = Convert.ToString(sdr["POSITION"]);//显示点检微信位置
            //node.SHOWTIME = "1";  //显示时间
            //node.SHOWNAME = 1;  //显示姓名id
            //node.SHOWNAMEMS = "1";//显示姓名

            return node;
        }
        private FIVES_CHECK_INFOList ReadHZDataToModel(SqlDataReader sdr)
        {
            FIVES_CHECK_INFOList node = new FIVES_CHECK_INFOList();
            //node.INFOID = Convert.ToInt32(sdr["INFOID"]);  //检查信息ID
            //node.TYPEID = Convert.ToInt32(sdr["TYPEID"]);  //检查类型ID
            //node.TYPEMS = Convert.ToString(sdr["TYPEMS"]);  //检查类型描述
            //node.SCOREID = Convert.ToInt32(sdr["SCOREID"]);  //检查结果类型
            //node.SCOREMS = Convert.ToString(sdr["SCOREMS"]);  //检查结果描述
            //node.JLTIME = Convert.ToString(sdr["JLTIME"]);  //记录时间
            //node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);  //人员ID
            //node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);  //人员名字
            //node.REMARK = Convert.ToString(sdr["REMARK"]);  //备注
            //node.GC = Convert.ToString(sdr["GC"]);  //工厂
            //node.DEPARTID = Convert.ToInt32(sdr["DEPARTID"]);  //部门ID
            node.DEPARTMS = Convert.ToString(sdr["DEPTNAME"]);  //部门描述
            node.OPINTID = Convert.ToInt32(sdr["POINTID"]);  //检查点ID
            node.OPINTMS = Convert.ToString(sdr["POINTMS"]);  //检查点描述
            node.CHECKCOUNT = Convert.ToInt32(sdr["CHECKCOUNT"]);
            node.BHGCOUNT = Convert.ToInt32(sdr["BHGCOUNT"]);
            node.FREQUENCYNAME = Convert.ToString(sdr["FREQUENCYNAME"]);  //检查频率
            //node.WORKSHOPID = Convert.ToInt32(sdr["WORKSHOPID"]);  //车间ID
            //node.WORKSHOPMS = Convert.ToString(sdr["WORKSHOPMS"]);  //车间描述
            //node.ACTION = Convert.ToInt32(sdr["ACTION"]);  //状态
            //node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);  //是否删除
            //node.OPINTLOCATION = Convert.ToString(sdr["OPINTLOCATION"]);  //检查点位置
            //node.HG = Convert.ToInt16(sdr["HG"]);
            return node;
        }


    }
}
