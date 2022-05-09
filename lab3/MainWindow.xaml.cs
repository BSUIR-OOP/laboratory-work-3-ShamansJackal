using lab3.Service;
using lab3.Struct;
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
        public string Text_str { get; set; } = "dsa";
        public ListOfTransports _transports { get; set; } = new();
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

                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(file);
                    bi.EndInit();

                    prewievImg.Source = bi;
                }
            }
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Transport newTrs = (Transport)SelectClass.SelectedItem;

            newTrs = (Transport)newTrs.Clone();
            newTrs.model = modelBox.Text; 
            newTrs.power = int.Parse(powerBox.Text); 
            newTrs.capacity = int.Parse(capacBox.Text);
            newTrs.bin = file;

            if (((Button)sender).Tag.ToString() == "upd")
                _transports[listView.SelectedIndex] = newTrs;
            else
                _transports.Add(newTrs);

            listView.Items.Refresh();
        }

        private void DeserialzeAct(object sender, RoutedEventArgs e)
        {
            var jsonTree = JsonTokenizer.ToJsonTree(File.ReadAllText("data.json"));
            _transports = (ListOfTransports)_transports.FromJson(jsonTree);

            listView.ItemsSource = _transports;
            listView.Items.Refresh();
        }

        private void SerializeAct(object sender, RoutedEventArgs e)
        {
            var json = _transports.ToJson();
            File.WriteAllText("data.json",json);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _transports.RemoveAt(listView.SelectedIndex);
            listView.Items.Refresh();
        }
    }
}
