// 命令行处理
#ifndef _COMMANDLINE_H
#define _COMMANDLINE_H

extern "C"
{
#include "lua.h"
#include "lauxlib.h"
#include "lualib.h"
}

using namespace std;

#include <string>
#include <map>
#include <list>

class CommandLine
{
public:
	static void Init();
	// 等待用户的命令输入
	static void Wait4Command(bool fromlua = false);
	static char* GetInput();
	// 列出所有断点
	static list<pair<string, pair<int, bool>>> ListBreakPoint();
	// 是否命中断点
	static bool HitBreakPoint(std::string filename, int lineno)
	{
		map<string, map<int, bool>>::iterator it = breakpoints.find(filename);
		if (it != breakpoints.end())
		{
			map<int, bool>::iterator it2 = it->second.find(lineno);
			if (it2 != it->second.end())
			{
				return it2->second;
			}
		}
		return false;
	}

	static void InsertBreakPoint(string filename, int lineno)
	{
		map<string, map<int, bool>>::iterator it = breakpoints.find(filename);
		if (it != breakpoints.end())
		{
			it->second.insert(make_pair(lineno, true));
		}
		else
		{
			map<int, bool> tmp;
			tmp.insert(make_pair(lineno, true));
			breakpoints.insert(make_pair(filename, tmp));
		}
	}

	static bool stepState; // 是否单步执行
	static bool isrunning; // 调试的程序正在运行


private:
	static map<string, map<int, bool>> breakpoints;//断点记录

};


#endif