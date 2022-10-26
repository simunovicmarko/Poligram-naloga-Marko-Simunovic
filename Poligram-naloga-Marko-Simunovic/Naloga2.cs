namespace Naloga
{
    class Naloga2
    {
        struct Pole
        {
            public double xi;
            public double hi;
        }

        struct Line
        {
            public double k;
            public double n;
        }

        private static int numberOfPoles = 6;
        private static Pole[] poles = {
            new Pole(){xi = 0, hi = 0.1},
            new Pole(){xi = 0.1, hi = 0.4},
            new Pole(){xi = 0.5, hi = 0.6},
            new Pole(){xi = 0.6, hi = 0.9},
            new Pole(){xi = 0.7, hi = 0.1},
            new Pole(){xi = 0.8, hi = 1},
        };

        private Pole[] GeneratePoles(int length = 10)
        {
            Pole[] poles = new Pole[length];

            Random random = new Random();
            poles[0] = new Pole() { xi = 0, hi = random.NextDouble() };
            double previous = 0;
            for (int i = 1; i < length; i++)
            {
                double x = ((double)random.Next(1, 3)) / 10;
                poles[i] = new Pole() { xi = previous + x, hi = random.NextDouble() };
                previous += x;
            }

            return poles;
        }




        private static Line calculateLine(double x1, double y1, double x2, double y2)
        {
            double a = (y2 - y1) / (x2 - x1);
            double b = y1 - a * x1;
            return new Line() { k = a, n = b };
        }

        private static bool pointLiesBelowALine(double x, double y, Line line)
        {
            return y < (line.k * x + line.n);
        }


        private KeyValuePair<string, string> Split(string input)
        {
            string[] output = input.Split(' ', 2);
            return new KeyValuePair<string, string>(output[0], output[1]);
        }


        private void UI()
        {
            System.Console.WriteLine("Vnesite število drogov:");
            numberOfPoles = int.Parse(Console.ReadLine());
            poles = new Pole[numberOfPoles];
            for (int i = 0; i < numberOfPoles; i++)
            {
                System.Console.WriteLine("Vnesite oddaljenost droga in njegovo višino:");
                string? input = Console.ReadLine();
                if (input != null)
                {
                    input = input.Replace('.', ',');
                    KeyValuePair<string, string> coordinates = Split(input);
                    double x = Convert.ToDouble(coordinates.Key);
                    double y = Convert.ToDouble(coordinates.Value);
                    poles[i] = new Pole() { xi = x, hi = y };
                }
            }
        }

        public int execute()
        {
            UI();

            int counter = 2;
            Pole firstPole = poles[0];
            Pole lastPole = poles[poles.Length - 1];
            Line lineFromFirstToLastPole = calculateLine(firstPole.xi, firstPole.hi, lastPole.xi, lastPole.hi);

            for (int i = 1; i < poles.Length - 1; i++)
            {
                Pole pole = poles[i];
                if (!pointLiesBelowALine(pole.xi, pole.hi, lineFromFirstToLastPole))
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
            return counter;
        }

    }
}