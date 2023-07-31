using System.ComponentModel.DataAnnotations;

namespace StSluzba.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string ime { get; set; }
        [Required]
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string pol { get; set; }
        public int telefon { get; set; }
    }
}
