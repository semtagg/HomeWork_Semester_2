#include <iostream>
#include <string>
#include <cmath>
#include <ctime>
#define NO_OF_CHARS 256 

using namespace std;

void badCharHeuristic(string str, int size,
	int badchar[NO_OF_CHARS])
{
	int i;

	for (i = 0; i < NO_OF_CHARS; i++)
		badchar[i] = -1;
 
	for (i = 0; i < size; i++)
		badchar[(int)str[i]] = i;
}

// Boyer-Moore algorithm
int customSearch(string txt, string pattern)
{
	int m = pattern.size();
	int n = txt.size();

	int badchar[NO_OF_CHARS];

	badCharHeuristic(pattern, m, badchar);

	int s = 0;
	int count = 0;

	while (s <= (n - m))
	{
		int j = m - 1;

		while (j >= 0 && pattern[j] == txt[s + j])
			j--;

		if (j < 0)
		{
			count++;
			s += (s + m < n) ? m - badchar[txt[s + m]] : 1;
		}
		else
			s += max(1, j - badchar[txt[s + j]]);
	}

	return count;
}

int integratedSearch(string txt, string pattern) {
	int count = 0;
	size_t str = txt.find(pattern);
	
	while (str != string::npos)
	{
		count++;
		str = txt.find(pattern, str + pattern.length());
	}
	return count;
}

int main()
{
	string txt = "ATAATTACCAACATCATAATTACCAACATCATAATTACCAACATCATAATTACCAACATCATC";
	string patterns[5] = { "AACA", "ATAA", "ATTA", "CAAC", "TACC" };

	unsigned int start_time_1 = clock();
	
	for (size_t i = 0; i < 5; i++)
	{
		cout << patterns[i] << " " << customSearch(txt, patterns[i]) << endl;
	}

	unsigned int end_time_1 = clock();
	
	cout<< "Custom alg time: " << end_time_1 - start_time_1 << endl;

	unsigned int start_time_2 = clock();

	for (size_t i = 0; i < 5; i++)
	{
		cout << patterns[i] << " " << integratedSearch(txt, patterns[i]) << endl;
	}

	unsigned int end_time_2 = clock();

	cout << "Integrated alg time: " << end_time_2 - start_time_2 << endl;

	return 0;
}