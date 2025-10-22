namespace Week_3_Inno_PreTrainee.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly PublishedYear { get; set; }
        public int AuthorId { get; set; }
    }
}
