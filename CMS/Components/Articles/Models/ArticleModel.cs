﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComArticles.Models
{
    public class ArticleModel
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Alias { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public String Content { get; set; }
    }
}
