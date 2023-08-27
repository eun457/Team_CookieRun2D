using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollViewCookiesSelect : MonoBehaviour
{
    public Text cookieName;
    public Image cookieImg;
    public Button selectBtn;
    public Button buyBtn;
    public Text priceTxt;
    public int id;

    public void Initialize(MycookiesData data)
    {
        id = data.id;
        cookieName.text = data.name;
        var atlas = AtlasManager.instance.GetAtlasByName("MyCookies"); //���� ��ֹ� sprite�� atlas�� �ؼ� key�� �������� enum���� ����
        cookieImg.sprite = atlas.GetSprite(data.sprite_name);
        cookieImg.SetNativeSize();
        priceTxt.text = string.Format("{0}",data.price);
    }
}
