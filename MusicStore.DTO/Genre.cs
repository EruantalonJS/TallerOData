using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DTO
{
    [DataContract]
    public class Genre
    {
        [Key]
        [DataMember]
        public Guid GenreId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public IEnumerable<Album> Albums { get; set; }

        private static Expression<Func<Data.Album, Album>> albumToDTO = DTO.Album.SelectAsDTO();
        private static Expression<Func<Album, Data.Album>> albumToData = DTO.Album.SelectAsData();

        public static Expression<Func<Genre, Data.Genre>> SelectAsData()
        {
            return g => new Data.Genre
            {
                Guid = g.GenreId,
                Name = g.Name,
                Description = g.Description,
                Albums = g.Albums
                          .AsQueryable()
                          .Select(albumToData)
                          .ToList()
            };
        }

        public static Expression<Func<Data.Genre, Genre>> SelectAsDTO()
        {
            return g => new Genre
            {
                GenreId = g.Guid ?? new Guid(),
                Name = g.Name,
                Description = g.Description,
                Albums = g.Albums
                          .AsQueryable()
                          .Select(albumToDTO)
                          .ToList()
            });
        }

        public static Expression<Func<Data.Genre,bool>> FindEntity(Guid key)
        {
            return genre => genre.Guid == key;
        }

        public Data.Genre ToData()
        {
            return Genre.SelectAsData()
                        .Compile()
                        .Invoke(this);
        }

        public static Genre FromData(Data.Genre genre)
        {
            return Genre.SelectAsDTO()
                        .Compile()
                        .Invoke(genre);
        }
    }
}
