using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Happy5SocialMedia.Message.Domain.Model
{
    public partial class Happy5socialmedia_MessageContext : DbContext
    {
        public Happy5socialmedia_MessageContext(DbContextOptions<Happy5socialmedia_MessageContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public virtual DbSet<ActivityStatus> ActivityStatus { get; set; }
        public virtual DbSet<Conversation> Conversation { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Participant> Participant { get; set; }

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

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ActivityStatus>().HasData(
                new ActivityStatus { Id = Guid.NewGuid(), Name = "Delivered", Description = "Delivered" },
                new ActivityStatus { Id = Guid.NewGuid(), Name = "Read", Description = "Read" },
                new ActivityStatus { Id = Guid.NewGuid(), Name = "Replied", Description = "Replied" },
                new ActivityStatus { Id = Guid.NewGuid(), Name = "UnRead", Description = "UnRead" }
            );

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContentMessage).IsRequired();

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ConversationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Conversation");

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ParticipantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Participant");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Message_ActivityStatus");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.Participant)
                    .HasForeignKey(d => d.ConversationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participant_Conversation");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Participant)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participant_ActivityStatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}