using System.Collections.Generic;
using MakaPrueba.Datos.Entities;
using Microsoft.EntityFrameworkCore;

namespace MakaPrueba.Datos.Config
{
    public class PersonTypeConfig : IEntityTypeConfiguration<PersonType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PersonType> builder)
        {
            List<PersonType> persons = new List<PersonType>();
            persons.Add(new PersonType() { Id= 1 , Description = "Teacher" });
            persons.Add(new PersonType() { Id= 2 , Description= "Students" });
            builder.HasData(persons.ToArray());
            builder.Property(item => item.Id).ValueGeneratedOnAdd();
        }
    }
}