using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{

    public GameObject[] Ground;//��� �� Ground �迭�� ��������

    private bool isTriggerEneter;



    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //trigger�� ����� ��
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾���
        {
            p.DashDuration = p.DashTime;//�뽬 ���ӽð� �ʱ�ȭ

            gameObject.GetComponent<SpriteRenderer>().enabled = false; //������ �̹��� ����

            p.isDashing = true;
            if (p.DashDuration > 0) //�뽬 ���ӽð��� �����ִٸ�.
            {
                p.GroundScrollSpeed = p.OriginalGroundScrollSpeed * 3; //���� �ӵ����� 3�� �������� ���� �־���

            }
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0); //�ڽİ�ü�� �ִ� ���� ����

            isTriggerEneter = true;


            Invoke("DestroySelf", 5); //5�ʵ� ���� ����
        }
    }
    void Update()
    {


        if (p.isMagnet)
        {
            transform.position = Vector3.MoveTowards(transform.position, p.gameObject.transform.position - new Vector3(0, 2, 0), p.MagnetSpeed);
        }
        else
            transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);
        if (isTriggerEneter)  //���� �����ֱ�
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 3f * Time.deltaTime);
            StartCoroutine(ShowText());

        }
        if (p.DashDuration <= 0)
        {
            p.GroundScrollSpeed = p.OriginalGroundScrollSpeed;
            p.isDashing = false;
        }



    }

    void DestroySelf() 
    {
        Destroy(gameObject); //������Ű��
    }

    IEnumerator ShowText()
    {
        transform.GetChild(0).transform.position += new Vector3(Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(0.2f);
    }

}
