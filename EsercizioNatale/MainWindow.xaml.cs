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
        private const string filenomivoti = @"filenomivoti.txt";
        private const string filevoti = @"filevoti.txt";
        private const string file_valido = @"FileValido.txt";
        private const string file_invalido = @"FileInvalido.txt";
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Vedi_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader rfile = new StreamReader(filenomivoti))
            {
                using (StreamWriter wvoti = new StreamWriter(filevoti))
                {
                    string sline = rfile.ReadLine();
                    while ((sline = rfile.ReadLine()) != null)
                    {
                        int found = 0;
                        Console.WriteLine(sline);
                        {
                            found = sline.IndexOf(",");
                            wvoti.WriteLine("{0}", sline.Substring(found + 1));
                        }
                    }
                }
                using (StreamReader readvoti = new StreamReader(filevoti))
                {
                    string linevoti = readvoti.ReadLine();
                    double max = 0;
                    double a = double.Parse(linevoti);
                    while ((linevoti = readvoti.ReadLine()) != null)
                    {
                        if (a > 0 && a <= 10 && a > max)
                        {
                            max = a;
                        }
                    }
                    LblMax.Content = (max);
                }
            }
                /*using (StreamReader readfile = new StreamReader(filenomivoti)) 
                {
                    string sline = readfile.ReadLine();
                    while (sLine != null)
                    {
                        sLine = file.ReadLine();
                        if (sLine != null)
                        {
                            if (!LstVoti.Items.Contains(sLine))
                            {
                                LstVoti.Items.Add(sLine);
                            }
                        }
                    }
                    file.Close();
                }      
                
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
            //} while (c >= n);*/

        }
    }
}     