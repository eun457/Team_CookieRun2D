using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollViewCookiesSelect : MonoBehaviour //code by. ����
{
    public Text cookieName;
    public Image cookieImg;
    public Button selectBtn;
    public Button buyBtn;
    public Text priceTxt;
    public int id;
    // lock panel 
    public GameObject lockPanel;
    [SerializeField] GameObject CheckIcon;

    public void Initialize(MycookiesData data)
    {
        id = data.id;
        cookieName.text = data.name;
        var atlas = AtlasManager.Instance.GetAtlasByName("MyCookies"); //���� ��ֹ� sprite�� atlas�� �ؼ� key�� �������� enum���� ����
        cookieImg.sprite = atlas.GetSprite(data.sprite_name);
        cookieImg.SetNativeSize();
        priceTxt.text = string.Format("{0}",data.price);  
        // user data manager ������ �ִ��� üũ -> ������� 

        if(UserDataManager.Instance.GetSelectCookieID() == id)
        {
            SetCheck(true);
        }
        else
        {
            SetCheck(false);  
        }

    }

    public void SetLock(bool flag)
    {
        lockPanel.SetActive(flag);
    }
    public void SetCheck(bool flag)
    {
        CheckIcon.SetActive(flag);
    }
    public int GetID()
    {
        return id;
    }
}
