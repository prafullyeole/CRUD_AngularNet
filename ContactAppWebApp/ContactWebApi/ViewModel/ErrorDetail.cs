using Newtonsoft.Json;

namespace ContactWebApi.ViewModel
{
    /// <summary>
    /// Model for error details
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// Https Status code for error
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// Serialize object to Json format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    
}
