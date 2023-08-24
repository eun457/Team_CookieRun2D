using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollView : MonoBehaviour
{
    [SerializeField] Transform contentTrans;
    [SerializeField] GameObject itemPrefab;

    public void Initialize()
    {
        List<MycookiesData> list = HE_DataManager.instance.GetMycookiesDatas();

        foreach (MycookiesData data in list)
        {
            if (data.type == 0)
            {
                AddCookies(data);
                //lock
            }
            else if (data.type == 1)
            {
                AddCookies(data);
                //unlock
            }
        }
    }
    public void AddCookies(MycookiesData data)
    {
        //������ �ν��Ͻ� ����, contentTrans �ڽ����� ����
        var go = Instantiate(itemPrefab, contentTrans);
        UIScrollViewCookiesSelect cookies = go.GetComponent<UIScrollViewCookiesSelect>();

        cookies.Initialize(data);

        cookies.selectBtn.onClick.AddListener(() => {
            Debug.LogFormat("�� ĳ����(id:{0}) ����", cookies.id);

            //Event�߻�
            EventManager.instance.onSelectBtnClick();
        });
        cookies.buyBtn.onClick.AddListener(() => {
            Debug.LogFormat("�� ĳ����(id:{0}) ����", cookies.id);

            //Event�߻�
            EventManager.instance.onBuyBtnClick(cookies.id);
        });
    }
}
