#pragma once
#ifndef _COMMAND_H
#define _COMMAND_H

/* �������˵��
����	����
start	filename	:����ִ��һ��lua�ļ�
list/l	filename	:��ʾ�ļ�����
break/b	filename:lineno	:��filename��lineno���öϵ�
step/s		:����ִ��
continue		:����ִ��
exit/e		:�˳�������
stop		:ֹͣ����
print/p	variable	:��ӡ����ֵ
*/

class CommandLine;

// �������

class Command
{
public:
	Command() {}
	virtual bool Execute(bool callfromlua) = 0; // ִ������
};

class CommandStart : public Command
{
public:
	CommandStart(char *para): para(para) {}
	bool Execute(bool callfromlua);
private:
	char* para; //�������
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
	char* para; //�������
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
	char* valname; //�������
};

class CommandFactory
{
public:
	static Command* CreateCommand(char* commandline);
};


#endif