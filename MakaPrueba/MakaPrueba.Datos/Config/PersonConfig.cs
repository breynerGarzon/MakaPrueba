using System.Collections.Generic;
using MakaPrueba.Datos.Entities;
using Microsoft.EntityFrameworkCore;

namespace MakaPrueba.Datos.Config
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Person> builder)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person() { Id= 1 , Name ="Usuario1", Age=20, PersonTypeId=1});
            persons.Add(new Person() { Id= 2 , Name ="Usuario2", Age=21, PersonTypeId=2});
            persons.Add(new Person() { Id= 3 , Name ="Usuario3", Age=22, PersonTypeId=1});
            persons.Add(new Person() { Id= 4 , Name ="Usuario4", Age=23, PersonTypeId=2});
            builder.HasData(persons.ToArray());
            builder.Property(item => item.Id).ValueGeneratedOnAdd();
        }
    }
}