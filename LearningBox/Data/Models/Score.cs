namespace LearningBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Score")]
    public partial class Score
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Index("IX_Score", 1, IsUnique = true)]
        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Index("IX_Score", 2, IsUnique = true)]
        [Required]
        public int BoxId { get; set; }

        [Required]
        public int AllAnswers { get; set; }

        [Required]
        public int CorrectAnswers { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public virtual Box Box { get; set; }
    }
}
