using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class AddArticle
    {
       
        public string Title { get; set; }

        public string Content { get; set; }

        public bool CommentOk { get; set; }

        public bool OnLigne { get; set; }

        public int UserId { get; set; }

    

    }
}
