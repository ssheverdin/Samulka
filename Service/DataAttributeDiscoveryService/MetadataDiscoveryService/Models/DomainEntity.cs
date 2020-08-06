using System;
using System.Collections.Generic;
using System.Text;

namespace MetadataDiscoveryService.Models
{
    public class DomainEntity
    {
        public string Schema { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
