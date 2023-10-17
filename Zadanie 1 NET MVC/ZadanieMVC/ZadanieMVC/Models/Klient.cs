using System.ComponentModel.DataAnnotations;

namespace ZadanieMVC.Models
{
    public class Klient
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(50)]
        public string Surname { get; set; } = null!;

        [MaxLength(11)]
        public string PESEL { get; set; } = null!;
        public int BirthYear { get; set; }
        public int Plec { get; set; }
    }
}
