using Domain.Models;

namespace Week_3_Inno_PreTrainee.Domain.Models
{
    public class Author : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
