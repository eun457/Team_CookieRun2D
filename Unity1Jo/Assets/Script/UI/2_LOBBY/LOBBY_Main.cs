using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LOBBY_Main : MonoBehaviour //code by.����
{
    [SerializeField] SpriteRenderer LobbyCookieImg;
    [SerializeField] Text bestPointTxt;
    [SerializeField] Text coinTxt;
    [SerializeField] string bgmAudioClipPath = "BGM_Lobby";
    void Start()
    {
        //������ �ε�
        UI_DataManager.instance.LoadCookiesData();  
        MycookiesData data = UI_DataManager.instance.GetMycookiesDatas().Find(cookie => cookie.id == UserDataManager.Instance.GetSelectCookieID());
        string cookieName = string.Empty;
        if(data != null)
        {
            var atlas = AtlasManager.Instance.GetAtlasByName("Cookies");
            cookieName = data.sprite_name;
            if (!string.IsNullOrEmpty(cookieName))
            {
                //MYCOOKIES���� ������ ��Ű�� spirte�� LOBBY�� ���
                LobbyCookieImg.sprite = atlas.GetSprite(cookieName);
                LobbyCookieImg.gameObject.transform.localScale = new Vector2(2f, 2f);  
            }
        }

        //BGM���
        AudioClip bgmAudioClip = GameManager.Instance.LoadAudioClip(bgmAudioClipPath);
        if(bgmAudioClip != null)
        {
            SoundManager.Instance.Play(bgmAudioClip, Define.Sound.Bgm);
        }
    }

    void Update()
    {
        if (coinTxt == null)
            return;
        coinTxt.text = string.Format("{0:#,0}", GameManager.Instance.totalCoin);
        bestPointTxt.text = string.Format("{0:#,0}", GameManager.Instance.bestJellyPoint);
    }
}
