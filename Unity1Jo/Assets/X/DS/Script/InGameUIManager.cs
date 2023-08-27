using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class InGameUIManager : MonoBehaviour
{
    GameObject cookie; // ��Ű���� HP ���� ��������
    Player player;

    public GameObject mainImage; // ��ü �̹���
    public GameObject pausePanel;

    public Button pause;
    public Button keepGame;
    public Button exitGame;
    public Button restartGame;

    public RectTransform HpdownEffect; // HP �Ͼ� ����Ʈ
    public Image HpGage; // HP �Ǹ���
    float HpValue; // ��ȭ�ϴ� ��
    float MaxHpValue; // ���� ��
    

    float CookieHP = 100; // ��ȭ�� ��Ű HP(player �ӽú���) delete ����

    bool HpDown = true;

    public Text CoinText;
    public Text JellyText;

    float CoinValue; // �ӽú���
    float JellyValue; // �ӽú���
    
    public static int totalScore;

    //public GameObject inputUI; // ���� ����� �����ϱ� ���� �� ��
   
    private void Awake()
    {
        cookie = GameObject.FindGameObjectWithTag("Player");
        player = GetComponent<Player>();
        //pausePanel.SetActive(false);
    }
    private void Start()
    {
        //cookie = GameObject.FindGameObjectWithTag("Player"); 
        //player = GetComponent<Player>();
        

        pausePanel.SetActive(false);

        if (HpDown)
        {
            //MaxHp�� Hp�� ����
            MaxHpValue = CookieHP; //player.hp; // ��ȣ������ public���� ���߰ų� ������Ƽ�� ��������
            HpValue = CookieHP; //player.hp; // ���ڱ� player.hp�� �ҷ��� ���� ��������.
        }
    }

    private void Update()
    {
        float hpGage = HpValue / MaxHpValue;
        HpGage.fillAmount = hpGage;

        if (HpDown)
        {
            Vector2 effect = HpdownEffect.position;
            effect = new Vector2 (effect.x - Time.deltaTime * 8.25f, effect.y); 
            HpdownEffect.position = effect;
           
            HpValue -= Time.deltaTime;

            if(HpValue <= 0f)
            {
                HpValue = 0;
            }
        }

       // CoinValue = player.coinScore;  �� ������ �ȵ���?
        JellyText.text = string.Format("{0:n0}", JellyValue); // CoinValue, JellyValue �ӽ� ������
        CoinText.text = string.Format("{0:n0}", CoinValue); // ����ǥ���� ����
        

    }
}
