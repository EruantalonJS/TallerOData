using System;
using System.Runtime.Serialization;

namespace MusicStore.Models
{
    [DataContract(IsReference = true)]
    public class Album
    {
        [DataMember]
        public int AlbumId { get; set; }
        [DataMember]
        public int GenreId { get; set; }
        [DataMember]
        public int ArtistId { get; set; }
        [DataMember]
        public virtual Genre Genre { get; set; }
        [DataMember]
        public virtual Artist Artist { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string AlbumArtUrl { get; set; }
    }
}