using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.BARCODE;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.BARCODE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.BARCODE
{
    public class SY_CODING : ISY_CODING
    {

        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "BARCODE_SY_CODING_Create";
        private const string SQL_CreateByImport = "BARCODE_SY_CODING_CreateList";
        private const string SQL_Update = "BARCODE_SY_CODING_Update";
        private const string SQL_ReadByParam = "BARCODE_SY_CODING_ReadByParam";
        private const string SQL_Delete = "BARCODE_SY_CODING_Delete";

        public MES_RETURN Create(BARCODE_SY_CODING model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@BARCODE",model.BARCODE),
                                        new SqlParameter("@DESCRIPTION",model.DESCRIPTION),
                                        new SqlParameter("@PP",model.PP),
                                        new SqlParameter("@CPZL",model.CPZL),
                                        new SqlParameter("@XH",model.XH),
                                        new SqlParameter("@QUANTITY",model.QUANTITY),
                                        new SqlParameter("@BZXS",model.BZXS),
                                        new SqlParameter("@BZSL",model.BZSL),
                                        new SqlParameter("@VERSION",model.VERSION),
                                        new SqlParameter("@YWY",model.YWY),
                                        new SqlParameter("@SQR",model.SQR),
                                        new SqlParameter("@BEGINNING",model.BEGINNING),
                                        new SqlParameter("@PIPECODE",model.PIPECODE),
                                        new SqlParameter("@BEIZ",model.BEIZ),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@CJR",model.CJR),
                                        new SqlParameter("@XGR",model.XGR),
                                     
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "BARCODE_SY_CODING_Create");

            }
            return mr;
        }
        public MES_RETURN CreateByImport(List<BARCODE_SY_CODING> model)
        {
            MES_RETURN mr = new MES_RETURN();
      
            DataTable dt = new DataTable();
            dt.Columns.Add("BARCODE", typeof(string));
            dt.Columns.Add("DESCRIPTION", typeof(string));
            dt.Columns.Add("PP", typeof(string));
            dt.Columns.Add("CPZL", typeof(string));
            dt.Columns.Add("XH", typeof(string));
            dt.Columns.Add("QUANTITY", typeof(string));
            dt.Columns.Add("BZXS", typeof(string));
            dt.Columns.Add("BZSL", typeof(string));
            dt.Columns.Add("SERIES", typeof(string));
            dt.Columns.Add("VERSION", typeof(string));
            dt.Columns.Add("YWY", typeof(string));
            dt.Columns.Add("SQR", typeof(string));
            dt.Columns.Add("BEGINNING", typeof(string));
            dt.Columns.Add("PIPECODE", typeof(string));
            dt.Columns.Add("BEIZ", typeof(string));
            dt.Columns.Add("ISACTIVE", typeof(string));
            dt.Columns.Add("CJR", typeof(string));
            dt.Columns.Add("XGR", typeof(string));
            if (model.Count == 0)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "传入新增数据为空！";
            }
            foreach (BARCODE_SY_CODING node in model)
            {
                DataRow dr = dt.NewRow();
                int i = 0;
                dr[i] = node.BARCODE;
                dr[i++] = node.DESCRIPTION;
                dr[i++] = node.PP;
                dr[i++] = node.CPZL;
                dr[i++] = node.XH;
                dr[i++] = node.QUANTITY;
                dr[i++] = node.BZXS;
                dr[i++] = node.BZSL;
                dr[i++] = node.VERSION;
                dr[i++] = node.YWY;
                dr[i++] = node.SQR;
                dr[i++] = node.BEGINNING;
                dr[i++] = node.PIPECODE;
                dr[i++] = node.BEIZ;
                dr[i++] = node.ISACTIVE;
                dr[i++] = node.CJR;
                dt.Rows.Add(dr);
            }

            SqlParameter[] parms = {
                                       new SqlParameter("@LIST",dt)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_CreateByImport, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "BARCODE_SY_CODING_CreateList");

            }
            return mr;
        }
        public MES_RETURN Update(BARCODE_SY_CODING model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                         new SqlParameter("@ID",model.ID),
                                        new SqlParameter("@BARCODE",model.BARCODE),
                                        new SqlParameter("@DESCRIPTION",model.DESCRIPTION),
                                        new SqlParameter("@PP",model.PP),
                                        new SqlParameter("@CPZL",model.CPZL),
                                        new SqlParameter("@XH",model.XH),
                                        new SqlParameter("@QUANTITY",model.QUANTITY),
                                        new SqlParameter("@BZXS",model.BZXS),
                                        new SqlParameter("@BZSL",model.BZSL),
                                        new SqlParameter("@SERIES",model.SERIES),
                                        new SqlParameter("@VERSION",model.VERSION),
                                        new SqlParameter("@YWY",model.YWY),
                                        new SqlParameter("@SQR",model.SQR),
                                        new SqlParameter("@BEGINNING",model.BEGINNING),
                                        new SqlParameter("@PIPECODE",model.PIPECODE),
                                        new SqlParameter("@BEIZ",model.BEIZ),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@XGR",model.XGR),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "BARCODE_SY_CODING_Update");

            }
            return mr;
        }
        public IList<BARCODE_SY_CODING> ReadByParam(BARCODE_SY_CODING model)
        {
            IList<BARCODE_SY_CODING> nodes = new List<BARCODE_SY_CODING>();
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                        new SqlParameter("@BARCODE",model.BARCODE),
                                        new SqlParameter("@DESCRIPTION",model.DESCRIPTION),
                                        new SqlParameter("@PP",model.PP),
                                        new SqlParameter("@CPZL",model.CPZL),
                                        new SqlParameter("@XH",model.XH),
                                        new SqlParameter("@QUANTITY",model.QUANTITY),
                                        new SqlParameter("@BZXS",model.BZXS),
                                        new SqlParameter("@BZSL",model.BZSL),
                                        new SqlParameter("@SERIES",model.SERIES),
                                        new SqlParameter("@VERSION",model.VERSION),
                                        new SqlParameter("@YWY",model.YWY),
                                        new SqlParameter("@SQR",model.SQR),
                                        new SqlParameter("@BEGINNING",model.BEGINNING),
                                        new SqlParameter("@PIPECODE",model.PIPECODE),
                                        new SqlParameter("@BEIZ",model.BEIZ),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@KSTIME",model.KSTIME),
                                        new SqlParameter("@JSTIME",model.JSTIME)
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "BARCODE_SY_CODING_ReadByParam");
                throw new ApplicationException(e.Message);
            }
        }


        public MES_RETURN Delete(int ID)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",ID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "BARCODE_SY_CODING_Delete");

            }
            return mr;
        }
        private BARCODE_SY_CODING ReadDataToModel(SqlDataReader sdr)
        {
            BARCODE_SY_CODING node = new BARCODE_SY_CODING();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.BARCODE = Convert.ToString(sdr["BARCODE"]);
            node.DESCRIPTION = Convert.ToString(sdr["DESCRIPTION"]);
            node.PP = Convert.ToInt32(sdr["PP"]);
            node.CPZL = Convert.ToInt32(sdr["CPZL"]);
            node.XH = Convert.ToInt32(sdr["XH"]);
            node.QUANTITY = Convert.ToInt32(sdr["QUANTITY"]);
            node.BZXS = Convert.ToInt32(sdr["BZXS"]);
            node.BZSL = Convert.ToString(sdr["BZSL"]);
            node.SERIES = Convert.ToInt32(sdr["SERIES"]);
            node.VERSION = Convert.ToString(sdr["VERSION"]);
            node.YWY = Convert.ToString(sdr["YWY"]);
            node.SQR = Convert.ToString(sdr["SQR"]);
            node.BEGINNING = Convert.ToInt32(sdr["BEGINNING"]);
            node.PIPECODE = Convert.ToString(sdr["PIPECODE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.PPMC = Convert.ToString(sdr["PPMC"]);
            node.CPZLMC = Convert.ToString(sdr["CPZLMC"]);
            node.XHMC = Convert.ToString(sdr["XHMC"]);
            node.QUANTITYMC = Convert.ToString(sdr["QUANTITYMC"]);
            node.BZXSMC = Convert.ToString(sdr["BZXSMC"]);
            node.SERIESMC = Convert.ToString(sdr["SERIESMC"]);
            return node;
        }




    }
}
