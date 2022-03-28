using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserUC5
{
    public class CustomException : Exception
    {
        //Enum for Exception Type
        public enum ExceptionType
        {
            NULL_MESSAGE_EXCEPTION, EMPTY_MESSAGE_EXCEPTION,
            NO_SUCH_METHOD, NO_SUCH_CLASS
        }

        private readonly ExceptionType exceptionType;
        private MoodAnalyserCustomException.ExceptionType nULL_MESSAGE_EXCEPTION;
        private string v;

        public CustomException(ExceptionType exceptionType, string exceptionMessage) : base(exceptionMessage)
        {
            this.exceptionType = exceptionType;
        }

        public CustomException(MoodAnalyserCustomException.ExceptionType nULL_MESSAGE_EXCEPTION, string v)
        {
            this.nULL_MESSAGE_EXCEPTION = nULL_MESSAGE_EXCEPTION;
            this.v = v;
        }
    }
}
