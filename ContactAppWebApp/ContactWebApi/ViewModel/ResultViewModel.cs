using System;
using System.Net;

namespace ContactWebApi.ViewModel
{
    /// <summary>
    /// This is Json Result object which has to return by each controller action method
    /// </summary>
    public class ResultViewModel
    {
        /// <summary>
        /// Any object which need to return to View
        /// </summary>
        public Object Data { get; set; }

        /// <summary>
        /// Excetion information in case need to provide to end user
        /// </summary>
        public Exception ExceptionInfo { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; } = "Request executed successfully.";

        /// <summary>
        /// Array of multiple messages
        /// </summary>
        public string[] Messages { get; set; }

        /// <summary>
        /// Request success or not
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Http Status code 
        /// </summary>
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;


    }
}
