using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Database
{
    public class ReviewManager : IReviewManager
    {
        private ApplicationDbContext _ctx;

        public ReviewManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> AddReview(Review review)
        {
            _ctx.Reviews.Add(review);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteReview(int id)
        {
            var review = _ctx.Reviews.FirstOrDefault(x => x.Id == id);

            _ctx.Reviews.Remove(review);

            return _ctx.SaveChangesAsync();
        }

        public Task UpdateReviewRange(List<Review> reviewList)
        {
            _ctx.Reviews.UpdateRange(reviewList);
            return _ctx.SaveChangesAsync();
        }
    }
}
