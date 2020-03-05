using System;
using System.Collections.Generic;

/*
 * Дано:
 * Метеостанция. Служба мчс и система умного дома.
 * Метестоанция сообщает о резких изменениях погоды.
 * Мчс и системна умного дома реагируют на это.
*/

namespace ObserverExample
{
    /// <summary>
    /// Интерфейс наблюдателей (подписчиков).
    /// </summary>
    interface IObserver
    {
        void Update(Object ob);
    }

    /// <summary>
    /// Интерфейс для управления подписками издателя.
    /// </summary>
    interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    /// <summary>
    /// Метеостанция. Издатель.
    /// </summary>
    class WeatherStation : ISubject
    {
        WeatherData _data;
        private List<IObserver> _observers;
        public WeatherStation()
        {
            _observers = new List<IObserver>();
            _data = new WeatherData();
        }

        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in _observers)
            {
                o.Update(_data);
            }
        }

        public void AnalyzeWeather()
        {
            Random rnd = new Random();
            _data.Temperature = rnd.Next(-20, 20);
            _data.WindSpeed = rnd.Next(0, 15);
            Console.Write(
                $"Данные погоды: температура {_data.Temperature} град. Ветер: {_data.WindSpeed} м/с {Environment.NewLine}"
            );
            NotifyObservers();
        }
    }

    /// <summary>
    /// Данные о погоде
    /// </summary>
    public class WeatherData
    {
        public int Temperature { get; set; }
        public int WindSpeed { get; set; }
    }

    /// <summary>
    /// Система умного дома. Подписчик.
    /// </summary>
    class HomeSystem : IObserver
    {
        ISubject _weatherStation;
        public HomeSystem(ISubject weatherStation)
        {
            _weatherStation = weatherStation;
            _weatherStation.AddObserver(this);
        }

        public void Update(object ob)
        {
            WeatherData wData = (WeatherData)ob;
            if (wData.Temperature < 10)
            {
                Console.WriteLine("Дом: температура {0} град., включаю отопление", wData.Temperature);
            }

            if (wData.WindSpeed > 7)
            {
                Console.WriteLine("Дом: включить электрогенерацию за счет мельницы");
            }
        }
    }

    /// <summary>
    /// Служба МЧС. Подписчик.
    /// </summary>
    class MES : IObserver
    {
        ISubject _weatherStation;
        public MES(ISubject weatherStation)
        {
            _weatherStation = weatherStation;
            _weatherStation.AddObserver(this);
        }

        public void Update(object ob)
        {
            WeatherData wData = (WeatherData)ob;
            if (wData.Temperature < 0)
            {
                Console.WriteLine("МЧС предупраждает о гололеде на дорогах");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ws = new WeatherStation();
            var mes = new MES(ws);
            var hs = new HomeSystem(ws);
            ws.AnalyzeWeather();
        }
    }
}
