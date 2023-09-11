using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jelly : MonoBehaviour
{
    [SerializeField] private float JellyPoint;
    [SerializeField] string effectAudioClipPath = "SoundEff_GetJelly";

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.currentJellyPoint += JellyPoint; //GameManager�� �ִ� ���� ���� ����
                                                                  //SoundManager.Instance.PlaySound("jelly");

            //Effect���
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.IngameEffect);

            Destroy(gameObject); //������Ű��  

        }

        if (collision.gameObject.CompareTag("Jelly") || collision.gameObject.CompareTag("Item") 
            || collision.gameObject.CompareTag("SpawnGround") || collision.gameObject.CompareTag("Enemy")
            || collision.gameObject.CompareTag("Coin"))
        {
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
