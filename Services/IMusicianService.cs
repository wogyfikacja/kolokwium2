using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2.Entities.Models;
namespace kolokwium2.Services
{
    public interface IMusicianService
    {
        Task SaveChangesAsync();
        IQueryable<Musician> GetAllMusicians();
        Task DeleteMusician(Musician musician);
        public Musician GetMusicianWithNickname(string Nickname);
        IQueryable<Track> GetTracksForMusician(Musician musician);
    }
}