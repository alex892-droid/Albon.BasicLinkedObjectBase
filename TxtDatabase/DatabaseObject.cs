using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TxtDatabase
{
    public class DatabaseObject
    {
        [JsonIgnore]
        public string Id { get; set; }

        public DatabaseObject()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
