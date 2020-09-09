using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MakaPrueba.Modelos.ViewModels
{
    public class ViewPerson
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public int PersonAge { get; set; }
        [Required]
        public string PersonType { get; set; }
    }
}
