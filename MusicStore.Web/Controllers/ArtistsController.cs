using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly MusicStoreDB _db = new MusicStoreDB();

        public IQueryable<Artist> GetArtists()
        {
            return _db.Artists;
        }

        [ResponseType(typeof(Artist))]
        public IHttpActionResult GetArtists(int id)
        {
            var artist = _db.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [ResponseType(typeof(Artist))]
        public IHttpActionResult PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.ArtistId)
            {
                return BadRequest();
            }

            _db.Entry(artist).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
	            if (!ArtistExists(id))
                {
                    return NotFound();
                }
	            throw;
            }

	        return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PostArtist(Artist artist)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_db.Artists.Add(artist);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = artist.ArtistId }, artist);
        }

        [ResponseType(typeof(Artist))]
        public IHttpActionResult DeleteArtist(int id)
        {
            var artist = _db.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }

            _db.Artists.Remove(artist);
            _db.SaveChanges();

            return Ok(artist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistExists(int id)
        {
            return _db.Artists.Count(e => e.ArtistId == id) > 0;
        }
    }
}