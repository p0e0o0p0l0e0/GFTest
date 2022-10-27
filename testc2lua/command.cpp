#include "command.h"
#include "commandline.h"
#include <stdio.h>
#include <string.h>
#include <lua.h>
#include <stdlib.h>

extern lua_State* L;

bool CommandStart::Execute(bool callfromlua)
{
	if (CommandLine::isrunning)
	{
		printf("�����Ѿ�������\n");
		return true;
	}
	CommandLine::isrunning = true;
	// ִ��lua�ļ�
	if (luaL_dofile(L, para)) {
		const char* error = lua_tostring(L, -1);
		lua_pop(L, 1);
	}
	CommandLine::isrunning = false;
	printf("������ֹ\n");
	return true;
}

bool CommandBreak::Execute(bool callfromlua)
{
	const char* filename = strtok(para, ":");
	const char* line = strtok(NULL, ":");
	if (!filename || !line)
	{
		printf("�ϵ����벻��ȷ\n");
		return true;
	}
	int lineno = atol(line);
	CommandLine::InsertBreakPoint(filename, lineno);
	return true;
}

bool CommandStep::Execute(bool callfromlua)
{
	if (!CommandLine::isrunning)
	{
		printf("�������г���\n");
		return true;
	}
	CommandLine::stepState = true;
	return false;
}

bool CommandContinue::Execute(bool callfromlua)
{
	CommandLine::stepState = false;
	if (callfromlua)
		return false;
	return true;
}

bool CommandExit::Execute(bool callfromlua)
{
	printf("��ȷ��Ҫ�Ƴ���������? (y:��, n:��)");
	int c = getchar();
	if (c == 'y' || c == 'Y')
	{
		exit(0);
	}
	return false;
}

bool CommandPrint::Execute(bool callfromlua)
{
	lua_getglobal(L, "printlocal");
	lua_pushstring(L, valname);
	if (lua_pcall(L, 1, 0, 0) != 0)
	{
		const char* error = lua_tostring(L, -1);
		printf("%s\n", error);
		lua_pop(L, 1);
	}
	return true;
}

Command* CommandFactory::CreateCommand(char* commandline)
{
	char* cmd = strtok(commandline, " ");
	if (!cmd || strcmp("", cmd) == 0)
	{
		return NULL;
	}
	if (strcmp("start", cmd) == 0)
	{
		char* para = strtok(NULL, " ");
		return new CommandStart(para);
	}
	else if (strcmp("exit", cmd) == 0 || strcmp("e", cmd) == 0)
	{
		return new CommandExit();
	}
	else if (strcmp("break", cmd) == 0 || strcmp("b", cmd) == 0)
	{
		char* para = strtok(NULL, " ");
		return new CommandBreak(para);
	}
	else if (strcmp("step", cmd) == 0 || strcmp("s", cmd) == 0)
	{
		return new CommandStep();
	}
	else if (strcmp("continue", cmd) == 0 || strcmp("c", cmd) == 0)
	{
		return new CommandContinue();
	}
	else if (strcmp("print", cmd) == 0 || strcmp("p", cmd) == 0)
	{
		char* para = strtok(NULL, " ");
		return new CommandPrint(para);
	}
	return NULL;
}