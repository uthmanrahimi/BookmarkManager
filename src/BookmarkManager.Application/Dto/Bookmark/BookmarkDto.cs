namespace BookmarkManager.Application.Dto
{
    public class BookmarkDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int OwnerId { get; set; }
        public string Description { get; set; }
    }
}
