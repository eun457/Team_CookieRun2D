//�÷��̾� �����ϰ� ���ִ� �Ŵ���
//�÷��̾� �����ϰ� ���ִ� �Ŵ���
//�÷��̾� �����ϰ� ���ִ� �Ŵ���
//�÷��̾� �����ϰ� ���ִ� �Ŵ���

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public void Awake()
    {
        if (Instance == null) //�������� �ڽ��� üũ��, null����
        {
            Instance = this; //���� �ڱ� �ڽ��� ������.
        }
    }
}
