using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string CommentatorName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }

        public string Comments { get; set; }

        public int Rating { get; set; }

        public string ThisDateTime { get; set; } 

        public int ProductId { get; set; }

        public Product Products { get; set; }
    }
}
