using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollView : MonoBehaviour //code by. ����
{
    [SerializeField] Transform contentTrans;
    [SerializeField] GameObject cookiePrefab;
    [SerializeField] List<UIScrollViewCookiesSelect> CookieComponentList = new List<UIScrollViewCookiesSelect>();
    [SerializeField] string effectAudioClipPath = "E_ClickBtn";

    public void Initialize()
    {
        //MycookiesData�� ���ִ� List�� ���޹޾Ƽ� Cookie�� ����
        List<MycookiesData> list = HE_DataManager.instance.GetMycookiesDatas();

        foreach (MycookiesData data in list)
        {
            //create
            AddCookies(data);
        }
    }

    //Cookies ����
    public void AddCookies(MycookiesData data)
    {
        //������ �ν��Ͻ� ����, contentTrans �ڽ����� ����
        var go = Instantiate(cookiePrefab, contentTrans);
        UIScrollViewCookiesSelect cookies = go.GetComponent<UIScrollViewCookiesSelect>();

        cookies.Initialize(data);
        // ���ó�� 
        if(UserDataManager.Instance.GetHasCookie(data.id) == 0) // ��Ű �Ȱ����� ���� 
        {
            cookies.SetLock(true);
        }
        else
        {
            cookies.SetLock(false);  
        }


        //�� ��ư�� ������ �ش� cookies�� id�� EventManager���� ����
        cookies.selectBtn.onClick.AddListener(() => {
            EventManager.instance.onSelectBtnClick(cookies.GetID());

            //Effect���
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
            {
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
            }

        });
        cookies.buyBtn.onClick.AddListener(() => {
            EventManager.instance.onBuyBtnClick(cookies.GetID());

            //Effect���
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
            {
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
            }
        });

        CookieComponentList.Add(cookies);  
    }
    public List<UIScrollViewCookiesSelect> GetCookieComponentList()
    {
        return CookieComponentList;
    }
}
