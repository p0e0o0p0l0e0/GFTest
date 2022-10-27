#pragma once
#ifndef _COMMAND_H
#define _COMMAND_H

/* 命令参数说明
命令	参数
start	filename	:启动执行一个lua文件
list/l	filename	:显示文件内容
break/b	filename:lineno	:在filename的lineno设置断点
step/s		:单步执行
continue		:继续执行
exit/e		:退出调试器
stop		:停止调试
print/p	variable	:打印变量值
*/

class CommandLine;

// 命令基类

class Command
{
public:
	Command() {}
	virtual bool Execute(bool callfromlua) = 0; // 执行命令
};

class CommandStart : public Command
{
public:
	CommandStart(char *para): para(para) {}
	bool Execute(bool callfromlua);
private:
	char* para; //命令参数
};

class CommandExit : public Command
{
public:
	CommandExit() {}
	bool Execute(bool callfromlua);
};

class CommandBreak : public Command
{
public:
	CommandBreak(char* para) : para(para) {}
	bool Execute(bool callfromlua);
private:
	char* para; //命令参数
};

class CommandStep : public Command
{
public:
	CommandStep() {}
	bool Execute(bool callfromlua);
};

class CommandContinue : public Command
{
public:
	CommandContinue() {}
	bool Execute(bool callfromlua);
};

class CommandPrint : public Command
{
public:
	CommandPrint(char* valname) : valname(valname) {}
	bool Execute(bool callfromlua);
private:
	char* valname; //命令参数
};

class CommandFactory
{
public:
	static Command* CreateCommand(char* commandline);
};


#endif