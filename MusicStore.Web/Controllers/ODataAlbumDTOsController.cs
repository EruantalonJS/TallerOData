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
    public class ODataAlbumDTOsController : ODataController
    {
        private readonly MusicStoreEntities dbContext = new MusicStoreEntities();

        [EnableQuery]
        public IQueryable<DTO.Album> Get()
        {
            return dbContext.Albums
                            .Select(DTO.Album.SelectAsDTO());
        }

        [EnableQuery]
        public SingleResult<DTO.Album> Get([FromODataUri] Guid key)
        {
            IQueryable<DTO.Album> result = dbContext.Albums
                                                    .Select(DTO.Album.SelectAsDTO())
                                                    .Where(p => p.GenreId == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<DTO.Album> album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = dbContext.Albums
                                  .Where(DTO.Album.FindEntity(key))
                                  .FirstOrDefault();

            if (entity == null)
            {
                return NotFound();
            }

            DTO.Album currentEntity = DTO.Album.FromData(entity);
            album.Patch(currentEntity);
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