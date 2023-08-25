using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
   
    public GameObject[] Ground;//��� �� Ground �迭�� ��������

    private void OnTriggerEnter2D(Collider2D collision) //trigger�� ����� ��
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾���
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //������ �̹��� ����
            //for(int i = 0; i < Ground.Length; i++) //�迭 ũ�� ��ŭ �ݺ�
            //{
            //Ground[i].GetComponent<GroundScroll>().ScrollSpeed *= 3; //��� �迭�� �ӵ� 3 ����

            //}
            GameManager.Instance.GroundScrollSpeed *= 3;
            Invoke("goingToOrigin", 3); //3�ʵ� ���󺹱� ��Ű��
        }
    }
    void Update()
    {
        transform.position += new Vector3(-GameManager.Instance.GroundScrollSpeed * Time.deltaTime, 0, 0);
    }

    void goingToOrigin() //���󺹱� ��Ű�� �Լ�
    {
        //for (int i = 0; i < Ground.Length; i++)
        //{
        //    Ground[i].GetComponent<GroundScroll>().ScrollSpeed /= 3; //��� �迭�� �ӵ� 3�� ����

        //}
        GameManager.Instance.GroundScrollSpeed /= 3;
        Destroy(gameObject); //������Ű��
    }
}
