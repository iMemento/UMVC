using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour {

    public static MainCanvas Root;

    private void Awake()
    {
        Root = this;
        MainUIMenuManager.Instance.StartUp();
    }

    private void OnDestroy()
    {
        Root = null;
    }

    public RectTransform RectTransform { get { return GetComponent<RectTransform>(); } }
}
