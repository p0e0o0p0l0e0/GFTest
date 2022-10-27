// luaDebugger.cpp : 定义控制台应用程序的入口
//

#include "commandline.h"

int main(int argc, char* argv[])
{
	CommandLine::Init();
	CommandLine::Wait4Command(false);
	return 0;
}

