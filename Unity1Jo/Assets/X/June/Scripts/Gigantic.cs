using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigantic : MonoBehaviour
{
    GameObject player;
    public float Size;

    private bool isTriggerEneter;

    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Size = p.GiganticSize; //���Ӹ޴������� ���� �����ϰ� ��
    }

    //private void Start()
    //{
    //    Size = p.GiganticSize; //���Ӹ޴������� ���� �����ϰ� ��
    //}
    private void OnTriggerEnter2D(Collider2D collision) //�÷��̾�� ����� ��
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾��� �±װ� ���� ��
        {
            player = GameObject.FindGameObjectWithTag("Player"); //���ӿ�����Ʈ�� ���� ��� ���ӿ�����Ʈ ����
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //�÷��̾��� �̹��� ����
            p.GiganticDuration = p.GiganticTime; //������ ���� �ð� �ʱ�ȭ

            if (!p.isGigantic) //�Ŵ�ȭ ���°� �ƴ� ��
            {
                player.transform.position += new Vector3(0, Size / 10, 0);// ������ �� �����̱�
                for (int i = 0; i < Size; i++) //���� ������ ��ŭ Ŀ��
                {
                    StartCoroutine(SizeUp()); //������ �� �ϱ�
                }

            }
            p.isGigantic = true;
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);//�ڽ����� �ִ� �Ŵ�ȭ ���� �� ����

            isTriggerEneter = true; 
            Invoke("DestroySelf", 5); //5�� �� ���� ����
        }
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);



        if (isTriggerEneter) //�浹 �ȴٸ� �ڽİ�ü�� �ִ� �Ŵ�ȭ ���� ����ϰ� �ϱ�
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 3f * Time.deltaTime);
            StartCoroutine(ShowText());

        }
        if (p.GiganticDuration <= 0) //�Ŵ�ȭ ���ӽð��� �����ٸ�
        {
            p.isGigantic = false;
            if (GameObject.FindGameObjectWithTag("Player").transform.localScale != p.OriginalSize) //������ ũ��� ���� ũ�Ⱑ ��ġ ���� �ʴ´ٸ�
            {
                StartCoroutine(SizeDown());

            }


        }
    }

    IEnumerator SizeDown()
    {
        GameObject.FindGameObjectWithTag("Player").transform.localScale -= new Vector3(0.1f, 0.1f, 0); //�÷��̾��� ���ý����ϰ� ����

        yield return new WaitForSeconds(0.1f);
    }



    void DestroySelf() //������� ���ư��� �Լ�
    {
        Destroy(gameObject);//���� ������Ʈ ����
    }


    IEnumerator SizeUp()
    {
        player.transform.localScale += new Vector3(0.1f, 0.1f, 0); //�÷��̾��� ���ý����ϰ� 3 ����

        yield return new WaitForSeconds(0.1f);
    }


    IEnumerator ShowText() //�ڽ� ��ü�� �ִ� ���� �����ֱ�
    {
        transform.GetChild(0).transform.position += new Vector3(Time.deltaTime, 0, 0); 
        yield return new WaitForSeconds(0.2f);
    }
}
