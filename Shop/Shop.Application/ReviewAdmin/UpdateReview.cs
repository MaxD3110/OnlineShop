using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Application.ReviewAdmin
{
    [Service]
    public class UpdateReview
    {
        private IReviewManager _reviewManager;

        public UpdateReview(IReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }

        public async Task<Response> Do(Request request)
        {
            var reviewList = new List<Review>();

            foreach(var review in request.Review)
            {
                reviewList.Add(new Review
                {
                    Id = review.Id,
                    CommentatorName = review.CommentatorName,
                    Title = review.Title,
                    Comments = review.Comments,
                    Email = review.Email,
                    Rating = review.Rating,
                    ThisDateTime = review.ThisDateTime,
                    ProductId = review.ProductId

                });
            }

            await _reviewManager.UpdateReviewRange(reviewList);

            return new Response
            {
                Review = request.Review
            };
        }

        public class ReviewViewModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string Comments { get; set; }
            public string Email { get; set; }
            public int Rating { get; set; }
            public string CommentatorName { get; set; }
            public string Title { get; set; }
            public string ThisDateTime { get; set; }
        }

        public class Request
        {
            public IEnumerable<ReviewViewModel> Review { get; set; }
        }

        public class Response
        {
            public IEnumerable<ReviewViewModel> Review { get; set; }
        }
    }
}
