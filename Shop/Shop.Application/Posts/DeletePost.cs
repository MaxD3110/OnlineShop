using Shop.Domain.Infrastructure;
using System.Threading.Tasks;

namespace Shop.Application.Posts
{
    [Service]
    public class DeletePost
    {
        private IPostManager _postManager;

        public DeletePost(IPostManager postManager)
        {
            _postManager = postManager;
        }

        public Task<int> Do(int id)
        {
            return _postManager.DeletePost(id);
        }
    }
}
