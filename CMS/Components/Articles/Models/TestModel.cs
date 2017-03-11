using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComArticles.Models
{
    public class TestModel
    {
        [Required(ErrorMessage = "Required!")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Required!")]
        public int Age { get; set; }
    }
}
