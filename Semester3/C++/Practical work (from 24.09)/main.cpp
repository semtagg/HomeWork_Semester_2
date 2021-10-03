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

int task2(int x, int i) {
    return x | (1 << i);
}

int task3(int x, int i) {
    return x & ~(1 << i);
}

bool task4_1(int x) {
    return ~x & 1;
}

void task4_2(int& x, int& y){
    x = x ^ y;
    y = x ^ y;
    x = x ^ y;
}

int task4_3(int x)
{
    return x << 3;
}

int main() {
    task1(1);
    cout << task2(16, 2) << endl;
    cout << task3(20, 2) << endl;


    return 0;
}
