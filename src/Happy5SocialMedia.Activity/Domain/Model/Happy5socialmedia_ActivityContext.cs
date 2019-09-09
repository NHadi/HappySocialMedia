using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Happy5SocialMedia.Activity.Domain.Model
{
    public partial class Happy5socialmedia_ActivityContext : DbContext
    {
        public Happy5socialmedia_ActivityContext(DbContextOptions<Happy5socialmedia_ActivityContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public virtual DbSet<ActivityStatus> ActivityStatus { get; set; }
        public virtual DbSet<FriendRelationship> FriendRelationship { get; set; }
        public virtual DbSet<FriendRequest> FriendRequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<ActivityStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ActivityStatus>().HasData(
                new ActivityStatus { Id = Guid.NewGuid(), Name = "Accepted", Description = "Accepted" },
                new ActivityStatus { Id = Guid.NewGuid(), Name = "Request", Description = "Request" },
                new ActivityStatus { Id = Guid.NewGuid(), Name = "Pending", Description = "Pending" },
                new ActivityStatus { Id = Guid.NewGuid(), Name = "Declined", Description = "Declined" }
            );

            modelBuilder.Entity<FriendRelationship>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FriendRequest)
                    .WithMany(p => p.FriendRelationship)
                    .HasForeignKey(d => d.FriendRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendRelationship_FriendRequest");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.FriendRelationship)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendRelationship_ActivityStatus");
            });

            modelBuilder.Entity<FriendRequest>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.FriendRequest)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_FriendRequest_ActivityStatus");
            });
            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}