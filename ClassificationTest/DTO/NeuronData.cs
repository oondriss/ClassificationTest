using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationTest.DTO
{
    static class NeuronData
    {   
        static List<NeuronInstanceData> _list { get; set; }

        static NeuronData()
        {
            _list = new List<NeuronInstanceData>();
        }

        static void AddExcelRowData(double t1, double t2, double t3, bool a)
        {
            _list.Add(new NeuronInstanceData(t1, t2, t3, a));
        }

        public static void AddExcelRowData(ExcelRange range)
        {
            var rowData = range.Select(c => c.Value == null ? string.Empty : c.Value.ToString());
            var rowArr = rowData.ToArray();
            var T1 = double.Parse(rowArr[0]);
            var T2 = double.Parse(rowArr[1]);
            var T3 = double.Parse(rowArr[2]);
            var Alarm = rowArr[4] == "Y" ? true : false;
            AddExcelRowData(T1, T2, T3, Alarm);
        }

        public static double[][] GetInputMatrix()
        {
            return _list.Select(i => new double[3] { i.T1, i.T2, i.T3 }).ToArray();
        }
        public static double[][] GetOutputMatrix()
        {
            return _list.Select(i => new double[1] { i.A }).ToArray();
        }
    }
}
