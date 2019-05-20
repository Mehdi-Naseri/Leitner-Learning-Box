using System.ComponentModel;

namespace LearningBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Box")]
    public partial class Box /*:INotifyPropertyChanged*/
    {
        //public Box()
        //{
           
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
       
        public int Id { get; set; }

        [Required]
 [Display(Name = "نام جعبه")]
        public string Name { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        ////[Required]
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
