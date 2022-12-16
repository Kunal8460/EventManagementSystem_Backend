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
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.HasKey(e => e.category_id);

                entity.ToTable("Event_Category");

                entity.Property(e => e.category_id).HasColumnName("category_id");

                entity.Property(e => e.category_name)
                    .HasColumnName("category_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventMaster>(entity =>
            {
                entity.HasKey(e => e.event_id);

                entity.ToTable("Event_Master");

                entity.Property(e => e.event_id).HasColumnName("event_id");

                entity.Property(e => e.category_id).HasColumnName("category_id");

                entity.Property(e => e.city)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.country)
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("customer_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.event_description)
                    .HasColumnName("event_description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.event_end_date)
                    .HasColumnName("event_end_date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.event_end_time)
                    .HasColumnName("event_end_time")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.event_start_date)
                    .HasColumnName("event_start_date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.event_start_time)
                    .HasColumnName("event_start_time")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.event_title)
                    .HasColumnName("event_title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.event_venue)
                    .HasColumnName("event_venue")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GalleryImage)
                    .HasColumnName("gallery_image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.state)
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbnailImage)
                    .HasColumnName("thumbnail_image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.EventMaster)
                    .HasForeignKey(d => d.category_id)
                    .HasConstraintName("FK_Event_Master_Event_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
