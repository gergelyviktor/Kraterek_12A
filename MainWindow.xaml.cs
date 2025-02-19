using System;
using System.Collections.Generic;
using System.IO;
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

namespace Kraterek_12A {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        List<Krater> lista = new List<Krater>();
        public MainWindow() {
            InitializeComponent();
            // 1. feladat
            beolvas();
            // 2. feladat
            label2.Content = "2. feladat\n" + lista.Count;
        }

        private void beolvas() {
            using (var sr = new StreamReader("felszin.txt")) {
                while (!sr.EndOfStream) {
                    var sor = sr.ReadLine().Split('\t');
                    var krater = new Krater(double.Parse(sor[0]), double.Parse(sor[1]), double.Parse(sor[2]), sor[3]);
                    lista.Add(krater);
                }
            }
        }
    }
}
