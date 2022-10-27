// �����д���
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
	// �ȴ��û�����������
	static void Wait4Command(bool fromlua = false);
	static char* GetInput();
	// �г����жϵ�
	static list<pair<string, pair<int, bool>>> ListBreakPoint();
	// �Ƿ����жϵ�
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

	static bool stepState; // �Ƿ񵥲�ִ��
	static bool isrunning; // ���Եĳ�����������


private:
	static map<string, map<int, bool>> breakpoints;//�ϵ��¼

};


#endif