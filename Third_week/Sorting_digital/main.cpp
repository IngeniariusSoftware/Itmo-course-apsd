#include "edx-io.hpp"
using namespace std;

int main()
{
	int strCount, strLength, depth;
	io >> strCount >> strLength >> depth;

	int* index_chars = new  int[strCount];
	int* buffer = new int[strCount];

	char** char_list = new char*[strLength];

	for (int i = 0; i < strLength; ++i)
	{
		char_list[i] = new char[strCount];
		for (int j = 0; j < strCount; ++j)
			io >> char_list[i][j];

	}
	for (int i = 0; i < strCount; ++i)
		index_chars[i] = i + 1;

	for (int i = strLength - 1; i >= strLength - depth; i--)
	{

		int bucket[26]{ 0 };
		for (int j = 0; j < strCount; ++j)
			bucket[char_list[i][j] - 97]++;
		for (int j = 1; j < 26; ++j)
			bucket[j] += bucket[j - 1];

		for (int j = strCount - 1; j >= 0; j--)
		{
			unsigned char symbol = char_list[i][index_chars[j] - 1];
			buffer[--bucket[symbol - 97]] = index_chars[j];
		}

		for (int j = 0; j < strCount; ++j)
			index_chars[j] = buffer[j];
	}

	for (int i = 0; i < strCount; ++i)
		io << index_chars[i] << " ";
}