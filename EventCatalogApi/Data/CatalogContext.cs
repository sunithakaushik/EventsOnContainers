using EventCatalogApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Data
{
    public class CatalogContext: DbContext
    {
        public CatalogContext(DbContextOptions options)
            : base(options)
        {  }

        public DbSet<EventTopic> EventTopics { get; set; }
        public DbSet<EventType> EventTypes  { get; set; }
        public DbSet<EventName> EventNames { get; set; }
       // public DbSet<EventLocation> EventLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<EventLocation>(e =>
            {
                e.ToTable("EventLocation");
                e.Property(l => l.Id)
                    .IsRequired()
                    .UseHiLo("event_location_hilo");
                e.Property(l => l.Location)
                    .IsRequired()
                    .HasMaxLength(1000);
            });*/

            modelBuilder.Entity<EventTopic>(e =>
            {
                e.ToTable("EventTopics");
                e.Property(t => t.Id)
                    .IsRequired()
                    .UseHiLo("event_topic_hilo");
                e.Property(t => t.Topic)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventType>(e =>
            {
                e.ToTable("EventTypes");
                e.Property(t => t.Id)
                    .IsRequired()
                    .UseHiLo("event_type_hilo");
                e.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventName>(e =>
            {
                e.ToTable("EventNames");
                e.Property(n => n.Id).IsRequired().UseHiLo("event_name_hilo");
                e.Property(n => n.Title).IsRequired().HasMaxLength(200);
                e.Property(n => n.Price).IsRequired().HasColumnType("decimal(9, 2)");
             //   e.Property(n => n.Ticket).IsRequired();
                e.Property(n => n.StartDate).IsRequired();
                e.Property(n => n.EndDate).IsRequired();
                e.Property(n => n.Location).IsRequired().HasMaxLength(400);
                e.Property(n => n.Description).IsRequired().HasMaxLength(2000);
                e.Property(n => n.Listing).IsRequired().HasMaxLength(10);
             //   e.Property(n => n.OrganizerDesc).IsRequired().HasMaxLength(2000);
             //   e.Property(n => n.OrganizerName).IsRequired().HasMaxLength(250);
                e.HasOne(n => n.EventType).WithMany().HasForeignKey(n => n.EventTypeId);
                e.HasOne(n => n.EventTopic).WithMany().HasForeignKey(n => n.EventTopicId);
              //  e.HasOne(n => n.EventLocation).WithMany().HasForeignKey(n => n.EventLocationId);
            });
        }
    }
}
