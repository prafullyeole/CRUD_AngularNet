using System;

namespace ContactWebApi.ViewModel
{
    /// <summary>
    /// Contact View Model
    /// </summary>
    public class ContactViewModel
    {       
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        public String PhoneNumber { get; set; }

        /// <summary>
        /// Contact Status
        /// </summary>
        public Boolean Status { get; set; }
    }
}
