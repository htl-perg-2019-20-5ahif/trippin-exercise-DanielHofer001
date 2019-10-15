using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trippin
{
    public class UserDTO
    {

        [JsonPropertyName("UserName")]
        public string UserName { get; set; }
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Emails")]
        public List<string> Emails { get; set; }
        public List<AdressInfo> AddressInfo { get; set; }

        public class AdressInfo
        {
            [JsonPropertyName("Address")]
            public string Address { get; set; }
            [JsonPropertyName("City")]
            public City City { get; set; }
          

        }
        public class City
        {
            [JsonPropertyName("Name")]
            public string Name { get; set; }
            [JsonPropertyName("CountryRegion")]
            public string CountryRegion { get; set; }
            [JsonPropertyName("Region")]
            public string Region { get; set; }
        }
        public class TrippinJsonFileUser
        {
            [JsonPropertyName("UserName")]
            public string UserName { get; set; }

            [JsonPropertyName("FirstName")]
            public string FirstName { get; set; }

            [JsonPropertyName("LastName")]
            public string LastName { get; set; }

            [JsonPropertyName("Email")]
            public string Email { get; set; }

            [JsonPropertyName("Address")]
            public string Address { get; set; }

            [JsonPropertyName("CityName")]
            public string CityName { get; set; }

            [JsonPropertyName("Country")]
            public string Country { get; set; }
        }
    }
    public class TrippinJsonFileUser
    {
        [JsonPropertyName("UserName")]
        public string UserName { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("CityName")]
        public string CityName { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }
    }
}
