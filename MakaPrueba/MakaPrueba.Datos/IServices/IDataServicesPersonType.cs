using MakaPrueba.Datos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakaPrueba.Datos.IServices
{
    public interface IDataServicesPersonType
    {
        public int CreatePersonType();

        public List<PersonType> GetPersonType();
    }
}
