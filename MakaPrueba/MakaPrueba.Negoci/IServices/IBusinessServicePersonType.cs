using MakaPrueba.Modelos.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakaPrueba.Negoci.IServices
{
    public interface IBusinessServicePersonType
    {
        public List<ViewPersonType> GetPersonType();
    }
}
