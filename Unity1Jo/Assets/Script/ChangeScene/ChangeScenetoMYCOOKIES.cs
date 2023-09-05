using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenetoMYCOOKIES : MonoBehaviour //code by. ����
{
    [SerializeField] GameObject myCookiesBtn;
    [SerializeField] string effectAudioClipPath = "E_ClickBtn";

    public void Awake()
    {
        myCookiesBtn.GetComponent<Button>().onClick.AddListener(GotoMyCookies);
    }

    public void GotoMyCookies()
    {
        SceneManager.LoadScene("MYCOOKIES");

        //Effect���
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
    }
}
