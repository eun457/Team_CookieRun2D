//������ �� ��ֹ� ���� �Ŵ���
//������ �� ��ֹ� ���� �Ŵ���
//������ �� ��ֹ� ���� �Ŵ���
//������ �� ��ֹ� ���� �Ŵ���

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;//�����Լ� ó��

public class Spawnanager : SingletonBehaviour<Spawnanager>
{

    void Awake()
    {
        base.Awake();
    }

    [Header("�� ����")]
    [SerializeField] GameObject ShortEnemy;//1�� ������ �������� ��
    [SerializeField] GameObject LongEnemy;//2�� ������ �������� ��
    [SerializeField] GameObject UpEnemy; //�����̵�� �������� ��
    [SerializeField] int patternNum; //���� ��ȣ
    float LastSpawnTime;

    [Header("SpawnPosition")]
    [SerializeField] Transform UpSpawnPos;//1�� ������ �������� ��
    [SerializeField] Transform GroundSpawnPos;//2�� ������ �������� ��
    [SerializeField] Transform SlideSpawnPos;//2�� ������ �������� ��




    //��ֹ� ���� ����
    //��ֹ� ���� ����
    //��ֹ� ���� ����
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null) //�÷��̾ ������
        {

            SpawnPattern();
        }
    }

    void SpawnPattern()
    {

        if (Time.time > LastSpawnTime + 5.0f)//���� ���� �ֱ�
        {
            LastSpawnTime = Time.time;
            patternNum = Random.Range(0, 3);  //���� ����
            StartCoroutine(attack(patternNum)); //�ش� ���ڿ� �´� �ڷ�ƾ ������
        }
    }

    //���� ���� ����
    //����ؾ� �� ���� ���߿� �뽬�� �Ǹ� map�� ���� �̼��� �������� �Ǵµ� 
    //�̶� �� �����ֱⰡ �����ϸ� ���� ������ ������ -> �ٵ� ������ �뽬���� �����̶� ������
    IEnumerator attack(int p) //���� �Լ���
    {
        if (p == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(ShortEnemy, GroundSpawnPos.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
        }

        if (p == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(LongEnemy, GroundSpawnPos.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (p == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(UpEnemy, SlideSpawnPos.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
        }

        if (p == 3)
        {
            Instantiate(ShortEnemy, GroundSpawnPos.position, Quaternion.identity);

        }

        if (p == 4)
        {
            Instantiate(ShortEnemy, GroundSpawnPos.position, Quaternion.identity);

        }
        if (p == 5)
        {
            Instantiate(ShortEnemy, GroundSpawnPos.position, Quaternion.identity);

        }
        yield return new WaitForSeconds(1f);
    }








}
