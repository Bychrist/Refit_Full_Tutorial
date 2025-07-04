namespace Refit_tutorial.Model_Interface
{

    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class ZanibalToken
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public DateTime grant_time { get; set; }
        public int expires_in { get; set; }
        public int refresh_expires_in { get; set; }
    }


    public class ZaniRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string tenant { get; set; }
    }



    public class Content
    {
        public string id { get; set; }
        public string createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedAt { get; set; }
        public string status { get; set; }
        public string deliveryType { get; set; }
        public List<string> @event { get; set; }
        public string url { get; set; }
        public string secretKey { get; set; }
        public string subject { get; set; }
    }

    public class Webhook
    {
        public int page { get; set; }
        public int size { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
        public string sort { get; set; }
        public string order { get; set; }
        public List<Content> content { get; set; }
    }


}
