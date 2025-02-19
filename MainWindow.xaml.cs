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
            //var max = lista.Max(item => item.R);
            // 4. feladat
            var max = lista[0].R;
            var nev = lista[0].Nev;
            foreach (var item in lista) {
                if (item.R > max) {
                    max = item.R;
                    nev = item.Nev;
                }
            }
            label4.Content = $"A legnagyobb kráter neve és sugara: {nev}, {max}";
            //double tav = tavolsag(100.0,50.0,200.0,80.0);
            // 6. feladat
            //combobox1.ItemsSource = lista;
            foreach (var item in lista) {
                comboBox1.Items.Add(item.Nev);
            }
            // 8. feladat - fájlba írás
            using (var sw = new StreamWriter("terulet.txt")) {
                foreach (var item in lista) {
                    var terulet = item.R * item.R * Math.PI;
                    sw.WriteLine(Math.Round(terulet, 2) + "\t" + item.Nev);
                }
            }
        }


        // 5. feladat
        private double tavolsag(double x1, double y1, double x2, double y2) {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
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

        private void button1_Click(object sender, RoutedEventArgs e) {
            // 3. feladat
            var index = -1;
            foreach (var item in lista) {
                if (item.Nev == textBox1.Text) {
                    // megvan
                    index = lista.IndexOf(item);
                    break;
                }
            }
            if (index >= 0) {
                label3.Content = lista[index].ToString();
                // $"A(z) {item.Nev} középpontja X={item.X} Y={item.Y} sugara R={item.R}."
            }
            else
                label3.Content = "Nincs ilyen nevű kráter!";
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // 6. feladat
            var x = -1.0;
            var y = -1.0;
            var r = -1.0;
            foreach (var item in lista) {
                if (item.Nev == comboBox1.SelectedItem.ToString()) {
                    x = item.X;
                    y = item.Y;
                    r = item.R;
                    break;
                }
            }
            label6.Content = "";
            foreach (var item in lista) {
                if (tavolsag(x, y, item.X, item.Y) > (r + item.R)) {
                    label6.Content += item.Nev + "\n";
                }

            }
        }
    }
}

