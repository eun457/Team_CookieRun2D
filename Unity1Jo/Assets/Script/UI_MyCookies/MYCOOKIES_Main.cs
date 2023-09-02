using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MYCOOKIES_Main : MonoBehaviour //code by. ����
{
    [SerializeField] UIMyCookies uiMyCookies;
    [SerializeField] UIScrollView cookieScrollView;
    [SerializeField] UIPopupScale Popup; //code by. ����
    [SerializeField] GameObject myCookiesContent;
    [Space]


    [Header("Popup Data")]
    [SerializeField] GameObject UI_BuyPopup;
    [SerializeField] GameObject ui_CheckPopupBox;
    [SerializeField] GameObject ui_CautionPopupBox;
    [SerializeField] private Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f); // Ȯ���� ������ ��
    [SerializeField] private Vector3 originScale = new Vector3(1, 1, 1); // Ȯ���� ������ ��
    [SerializeField] private float animationDuration = 0.2f; // �ִϸ��̼� ���� �ð�  

    private void Awake()
    {

        foreach (Transform child in UI_BuyPopup.transform)
            GameObject.Destroy(child.gameObject);

        UI_BuyPopup.gameObject.SetActive(false);  

    }

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
            UIScrollViewCookiesSelect afterCheckcookieComponent = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == data.id);  // ���õ� ��Ű ������Ʈ ������ 
            beforeCheckcookieComponent?.RefreshCheck(); // ���� refresh 
            afterCheckcookieComponent?.RefreshCheck();  // ���� refresh 

            Debug.LogFormat("{0},{1} ĳ���Ͱ� ���õǾ����ϴ�", data.id, data.name);
        };

        EventManager.instance.onBuyBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);
            Debug.LogFormat("{0},{1},{2}", data.id, data.name, data.price);

            float totCoin = GameManager.Instance.totalCoin; // total coin ������ 
            Debug.Log($"totCoin : {totCoin}");

            //Debug.Log($"�����ϱ� ��ư ������ �� Popup.isBuy: {Popup.isBuy}");

            if (totCoin >= data.price)
            {
                UI_BuyPopup.gameObject.SetActive(true);

                GameObject checkPopupBox = Instantiate(ui_CheckPopupBox);   // �������� popup ���� (�ش� ������ ��ġ : Asset/Prefabs/UI/Popup)
                checkPopupBox.transform.SetParent(UI_BuyPopup.transform);   // �θ� ���� 
                checkPopupBox.GetComponent<RectTransform>().localPosition = Vector2.zero;   // position ���� 
                checkPopupBox.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); // scale ���� 

                // popup animation 
                checkPopupBox.GetComponent<RectTransform>().DOScale(targetScale, animationDuration).OnComplete(() => {
                    checkPopupBox.GetComponent<RectTransform>().DOScale(originScale, animationDuration);   
                });  

                // ID, price, view ��������   
                UI_CheckPopupBox checkComponent = checkPopupBox.GetComponent<UI_CheckPopupBox>();
                checkComponent.SetCookieID(data.id);
                checkComponent.SetCookiePrice(data.price);
                checkComponent.SetCookieScrollView(cookieScrollView);

            }
            else 
            {
                UI_BuyPopup.gameObject.SetActive(true);

                GameObject cautionPopupBox = Instantiate(ui_CautionPopupBox);   // �������� popup ����  (�ش� ������ ��ġ : Asset/Prefabs/UI/Popup)
                cautionPopupBox.transform.SetParent(UI_BuyPopup.transform);     // �θ� ���� 
                cautionPopupBox.GetComponent<RectTransform>().localPosition = Vector2.zero; // position ���� 
                cautionPopupBox.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); // scale ���� 

                // popup animation 
                cautionPopupBox.GetComponent<RectTransform>().DOScale(targetScale, animationDuration).OnComplete(() => {
                    cautionPopupBox.GetComponent<RectTransform>().DOScale(originScale, animationDuration);  
                });

                Debug.Log("������ �����մϴ�.");
            }

            /* ���� �ڵ� */
            //if (totCoin >= data.price && Popup != null)
            //{
            //    Popup.ShowCheckPopup(); //code by. ����
            //    Debug.Log($"�����ϱ� ��ư ���� ���� Popup.isBuy: {Popup.isBuy}");
            //    if (Popup.isBuy == true)
            //    {
            //        //Popup.HideCheckPopup();
            //        GameManager.Instance.totalCoin -= data.price;
            //        UserDataManager.Instance.SetHasCookie(data.id, true); // ���� ���� ������Ʈ 
            //        UIScrollViewCookiesSelect cookie = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == data.id); // ������ ��Ű�� Component ������ 
            //        if (cookie != null)
            //        {
            //            cookie.SetActivePanel(); // ���� �гη� �ٲ��� 
            //            cookie.RefreshLock(); //  lock Ǯ����
            //        }
            //    }
            //}
            //else if(totCoin < data.price && Popup != null)
            //{
            //    Popup.ShowCautionPopup(); //code by. ����
            //    //Debug.Log("������ �����մϴ�.");
            //}
        };

        //UIMyCookies �ʱ�ȭ
        uiMyCookies.Initialize();
    }
}
