#include<iostream>


int main()
{
	int x = 1;
	int y = 2;
	y = x + (x = y);
	printf("%d", y);
	return 0;
}