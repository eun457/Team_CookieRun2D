using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LOBBY_Main : MonoBehaviour
{
    [SerializeField] SpriteRenderer LobbyCookieImg;    
    void Start()
    {
        //������ �ε�
        HE_DataManager.instance.LoadData();  
        MycookiesData data = HE_DataManager.instance.GetMycookiesDatas().Find(cookie => cookie.id == UserDataManager.Instance.GetSelectCookieID());
        string cookieName = string.Empty;
        if(data != null)
        {
            var atlas = AtlasManager.Instance.GetAtlasByName("MyCookies"); //���� ��ֹ� sprite�� atlas�� �ؼ� key�� �������� enum���� ����  
            cookieName = data.sprite_name;
            if (!string.IsNullOrEmpty(cookieName))
            {
                LobbyCookieImg.sprite = atlas.GetSprite(cookieName);
                LobbyCookieImg.gameObject.transform.localScale = new Vector2(1.2f, 1.2f);  
            }

        }
    }

    void Update()
    {
        
    }
}
