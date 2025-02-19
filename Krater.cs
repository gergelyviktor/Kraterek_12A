using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraterek_12A {
    internal class Krater {
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
        public string Nev { get; set; }

        public Krater(double x, double y, double r, string nev) {
            X = x;
            Y = y;
            R = r;
            Nev = nev;
        }

        public override string ToString() {
            return $"{Nev} - Középpont: {X},{Y}, Sugár: {R}";
        }
    }
}
