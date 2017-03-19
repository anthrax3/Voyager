using CMS.Core.Components;
using CMS.Core.DB;
using CMS.Core.Services.Messages;
using ComArticles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComArticles.Services
{
    internal class ArticlesService : IArticlesService
    {
        IDatabaseContext db = null;
        IMessagesService messagesService = null;

        public ArticlesService(IDatabaseContext db, IMessagesService messagesService)
        {
            this.db = db;
            this.messagesService = messagesService;
        }

        public bool ChangeArticleState(string alias, bool published)
        {
            var article = db.Set<ArticleModel>().FirstOrDefault(p => p.Alias == alias);
            if (article == null)
                return false;
            article.Published = published;
            db.Save();

            return true;
        }

        public bool Exist(string alias)
        {
            return db.Set<ArticleModel>().Any(p => p.Alias == alias);
        }

        public List<ArticleModel> GetAllArticles()
        {
            var message = new Message()
            {
                Receiver = "ComCategories",
                SendTime = DateTime.Now,
                Value = "hello"
            };

            var test = messagesService.RequestData(message);
            return db.Set<ArticleModel>().ToList();
        }

        public bool RemoveArticle(String alias)
        {
            var article = db.Set<ArticleModel>().FirstOrDefault(p => p.Alias == alias);
            if (article == null)
                return false;

            db.Set<ArticleModel>().Remove(article);
            db.Save();

            return true;
        }

        public ArticleModel GetArticle(String alias)
        {
            return db.Set<ArticleModel>().FirstOrDefault(p => p.Alias == alias);
        }
    }
}
