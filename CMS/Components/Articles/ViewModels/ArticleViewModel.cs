using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComArticles.ViewModels
{
    public class ArticleViewModel
    {
        public String Title { get; set; }
        public String Alias { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyTime { get; set; }
        public String Content { get; set; } 
    }
}
