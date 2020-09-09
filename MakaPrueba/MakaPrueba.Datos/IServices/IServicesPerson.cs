using MakaPrueba.Datos.Entities;
using MakaPrueba.Datos.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakaPrueba.Datos.IServices
{
    public interface IDataServicesPerson
    {
        public int CreatePerson(Person newPerson);
        public int UpdatePerson(Person updatePerson);
        public int DeletePerson(Person deletePerson);
        public List<Person> GetPersons(FilterPerson filters);
    }
}
