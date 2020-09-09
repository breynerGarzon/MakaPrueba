using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MakaPrueba.Datos.Entities
{
    public class PersonType
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }
        List<Person> Persons { get; set; }
    }
}
