using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
/// <summary>
/// tolua 启动入口，将此脚本动态绑定到一个不销毁的 GameObject 上，通常跟游戏的 GameManager 绑在同物体上
/// </summary>
public class LuaEngine : LuaClient
{
    
    protected override LuaFileUtils InitLoader()
    {
        return new LuaResLoader();
    }

    /// <summary>
    /// 可添加或修改搜索 lua 文件的目录
    /// </summary>
    protected override void LoadLuaFiles()
    {
#if UNITY_EDITOR
        // 添加编辑器环境下获取 lua 脚本的路径（Assets/lua）
        luaState.AddSearchPath(Application.dataPath + "/lua");

#endif



        OnLoadFinished();
    }


    private void Start()
    {
        luaState.DoFile("test_unity_api.lua");


        CallLuaFunction();
    }

    void CallLuaFunction(){

        LuaFunction luaFunc = luaState.GetFunction("CalcAddTwoNumFunc");

        if (luaFunc != null)
        {
            int a = 1;
            int b = 3;
            print(" Calc By Lua : result of " + a + " and " + b + " = " + CallFuncWithTwoIntParam(luaFunc, a, b));

            int c = 3;
            int d = 5;
            print(" Calc By Lua : result of " + c + " and " + d + " = " + CallFuncWithTwoIntParam(luaFunc, c, d));

            
            //int num = luaFunc.Invoke<int, int>(123456);
            //Debugger.Log("generic call return: {0}", num);

            //num = CallFunc();
            //Debugger.Log("expansion call return: {0}", num);

            //Func<int, int> Func = luaFunc.ToDelegate<Func<int, int>>();
            //num = Func(123456);
            //Debugger.Log("Delegate call return: {0}", num);

            //num = lua.Invoke<int, int>("test.luaFunc", 123456, true);
            //Debugger.Log("luastate call return: {0}", num);
        }
    }

    int CallFuncWithTwoIntParam( LuaFunction function,  int a, int b )
    {
        function.BeginPCall();
        function.Push(a);
        function.Push(b);
        function.PCall();
        int num = (int)function.CheckNumber();
        function.EndPCall();
        return num;
    }
}