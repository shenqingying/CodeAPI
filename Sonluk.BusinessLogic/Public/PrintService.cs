using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.Public
{
    public class PrintService
    {
        private static PrintDocument fPrintDocument = new PrintDocument();
        public string  Print()
        {
            string msg = "成功";
            PrintDocument printDocument = new PrintDocument();
            //指定打印机
            printDocument.PrinterSettings.PrinterName = "\\\\192.168.0.77\\hp 1108";
            //设置页边距
            printDocument.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            printDocument.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            printDocument.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            printDocument.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            //设置尺寸大小，如不设置默认是A4纸
            //A4纸的尺寸是210mm×297mm，
            //当你设定的分辨率是72像素/英寸时，A4纸的尺寸的图像的像素是595×842
            //当你设定的分辨率是150像素/英寸时，A4纸的尺寸的图像的像素是1240×1754
            //当你设定的分辨率是300像素/英寸时，A4纸的尺寸的图像的像素是2479×3508，
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 595, 842);

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            try
            {
                printDocument.Print();
            }
            catch (InvalidPrinterException e)
            {
                msg = e.Message;
                return msg;
            }
            finally
            {
                printDocument.Dispose();
            }
            return msg;
        }
        public  List<String> GetLocalPrinters()
        {
            List<String> fPrinters = new List<String>();
            fPrinters.Add(DefaultPrinter()); //默认打印机始终出现在列表的第一项
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                {
                    fPrinters.Add(fPrinterName);
                }
            }
            return fPrinters;
        }
        
        //获取本机默认打印机名称
        public static String DefaultPrinter()
        {
            return fPrintDocument.PrinterSettings.PrinterName;
        }
        //打印方法
        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var printContent = "后台Api打印";
            var printFont = new Font("宋体", 12, System.Drawing.FontStyle.Regular);
            var printColor = System.Drawing.Brushes.Black;

            var pointY = 10f;
            //画字符串
            e.Graphics.DrawString(printContent, printFont, printColor, 10f, pointY);

            //如何打印带粗体,倾斜,字体中带横线,下划线的字符串,设置字体的FontStyle(粗体,倾斜,字体中带横线,下划线)
            printFont = new Font("宋体", 12, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            e.Graphics.DrawString(printContent, printFont, printColor, 10f, pointY += 20f);
            printFont = new Font("宋体", 12, System.Drawing.FontStyle.Regular);

            //画图像
            //e.Graphics.DrawImage(Image, 10, 50);

            //设置坐标系缩放
            //设置打印坐标系X值为原值的0.6倍打印
            e.Graphics.ScaleTransform(0.6f, 1.0f);
            e.Graphics.DrawString(printContent, printFont, printColor, 10f, pointY += 20f);
            //恢复坐标系缩放
            e.Graphics.ScaleTransform(1 / 0.6f, 1.0f);
            e.Graphics.DrawString(printContent, printFont, printColor, 10f, pointY += 20f);

            //绘画的设置保存与恢复
            var status = e.Graphics.Save();
            e.Graphics.ScaleTransform(0.6f, 1.0f);
            e.Graphics.DrawString(printContent, printFont, printColor, 10f, pointY += 20f);
            e.Graphics.Restore(status);
            e.Graphics.DrawString(printContent, printFont, printColor, 10f, pointY += 20f);


            //如果打印还有下一页，将HasMorePages值置为true;
            e.HasMorePages = false;
        }
    }
}
