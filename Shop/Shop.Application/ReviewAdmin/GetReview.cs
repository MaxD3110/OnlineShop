using Shop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.Reviews
{
    [Service]
    public class GetReview
    {
        private IProductManager _poductManager;

        public GetReview(IProductManager poductManager)
        {
            _poductManager = poductManager;
        }

        public IEnumerable<ProductViewModel> Do()
        {
            return _poductManager.GetProductsWithReview(x => new ProductViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Review = x.Review.Select(y => new ReviewViewModel
                {
                    Id = y.Id,
                    CommentatorName = y.CommentatorName,
                    Title = y.Title,
                    Email = y.Email,
                    Comments = y.Comments,
                    ThisDateTime = y.ThisDateTime,
                    Rating = y.Rating
                })
            });
        }

        public class ReviewViewModel
        {
            public int Id { get; set; }
            public string Comments { get; set; }
            public int Rating { get; set; }
            public string Email { get; set; }
            public string CommentatorName { get; set; }
            public string Title { get; set; }
            public string ThisDateTime { get; set; }
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public IEnumerable<ReviewViewModel> Review { get; set; }
        }
    }
}
