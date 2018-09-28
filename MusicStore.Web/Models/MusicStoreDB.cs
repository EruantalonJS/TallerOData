using System.Data.Entity;

namespace MusicStore.Models
{
	public class MusicStoreDB:DbContext
    {
        public MusicStoreDB()
            : base("name=MusicStore")
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}