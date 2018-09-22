using System.Data.Entity;

namespace MusicStore.Models
{
	public class MusicDb:DbContext
	{
		public DbSet<Music> Musics { get; set; }
	}
}