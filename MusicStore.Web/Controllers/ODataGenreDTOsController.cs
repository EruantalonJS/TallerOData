using MusicStore.Data;
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
        public SingleResult<DTO.Genre> Get([FromODataUri] int key)
        {
            IQueryable<DTO.Genre> result = dbContext.Genres
                                                    .Where(p => p.GenreId == key)
                                                    .Select(DTO.Genre.SelectAsDTO());
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<DTO.Genre> genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await dbContext.Genres
                                        .FindAsync(key);

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