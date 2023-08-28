using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{

    public GameObject[] Ground;//��� �� Ground �迭�� ��������

    private bool isTriggerEneter;

    
    

    private void OnTriggerEnter2D(Collider2D collision) //trigger�� ����� ��
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾���
        {
            GameManager.Instance.DashDuration = GameManager.Instance.DashTime;//�뽬 ���ӽð� �ʱ�ȭ

            gameObject.GetComponent<SpriteRenderer>().enabled = false; //������ �̹��� ����

            GameManager.Instance.isDashing = true;
            if (GameManager.Instance.DashDuration > 0) //�뽬 ���ӽð��� �����ִٸ�.
            {
                GameManager.Instance.GroundScrollSpeed = GameManager.Instance.OriginalGroundScrollSpeed * 3; //���� �ӵ����� 3�� �������� ���� �־���

            }
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0); //�ڽİ�ü�� �ִ� ���� ����

            isTriggerEneter = true;


            Invoke("DestroySelf", 5); //5�ʵ� ���� ����
        }
    }
    void Update()
    {
        

        transform.position += new Vector3(-GameManager.Instance.GroundScrollSpeed * Time.deltaTime, 0, 0);
        if (isTriggerEneter)  //���� �����ֱ�
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 3f * Time.deltaTime);
            StartCoroutine(ShowText());

        }
        if (GameManager.Instance.DashDuration <= 0)
        {
            GameManager.Instance.GroundScrollSpeed = GameManager.Instance.OriginalGroundScrollSpeed;
            GameManager.Instance.isDashing = false;
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
