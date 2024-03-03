#include <stdio.h>

// Array para armazenar o número de divisores para cada valor de 1 até 1586335
int ndivs[1586336], ans[100001];

int main() {
    int n, sum = 1586335;

    // Calcula o número de divisores para cada número de 1 até 1586335
    for (int i = 1; i <= sum; i++)
        for (int j = i; j <= sum; j += i)
            ndivs[j]++;

    // Calcula os primeiros 100000 números cujos divisores somam 1586335
    for (int i = 100000; i > 0; i--)
        ans[i] = ndivs[sum], sum -= ans[i];

    // Lê o valor de 'n' a ser impresso
    scanf("%d", &n);

    // Imprime os primeiros 'n' números cujos divisores somam 1586335
    for (int i = 1; i <= n; i++)
        printf("%d ", ans[i]);

    return 0;
}
