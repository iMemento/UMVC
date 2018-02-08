using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Client.UI.Common;

public class MenuType
{
    public string Path { get; private set; }

    MenuType(string path)
    {
        Path = path;
    }

    public static readonly MenuType Main = new MenuType("UIPrefabs/Main");
    public static readonly MenuType Chat = new MenuType("UIPrefabs/Chat");
}

public class MainUIMenuManager
{
    public static MainUIMenuManager Instance
    { 
        get
        {
            if (sInstance == null)
            {
                sInstance = new MainUIMenuManager();
            }

            return sInstance;
        }
    }

    private static MainUIMenuManager sInstance;

    private Stack<MenuType> stack = new Stack<MenuType>();
    private Stack<object[]> parameterStack = new Stack<object[]>();

    private MenuType currentMenu = MenuType.Main;
    private object[] currentParameters;

    private Dictionary<MenuType, MenuBaseController> menuDic = new Dictionary<MenuType, MenuBaseController>();

    

    private void ChangeMenu(MenuType menu, bool isBack, params object[] args)
    {
        if (menuDic.ContainsKey(currentMenu))
        {
            menuDic[currentMenu].Hide();
        }

        if (!isBack)
        {
            stack.Push(currentMenu);
            parameterStack.Push(currentParameters);
        }

        if (!menuDic.ContainsKey(menu))
        {
            menuDic[menu] = Create(menu);
        }

        menuDic[menu].Show();
        menuDic[menu].Refresh(args);

        currentMenu = menu;
        currentParameters = args;
    }


    private MenuBaseController Create(MenuType menu)
    {
        var prefab = Resources.Load(menu.Path) as GameObject;
        var go = GameObject.Instantiate(prefab);
        var rt = go.GetComponent<RectTransform>();

        rt.SetParent(MainCanvas.Root.RectTransform);
        rt.offsetMin = new Vector2(0f, 0f);
        rt.offsetMax = new Vector2(0f, -140f);

        return go.GetComponent<MenuBaseController>();
    }

    public void ChangeToMenu(MenuType menu, params object[] args)
    {
        ChangeMenu(menu, false, args);
    }

    public void Back()
    {
        if (stack.Count > 0)
        {
            ChangeMenu(stack.Pop(), true, parameterStack.Pop());
        }
    }

    public void StartUp()
    {
        ChangeToMenu(MenuType.Main);
    }

}
