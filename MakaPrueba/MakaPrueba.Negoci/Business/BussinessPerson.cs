using MakaPrueba.Datos.Entities;
using MakaPrueba.Datos.Filter;
using MakaPrueba.Datos.IServices;
using MakaPrueba.Modelos.ViewModels;
using MakaPrueba.Util.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakaPrueba.Negoci.Business
{
    public class BussinessPerson
    {
        private readonly ViewPerson Person;

        public BussinessPerson(ViewPerson newPerson)
        {
            this.Person = newPerson;
        }

        public Person ValidationNewPerson()
        {
            Utils.ValidationText(this.Person.PersonName);
            Utils.ValidationNumber(this.Person.PersonAge);
            Utils.ValidationText(this.Person.PersonType);
            var newPerson = new Person() { Name = this.Person.PersonName, Age = this.Person.PersonAge, PersonTypeId = int.Parse(this.Person.PersonType) };
            return newPerson;
        }

        public Person ValidationUpdatePerson(IDataServicesPerson serviceData)
        {
            Utils.ValidationNumber(this.Person.PersonId);
            Utils.ValidationText(this.Person.PersonName);
            Utils.ValidationNumber(this.Person.PersonAge);
            Utils.ValidationText(this.Person.PersonType);
            var filter = new FilterPerson() { Id = this.Person.PersonId };
            var person = serviceData.GetPersons(filter).First();
            person.Name = this.Person.PersonName;
            person.Age = this.Person.PersonAge;
            person.PersonTypeId = int.Parse(this.Person.PersonType);
            return person;
        }

        public Person ValidationDeletePerson(IDataServicesPerson serviceData) { 
            Utils.ValidationNumber(this.Person.PersonId);
            var filter = new FilterPerson() { Id = this.Person.PersonId };
            var person = serviceData.GetPersons(filter).First();
            return person;
        }

    }
}
