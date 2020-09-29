using Sonluk.Entities.FICO;
using Sonluk.IDataAccess.FICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.FICO
{
    public class FM_ElectricInvoice : IFM_ElectricInvoice
    {
        private const string SQL_Create = "FICO_FM_ElectricInvoice_Create";
        private const string SQL_Update = "FICO_FM_ElectricInvoice_Update";
        private const string SQL_ReadByParam = "FICO_FM_ElectricInvoice_ReadByParam";
        private const string SQL_ReadBySCAN = "FICO_FM_ElectricInvoice_ReadBySCAN";
        private const string SQL_Delete = "FICO_FM_ElectricInvoice_Delete";

        public int Create(FICO_FM_ElectricInvoice model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@FPDM", model.FPDM),
                                        new SqlParameter("@FPHM", model.FPHM),
                                        new SqlParameter("@KPRQ", model.KPRQ),
                                        new SqlParameter("@JYM", model.JYM),
                                        new SqlParameter("@AMOUNT", model.AMOUNT),
                                        new SqlParameter("@BXR", model.BXR),
                                        new SqlParameter("@KJND", model.KJND),
                                        new SqlParameter("@PZBH", model.PZBH),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@GS", model.GS),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(FICO_FM_ElectricInvoice model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@FPDM", model.FPDM),
                                        new SqlParameter("@FPHM", model.FPHM),
                                        new SqlParameter("@KPRQ", model.KPRQ),
                                        new SqlParameter("@JYM", model.JYM),
                                        new SqlParameter("@AMOUNT", model.AMOUNT),
                                        new SqlParameter("@PZBH", model.PZBH),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BXR", model.BXR),
                                        new SqlParameter("@KJND", model.KJND),
                                        new SqlParameter("@XGR", model.XGR),
                                         new SqlParameter("@GS", model.GS),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }


        public IList<FICO_FM_ElectricInvoice> ReadByParam(FICO_FM_ElectricInvoice model)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@FPDM", model.FPDM),
                                        new SqlParameter("@FPHM", model.FPHM),
                                        new SqlParameter("@JYM", model.JYM),
                                        new SqlParameter("@PZBH", model.PZBH),
                                        new SqlParameter("@KJND", model.KJND),
                                        new SqlParameter("@BXR", model.BXR),
                                        new SqlParameter("@BEGIN_AMOUNT", model.BEGIN_AMOUNT),
                                        new SqlParameter("@END_AMOUNT", model.END_AMOUNT),
                                        new SqlParameter("@BEGIN_CJSJ", model.BEGIN_CJSJ),
                                        new SqlParameter("@END_CJSJ", model.END_CJSJ),
                                        new SqlParameter("@BEGIN_KPRQ", model.BEGIN_KPRQ),
                                        new SqlParameter("@END_KPRQ", model.END_KPRQ),
                                        new SqlParameter("@SELECT_CJR", model.SELECT_CJR),
                                         new SqlParameter("@SELECT_GS", model.SELECT_GS),
                                        
                                   };
            IList<FICO_FM_ElectricInvoice> nodes = new List<FICO_FM_ElectricInvoice>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public int ReadBySCAN(FICO_FM_ElectricInvoice model)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@FPDM", model.FPDM),
                                        new SqlParameter("@FPHM", model.FPHM)
                                   };

            return Binning(CommandType.StoredProcedure, SQL_ReadBySCAN, parms);
        }



        public int Delete(int ID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", ID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
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
        //private int BinningForSCAN(CommandType type, string sql, SqlParameter[] parms)
        //{
        //    int ID = 0;
        //    try
        //    {
        //        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(type, sql, parms))
        //        {
        //            if (sdr.Read())
        //            {
        //                ID = Convert.ToInt32(sdr["ID"]);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw new ApplicationException(e.Message);
        //    }
        //    return ID;
        //}



        private FICO_FM_ElectricInvoice ReadDataToObj(SqlDataReader sdr)
        {
            FICO_FM_ElectricInvoice node = new FICO_FM_ElectricInvoice();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.FPDM = Convert.ToString(sdr["FPDM"]);
            node.FPHM = Convert.ToString(sdr["FPHM"]);
            node.KPRQ = Convert.ToString(sdr["KPRQ"]);
            node.JYM = Convert.ToString(sdr["JYM"]);
            node.AMOUNT = Convert.ToDecimal(sdr["AMOUNT"]);
            node.PZBH = Convert.ToString(sdr["PZBH"]);
            node.BXR = Convert.ToString(sdr["BXR"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.KJND = Convert.ToString(sdr["KJND"]);
            node.GS = Convert.ToString(sdr["GS"]);
            node.GSNAME = Convert.ToString(sdr["GSNAME"]);
            return node;
        }
    }
}
