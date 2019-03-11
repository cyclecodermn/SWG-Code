using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    /// <summary>
    /// int AddressId, string Street1, string Street2, string City, State State, string PostalCode
    /// </summary>
    public class Address
    {
        public int AddressId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
    }
}