using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CheckPopupBox : MonoBehaviour
{
    int cookieID;
    int cookiePrice;
    UIScrollView cookieScrollView;

    [SerializeField] GameObject oKBtn;
    [SerializeField] GameObject closeBtn;

    [SerializeField] string effectAudioClipPath = "E_BuyCookie";
    [SerializeField] string effectAudioClipPath2 = "E_ClickBtn";

    private void Awake()
    {
        oKBtn.AddUIEvent(OnOkBtnClicked);
        closeBtn.AddUIEvent(OnCloseBtnClicked);  
    }

    /* Setter */
    public void SetCookieID(int id)
    {
        cookieID = id;
    }

    public void SetCookiePrice(int price)
    {
        cookiePrice = price;
    }
    public void SetCookieScrollView(UIScrollView view)
    {
        cookieScrollView = view;
    }

    /* ���� ��ư ��� ���� */
    void OnOkBtnClicked(PointerEventData data)
    {
        Debug.Log($"ID : {cookieID} ���� �Ϸ� ~!! ");

        //Effect���
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

        GameManager.Instance.totalCoin -= cookiePrice;
        UserDataManager.Instance.SetHasCookie(cookieID, true); // ���� ���� ������Ʈ 
        if (cookieScrollView == null)
            return;

        UIScrollViewCookiesSelect cookie = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == cookieID); // ������ ��Ű�� Component ������ 
        if (cookie != null)
        {
            cookie.SetActivePanel(); // ���� �гη� �ٲ��� 
            cookie.RefreshLock(); //  lock Ǯ����    
        }

        ClosePopup();  
    }

    /* �ݱ� ��ư ��� ���� */
    void OnCloseBtnClicked(PointerEventData data)
    {
        //Effect���
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath2);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

        ClosePopup();
    }

    void ClosePopup()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
