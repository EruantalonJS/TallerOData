using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using MusicStore.Models;

namespace MusicStore.Controllers
{
	// [EnableCors(origins: "http://localhost:63249", headers: "*", methods: "*")]
    public class MusicsController : ApiController
    {
        private readonly MusicDb _db = new MusicDb();

        // GET: api/Musics
        public IQueryable<Music> GetMusics()
        {
            return _db.Musics;
        }

        // GET: api/Musics/5
        [ResponseType(typeof(Music))]
        public IHttpActionResult GetMusic(int id)
        {
            var music = _db.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }

            return Ok(music);
        }

        // PUT: api/Musics/5
        [ResponseType(typeof(Music))]
        public IHttpActionResult PutMusic(int id, Music music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != music.Id)
            {
                return BadRequest();
            }

            _db.Entry(music).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
	            if (!MusicExists(id))
                {
                    return NotFound();
                }
	            throw;
            }

	        return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Musics
        [ResponseType(typeof(void))]
        public IHttpActionResult PostMusic(Music music)
        {
			//var newMusic = new Music
			//{
			//	Title = music.Title,
			//	Singers = music.Singers,
			//	ReleaseDate = music.ReleaseDate,
			//	RunTime = music.RunTime
			//};
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_db.Musics.Add(music);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = music.Id }, music);
        }

        // DELETE: api/Musics/5
        [ResponseType(typeof(Music))]
        public IHttpActionResult DeleteMusic(int id)
        {
            var music = _db.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }

            _db.Musics.Remove(music);
            _db.SaveChanges();

            return Ok(music);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MusicExists(int id)
        {
            return _db.Musics.Count(e => e.Id == id) > 0;
        }
    }
}