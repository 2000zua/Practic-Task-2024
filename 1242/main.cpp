#include <iostream>
#include <vector>
using namespace std;

// Grafo representado como uma lista de adjacência para dois conjuntos de vértices 
//(grafo bipartido)
vector<vector<vector<int>>> g(1001, vector <vector <int>> (2)); 

// Vetor para rastrear os vértices já visitados durante a DFS
vector<bool> used(1001);

// Função de DFS para explorar o grafo a partir de um vértice e conjunto específicos
void dfs(int v, int gi) {
    used[v] = true;
    for (vector<int>::iterator i = g[v][gi].begin(); i != g[v][gi].end(); ++i)
        if (!used[*i])
            dfs(*i, gi);
}

int main() {
    int n, l, r;
    cin >> n;

    // Leitura das arestas do grafo bipartido
    for (;;) {
        if (!(cin >> l >> r)) {
            // Limpa os flags de erro e ignora a entrada até o próximo número
            cin.clear();
            cin.ignore(6, 'D');
            break;
        }
        // Adiciona arestas nos dois conjuntos do grafo bipartido
        g[l][0].push_back(r);
        g[r][1].push_back(l);
    }

    // Leitura dos vértices para iniciar as buscas DFS
    while (cin >> l) {
        // Realiza busca DFS a partir do vértice l em ambos os conjuntos
        dfs(l, 0);
        dfs(l, 1);
    }

    // Verifica quais vértices não foram alcançados durante as buscas DFS
    bool notfound = true;
    for (int i = 1; i <= n; i++) {
        if (!used[i]) {
            cout << i << ' '; // Imprime vértices não alcançados
            notfound = false;
        }
    }

    // Se todos os vértices foram alcançados, imprime 0
    if (notfound)
        cout << 0;

    return 0;
}
