using System;

/*
 * Дано:
 * Есть любитель-астроном, который наблюдает за звездами.
 * Он может получать данные в световом диапозоне со своего телескопа.
 * Предположим, что он подключился к местной обсерватории,
 * и теперь может наблдать свезду еще и в радиодиапозоне. 
 * Для этого его класс нужно адаптировать.
*/

namespace AdapterExample
{
    /// <summary>
    /// Оборудование.
    /// </summary>
    interface IEquipment
    {
        string GetData();
    }

    /// <summary>
    /// Телескоп.
    /// </summary>
    class Telescope : IEquipment
    {
        public string GetData()
        {
            return "Получены данные с телескопа";
        }
    }

    /// <summary>
    /// Астроном. Взаимодействует с целевым оборудованием.
    /// </summary>
    class Astronomer
    {
        public string WatchUniverse(IEquipment equipment)
        {
            return equipment.GetData();
        }
    }

    /// <summary>
    /// Радиотелескоп. Класс для адаптирования.
    /// </summary>
    class RadioTelescope
    {
        public string GetDataInRadioRange()
        {
            return "Полученны данные в радиодиапозоне";
        }
    }

    /// <summary>
    /// Адаптер радиотелескопа к целевому оборудованию.
    /// </summary>
    class ObserverAdapter : IEquipment
    {
        private readonly RadioTelescope _radioTelescope;
        public ObserverAdapter(RadioTelescope radioTelescope)
        {
            this._radioTelescope = radioTelescope;
        }

        public string GetData()
        {
            return _radioTelescope.GetDataInRadioRange();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var spacer = new Astronomer();
            var telescope = new Telescope();

            // Получили стандартные данные.
            Console.WriteLine(spacer.WatchUniverse(telescope));

            // Теперь нужно поолучить в ридиодиапозоне.
            var radioTelescope = new RadioTelescope();
            IEquipment radioTelescopeToEquipment = new ObserverAdapter(radioTelescope);
            Console.WriteLine(spacer.WatchUniverse(radioTelescopeToEquipment));
        }
    }
}
