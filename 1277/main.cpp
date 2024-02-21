#include <stdio.h>
#include <vector>
#include <queue>
#include <cstring>

std::vector<int> a[101]; // Adjacency lists
int c[101], f[101], l[101]; // Cost, flow, levels

int K, N, M, S, F, x, y;

int bfs(int node) {
    // Sets up the level graph
    std::queue<int> q;
    std::memset(l, 0, sizeof(l));
    q.push(node);
    l[node] = 1;
    while(!q.empty()) {
        int n = q.front();
        q.pop();
        for(auto v : a[n])
            if(c[v] > f[v] && !l[v])
                q.push(v), l[v] = l[n] + 1;
    }
    return l[F];
}

int dfs(int n, int flow) {
    // Finds some augmenting flow in the level graph
    if(n == F)
        return flow;
    int sum = 0;
    for(auto v : a[n]) {
        if(l[v] == l[n] + 1) {
            int fl = dfs(v, std::min(c[v]-f[v], flow));
            sum += fl;
            flow -= fl;
            f[v] += fl;
        }
    }
    return sum;
}

int main() {
    scanf("%d %d %d %d %d", &K, &N, &M, &S, &F);

    for(int i = 1; i <= N; i++)
        scanf("%d", &c[i]);

    c[S] = c[F] = 10000;

    for(int i = 1; i <= M; i++) {
        scanf("%d %d", &x, &y);
        a[x].push_back(y);
        a[y].push_back(x);
    }

    int sum = 0;
    if(F == S)
        return printf("NO"), 0;
    while(bfs(S))
        sum += dfs(S, 10000);
    printf(K < sum ? "NO" : "YES");
}