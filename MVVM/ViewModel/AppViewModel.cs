using ReplicaSpotify.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReplicaSpotify.MVVM.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Playlist> ListPlaylists { get; set; } = new ObservableCollection<Playlist>();
        public ObservableCollection<Album> ListAlbums { get; set; } = new ObservableCollection<Album>();
        public ObservableCollection<Artist> ListArtists { get; set; } = new ObservableCollection<Artist>();

        public AppViewModel()
        {
            CargarDatosPlaylists();
            CargarDatosAlbums();
        }

        private void CargarDatosPlaylists()
        {
            var playlist1 = new Playlist()
            {
                Id = "1",
                Name = "Top Hits",
                Description = "Las canciones más populares del momento.",
                CoverUrl = "https://i.scdn.co/image/ab67616d0000b273fa853d9769c89d08a74983bb",
                Tracks = new List<Track>()
                {
                    new Track() { 
                        Id = "1", 
                        Title = "Song A", 
                        Duration = TimeSpan.FromMinutes(3).ToString() 
                    },
                    new Track() { 
                        Id = "2", 
                        Title = "Song B", 
                        Duration = TimeSpan.FromMinutes(4).ToString() 
                    },
                    new Track() { 
                        Id = "3", 
                        Title = "Song C", 
                        Duration = TimeSpan.FromMinutes(2.5).ToString() 
                    }
                }
            };
            var playlist2 = new Playlist()
            {
                Id = "2",
                Name = "Top Hits 2024",
                Description = "Las canciones más populares del momento.",
                CoverUrl = "https://i.scdn.co/image/ab67616d0000b273fa853d9769c89d08a74983bb",
                Tracks = new List<Track>()
                {
                    new Track() {
                        Id = "1",
                        Title = "Song A",
                        Duration = TimeSpan.FromMinutes(3).ToString()
                    },
                    new Track() {
                        Id = "2",
                        Title = "Song B",
                        Duration = TimeSpan.FromMinutes(4).ToString()
                    },
                    new Track() {
                        Id = "3",
                        Title = "Song C",
                        Duration = TimeSpan.FromMinutes(2.5).ToString()
                    }
                }
            };
            ListPlaylists.Add(playlist1);
            ListPlaylists.Add(playlist2);
        }

        private void CargarDatosAlbums()
        {
            // Artistas reales de ejemplo con URLs de demostración funcionales
            var artist1 = new Artist
            {
                Id = "art1_biza",
                Name = "Bizarrap",
                ProfilePicUrl = "https://picsum.photos/seed/bizarrap/200/200" // Imagen genérica 1
            };
            var artist2 = new Artist
            {
                Id = "art2_badbunny",
                Name = "Bad Bunny",
                ProfilePicUrl = "https://picsum.photos/seed/badbunny/200/200" // Imagen genérica 2
            };
            var artist3 = new Artist
            {
                Id = "art3_rosalia",
                Name = "ROSALÍA",
                ProfilePicUrl = "https://picsum.photos/seed/rosalia/200/200" // Imagen genérica 3
            };

            // Añadir artistas al listado global (simulación de manejo de duplicados)
            if (!ListArtists.Any(a => a.Id == artist1.Id)) ListArtists.Add(artist1);
            if (!ListArtists.Any(a => a.Id == artist2.Id)) ListArtists.Add(artist2);
            if (!ListArtists.Any(a => a.Id == artist3.Id)) ListArtists.Add(artist3);

            // Álbum 1: Bizarrap
            var album1 = new Album
            {
                Id = "alb1_bizarrap",
                Name = "BZRP Music Sessions, Vol. 53",
                CoverUrl = "https://picsum.photos/seed/album1/300/300", // Carátula de demostración 1
                Artists = new List<Artist> { artist1 },
                Tracks = new List<Track>
        {
            new Track
            {
                Id = "alb1_t1",
                Title = "Shakira: BZRP Music Sessions, Vol. 53",
                Duration = TimeSpan.FromMinutes(3.38).ToString("mm\\:ss"),
                AudioUrl = "https://example.com/audio/biza_shakira.mp3",
                AlbumId = "alb1_bizarrap",
                Artists = new List<Artist> { artist1 }
            },
            new Track
            {
                Id = "alb1_t2",
                Title = "Quevedo: BZRP Music Sessions, Vol. 52",
                Duration = TimeSpan.FromMinutes(3.18).ToString("mm\\:ss"),
                AudioUrl = "https://example.com/audio/biza_quevedo.mp3",
                AlbumId = "alb1_bizarrap",
                Artists = new List<Artist> { artist1 }
            }
        }
            };

            // Álbum 2: Bad Bunny
            var album2 = new Album
            {
                Id = "alb2_badbunny",
                Name = "Un Verano Sin Ti",
                CoverUrl = "https://picsum.photos/seed/album2/300/300", // Carátula de demostración 2
                Artists = new List<Artist> { artist2 },
                Tracks = new List<Track>
        {
            new Track
            {
                Id = "alb2_t1",
                Title = "Moscow Mule",
                Duration = TimeSpan.FromMinutes(4.05).ToString("mm\\:ss"),
                AudioUrl = "https://example.com/audio/badbunny_mule.mp3",
                AlbumId = "alb2_badbunny",
                Artists = new List<Artist> { artist2 }
            },
            new Track
            {
                Id = "alb2_t2",
                Title = "Tití Me Preguntó",
                Duration = TimeSpan.FromMinutes(4.03).ToString("mm\\:ss"),
                AudioUrl = "https://example.com/audio/badbunny_titi.mp3",
                AlbumId = "alb2_badbunny",
                Artists = new List<Artist> { artist2 }
            },
            new Track
            {
                Id = "alb2_t3",
                Title = "La Corriente (with Tony Dize)",
                Duration = TimeSpan.FromMinutes(3.18).ToString("mm\\:ss"),
                AudioUrl = "https://example.com/audio/badbunny_corriente.mp3",
                AlbumId = "alb2_badbunny",
                Artists = new List<Artist> { artist2, new Artist { Id = "art_tonydize", Name = "Tony Dize" } }
            }
        }
            };

            // Álbum 3: ROSALÍA
            var album3 = new Album
            {
                Id = "alb3_rosalia",
                Name = "MOTOMAMI",
                CoverUrl = "https://picsum.photos/seed/album3/300/300", // Carátula de demostración 3
                Artists = new List<Artist> { artist3 },
                Tracks = new List<Track>
        {
            new Track
            {
                Id = "alb3_t1",
                Title = "SAOKO",
                Duration = TimeSpan.FromMinutes(2.17).ToString("mm\\:ss"),
                AudioUrl = "https://example.com/audio/rosalia_saoko.mp3",
                AlbumId = "alb3_rosalia",
                Artists = new List<Artist> { artist3 }
            },
            new Track
            {
                Id = "alb3_t2",
                Title = "DESPECHÁ",
                Duration = TimeSpan.FromMinutes(2.37).ToString("mm\\:ss"),
                AudioUrl = "https://example.com/audio/rosalia_despecha.mp3",
                AlbumId = "alb3_rosalia",
                Artists = new List<Artist> { artist3 }
            }
        }
            };

            // Añadir álbumes a la colección observable (o ListAlbums en este ejemplo)
            if (!ListAlbums.Any(a => a.Id == album1.Id)) ListAlbums.Add(album1);
            if (!ListAlbums.Any(a => a.Id == album2.Id)) ListAlbums.Add(album2);
            if (!ListAlbums.Any(a => a.Id == album3.Id)) ListAlbums.Add(album3);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
