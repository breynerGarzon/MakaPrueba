using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MakaPrueba.Modelos.ViewModels
{
    public class ViewPersonType
    {
        //[Required]
        public string PersonTypeId { get; set; }
        //[Required]
        public string PersonTypeDescription { get; set; }
    }
}
