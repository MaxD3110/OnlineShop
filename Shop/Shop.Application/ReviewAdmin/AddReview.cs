using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Shop.Application.ReviewAdmin
{
    [Service]
    public class AddReview
    {
        private IReviewManager _reviewManager;

        public AddReview(IReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }

        public async Task<Response> Do(Request request)
        {
            var review = new Review
            {
                CommentatorName = request.CommentatorName,
                Title = request.Title,
                Comments = request.Comments,
                Email = request.Email,
                Rating = request.Rating,
                ThisDateTime = DateTime.Now.ToString("dd MMMM yyyy в HH:mm"),
                ProductId = request.ProductId
            };

            await _reviewManager.AddReview(review);

            return new Response
            {
                Id = review.Id,
                CommentatorName = review.CommentatorName,
                Title = review.Title,
                Comments = review.Comments,
                Email = review.Email,
                Rating = review.Rating,
                ThisDateTime = DateTime.Now.ToString("dd MMMM yyyy в HH:mm"),
            };
        }

        public class Request
        {
            public int ProductId { get; set; }
            public string Comments { get; set; }
            public string Email { get; set; }
            public int Rating { get; set; }
            public string CommentatorName { get; set; }
            public string Title { get; set; }
            public string ThisDateTime { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Comments { get; set; }
            public string Email { get; set; }
            public int Rating { get; set; }
            public string CommentatorName { get; set; }
            public string Title { get; set; }
            public string ThisDateTime { get; set; }
        }
    }
}
