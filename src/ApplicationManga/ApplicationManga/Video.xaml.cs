using Modele;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ApplicationManga
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Video : Window
    {
        public Manager Mgr => (App.Current as App).LeManager;

        int TempsDeLaVideo;

        public Boolean i = true;
        public Video()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void ButtonVideo_Click(object sender, RoutedEventArgs e)
        {
            if (i) // vrais = si le media play , faux = si le media est stop
            {
                VideoBA.LoadedBehavior = MediaState.Pause;
                i = false;
            }
            else
            {
                VideoBA.LoadedBehavior = MediaState.Play;
                i = true;
            }
        }

        private void Temps_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoBA.LoadedBehavior = MediaState.Pause;
            int tempsSlider = (int)TempsSlider.Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, tempsSlider);
            VideoBA.Position = ts;
            VideoBA.LoadedBehavior = MediaState.Play;
            //TempsSlider.IsMouseCapturedChanged
        }

        private void VideoBA_MediaEnded(object sender, RoutedEventArgs e)
        {
            
        }

        private void VideoBA_MediaOpened(object sender, RoutedEventArgs e)
        {
            TempsSlider.Maximum = VideoBA.NaturalDuration.TimeSpan.TotalMilliseconds;
        }
    }
}
