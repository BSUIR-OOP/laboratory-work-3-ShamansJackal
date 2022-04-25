using lab3.Transports;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Transport> _transports = new();
        private byte[] file;

        private List<Transport> _availbleType = new()
        {
            new Jet(),
            new Plane(),
            new Tanker(),
            new CargoShip()
        };
        public MainWindow()
        {
            InitializeComponent();

            SelectClass.ItemsSource = _availbleType;
            listView.ItemsSource = _transports;
        }
        private void InputFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "PNG (*.jpg)|*.jpg"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    ((Button)sender).Tag = filename;

                    using (FileStream SourceStream = new FileStream(OpenFileBTN.Tag.ToString(), FileMode.Open))
                    {
                        file = new byte[SourceStream.Length];
                        SourceStream.Read(file, 0, (int)SourceStream.Length);
                    }

                    //BitmapImage logo = new BitmapImage();
                    //logo.BeginInit();
                    //logo.UriSource = new Uri(filename);
                    //logo.EndInit();

                    //prewievImg.Source = logo;
                }
            }
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Transport newTrs = SelectClass.SelectedItem as Transport;

            newTrs.model = modelBox.Text; 
            newTrs.power = int.Parse(powerBox.Text); 
            newTrs.capacity = int.Parse(capacBox.Text);
            newTrs.bin = file;

            if (((Button)sender).Tag == "upd")
                _transports[listView.SelectedIndex] = newTrs;
            else
                _transports.Add(newTrs);
        }

        private void DeserialzeAct(object sender, RoutedEventArgs e)
        {
            _transports = JsonService.FromFile("data.json");
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void SerializeAct(object sender, RoutedEventArgs e)
        {
            JsonService.ToFile(_transports, "data.json");
        }
    }
}
