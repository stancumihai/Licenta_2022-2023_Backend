namespace Library.Models
{
    public class SearchModel
    {
        public string OrderBy { get; set; }
        public string Ordering { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }   
        public int ItemsPerPage { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
    }
}