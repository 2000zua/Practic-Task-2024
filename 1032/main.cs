using System;

class Program
{
    static void Main()
    {
        // Solicitar ao usuário a quantidade de elementos a serem adicionados ao 
        //array
        Console.Write("How many elements to add to the array: ");
        int n = int.Parse(Console.ReadLine());

        // Inicializar arrays para armazenar os elementos e as somas prefixas
        int[] arrayForInput = new int[n];
        int[] arrayForManipu = new int[n + 1];
        
        // Receber os elementos do usuário, calcular as somas prefixas e armazenar 
        //os elementos fornecidos
        int s = 0;
        arrayForManipu[0] = 0;
        for (int i = 0; i < n; i++)
        {
            Console.Write($"[{i}] = ");
            arrayForInput[i] = int.Parse(Console.ReadLine());
            s += arrayForInput[i];
            arrayForManipu[i + 1] = s;
        }

        // Iterar sobre as somas prefixas para encontrar um subconjunto cuja 
        //soma é um múltiplo de n
        for (int i = 0; i < n + 1; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if ((arrayForManipu[i] - arrayForManipu[j]) % n == 0)
                {
                    // Exibir o tamanho do subconjunto e seus elementos
                    int subsetSize = i - j;
                    Console.WriteLine($"Size of subset: {subsetSize}");
                    Console.Write("Subset = [");
                    for (int k = j; k < i; k++)
                    {
                        Console.Write($" {arrayForInput[k]} ");
                    }
                    Console.WriteLine($"] => {n}");
                    return;
                }
            }
        }

        // Se nenhum subconjunto for encontrado
        Console.WriteLine("0");
    }
}
