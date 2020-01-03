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
using System.IO;

namespace EsercizioNatale
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string file = "file.txt";
        private const string file_valido = "FileValido.txt";
        private const string file_invalido = "FileInvalido.txt";
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Vedi_Click(object sender, RoutedEventArgs e)
        {
            int result = Convert.ToInt32(file.Substring(file.LastIndexOf(',') + 1));
            if (File.Exists(file))
            {
                StreamReader r = new StreamReader(file, Encoding.UTF8);
                var sLine = "";
                while (sLine != null)
                {
                    sLine = r.ReadLine();
                    if (sLine != null)
                    {
                        if (!LstVoti.Items.Contains(sLine))
                        {
                            LstVoti.Items.Add(sLine);
                        }
                    }
                }
                r.Close();
            }
            //double max = 0;
            // c = 0;
            //do
            //{
               // if (result > max)
               // {
                   // max = result;
               //     c++;
             //   }
            //} while (c >= n);

        }
    }
}     