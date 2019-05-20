namespace LearningBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Card")]
    public partial class Card
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Index("IX_Card", 1, IsUnique = true)]
        [Required]
        [Display(Name = "سوال")]
        public string Question { get; set; }

        [Index("IX_Card", 1, IsUnique = true)]
        [Required]
        [Display(Name = "پاسخ")]
        public string Answer { get; set; }

        [Index("IX_Card", 1, IsUnique = true)]
        [Required]
        public int BoxId { get; set; }

        [Required]
        public short GroupNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }


        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public virtual Box Box { get; set; }
    }
}
