using System;

namespace FabricAPP.Exceptions
{
    [Serializable]
    public class IncorectValueOfUserException : Exception
    {
        public IncorectValueOfUserException() { }

        public IncorectValueOfUserException(string message)
            : base(message) { }

        public IncorectValueOfUserException(string message, Exception inner)
            : base(message, inner) { }
    }
}
