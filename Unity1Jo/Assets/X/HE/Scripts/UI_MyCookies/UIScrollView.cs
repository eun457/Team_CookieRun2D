using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollView : MonoBehaviour
{
    [SerializeField] Transform contentTrans;
    [SerializeField] GameObject cookiePrefab;

    public void Initialize()
    {
        //MycookiesData�� ���ִ� List�� ���޹޾Ƽ� Cookie�� ����
        List<MycookiesData> list = HE_DataManager.instance.GetMycookiesDatas();

        foreach (MycookiesData data in list)
        {
            //create
            AddCookies(data);
        }
    }

    //Cookies ����
    public void AddCookies(MycookiesData data)
    {
        //������ �ν��Ͻ� ����, contentTrans �ڽ����� ����
        var go = Instantiate(cookiePrefab, contentTrans);
        UIScrollViewCookiesSelect cookies = go.GetComponent<UIScrollViewCookiesSelect>();

        cookies.Initialize(data);

        //�� ��ư�� ������ �ش� cookies�� id�� EventManager���� ����
        cookies.selectBtn.onClick.AddListener(() => {
            EventManager.instance.onSelectBtnClick(cookies.id);
        });
        cookies.buyBtn.onClick.AddListener(() => {
            EventManager.instance.onBuyBtnClick(cookies.id);
        });
    }
}
