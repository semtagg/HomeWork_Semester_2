#include <iostream>
#include "cmath"

using namespace std;

int h_a_simple(int A, int D) {
    int One = 1;
    for (int i = 1; i < A; ++i) {
        One = One * 10 + 1;
    }
    return One % D;
}

int main() {
    cout << h_a_simple(1, 2) << endl;
    cout << h_a_simple(2, 3) << endl;
    cout << h_a_simple(3, 4) << endl;
    cout << h_a_simple(4, 5) << endl;
    return 0;
}
