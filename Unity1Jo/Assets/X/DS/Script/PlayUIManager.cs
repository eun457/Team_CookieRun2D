using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUIManager : MonoBehaviour
{
    [SerializeField] GameManager mainImage; // ��ü �̹���
    public GameObject panel;

    public Image HpdownEffect;
    public Image HpGage;
    public float HpValue;
    public float MaxHP;

    public GameObject CoinText;
    public GameObject JellyText;
    
    public int totalScore;

    public GameObject inputUI; // ���� ����� �����ϱ� ���� �� ��

    private void Start()
    {
        
    }

    private void Update()
    {
        HpValue -= Time.deltaTime;
    }
}
