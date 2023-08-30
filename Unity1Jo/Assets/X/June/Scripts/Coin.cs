using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }



    [SerializeField] private float CoinPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GameManager.Instance.TotalCoin += CoinPoint; //GameManager�� coin������ �� ���� �� ��ŭ ����
            GameManager.Instance.IngameCoin += CoinPoint; //InGame���� ���̴� coin����
            Destroy(gameObject); //����
        }
    }
    void Update()
    {
       
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
