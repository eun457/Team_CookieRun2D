using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GobacktoLOBBY : MonoBehaviour //code by. ����
{
    [SerializeField] GameObject gobackBtn;
    [SerializeField] string effectAudioClipPath = "E_ClickBtn";

    public void Awake()
    {
        gobackBtn.GetComponent<Button>().onClick.AddListener(GotoLobby);
    }

    public void GotoLobby()
    {
        SceneManager.LoadScene("LOBBY");

        //Effect���
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
        {
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
        }
    }
}
