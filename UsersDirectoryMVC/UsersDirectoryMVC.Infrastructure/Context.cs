using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentTag> AssignmentTag { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<ContactDetailType> ContactDetailTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContactInformation> CustomerContactInformations { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasOne(a => a.CustomerContactInformation).WithOne(b => b.Customer)
                .HasForeignKey<CustomerContactInformation>(e => e.CustomerRef);

            builder.Entity<AssignmentTag>()
                .HasKey(it => new { it.AssignmentId, it.TagId });

            builder.Entity<AssignmentTag>()
                .HasOne<Assignment>(it => it.Assignment)
                .WithMany(a => a.AssignmentTags)
                .HasForeignKey(it => it.AssignmentId);

            builder.Entity<AssignmentTag>()
                .HasOne<Tag>(it => it.Tag)
                .WithMany(a => a.AssignmentTags)
                .HasForeignKey(it => it.TagId);
        }
    }
}
