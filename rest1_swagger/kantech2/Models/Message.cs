using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kantech2.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        [Required]
        public string Sender { get; set; }

        [Required]
        [StringLength(maximumLength:100, MinimumLength = 5)]
        public string Body { get; set; }
    }
}
