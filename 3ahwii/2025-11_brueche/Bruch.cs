namespace _2025_11_brueche;

internal class Bruch
    {
        // jetzt kommen die sog. "Attribute" der Klasse oder "Felder"
        private int _ganz;
        private int _zaehler;
        private int _nenner;

        public Bruch(string bruchtext)
        {
            String[] teile1 = bruchtext.Split(' ');
            this._ganz = int.Parse(teile1[0]);
            String[] teile = teile1[1].Split('/');
            this._zaehler = int.Parse(teile[0]);
            this._nenner = int.Parse(teile[1]);
        }

        private Bruch(int ganz, int zaehler, int nenner)
        {
            this._ganz = ganz;
            this._zaehler = zaehler;
            this._nenner = nenner;
            this.Kuerze();
        }

        private void Kuerze()
        {
            var g = Gcd(this._zaehler, this._nenner);
            this._zaehler /= g;
            this._nenner /= g;
            this._ganz += this._zaehler / this._nenner;
            this._zaehler %= this._nenner;
        }

        private static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public Bruch Addiere(Bruch b)
        {
            var a = this;
            return new Bruch(a._ganz + b._ganz, a._zaehler * b._nenner + b._zaehler * a._nenner, a._nenner * b._nenner);
        }

        public override string ToString()
        {
            return $"{this._ganz} {this._zaehler}/{this._nenner}";
            // JS: return `ich bin ein bruch: ${this.zaehler}/${this.nenner}`;
        }
    }
