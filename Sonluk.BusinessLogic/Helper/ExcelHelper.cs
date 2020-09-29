using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using Sonluk.Entities.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace Sonluk.BusinessLogic.Helper
{
    public class ExcelHelper
    {
        public ApiReturn DataToExcel(string path, List<string> data, List<string> dataName, Dictionary<int, string> title, string sheetTitle = "sheet1", Func<string, int, int, string, string> dataTransform = null, char sep = '|', char sepChild = ',')
        {
            try
            {
                //获取基本信息
                int rowNumTitle = title.Count; //标题行
                int rowNumData = data.Count;   //数据行
                int colNumMax = 0;             //最大列数
                foreach (var item in title)
                {
                    int num = item.Value.Split(sep).Length;
                    if (colNumMax < num) colNumMax = num;
                }

                //表初始化
                IWorkbook mworkbook = new HSSFWorkbook();
                ISheet msheet = mworkbook.CreateSheet(sheetTitle);

                //标题栏样式
                ICellStyle style = mworkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
                style.WrapText = true;

                //数据栏样式
                ICellStyle styleA = mworkbook.CreateCellStyle();
                styleA.Alignment = HorizontalAlignment.Center;
                styleA.VerticalAlignment = VerticalAlignment.Center;
                styleA.BorderBottom = BorderStyle.Thin;
                styleA.BorderLeft = BorderStyle.Thin;
                styleA.BorderRight = BorderStyle.Thin;
                styleA.BorderTop = BorderStyle.Thin;

                //单元格初始化
                for (int i = 0; i < rowNumTitle; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    row.HeightInPoints = 30;
                    for (int j = 0; j < colNumMax; j++) row.CreateCell(j).CellStyle = style;
                }
                for (int i = rowNumTitle; i < rowNumData + rowNumTitle; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < colNumMax; j++) row.CreateCell(j).CellStyle = styleA;
                }

                //设置列宽
                //msheet.SetColumnWidth(12, 15 * 256);

                //写入标题
                foreach (var item in title)
                {
                    string[] titleChild = item.Value.Split(sep);
                    int startCol = 0;
                    for (int titleCol = 0; titleCol < titleChild.Length; titleCol++)
                    {
                        string[] titleChildInfo = titleChild[titleCol].Split(sepChild);
                        if (titleChildInfo.Length == 1 || titleChildInfo.Length == 2 || titleChildInfo.Length == 3)
                        {
                            int colspan = titleChildInfo.Length > 1 ? Convert.ToInt32(titleChildInfo[1]) : 1;
                            int rowspan = titleChildInfo.Length == 3 ? Convert.ToInt32(titleChildInfo[2]) : 1;
                            msheet.GetRow(item.Key).GetCell(startCol).SetCellValue(titleChildInfo[0]);
                            msheet.AddMergedRegion(new CellRangeAddress(item.Key, item.Key + rowspan - 1, startCol, startCol + colspan - 1));
                            startCol = startCol + colspan;
                        }
                        else
                        {
                            return new ApiReturn(false, "标题格式错误！");
                        }
                    }
                }

                //写入数据
                for (int i = rowNumTitle; i < rowNumData + rowNumTitle; i++)
                {
                    Type myData = data[i - rowNumTitle].GetType();
                    for (int j = 0; j < dataName.Count; j++)
                    {
                        foreach (PropertyInfo pi in myData.GetProperties())
                        {
                            if (pi.Name == dataName[j])
                            {
                                string dataIn = dataTransform(pi.GetValue(data[i - rowNumTitle], null).ToString(), i, j, pi.Name);
                                msheet.GetRow(i).GetCell(j).SetCellValue(dataIn);
                                break;
                            }
                        }
                    }
                }

                //保存Excel
                string filePath = path + "Temp/File/DataToExcel" + DateTime.Now.ToFileTime() + ".xls";
                using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    mworkbook.Write(file);
                }
                return new ApiReturn<string>(filePath, true, "已保存至临时文件夹");
            }
            catch (Exception e)
            {
                return new ApiReturn(false, "临时文件保存失败：" + e.Message);
            }
        }
        /// <summary>
        /// Excel转换到DataTable
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public DataTable ExcelToDataTable(string fileName, bool isFirstRowColumn)
        {
            FileStream fs = null;
            ISheet sheet = null;
            IWorkbook workbook = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                //sheet = workbook.GetSheet();

                int SheetCount = workbook.NumberOfSheets;

                for (int x = 0; x < SheetCount; x++)
                {
                    sheet = workbook.GetSheetAt(x);

                    if (sheet != null)
                    {
                        IRow firstRow = sheet.GetRow(0);
                        int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                        if (isFirstRowColumn)
                        {
                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                            {
                                ICell cell = firstRow.GetCell(i);
                                if (cell != null)
                                {
                                    string cellValue = cell.StringCellValue.Trim();
                                    if (cellValue != null)
                                    {
                                        DataColumn column = new DataColumn(cellValue);
                                        data.Columns.Add(column);
                                    }
                                }
                            }
                            startRow = sheet.FirstRowNum + 1;
                        }
                        else
                        {
                            startRow = sheet.FirstRowNum;
                        }

                        //最后一列的标号
                        int rowCount = sheet.LastRowNum;
                        for (int i = startRow; i <= rowCount; ++i)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null) continue; //没有数据的行默认是""　　　　　　

                            DataRow dataRow = data.NewRow();
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {
                                //if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是""
                                //    dataRow[j] = row.GetCell(j).ToString();
                                ICell cell = row.GetCell(j);

                                if (cell != null)
                                {
                                    string cellValue = "";
                                    if (cell.CellType == CellType.Numeric)
                                    {
                                        short format = cell.CellStyle.DataFormat;
                                        if (format == 14)
                                        {
                                            cellValue = cell.DateCellValue.ToString("yyyy-MM-dd");
                                        }
                                        else
                                        {
                                            cellValue = row.GetCell(j).ToString();
                                        }
                                    }
                                    else
                                    {
                                        cellValue = row.GetCell(j).ToString();
                                    }
                                    dataRow[j] = cellValue;
                                }
                            }
                            data.Rows.Add(dataRow);
                        }
                    }
                }
                return data;
            }
            catch //(Exception e)
            {
                // throw;
                //MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }
    }
}
