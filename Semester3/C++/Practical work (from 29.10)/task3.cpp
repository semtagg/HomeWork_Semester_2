#include <iostream>

using namespace std;

int singleNumber() {
    int n;
    int result = 0;

    while (cin >> n) {
        result ^= n;
    }

    return result;
}

int main() {
    cout << singleNumber();
    return 0;
}
