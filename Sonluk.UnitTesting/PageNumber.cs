using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UnitTesting
{
    public class PageNumber : PdfPageEventHelper
    {
        String header;
        PdfTemplate total;
        BaseFont BF_Light = BaseFont.CreateFont(@"C:\Windows\Fonts\simsun.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

        public void setHeader(String header)
        {
            this.header = header;
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            Console.WriteLine("2");
            total = writer.DirectContent.CreateTemplate(30, 16);
            

        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            //base.OnEndPage(writer, document);

            PdfPTable pageNumber = new PdfPTable(1);
            //pageNumber.AddCell("11测试"+writer.PageNumber+","+writer.CurrentPageNumber);
            pageNumber.TotalWidth = 100f;
            PdfPCell pageIndexCell = new PdfPCell(new Paragraph("第" + writer.PageNumber.ToString() + "页/", new Font(BF_Light, 10)));
            pageIndexCell.Border = Rectangle.NO_BORDER;
            pageNumber.AddCell(pageIndexCell);
            pageNumber.WriteSelectedRows(0, -1, 437, document.PageSize.Height - 168, writer.DirectContent);
            total = writer.DirectContent.CreateTemplate(30, 16);
            Console.WriteLine(document.PageSize.Height - 168);
            ////输出页眉
            //Header = GenerateHeader(writer);
            //Header.TotalWidth = document.PageSize.Width - 20f;
            /////调用PdfTable的WriteSelectedRows方法。该方法以第一个参数作为开始行写入。
            /////第二个参数-1表示没有结束行，并且包含所写的所有行。
            /////第三个参数和第四个参数是开始写入的坐标x和y.
            //Header.WriteSelectedRows(0, -1, 10, document.PageSize.Height - 20, writer.DirectContent);

            ////输出页脚
            //Footer = GenerateFooter(writer);
            //Footer.TotalWidth = document.PageSize.Width - 20f;
            //Footer.WriteSelectedRows(0, -1, 10, document.PageSize.GetBottom(50), writer.DirectContent);
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {

            //PdfPTable pageNumber = new PdfPTable(1);
            ////pageNumber.AddCell("11测试"+writer.PageNumber+","+writer.CurrentPageNumber);
            //pageNumber.TotalWidth = 100f;
            //PdfPCell pageIndexCell = new PdfPCell(new Paragraph("共" + writer.PageNumber.ToString() + "356464页", new Font(BF_Light, 10)));
            //Console.WriteLine(writer.PageNumber.ToString());
            ////pageIndexCell.Border = Rectangle.NO_BORDER;
            //pageNumber.AddCell(pageIndexCell);
            //pageNumber.AddCell("3456436534");
            //pageNumber.WriteSelectedRows(0, -1, 437, document.PageSize.Height - 168, writer.DirectContent);

            Console.WriteLine(writer.PageNumber);
            ColumnText.ShowTextAligned(total, Element.ALIGN_LEFT,new Phrase(writer.PageNumber.ToString()), 100,100, 0);
            //total.BeginText();
            //total.SetFontAndSize(BF_Light, 10);
            //total.ShowText((writer.PageNumber - 1) + "页");
            //total.EndText();
            //total.ClosePath();//sanityCheck();  

        }
    }
}
