using System;

namespace SquareFish.Assessment.Application.Exceptions
{
    public class BusinessConditionException : Exception
    {
        public BusinessConditionException(string message) : base(message)
        {
        }
    }
}