using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackersHubV2.Entities
{
    public class Event
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Created_by { get; set; }
    }
}
