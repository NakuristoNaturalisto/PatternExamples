using System;

/*
 * Реализация DI через свойство класса (Setter injection)
 * Модуль верхнего уровня ReportService - сервис для формирования отчетов
 * с ним взаимодействует клиент через абстракцию IReport
 * Модули нижниего уровня: LegalReport (юридические очтеты) и FinanceReport (бухгалтерские отчеты).
 * они же являются деталями для абстракции IReport.
 * Модуль верхнего уровня ReportService зависит от абстракции, так как имеет поле абстракции и устанавливает его через метод.
 * А потом реализует метод через абстракцию.
 * Модули нижнего уровня так же зависят от абстракции, наследуя интерфейс и реализуя его методы.
*/

namespace IoCDIExample1
{
    /// <summary>
    /// Сервис для формирования отчетов. Модуль верхнего уровня.
    /// </summary>
    class ReportService
    {
        private IReport _report;

        public void SetReport(IReport report)
        {
            this._report = report;
        }

        public void GetReport()
        {
            Console.WriteLine(_report.GenerateReport());
        }
    }

    /// <summary>
    /// Интерфейс отчетов (абстракция).
    /// </summary>
    interface IReport
    {
        public string GenerateReport();
    }

    /// <summary>
    /// Юридический отчет. Модуль нижнего уровня
    /// </summary>
    class LegalReport : IReport
    {
        public string GenerateReport()
        {
            return "Получен сформированный юридический отчет";
        }
    }

    /// <summary>
    /// Финансовый отчет из бухгалтерии. Модуль нижнего уровня
    /// </summary>
    class FinanceReport : IReport
    {
        public string GenerateReport()
        {
            return "Получен сформированный бухгалтерский отчет";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IReport financeReport = new FinanceReport();
            IReport legalReport = new LegalReport();
            ReportService reportService = new ReportService();
            reportService.SetReport(financeReport);
            reportService.GetReport();
            reportService.SetReport(legalReport);
            reportService.GetReport();
        }
    }
}
