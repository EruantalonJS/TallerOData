using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class AlbumsController : ApiController
    {
        private readonly MusicStoreDB _db = new MusicStoreDB();

        public IQueryable<Album> GetAlbums()
        {
            return _db.Albums.Include("Genre")
                             .Include("Artist");
        }

        [ResponseType(typeof(Album))]
        public IHttpActionResult GetAlbums(int id)
        {
            var album = _db.Albums.Find(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        [ResponseType(typeof(Album))]
        public IHttpActionResult PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != album.AlbumId)
            {
                return BadRequest();
            }

            _db.Entry(album).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
	            if (!AlbumExists(id))
                {
                    return NotFound();
                }
	            throw;
            }

	        return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Albums
        [ResponseType(typeof(void))]
        public IHttpActionResult PostAlbum(Album album)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_db.Albums.Add(album);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = album.AlbumId }, album);
        }

        // DELETE: api/Albums/5
        [ResponseType(typeof(Album))]
        public IHttpActionResult DeleteAlbum(int id)
        {
            var album = _db.Albums.Find(id);
            if (album == null)
            {
                return NotFound();
            }

            _db.Albums.Remove(album);
            _db.SaveChanges();

            return Ok(album);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlbumExists(int id)
        {
            return _db.Albums.Count(e => e.AlbumId == id) > 0;
        }
    }
}