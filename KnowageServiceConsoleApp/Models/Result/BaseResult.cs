using System;
namespace KnowageService.Models.Result
{
    public class BaseResult
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public Exception ObjectException { get; set; }
    }
}
