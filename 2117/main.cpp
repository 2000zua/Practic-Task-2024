#include <stdio.h>
#include <cmath>
#include <tuple>

using ll = long long;

std::pair<ll, bool> fac(const ll n) {
    // Returns either a square factor of n, or a non-square factor
    for(ll i = 2, lim = std::pow(n, 1.0/3) + 0.5; i <= lim; i++)
        if(!(n%(i*i)))
            return { i, true };
        else if(!(n%i))
            return { i, false };

    if(ll s = std::sqrt(n) + 0.5; s*s == n)
        return { s, true };

    return { 1, true };
}

int main() {
    ll C, ans = 1;
    scanf("%lld", &C);
    while(C != 0) {
        // Keep shaving off factors of C
        auto [p, t] = fac(C);
        if(t) {
            C /= (p*p);
            ans *= p;
        } else
            C /= p;
        if(p == 1)
            break;
    }
    printf("%lld", ans/2+1);
}