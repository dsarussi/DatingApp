namespace API.Helpers
{
    public class LikesParams : PaginationParams
    {
        public int userId { get; set; }
        public string Predicate { get; set; }
    }
}