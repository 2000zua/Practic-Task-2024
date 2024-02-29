using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        const double PI = Math.PI;
        double x, y;
        long n, i, ic = 0, MIN = long.MaxValue;
        SortedSet<(double angle, long index)> ang = new SortedSet<(double, long)>();
        List<List<long>> vv = new List<List<long>> { new List<long>(), new List<long>() };

        Console.Write("Informe o valor de N: ");
        if (!long.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Entrada inválida para N.");
            return;
        }

        // Entrada das coordenadas dos pontos
        for (i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            if (input.Length < 2 || !double.TryParse(input[0], out x) || !double.TryParse(input[1], out y))
            {
                Console.WriteLine("Entrada inválida para as coordenadas.");
                return;
            }

            // Armazenar as coordenadas nos vetores vv
            vv[0].Add((long)x);
            vv[1].Add((long)y);

            // Encontrar o ponto com a menor coordenada x (ponto central)
            if (x < MIN)
            {
                MIN = (long)x;
                ic = i;
            }
        }

        // Calcular os ângulos entre cada ponto e o ponto central
        for (long i = 0; i < n; i++)
        {
            if (i != ic)
            {
                double angle = Math.Atan2(vv[1][(int)i] - vv[1][(int)ic], vv[0][(int)i] - vv[0][(int)ic]);
                ang.Add((angle, i + 1));
            }
        }

        // Imprimir o índice do ponto central e o índice do ponto mais distante
        Console.WriteLine($"{ic + 1} {ang.ElementAt((int)n / 2 - 1).index}");
    }
}
