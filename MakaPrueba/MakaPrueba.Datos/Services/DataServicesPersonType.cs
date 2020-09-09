using MakaPrueba.Datos.Context;
using MakaPrueba.Datos.Entities;
using MakaPrueba.Datos.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakaPrueba.Datos.Services
{
    public class DataServicesPersonType : IDataServicesPersonType
    {
        private readonly MakaContext Context;
        public DataServicesPersonType(MakaContext context)
        {
            this.Context = context;
        }

        public int CreatePersonType()
        {
            throw new NotImplementedException();
        }

        public List<PersonType> GetPersonType()
        {
            return this.Context.PersonTypes.ToList();
        }
    }
}
