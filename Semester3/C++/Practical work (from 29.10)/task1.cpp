#include <iostream>
#include <string>

using namespace std;

string getBinNumber(int number) {
    string binNumber = "";

    while (number != 0) {
        binNumber = to_string(number % 2) + binNumber;
        number /= 2;
    }

    return binNumber;
}

bool isPal(int number) {
    string binNumber = getBinNumber(number);

    for (int i = 0; i < binNumber.length() / 2; i++) {
        if (binNumber[i] != binNumber[binNumber.length() - 1 - i]) {
            return false;
        }
    }

    return true;
}

int main() {
    int number;
    cin >> number;
    cout << isPal(number);
    return 0;
}
