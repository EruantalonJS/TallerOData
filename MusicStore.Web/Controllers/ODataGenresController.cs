using MusicStore.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;

namespace MusicStore.Controllers.OData
{
    public class ODataGenresController: ODataController
    {
        private readonly MusicStoreEntities dbContext = new MusicStoreEntities();
        private const AllowedQueryOptions allowedQueryOptions = AllowedQueryOptions.Select
                                                          | AllowedQueryOptions.OrderBy
                                                          | AllowedQueryOptions.Expand; 

        [EnableQuery(AllowedQueryOptions = allowedQueryOptions, MaxExpansionDepth =1)]
        public IQueryable<Genre> Get()
        {
            return dbContext.Genres;
        }

        [EnableQuery]
        public SingleResult<Genre> Get([FromODataUri] int key)
        {
            IQueryable<Genre> result = dbContext.Genres.Where(p => p.GenreId == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Genre> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await dbContext.Genres.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            product.Patch(entity);
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