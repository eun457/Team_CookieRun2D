using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LOBBY_Main : MonoBehaviour //code by.����
{
    [SerializeField] SpriteRenderer LobbyCookieImg;
    [SerializeField] SpriteRenderer LobbyPetImg;
    [SerializeField] Text bestPointTxt;
    [SerializeField] Text coinTxt;
    [SerializeField] string bgmAudioClipPath = "BGM_Lobby";
    void Start()
    {
        //PrintCookie();
        //PrintPet();
        //PrintTreasure();

        //BGM���
        AudioClip bgmAudioClip = GameManager.Instance.LoadAudioClip(bgmAudioClipPath);
        if(bgmAudioClip != null)
        {
            SoundManager.Instance.Play(bgmAudioClip, Define.Sound.Bgm);
        }
    }

    //void PrintCookie()
    //{
    //    //������ ��Ű ���
    //    UI_DataManager.instance.LoadCookiesData();
    //    MycookiesData data = UI_DataManager.instance.GetMycookiesDatas().Find(cookie => cookie.id == UserDataManager.Instance.GetSelectCookieID());
    //    string cookieName = string.Empty;
    //    if (data != null)
    //    {
    //        var atlas = AtlasManager.Instance.GetAtlasByName("Cookies");
    //        cookieName = data.sprite_name;
    //        if (!string.IsNullOrEmpty(cookieName))
    //        {
    //            //MYCOOKIES���� ������ ��Ű�� spirte�� LOBBY�� ���
    //            LobbyCookieImg.sprite = atlas.GetSprite(cookieName);
    //            switch (cookieName)
    //            {
    //                case "cookie03":
    //                    LobbyCookieImg.gameObject.transform.position = new Vector2(0, 0.33f);
    //                    LobbyPetImg.gameObject.transform.localScale = new Vector2(1.8f, 1.8f);
    //                    break;
    //                case "cookie05":
    //                    LobbyPetImg.gameObject.transform.localScale = new Vector2(1.8f, 1.8f);
    //                    break;
    //                default:
    //                    LobbyCookieImg.gameObject.transform.localScale = new Vector2(2f, 2f);
    //                    break;
    //            }
    //        }
    //    }
    //}

    //void PrintPet()
    //{
    //    //������ �� ���
    //    UI_DataManager.instance.LoadPetsData();
    //    MyPetsData petdata = UI_DataManager.instance.GetMypetsDatas().Find(pet => pet.id == UserDataManager.Instance.GetSelectPetID());
    //    string petName = string.Empty;
    //    if (petdata != null)
    //    {
    //        var atlas = AtlasManager.Instance.GetAtlasByName("Pets");
    //        petName = petdata.sprite_name;
    //        if (!string.IsNullOrEmpty(petName))
    //        {
    //            LobbyPetImg.sprite = atlas.GetSprite(petName);
    //            switch (petName)
    //            {
    //                case "pet01":
    //                    LobbyPetImg.gameObject.transform.localScale = new Vector2(1.2f, 1.2f);
    //                    break;
    //                case "pet03":
    //                    LobbyPetImg.gameObject.transform.position = new Vector2(-2.68f, 1f);
    //                    LobbyPetImg.gameObject.transform.localScale = new Vector2(1.5f, 1.5f);
    //                    break;
    //                case "pet05":
    //                    LobbyPetImg.gameObject.transform.position = new Vector2(2.2f, 1.81f);
    //                    LobbyPetImg.gameObject.transform.localScale = new Vector2(1f, 1f);
    //                    break;
    //                default:
    //                    LobbyPetImg.gameObject.transform.localScale = new Vector2(1f, 1f);
    //                    break;
    //            }
    //        }
    //    }
    //}

    void Update()
    {
        if (coinTxt == null)
            return;
        coinTxt.text = string.Format("{0:#,0}", GameManager.Instance.totalCoin);
        bestPointTxt.text = string.Format("{0:#,0}", GameManager.Instance.bestJellyPoint);
    }
}
