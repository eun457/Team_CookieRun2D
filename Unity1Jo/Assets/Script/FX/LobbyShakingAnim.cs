using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyShakingAnim : MonoBehaviour //code by.����
{
    public float swingSpeed = 1.0f; // ��鸮�� �ӵ� ����
    public float swingAmount = 1.0f; // ��鸮�� ���� ����

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Sin �Լ��� ����Ͽ� �¿�� ��鸮�� �������� ����
        float xOffset = Mathf.Sin(Time.time * swingSpeed) * swingAmount;

        // �ʱ� ��ġ�� �������� �¿�� �̵�
        transform.position = initialPosition + new Vector3(xOffset, 0f, 0f);
    }
}
