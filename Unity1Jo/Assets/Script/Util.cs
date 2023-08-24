using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    //code by.��ȣ
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>(); // T Ÿ���� ������Ʈ�� ���� 
        if (component == null) // ������Ʈ�� ���ٸ� 
            component = go.AddComponent<T>(); // �߰��ϰ� 
        return component; // component ��ȯ 
    }
}
