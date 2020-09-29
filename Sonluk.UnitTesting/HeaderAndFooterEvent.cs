﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UnitTesting
{
    public class HeaderAndFooterEvent : PdfPageEventHelper
    {
        public static PdfTemplate tpl = null;//模版
        public static bool PAGE_NUMBER = true;//为True时就生成 页眉和页脚

        iTextSharp.text.Font font = BaseFontAndSize("黑体", 10, Font.NORMAL, BaseColor.BLACK);


        //重写 关闭一个页面时
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            //if (PAGE_NUMBER)
            //{
            //    Phrase header = new Phrase("PDF测试生成页眉分析报告", font);

            //    Phrase footer = new Phrase("第" + (writer.PageNumber - 1) + "页/共     页", font);
            //    PdfContentByte cb = writer.DirectContent;

            //    //模版 显示总共页数
            //    cb.AddTemplate(tpl, document.Right - 54 + document.LeftMargin, document.Bottom - 8);//调节模版显示的位置

            //    //页眉显示的位置
            //    ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER, header,
            //           document.Right - 140 + document.LeftMargin, document.Top + 10, 0);

            //    //页脚显示的位置
            //    ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER, footer,
            //           document.Right - 60 + document.LeftMargin, document.Bottom - 10, 0);
            //}

            PdfPTable pageNumber = new PdfPTable(1);
            //pageNumber.AddCell("11测试"+writer.PageNumber+","+writer.CurrentPageNumber);
            pageNumber.TotalWidth = 100f;
            pageNumber.AddCell("HelloWorld");
            pageNumber.WriteSelectedRows(0, -1, 100, 100, writer.DirectContent);
        }

        //重写 打开一个新页面时
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            if (PAGE_NUMBER)
            {
                writer.PageCount = writer.PageNumber - 1;
            }
        }
        //关闭PDF文档时发生该事件
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            //BaseFont bf = BaseFont.CreateFont(@"c:\windows\fonts\SIMYOU.TTF", BaseFont.IDENTITY_H, false); //调用的字体
            //tpl.BeginText();
            //tpl.SetFontAndSize(bf, 16);//生成的模版的字体、颜色
            //tpl.ShowText((writer.PageNumber - 2).ToString());//模版显示的内容
            //tpl.EndText();
            //tpl.ClosePath();
        }
        //定义字体 颜色
        public static Font BaseFontAndSize(string font_name, int size, int style, BaseColor baseColor)
        {
            BaseFont baseFont;
            //BaseFont.AddToResourceSearch("iTextAsian.dll");
            //BaseFont.AddToResourceSearch("iTextAsianCmaps.dll");
            Font font = null;
            string file_name = "";
            int fontStyle;
            switch (font_name)
            {
                case "黑体":
                    file_name = "SIMHEI.TTF";
                    break;
                case "华文中宋":
                    file_name = "STZHONGS.TTF";
                    break;
                case "宋体":
                    file_name = "SIMYOU.TTF";
                    break;
                default:
                    file_name = "SIMYOU.TTF";
                    break;
            }
            baseFont = BaseFont.CreateFont(@"c:/windows/fonts/" + file_name, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);//字体：黑体 
            if (style < -1)
            {
                fontStyle = Font.NORMAL;
            }
            else
            {
                fontStyle = style;
            }
            font = new Font(baseFont, size, fontStyle, baseColor);
            return font;
        }

        //定义输出文本
        public static Paragraph InsertTitleContent(string text)
        {

            iTextSharp.text.Font font = BaseFontAndSize("华文中宋", 16, Font.BOLD, BaseColor.BLACK);

            //BaseFont bfSun = BaseFont.CreateFont(@"c:\windows\fonts\STZHONGS.TTF", BaseFont.IDENTITY_H, false); //调用的字体
            //Font font = new Font(bfSun, 15);

            Paragraph paragraph = new Paragraph(text, font);//新建一行
            paragraph.Alignment = Element.ALIGN_CENTER;//居中
            paragraph.SpacingBefore = 5;
            paragraph.SpacingAfter = 5;
            paragraph.SetLeading(1, 2);//每行间的间隔
            return paragraph;
        }

    }
}
