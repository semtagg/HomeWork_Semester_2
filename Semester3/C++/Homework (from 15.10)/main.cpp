#include <iostream>

using namespace std;

int **create(int rows, int col) {
    int **res = new int *[rows];

    for (int i = 0; i < rows; i++) {
        res[i] = new int[col];
    }

    return res;
}

void rand(int **arr, int rows, int col) {
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < col; ++j) {
            arr[i][j] = rand() % 40 + 10;
        }
    }
}

void print(int **arr, int rows, int col) {
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < col; ++j) {
            cout << arr[i][j] << "  ";
        }
        cout << "\n";
    }
}

int main() {
    int rows, col;
    cin >> rows >> col;
    auto arr = create(rows, col);
    rand(arr, rows, col);
    print(arr, rows, col);
    return 0;
}
