using System;
namespace KnowageService.Common
{
    public class Constants
    {
        public class Messages
        {
            public const string RESPONSE_CONTENT_IS_EMPTY = "Respnse content is empty.";
            public const string RESPONSE_CONTAINS_ERROR = "Respnse contains error.";
        }

        public class Output
        {
            public const int EMPTY = 0;
            public const int SUCCESSFUL = 1;
            public const int ERROR = 2;
            
        }

        public class Result
        {
            public const string FAILED = "Failed";
            public const string EXCEPTION = "Exception";
            public const string SUCCESSFUL = "Success";
        }


    }
}
