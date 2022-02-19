using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BCYips.Models
{
    public class YipDbContext : DbContext
    {
        public DbSet<Yip> Yips { get; set; }
        public DbSet<Yipper> Yippers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Yip>()
                        .HasOptional(y => y.ReYip)
                        .WithOptionalDependent();

            modelBuilder.Entity<Yip>()
                        .HasOptional(y => y.ReplyTo)
                        .WithOptionalDependent();
        }
    }



}