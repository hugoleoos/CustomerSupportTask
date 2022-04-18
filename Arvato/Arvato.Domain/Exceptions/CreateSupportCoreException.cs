using System;

namespace Arvato.Domain.Exceptions
{
    [Serializable]
    public class CreateSupportCoreException : Exception
    {
        public CreateSupportCoreException() { }

        public CreateSupportCoreException(string message)
            : base(message) { }

        public CreateSupportCoreException(string message, Exception inner)
            : base(message, inner) { }
    }
}
