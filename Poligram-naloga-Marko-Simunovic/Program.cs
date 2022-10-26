using System;

namespace Naloga
{

    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {

                System.Console.WriteLine("Poligram - Naloge - Marko Simunovic");
                System.Console.WriteLine("Izberite nalogo:");
                System.Console.WriteLine("1. Naloga 1");
                System.Console.WriteLine("2. Naloga 2");
                System.Console.WriteLine("3. Naloga 3");
                string? inputString = Console.ReadLine();
                if (inputString != null)
                {
                    try
                    {
                        int selection = int.Parse(inputString);
                        switch (selection)
                        {
                            case 1:
                                Naloga1 n1 = new Naloga1();
                                n1.execute();
                                break;
                            case 2:
                                Naloga2 n2 = new Naloga2();
                                n2.execute();
                                break;
                            case 3:
                                Naloga3 n3 = new Naloga3();
                                n3.execute();
                                break;
                            default:
                                break;
                        }
                    }
                    catch (System.Exception)
                    {
                        break;
                    }
                }
                else break;
            }

            // Naloga1 n1 = new Naloga1();
            // n1.execute();
            // Naloga2 n2 = new Naloga2();
            // var watch = new System.Diagnostics.Stopwatch();
            // watch.Start();
            // Naloga3 n3 = new Naloga3();
            // Random random = new Random();
            // for (int i = 0; i < 1000; i++)
            // {
            //     // n2.execute();
            //     n3.execute(random.Next(10, 51));
            //     // System.Console.WriteLine(n2.analyse());
            // }
            // watch.Stop();
            // System.Console.WriteLine((double)watch.ElapsedMilliseconds / 1000);

            // n3.execute();
        }
    }
}