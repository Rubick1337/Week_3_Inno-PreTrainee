using Week_3_Inno_PreTrainee.Domain.Interfaces;

namespace Week_3_Inno_PreTrainee.Domain.Models
{
    public class Author : IIWithId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
