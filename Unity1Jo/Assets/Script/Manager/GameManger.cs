//���� �� ������ ����ִ� ���� �Ŵ���
//���� �� ������ ����ִ� ���� �Ŵ���
//���� �� ������ ����ִ� ���� �Ŵ���
//���� �� ������ ����ִ� ���� �Ŵ���

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    void Awake()
    {
        base.Awake();
    }

    [Header("�÷��̾� ������ ����")]
    [SerializeField] public float JellyPoint; //���� ����
    [SerializeField] public float Coin; //���� ����

    //bonusTime������ ���� ó������ ����̶� �ϴ� ���� ������Ʈ�� ����� �ξ����ϴ�.
    [SerializeField] public GameObject[] BonusTimeJelly; //���ʽ�Ÿ������ ��������

    
    


}
