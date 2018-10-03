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

        public static Expression<Func<Genre, Data.Genre>> SelectAsData()
        {
            return g => new Data.Genre
            {
                Guid = g.GenreId,
                Name = g.Name,
                Description = g.Description
            };
        }

        public static Expression<Func<Data.Genre, Genre>> SelectAsDTO()
        {
            return g => new Genre
            {
                GenreId = g.Guid ?? new Guid(),
                Name = g.Name,
                Description = g.Description
            };
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
