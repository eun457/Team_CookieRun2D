using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] GameObject mainImage; // ��ü �̹���
    public GameObject panel;

    public Image HpdownEffect;
    public Image HpGage;
    public float HpValue;
    public float MaxHP;
    public bool isHpDown = true;

    public Text CoinText;
    public Text JellyText;
    public Text Comma;
    public int CoinValue;
    public int JellyValue;
    
    public int totalScore;

    //public GameObject inputUI; // ���� ����� �����ϱ� ���� �� ��

    private void Start()
    {
        
    }

    private void Update()
    {
        
        CoinText.text = CoinValue.ToString();
        Comma.text = Comma1000(CoinValue).ToString();

        HpValue -= Time.deltaTime;

    }

    public string Comma1000(int data) // ����ǥ����
    {
        return string.Format("0:#,###", data); // Format()
    }
}
