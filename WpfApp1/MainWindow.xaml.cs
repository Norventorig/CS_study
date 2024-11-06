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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> images_source;
        private int current_index = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadImages(@"C:\Users\123\Desktop\images");
            DisplayImage();
        }

        private void LoadImages(string path)
        {
            if (Directory.Exists(path))
            {
                images_source = new List<string>();
                images_source.AddRange(Directory.GetFiles((path), "*.jpg"));
                images_source.AddRange(Directory.GetFiles((path), "*.png"));
                images_source.AddRange(Directory.GetFiles((path), "*.jfif"));
            }
        }

        private void DisplayImage()
        {
            if (images_source == null || images_source.Count == 0)
            {
                MessageBox.Show("Нету картинок");
                return;
            }

            var image_path = images_source[current_index];
            IMAGE.Source = new BitmapImage(new Uri(image_path));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            this.Close();
        }

        private void MenuItemClick_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (current_index == images_source.Count - 1)
            {
                current_index = 0;
            }

            else
            {
                current_index++;
            }

            DisplayImage();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (current_index == 0)
            {
                current_index = images_source.Count - 1;
            }

            else
            {
                current_index--;
            }

            DisplayImage();
        }
    }
}
