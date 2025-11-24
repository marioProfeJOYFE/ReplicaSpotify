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

        public MainWindow()
        {
            InitializeComponent();
            musicPlayer = new MediaPlayer();
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
    }
}