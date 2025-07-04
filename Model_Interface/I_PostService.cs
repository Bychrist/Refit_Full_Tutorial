using Refit;

namespace Refit_tutorial.Model_Interface
{
    public interface I_PostService
    {
        [Get("/posts")]
        Task<List<Post>> GetPostsAsync();

        [Get("/posts/{id}")]
        Task<Post> GetPostByIdAsync(int id);

        [Post("/posts")]
        Task<Post> CreatePostAsync([Body] Post post);

        [Put("/posts/{id}")]
        Task<Post> UpdatePostAsync(int id, [Query] Post post);

        [Delete("/posts/{id}")]
        Task DeletePostAsync(int id);
    }


    public interface IZanibalApi
    {
       [Post("/administration/api/v1/users/token/new")]
       Task <ZanibalToken> GetTokenAsync([Body] ZaniRequest request);

        [Get("/administration/api/v1/webhooks/list")]
        Task<Webhook> GetWebhooklistAsync([Header("Authorization")] string token);
    }
}
