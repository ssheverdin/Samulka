using System;
using System.Collections.Generic;
using System.Text;

namespace MetadataDiscoveryService.Models
{
    public class DomainEntityRelation
    {
        public string Name { get; set; }
        public string EntityName { get; set; }
        public string EntityAttributeName { get; set; }
        public string RelationEntityName { get; set; }
        public string RelationEntityAttributeName { get; set; }

    }
}
