using MakaPrueba.Datos.Filter;
using MakaPrueba.Datos.IServices;
using MakaPrueba.Modelos.Exceptions;
using MakaPrueba.Modelos.ViewModels;
using MakaPrueba.Negoci.Business;
using MakaPrueba.Negoci.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakaPrueba.Negoci.Services
{
    public class BusinessServicePerson : IBusinessServicePerson
    {
        private readonly IDataServicesPerson ServiceData;

        public BusinessServicePerson(IDataServicesPerson serviceData)
        {
            this.ServiceData = serviceData;
        }

        public void CreatePerson(ViewPerson newPerson)
        {
            try
            {
                var subServicesPerson = new BussinessPerson(newPerson);
                this.ServiceData.CreatePerson(subServicesPerson.ValidationNewPerson());
            }
            catch (ValidationException ex)
            {
                throw;
            }
            catch (PersonException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeletePerson(int deletePerson)
        {
            try
            {

                var subServicesPerson = new BussinessPerson(new ViewPerson() { PersonId = deletePerson });
                this.ServiceData.DeletePerson(subServicesPerson.ValidationDeletePerson(this.ServiceData));
            }
            catch (ValidationException ex)
            {
                throw;
            }
            catch (PersonException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetPersonByAge(int agePerson)
        {
            throw new NotImplementedException();
        }

        public ViewPerson GetPersonById(int idPerson)
        {
            var filter = new FilterPerson() { Id=idPerson};
            return this.ServiceData.GetPersons(filter).Select(person =>new ViewPerson() {PersonId = person.Id, PersonAge = person.Age, PersonName= person.Name, PersonType= person.PersonTypeId.ToString() }).First();
            //throw new NotImplementedException();
        }

        public void GetPersonByName(string namePerson)
        {
            throw new NotImplementedException();
        }

        public void GetPersonByType(int typePerson)
        {
            throw new NotImplementedException();
        }

        public List<ViewPerson> GetPersons()
        {
            try
            {
                var filter = new FilterPerson();
                var persons = this.ServiceData.GetPersons(filter);
                return persons.Select(person => new ViewPerson()
                {
                    PersonId = person.Id,
                    PersonName = person.Name,
                    PersonAge = person.Age,
                    PersonType = person.PersonTypeId.ToString()
                }).ToList();
            }
            catch (Exception ex)
            {
                return new List<ViewPerson>();
            }
        }

        public void UpdatePerson(ViewPerson newPerson)
        {
            try
            {
                var subServicesPerson = new BussinessPerson(newPerson);
                this.ServiceData.UpdatePerson(subServicesPerson.ValidationUpdatePerson(this.ServiceData));
            }
            catch (ValidationException ex)
            {
                throw;
            }
            catch (PersonException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
