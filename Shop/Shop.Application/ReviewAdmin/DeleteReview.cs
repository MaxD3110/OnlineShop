using Shop.Domain.Infrastructure;
using System.Threading.Tasks;

namespace Shop.Application.ReviewAdmin
{
    [Service]
    public class DeleteReview
    {
        private IReviewManager _reviewManager;

        public DeleteReview(IReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }

        public Task<int> Do(int id)
        {
            return _reviewManager.DeleteReview(id);
        }
    }
}
