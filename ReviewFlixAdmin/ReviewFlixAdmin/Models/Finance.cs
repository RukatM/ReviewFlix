namespace ReviewFlixAdmin.Models
{
    public class Finance
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }
    }
}

