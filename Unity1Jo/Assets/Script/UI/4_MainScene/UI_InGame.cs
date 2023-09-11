using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UI_InGame : MonoBehaviour
{
    Player player;

    public GameObject mainImage; // ��ü �̹���
    public GameObject pausePanel;

    public Button pause;
    public Button keepGame;
    public Button exitGame;
    public Button restartGame;

    public RectTransform HpdownEffect; // HP �Ͼ� ����Ʈ
    public Image HpGage; // HP �Ǹ���
    public float HpValue; // ��ȭ�ϴ� ��
    float MaxHpValue; // ���� ��

    public bool HpDown = true;

    public Text CoinText;
    public Text JellyText;
    
    public static int totalScore;

    [SerializeField] GameObject Bonus;

    [SerializeField] string bgmAudioClipPath = "BGM_Map1";

    //public GameObject inputUI; // ���� ����� �����ϱ� ���� �� ��

    private void Awake()
    {
        pausePanel.SetActive(false);
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        //BGM���
        AudioClip bgmAudioClip = GameManager.Instance.LoadAudioClip(bgmAudioClipPath);
        if (bgmAudioClip != null)
            SoundManager.Instance.Play(bgmAudioClip, Define.Sound.Bgm);

        if (HpDown)
        {
            //MaxHp�� Hp�� ����
            MaxHpValue = player.GetHP(); // ����
            HpValue = player.GetHP();
        }
    }

    private void Update()
    {
        float hpGage = HpValue / MaxHpValue;
        HpGage.fillAmount = hpGage;

        float HpEffect = HpGage.fillAmount;
        HpdownEffect.anchorMin = new Vector2(HpEffect, HpdownEffect.anchorMin.y);
        HpdownEffect.anchorMax = new Vector2(HpEffect, HpdownEffect.anchorMax.y);
        HpdownEffect.anchoredPosition = Vector2.zero; // ��� �̻����

        if (HpDown)
        {
            HpValue -= Time.deltaTime;

            if(HpValue <= 0f)
            {
                HpValue = 0;
            }

            if(HpValue >= MaxHpValue)
            {
                HpValue = MaxHpValue;
            }
        }

      
        JellyText.text = string.Format("{0:n0}", GameManager.Instance.currentJellyPoint); //���� JellyPoint�� �Ǿ��ִ� �� currentCoin���� �����߽��ϴ�. -����
        CoinText.text = string.Format("{0:n0}", GameManager.Instance.currentCoin); // ����ǥ���� ���� //���� TotalCoin���� �Ǿ��ִ� �� currentCoin���� �����߽��ϴ�. -����
        
        
    }

    public float GetHpValue()
    {
        return HpValue;
    }
}
