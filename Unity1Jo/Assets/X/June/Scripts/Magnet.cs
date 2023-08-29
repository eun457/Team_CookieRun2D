using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    Player p;

    private bool isTriggerEneter;

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            p.isMagnet = true;
            p.MagnetDuration = p.MagnetTime;
            isTriggerEneter = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //������ �̹��� ����
            
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);//�ڽ����� �ִ� �Ŵ�ȭ ���� �� ����


            Invoke("SelfDestroy", 10); //5�ʵ� ���� ����

        }
    }
    void Update()
    {
       
        if (p.MagnetDuration < 0)
        {
            p.isMagnet = false;
        }

        if (isTriggerEneter) //�浹 �ȴٸ� �ڽİ�ü�� �ִ� �ڼ� ���� ����ϰ� �ϱ�
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 3f * Time.deltaTime);
            StartCoroutine(ShowText());

        }
    }



    private void SelfDestroy()
    {
      
        Destroy(gameObject); //������Ű��
    }
    IEnumerator ShowText() //�ڽ� ��ü�� �ִ� ���� �����ֱ�
    {
        transform.GetChild(0).transform.position -= new Vector3(Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(0.2f);
    }
}
