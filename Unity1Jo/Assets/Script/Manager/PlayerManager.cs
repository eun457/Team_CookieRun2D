//�÷��̾� �����ϰ� ���ִ� �Ŵ���
//�÷��̾� �����ϰ� ���ִ� �Ŵ���
//�÷��̾� �����ϰ� ���ִ� �Ŵ���
//�÷��̾� �����ϰ� ���ִ� �Ŵ���

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonBehaviour<PlayerManager>
{
    [SerializeField] private GameObject player;
    void Awake()
    {
        base.Awake();
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
