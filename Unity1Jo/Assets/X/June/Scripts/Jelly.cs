using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jelly : MonoBehaviour
{
    [SerializeField] private float JellyPoint;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.currentJellyPoint += JellyPoint; //GameManager�� �ִ� ���� ���� ����
            //SoundManager.Instance.PlaySound("jelly");
            Destroy(gameObject); //������Ű��

        }
    }
    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
       
    }

    void Update()
    {
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
