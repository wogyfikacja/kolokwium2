using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2.Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace kolokwium2.Entities
{
    public class MusicContext : DbContext
    {
        DbSet<MusicLabel> MusicLabels { get; set; }
        DbSet<Musician> Musicians { get; set; }
        DbSet<Musician_Track> Musician_Tracks { get; set; }
        DbSet<Track> Tracks { get; set; }
        DbSet<Album> Albums { get; set; }
        public MusicContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusicLabel>(e => {
                e.ToTable("MusicLabel");
                e.HasKey(x => x.IdMusicLabel);

                e.Property(x => x.Name).HasMaxLength(50).IsRequired();
                
                e.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "EMI" },
                    new MusicLabel { IdMusicLabel = 2, Name = "Sony" },
                    new MusicLabel { IdMusicLabel = 3, Name = "Universal" },
                    new MusicLabel { IdMusicLabel = 4, Name = "Warner" }
                    );
            });
            modelBuilder.Entity<Musician>(e => {
                e.ToTable("Musician");
                e.HasKey(x => x.IdMusician);
                e.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
                e.Property(x => x.LastName).HasMaxLength(50).IsRequired();
                e.Property(x => x.Nickname).HasMaxLength(50).IsRequired();
                e.HasMany(x => x.Musician_Tracks).WithOne(x => x.Musician).HasForeignKey(x => x.IdMusician);
                e.HasData(
                    new Musician { IdMusician = 1, FirstName = "John", LastName = "Smith", Nickname = "John Smith" },
                    new Musician { IdMusician = 2, FirstName = "John", LastName = "Doe", Nickname = "John Doe" },
                    new Musician { IdMusician = 3, FirstName = "Jane", LastName = "Doe", Nickname = "Jane Doe" }
                    );
            });
            modelBuilder.Entity<Track>(e => {
                e.ToTable("Track");
                e.HasKey(x => x.IdTrack);
                e.Property(x => x.TrackName).HasMaxLength(50).IsRequired();
                e.Property(x => x.Duration).IsRequired();
                e.HasOne(x => x.Album).WithMany(x => x.Tracks).HasForeignKey(x => x.IdAlbum);
                e.HasMany(x => x.Musician_Tracks).WithOne(x => x.Track).HasForeignKey(x => x.IdTrack);
                e.HasData(
                    new Track { IdTrack = 1, TrackName = "Track 1", Duration = 120, IdAlbum = 1 },
                    new Track { IdTrack = 2, TrackName = "Track 2", Duration = 180, IdAlbum = 1 }
                    );
            });

        }
        
    }
}