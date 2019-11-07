using System;

namespace back_pi.BLL.Exceptions
{
    public class  DbConcurrencyException: ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }

}