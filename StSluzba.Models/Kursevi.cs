using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StSluzba.Models
{
    public class Kursevi
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public int Bodovi { get; set; }
        
        
    }
}
