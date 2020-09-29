using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{

    public class HG_WJJL : IHG_WJJL
    {
        private const string SQL_Create = "CRM_HG_WJJL_Create";
        //private const string SQL_Update = "CRM_HG_WJJL_Update";
        private const string SQL_Read = "CRM_HG_WJJL_Read";
        private const string SQL_Delete = "CRM_HG_WJJL_Delete";
        private const string SQL_ReadByParam = "CRM_HG_WJJL_ReadByParam";
        private const string SQL_ReadLocation = "CRM_HG_WJJL_ReadLocation";
        private const string SQL_Update_SP = "CRM_HG_WJJL_Update_SP";
        private const string SQL_DisplayImgReport = @"CRM_HG_WJJL_DisplayImgReport";

        public int Create(CRM_HG_WJmodel model)
        {
            SqlParameter[] parms = {
                                      new SqlParameter("@GSDX",model.WJJLTT.GSDX),
                                      new SqlParameter("@GSDXID",model.WJJLTT.GSDXID),
                                      //new SqlParameter("@GSDXHXM",model.WJJLTT.GSDXHXM),
                                      new SqlParameter("@CZR",model.WJJLTT.CZR),
                                      new SqlParameter("@CZSJ",model.WJJLTT.CZSJ),
                                      new SqlParameter("@ISACTIVE",model.WJJLTT.ISACTIVE),
                                      new SqlParameter("@WJID",model.WJJL.WJID),
                                      //new SqlParameter("@WJHXM",model.WJJL.WJHXM),
                                      new SqlParameter("@WJM",model.WJJL.WJM),
                                      new SqlParameter("@ML",model.WJJL.ML),
                                      new SqlParameter("@WJMS",model.WJJL.WJMS),
                                      new SqlParameter("@ISATIVE",model.WJJL.ISATIVE),
                                      new SqlParameter("@IMGSOURCE",model.WJJL.IMGSOURCE),
                                      new SqlParameter("@WJLX",model.WJJL.WJLX),
                                      new SqlParameter("@MXCZR",model.WJJL.CZR),
                                      new SqlParameter("@MXCZSJ",model.WJJL.CZSJ),
                                      new SqlParameter("@SPZT",model.WJJL.SPZT),
                                      new SqlParameter("@SPR",model.WJJL.SPR),
                                      new SqlParameter("@SPSJ",model.WJJL.SPSJ),
                                      new SqlParameter("@SPYJ",model.WJJL.SPYJ),
                                      new SqlParameter("@OPINION",model.WJJL.OPINION)
                                   };

            return Binning(CommandType.StoredProcedure, SQL_Create, parms);

        }


        public IList<CRM_HG_WJJL> Read(int GSDX, int GSDXID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@GSDX",GSDX),
                                       new SqlParameter("@GSDXID",GSDXID)
                                   };
            IList<CRM_HG_WJJL> nodes = new List<CRM_HG_WJJL>();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_HG_WJJL> ReadByParam(CRM_HG_WJJL model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@GSDX",model.GSDX),
                                       new SqlParameter("@GSDXID",model.GSDXID),
                                       new SqlParameter("@WJLX",model.WJLX)
                                   };
            IList<CRM_HG_WJJL> nodes = new List<CRM_HG_WJJL>();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_HG_WJJL> ReadLocation(int GSDX, int GSDXID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@GSDX",GSDX),
                                       new SqlParameter("@GSDXID",GSDXID)
                                   };
            IList<CRM_HG_WJJL> nodes = new List<CRM_HG_WJJL>();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadLocation, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadLocationDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_HG_WJJL> DisplayImgReport(CRM_HG_WJJL_KHModel model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHLX",model.KHLX),
                                        new SqlParameter("@CRMID",model.CRMID),
                                        new SqlParameter("@MC",model.MC),
                                        new SqlParameter("@SAPSN",model.SAPSN),
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@SF",model.SF),
                                        new SqlParameter("@CS",model.CS),
                                        new SqlParameter("@XSZZ",model.XSZZ),
                                        new SqlParameter("@FID",model.FID),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@STAFFID",STAFFID),
                                        new SqlParameter("@PMC",model.PMC),
                                        new SqlParameter("@PCRMID",model.PCRMID),
                                        new SqlParameter("@IsOfficial",model.IsOfficial),
                                        new SqlParameter("@MCSX",model.MCSX),
                                        new SqlParameter("@STARTTIME",model.STARTTIME),
                                        new SqlParameter("@ENDTIME",model.ENDTIME),
                                        new SqlParameter("@IsDZS",model.IsDZS),
                                        new SqlParameter("@IsZXS",model.IsZXS),
                                        new SqlParameter("@HDMC",model.HDMC),
                                        new SqlParameter("@BEIZ",model.BEIZ),
                                        new SqlParameter("@DISPLAY_STATUS",model.DISPLAY_STATUS),
                                        new SqlParameter("@DISPLAYITEM",model.DISPLAYITEM),
                                        new SqlParameter("@HUODONG_STATUS",model.HUODONG_STATUS),
                                        new SqlParameter("@IncludePKH",model.IncludePKH),
                                        new SqlParameter("@IMG_CJSJ_BEGIN",model.IMG_CJSJ_BEGIN),
                                        new SqlParameter("@IMG_CJSJ_END",model.IMG_CJSJ_END),
                                        new SqlParameter("@LB",model.LB)
                                   };

            IList<CRM_HG_WJJL> nodes = new List<CRM_HG_WJJL>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DisplayImgReport, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDisplayImgDataToObject(sdr, model.LB));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public int Delete(int JLID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@JLID",JLID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int Update_SP(CRM_HG_WJJL model)
        {
            SqlParameter[] parms = {
                                      new SqlParameter("@ID",model.ID),
                                      new SqlParameter("@SPZT",model.SPZT),
                                      new SqlParameter("@SPR",model.SPR),
                                      new SqlParameter("@SPSJ",model.SPSJ),
                                      new SqlParameter("@SPYJ",model.SPYJ),
                                      new SqlParameter("@OPINION",model.OPINION),
                                      new SqlParameter("@HFR",model.HFR),
                                      new SqlParameter("@HFSJ",model.HFSJ),
                                      new SqlParameter("@HFYJ",model.HFYJ)
                                   };

            return Binning(CommandType.StoredProcedure, SQL_Update_SP, parms);

        }




        private int Binning(CommandType type, string sql, SqlParameter[] parms)
        {
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(type, sql, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["ID"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return ID;
        }



        private CRM_HG_WJJL ReadDataToObject(SqlDataReader sdr)
        {
            CRM_HG_WJJL node = new CRM_HG_WJJL();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.WJID = Convert.ToInt32(sdr["WJID"]);
            //node.WJHXM = Convert.ToInt32(sdr["WJHXM"]);
            node.WJM = Convert.ToString(sdr["WJM"]);
            node.ML = Convert.ToString(sdr["ML"]);
            node.WJMS = Convert.ToString(sdr["WJMS"]);
            node.ISATIVE = Convert.ToInt32(sdr["ISATIVE"]);
            node.IMGSOURCE = Convert.ToString(sdr["IMGSOURCE"]);
            node.WJLX = Convert.ToInt32(sdr["WJLX"]);
            node.WJLXDES = Convert.ToString(sdr["WJLXDES"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZRDES = Convert.ToString(sdr["CZRDES"]);
            node.CZSJ = Convert.ToString(sdr["CZSJ"]);
            node.SPZT = Convert.ToInt32(sdr["SPZT"]);
            node.SPR = Convert.ToInt32(sdr["SPR"]);
            node.SPRNAME = Convert.ToString(sdr["SPRNAME"]);
            node.SPSJ = Convert.ToString(sdr["SPSJ"]);
            node.SPYJ = Convert.ToInt32(sdr["SPYJ"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.SPYJDES = Convert.ToString(sdr["SPYJDES"]);
            node.HFRNAME = Convert.ToString(sdr["HFRNAME"]);
            node.HFR = Convert.ToInt32(sdr["HFR"]);
            node.HFSJ = Convert.ToString(sdr["HFSJ"]);
            node.HFYJ = Convert.ToString(sdr["HFYJ"]);
            return node;
        }

        private CRM_HG_WJJL ReadLocationDataToObject(SqlDataReader sdr)
        {
            CRM_HG_WJJL node = new CRM_HG_WJJL();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.WJID = Convert.ToInt32(sdr["WJID"]);
            //node.WJHXM = Convert.ToInt32(sdr["WJHXM"]);
            node.WJM = Convert.ToString(sdr["WJM"]);
            node.ML = Convert.ToString(sdr["ML"]);
            node.WJMS = Convert.ToString(sdr["WJMS"]);
            node.ISATIVE = Convert.ToInt32(sdr["ISATIVE"]);
            node.IMGSOURCE = Convert.ToString(sdr["IMGSOURCE"]);
            node.WJLX = Convert.ToInt32(sdr["WJLX"]);
            node.WJLXDES = Convert.ToString(sdr["WJLXDES"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZRDES = Convert.ToString(sdr["CZRDES"]);
            node.CZSJ = Convert.ToString(sdr["CZSJ"]);
            node.QDWZ = Convert.ToString(sdr["QDWZ"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);

            node.SPZT = Convert.ToInt32(sdr["SPZT"]);
            node.SPR = Convert.ToInt32(sdr["SPR"]);
            node.SPRNAME = Convert.ToString(sdr["SPRNAME"]);
            node.SPSJ = Convert.ToString(sdr["SPSJ"]);
            node.SPYJ = Convert.ToInt32(sdr["SPYJ"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.SPYJDES = Convert.ToString(sdr["SPYJDES"]);
            node.HFRNAME = Convert.ToString(sdr["HFRNAME"]);
            node.HFR = Convert.ToInt32(sdr["HFR"]);
            node.HFSJ = Convert.ToString(sdr["HFSJ"]);
            node.HFYJ = Convert.ToString(sdr["HFYJ"]);
            return node;
        }

        private CRM_HG_WJJL ReadDisplayImgDataToObject(SqlDataReader sdr, int LB)
        {
            CRM_HG_WJJL node = new CRM_HG_WJJL();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.WJID = Convert.ToInt32(sdr["WJID"]);
            //node.WJHXM = Convert.ToInt32(sdr["WJHXM"]);
            node.WJM = Convert.ToString(sdr["WJM"]);
            node.ML = Convert.ToString(sdr["ML"]);
            node.WJMS = Convert.ToString(sdr["WJMS"]);
            node.ISATIVE = Convert.ToInt32(sdr["ISATIVE"]);
            node.IMGSOURCE = Convert.ToString(sdr["IMGSOURCE"]);
            node.WJLX = Convert.ToInt32(sdr["WJLX"]);
            node.WJLXDES = Convert.ToString(sdr["WJLXDES"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZRDES = Convert.ToString(sdr["CZRDES"]);
            node.CZSJ = Convert.ToString(sdr["CZSJ"]);
            node.SPZT = Convert.ToInt32(sdr["SPZT"]);
            node.SPR = Convert.ToInt32(sdr["SPR"]);
            node.SPRNAME = Convert.ToString(sdr["SPRNAME"]);
            node.SPSJ = Convert.ToString(sdr["SPSJ"]);
            node.SPYJ = Convert.ToInt32(sdr["SPYJ"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.SPYJDES = Convert.ToString(sdr["SPYJDES"]);

            if (LB == 1)
            {
                //陈列字段
                node.CLLX = Convert.ToInt32(sdr["CLLX"]);
                node.CLFS = Convert.ToInt32(sdr["CLFS"]);
                node.CLGSRQ = Convert.ToString(sdr["CLGSRQ"]);
                node.CLGSJSRQ = Convert.ToString(sdr["CLGSJSRQ"]);
                node.CLFSDES = Convert.ToString(sdr["CLFSDES"]);
            }


            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.MCSX = Convert.ToInt32(sdr["MCSX"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            return node;
        }



    }
}
