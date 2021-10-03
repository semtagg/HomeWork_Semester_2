#include <iostream>

using namespace std;

void task1(int n) {
    if (n < 0)
        cerr << "Degree can't be negative." << endl;

    switch (n) {
        case 0:
            cout << "sin(x)" << endl;
            break;
        case 1:
            cout << "cos(x)" << endl;
            break;
        case 2:
            cout << "-sin(x)" << endl;
            break;
        case 3:
            cout << "-cos(x)" << endl;
            break;
    }
}


int main() {
    task1(1);
    return 0;
}
