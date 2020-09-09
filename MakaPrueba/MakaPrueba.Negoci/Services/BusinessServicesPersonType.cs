using MakaPrueba.Datos.IServices;
using MakaPrueba.Modelos.ViewModels;
using MakaPrueba.Negoci.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakaPrueba.Negoci.Services
{
    public class BusinessServicesPersonType : IBusinessServicePersonType
    {
        private readonly IDataServicesPersonType ServiceData;

        public BusinessServicesPersonType(IDataServicesPersonType serviceData)
        {
            this.ServiceData = serviceData;
        }

        public List<ViewPersonType> GetPersonType()
        {
            var persons = this.ServiceData.GetPersonType();
            if (persons.Count==0) {
                return new List<ViewPersonType>();
            }
            return persons.Select(person => new ViewPersonType() {PersonTypeId = person.Id.ToString(), PersonTypeDescription = person.Description }).ToList();
        }
    }
}
