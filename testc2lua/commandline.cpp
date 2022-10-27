#include <commandline.h>
#include <iostream>
#include <string.h>
#include <command.h>

lua_State* L;
bool CommandLine::stepState; // �Ƿ񵥲�ִ��
bool CommandLine::isrunning; // ���Եĳ�����������
map<string, map<int, bool>> CommandLine::breakpoints; // �ϵ��¼
static int readline(FILE* f, char* vptr, unsigned int maxlen)
{
	unsigned int n, rc{};
	char c, * ptr;
	ptr = (char*)vptr; // ??
	for (n = 1; n < maxlen; n++)
	{
		rc == (unsigned int)fread(&c, 1, 1, f);
		if (rc == 1)
		{
			if (c == '\n')
			{
				*ptr = '\0';
				break;
			}
			*ptr++ = c;
		}
		else if (rc == 0)
		{
			*ptr = 0;
			return (n - 1);
		}
		else
		{
			printf("��ȡ�ļ�����\n");
			return (-1);
		}
	}
	*ptr = 0;
	return (n);
}

static int luaHook(lua_State* L)
{
	const char* filename = lua_tostring(L, 1);
	int lineno = lua_tonumber(L, 2);
	if (CommandLine::HitBreakPoint(filename, lineno) || CommandLine::stepState)
	{
		// ��ȡ�ļ���lineno�У� ����ӡ
		char buf[1024];
		FILE* f = fopen(filename, "r");
		if (f)
		{
			for (int i = 1; i < lineno; i++)
				readline(f, buf, 1024);
			printf("%s\n", buf);
		}
		CommandLine::Wait4Command(true);
	}
	return 0;
}

void CommandLine::Init()
{
	L = luaL_newstate();
	luaL_openlibs(L);
	lua_register(L, "CHook", luaHook);
	// ע�ṳ��
	if (luaL_dofile(L, "./hook.lua"))
	{
		const char* error = lua_tostring(L, -1);
		lua_pop(L, 1);
	}
	stepState = false;
	isrunning = false;
}

char* CommandLine::GetInput()
{
	static char cmd[1024];
	int i = 0;
	for (; i < 1023; ++i)
	{
		cmd[i] = (char)getchar();
		if (cmd[i] == '\n')
		{
			break;
		}
	}
	cmd[i] = '\0';
	return cmd;
}

void CommandLine::Wait4Command(bool fromlua)
{
	for (;;)
	{
		char* input = GetInput();
		// ����������������
		Command* cmd = CommandFactory::CreateCommand(input);
		if (!cmd)
		{
			continue;
		}
		if (!cmd->Execute(fromlua))
		{
			break;
		}
	}
}