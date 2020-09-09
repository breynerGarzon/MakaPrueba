using MakaPrueba.Modelos.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakaPrueba.Negoci.IServices
{
    public interface IBusinessServicePerson
    {
        public void CreatePerson(ViewPerson newPerson);
        public void UpdatePerson(ViewPerson newPerson);
        public void DeletePerson(int deletePerson);
        public ViewPerson GetPersonById(int idPerson);
        public void GetPersonByName(string namePerson);
        public void GetPersonByAge(int agePerson);
        public void GetPersonByType(int typePerson);
        public List<ViewPerson> GetPersons();
    }
}
