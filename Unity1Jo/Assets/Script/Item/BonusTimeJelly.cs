using System.Collections;using System.Collections.Generic;
using UnityEngine;

public class BonusTimeJelly : MonoBehaviour
{
    [SerializeField] private float JellyPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.currentJellyPoint += JellyPoint; //GameManager�� �ִ� ���� ���� ����
           // GameManager.Instance.BonusTimeJelly[0] = gameObject;
            
            Destroy(gameObject); //������Ű��

        }
    }





}
