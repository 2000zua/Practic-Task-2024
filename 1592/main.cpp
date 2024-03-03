#include <stdio.h>
#include <vector>
#include <algorithm>
#include <numeric>

int main(){
    // Define um alias 'uint' para 'unsigned int'
    using uint = unsigned int;

    // Declara variáveis para armazenar o número de eventos (n), horas (h), minutos (m), e segundos (s)
    uint n, h, m, s;

    // Declara um vetor 'v' para armazenar os tempos convertidos para segundos
    std::vector<uint> v;

    // Lê o número de eventos
    printf("Input the number of event: ");
    scanf("%u", &n);

    // Loop para ler os tempos de cada evento e convertê-los para segundos
    for(uint i = 0; i < n; i++){
        printf("Input the time [%d]: ", i+1);
        scanf("%u:%u:%u", &h, &m, &s), v.push_back((s + 60*(m+60*h))%(12*60*60));
    }
        

    // Ordena os tempos em ordem crescente
    std::sort(v.begin(), v.end());

    // Calcula o somatório total de tempo disponível ao longo das 12 horas
    uint sum = 12*60*60*n - std::accumulate(v.begin(), v.end(), 0);

    // Inicializa variáveis para encontrar o melhor momento para realizar um evento
    uint min = std::numeric_limits<uint>::max(), mint = 0, prev = 0;

    // Loop para calcular o momento mais adequado para realizar um evento
    for(uint i = 0; i < n; prev = v[i++])
        if((sum += n*(v[i]-prev) - 12*60*60) < min)
            mint = v[i], min = sum;

    // Se o momento mais adequado for antes de 1 hora (3600 segundos), ajusta para 12 horas depois
    if(mint < 3600)
        mint += 3600*12;

    // Imprime o momento mais adequado no formato hh:mm:ss
    printf("%u:%02u:%02u", mint/3600, mint/60%60, mint%60);
}
