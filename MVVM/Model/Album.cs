using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicaSpotify.MVVM.Model
{
    public class Album
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CoverUrl { get; set; }
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<Track> Tracks { get; set; } = new List<Track>();

    }
}
