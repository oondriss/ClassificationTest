using ClassificationTest.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TemperatureDataVW.DTO;

namespace ClassificationTest.Managers
{
    class ExcelParser
    {
        string _fileName;
        double[][] input;
        double[][] output;

        //List<VwTempData> dataList = new List<VwTempData>();


        public ExcelParser(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("param cannot be empty string", nameof(fileName));
            }

            _fileName = fileName;
        }

        public void ParseSourceData()
        {
            var i = 1;
            var cnt = 0;
            using (ExcelPackage sourceFile = new ExcelPackage(new FileInfo(_fileName)))
            {
                var myWorksheet = sourceFile.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;
                cnt = totalRows;

                var sb = new StringBuilder(); //this is your your data
                for (int rowNum = 2; rowNum <= totalRows; rowNum++) //select starting row here
                {
                    var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns];

                    NeuronData.AddExcelRowData(row);
                    Console.WriteLine($"parsing: - {i}/{cnt}");
                    i++;
                }
            }
        }
    }
}