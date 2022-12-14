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
                optionsBuilder.UseSqlServer("Data Source=RENCY\\MSSQLSERVER01;Initial Catalog=ems;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingMaster>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("Booking_master");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.BookedOn)
                    .HasColumnName("booked_on")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CutomerEmail)
                    .IsRequired()
                    .HasColumnName("cutomer_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.NetPrice).HasColumnName("net_price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.BookingMaster)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Event_id");
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("Event_Category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("category_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventMaster>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("Event_Master");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasColumnName("customer_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasColumnName("event_description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventEndDate)
                    .HasColumnName("event_end_date")
                    .HasColumnType("date");

                entity.Property(e => e.EventEndTime).HasColumnName("event_end_time");

                entity.Property(e => e.EventStartDate)
                    .HasColumnName("event_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.EventStartTime).HasColumnName("event_start_time");

                entity.Property(e => e.EventTitle)
                    .IsRequired()
                    .HasColumnName("event_title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventVenue)
                    .IsRequired()
                    .HasColumnName("event_venue")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GalleryImage)
                    .IsRequired()
                    .HasColumnName("gallery_image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbnailImage)
                    .IsRequired()
                    .HasColumnName("thumbnail_image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
