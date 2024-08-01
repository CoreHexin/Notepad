using Microsoft.Win32;
using Notepad.ViewModels;
using System.IO;
using System.Text;
using System.Windows;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save data in text file";
            saveFileDialog.Filter = "Text files|*.txt";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                File.WriteAllText(saveFileDialog.FileName, txtContent.Text, Encoding.UTF8);
            }
        }
    }
}