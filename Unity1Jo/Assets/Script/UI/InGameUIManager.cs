using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class InGameUIManager : MonoBehaviour
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
    float HpValue; // ��ȭ�ϴ� ��
    float MaxHpValue; // ���� ��

    bool HpDown = true;

    public Text CoinText;
    public Text JellyText;
    
    public static int totalScore;

    [SerializeField] GameObject Bonus;  

    //public GameObject inputUI; // ���� ����� �����ϱ� ���� �� ��
   
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();  
        pausePanel.SetActive(false);
    }
    private void Start()
    {

        if (HpDown)
        {
            //MaxHp�� Hp�� ����
            MaxHpValue = player.GetHP(); 
            HpValue = player.GetHP();
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

      
        JellyText.text = string.Format("{0:n0}", GameManager.Instance.JellyPoint);
        CoinText.text = string.Format("{0:n0}", GameManager.Instance.TotalCoin); // ����ǥ���� ����
        

    }
}
