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

    //[Header("�뽬 ����")]
    //[SerializeField] public bool isDashing;
    //[SerializeField] public float DashDuration; //�뽬 �����ִ� �ð�
    //[SerializeField] public float GroundScrollSpeed; //���� �������� ���ǵ�
    //[SerializeField] public float OriginalGroundScrollSpeed; //���� �ʱⰪ ���ǵ�
    //public float DashTime; //�뽬 ���� �ð�


    //[Header("�Ŵ�ȭ ����")]
    //[SerializeField] public bool isGigantic;
    //[SerializeField] public float GiganticSize; //�󸶳� Ŀ����
    //[SerializeField] public Vector3 OriginalSize; //������ ũ��
    //[SerializeField] public float GiganticDuration; //�Ŵ�ȭ �����ִ� �ð�
    //public float GiganticTime; //�Ŵ�ȭ ���� �ð�


    //private void Start()
    //{
    //    OriginalGroundScrollSpeed = GroundScrollSpeed; //���� �ӵ��� �־��ֱ�
    //    DashDuration = DashTime; //�����ص� ����

    //    OriginalSize = GameObject.FindGameObjectWithTag("Player").transform.localScale; //���� �÷��̾��� ������ ����
    //    GiganticDuration = GiganticTime; //�����ص� ����


    //}
    //private void FixedUpdate()
    //{
    //    DashDuration -= Time.deltaTime; //�ð��� ���� �� ����
    //    GiganticDuration -= Time.deltaTime;//�ð��� ���� �� ����
    //}


}
