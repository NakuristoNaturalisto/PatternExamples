using System;

/*
 * Дано:
 * Публикуется какой-то контент на сайте. Помимо сайта, публикацию можно дублировать в соц. сети.
 * В зависимости от тематики и контента публикации, редактор решает - в какие соц-сети ее запостить.
 * Нужно реализовать различные обертки для публикации, чтобы отправлять ее в различные соц. сети.
*/

namespace DecoratorExample
{
    /// <summary>
    /// Публикация (базовый компонент).
    /// </summary>
    abstract class Publication
    {
        public Publication(string t, string d)
        {
            this.Title = t;
            this.Description = d;
        }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public abstract string Publish();
    }

    /// <summary>
    /// Публикация по типу "Новость" (конкретный компонент). 
    /// </summary>
    class News : Publication
    {
        public News() : base("Новость", "Описание новости")
        { }

        public override string Publish()
        {
            return "Новость опубликована";
        }
    }

    /// <summary>
    /// Публикация по типу "Статья" (конкретный компонент).
    /// </summary>
    class Article : Publication
    {
        public Article() : base("Статья", "Описание статьи")
        { }

        public override string Publish()
        {
            return "Статья опубликована";
        }
    }

    /// <summary>
    /// Базовый декоратор.
    /// </summary>
    abstract class PublicationDecorator : Publication
    {
        protected Publication _publication;
        public PublicationDecorator(string t, string d, Publication publication) : base(t, d)
        {
            this._publication = publication;
        }

        public override string Publish()
        {
            if (this._publication != null)
            {
                return this._publication.Publish();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    /// <summary>
    /// Декоратор для публикации в ВК.
    /// </summary>
    class VKPublication : PublicationDecorator
    {
        public VKPublication(Publication p)
            : base(p.Title + " для вк", p.Description + " для вк", p)
        { }

        public override string Publish()
        {
            return _publication.Publish() + " в вконтакте";
        }
    }

    /// <summary>
    /// Декоратор для публикации в ФБ.
    /// </summary>
    class FBPublication : PublicationDecorator
    {
        public FBPublication(Publication p)
            : base(p.Title + " для фб", p.Description + " для фб", p)
        { }

        public override string Publish()
        {
            return _publication.Publish() + " в фейсбук";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Publication news = new News();
            news = new VKPublication(news);
            Console.WriteLine(news.Publish());

            Publication article = new Article();
            article = new FBPublication(article);
            Console.WriteLine(article.Publish());

            Publication polypublication = new News();
            polypublication = new VKPublication(polypublication);
            polypublication = new FBPublication(polypublication);
            Console.WriteLine(polypublication.Publish());
        }
    }
}
