// testc2lua.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
extern "C"
{
#include "lua.h"
#include "lauxlib.h"
#include "llimits.h"
#include <lstate.h>
#include <lualib.h>
}

using namespace std;

//int main(int argc, char* argv[])
//{
//    lua_State* pState = luaL_newstate();
//    luaL_openlibs(pState);
//    if (nullptr == pState)
//    {
//        cout << "Lua 初始化失败" << endl;
//        return -1;
//    }
//
//    if (luaL_loadfile(pState, "./test.lua"))
//    {
//        cout << "Lua 文件加载失败" << endl;
//    }
//    else
//    {
//        if (lua_pcall(pState, 0, 0, 0))
//        {
//            cerr << lua_tostring(pState, -1) << endl;
//        }
//        else
//        {
//            
//            /*lua_getglobal(pState, "mystr");
//            string str = lua_tostring(pState, -1);
//            cout << str << endl;
//
//            lua_getglobal(pState, "myTable");
//            lua_getfield(pState, -1, "name");
//            cout << lua_tostring(pState, -1) << endl;
//
//            lua_getglobal(pState, "myTable");
//            lua_getfield(pState, -1, "id");
//            cout << lua_tonumber(pState, -1) << endl;*/
//
//            lua_getglobal(pState, "RunPPP");
//            lua_pcall(pState, 0, 0, 0);
//
//        }
//    }
//    lua_close(pState);
//    std::cout << "Hello World!\n";
//}