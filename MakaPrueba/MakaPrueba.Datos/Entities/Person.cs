using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MakaPrueba.Datos.Entities
{
    public class Person
    {
        public int Id{ get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name{ get; set; }
        public int Age{ get; set; }
        public int PersonTypeId{ get; set; }
        public PersonType PersonType { get; set; }
    }
}
