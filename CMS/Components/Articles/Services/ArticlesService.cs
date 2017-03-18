using CMS.Core.DB;
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
        public ArticlesService(IDatabaseContext db)
        {
            this.db = db;
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
