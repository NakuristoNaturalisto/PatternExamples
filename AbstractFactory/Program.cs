using System;

/*
 * Дано:
 * У нас есть электромеханический завод, который выпускает телефоны и ноутбуки.
 * Изделия выпускаются в двух вариациях: 
 *  1) бюджетный - который делается из более доступных материалов.
 *  2) И из дорогих материалов и комплектующих - флагманы.
 * В рамках акции "1+1" нужно организовать выпуск изделий в сочетании с их вариациями,
 * и при этом оставить возможность добававлять новые продукты в систему.
 */

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                $"Выберите набор в рамках акции 1+1:{ Environment.NewLine }" +
                $"1. Бюджетные ноутбук и телефон{ Environment.NewLine }" +
                $"2. Флагманские ноутбук и телефон{ Environment.NewLine }"
            );

            var userSelectValue = Console.ReadLine();
            GetProductSetForClient(userSelectValue);
        }

        /// <summary>
        /// Получаем набор продуктов и отправляем клиенту.
        /// </summary>
        /// <param name="userSelectValue">Какой набор выбрал пользователь.</param>
        public static void GetProductSetForClient(string userSelectValue)
        {
            if (String.IsNullOrWhiteSpace(userSelectValue))
            {
                throw new Exception("Вы ввели пустное значение");
            }

            int numSelect;
            if (!int.TryParse(userSelectValue, out numSelect))
            {
                throw new Exception("Выбранное значение не является числом.");
            }

            IAbstractPhone phone;
            IAbstractNotebook notebook;
            if (numSelect == 1)
            {
                var factory = new BudgetFactory();
                phone = factory.CreatePhone();
                notebook = factory.CreateNotebook();
            }
            else
            {
                var factory = new FlagshipFactory();
                phone = factory.CreatePhone();
                notebook = factory.CreateNotebook();
            }

            Console.WriteLine(phone.SendConcretePhoneToClient());
            Console.WriteLine(notebook.SendCocnreteNotebookToClient());
            Console.ReadKey();
        }
    }
}
