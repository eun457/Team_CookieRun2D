//���� �� ������ ����ִ� ���� �Ŵ���
//���� �� ������ ����ִ� ���� �Ŵ���
//���� �� ������ ����ִ� ���� �Ŵ���
//���� �� ������ ����ִ� ���� �Ŵ���

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public void Awake()
    {
        if (Instance == null) //�������� �ڽ��� üũ��, null����
        {
            Instance = this; //���� �ڱ� �ڽ��� ������.
        }
    }

    [Header("�÷��̾� ������ ����")]
    [SerializeField] public float JellyPoint; //���� ����
    [SerializeField] public float Coin; //���� ����

    //bonusTime������ ���� ó������ ����̶� �ϴ� ���� ������Ʈ�� ����� �ξ����ϴ�.
    [SerializeField] public GameObject[] BonusTimeJelly; //���ʽ�Ÿ������ ��������










}
