using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CheckPopupBox : MonoBehaviour
{
    int cookieID;
    int cookiePrice;
    [SerializeField] Text message;
    UIScrollView cookieScrollView;

    int petID;
    int petPrice;
    MYPETS_UIScrollView petScrollView;

    [SerializeField] Define.PopupType popupType;  

    [SerializeField] GameObject oKBtn;
    [SerializeField] GameObject closeBtn;

    [SerializeField] string effectAudioClipPath = "E_BuyCookie";
    [SerializeField] string effectAudioClipPath2 = "E_ClickBtn";

    private void Awake()
    {
        oKBtn.AddUIEvent(OnOkBtnClicked);
        closeBtn.AddUIEvent(OnCloseBtnClicked);  
    }

    private void Start()
    {
        switch (popupType)
        {
            case Define.PopupType.Cookie:
                message.text = "ĳ���͸� �����Ͻðڽ��ϱ�?";
                break;
            case Define.PopupType.Pet:
                message.text = "���� �����Ͻðڽ��ϱ�?";
                break;
        }
    }

    #region Cookies Setter
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
    public void SetPopupType(Define.PopupType type)
    {
        popupType = type;
    }
    #endregion

    #region Pets Setter
    /* Pets Setter */
    public void SetPetID(int id)
    {
        petID = id;
    }

    public void SetPetPrice(int price)
    {
        petPrice = price;
    }
    public void SetPetScrollView(MYPETS_UIScrollView view)
    {
        petScrollView = view;
    }
    #endregion

    #region ���Ź�ư ��ɱ���
    void OnOkBtnClicked(PointerEventData data)
    {
        Debug.Log($"ID : {cookieID} ���� �Ϸ� ~!! ");

        //Effect���
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);


        switch (popupType)
        {
            case Define.PopupType.Cookie:
                BuyCookie();
                break;
            case Define.PopupType.Pet:
                BuyPet();
                break;
        }



        ClosePopup();  
    }
    #endregion


    void BuyCookie()
    {
        //���λ��
        GameManager.Instance.totalCoin -= cookiePrice;

        //���� ���� ������Ʈ
        UserDataManager.Instance.SetHasCookie(cookieID, true);
        if (cookieScrollView == null)
            return;

        UIScrollViewCookiesSelect cookie = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == cookieID); // ������ ��Ű�� Component ������ 
        if (cookie != null)
        {
            cookie.SetActivePanel(); // ���� �гη� �ٲ��� 
            cookie.RefreshLock(); //  lock Ǯ����    
        }
    }
    void BuyPet()
    {
        //���λ��
        GameManager.Instance.totalCoin -= petPrice;

        //���� ���� ������Ʈ
        UserDataManager.Instance.SetHasPet(petID, true);  
        if (petScrollView == null)
            return;
        Debug.Log("buy pet ����111");

        UIScrollViewPetsSelect pet = petScrollView.GetPetComponentList()?.Find(item => item.GetID() == petID); // ������ ���� Component ������ 
        if (pet != null)
        {
            Debug.Log("buy pet ����222");

            pet.SetActivePanel(); // ���� �гη� �ٲ��� 
            pet.RefreshLock(); //  lock Ǯ����       
        }
    }
    #region �˾�â�ݱ��ư ��ɱ���
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
    #endregion
}
