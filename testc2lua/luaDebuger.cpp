// luaDebugger.cpp : �������̨Ӧ�ó�������
//

#include "commandline.h"

int main(int argc, char* argv[])
{
	CommandLine::Init();
	CommandLine::Wait4Command(false);
	return 0;
}

