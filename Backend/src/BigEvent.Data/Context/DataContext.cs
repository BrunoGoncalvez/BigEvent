using BigEvent.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BigEvent.Data.Context
{
    public class DataContext : DbContext
    {
        
        public DataContext( DbContextOptions<DataContext> options ) 
            : base(options){ }


        public DbSet<Event> Events { get; set; }

        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<Allotment> Allotments { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<SpeakerEvent> SpeakersEvents { get; set; }


        // Config ForeignKey - Many to Many
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // When the speaker table is created it will be the junction of eventId and speakerId
            modelBuilder.Entity<SpeakerEvent>()
                .HasKey(speakerEvent => new { speakerEvent.EventId, speakerEvent.SpeakerId });
            
            modelBuilder.Entity<Event>()
                .HasMany(ev => ev.SocialMedias)
                .WithOne(sm => sm.Event)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Speaker>()
                .HasMany(ev => ev.SocialMedias)
                .WithOne(sm => sm.Speaker)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}