using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extensions 
{
    /*====================================*/
    // Extension Ŭ������ �Լ��� ���� ������ ���� ���� �����ϴ� Ŭ�����̴�.
    // ������ this�� ����Ѵ�.

    //code by.��ȣ
    //public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
    //{
    //    return Util.GetOrAddComponent<T>(go);
    //}

    //code by.��ȣ
    public static void AddUIEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventBase.AddUIEvent(go, action, type);
    }
}
