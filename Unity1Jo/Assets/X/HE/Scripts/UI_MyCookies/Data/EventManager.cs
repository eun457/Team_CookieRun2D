using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MYCOOKIES������ ����/���� ��ư�� Ŭ������ �� UIScrollView���� MYCOOKIES_Main���� ��ư�� ���� ������ �Ѱ��ֱ� ���� �Ŵ��� 
public class EventManager //code by. ����
{
    public static readonly EventManager instance = new EventManager();

    public System.Action<int> onSelectBtnClick;
    public System.Action<int> onBuyBtnClick;

    private EventManager() { }
}
