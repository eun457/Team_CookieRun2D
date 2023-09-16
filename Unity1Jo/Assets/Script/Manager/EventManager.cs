using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager //code by. ����
{
    public static readonly EventManager instance = new EventManager();

    public System.Action<int> onSelectBtnClick;
    public System.Action<int> onBuyBtnClick;
    public System.Action<int> showCookieExplain;

    private EventManager() { }
}
