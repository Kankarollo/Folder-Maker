using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Forms;
using System.IO;

namespace Folderomat
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path;
        private static SolidColorBrush acceptBrush = new SolidColorBrush(Color.FromArgb(70, 17, 182, 62));
        private static SolidColorBrush errorBrush = new SolidColorBrush(Color.FromArgb(70, 214, 44, 44));

        public MainWindow()
        {
            InitializeComponent();
            Play_White.Play();
        }

        private void FolderDialog_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            path = dialog.SelectedPath;
            if (path != "")
                FolderDialog.Background = acceptBrush;
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                ValidateButton.Background = acceptBrush;
                Start.IsEnabled = true;
                ResultTextBlock.Text = "Input is Valid!";
                Play_White.Stop();
                The_Rules.Play();
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int folderNumber = 1;
            string name = FolderName.Text + "_" + folderNumber;
            string newPath = path + "\\" + name;
            while (folderNumber < Convert.ToInt32(Amount.Text) + 1)
            {
                try
                {
                    Directory.CreateDirectory(newPath);
                    folderNumber++;
                    name = FolderName.Text + "_" + folderNumber;
                    newPath = path + "\\" + name;
                }
                catch (Exception)
                {
                    ResultTextBlock.Text = "Failed to create folder at /n" + newPath;
                }
            }
            Start.Background = acceptBrush;
            ResultTextBlock.Text = "Success!";
        }

        private bool Validate()
        {
            bool folderNameCheck = false;
            bool amountCheck = false;

            if (FolderName.Text != "")
            {
                folderNameCheck = true;
                FolderName.Background = acceptBrush;
            }
            else
                FolderName.Background = errorBrush;

            if (int.TryParse(Amount.Text, out int number))
            {
                if (number > 0)
                {
                    amountCheck = true;
                    Amount.Background = acceptBrush;
                }
                else
                    Amount.Background = errorBrush;
            }
            else
                Amount.Background = errorBrush;

            return (folderNameCheck && amountCheck);
        }
    }
}

