using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DataUnitOfWork.Base;

namespace MetadataStoreDataAccess.Dtos
{
    [Table("SourceEntity")]
    public class SourceEntityDto : EntityBase
    {
        public int SourceSystemId { get; set; }
        public string SchemaName { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public string Type { get; set; }
        public DateTime? EntityCreatedDate { get; set; }
        public DateTime? EntityLastUpdatedDate { get; set; }
        public int? SourceColumnCount { get; set; }

    }
}
