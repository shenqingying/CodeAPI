using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using ZXing.QrCode;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Sonluk.DAFactory;
using Sonluk.Entities.BC;
using Sonluk.Entities.LE;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.BC;
using Sonluk.IDataAccess.LE.TRA;
using Sonluk.Entities.MES;
using Sonluk.Entities.API;

namespace Sonluk.BusinessLogic.BC
{
    public class BarCode
    {
        private static readonly IBarCode detaAccess = BCDataAccess.CreateBarCode();
        private static readonly IConsignmentNote cnAccess = LETRADataAccess.CreateConsignmentNote();

        EncodingOptions options = null;
        BarcodeWriter writer = null;

        //private BitMatrix deleteWhite(BitMatrix matrix)
        //{
        //    int[] rec = matrix.getEnclosingRectangle();
        //    int resWidth = rec[2] + 1;
        //    int resHeight = rec[3] + 1;

        //    BitMatrix resMatrix = new BitMatrix(resWidth, resHeight);
        //    resMatrix.clear();
        //    for (int i = 0; i < resWidth; i++)
        //    {
        //        for (int j = 0; j < resHeight; j++)
        //        {
        //            if (matrix[i + rec[0], j + rec[1]])
        //                resMatrix[i, j] = true;
        //        }
        //    }
        //    return resMatrix;
        //}

        //public Byte[] CreateBarCode(string code, string format, int width, int height, int pure)
        //{
        //    Byte[] ret = null;

        //    options = new QrCodeEncodingOptions
        //    {
        //        DisableECI = true,
        //        CharacterSet = "UTF-8",
        //        Width = width,
        //        Height = height
        //    };
        //    if (pure == 1)
        //        options.PureBarcode = true;
        //    else
        //        options.PureBarcode = false;

        //    writer = new BarcodeWriter();
        //    switch (format)
        //    {
        //        case "CODE128":
        //            writer.Format = BarcodeFormat.CODE_128; break;
        //        case "QRCODE":
        //            writer.Format = BarcodeFormat.QR_CODE; break;
        //        case "PDF417":
        //            writer.Format = BarcodeFormat.PDF_417; break;
        //    }
        //    writer.Options = options;
        //    writer.Options.Margin = 0;

        //    BitMatrix byteMatrix = writer.Encode(code);
        //    byteMatrix = deleteWhite(byteMatrix);//删除白边
        //    Bitmap bm = byteMatrix.ToBitmap();

        //    MemoryStream ms = new MemoryStream();
        //    ImageCodecInfo[] inf = ImageCodecInfo.GetImageEncoders();
        //    EncoderParameters eps = new EncoderParameters(1);
        //    System.Drawing.Imaging.Encoder ec = System.Drawing.Imaging.Encoder.ColorDepth;
        //    EncoderParameter ep = new EncoderParameter(ec, 80);
        //    eps.Param[0] = ep;
        //    bm.Save(ms, inf.First(info => info.MimeType == "image/bmp"), eps);
        //    ret = new byte[ms.Length];
        //    ret = ms.ToArray();
        //    return ret;

        //}

        public ApiReturn ReadBarCode(byte[] img)
        {
            if (img == null) return new ApiReturn(false, Msg.Code.EmptyError);
            BarcodeReader reader = new BarcodeReader();
            Bitmap bmp;
            try
            {
                using (Stream stream = new MemoryStream(img))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    bmp = new Bitmap(stream);
                }
            }
            catch(Exception e)
            {
                return new ApiReturn(false,Msg.Code.FileAccessError,e.Message);
            }
            Result result = new BarcodeReader().Decode(bmp);
            if(result == null) return new ApiReturn(false, Msg.Code.EmptyError);
            return new ApiReturn<string>(result.ToString(),true);
        }

        public Byte[] CreateBarCode(string code, string format, int width, int height, int pure)
        {
            Byte[] ret = null;

            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = width,
                Height = height,
                Margin = 1
            };
            if (pure == 1)
                options.PureBarcode = true;
            else
                options.PureBarcode = false;

            writer = new BarcodeWriter();
            switch (format)
            {
                case "CODE128":
                    writer.Format = BarcodeFormat.CODE_128;
                    break;
                case "QRCODE":
                    writer.Format = BarcodeFormat.QR_CODE;
                    break;
                case "PDF417":
                    writer.Format = BarcodeFormat.PDF_417; break;
            }

            writer.Options = options;

            Bitmap bm = writer.Write(code);

            MemoryStream ms = new MemoryStream();
            bm.Save(ms, ImageFormat.Bmp);
            ret = new byte[ms.Length];
            ret = ms.ToArray();

            //MemoryStream ms = new MemoryStream();
            //ImageCodecInfo[] inf = ImageCodecInfo.GetImageEncoders();
            //EncoderParameters eps = new EncoderParameters(1);
            //System.Drawing.Imaging.Encoder ec = System.Drawing.Imaging.Encoder.ColorDepth;
            //EncoderParameter ep = new EncoderParameter(ec, 80);
            //eps.Param[0] = ep;
            //bm.Save(ms, inf.First(info => info.MimeType == "image/bmp"), eps);
            //ret = new byte[ms.Length];
            //ret = ms.ToArray();
            return ret;

        }

        public string ZBCFUN_TBM_ZFTH(string srwlm, string tgwlm, string fcode)
        {
            return detaAccess.ZBCFUN_TBM_ZFTH(srwlm, tgwlm, fcode);
        }

        public ZSL_BCS007 ZBCFUN_MAT_GET(string matnr)
        {
            return detaAccess.ZBCFUN_MAT_GET(matnr, "", "");
        }

        public PickingtaskInfo ZBCFUN_CKGDP_DISPLAY(string IV_CJRQ, string IV_LGNUM)
        {
            return detaAccess.ZBCFUN_CKGDP_DISPLAY(IV_CJRQ, IV_LGNUM);
        }

        ///// <summary>
        ///// 判断是否是流通装产品
        ///// </summary>
        ///// <param name="matnr"></param>
        ///// <returns></returns>
        //public bool SFLTBS(string matnr)
        //{
        //    bool rtn;
        //    ZSL_BCS007 l_bsc007 = detaAccess.ZBCFUN_MAT_GET(matnr, "", "");

        //    rtn = false;
        //    if (l_bsc007.Zltbs == "Y")
        //        rtn = true;
        //    return rtn;
        //}

        public IList<ZSL_BCS107> ZBCFUN_LTPM_READ(string IV_LGNUM, string IV_JPD, string IV_CJRQ_S, string IV_CJRQ_E, string IV_VBELN)
        {
            return detaAccess.ZBCFUN_LTPM_READ(IV_LGNUM, IV_JPD, IV_CJRQ_S, IV_CJRQ_E, IV_VBELN);
        }

        /// <summary>
        /// 取喷码打印清单
        /// </summary>
        /// <param name="IV_LGNUM"></param>
        /// <param name="IV_JPD"></param>
        /// <param name="IV_CJRQ_S"></param>
        /// <param name="IV_CJRQ_E"></param>
        /// <param name="IV_VBELN"></param>
        /// <returns></returns>
        public IList<ZSL_BCS107> PickingListREAD(string IV_LGNUM, string IV_JPD, string IV_CJRQ_S, string IV_CJRQ_E, string IV_VBELN)
        {
            string old_jpd = "";
            List<ZSL_BCS107> plist = new List<ZSL_BCS107>();
            List<ZSL_BCS107> nodes = detaAccess.ZBCFUN_LTPM_READ(IV_LGNUM, IV_JPD, IV_CJRQ_S, IV_CJRQ_E, IV_VBELN).ToList();

            foreach (ZSL_BCS107 node in nodes)
            {
                if (!(node.Jpd == old_jpd))
                {
                    old_jpd = node.Jpd;

                    ZSL_BCS107 newnode = new ZSL_BCS107();
                    newnode.Jpd = node.Jpd;
                    newnode.Kunnr = node.Kunnr;
                    newnode.Sdfmc = node.Sdfmc;
                    newnode.Sdfdz = node.Sdfdz;

                    ////根据交货单号取对应的托运单
                    //CNInfo keywords = new CNInfo();

                    //keywords.Carrier = new CompanyInfo();
                    //keywords.Carrier.ID = 0;
                    //keywords.Destination.ID = 0;
                    //keywords.SerialNumber = "";
                    //keywords.Number = "";
                    //keywords.Date = "";
                    //keywords.DateEnd = "";
                    //keywords.DeliveryDate = "";
                    //keywords.DeliveryDateEnd = "";
                    //keywords.Delivery = node.Vbeln;
                    //keywords.Receiver = new CompanyInfo();
                    //keywords.Receiver.Name = "";
                    //keywords.Receiver.Contact = "";
                    //keywords.Receiver.Cellphone = "";
                    //keywords.Receiver.Telephone = "";
                    //keywords.Receiver.Address = "";
                    //keywords.Instruction = "";
                    //keywords.Remark = "";
                    //keywords.Status = 0;

                    //List<CNInfo> cnnodes = cnAccess.Read(keywords).ToList();
                    //foreach (CNInfo cnnode in cnnodes)
                    //{
                    //    newnode.Lxfs = cnnode.PrintTxt;
                    //    newnode.Ywc = cnnode.SerialNumber;
                    //}
                    node.Vbeln = Convert.ToInt32(node.Vbeln).ToString();
                    List<CNDeliveryInfo> cndnodes = cnAccess.ReadCNDelivery(node.Vbeln).ToList();
                    foreach (CNDeliveryInfo cndnode in cndnodes)
                    {
                        CNInfo cn = cnAccess.Read(cndnode.TYDID);
                        newnode.Lxfs = cn.PrintTxt;
                        newnode.Ywc = cn.SerialNumber;
                    }

                    plist.Add(newnode);

                }
            }

            return plist;
        }

        public TrackInfo ZBCFUN_WLZS_READ(string IV_WLM)
        {
            TrackInfo ti = detaAccess.ZBCFUN_WLZS_READ(IV_WLM);

            return ti;
        }

        public RktjInfo ZBCFUN_RKTJ_READ(string IV_START, string IV_END)
        {
            RktjInfo ti = detaAccess.ZBCFUN_RKTJ_READ(IV_START, IV_END);

            return ti;
        }

        public DeliveryNoteInfo ZSD_JH_READ(string I_VBELN, string I_UNAME)
        {
            DeliveryNoteInfo ti = detaAccess.ZSD_JH_READ(I_VBELN, I_UNAME);

            return ti;
        }


        public SalesOrderInfo ZSD_DD_READ(string I_VBELN, string I_UNAME)
        {
            SalesOrderInfo ti = detaAccess.ZSD_DD_READ(I_VBELN, I_UNAME);

            return ti;
        }

        public CKInfo ZSD_CK_READ(string I_START, string I_END, string I_UNAME)
        {
            CKInfo ti = detaAccess.ZSD_CK_READ(I_START, I_END, I_UNAME);

            return ti;
        }

        public TpmInfo ZBCFUN_TPM_READ(string IV_TPM)
        {
            TpmInfo ti = detaAccess.ZBCFUN_TPM_READ(IV_TPM);

            return ti;
        }

        public GdInfo ZBCFUN_GD_READ(string IV_GD)
        {
            GdInfo ti = detaAccess.ZBCFUN_GD_READ(IV_GD);

            return ti;
        }
        public MODEL_ZBCFUN_CUS_GET GET_ZBCFUN_CUS_GET()
        {
            return detaAccess.GET_ZBCFUN_CUS_GET();
        }
        public MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET(string IV_DATE, string IV_SYS)
        {
            return detaAccess.GET_ZBCFUN_DLV_GET(IV_DATE, IV_SYS);
        }

        public MODEL_ZBCFUN_MAT_GET GET_ZBCFUN_MAT_GET(string IV_DATUM, string IV_MTART, string IV_MATNR, string IV_ZSBS)
        {
            return detaAccess.GET_ZBCFUN_MAT_GET(IV_DATUM, IV_MTART, IV_MATNR, IV_ZSBS);
        }
        public MODEL_ZBCFUN_ORT_GET GET_ZBCFUN_ORT_GET()
        {
            return detaAccess.GET_ZBCFUN_ORT_GET();
        }
        public MODEL_ZBCFUN_TM_READ GET_ZBCFUN_TM_READ(string IV_AUFNR, string IV_KZBEW)
        {
            return detaAccess.GET_ZBCFUN_TM_READ(IV_AUFNR, IV_KZBEW);
        }
        public MODEL_ZBCFUN_THLOG_READ GET_ZBCFUN_THLOG_READ()
        {
            return detaAccess.GET_ZBCFUN_THLOG_READ();
        }
        public MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET2(string KHmodeldata)
        {
            return detaAccess.GET_ZBCFUN_DLV_GET2(KHmodeldata);
        }
        public MODEL_ZBCFUN_POITEM_READ GET_ZBCFUN_POITEM_READ(string IV_EBELN, string IV_EBELP)
        {
            return detaAccess.GET_ZBCFUN_POITEM_READ(IV_EBELN, IV_EBELP);
        }
        public ZSL_BCST100 GET_ZBCFUN_PO_RECEIPT(string IV_CKDJH, string IV_KZBEW)
        {
            return detaAccess.GET_ZBCFUN_PO_RECEIPT(IV_CKDJH, IV_KZBEW);
        }
        public MODEL_ZBCFUN_JHD_READ JHD_READ(string VBELN)
        {
            return detaAccess.JHD_READ(VBELN);
        }
        public MES_RETURN JHD_UPDATE(List<ZSL_BCT110> model)
        {
            return detaAccess.JHD_UPDATE(model);
        }
        public MODEL_ZBCFUN_JHZ_READ JHZ_READ(MODEL_ZBCFUN_JHZ_READ model)
        {
            return detaAccess.JHZ_READ(model);
        }
    }
}
