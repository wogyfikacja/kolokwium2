

namespace kolokwium2.Entities.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual MusicLabel MusicLabel { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}