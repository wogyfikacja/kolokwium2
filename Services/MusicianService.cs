using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using kolokwium2.Entities;
using kolokwium2.Entities.Models;

namespace kolokwium2.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly MusicContext _context;

        public MusicianService(MusicContext context)
        {
            _context = context;
        }

        public async void DeleteMusician(Musician musician)
        {
            _context.Musicians.Remove(musician);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Musician> GetAllMusicians()
        {
            var toReturn = _context.Musicians.AsQueryable();
            return toReturn;
        }

        public Musician GetMusicianWithNickname(string Nickname)
        {
            return _context.Musicians.Where(m => m.Nickname == Nickname).FirstOrDefault();
        }

        //save changes in context
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        IQueryable<Track> IMusicianService.GetTracksForMusician(Musician musician)
        {
            return _context.Tracks.Where(t => t.Musician_Tracks.Any(mt => mt.Musician.IdMusician == musician.IdMusician));
        }
    }
}