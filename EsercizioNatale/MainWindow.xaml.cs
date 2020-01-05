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
        private const string filenomi = @"filenomi.txt";
        private const string file_valido = @"fileValido.txt";
        private const string file_invalido = @"fileInvalido.txt";
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Vedi_Click(object sender, RoutedEventArgs e)
        {
            //divisione dei voti dal file
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
            }
            //divisione dei nomi dal file
            using (StreamReader rfile = new StreamReader(filenomivoti))
            {
                using (StreamWriter wnomi = new StreamWriter(filenomi))
                {
                    string wline = rfile.ReadLine();
                    while ((wline = rfile.ReadLine()) != null)
                    {
                        Console.WriteLine(wline);
                        {
                            int posizione = wline.IndexOf(",");
                            if (posizione >= 0)
                            {
                                string found = wline.Remove(posizione);
                                wnomi.WriteLine(found);
                            }
                        }
                    }
                }
            }
            //scrittura nel file dei voti validi
            using (StreamReader readvoti = new StreamReader(filevoti))
            {
                string linevoti = readvoti.ReadLine();

                using (StreamReader readnomi = new StreamReader(filenomi))
                {
                    string rline = readnomi.ReadLine();
                    using (StreamWriter validi = new StreamWriter(file_valido))
                    {
                        while ((rline = readnomi.ReadLine()) != null)
                        {
                            string nome = rline;
                            string virgola = ",";
                            double n;
                            n = double.Parse(linevoti);
                            if (n < 0 || n > 10)
                            {
                                validi.WriteLine("");
                            }
                            else
                            {
                                validi.WriteLine($"{nome}{virgola}{n}");
                            }
                            break;
                        }
                    }
                }
            }
            //scrittura nel file dei voti invalidi
            using (StreamReader readvoti = new StreamReader(filevoti))
            {
                string linevoti = readvoti.ReadLine();

                using (StreamReader readnomi = new StreamReader(filenomi))
                {
                    string rline = readnomi.ReadLine();
                    using (StreamWriter invalidivalidi = new StreamWriter(file_invalido))
                    {
                        while ((rline = readnomi.ReadLine()) != null)
                        {
                            string nome = rline;
                            string virgola = ",";
                            double n;
                            n = double.Parse(linevoti);
                            if (n > 0 || n < 10)
                            {
                                invalidivalidi.WriteLine("");
                            }
                            else
                            {
                                invalidivalidi.WriteLine($"{nome}{virgola}{n}");
                            }
                            break;
                        }
                    }
                }
            }
            //trovato il voto max
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
            //scrittura file valido nella list box
            using (StreamReader readvalidi = new StreamReader(file_valido))
            {
                string valido = readvalidi.ReadLine();
                while ((valido = readvalidi.ReadLine()) != null)
                {
                    LstVoti.Items.Add(valido.ToString());
                }
            }
        }
    }
}     