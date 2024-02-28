# Solicitar ao usuário a quantidade de elementos a serem adicionados ao array
n = int(input("How many elements to add to the array: "))

# Inicializar listas para armazenar os elementos e as somas prefixas
array_for_input = []
array_for_manipu = []

# Receber os elementos do usuário, calcular as somas prefixas e armazenar os 
#elementos fornecidos
s = 0
for i in range(n):
    element = int(input(f"[{i}] = "))
    array_for_input.append(element)
    s += element
    array_for_manipu.append(s)

# Iterar sobre as somas prefixas para encontrar um subconjunto cuja soma é um 
#múltiplo de n
for i in range(n + 1):
    for j in range(i):
        if (array_for_manipu[i] - array_for_manipu[j]) % n == 0:
            # Exibir o tamanho do subconjunto e seus elementos
            subset_size = i - j
            print(f"Size of subset: {subset_size}")
            print("Subset =", array_for_input[j:i])
            print("=>", n)
            exit(0)

# Se nenhum subconjunto for encontrado
print("0")
