def gera_sequencia(n):
    sequencia = []

    # Inicializa a sequência com os primeiros n números primos
    for i in range(1, n+1):
        sequencia.append(i)

    # Preenche o restante da sequência com números compostos
    for i in range(n+1, 2 * n + 1):
        sequencia.append(i)

    # Verifica a condição para a soma dos subconjuntos
    for k in range(2, n+1):
        soma = sum(sequencia[:k])
        divisores_soma = contar_divisores(soma)
        
        if divisores_soma != k:
            return "Impossível"

    return sequencia

def contar_divisores(numero):
    # Implemente a lógica para contar o número de divisores de 'numero'
    # Esta função depende de como você decide implementar o cálculo de divisores
    pass

# Leitura do valor de n
n = int(input())
resultado = gera_sequencia(n)

if resultado == "Impossível":
    print("Impossível")
else:
    print(" ".join(map(str, resultado)))
