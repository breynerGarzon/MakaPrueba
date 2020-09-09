using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MakaPrueba.Modelos.Exceptions
{
    public class PersonException : Exception
    {
        public PersonException()
        {
        }

        public PersonException(string message) : base(message)
        {
        }

        public PersonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PersonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
