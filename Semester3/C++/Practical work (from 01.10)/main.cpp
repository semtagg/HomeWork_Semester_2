#include <iostream>
#include "cmath"
#include <algorithm>

using namespace std;

float e_a(int a, int S) {
    return (float) 2 * S / a;
}

int e_b(int r, float x, float y) {
    return r * r - (x * x + y * y) >= -10e-6 ? 1 : 0;
}

bool e_c(int m, int f) {
    for (int i = 0; i < m; i++)
        if (i * i % m == f)
            return true;
    return false;
}

int e_d(int y, int m, int d) {
    if (m < 3)
        y--, m += 12;
    return 365 * y + y / 4 - y / 100 + y / 400 + (153 * m - 457) / 5 + d - 306;
}

unsigned int gcd(unsigned int n1, unsigned int n2) {
    return (n2 == 0) ? n1 : gcd(n2, n1 % n2);
}

int m_a(int v1, int v2, int v3) {
    if (v3 > v1 + v2)
        return false;
    else if (v1 == v3 || v2 == v3 || v1 + v2 == v3)
        return true;
    else
        return v3 % gcd(v1, v2) == 0;
}

bool is_prime(int x) {
    int p = 2;
    while (p * p <= x) {
        if (x % p == 0)
            return false;
        p++;
    }
    return true;
}

bool m_2(int a, int b) {
    if (a / 2 < b)
        return false;

}

int h_a_simple(int A, int D) {
    int One = 1;
    for (int i = 1; i < A; ++i) {
        One = One * 10 + 1;
    }
    return One % D;
}

int main() {
    cout << e_a(10, 12) << endl;
    cout << e_b(1, 0.8, 0.6) << endl;
    cout << e_d(2001, 3, 1) - e_d(2001, 2, 1) << endl;
    cout << m_a(3, 5, 4) << endl;

    return 0;
}
