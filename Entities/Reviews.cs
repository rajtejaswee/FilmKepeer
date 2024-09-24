namespace Filmkeeper.Entities
{
    public class Review
    {
        public int id { get; set; }
        public string review { get; set; }
	    public int rating { get; set; }
	    public int movieid { get; set; }
    }
}
