using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Infrastructure
{
    public interface IReviewManager
    {
        Task<int> AddReview(Review review);
        Task<int> DeleteReview(int id);
        Task UpdateReviewRange(List<Review> reviewList);
    }
}
