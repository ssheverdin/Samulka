using System;
using System.Collections.Generic;
using System.Text;

namespace DataAttributeScannerContracts.Contract
{
    public class SourceSystemEntityRelationContract
    {
        public string Name { get; set; }
        public string EntityName { get; set; }
        public string EntityAttributeName { get; set; }
        public string RelationEntityName { get; set; }
        public string RelationEntityAttributeName { get; set; }
    }
}
