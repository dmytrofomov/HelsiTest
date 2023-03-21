using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelsiTest.Common.Exceptions
{

    public class PermissionDeniedException : Exception
    {
        public PermissionDeniedException(string message) : base(message)
        {
        }

        public static PermissionDeniedException Throw<T>(T id)
        => throw new PermissionDeniedException($"Permission Denied for Id - {id}");
    }
}
