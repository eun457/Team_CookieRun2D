using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MYCOOKIES_Main : MonoBehaviour //code by. ����
{
    public UIMyCookies uiMyCookies;
    public GameObject myCookiesContent;  

    void Start()
    {
        //������ �ε�
        HE_DataManager.instance.LoadData();

        //��ưŬ�� ����(id)�� �޾Ƽ� �ش� Event �߻���Ŵ
        EventManager.instance.onSelectBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);
            //���õǾ��ٴ� �̹���(�ʷϻ� �׵θ�)
            //�ڷΰ��� ������ LOBBY������ �ٲ�鼭 �ش� ĳ���Ͱ� ���
            UserDataManager.Instance.SetSelectCookieID(id);  
            for(int i = 0; i < myCookiesContent.transform.childCount; i++)
            {
                GameObject item = myCookiesContent.transform.GetChild(i).gameObject;
                if(item != null)
                {
                    UIScrollViewCookiesSelect itemComponent = item.GetComponent<UIScrollViewCookiesSelect>();
                    if(itemComponent.GetID() == id)
                    {
                        itemComponent.SetCheck(true);
                    }
                    else
                    {
                        itemComponent.SetCheck(false);    

                    }
                }
            }


            Debug.LogFormat("{0},{1} ĳ���Ͱ� ���õǾ����ϴ�", data.id, data.name);
        };

        EventManager.instance.onBuyBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);
            Debug.LogFormat("{0},{1},{2}", data.id, data.name, data.price);
        };

        //UIMyCookies �ʱ�ȭ
        uiMyCookies.Initialize();
    }
}
