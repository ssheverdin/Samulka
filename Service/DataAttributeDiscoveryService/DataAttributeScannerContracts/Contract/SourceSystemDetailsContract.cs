using System;
using System.Collections.Generic;
using System.Text;

namespace DataAttributeScannerContracts.Contract
{
    public class SourceSystemDetailsContract
    {
        public SourceSystemDetailsContract()
        {
            Entities = new List<SourceSystemEntityContract>();
        }

        public SourceSystemContract SourceSystem { get; set; }
        public List<SourceSystemEntityContract> Entities { get; set; }
    }
}
