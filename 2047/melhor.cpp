#include <iostream>
#include <vector>

using namespace std;

// Função para contar os divisores de um número
int countDivisors(int num) {
    int count = 0;
    for (int i = 1; i <= num; ++i) {
        if (num % i == 0) {
            count++;
        }
    }
    return count;
}

int main() {
    int n;
    cin >> n;

    vector<int> sequence;

    // Construa a sequência
    for (int i = 2; i <= n; ++i) {
        int divisorsNeeded = countDivisors(i);

        // Se o número de divisores necessários for ímpar, adicione 1 à sequência,
        // caso contrário, adicione 2.
        sequence.push_back(divisorsNeeded % 2 == 1 ? 1 : 2);
    }

    // Verifique se a sequência é válida
    for (int i = 0; i < n; ++i) {
        int sum = 0;
        for (int j = 0; j <= i; ++j) {
            sum += sequence[j];
        }

        if (countDivisors(sum) != sequence[i]) {
            cout << "Impossivel" << endl;
            return 0;
        }
    }

    // Imprima a sequência
    for (int i = 0; i < n; ++i) {
        cout << sequence[i] << " ";
    }

    return 0;
}
