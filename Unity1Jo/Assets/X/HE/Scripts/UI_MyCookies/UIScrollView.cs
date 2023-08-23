using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollView : MonoBehaviour
{
    [SerializeField] Transform contentTrans;
    [SerializeField] GameObject itemPrefab;

    public void Initialize()
    {
        //i���� ������ �����ϸ� ��ũ�Ѻ信 ��Ű������ �������� �ø� �� ����
        //Cookie 5�� ����(�⺻, �ٴٿ��� ...)
        for (int i = 0; i <50; i++)
        {
            AddCookies();
        }
    }
    public void AddCookies()
    {
        //������ �ν��Ͻ� ����, contentTrans �ڽ����� ����
        var go = Instantiate(itemPrefab, contentTrans);
        UIScrollViewCookiesSelect cookies = go.GetComponent<UIScrollViewCookiesSelect>();
        cookies.selectBtn.onClick.AddListener(() => { Debug.Log("�� ĳ���� ����"); });
        cookies.buyBtn.onClick.AddListener(() => { Debug.Log("�� ĳ���� ����"); });
    }
}
