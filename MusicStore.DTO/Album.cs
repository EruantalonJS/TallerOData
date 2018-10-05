using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DTO
{
    [DataContract]
    public class Album
    {
        private static Expression<Func<Data.Album, Album>> albumToDTO = DTO.Album.SelectAsDTO();
        private static Expression<Func<Album, Data.Album>> albumToData = DTO.Album.SelectAsData();

        [Key]
        [DataMember]
        public Guid AlbumId { get; set; }

        [DataMember]
        [ForeignKey("Genre")]
        public Guid GenreId { get; set; }

        [DataMember]
        public virtual DTO.Genre Genre { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string AlbumArtUrl { get; set; }

        public static Expression<Func<Album, Data.Album>> SelectAsData()
        {
            return g => new Data.Album
            {
                Guid = g.AlbumId,
                Title = g.Title,
                Price = g.Price,
                AlbumArtUrl = g.AlbumArtUrl
            };
        }

        public static Expression<Func<Data.Album, Album>> SelectAsDTO()
        {
            return (g => new Album
            {
                AlbumId = g.Guid ?? new Guid(),
                GenreId = g.Genre.Guid ?? new Guid(),
                //Genre =  
                //{
                //    GenreId = g.Genre.Guid ?? new Guid(),
                //    Name = g.Genre.Name,
                //    Description = g.Genre.Description
                //},
                Title = g.Title,
                Price = g.Price,
                AlbumArtUrl = g.AlbumArtUrl
            });
        }
        
        public static Expression<Func<Data.Album, bool>> FindEntity(Guid key)
        {
            return album => album.Guid == key;
        }

        public Data.Album ToData()
        {
            return Album.SelectAsData()
                        .Compile()
                        .Invoke(this);
        }

        public static Album FromData(Data.Album genre)
        {
            return Album.SelectAsDTO()
                        .Compile()
                        .Invoke(genre);
        }
    }
}
