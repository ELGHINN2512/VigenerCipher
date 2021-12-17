using Microsoft.Win32;
using System.IO;
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
using System.Windows.Shapes;

namespace VigenereCipher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultTextBox.Text = VigenereСipherRus.Encrypt(startTextBox.Text, keyTextBox.Text);
            }
            catch (Exception ex)
            {
                resultTextBox.Text = ex.Message;
            }
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultTextBox.Text = VigenereСipherRus.Decrypt(startTextBox.Text, keyTextBox.Text);
            }
            catch(Exception ex)
            {
                resultTextBox.Text = ex.Message;
            }
        }

        private void downloadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый файл (*.txt)|*.txt";
            openFileDialog.Title = "Загрузка содержимого из файла";
            if (openFileDialog.ShowDialog() == true)
            {
                if(openFileDialog.FileName.EndsWith(".txt"))
                    startTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Сохранение результата в файл";
            if(saveFileDialog.ShowDialog() == true)
            {
                File.AppendAllText(saveFileDialog.FileName,resultTextBox.Text);
            }
        }
    }
}
