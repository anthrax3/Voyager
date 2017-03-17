using ComArticles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComArticles.Services
{
    public interface IArticlesService
    {
        List<ArticleModel> GetAllArticles();
        bool Exist(String alias);
        bool ChangeArticleState(String alias, bool published);
    }
}
