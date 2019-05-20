using LearningBox.Data.Models;

namespace LearningBox.Data.DbContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DictionaryDbContext : DbContext
    {
        public DictionaryDbContext()
            : base("name=DictionaryDbContext")
        {
        }

        public virtual DbSet<DictionaryEnFa> DictionaryEnFas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DictionaryEnFa>()
                .Property(e => e.Timestamp)
                .IsFixedLength();
        }
    }
}
