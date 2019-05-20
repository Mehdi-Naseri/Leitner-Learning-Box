namespace LearningBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DictionaryEnFa")]
    public partial class DictionaryEnFa
    {
        public int Id { get; set; }

        [Index("IX_DictionaryEnFa", 1, IsUnique = true)]
        [Required]
        [StringLength(60)]
        public string En { get; set; }

        [Index("IX_DictionaryEnFa", 2, IsUnique = true)]
        [Required]
        public string Fa { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
