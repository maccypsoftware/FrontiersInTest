using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontiersInTest.API.Models
{
    public class DateModel
    {
        [JsonProperty(PropertyName = "abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty(PropertyName = "datetime")]
        public DateTime Datetime { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "utc_datetime")]
        public DateTime UtcDatetime { get; set; }
    }
}
