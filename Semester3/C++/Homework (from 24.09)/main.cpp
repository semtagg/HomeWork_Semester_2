#include <iostream>

using namespace std;

int medium(int x, int y) {
    int result = 0;
    while (y != 0) {
        if (y & 1){
            int x1 = x;
            while (x1 != 0)
            {
                int result1 = result & x1;
                result = result ^ x1;
                x1 = result1 << 1;
            }
        }

        y = y >> 1;
        x = x << 1;
    }

    return result;
}

int main() {
    int x, y;
    cin >> x >> y;
    cout << medium(x, y);
    return 0;
}
