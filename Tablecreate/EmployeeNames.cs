using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablecreate
{
    internal class EmployeeNames
    {
        [JsonProperty("unique_values")]
        public List<string> UniqueValues { get; set; }
    }
}
