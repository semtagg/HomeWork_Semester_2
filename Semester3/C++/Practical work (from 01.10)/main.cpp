#include <iostream>
#include "cmath"

using namespace std;

float e_a(int a, int S) {
    return (float) 2 * S / a;
}

int e_b(int r, float x, float y) {
    return r * r - (x * x + y * y) >= -10e-6 ? 1 : 0;
}

int e_d (int y, int m, int d) {
    if (m < 3)
        y--, m += 12;
    return 365*y + y/4 - y/100 + y/400 + (153*m - 457)/5 + d - 306;
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
    cout << e_d(2001,3,1) - e_d(2001,2,1);
    return 0;
}
