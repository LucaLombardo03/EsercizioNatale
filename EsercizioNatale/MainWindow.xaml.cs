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

        private void ReadFile()
        {
            if (File.Exists(file))
            {    
                try
                {
                    using (StreamReader r = new StreamReader(file, Encoding.UTF8))
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            lblresult.Content=(line);
                        }
                    }
                }
                catch
                {

                }
            }   
        }
    }
}