using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public interface IPeople
    {
        int ID { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        DateTime? Birthday { get; set; }
    }

    public class People :IPeople
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        // ? makes it nullable
        public DateTime? Birthday { get; set; }

    }
}
