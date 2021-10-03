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

void task4_2(int &x, int &y) {
    x = x ^ y;
    y = x ^ y;
    x = x ^ y;
}

int task4_3(int x) {
    return x << 3;
}

void task5(int t, float v, float &s1, float &s2, float &s) {
    s1 = t * v;
    s2 = t * v / 2;
    s = s1 + s2;
}

int main() {
    task1(1);

    cout << "Task 2: " << task2(16, 2) << endl;

    cout << "Task 3: " << task3(20, 2) << endl;

    cout << "Task 4.1: " << task4_1(1) << endl;

    int x = 1, y = 2;
    task4_2(x, y);
    cout << "Task 4.2: x = " << x << " ,y = " << y << endl;

    cout << "Task 4.3: " << task4_3(5) << endl;

    float a, b, c;
    task5(10, 5, a, b, c);
    cout << a << " " << b << " " << c << endl;

    return 0;
}
