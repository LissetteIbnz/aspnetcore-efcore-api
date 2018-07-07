using System;

namespace SchoolManager.Service
{
    public class StoreException : Exception
    {
        public StoreException()
            : base()
        {
        }

        public StoreException(String message)
            : base(message)
        {
        }

        public StoreException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
