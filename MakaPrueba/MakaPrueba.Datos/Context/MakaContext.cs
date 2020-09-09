using MakaPrueba.Datos.Config;
using MakaPrueba.Datos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakaPrueba.Datos.Context
{
    public class MakaContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }

        public MakaContext(DbContextOptions<MakaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonTypeConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
        }
    }
}
