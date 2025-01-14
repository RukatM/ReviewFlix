namespace ReviewFlixApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; } 
        public DateTime DateAdded { get; set; }

    }


}
