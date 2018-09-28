using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class GenresController : ApiController
    {
        private readonly MusicStoreDB _db = new MusicStoreDB();

        public IQueryable<Genre> GetGenres()
        {
            return _db.Genres;
        }

        [ResponseType(typeof(Genre))]
        public IHttpActionResult GetGenres(int id)
        {
            var genre = _db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [ResponseType(typeof(Genre))]
        public IHttpActionResult PutGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.GenreId)
            {
                return BadRequest();
            }

            _db.Entry(genre).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
	            if (!GenreExists(id))
                {
                    return NotFound();
                }
	            throw;
            }

	        return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PostGenre(Genre genre)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_db.Genres.Add(genre);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = genre.GenreId }, genre);
        }

        [ResponseType(typeof(Genre))]
        public IHttpActionResult DeleteGenre(int id)
        {
            var genre = _db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            _db.Genres.Remove(genre);
            _db.SaveChanges();

            return Ok(genre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenreExists(int id)
        {
            return _db.Genres.Count(e => e.GenreId == id) > 0;
        }
    }
}