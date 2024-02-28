#include <iostream>

using namespace std;

// definir a dois array for take a data
int arrayForInput[10050];
int arrayForManipu[10050];

int main() {
    cout <<"How many element add to the array: ";
    int n;
    scanf("%d", &n);
    int s = 0;
    arrayForManipu[0] = 0;
    for (int i=0; i<n; i++) {
        printf("[%d]=", i);
        scanf("%d", &arrayForInput[i]);
        s+=arrayForInput[i];
        arrayForManipu[i+1]=s;
    }
    for (int i=0; i<n+1; i++) {
        for (int j=0; j<i; j++) {
            if ((arrayForManipu[i]-arrayForManipu[j])%n==0) {
                printf("Size of subset: %d\n", i-j);
                printf("Subset = [");
                for (int k=j; k<i; k++)
                    printf(" %d ", arrayForInput[k]);
                printf("] => %d\n", n);
                return 0;
            }
        }
    }
    
    printf("0\n");
    
	return 0;
}