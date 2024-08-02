using Microsoft.Win32;
using Notepad.ViewModels;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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
            saveFileDialog.Title = "另存为";
            saveFileDialog.Filter = "Text files|*.txt";
            saveFileDialog.AddExtension = true;
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                File.WriteAllText(saveFileDialog.FileName, txtContent.Text, Encoding.UTF8);
            }
        }

        private void openFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开文件";
            openFileDialog.Filter = "Text files|*.txt";
            openFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                txtContent.Text = File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
            }
        }

        private void textWrapButton_Click(object sender, RoutedEventArgs e)
        {
            if (textWrapButton.IsChecked == true)
            {
                txtContent.TextWrapping = TextWrapping.Wrap;
                txtContent.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
            else
            {
                txtContent.TextWrapping = TextWrapping.NoWrap;
                txtContent.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
        }

        private void aboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            var aboutUsWindow = new AboutWindow();
            aboutUsWindow.ShowDialog();
        }
    }
}