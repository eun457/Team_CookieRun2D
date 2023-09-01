using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MYCOOKIES_Main : MonoBehaviour //code by. ����
{
    public UIMyCookies uiMyCookies;
    public GameObject myCookiesContent;
    [SerializeField] UIScrollView cookieScrollView;

    void Start()
    {
        //������ �ε�
        HE_DataManager.instance.LoadData();

        //��ưŬ�� ����(id)�� �޾Ƽ� �ش� Event �߻���Ŵ
        EventManager.instance.onSelectBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);

            //�ڷΰ��� ������ LOBBY������ �ٲ�鼭 �ش� ĳ���Ͱ� ���
            if (UserDataManager.Instance.GetHasCookie(id) == 0) // ��Ű �Ȱ����� ������ ���� 
                return;

            UserDataManager.Instance.SetSelectCookieID(id);
            UIScrollViewCookiesSelect beforeCheckcookieComponent = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetCheck() == true); // ���� üũ�Ǿ��ִ� ��Ű ������Ʈ ������ 
            UIScrollViewCookiesSelect afterCheckcookieComponent = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == data.id);  // ���õ� ��� ������Ʈ ������ 
            beforeCheckcookieComponent?.RefreshCheck(); // ���� refresh 
            afterCheckcookieComponent?.RefreshCheck();  // ���� refresh 

            Debug.LogFormat("{0},{1} ĳ���Ͱ� ���õǾ����ϴ�", data.id, data.name);
        };

        EventManager.instance.onBuyBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);
            Debug.LogFormat("{0},{1},{2}", data.id, data.name, data.price);

            // TODO : ���� ��ư ���� 
            float totCoin = GameManager.Instance.totalCoin; // total coin ������ 
            Debug.Log($"totCoin : {totCoin}");
            if (totCoin >= data.price)
            {
                GameManager.Instance.totalCoin -= data.price; 
                UserDataManager.Instance.SetHasCookie(data.id, true); // ���� ���� ������Ʈ 
                UIScrollViewCookiesSelect cookie = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == data.id); // ������ ��Ű�� Component ������ 
                if (cookie != null)
                {
                    cookie.SetActivePanel(); // ���� �гη� �ٲ��� 
                    cookie.RefreshLock();   //  lock Ǯ����   
                }
            }
            else
            {
                Debug.Log("������ �����մϴ�.");
            }



        };

        //UIMyCookies �ʱ�ȭ
        uiMyCookies.Initialize();
    }
}
