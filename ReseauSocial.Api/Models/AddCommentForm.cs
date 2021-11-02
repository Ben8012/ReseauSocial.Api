using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api.Models
{
    public class AddCommentForm
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        
    }
}
