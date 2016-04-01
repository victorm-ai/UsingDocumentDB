using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentDBProject
{
    public class UserTest
    {
        [JsonProperty(PropertyName = "id")]
        public string UserID { get; set; }


        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "Age")]
        public string Age { get; set; }


        [JsonProperty(PropertyName = "Sex")]
        public string Sex { get; set; }
    }
}