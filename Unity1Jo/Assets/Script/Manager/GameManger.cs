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
    [SerializeField] public float currentJellyPoint; //���� ���ӿ��� ���� ���� ����
    [SerializeField] public float bestJellyPoint; //�ְ� ���� ����
    [SerializeField] public float currentCoin; //���� ���ӿ��� ���� ���� ����
    [SerializeField] public float totalCoin; // ���� ���� ����  

    //bonusTime������ ���� ó������ ����̶� �ϴ� ���� ������Ʈ�� ����� �ξ����ϴ�.
    [SerializeField] public GameObject[] BonusTimeJelly; //���ʽ�Ÿ������ ��������

    private void Update()
    {
        if (currentJellyPoint >= bestJellyPoint)
            bestJellyPoint = currentJellyPoint;
    }

    public AudioClip LoadAudioClip(string path) //SoundManager�� ���ҽ��� �ε��ϱ� ���� �޼ҵ�
    {
        if (!path.StartsWith("Sounds/"))
        {
            path = "Sounds/" + path;
        }

        AudioClip audioClip = Resources.Load<AudioClip>(path); // Resources �������� AudioClip�� �ε��մϴ�.

        if (audioClip == null) //���� ���
        {
            Debug.LogError($"AudioClip not found at path: {path}");
        }

        return audioClip;
    }
}
