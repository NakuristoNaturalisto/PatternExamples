using System;

/*
 * Реализация DI через аргумент метода (Method injection)
 * Модуль верхнего уровня ReportService - сервис для формирования отчетов
 * с ним взаимодействует клиент через абстракцию IReport
 * Модули нижниего уровня: LegalReport (юридические очтеты) и FinanceReport (бухгалтерские отчеты).
 * они же являются деталями для абстракции IReport.
 * Модуль верхнего уровня ReportService зависит от абстракции, так как как принимает
 * в свой клиентский метод абстракцию для дальнейшей реализации.
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
        public void GetReport(IReport report)
        {
            Console.WriteLine(report.GenerateReport());
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
            reportService.GetReport(financeReport);
            reportService.GetReport(legalReport);
        }
    }
}
