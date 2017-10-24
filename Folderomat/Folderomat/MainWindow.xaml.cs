using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using System.IO;

namespace Folderomat
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string path;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void fileSelect_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            path = dialog.SelectedPath;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int folderNumber = 1;
            string name = folderName.Text + "_" + folderNumber;
            string newPath = path + "\\" + name;
            while (folderNumber < Convert.ToInt32(amount.Text) + 1)
            {
                try
                {
                    Directory.CreateDirectory(newPath);
                    folderNumber++;
                    name = folderName.Text + "_" + folderNumber;
                    newPath = path + "\\" + name;
                }
                catch (Exception)
                {
                    log.Text = "fail to make directory at " + newPath;
                }
                
            }
        }
    }
}
