using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.Entities
{
   public class Feedback
    {
        public Guid Id { get; set; }
        [Required (ErrorMessage ="Please add rivew")]
        public string Review { get; set; }
        [Required (ErrorMessage ="Select Rating")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name")]

        public int Rating { get; set; }
    }
}
