#include <iostream>

using namespace std;

int pairSearch(int *arr, int size) {
    int count = 0;

    for (int i = size - 1; i > 0; i--) {
        for (int j = i - 1; j >= 0; j--) {
            if (arr[i] < arr[j])
                count++;
        }
    }

    return count;
}

int main() {
    int size;
    cin >> size;
    int *arr = new int[size];

    for (int i = 0; i < size; ++i) {
        cin >> arr[i];
    }

    cout << pairSearch(arr, size);

    return 0;
}
