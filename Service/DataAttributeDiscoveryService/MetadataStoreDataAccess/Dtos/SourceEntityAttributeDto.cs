using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DataUnitOfWork.Base;

namespace MetadataStoreDataAccess.Dtos
{
    [Table("SourceEntityAttribute")]
    public class SourceEntityAttributeDto : EntityBase
    {
        public int SourceEntityId { get; set; }
        public string Name { get; set; }
        public bool PrimaryKey { get; set; }
        public bool Hashed { get; set; }
        public string Description { get; set; }
        public string CodeType { get; set; }
        public string DataType { get; set; }
        public int? DataTypeLength { get; set; }
        public int? Precision { get; set; }
        public int? Position { get; set; }
        public bool IsNull { get; set; }

    }
}
