using System;
using Newtonsoft.Json;

namespace MyShop
{
    public class User
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
       
        [Microsoft.WindowsAzure.MobileServices.Version]
        public string Version { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Age { get; set; } = string.Empty;
        public string Allergies { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;


        [JsonIgnore]
        public Uri ImageUri
        {
            get { return new System.Uri(Image); }
        }


    }
}

