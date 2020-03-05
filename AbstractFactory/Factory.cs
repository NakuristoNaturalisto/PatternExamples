using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    /// <summary>
    /// Интерфейс асбтрактной фабрики с фабричными методами создания ноутбуков и телефонов.
    /// </summary>
    public interface IAbstractFactory
    {
        IAbstractPhone CreatePhone();

        IAbstractNotebook CreateNotebook();
    }

    /// <summary>
    /// Кокнретная фабрика, которая производит телефоны и ноутбуки бюджетной вариации.
    /// </summary>
    class BudgetFactory : IAbstractFactory
    {
        public IAbstractPhone CreatePhone()
        {
            return new ConcretePhoneBudget();
        }

        public IAbstractNotebook CreateNotebook()
        {
            return new ConcreteNotebookBudget();
        }
    }

    /// <summary>
    /// Кокнкретная фабрика, которая производит телефоны и ноутбуки флагманской вариации.
    /// </summary>
    class FlagshipFactory : IAbstractFactory
    {
        public IAbstractPhone CreatePhone()
        {
            return new ConcretePhoneFlagship();
        }

        public IAbstractNotebook CreateNotebook()
        {
            return new ConcreteNotebookFlagship();
        }
    }

    /// <summary>
    /// Базовый интерфейс отдельного продукта "Телефон" для всех вариаций.
    /// </summary>
    public interface IAbstractPhone
    {
        string SendConcretePhoneToClient();
    }

    /// <summary>
    /// Класс, отвечающий за создание кокнретного телефона из бюджетной категории.
    /// </summary>
    class ConcretePhoneBudget : IAbstractPhone
    {
        public string SendConcretePhoneToClient()
        {
            return "Клиенту успешно отправлен бюджетный смартфон!";
        }
    }

    /// <summary>
    /// Класс, отвечающий за создание кокнретного телефона из флагманской категории.
    /// </summary>
    class ConcretePhoneFlagship : IAbstractPhone
    {
        public string SendConcretePhoneToClient()
        {
            return "Клиенту успешно отправлен флагманский смартфон!";
        }
    }

    /// <summary>
    /// Базовый интерфейс отдельного продукта "Ноутбук" для всех вариаций.
    /// </summary>
    public interface IAbstractNotebook
    {
        string SendCocnreteNotebookToClient();
    }

    /// <summary>
    /// Класс, отвечающий за создание кокнретного ноутбука из бюджетной категории.
    /// </summary>
    class ConcreteNotebookBudget : IAbstractNotebook
    {
        public string SendCocnreteNotebookToClient()
        {
            return "Клиенту успешно отправлен бюджетный ноутбук!";
        }
    }

    /// <summary>
    /// Класс, отвечающий за создание кокнретного ноутбука из флагманской категории.
    /// </summary>
    class ConcreteNotebookFlagship : IAbstractNotebook
    {
        public string SendCocnreteNotebookToClient()
        {
            return "Клиенту успешно отправлен флагманский ноутбук!";
        }
    }
}
