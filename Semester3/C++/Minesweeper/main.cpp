#include <iostream>
#include <utility>
#include <vector>
using namespace std;

const int BEGINNER = 0;
const int INTERMEDIATE = 1;
const int ADVANCED = 2;
const int MAX_SIDE = 30;

int ROWS;
int COLUMNS;
int MINES;

// выбор уровня сложности
void chooseDifficultyLevel() {
    int level;

    cout << "Enter the Difficulty Level" << endl;
    cout << "Press 0 for BEGINNER     (9  * 9  cells and 10 mines)" << endl;
    cout << "Press 1 for INTERMEDIATE (16 * 16 cells and 40 mines)" << endl;
    cout << "Press 2 for ADVANCED     (16 * 30 cells and 99 mines)" << endl;

    cin >> level;

    if (level == BEGINNER) {
        ROWS = 9;
        COLUMNS = 9;
        MINES = 10;
    }

    else if (level == INTERMEDIATE) {
        ROWS = 16;
        COLUMNS = 16;
        MINES = 40;
    }

    else if (level == ADVANCED) {
        ROWS = 30;
        COLUMNS = 30;
        MINES = 99;
    }

    else {
        cout << "You entered the wrong number. Please try again." << endl << endl;
        chooseDifficultyLevel();
    }

    return;
}

// очищаем таблицы
void clearBoards(char mineBoard[][MAX_SIDE], char gameBoard[][MAX_SIDE]) {
    for (int i = 0; i < ROWS; i++)
        for (int j = 0; j < COLUMNS; j++)
            gameBoard[i][j] = mineBoard[i][j] = '.';

    return;
}

// размещение мин
void placeMines(char mineBoard[][MAX_SIDE], int mines) {
    int placed = 0;

    while (placed < mines) {
        // более-менее рандомное распределение мин
        int random = rand() % (ROWS * COLUMNS);
        int row = random / COLUMNS;
        int col = random % ROWS;

        if (mineBoard[row][col] == '#')
            continue;

        mineBoard[row][col] = '#';
        placed++;
    }

    return;
}

// меняем мину
void replaceMine(int row, int col, char mineBoard[][MAX_SIDE]) {
    // добавим одну мину
    placeMines(mineBoard, 1);

    // удаляем старую мину
    mineBoard[row][col] = '.';

    return;
}

char indexToChar(int index) {
    if (index < 10)
        return index + '0';
    else
        return 'a' + (index - 10);
}

int charToIndex(char ch) {
    if (ch <= '9')
        return ch - '0';
    else
        return (ch - 'a') + 10;
}

// отображение таблицы
void displayBoard(char gameBoard[][MAX_SIDE]) {
    // верхние индексы
    cout << "    ";
    for (int i = 0; i < COLUMNS; i++)
        cout << indexToChar(i) << ' ';
    cout << endl << endl;

    // боковые индексы и игровое поле
    for (int i = 0; i < ROWS; i++) {
        cout << indexToChar(i) << "   ";

        for (int j = 0; j < COLUMNS; j++)
            cout << gameBoard[i][j] << " ";

        cout << "  " << indexToChar(i);
        cout << endl;
    }

    // нижние индексы
    cout << endl << "    ";
    for (int i = 0; i < COLUMNS; i++)
        cout << indexToChar(i) << ' ';
    cout << endl;

    return;
}

bool isValid(int row, int col) {
    return (row >= 0) && (row < ROWS) && (col >= 0) && (col < COLUMNS);
}

// проверяем является данная ячайка миной или нет
bool isMine(int row, int col, char board[][MAX_SIDE]) {
    return (board[row][col] == '#');
}

// получаем соседние с данной ячейки
// в виде пар, где первое значение
// ряд, второе столбец
vector<pair<int, int>> getNeighbours(int row, int col) {
    vector<pair<int, int>> neighbours;

    for (int dx = -1; dx <= 1; dx++)
        for (int dy = -1; dy <= 1; dy++)
            if (dx != 0 || dy != 0)
                // проверяем что сосед существует
                if (isValid(row+dx, col+dy))
                    neighbours.push_back(make_pair(row+dx, col+dy));

    return neighbours;
}

// количество соседних мин
int countAdjacentMines(int row, int col, char mineBoard[][MAX_SIDE]) {
    // получаем соседий
    vector<pair<int, int>> neighbours = getNeighbours(row, col);

    int count = 0;
    for (int i = 0; i < neighbours.size(); i++)
        if (isMine(neighbours[i].first, neighbours[i].second, mineBoard))
            count++;

    return count;
}

// открывает ячейку
void uncoverBoard(char gameBoard[][MAX_SIDE], char mineBoard[][MAX_SIDE], int row, int col, int *movesCount) {
    (*movesCount)++;

    // вычисляем кол-во мин в соседних с данной 9 ячейках
    int count = countAdjacentMines(row, col, mineBoard);

    gameBoard[row][col] = count + '0';

    // если количество мин в соседних с данной ячейках равно 0
    // то открываем их все
    if (count == 0) {
        vector<pair<int, int>> neighbours = getNeighbours(row, col);

        for (int i = 0; i < neighbours.size(); i++)
            // открываем ячейки пока это возможно
            if (gameBoard[neighbours[i].first][neighbours[i].second] == '.')
                uncoverBoard(gameBoard, mineBoard, neighbours[i].first, neighbours[i].second, movesCount);
    }

    return;
}


// когда игра заканчивается победой:
// 1. сделано число шагов равное максимально возможному
// 2.
// в случае победы вскрываются все мины и помечаются флагами
// когда игра заканчивается поражением:
// 1. открыта ячейка которая была миной
// в случае поражения вскрываются все мины и помечаются, как взорваные
void markMines(char gameBoard[][MAX_SIDE], char mineBoard[][MAX_SIDE], bool won) {
    for (int i = 0; i < ROWS; i++) {
        for (int j = 0; j < COLUMNS; j++) {
            if (gameBoard[i][j] == '.' && mineBoard[i][j] == '#') {
                if (won) {
                    gameBoard[i][j] = 'F';
                }
                else {
                    gameBoard[i][j] = '#';
                }
            }
        }
    }
}

// основная функция
void playMinesweeper() {
    char mineBoard[MAX_SIDE][MAX_SIDE], gameBoard[MAX_SIDE][MAX_SIDE];
    int movesTotal = ROWS * COLUMNS - MINES;
    int flags = MINES;

    clearBoards(mineBoard, gameBoard);
    placeMines(mineBoard, MINES);

    int movesCount = 0;
    bool gameOver = false;

    // пока игра не завершена ...
    while (!gameOver) {
        displayBoard(gameBoard);
        cout << flags << " flags left" << endl << endl;

        // вводим координаты поля и что с ним сделать:
        // s - открыть ячейку
        // f - поставить флажок
        char x, y, z;
        cout << "Enter your move, (row, column, safe(s)/flag(f)) -> ";
        cin >> x >> y >> z;
        cout << endl;

        int row = charToIndex(x);
        int col = charToIndex(y);

        // нельзя проиграть первым ходом
        if (movesCount == 0)
            if (isMine(row, col, mineBoard))
                replaceMine(row, col, mineBoard);

        // s - открыть ячейку
        if (z == 's') {
            if (gameBoard[row][col] == '.' && mineBoard[row][col] == '.') {
                // открываем ячейку или ячейки
                // в случае, если количество мин в
                // соседних с данной ячейках равно нулю
                uncoverBoard(gameBoard, mineBoard, row, col, &movesCount);

                // если количество шагов равно
                // максимальному количеству шагов,
                // то игра заканчивается победой
                if (movesCount == movesTotal) {
                    markMines(gameBoard, mineBoard, true);
                    displayBoard(gameBoard);
                    cout << endl << "You won!!! :)" << endl;
                    gameOver = true;
                }
            }

            else if (gameBoard[row][col] == '.' && mineBoard[row][col] == '#') {
                // game over
                gameBoard[row][col] = '#';
                markMines(gameBoard, mineBoard, false);
                displayBoard(gameBoard);
                cout << endl << "You lost! :(" << endl;
                gameOver = true;
            }

            else {
                // пытаемся открыть ячейка, которая и так уже открыта
                cout << "Illegal move. ";
                if (gameBoard[row][col] == 'F')
                    cout << "Cell is a flag. Use f to toggle flag off. ";
                else
                    cout << "Cell is already a number. ";
                cout << endl;
            }
        }

        // f - поставить флаг
        if (z == 'f') {
            if (gameBoard[row][col] == '.') {
                if (flags != 0) {
                    gameBoard[row][col] = 'F';
                    flags--;
                }
                else {
                    cout << "Illegal move. Too many flags!" << endl;
                }
            }
            // можно убрать флаг
            else if (gameBoard[row][col] == 'F') {
                gameBoard[row][col] = '.';
                flags++;
            }
            else {
                cout << "Illegal move. Cell is a number. " << endl;
            }
        }
    }

    return;
}

int main() {
    srand(time(nullptr));

    chooseDifficultyLevel();

    playMinesweeper();

    return 0;
}
