using LearningBox.Data.Models;

namespace LearningBox.Data.DbContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LearningBoxDbContext : DbContext
    {
        public LearningBoxDbContext()
            : base("name=LearningBoxDbContext")
        {
        }

        public virtual DbSet<Box> Boxes { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Box>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<Card>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<Score>()
                .Property(e => e.Timestamp)
                .IsFixedLength();
        }
    }
}
