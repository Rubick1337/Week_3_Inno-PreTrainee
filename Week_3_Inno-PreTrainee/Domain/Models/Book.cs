using Week_3_Inno_PreTrainee.Domain.Interfaces;

namespace Week_3_Inno_PreTrainee.Domain.Models
{
    public class Book : IIWithId
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedYear { get; set; }
        public int AuthorId { get; set; }
    }
}
