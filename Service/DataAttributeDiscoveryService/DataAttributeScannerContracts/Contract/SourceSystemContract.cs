using System;
using System.Collections.Generic;
using System.Text;

namespace DataAttributeScannerContracts.Contract
{
    public class SourceSystemContract
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool HasConnection { get; set; }
        public bool HasMetadataConnector { get; set; }
        public bool HasSync { get; set; }
        public bool HasMetadata { get; set; }

    }
}
