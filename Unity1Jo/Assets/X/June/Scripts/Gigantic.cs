using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigantic : MonoBehaviour
{
    GameObject player;
    public float Size;

    private void Start()
    {
        Size *= 10;
    }
    private void OnTriggerEnter2D(Collider2D collision) //�÷��̾�� ����� ��
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾��� �±װ� ���� ��
        {
            player = GameObject.FindGameObjectWithTag("Player"); //���ӿ�����Ʈ�� ���� ��� ���ӿ�����Ʈ ����
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //�÷��̾��� �̹��� ����
            player.transform.position += new Vector3(0, Size/10, 0);// ������ �� �����̱�
            
            for(int i = 0; i < Size;i++) //���� ������ ��ŭ Ŀ��
            {
                StartCoroutine(SizeUp());
            }
        }
        Invoke("goingToOrigin", 3); //3�� �� ������� ���ư��� �Լ� ����
    }

    void Update()
    {
        transform.position += new Vector3(-GameManager.Instance.GroundScrollSpeed * Time.deltaTime, 0, 0);
    }

    void goingToOrigin() //������� ���ư��� �Լ�
    {
        player.transform.position -= new Vector3(0, Size / 9, 0);

        for (int i = 0; i < Size; i++)
        {
            StartCoroutine(SizeDown());
        }
        Destroy(gameObject);//���� ������Ʈ ����
    }


    IEnumerator SizeUp()
    {
        player.transform.localScale += new Vector3(0.1f, 0.1f, 0); //�÷��̾��� ���ý����ϰ� 3 ����

        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator SizeDown()
    {
        player.transform.localScale -= new Vector3(0.1f, 0.1f, 0); //�÷��̾��� ���ý����ϰ� 3 ����

        yield return new WaitForSeconds(0.1f);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
