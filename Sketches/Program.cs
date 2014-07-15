using Sketches.Factory_pattern;
using Sketches.Factory_pattern.Implementations;

namespace Sketches {
    class Program {

        interface ILalala {
            string ShipFrom();
        }

        class A : ILalala {
            public string ShipFrom() {
                throw new System.NotImplementedException();
            }
        }

        static void Main(string[] args) {
            var customExcelExporterFactory = new CustomExcelExporterFactory();
            IExcelExporter excelExporter = customExcelExporterFactory.Build();
            excelExporter.WriteExcelFile();
        }
    }
}
