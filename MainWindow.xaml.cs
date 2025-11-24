using Microsoft.Win32;
using ReplicaSpotify.MVVM.Model;
using ReplicaSpotify.MVVM.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ReplicaSpotify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainPage mainPage = new MainPage();

        private MediaPlayer musicPlayer;

        private Boolean isPlaying = false;

        // Crear un temporizador para actualizar la posición de la canción
        DispatcherTimer _timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            musicPlayer = new MediaPlayer();
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Tick += new EventHandler(ticktock);
            _timer.Start();
            MainFrame.Navigate(mainPage);
        }

        private void BtnCargarCancion_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de audio|*.mp3;";
            if(dialog.ShowDialog() == true)
            {
                TagLib.File ficheroCancion = TagLib.File.Create(dialog.FileName);
                if(ficheroCancion != null)
                {
                    var cancion = new Track
                    {
                        Title = ficheroCancion.Tag.Title,
                        Artists = ficheroCancion.Tag.Performers.ToList().Select(texto => new Artist { Name = texto }).ToList(),
                        Duration = ficheroCancion.Properties.Duration.ToString(@"mm\:ss"),
                        AudioUrl = dialog.FileName,
                        AlbumId = "" // Aquí podrías asignar el ID del álbum si es necesario
                    };
                    
                    var vm = DataContext as MVVM.ViewModel.AppViewModel;
                    if(vm!= null)
                    {
                        vm.SelectedTrack = cancion;
                        musicPlayer.Open(new Uri(cancion.AudioUrl, UriKind.Absolute));
                        musicPlayer.Play();
                        isPlaying = true;
                        SliderCancion.Maximum = ficheroCancion.Properties.Duration.TotalSeconds;
                    }

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                musicPlayer.Pause();
                isPlaying = false;
            }
            else
            {
                musicPlayer.Play();
                isPlaying = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            musicPlayer.Position = TimeSpan.Zero;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            musicPlayer.Position = TimeSpan.FromSeconds(musicPlayer.Position.TotalSeconds + 15);
        }

        private void SliderCancion_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            musicPlayer.Position = TimeSpan.FromSeconds(SliderCancion.Value);
        }

        void ticktock(object sender, EventArgs e)
        {
            if (musicPlayer.NaturalDuration.HasTimeSpan)
            {
                SliderCancion.Value = musicPlayer.Position.TotalSeconds;
            }
        }
    }
}