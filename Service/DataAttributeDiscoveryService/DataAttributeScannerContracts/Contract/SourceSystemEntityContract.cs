using System;
using System.Collections.Generic;
using System.Text;

namespace DataAttributeScannerContracts.Contract
{
    public class SourceSystemEntityContract
    {
        public SourceSystemEntityContract()
        {
            Attributes = new List<SourceSystemEntityAttributeContract>();
            Referenced = new List<SourceSystemEntityRelationContract>();
            Referencing = new List<SourceSystemEntityRelationContract>();
        }

        public string Schema { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int? SourceColumnCount { get; set; }
        public bool HasMetadata { get; set; }
        public bool NeedsToSync { get; set; }
        
        public List<SourceSystemEntityAttributeContract> Attributes { get; set; }

        public List<SourceSystemEntityRelationContract> Referenced { get; set; }
        public List<SourceSystemEntityRelationContract> Referencing { get; set; }
    }
}
