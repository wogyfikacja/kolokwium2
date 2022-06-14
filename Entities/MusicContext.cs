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
                e.Property(x => x.Duration).HasColumnType("float").IsRequired();
                e.HasData(
                    new Track { IdTrack = 1, TrackName = "Track 1", Duration = 1.5f },
                    new Track { IdTrack = 2, TrackName = "Track 2", Duration = 2.5f },
                    new Track { IdTrack = 3, TrackName = "Track 3", Duration = 3.5f }
                    );
            });
            modelBuilder.Entity<Album>(e => {
                e.ToTable("Album");
                e.HasKey(x => x.IdAlbum);
                e.Property(x => x.AlbumName).HasMaxLength(50).IsRequired();
                e.Property(x => x.PublishDate).HasColumnType("date").IsRequired();
                e.HasData(
                    new Album { IdAlbum = 1, AlbumName = "Album 1", PublishDate = new DateTime(2020, 1, 1) },
                    new Album { IdAlbum = 2, AlbumName = "Album 2", PublishDate = new DateTime(2020, 2, 1) },
                    new Album { IdAlbum = 3, AlbumName = "Album 3", PublishDate = new DateTime(2020, 3, 1) }
                    );
            });

        }
        
    }
}