using Singleton.Component;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : SingletonComponent<UIManager>
{
    [SerializeField] private GameObject Root;
    [SerializeField] private List<UIBase> uiPrefabs = new List<UIBase>(); // UI 프리팹 목록

    private Dictionary<string, UIBase> dic = new Dictionary<string, UIBase>();
    private Dictionary<string, UIBase> openedDic = new Dictionary<string, UIBase>();
    private Stack<UIBase> stack = new Stack<UIBase>();

    

    #region Singleton
    protected override void AwakeInstance()
    {
        Initialize();
    }

    protected override bool InitInstance()
    {
        for(int i = 0; i < uiPrefabs.Count; i++)
        {
            UIBase ui = uiPrefabs[i];
            if (ui == null) continue;
            string name = ui.GetType().Name;
            if (!dic.ContainsKey(name))
            {
                dic.Add(name, ui);
            }
        }

        return true;
    }

    protected override void ReleaseInstance()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        if (Instance != this)
            Destroy(gameObject); // 중복 인스턴스 방지
    }
    #endregion

    public T GetUI<T>() where T : UIBase
    {
        string name = typeof(T).Name;
        if (openedDic.ContainsKey(name))
            return openedDic[name] as T;

        return null;
    }

    public T OpenUI<T>() where T : UIBase
    {
        string name = typeof(T).Name;
        UIBase ui = GameObject.Instantiate(dic[name]);
        stack.Push(ui);
        openedDic.Add(name, ui);
        ui.transform.SetParent(Root.transform);
        var rt = ui.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;
        rt.sizeDelta = Vector2.zero;
        return ui as T;
    }

    public void CloseUI(UIBase ui)
    {
        if (stack.Count == 0) return;
        if (stack.Peek() != ui) return;
        CloseUI();
    }

    public void CloseUI()
    {
        if (stack.Count == 0) return;
        UIBase ui = stack.Pop();
        openedDic.Remove(ui.GetType().Name);
        GameObject.Destroy(ui.gameObject);
    }
}
