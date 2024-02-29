using System;
using System.Collections.Generic;
using System.Numerics;

class Program{
    static BigInteger[,,] C; // Matriz tridimensional para armazenar resultados intermediários da função A
    static bool[,,] calced; // Matriz tridimensional para rastrear se um determinado valor já foi calculado

    static BigInteger A(int i, int j, int k)
    {
        // Função recursiva para calcular um valor relacionado a uma fórmula combinatória
        if (i == 0 && j == 0 && k == 0)
            return 1;
        else if (i < 0)
            return 0;
        else
        {
            if (!calced[i, j, k])
            {
                // Memoização: Armazenar resultados intermediários para evitar recálculos
                C[i, j, k] = j * A(j - 1, Math.Min(i, k), Math.Max(i, k)) + k * A(k - 1, Math.Min(i, j), Math.Max(i, j));
                calced[i, j, k] = true;
            }
            return C[i, j, k];
        }
    }

    static BigInteger B(int i, int j, int k)
    {
        // Função recursiva que utiliza resultados da função A para calcular um valor final
        if (i < 0)
            return 0;
        else
            return A(i, Math.Min(j, k), Math.Max(j, k)) - (i * B(i - 1, j, k));
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        C = new BigInteger[31, 31, 31]; // Inicializa a matriz tridimensional
        calced = new bool[31, 31, 31]; // Inicializa a matriz tridimensional

        // Chama a função B para calcular o valor relacionado à fórmula combinatória e imprime o resultado
        Console.WriteLine((B(N - 1, N, N) / 2).ToString());
    }
}
