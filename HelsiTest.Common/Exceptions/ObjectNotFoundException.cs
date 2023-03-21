using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelsiTest.Common.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string message) : base(message)
        {
        }

        public static ObjectNotFoundException Throw<T>(T id)
        => throw new ObjectNotFoundException($"Can't find Object in DB with Id - {id}");
    }
}
