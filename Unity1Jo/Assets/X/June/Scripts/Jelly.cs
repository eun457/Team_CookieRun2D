using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jelly : MonoBehaviour
{
    [SerializeField] private float JellyPoint;

    private AudioSource audioSource;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
        //if (gameObject.GetComponent<AudioSource>() != null)
        //{

        //    audioSource = GetComponent<AudioSource>();
        //}


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.currentJellyPoint += JellyPoint; //GameManager�� �ִ� ���� ���� ����
                                                                  //SoundManager.Instance.PlaySound("jelly");

            //if (gameObject.GetComponent<AudioSource>() != null)
            //{
            //    audioSource.Play();
            //}
            Destroy(gameObject); //������Ű��  

        }
    }
    Player p;

    void Update()
    {

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
