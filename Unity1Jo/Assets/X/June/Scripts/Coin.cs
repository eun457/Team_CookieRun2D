using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float CoinPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GameManager.Instance.Coin += CoinPoint; //GameManager�� coin������ �� ���� �� ��ŭ ����
            Destroy(gameObject); //����
        }
    }
    void Update()
    {
        transform.position += new Vector3(-GameManager.Instance.GroundScrollSpeed * Time.deltaTime, 0, 0);
    }
}
