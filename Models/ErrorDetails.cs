using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Kaizala.Models
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorCategoryKey { get; set; }
        public ErrorDetails() { }
        public ErrorDetails(string message, string errorCode, string errorCat)
        {
            this.Message = message;
            this.ErrorCode = errorCode;
            this.ErrorCategoryKey = errorCat;
        }
    }
}
