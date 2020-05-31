using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DutchTreat.ViewModels
{
    public class ContactsViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(100)]
        public string Message { get; set; }
    }
}
