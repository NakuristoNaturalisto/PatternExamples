using System;

/*
 * Дано:
 * Есть купли-продажи чего либо через гаранта.
 * А значит у нас есть следующие участники: Покупатель, Продавец, Гарант.
 * Безусловно, эти сущности работают друг с другом. Но все взаимоисвязи 
 * будут переданы посреднику:
*/
namespace MediatorExample
{
    /// <summary>
    /// Общий интерфейс посредников.
    /// </summary>
    public interface IMediator
    {
        void Notify(ServiceUser user, string msg);
    }

    /// <summary>
    /// Базовый класс участников сервиса.
    /// </summary>
    public abstract class ServiceUser
    {
        protected IMediator _mediator;

        public ServiceUser(IMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }

    /// <summary>
    /// Продавец.
    /// </summary>
    class Seller : ServiceUser
    {
        /// <summary>
        /// Продать предмет.
        /// </summary>
        /// <param name="price">Цена.</param>
        /// <returns></returns>
        public string SellItem()
        {
            return $"Продавец продает товар";
        }
    }

    /// <summary>
    /// Покупатель.
    /// </summary>
    class Buyer : ServiceUser
    {
        public string BuyItem()
        {
            return $"Нашелся покупатель на этот товар";
        }

        public string CheckItem()
        {
            return $"Покупатель проверил товар";
        }
    }

    /// <summary>
    /// Гарант.
    /// </summary>
    class Guarantor : ServiceUser
    {
        public string GetMoney()
        {
            return $"Гарант взял деньги покупателя до завершения сделки";
        }

        public string ReturnMoneyToBuyer()
        {
            return $"Гарант вернул деньги покупателю";
        }

        public string TransferMoneyToSeller()
        {
            return $"Гарант передал деньги продавцу";
        }
    }


    class ServiceMediator : IMediator
    {
        public Seller seller { get; set; }
        public Buyer buyer { get; set; }
        public Guarantor guarantor { get; set; }

        public void Notify(ServiceUser user, string msg)
        {
            if (user == seller)
            {
                if (msg == "sell")
                {
                    Console.WriteLine(seller.SellItem());
                }
            }

            if (user == buyer)
            {
                if (msg == "buy")
                {
                    Console.WriteLine(buyer.BuyItem());
                }

                if (msg == "check")
                {
                    Console.WriteLine(buyer.CheckItem());
                }
            }

            if (user == guarantor)
            {
                if (msg == "getMoney")
                {
                    Console.WriteLine(guarantor.GetMoney());
                }

                if (msg == "returnMoney")
                {
                    Console.WriteLine(guarantor.ReturnMoneyToBuyer());
                }

                if (msg == "transferMoney")
                {
                    Console.WriteLine(guarantor.TransferMoneyToSeller());
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceMediator mediator = new ServiceMediator();
            Seller seller = new Seller();
            Buyer buyer = new Buyer();
            Guarantor guarantor = new Guarantor();
            mediator.seller = seller;
            mediator.buyer = buyer;
            mediator.guarantor = guarantor;
            mediator.Notify(mediator.seller, "sell");
            mediator.Notify(mediator.buyer, "buy");
            mediator.Notify(mediator.guarantor, "getMoney");
            mediator.Notify(mediator.buyer, "check");
            mediator.Notify(mediator.guarantor, "transferMoney");
        }
    }
}
