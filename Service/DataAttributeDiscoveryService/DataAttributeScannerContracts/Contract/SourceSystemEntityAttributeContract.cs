using System;
using System.Collections.Generic;
using System.Text;

namespace DataAttributeScannerContracts.Contract
{
    public class SourceSystemEntityAttributeContract
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Position { get; set; }
        public int MaxLength { get; set; }
        public int Precision { get; set; }
        public bool IsNullable { get; set; }
        public bool IsIdentity { get; set; }
    }
}
