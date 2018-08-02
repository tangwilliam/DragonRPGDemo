using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    private LuaEngine _luaEngine;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    public LuaEngine luaEngine{ get { return _luaEngine; }}

    void Awake()
    {
        _instance = this;
        // 设置为切换场景不被销毁的属性
        GameObject.DontDestroyOnLoad(gameObject);
        Init();
    }

    /// <summary>
    /// 游戏管理器的初始化步骤
    /// </summary>
    void Init()
    {
        _luaEngine = gameObject.AddComponent<LuaEngine>();
    }
}