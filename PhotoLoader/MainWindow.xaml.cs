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

namespace PhotoLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        byte[] imgDataSmall = new byte[1];
        byte[] imgDataBig = new byte[1];
        int id = 0;

        private void btnLoadSmall_Click(object sender, RoutedEventArgs e)
        {
            imgDataSmall = new byte[1];

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                FileStream filestream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                imgDataSmall = new byte[filestream.Length];
                filestream.Read(imgDataSmall, 0, (int)filestream.Length);
                //    img1.Source = UploadPhoto(imgData);
                filestream.Close();
            }



            // img1.Source = UploadPhoto(imgData);
        }

        private void btnLoadBig_Click(object sender, RoutedEventArgs e)
        {
            imgDataBig = new byte[1];

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                FileStream filestream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                imgDataBig = new byte[filestream.Length];
                filestream.Read(imgDataBig, 0, (int)filestream.Length);
                //    img1.Source = UploadPhoto(imgData);
                filestream.Close();
            }
        }

        private void tbID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbID.Text == "")
                return;

            id = Convert.ToInt32(tbID.Text);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRecordsDB.AddPhoto(id, imgDataSmall, imgDataBig);
        }
    }
}
