using MusicStore.Data;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;

namespace MusicStore.Controllers.OData
{
    public class ODataGenreDTOsController: ODataController
    {
        private readonly MusicStoreEntities dbContext = new MusicStoreEntities();

        [EnableQuery()]
        public IQueryable<DTO.Genre> Get()
        {
            return dbContext.Genres
                            .Select(DTO.Genre.SelectAsDTO());
        }

        [EnableQuery]
        public SingleResult<DTO.Genre> Get([FromODataUri] Guid key)
        {
            IQueryable<DTO.Genre> result = dbContext.Genres
                                                    .Select(DTO.Genre.SelectAsDTO())
                                                    .Where(p => p.GenreId == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<DTO.Genre> genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = dbContext.Genres
                                  .Where(DTO.Genre.FindEntity(key))
                                  .FirstOrDefault();

            if (entity == null)
            {
                return NotFound();
            }

            DTO.Genre currentEntity = DTO.Genre.FromData(entity);
            genre.Patch(currentEntity);
            entity = currentEntity.ToData();

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }
            return Updated(entity);
        }
    }
}