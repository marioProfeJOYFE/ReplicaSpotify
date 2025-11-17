using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicaSpotify.MVVM.Model
{
    public class Track
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public string Duration { get; set; }
        public string AudioUrl { get; set; }
        public string AlbumId { get; set; }
    }
}
