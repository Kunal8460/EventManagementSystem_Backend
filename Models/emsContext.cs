using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ems.Models
{
    public partial class emsContext : DbContext
    {
        public emsContext()
        {
        }

        public emsContext(DbContextOptions<emsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingMaster> BookingMaster { get; set; }
        public virtual DbSet<EventCategory> EventCategory { get; set; }
        public virtual DbSet<EventMaster> EventMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=Kunal;Initial Catalog=emsDatabase.bacpac;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingMaster>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("Booking_master");

                entity.Property(e => e.BookingId).HasColumnName("bookingId");

                entity.Property(e => e.BookedOn)
                    .HasColumnName("bookedOn")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("customerEmail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.NetPrice).HasColumnName("netPrice");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.BookingMaster)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Booking_master_Event_Master");
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("Event_Category");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("categoryName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventMaster>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("Event_Master");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("customerEmail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventDescription)
                    .HasColumnName("eventDescription")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.EventEndDate)
                    .HasColumnName("eventEndDate")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventEndTime)
                    .HasColumnName("eventEndTime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventStartDate)
                    .HasColumnName("eventStartDate")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventStartTime)
                    .HasColumnName("eventStartTime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventTitle)
                    .HasColumnName("eventTitle")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventVenue)
                    .HasColumnName("eventVenue")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GalleryImage)
                    .HasColumnName("galleryImage")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbnailImage)
                    .HasColumnName("thumbnailImage")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.EventMaster)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Event_Master_Event_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
