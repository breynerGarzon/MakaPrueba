using MakaPrueba.Datos.Context;
using MakaPrueba.Datos.Entities;
using MakaPrueba.Datos.Filter;
using MakaPrueba.Datos.IServices;
using MakaPrueba.Modelos.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakaPrueba.Datos.Services
{
    public class DataServicesPerson : IDataServicesPerson
    {
        private readonly MakaContext Context;

        public DataServicesPerson(MakaContext context)
        {
            this.Context = context;
        }
        public int CreatePerson(Person newPerson)
        {
            try
            {
                using (var transaccion = this.Context.Database.BeginTransaction()) {
                    this.Context.Persons.Add(newPerson);
                    var register = this.Context.SaveChanges();
                    if (register>0)
                    {
                        transaccion.Commit();
                        return newPerson.Id;
                    }
                    transaccion.Rollback();
                    throw new PersonException("Error al crear la persona.");
                }
            }
            catch (PersonException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new PersonException("Error del servidor por favor validar");
            }
        }

        public int DeletePerson(Person deletePerson)
        {
            try
            {
                using (var transaccion = this.Context.Database.BeginTransaction())
                {
                    this.Context.Persons.Remove(deletePerson);
                    var register = this.Context.SaveChanges();
                    if (register > 0)
                    {
                        transaccion.Commit();
                        return deletePerson.Id;
                    }
                    transaccion.Rollback();
                    throw new PersonException("Error al eliminar la persona.");
                }
            }
            catch (PersonException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new PersonException("Error del servidor por favor validar");
            }
        }

        public List<Person> GetPersons(FilterPerson filters)
        {
            IQueryable<Person> persons = this.Context.Persons;
            if (filters.Id>0)
            {
                return persons.Where(person=> person.Id==filters.Id).ToList();
            }
            if (!string.IsNullOrEmpty(filters.Name))
            {
                return persons.Where(person => person.Name.Equals(filters.Name)).ToList();
            }
            if (filters.Age > 0)
            {
                return persons.Where(person => person.Age == filters.Age).ToList();
            }
            if (filters.PersonType > 0)
            {
                return persons.Where(person => person.PersonTypeId == filters.PersonType).ToList();
            }
            return persons.ToList();
        }

        public int UpdatePerson(Person updatePerson)
        {
            try
            {
                using (var transaccion = this.Context.Database.BeginTransaction())
                {
                    this.Context.Persons.Update(updatePerson);
                    var register = this.Context.SaveChanges();
                    if (register > 0)
                    {
                        transaccion.Commit();
                        return updatePerson.Id;
                    }
                    transaccion.Rollback();
                    throw new PersonException("Error al actulizar la persona.");
                }
            }
            catch (PersonException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new PersonException("Error del servidor por favor validar");
            }
        }
    }
}
