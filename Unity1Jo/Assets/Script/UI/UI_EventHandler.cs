using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnPointerDownHandler = null;
    public Action<PointerEventData> OnPointerUpHandler = null;


    //code by.��ȣ
    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null) // ���� ��û ������ 
        {
            OnClickHandler.Invoke(eventData); // �������� Invoke�� event �ѷ��ֱ�  

        }
    }

    //code by.��ȣ
    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnPointerDownHandler != null) // ���� ��û ������ 
        {
            //Debug.Log("OnPointerDown");
            OnPointerDownHandler.Invoke(eventData); // �������� Invoke�� event �ѷ��ֱ�  

        }
    }

    //code by.��ȣ
    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnPointerUpHandler != null) // ���� ��û ������ 
        {
            //Debug.Log("OnPointerUp");
            OnPointerUpHandler.Invoke(eventData); // �������� Invoke�� event �ѷ��ֱ�    
        }
    }
}
