
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserUC6
{
    public class CustomException : Exception
    {
        //Enum for Exception Type
        public enum ExceptionType
        {
            NULL_MESSAGE_EXCEPTION, EMPTY_MESSAGE_EXCEPTION,
            NO_SUCH_METHOD, NO_SUCH_CLASS,
            NO_SUCH_METHOD_ERROR
        }
        private readonly ExceptionType exceptionType;

        public CustomException(ExceptionType exceptionType, string exceptionMessage) : base(exceptionMessage)
        {
            this.exceptionType = exceptionType;
        }
    }
}
