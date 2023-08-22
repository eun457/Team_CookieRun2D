using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigantic : MonoBehaviour
{
    GameObject player;
    private void OnTriggerEnter2D(Collider2D collision) //�÷��̾�� ����� ��
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾��� �±װ� ���� ��
        {
            player = collision.gameObject; //���ӿ�����Ʈ�� ���� ��� ���ӿ�����Ʈ ����
            player.GetComponent<SpriteRenderer>().enabled = false; //�÷��̾��� �̹��� ����
            player.transform.localScale = new Vector3(3, 3, 0); //�÷��̾��� ���ý����ϰ� 3 ����
        }
        Invoke("goingToOrigin", 3); //3�� �� ������� ���ư��� �Լ� ����
    }


    void goingToOrigin() //������� ���ư��� �Լ�
    {
        player.transform.localScale = new Vector3(-3, 3, 0);//�÷��̾��� ���ý����� 3 ����

        Destroy(gameObject);//���� ������Ʈ ����
    }
}
