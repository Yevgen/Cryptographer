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

namespace Lab_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int left = 'a';
        const int right = 'z';
        const int lenght = right - left;

        Cryptographer _cryptographer = new Cryptographer();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Encryptions_Click(object sender, RoutedEventArgs e)
        {
            string encrText = "";
            try
            {
                encrText = _cryptographer.Encryptions(OriginalText.Text, BoxOfKey.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            IncriptedText.Text = encrText;
        }
        private void ButtonDecryptions_Click(object sender, RoutedEventArgs e)
        {
            string decryptText = "";
            try
            {
                decryptText = _cryptographer.Decryptions(IncriptedText.Text,BoxOfKey2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DecryptedText.Text = decryptText;
        }

    }
}
