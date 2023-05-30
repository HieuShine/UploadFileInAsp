using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace uploadFile.Models
{
    public partial class DbContext : System.Data.Entity.DbContext
    {
        public DbContext()
            : base("name=DbContext")
        {
        }

        public virtual DbSet<doanhngiep> doanhngieps { get; set; }
        public virtual DbSet<tailieudinhkem> tailieudinhkems { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<doanhngiep>()
        //        .Property(e => e.tenDN)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<tailieudinhkem>()
        //        .Property(e => e.DuongDan)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<tailieudinhkem>()
        //        .Property(e => e.MoTa)
        //        .IsUnicode(false);
        //}
    }
}
