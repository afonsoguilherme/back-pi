using System;

namespace back_pi.BLL.Exceptions
{
    public class  IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {
        }
    }

}