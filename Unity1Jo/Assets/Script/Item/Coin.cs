using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Player p;
    [SerializeField] private float CoinPoint;
    [SerializeField] string effectAudioClipPath = "SoundEff_GetCoinJelly";

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Effect���
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.IngameEffect);

            GameManager.Instance.totalCoin += CoinPoint; //GameManager�� coin������ �� ���� �� ��ŭ ����
            GameManager.Instance.currentCoin += CoinPoint; //InGame���� ���̴� coin����
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
