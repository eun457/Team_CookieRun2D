//���� �� ������ ����ִ� ���� �Ŵ���
//���� �� ������ ����ִ� ���� �Ŵ���
//���� �� ������ ����ִ� ���� �Ŵ���
//���� �� ������ ����ִ� ���� �Ŵ���

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonBehaviour<GameManager> //code by. ��
{
    public Text coinText; // code by.����

    void Awake()
    {
        base.Awake();
    }

    [Header("�÷��̾� ������ ����")]
    [SerializeField] public float JellyPoint; //���� ����
    [SerializeField] public float Coin; //���� ����

    //bonusTime������ ���� ó������ ����̶� �ϴ� ���� ������Ʈ�� ����� �ξ����ϴ�.
    [SerializeField] public GameObject[] BonusTimeJelly; //���ʽ�Ÿ������ ��������

    [SerializeField] public float GroundScrollSpeed;

    private void Start()
    {
        coinText.text = Coin.ToString(); // code by.����
    }
}
