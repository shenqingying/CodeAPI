using Sonluk.DAFactory;
using Sonluk.Entities.API;
using Sonluk.Entities.BARCODE;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.BARCODE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using ZXing;
using ZXing.Common;

namespace Sonluk.BusinessLogic.BARCODE
{
    public class SY_CODING
    {
        private static readonly ISY_CODING _DataAccess = RMSDataAccess.CreateSY_CODING();

        public ApiReturn Create(BARCODE_SY_CODING model, string width, string height)
        {
            Byte[] RESULT = null;

            IList<BARCODE_SY_CODING> DataList = _DataAccess.ReadByParam(new BARCODE_SY_CODING());

            var query = (from c in DataList where c.PIPECODE != "" & c.BEGINNING == 0 select c).ToList();

            const string sonluk = "6911334";

            int Num = 0;
            string PIPECODE = "";
            //非导入第一次新增数据
            var QueryList = (from a in DataList select a.PIPECODE).ToList();
            if (query.Count == 0)
            {
                Num = 00000;
            }
            //正常新增
            else if (query.Count != 0)
            {
                string strCode = (from d in query select d.PIPECODE).Max();//取出当前流水码最大值
                Num = Convert.ToInt32(strCode);
            }
            do
            {
                Num++;
            } while (QueryList.Contains(Num.ToString().PadLeft(5, '0')));

            PIPECODE = Num.ToString().PadLeft(5, '0');

            //获得完整的条码
            string Code = GetBarcode(string.Format("{0}{1}", sonluk, PIPECODE));

            model.BARCODE = Code;
            model.PIPECODE = PIPECODE;

            MES_RETURN MR = new MES_RETURN();
            MR = _DataAccess.Create(model);


            if (MR.TYPE == "S")
            {
                //BarcodeWriter Writer = new BarcodeWriter();
                //Writer.Format = BarcodeFormat.EAN_13;
                //EncodingOptions options = new EncodingOptions();
                //options.Width = Convert.ToInt32(width);
                //options.Height = Convert.ToInt32(height);
                ////   options.Margin = 2;
                ////   options.PureBarcode = true;
                //Writer.Options = options;
                //Bitmap img = Writer.Write(Code);

                //MemoryStream MS = new MemoryStream();
                //img.Save(MS, ImageFormat.Bmp);

                //RESULT = new byte[MS.Length];
                //RESULT = MS.ToArray();

                //Dictionary<string, Byte[]> DC = new Dictionary<string, byte[]>();
                //DC.Add(Code, RESULT);

                //       BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                //       //b.BackColor = System.Drawing.Color.White;//图片背景颜色
                //       //b.ForeColor = System.Drawing.Color.Black;//条码颜色
                //    //   b.IncludeLabel = true;
                // //      b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                //       //b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;//code的显示位置
                //       //b.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;//图片格式
                //       //System.Drawing.Font font = new System.Drawing.Font("宋体", 12f);//字体设置
                //       //b.LabelFont = font;
                //       ////b.Height = 55;//图片高度设置(px单位)
                //       ////b.Width = 148;//图片宽度设置(px单位)
                //       //b.RotateFlipType = RotateFlipType.RotateNoneFlipNone;

                //   // Image imge = BarcodeLib.Barcode.DoEncode(BarcodeLib.TYPE.EAN13, Code,true, Color.Black, Color.White, 100, 80);

                //Image imge = b.Encode(BarcodeLib.TYPE.EAN13, Code, Color.Black, Color.White, 100, 80);

                //MyImage.EAN13 _EAN13 = new MyImage.EAN13();
                //_EAN13.Magnify = 1;
                //_EAN13.Heigth = 80;
                //_EAN13.FontSize = 25;
                //Image imge = _EAN13.GetCodeImage(Code);
                //CODE128C.Code128 _Code = new CODE128C.Code128();
                //_Code.ValueFont = new Font("宋体", 10);
                //Image imge = _Code.GetCodeImage("00169113340000030131", CODE128C.Code128.Encode.Code128C);
                //Bitmap test = new Bitmap(imge);
                //MemoryStream ms = new MemoryStream();
                //test.Save(ms, ImageFormat.Bmp);
                //RESULT = new byte[ms.Length];
                //RESULT = ms.ToArray();
                //ms.Close();

                BARCODE_SY_CODING ResultModel = new BARCODE_SY_CODING();
                ResultModel.BARCODE = Code;
                // ResultModel.IMGBYTE = RESULT;
                //   ResultModel.HTML = HtmlBarCode.getEAN13(Code, 2, 120);
                return new ApiReturn<BARCODE_SY_CODING>(ResultModel, true);
            }
            else
            {
                //return new ApiReturn<MES_RETURN>(MR, true);
                return new ApiReturn(MR);
            }
        }
        public MES_RETURN CreateByImport(List<BARCODE_SY_CODING> model)
        {
            return _DataAccess.CreateByImport(model);
        }

        public MES_RETURN Update(BARCODE_SY_CODING model)
        {
            return _DataAccess.Update(model);
        }
        public IList<BARCODE_SY_CODING> ReadByParam(BARCODE_SY_CODING model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public MES_RETURN Delete(int ID)
        {
            return _DataAccess.Delete(ID);
        }

        public string GetBarcode(string str)
        {
            int EVEN = 0;
            int ODD = 0;
            List<string> Temp_str = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                Temp_str.Add(str[i].ToString());
            }
            var Arr = Temp_str.Select<string, int>(x => Convert.ToInt32(x)).ToArray();//转换为int数组

            for (int i = 0; i < Arr.Length; i++)
            {
                if (i % 2 != 0)
                {
                    EVEN = EVEN + Arr[i];
                }
                else
                {
                    //奇数
                    ODD = ODD + Arr[i];
                }
            }

            int checkCode = 0;

            int SUM = ODD + (EVEN * 3);

            int ck = 0;
            if (SUM % 10 == 0)
            {
                ck = SUM;
            }
            else
            {
                ck = (SUM / 10 + 1) * 10;
            }
            checkCode = ck - SUM;

            return string.Format("{0}{1}", str, checkCode);
        }

    }
}
