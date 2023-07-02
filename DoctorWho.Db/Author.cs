

namespace DoctorWho.Db
{
    public class Author
    {
        public Author()
        {
            Episodes = new List<Episode>();
        }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }
}
