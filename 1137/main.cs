using System;
using System.Collections.Generic;

// Definição da classe Vertex, que representa um vértice no grafo
class Vertex
{
    public List<Vertex> Out { get; set; } = new List<Vertex>(); // Lista de vértices de saída (vizinhos)
    public int N { get; set; } // Número identificador do vértice
}

class Program
{
    // Função Explore realiza uma busca em profundidade (DFS) no grafo a partir de um vértice dado
    static void Explore(Vertex u, List<Vertex> ans)
    {
        ans.Add(u); // Adiciona o vértice atual à lista de resposta
        Queue<Vertex> q = new Queue<Vertex>(); // Fila para explorar os vizinhos em largura
        Vertex v = u;

        // Explora os vizinhos em largura, adicionando-os à fila
        while (v.Out.Count > 0)
        {
            Vertex w = v.Out[^1]; // ^1 notation obtém o último elemento da lista
            v.Out.RemoveAt(v.Out.Count - 1);
            v = w;
            q.Enqueue(v);
        }

        // Para todos os vértices na fila, realiza chamadas recursivas para a função Explore
        while (q.Count > 0)
        {
            Explore(q.Dequeue(), ans);
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Vertex> v = new List<Vertex>(10001); // Lista de vértices (armazenamento)

        // Inicializa a lista de vértices
        for (int i = 0; i < 10001; i++)
        {
            v.Add(new Vertex());
        }

        int last = 0, tot = 0;

        // Processa as entradas para construir o grafo direcionado
        for (int i = 0; i < n; i++)
        {
            int m = int.Parse(Console.ReadLine());
            int u;
            int.TryParse(Console.ReadLine(), out last);

            // Constrói as arestas direcionadas com base nas entradas
            for (int j = 1; j <= m; j++)
            {
                int.TryParse(Console.ReadLine(), out u);
                v[u].N = u;
                v[last].Out.Add(v[u]);
                last = u;
            }
        }

        List<Vertex> ans = new List<Vertex>();
        Explore(v[last], ans); // Inicia a DFS a partir do último vértice da última sequência

        // Imprime o número total de vértices visitados e a lista de vértices visitados
        Console.Write($"{ans.Count - 1} ");
        foreach (var vertex in ans)
        {
            Console.Write($"{vertex.N} ");
        }
    }
}
