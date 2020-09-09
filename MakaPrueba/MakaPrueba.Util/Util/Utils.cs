using MakaPrueba.Modelos.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakaPrueba.Util.Util
{
    public static class Utils
    {
        public static void ValidationText(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ValidationException("El campo no puede ser vacio");
            }
        }

        public static void ValidationNumber(int value)
        {
            if (value ==0)
            {
                throw new ValidationException("El campo no puede ser vacio");
            }
        }
    }
}
