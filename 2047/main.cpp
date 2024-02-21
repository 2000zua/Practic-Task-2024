#include <stdio.h>

int ndivs[1586336], ans[100001];

int main()
{
    int n, sum = 1586335;
    for(int i = 1; i <= sum; i++) // Calculates the number of divisors
        for(int j = i; j <= sum; j += i)
            ndivs[j]++;

    for(int i = 100000; i > 0; i--)
        ans[i] = ndivs[sum], sum -= ans[i];

    scanf("%d", &n);
    for(int i = 1; i <= n; i++)
        printf("%d ", ans[i]);
}